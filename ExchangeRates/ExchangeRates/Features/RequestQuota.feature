Feature: API Request Quota
	Gets information about quantity of remaining requests to ExchangeRate API

@APIRequestQuota
Scenario: Get information about quantity of remaining requests
	When the user sends request to Quota API
	Then the result should contain required information

@APIRequestQuota_requestWithoutAPIKey
Scenario: Sending quota request without API Key
	When the user sends quota request without API Key
	Then the request quota response should be error