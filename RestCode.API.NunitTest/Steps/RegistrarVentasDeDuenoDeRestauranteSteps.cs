using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.SpecTest.Steps
{
    [Binding]
    public class RegistrarVentasDeDuenoDeRestauranteSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Sale sale;

        [Given(@"que el dueño del restaurante se encuentra en la sección de Registros/Añadir")]
        public void GivenQueElDuenoDelRestauranteSeEncuentraEnLaSeccionDeRegistrosAnadir()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/sales", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"termina de colocar los datos de su venta")]
        public void WhenTerminaDeColocarLosDatosDeSuVenta(Table table)
        {
            sale = table.CreateInstance<Sale>();
            sale = new Sale()
            {
                DateAndTime = DateTime.Parse("2021/05/29"),
                ClientFullName = "Gloria Prado",
                RestaurantId = 1
            };
            restRequest.AddJsonBody(sale);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"el sistema guarda la venta exitosamente")]
        public void ThenElSistemaGuardaLaVentaExitosamente()
        {
            Assert.That("Gloria Prado", Is.EqualTo(sale.ClientFullName));
        }
    }
}
