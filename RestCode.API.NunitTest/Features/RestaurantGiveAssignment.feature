Feature: RestaurantGiveAssignment
	As a restaurant owner, I make assignment 
	to the consultant to access its information

@mytag
Scenario: As an owner make an assignment to consultant
	Given as an owner add on assignment endpoint
	When the owner add assignment 
	| State |
	| true	|
	Then the assignment will be add successfully


