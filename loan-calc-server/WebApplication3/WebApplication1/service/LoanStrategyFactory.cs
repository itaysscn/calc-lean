namespace WebApplication1.service
{
    public static class LoanStrategyFactory
    {
        public static ILoanStrategy GetLoanStrategy(int age, decimal amount)
        {
            if (age < 20) return new YoungClientLoanStrategy();
            if (age >= 20 && age <= 35) return new MidAgeClientLoanStrategy();
            return new SeniorClientLoanStrategy();
        }
    }
    public class YoungClientLoanStrategy : ILoanStrategy
    {
        private const decimal PrimeRate = 1.5m;
        public decimal CalculateInterest(decimal amount, int periodMonths)
        {
            decimal baseInterest = amount * (0.02m + PrimeRate);
            decimal extraMonthsInterest = (periodMonths - 12) * (amount * 0.0015m);
            return baseInterest + (extraMonthsInterest > 0 ? extraMonthsInterest : 0);
        }
    }

    public class MidAgeClientLoanStrategy : ILoanStrategy
    {
        private const decimal PrimeRate = 1.5m;
        public decimal CalculateInterest(decimal amount, int periodMonths)
        {
            decimal baseRate;
            if (amount <= 5000)
            {
                baseRate = 0.02m; ; // ריבית קבועה של 2%
            }
            else if (amount <= 30000)
            {
                baseRate = 0.015m + PrimeRate; // ריבית של 1.5% + ריבית פריים
            }
            else
            {
                baseRate = 0.01m + PrimeRate; // ריבית קבועה של 1%
            }

            decimal baseInterest = amount * baseRate;
            decimal extraMonthsInterest = (periodMonths - 12) * (amount * 0.0015m);
            return baseInterest + Math.Max(0, extraMonthsInterest);
        }
    }

    public class SeniorClientLoanStrategy : ILoanStrategy
    {
        private const decimal PrimeRate = 1.5m;
        public decimal CalculateInterest(decimal amount, int periodMonths)
        {
            //decimal baseRate = amount switch
            //{
            //    <= 15000 => 0.015m + PrimeRate,
            //    > 15000 and <= 30000 => 0.03m + PrimeRate,
            //    _ => 0.01m
            //};
            decimal baseRate;
            if (amount <= 15000)
            {
                baseRate = 0.015m + PrimeRate; // ריבית של 1.5% + ריבית פריים
            }
            else if (amount <= 30000)
            {
                baseRate = 0.03m + PrimeRate; // ריבית של 3% + ריבית פריים
            }
            else
            {
                baseRate = 0.01m; // ריבית קבועה של 1%
            }

            decimal baseInterest = amount * baseRate;
            decimal extraMonthsInterest = (periodMonths - 12) * (amount * 0.0015m);
            return baseInterest + Math.Max(0, extraMonthsInterest);
        }
    }

}
