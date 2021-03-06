Feature: Pair Conversion
	Allows you to download the exchange rate of two specific currencies

@pairConversion_happyPath_PLN_GBP
Scenario: Get exchange rate between two currencies
	Given the first currency is PLN
	And the second currency is GBP
	When the user sends the request for pair conversion
	Then the response should be success

@pairConversion_happyPath_VuV_rsd
Scenario: Get exchange rate between two currencies - typing currencies should be case insesitive
	Given the first currency is VuV
	And the second currency is rsd
	When the user sends the request for pair conversion
	Then the response should be success

@pairConversion_happyPath_withAmount
Scenario: Get exchange rate between two currencies - with given amount
	Given the first currency is PLN
	And the second currency is EUR
	And the amount is 100.00
	When the user sends the request for pair conversion with amount
	Then the response should be success

@pairConversion_invalidCurrencyCode
Scenario: User sends request to Pair Conversion API Endpoint with invalid currency code
	Given the first currency is PLNY
	And the second currency is GBP
	When the user sends the request for pair conversion
	Then the pair conversion response should be error

@pairConversion_requestWithoutAPIKey
Scenario: User sends request to Pair Conversion API Endpoint without API key
	Given the first currency is PLN
	And the second currency is GBP
	When the user sends the request for pair conversion without API Key
	Then the pair conversion response should be error