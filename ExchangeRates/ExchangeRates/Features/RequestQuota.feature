﻿Feature: API Request Quota
	Gets information about quantity of remaining requests to ExchangeRate API

@APIRequestQuota
Scenario: Get information about quantity of remaining requests
	When the user sends request to Quota API
	Then the result should contain required information