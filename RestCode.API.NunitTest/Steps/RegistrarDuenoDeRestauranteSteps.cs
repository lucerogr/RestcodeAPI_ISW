using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.SpecTest.Steps
{
    [Binding]
    public class RegistrarDuenoDeRestauranteSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Owner owner;

        [Given(@"que el dueño de restaurante se encuentra en la pantalla de crear una cuenta")]
        public void GivenQueElDuenoDeRestauranteSeEncuentraEnLaPantallaDeCrearUnaCuenta()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/owners", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"ingresa sus datos personales")]
        public void WhenIngresaSusDatosPersonales(Table table)
        {
            owner = table.CreateInstance<Owner>();
            owner = new Owner()
            {
                UserName = "cintia12",
                FirstName = "Cintia",
                LastName = "Rosales",
                Cellphone = "912334411",
                Email = "cintiar@gmail.com",
                Password = "rosalescintia",
                Ruc = 12745621351
            };
            restRequest.AddJsonBody(owner);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"el sistema guarda todos los datos registrados por el usuario")]
        public void ThenElSistemaGuardaTodosLosDatosRegistradosPorElUsuario()
        {
            Assert.That(12745621351, Is.EqualTo(owner.Ruc));
        }
    }
}
