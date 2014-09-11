Feature: Proxy Endpoints
	In order to check errors are handled correctly
	As an API client
	I want to proxy my API to an endpoint with a known error response

Scenario: Bad Request
	Given I want to test my client handles a 400: "Bad Request" response
	And I have proxied "api.myproduct.net" to point to badapi.net
	When I make a GET request to "http://api.myproduct.net/some/path?with=query"
	Then the API returns with response code '400'
	And the response does not contain a body

Scenario: Conflict
	Given I want to test my client handles a 409: "Conflict" response
	And I have proxied "api.myproduct.net" to point to badapi.net
	When I make a GET request to "http://api.myproduct.net/some/path?with=query"
	Then the API returns with response code '409'
	And the response does not contain a body

Scenario: Forbidden
	Given I want to test my client handles a 403: "Forbidden" response
	And I have proxied "api.myproduct.net" to point to badapi.net
	When I make a GET request to "http://api.myproduct.net/some/path?with=query"
	Then the API returns with response code '403'
	And the response does not contain a body

Scenario: Internal Server Error
	Given I want to test my client handles a 500: "Internal Server Error" response
	And I have proxied "api.myproduct.net" to point to badapi.net
	When I make a GET request to "http://api.myproduct.net/some/path?with=query"
	Then the API returns with response code '500'
	And the response does not contain a body

Scenario: Not Found
	Given I want to test my client handles a 404: "Not Found" response
	And I have proxied "api.myproduct.net" to point to badapi.net
	When I make a GET request to "http://api.myproduct.net/some/path?with=query"
	Then the API returns with response code '404'
	And the response does not contain a body

Scenario: Service Unavailable
	Given I want to test my client handles a 503: "Service Unavailable" response
	And I have proxied "api.myproduct.net" to point to badapi.net
	When I make a GET request to "http://api.myproduct.net/some/path?with=query"
	Then the API returns with response code '503'
	And the response does not contain a body

Scenario: Unauthorized
	Given I want to test my client handles a 401: "Unauthorized" response
	And I have proxied "api.myproduct.net" to point to badapi.net
	When I make a GET request to "http://api.myproduct.net/some/path?with=query"
	Then the API returns with response code '401'
	And the response does not contain a body
