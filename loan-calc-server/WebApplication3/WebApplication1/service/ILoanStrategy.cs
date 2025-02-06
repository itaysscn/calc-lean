namespace WebApplication1.service
{
    public interface ILoanStrategy
    {
        decimal CalculateInterest(decimal amount, int periodMonths);
    }
}
