Feature: PerformOperationAndSaveResult
	In order to avoid silly mistakes
	As a user
	I be able to calculate and save operation result

Scenario: Save operation result
	Given I have entered 50 into the first operand
	And I have entered 70 into the second operand
	And I have selected add operation
	And I have clicked calc button
	When I press save result on result window
	Then 120 should be added to the result list
