Feature: MySuperDuperCalculator
	In order to avoid silly mistakes
	As a user
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the first operand text box
	Given I have entered 70 into the second operand text box
	Given I have entered + sign into the operation combo
	When I click calc button
	Then the result should be 120 on the screen
