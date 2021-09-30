Feature: registerRestaurant
	As owner i want to register my restaurant 

@tag1
Scenario: As owner i want to register restaurant
	Given as owner login to endpoint to add restaurant  
	When as owner complete the requerid data
	| Name			 | Address		  | CellPhoneNumber |
	| El mero loco	 | Av siempre lt4 | 956                       | 
	Then I register my data successfully


	