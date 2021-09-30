Feature: Contratar servicio de consultoría 
	COMO dueño de un restaurante
	QUIERO contratar un servicio de consultoría 
	PARA evaluar y escoger la solución más efectiva al problema que estoy atravesando, 
	además de mejorar la gestión de mi negocio de una forma eficiente

@mytag
Scenario: El dueño del restaurante programa una cita
	Given que el dueño del restaurante quiere programar una cita con un consultor 
	When solicita una cita ingresando los datos que se piden 
	| CurrentDateTime | ScheduleDateTime | Topic  | MeetLink                     |
	| 29-10-2020      | 07-11-2020       | Topic1 | meet.google.com.mez-uwgg-obk |
	Then el sistema programa la cita de manera exitosa.