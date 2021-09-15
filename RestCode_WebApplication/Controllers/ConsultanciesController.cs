using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    public class ConsultanciesController : ControllerBase
    {
        private readonly IConsultancyService _consultancyService;
        private readonly IMapper _mapper;

        public ConsultanciesController(IConsultancyService consultancyService, IMapper mapper)
        {
            _consultancyService = consultancyService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all consultancies",
            Description = "List all consultancies",
            OperationId = "ListAllConsultancies",
            Tags = new[] { "Consultancies" })]
        [SwaggerResponse(200, "List of Consultancies", typeof(IEnumerable<ConsultancyResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ConsultancyResource>), 200)]
        public async Task<IEnumerable<ConsultancyResource>> GetAllAsync()
        {
            var consultancies = await _consultancyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Consultancy>, IEnumerable<ConsultancyResource>>(consultancies);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(SaveConsultancyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var consultancy = _mapper.Map<SaveConsultancyResource, Consultancy>(resource);
            var result = await _consultancyService.SaveAsync(consultancy);

            if (!result.Success)
                return BadRequest(result.Message);

            var consultancyResource = _mapper.Map<Consultancy, ConsultancyResource>(result.Resource);
            return Ok(consultancyResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveConsultancyResource resource)
        {
            var consultancy = _mapper.Map<SaveConsultancyResource, Consultancy>(resource);
            var result = await _consultancyService.UpdateAsync(id, consultancy);

            if (!result.Success)
                return BadRequest(result.Message);
            var consultancyResource = _mapper.Map<Consultancy, ConsultancyResource>(result.Resource);
            return Ok(consultancyResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _consultancyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var consultancyResource = _mapper.Map<Consultancy, ConsultancyResource>(result.Resource);
            return Ok(consultancyResource);
        }


    }
}
