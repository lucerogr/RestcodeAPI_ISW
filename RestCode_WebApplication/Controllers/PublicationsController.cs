using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace RestCode_WebApplication.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;
        public PublicationsController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all publications",
            Description = "List of Publications",
            OperationId = "ListAllPublications",
            Tags = new[] { "Publications" })]
        [SwaggerResponse(200, "List of publications", typeof(IEnumerable<PublicationResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublicationResource>), 200)]
        public async Task<IEnumerable<Publication>> GetAllAsync()
        {
            var publications = await _publicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return publications;
        }

        [SwaggerOperation(
            Summary = "Creates a new publication",
            Description = "Requires date and description",
            OperationId = "CreatePublication",
            Tags = new[] { "Publications" }
        )]
        [HttpPost]
        public async Task<IActionResult> PostAsync(SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.SaveAsync(publication);

            if (!result.Success)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }

        [SwaggerOperation(
            Summary = "Updates an existing publication",
            Description = "Requires id, date and description",
            OperationId = "UpdatePublication",
            Tags = new[] { "Publications" })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePublicationResource resource)
        {
            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.UpdateAsync(id, publication);

            if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }

        [SwaggerOperation(
            Summary = "Deletes a publication",
            Description = "Requires id",
            OperationId = "DeletePublication",
            Tags = new[] { "Publications" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _publicationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }
    }
}
