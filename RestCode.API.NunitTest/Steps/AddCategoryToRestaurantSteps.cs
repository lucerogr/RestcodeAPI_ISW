using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.NunitTest.Steps
{
    [Binding]
    public class AddCategoryToRestaurantSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Category category;

        [Given(@"the owner wants to add on category endpoint")]
        public void GivenTheOwnerWantsToAddOnCategoryEndpoint()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/categories", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"owner add a new category")]
        public void WhenOwnerAddANewCategory(Table table)
        {
            category = table.CreateInstance<Category>();
            category = new Category()
            {
                Name = "Comida China"
            };
            restRequest.AddJsonBody(category);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"the category will be added succesfully")]
        public void ThenTheCategoryWillBeAddedSuccesfully()
        {
            Assert.That("Comida China", Is.EqualTo(category.Name));
        }
    }
}
