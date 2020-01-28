using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.WebUtilities;

namespace EmoticonPublisher
{
    public static class EmoticonPublisher
    {
        [FunctionName("EmoticonPublisher")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var reqBody = new StreamReader(req.Body).ReadToEndAsync().Result;
            var reqData = QueryHelpers.ParseQuery(reqBody);
            string emoticonName = reqData["text"].ToString();

            string emoticonText = EmoticonFactory.createEmoticon(emoticonName);

            var response = new {response_type = "in_channel", text = emoticonText};
            var responseJson = JsonConvert.SerializeObject(response);

            return new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            };
        }
    }
}