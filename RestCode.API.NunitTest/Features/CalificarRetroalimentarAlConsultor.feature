Feature: Calificar y retroalimenta al consultor
	COMO dueño de restaurante 
	QUIERO brindar una calificación y retroalimentación a un consultor 
	PARA expresar mi opinión respecto al servicio brindado, mencionar puntos en los que podría mejorar y, de esta manera, más dueños de restaurantes conozcan su forma de trabajar

@mytag
Scenario: El dueño de restaurante escribe su opinión de acuerdo con el servicio que recibió por parte del consultor
	Given que el dueño del restaurante se encuentra en la sección Dejar una opinión en el perfil del consultor de negocio
	When el dueño del restaurante termina de escribir su opinión
	| PublishedDate | Description                               | PublicationId | OwnerId | ConsultantId |
	| 2021/09/29    | Gran profesional. Comprometido al maximo. | 2             | 1       | 20           |
	Then el sistema guarda su opinión como un comentario exitosamente