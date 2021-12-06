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
    public class PairConversionSteps
    {
        private RestClient RestClient { get; set; }
        private RestRequest RestRequest { get; set; }
        private IRestResponse RestResponse { get; set; }

        private const string APIKey = "4ad3799d170ec86655e1542a";
        private const string BaseUrl = "https://v6.exchangerate-api.com/v6";
        private const string EndpointPairConversion = "/pair/";

        private readonly ScenarioContext _scenarioContext;

        public PairConversionSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the first currency is (.*)")]
        public void GivenTheFirstCurrencyIs(string firstCurrency)
        {
            _scenarioContext.Add("firstCurrency", firstCurrency);
        }

        [Given(@"the second currency is (.*)")]
        public void GivenTheSecondCurrencyIs(string secondCurrency)
        {
            _scenarioContext.Add("secondCurrency", secondCurrency);
        }

        [Given(@"the amount is (.*)")]
        public void GivenTheAmountIs(decimal amount)
        {
            _scenarioContext.Add("amount", amount);
        }


        [When(@"the user sends the request for pair conversion")]
        public void WhenTheUserSendsTheRequestForPairConversion()
        {
            var firstCurrency = _scenarioContext.Get<string>("firstCurrency");
            var secondCurrency = _scenarioContext.Get<string>("secondCurrency");

            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(APIKey + EndpointPairConversion + firstCurrency + "/" + secondCurrency, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }

        [When(@"the user sends the request for pair conversion with amount")]
        public void WhenTheUserSendsTheRequestForPairConversionWithAmount()
        {
            var firstCurrency = _scenarioContext.Get<string>("firstCurrency");
            var secondCurrency = _scenarioContext.Get<string>("secondCurrency");
            var amount = _scenarioContext.Get<decimal>("amount");

            RestClient = new RestClient(BaseUrl);
            RestRequest = new RestRequest(APIKey + EndpointPairConversion + firstCurrency + "/" + secondCurrency + "/" + amount, Method.GET);

            RestResponse = RestClient.Execute(RestRequest);
        }


        [Then(@"the response should be success")]
        public void ThenTheResponseShouldBeSuccess()
        {
            var expectedResultInfo = "success";
            var firstCurrency = _scenarioContext.Get<string>("firstCurrency").ToUpper();
            var secondCurrency = _scenarioContext.Get<string>("secondCurrency").ToUpper();
            var expectedDocUrl = "https://www.exchangerate-api.com/docs";
            var expectedTermsOfUseUrl = "https://www.exchangerate-api.com/terms";

            PairConversionResponse pairConversionRatesResponse = new JsonDeserializer().Deserialize<PairConversionResponse>(RestResponse);

            using (new AssertionScope())
            {
                pairConversionRatesResponse.Result.Should().Be(expectedResultInfo);
                pairConversionRatesResponse.BaseCode.Should().Be(firstCurrency);
                pairConversionRatesResponse.TargetCode.Should().Be(secondCurrency);
                pairConversionRatesResponse.Documentation.Should().Be(expectedDocUrl);
                pairConversionRatesResponse.TermsOfUse.Should().Be(expectedTermsOfUseUrl);
            }
        }
    }
}
