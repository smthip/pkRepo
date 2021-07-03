
Feature: Manage Methodologies


Scenario: Add a Methodologies
	Given I am on the Dynamic365 login page
	When I click on SignIn button
	And I enter the username as "prash@praskuls.onmicrosoft.com" and password as 'CgUser123'
	And Submit those details
	When I click on Manage methodologies
	And I click on plus sign 
	And Enter Name as "Prash Methodolgogy" & Prodcut Name as "Finance and Operations" on the new methodologies panel 
	And Click on Confirm button
	Then new methodologies as "Prash Methodolgogy" is created 


Scenario: Delete a Methodologies
	Given I am on the Dynamic365 login page
	When I click on SignIn button
	And I enter the username as "prash@praskuls.onmicrosoft.com" and password as 'CgUser123'
	And Submit those details
	When I click on Manage methodologies
	When I selected the "Prash Methodolgogy" 
	And I click on Delete Methodology icon
	And Click Yes on pop winodw
	Then "Prash Methodolgogy" is deleted
	

