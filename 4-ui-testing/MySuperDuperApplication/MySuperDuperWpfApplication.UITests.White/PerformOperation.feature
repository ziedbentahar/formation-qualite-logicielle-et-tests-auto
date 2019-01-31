Feature: PerformOperation
	In order to avoid silly mistakes
	As a user
	I be able to perform operation and see the result of this operation

Scenario Outline: Add two numbers
	And I have entered <operand1> and <operand2> into the operands
	And I have selected + operation
	When I press calc button
	Then I should see the <result> on a new window

	Examples:
		| operand1 | operand2 | result |
		|  70	   |  20      |  90    |
		|  xx      |  AA      |  Error |



