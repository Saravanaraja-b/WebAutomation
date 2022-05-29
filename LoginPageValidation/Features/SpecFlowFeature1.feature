Feature: Login validation

Background: Navigate to website
	Given User launches the browser
	And Navigate to "https://www.saucedemo.com/"

Scenario: Login with Invalid UserName
	Given the user is in login page
	And the user enters username standard_user and password secret_sauce
	And the user click Login button
	Then user add item to the cart
	And navigate to cart screen
	Then user checkout the product
	And fill the 'firstName' 'lastName' and 'postalCode' information
	When the user finish the transaction
	Then the order confirmation message should be displayed

	