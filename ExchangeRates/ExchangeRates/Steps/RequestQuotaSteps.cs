using ExchangeRates.Objects;
using FluentAssertions;
using FluentAssertions.Execution;
using RestSharp;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow;

namespace ExchangeRates.Steps
{
    [Binding]
    public class APIRequestQuotaSteps
    {
        private RestClient RestClient { get; set; }
        private RestRequest RestRequest { get; set; }
        private IRestResponse RestResponse { get; set; }

        private const string APIKey = "4ad3799d170ec86655e1542a";
        private const string BaseUrl = "https://v6.exchangerate-api.com/v6";
        private const string EndpointRequestQuota = "/quota";

        [When(@"the user sends request to Quota API")]
        public void WhenTheUserSendsRequestToQuotaAPI()
        {
            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(APIKey + EndpointRequestQuota, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [When(@"the user sends quota request without API Key")]
        public void WhenTheUserSendsQuotaRequestWithoutAPIKey()
        {
            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(EndpointRequestQuota, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [Then(@"the result should contain required information")]
        public void ThenTheResultShouldContainRequiredInformation()
        {
            var expectedResultInfo = "success";
            var expectedPlanQuota = 1500;
            var expectedRefreshDayOfMonth = 2;
            var expectedDocUrl = "https://www.exchangerate-api.com/docs";
            var expectedTermsOfUseUrl = "https://www.exchangerate-api.com/terms";

            RequestQuotaResponse requestQuotaResponse = new JsonDeserializer().Deserialize<RequestQuotaResponse>(RestResponse);

            using (new AssertionScope())
            {
                requestQuotaResponse.Result.Should().Be(expectedResultInfo);
                requestQuotaResponse.Documentation.Should().Be(expectedDocUrl);
                requestQuotaResponse.TermsOfUse.Should().Be(expectedTermsOfUseUrl);
                requestQuotaResponse.PlanQuota.Should().Be(expectedPlanQuota);
                requestQuotaResponse.RefreshDayOfMonth.Should().Be(expectedRefreshDayOfMonth);
                requestQuotaResponse.RequestsRemaining.Should().BeInRange(0, expectedPlanQuota);
            }
        }

        [Then(@"the request quota response should be error")]
        public void ThenTheRequestQuotaResponseShouldBeError()
        {
            var expectedResultInfo = "error";
            var expectedDocUrl = "https://www.exchangerate-api.com/docs";
            var expectedTermsOfUseUrl = "https://www.exchangerate-api.com/terms";

            ErrorResponse errorResponse = new JsonDeserializer().Deserialize<ErrorResponse>(RestResponse);

            using (new AssertionScope())
            {
                errorResponse.Result.Should().Be(expectedResultInfo);
                errorResponse.Documentation.Should().Be(expectedDocUrl);
                errorResponse.TermsOfUse.Should().Be(expectedTermsOfUseUrl);
                errorResponse.ErrorType.Should().ContainAny(ErrorTypes.errorTypes);
            }
        }
    }
}
