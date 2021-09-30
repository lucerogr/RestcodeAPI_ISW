Feature: RegistrarDueñoDeRestaurante
	COMO dueño de restaurante
	QUIERO registrarme en la aplicación web 
	PARA administrar y gestionar mi negocio eficientemente.

@mytag
Scenario:  El dueño de restaurante crea su cuenta
	Given que el dueño de restaurante se encuentra en la pantalla de crear una cuenta
	When ingresa sus datos personales
	| UserName | FirstName | LastName | Cellphone | Email             | Password      | Ruc         |
	| cintia12 | Cintia    | Rosales  | 912334411 | cintiar@gmail.com | rosalescintia | 12745621351 |
	Then el sistema guarda todos los datos registrados por el usuario