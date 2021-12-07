using ExchangeRates.Objects;
using FluentAssertions;
using FluentAssertions.Execution;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ExchangeRates.Steps
{
    [Binding]
    public class SupportedCodesSteps
    {
        private RestClient RestClient { get; set; }
        private RestRequest RestRequest { get; set; }
        private IRestResponse RestResponse { get; set; }

        private const string APIKey = "4ad3799d170ec86655e1542a";
        private const string BaseUrl = "https://v6.exchangerate-api.com/v6";
        private const string EndpointSupportedCodes = "/codes";

        [When(@"the user sends request")]
        public void WhenTheUserSendsRequest()
        {
            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(APIKey + EndpointSupportedCodes, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [When(@"the user sends request without API Key")]
        public void WhenTheUserSendsRequestWithoutAPIKey()
        {
            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(EndpointSupportedCodes, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [Then(@"the result should be success")]
        public void ThenTheResultShouldBeSuccess()
        {
            var expectedResultInfo = "success";
            var expectedDocUrl = "https://www.exchangerate-api.com/docs";
            var expectedTermsOfUseUrl = "https://www.exchangerate-api.com/terms";

            SupportedCodesResponse supportedCodesResponse = new JsonDeserializer().Deserialize<SupportedCodesResponse>(RestResponse);

            using (new AssertionScope())
            {
                supportedCodesResponse.Result.Should().Be(expectedResultInfo);
                supportedCodesResponse.SupportedCodes.Should().BeOfType<List<List<string>>>();
                supportedCodesResponse.Documentation.Should().Be(expectedDocUrl);
                supportedCodesResponse.TermsOfUse.Should().Be(expectedTermsOfUseUrl);
            }
        }

        [Then(@"the Supported Codes response should be error")]
        public void ThenTheSupportedCodesResponseShouldBeError()
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
