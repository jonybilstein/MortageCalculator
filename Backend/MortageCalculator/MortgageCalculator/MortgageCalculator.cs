namespace MortgageCalculator
{
    
    
    
    public static class MortgageCalculator
    {
        public static double MonthlyPayment(double principal, int years, double interestRate)
        {
            var interestRateDec = interestRate / 100;
            var numerator = principal * interestRateDec / 12;

            var denominator = 1 - Math.Pow(1 + interestRateDec / 12, -1 * 12 * years);

            return numerator / denominator;
        }
    }
}