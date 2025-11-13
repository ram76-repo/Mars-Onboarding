@Login
Feature: Login

As a registered user, I want to login to the portal with valid credentials


Background: 
Given I get into the homepage

@logintest
Scenario: Check if user is able to login to the portal with valid data
	When I enter valid credentials
	Then I should be able to login successfully
	
@logintest
Scenario Outline: Check if user is unable to login to the portal with blank email and valid password
	When I enter blank '<email>' and valid '<password>'
	Then I should see an error message for blank '<email>'

	Examples:
	| email                 | password |
	|	                    | rithika  |
	
@logintest
	Scenario Outline: Check if user is unable to login to the portal with valid email and blank password
	When I enter valid '<email>' and blank '<password>'
	Then I should see an error message for '<password>' 
	Examples:
	| email                 | password |
	| ram_login@yahoo.co.uk |          |


	@logintest
	Scenario Outline: Check if user is unable to login to the portal with invalid data
	When I enter invalid '<email>' and '<password>'
	Then I should be see an error message for invalid credentials	

	Examples:
	| email          | password |
	| abcd@gmail.com | abcd1234 |