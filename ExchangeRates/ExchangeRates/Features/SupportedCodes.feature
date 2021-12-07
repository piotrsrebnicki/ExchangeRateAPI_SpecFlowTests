Feature: Supported Codes
	Gets currency codes supported by ExchangeRateAPI

@SupportedCodes_happyPath
Scenario: Get currency codes supported by ExchangeRateAPI
	When the user sends request
	Then the result should be success

@SupportedCodes_requestWithoutAPIKey
Scenario: Get currency codes supported by ExchangeRateAPI - sending request without API Key
	When the user sends request without API Key
	Then the Supported Codes response should be error