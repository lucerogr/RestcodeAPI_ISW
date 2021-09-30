using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.SpecTest.Steps
{
    [Binding]
    public class PublicarInformacionDeContactoSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Consultant consultant;

        [Given(@"que el consultor de negocios se encuentra en la seccion Perfil")]
        public void GivenQueElConsultorDeNegociosSeEncuentraEnLaSeccionPerfil()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/consultants", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"ingresa su Información de Contacto")]
        public void WhenIngresaSuInformacionDeContacto(Table table)
        {
            consultant = table.CreateInstance<Consultant>();
            consultant = new Consultant()
            {
                UserName = "luis12",
                FirstName = "Luis",
                LastName = "Rios",
                Cellphone = "988123412",
                Email = "luis21@gmail.com",
                Password = "riosluis",
                LinkedinLink = "pe.linkedin.com/luis-rios"

            };
            restRequest.AddJsonBody(consultant);
            response = restClient.Execute(restRequest);
        }

        [Then(@"su informacion se agrega a su perfil")]
        public void ThenSuInformacionSeAgregaASuPerfil()
        {
            Assert.That("luis12", Is.EqualTo(consultant.UserName));
        }

    }
}
