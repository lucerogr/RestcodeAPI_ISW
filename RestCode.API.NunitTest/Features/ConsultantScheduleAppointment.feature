Feature: ConsultantScheduleAppointment
	As a consultant I want to schedule an appointment for an owner

@mytag
Scenario: As a consultant I want to schedule an appointment for an owner
	Given a consultant want to schedule on appointment endpoint 
	When owner requested an appointment
	| CurrentDateTime | ScheduleDateTime | Topic  | MeetLink                     |
	| 29-10-2020      | 07-11-2020       | Topic1 | meet.google.com.mez-uwgg-obk |

	Then an appointment will be scheduled succesfully
