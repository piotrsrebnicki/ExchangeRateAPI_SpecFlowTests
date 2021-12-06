Feature: Supported Codes
	Gets currency codes supported by ExchangeRateAPI

@mytag
Scenario: Get currency codes supported by ExchangeRateAPI
	When the user sends request
	Then the result should be success