Feature: User Login


Scenario: Login with valid credentials
	Given I am on the Dynamic365 login page
	When I click on SignIn button
	And I enter the username as "prash@praskuls.onmicrosoft.com" and password as 'CgUser123' 
	And Submit those details
	Then I have logged in


Scenario: Login with invalid credentials
	Given I am on the Dynamic365 login page
	When I click on SignIn button
	And I enter the valid username "prash@praskuls.onmicrosoft.com" and wrong password 'abc123' 
	And Submit those details
	Then error message is displayed 

