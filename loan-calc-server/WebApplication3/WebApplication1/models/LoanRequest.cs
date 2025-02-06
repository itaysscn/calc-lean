namespace WebApplication1.models
{
    public class LoanRequest
    {
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public int PeriodMonths { get; set; }
    }
    public class LoanResponse
    {
        public decimal TotalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public string Message { get; set; }
    }
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


}
