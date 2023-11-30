Feature: LogIn
	Simple calculator for adding two numbers

Background: 
	Given that Orange HRM is loaded
	

Scenario: LogIn_01_Verify that user can login with a valid username and Password
	When a user fill valid Username and Password data
	And a user clicks on login button
	Then the user should login 


Scenario: LogIn_02_Verify that user can login for 30 days with a valid username and Password
	When a user fill valid Username and Password data
	#And a user checks the remember me checkbox
	And a user clicks on login button


Scenario Outline: LogIn_03_Verify that user cannot login with an invalid credentials
	When a user fill Login page with <Username> and <Password> data
	And a user clicks on login button
	Then a error message <ExpectedErrorMessage> should be displayed
	Examples:
	| Username | Password | ExpectedErrorMessage     |
	| valid    | invalid  | Invalid Credentials      |
	| invalid  | valid    | Invalid Credentials      |
	|          | valid    | Username cannot be empty |
	| valid    |          | Password cannot be empty |
	| invalid  | invalid  | Invalid Credentials      |
	| invalid  | invalid  | Invalid Credentials      |
