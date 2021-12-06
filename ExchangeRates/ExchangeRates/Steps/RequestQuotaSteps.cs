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

        [When]
        public void WhenTheUserSendsRequestToQuotaAPI()
        {
            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(APIKey + EndpointRequestQuota, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [Then]
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
    }
}
