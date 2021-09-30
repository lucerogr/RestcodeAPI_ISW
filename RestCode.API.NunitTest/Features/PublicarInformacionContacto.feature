Feature: Publicar Información de Contacto
	COMO Consultor de Negocios, 
	QUIERO publicar mi Información de Contacto 
	PARA proporcionar distintos métodos de comunicación a mis clientes.

@mytag
Scenario: Consultor quiere publicar su información de contacto
	Given que el consultor de negocios se encuentra en la seccion Perfil
	When ingresa su Información de Contacto
	| userName | firstName | lastName | cellphone | email            | password | linkedinLink                                       |
	| luis12   | Luis      | Rios     | 988123412 | luis21@gmail.com | riosluis | pe.linkedin.com/luis-rios |
	Then su informacion se agrega a su perfil
