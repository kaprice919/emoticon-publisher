using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class EmoticonPubisherSteps
    {
        [Given("the slack slash command /emoticon is run")]
        public void theSlackSlashCommandEmoticonsIsRun()
        {

        }
        [When("the EmoticonPublisher function gets a POST request with the following data")]
        public void EmoticonPublisherFunctionRunsWhenPOSTRequestWithData(string requestBody)
        {

        }

        [Then("we respond to slack with the following data")]
        public void RespondToSlackWithValidResponseData(string responseBody)
        {
            
        }
    }
}
