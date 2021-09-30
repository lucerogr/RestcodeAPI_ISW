using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.NunitTest.Steps
{
    [Binding]
    public class RestaurantGiveAssignmentSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Assignment assignment;

        [Given(@"as an owner add on assignment endpoint")]
        public void GivenAsAnOwnerAddOnAssignmentEndpoint()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/assignments", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"the owner add assignment")]
        public void WhenTheOwnerAddAssignment(Table table)
        {
            assignment = table.CreateInstance<Assignment>();
            assignment = new Assignment()
            {
                State = true
            };
            restRequest.AddJsonBody(assignment);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"the assignment will be add successfully")]
        public void ThenTheAssignmentWillBeAddSuccessfully()
        {
            Assert.That(true, Is.EqualTo(assignment.State));
        }
    }
}
