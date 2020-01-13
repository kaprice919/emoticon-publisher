using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class EmoticonPubisherSteps
    {
        [Given("the slack command emoticon is run")]
        public void theSlackSlashCommandEmoticonsIsRun()
        {
            
        }
        [When("the EmoticonPublisher function gets a POST request with the following data")]
        public async void EmoticonPublisherFunctionRunsWhenPOSTRequestWithData(string requestBody)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.PostAsync
            (
                $"http://localhost:7071/admin/functions/EmoticonPublisher", 
                new StringContent("requestBody=fds&token=fds", UnicodeEncoding.UTF8, "application/x-www-form-urlencoded")
            );
            responseMessage.EnsureSuccessStatusCode();
        }

        [Then("we respond to slack with the following data")]
        public void RespondToSlackWithValidResponseData(string responseBody)
        {
            
        }
    }
}
