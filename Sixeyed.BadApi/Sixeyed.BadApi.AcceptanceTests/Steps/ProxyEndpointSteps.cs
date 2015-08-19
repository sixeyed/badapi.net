using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Sixeyed.BadApi.AcceptanceTests.Steps
{
    [Binding]
    public class ProxyEndpointSteps : ApiStepBase
    {
        private string _proxyPrefix;
        private string _domainToProxy;

        [Given(@"I want to test my client handles a (.*): ""(.*)"" response")]
        public void GivenIWantToTestMyClientHandlesABadRequestResponse(int statusCode, string status)
        {
            _proxyPrefix = statusCode.ToString();
        }

        [Given(@"I want to test my client handles a ""(.*)"" failure")]
        public void GivenIWantToTestMyClientHandlesAFailure(string failureType)
        {
            _proxyPrefix = failureType;
        }

        [Given(@"I have proxied ""(.*)"" to point to badapi\.net")]
        public void GivenIHaveProxiedToPointToBadapi_Net(string myDomain)
        {
            _domainToProxy = myDomain;
        }

        [When(@"I make a GET request to ""(.*)""")]
        public void WhenIMakeAGETRequestTo(string originalUrl)
        {
            //simulate the proxy redirect by replacing the URL:
            var domain = ConfigurationManager.AppSettings["api.domain"];
            RequestUrl = originalUrl.Replace(_domainToProxy, string.Format("{0}.{1}", _proxyPrefix, domain));
            GetResponse();
        }

        [Then(@"the API returns with response code '(.*)'")]
        public void ThenTheAPIReturnsWithResponseCode(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)ResponseMessage.StatusCode);
        }

        [Then(@"the API returns with response code ""(.*)"" or ""(.*)""")]
        public void ThenTheAPIReturnsWithResponseCodeOr(int expectedStatusCode1, int expectedStatusCode2)
        {
            var responseStatuseCode = (int)ResponseMessage.StatusCode;
            Assert.IsTrue(responseStatuseCode == expectedStatusCode1 || responseStatuseCode == expectedStatusCode2);
        }

        [Then(@"the response does not contain a body")]
        public void ThenTheResponseDoesNotContainABody()
        {
            Assert.IsTrue(string.IsNullOrEmpty(ResponseBody));
        }
    }
}
