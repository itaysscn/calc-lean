using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;
using WebApplication1.Repository;
using WebApplication1.service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public LoanController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpPost("calculate")]
        public ActionResult<LoanResponse> CalculateLoan([FromBody] LoanRequest request)
        {
            if (request.PeriodMonths < 12)
            {
                return BadRequest(new LoanResponse { Message = "תקופת ההלוואה חייבת להיות לפחות 12 חודשים" });
            }

            var client = _clientRepository.GetClientById(request.ClientId);
            if (client == null)
            {
                return NotFound(new LoanResponse { Message = "הלקוח לא נמצא" });
            }

            var strategy = LoanStrategyFactory.GetLoanStrategy(client.Age, request.Amount);
            decimal interest = strategy.CalculateInterest(request.Amount, request.PeriodMonths);
            decimal totalAmount = request.Amount + interest;

            return Ok(new LoanResponse
            {
                TotalAmount = totalAmount,
                InterestAmount = interest,
                Message = "חישוב הלוואה בוצע בהצלחה"
            });
        }

    }
}
