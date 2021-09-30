using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace RestCode_WebApplication.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        private readonly IMapper _mapper;
        public ConsultantsController(IConsultantService consultantService, IMapper mapper)
        {
            _consultantService = consultantService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all consultants",
            Description = "List all consultants",
            OperationId = "ListAllConsultants",
            Tags = new[] { "Consultants" })]
        [SwaggerResponse(200, "List of Consultants", typeof(IEnumerable<ConsultantResource>))]
        [HttpGet]
        public async Task<IEnumerable<ConsultantResource>> GetAllAsync()
        {
            var consultants = await _consultantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Consultant>, IEnumerable<ConsultantResource>>(consultants);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get an existing consultant",
            Description = "Requires id",
            OperationId = "GetExistingConsultant",
            Tags = new[] { "Consultants" })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _consultantService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var consultantResource = _mapper.Map<Consultant, ConsultantResource>(result.Resource);
            return Ok(consultantResource);

        }

        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Create a new consultant",
            Description = "Requires userName, firstName, lastName, cellphone, email, password and linkedinLink",
            OperationId = "CreateNewConsultant",
            Tags = new[] { "Consultants" })]
        [HttpPost]
        public async Task<IActionResult> PostAsync( [FromBody] SaveConsultantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var consultant = _mapper.Map<SaveConsultantResource, Consultant>(resource);
            var result = await _consultantService.SaveAsync(consultant);

            if (!result.Success)
                return BadRequest(result.Message);

            var consultantResource = _mapper.Map<Consultant, ConsultantResource>(result.Resource);
            return Ok(consultantResource);
            
        }

        [SwaggerOperation(
            Summary = "Update an existing consultant",
            Description = "Requires userName, firstName, lastName, cellphone, email, password and linkedinLink",
            OperationId = "UpdateExistingConsultant",
            Tags = new[] { "Consultants" })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveConsultantResource resource)
        {
            var consultant = _mapper.Map<SaveConsultantResource, Consultant>(resource);
            var result = await _consultantService.UpdateAsync(id, consultant);

            if (!result.Success)
                return BadRequest(result.Message);
            var consultantResource = _mapper.Map<Consultant, ConsultantResource>(result.Resource);
            return Ok(consultantResource);
        }

        [SwaggerOperation(
            Summary = "Delete an existing consultant",
            Description = "Requires id",
            OperationId = "DeleteExistingConsultant",
            Tags = new[] { "Consultants" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _consultantService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var consultantResource = _mapper.Map<Consultant, ConsultantResource>(result.Resource);
            return Ok(consultantResource);

        }

    }
}
