using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.NunitTest.Steps
{
    [Binding]
    public class AddConsultancySessionSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Consultancy consultancy;

        [Given(@"the consultant want to schedule on consultancy endpoint")]
        public void GivenTheConsultantWantToScheduleOnConsultancyEndpoint()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/consultancies", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"the consultant schedule a consultancy session")]
        public void WhenTheConsultantScheduleAConsultancySession(Table table)
        {
            consultancy = table.CreateInstance<Consultancy>();
            consultancy = new Consultancy()
            {
                Diagnosis = "Se va a quiebra",
                Recommendation = "Mejorar administracion de finanzas"
            };
            restRequest.AddJsonBody(consultancy);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"the consultancy will be schedule sucessfully")]
        public void ThenTheConsultancyWillBeScheduleSucessfully()
        {
            Assert.That("Se va a quiebra", Is.EqualTo(consultancy.Diagnosis));
        }
    }
}
