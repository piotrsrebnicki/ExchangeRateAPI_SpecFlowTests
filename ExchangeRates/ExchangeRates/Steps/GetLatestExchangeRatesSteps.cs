using ExchangeRates.Objects;
using FluentAssertions;
using FluentAssertions.Execution;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using TechTalk.SpecFlow;

namespace ExchangeRates.Steps
{
    [Binding]
    public class GetLatestExchangeRatesSteps
    {
        private RestClient RestClient { get; set; }
        private RestRequest RestRequest { get; set; }
        private IRestResponse RestResponse { get; set; }

        private const string APIKey = "4ad3799d170ec86655e1542a";
        private const string BaseUrl = "https://v6.exchangerate-api.com/v6";
        private const string EndpointLatest = "/latest/";

        private readonly ScenarioContext _scenarioContext;

        public GetLatestExchangeRatesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user wants to retrieve currency conversion for (.*)")]
        public void GivenTheUserWantsToRetrieveCurrencyConversionFor(string currency)
        {
            _scenarioContext.Add("currency", currency);
        }

        [Given(@"the user wants to download currency conversion for invalid currency code (.*)")]
        public void GivenTheUserWantsToDownloadCurrencyConversionForInvalidCurrencyCode(string currency)
        {
            _scenarioContext.Add("currency", currency);
        }

        [When(@"the user sends the request")]
        public void WhenTheUserSendsTheRequest()
        {
            var currency = _scenarioContext.Get<string>("currency");

            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(APIKey + EndpointLatest + currency, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [When(@"the user sends the request without API Key")]
        public void WhenTheUserSendsTheRequestWithoutAPIKey()
        {
            var currency = _scenarioContext.Get<string>("currency");

            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(EndpointLatest + currency, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [Then(@"the response should be successful")]
        public void ThenTheResponseShouldBeSuccessful()
        {
            var currency = _scenarioContext.Get<string>("currency").ToUpper();
            var expectedDocUrl = "https://www.exchangerate-api.com/docs";
            var expectedTermsOfUseUrl = "https://www.exchangerate-api.com/terms";
            var expectedResultInfo = "success";
            var expectedDate = DateTime.Now.Date;
            LatestEndpointResponse latestRatesResponse = new JsonDeserializer().Deserialize<LatestEndpointResponse>(RestResponse);

            using (new AssertionScope())
            {
                latestRatesResponse.BaseCode.Should().Be(currency);
                latestRatesResponse.Documentation.Should().Be(expectedDocUrl);
                latestRatesResponse.Result.Should().Be(expectedResultInfo);
                latestRatesResponse.TermsOfUse.Should().Be(expectedTermsOfUseUrl);
                latestRatesResponse.TimeLastUpdateUtc.Date.Should().Be(expectedDate);
            }
        }

        [Then(@"the response should be error")]
        public void ThenTheResponseShouldBeError()
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
