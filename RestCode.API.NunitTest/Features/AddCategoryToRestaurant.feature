Feature: AddCategoryToRestaurant
	As owner I want to add a new category of dishes for my restaurant

@mytag
Scenario: Add new categories to my restaurant
	Given the owner wants to add on category endpoint 
	When owner add a new category 
	| Name         |
	| Comida China |
	Then the category will be added succesfully