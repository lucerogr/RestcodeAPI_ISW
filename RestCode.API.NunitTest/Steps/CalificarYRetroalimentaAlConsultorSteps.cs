using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestCode.API.SpecTest.Steps
{
    [Binding]
    public class CalificarYRetroalimentaAlConsultorSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Comment comment;

        [Given(@"que el dueño del restaurante se encuentra en la sección Dejar una opinión en el perfil del consultor de negocio")]
        public void GivenQueElDuenoDelRestauranteSeEncuentraEnLaSeccionDejarUnaOpinionEnElPerfilDelConsultorDeNegocio()
        {
            restClient = new RestClient("https://localhost:44316/");
            restRequest = new RestRequest("api/comments", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
        }
        
        [When(@"el dueño del restaurante termina de escribir su opinión")]
        public void WhenElDuenoDelRestauranteTerminaDeEscribirSuOpinion(Table table)
        {
            comment = table.CreateInstance<Comment>();
            comment = new Comment()
            {
                PublishedDate = DateTime.Parse("2021/09/29"),
                Description = "Gran profesional. Comprometido al maximo.",
                PublicationId = 2,
                OwnerId = 1,
                ConsultantId = 20
            };
            restRequest.AddJsonBody(comment);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"el sistema guarda su opinión como un comentario exitosamente")]
        public void ThenElSistemaGuardaSuOpinionComoUnComentarioExitosamente()
        {
            Assert.That("Gran profesional. Comprometido al maximo.", Is.EqualTo(comment.Description));
        }
    }
}
