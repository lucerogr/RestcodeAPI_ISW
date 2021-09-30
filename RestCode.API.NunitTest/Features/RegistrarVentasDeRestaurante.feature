Feature: Registrar Ventas de Dueño de Restaurante
	COMO dueño de un restaurante, 
	QUIERO registrar mis ventas 
	PARA conocer las ganancias del día.

@mytag
Scenario: Dueño de restaurante finaliza el registro de ventas
	Given que el dueño del restaurante se encuentra en la sección de Registros/Añadir
	When termina de colocar los datos de su venta
	| DateAndTime | ClientFullName | RestaurantId |
	| 2021/05/29  | Gloria Prado   | 1            |
	Then el sistema guarda la venta exitosamente