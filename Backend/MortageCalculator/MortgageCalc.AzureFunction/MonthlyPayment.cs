using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MortgageCalculator;




namespace MortgageCalc.AzureFunction
{
    public static class Function1
    {
        [FunctionName("GetMonthlyPayment")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string years = req.Query["years"];
            string rate = req.Query["rate"];
            string principal = req.Query["principal"];

            var monnthlyPayment = MortgageCalculator.MortgageCalculator.MonthlyPayment(double.Parse(principal), int.Parse(years), double.Parse(rate));

            var jsonObj = new
            {
                MonthlyPayment = monnthlyPayment
            };

            return new OkObjectResult(jsonObj);
        }
    }
}
