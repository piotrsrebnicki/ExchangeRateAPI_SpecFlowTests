Feature: Get latest exchange rates
	Endpoint used to return the latest currency rates

@latest_happyPath_EGP
Scenario: User sends request to 'latest' API Endpoint 1
	Given the user wants to retrieve currency conversion for EGP
	When the user sends the request
	Then the response should be successful

@latest_happyPath_cny
Scenario: User sends request to 'latest' API Endpoint 2 - currency symbol should be case insensitive
	Given the user wants to retrieve currency conversion for cny
	When the user sends the request
	Then the response should be successful

@latest_happyPath_SeK
Scenario: User sends request to 'latest' API Endpoint 3  - currency symbol should be case insensitive
	Given the user wants to retrieve currency conversion for SeK
	When the user sends the request
	Then the response should be successful

@latest_invalidCurrencyCode
Scenario: User sends request to 'latest' API Endpoint with invalid currency code
	Given the user wants to download currency conversion for invalid currency code PLNY
	When the user sends the request
	Then the response should be error

@latest_requestWithoutAPIKey
Scenario: User sends request to 'latest' API Endpoint without API key
	Given the user wants to retrieve currency conversion for USD
	When the user sends the request without API Key
	Then the response should be error
