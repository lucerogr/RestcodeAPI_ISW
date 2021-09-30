using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.SpecTest.Steps
{
    [Binding]
    public class ContratarServicioDeConsultoriaSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Appointment appointment;
        
        [Given(@"que el dueño del restaurante quiere programar una cita con un consultor")]
        public void GivenQueElDuenoDelRestauranteQuiereProgramarUnaCitaConUnConsultor()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/appointments", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }

        [When(@"solicita una cita ingresando los datos que se piden")]
        public void WhenSolicitaUnaCitaIngresandoLosDatosQueSePiden(Table table)
        {
            appointment = table.CreateInstance<Appointment>();
            appointment = new Appointment()
            {
                CurrentDateTime = DateTime.Parse("2020/10/29"),
                ScheduleDateTime = DateTime.Parse("2020/11/07"),
                Topic = "Mejorar ventas",
                MeetLink = "meet.google.com.mez-uwgg-obk"
            };
            restRequest.AddJsonBody(appointment);
            response = restClient.Execute(restRequest);
        }

        [Then(@"el sistema programa la cita de manera exitosa\.")]
        public void ThenElSistemaProgramaLaCitaDeManeraExitosa_()
        {
            Assert.That("Mejorar ventas", Is.EqualTo(appointment.Topic));
        }
    }
}

