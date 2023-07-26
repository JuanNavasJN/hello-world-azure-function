using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Veest.Function
{
    public static class HelloWorld
    {
        [FunctionName("hello-world")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            if(string.IsNullOrEmpty(name))
            {
                return new OkObjectResult(new
                {
                    Message = "No name"
                });
            }

            return new OkObjectResult(new
            {
                Message = $"Hello World - {name}"
            });
        }
    }
}
