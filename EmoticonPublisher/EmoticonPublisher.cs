using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class EmoticonPublisher
    {
        [FunctionName("EmoticonPublisher")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var name = req.Query["text"];
            log.LogInformation($"Request recieved for a {name}");

            return @"{
                        ""response_type"": ""in_channel"",
                        ""text"": ""ʕ •ᴥ•ʔ""
                    }";
        }
    }
}
