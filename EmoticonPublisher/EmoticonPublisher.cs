using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace EmoticonPublisher
{
    public static class EmoticonService
    {
        [FunctionName("EmoticonService")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string emoticonName = data?.text;

            string emoticonText = EmoticonFactory.generateEmoticon(emoticonName);
            return buildValidResponse(emoticonText);
        }

        private static HttpResponseMessage buildValidResponse(string emoticonText)
        {
            var response = new { response_type = "in_channel", text = emoticonText };
            var responseJson = JsonConvert.SerializeObject(response);

            var responsePackage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            };
            
            return responsePackage;
        }
    }
}
