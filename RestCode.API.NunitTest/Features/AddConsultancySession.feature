Feature: AddConsultancySession
	As a consultant I want to schedule
	a consulting session according to the appointment previously made

@mytag
Scenario: As a consultant I want to schedule a consulting session
	Given the consultant want to schedule on consultancy endpoint
	When the consultant schedule a consultancy session
	| Diagnosis            | Recommendation                      |
	| Se va a quiebra      | Mejorar administracion de finanzas |
	Then the consultancy will be schedule sucessfully