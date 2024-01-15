namespace MortgageCalculator.Test
{
    [TestClass]
    public class MortgageCalculatorTests
    {
        [TestMethod]
        public  void MortgageCalculator_CorrectMonthlyPayment()
        {
            var monthlyPayment = MortgageCalculator.MonthlyPayment(400000, 30, 5);
            Assert.AreEqual(Math.Round(monthlyPayment,2), 2147.29);
        }
    }
}