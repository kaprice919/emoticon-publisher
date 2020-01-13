using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Company.Function
{
    public static class EmoticonPublisher
    {
        [FunctionName("EmoticonPublisher")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var reqData = parseQueryString(req);
            var emoticonName = reqData["text"];

            var emoticon = "Emoticon not recognized.";
            if (emoticonName.ToLower().Equals("koala"))
            {
                emoticon = "ʕ•ᴥ•ʔ";
            }

            var response = new {response_type = "in_channel", text = emoticon};
            var responseJson = JsonConvert.SerializeObject(response);

            return new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            };
        }

        private static Dictionary<string, string> parseQueryString(HttpRequest req){
            
            Dictionary<string, string> reqData = new Dictionary<string, string>();

            var requestBody = new StreamReader(req.Body).ReadToEndAsync().Result;
            foreach (var item in requestBody.Split('&'))
            {
                    var keyvalue = item.Split('=');
                    reqData.Add(keyvalue[0],keyvalue[1]);
            }

            return reqData;
        }
    }
}