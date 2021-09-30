using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Resources;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.NunitTest.Features
{
    [Binding]
    public class RegisterRestaurantSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
       // private static Restaurant restaurant;
        private static Restaurant restaurant;

        [Given(@"as owner login to endpoint to add restaurant")]
        public void GivenAsOwnerLoginToEndpointToAddRestaurant()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/restaurants", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }

        [When(@"as owner complete the requerid data")]
        public void WhenAsOwnerCompleteTheRequeridData(Table table)
        {
            restaurant = table.CreateInstance<Restaurant>();
            
            restaurant = new Restaurant()
            {
                Name = "Daniel",
                Address = "Luis 123",
                CellPhoneNumber = 123
            };

            restRequest.AddJsonBody(restaurant);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"I register my data successfully")]
        public void ThenIRegisterMyDataSuccessfully()
        {
            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<RestaurantResource>(response);
            //Console.WriteLine(output.RestaurantName);
            //Assert.That("Ok", Is.EqualTo(response.StatusCode.ToString()));
            Assert.That("Daniel", Is.EqualTo(restaurant.Name));
        }
    }
}
