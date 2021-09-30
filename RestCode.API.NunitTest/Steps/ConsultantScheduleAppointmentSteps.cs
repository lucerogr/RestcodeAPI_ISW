using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.NunitTest.Steps
{
    [Binding]
    public class ConsultantScheduleAppointmentSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Appointment appointment;

        [Given(@"a consultant want to schedule on appointment endpoint")]
        public void GivenAConsultantWantToScheduleOnAppointmentEndpoint()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/appointments", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"owner requested an appointment")]
        public void WhenOwnerRequestedAnAppointment(Table table)
        {
            appointment = table.CreateInstance<Appointment>();
            appointment = new Appointment()
            {
               CurrentDateTime = DateTime.Parse("2020/10/29"), 
               ScheduleDateTime = DateTime.Parse("2020/11/07"),
               Topic = "Topic1",
               MeetLink = "meet.google.com.mez-uwgg-obk"
            };
            restRequest.AddJsonBody(appointment);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"an appointment will be scheduled succesfully")]
        public void ThenAnAppointmentWillBeScheduledSuccesfully()
        {
            Assert.That("Topic1", Is.EqualTo(appointment.Topic));
        }
    }
}
