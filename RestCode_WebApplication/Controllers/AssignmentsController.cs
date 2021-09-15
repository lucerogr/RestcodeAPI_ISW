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
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;

        public AssignmentsController(IAssignmentService assignmentService, IMapper mapper)
        {
            _assignmentService = assignmentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all assignments",
            Description = "List all assignments",
            OperationId = "ListAllAssignments",
            Tags = new[] { "Assignments" })]
        [SwaggerResponse(200, "List of Assignments", typeof(IEnumerable<AssignmentResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AssignmentResource>), 200)]
        public async Task<IEnumerable<AssignmentResource>> GetAllAsync()
        {
            var assignments = await _assignmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentResource>>(assignments);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync(SaveAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var assignment = _mapper.Map<SaveAssignmentResource, Assignment>(resource);
            var result = await _assignmentService.SaveAsync(assignment);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Resource);
            return Ok(assignmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAssignmentResource resource)
        {
            var assignment = _mapper.Map<SaveAssignmentResource, Assignment>(resource);
            var result = await _assignmentService.UpdateAsync(id, assignment);

            if (!result.Success)
                return BadRequest(result.Message);
            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Resource);
            return Ok(assignmentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _assignmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Resource);
            return Ok(assignmentResource);
        }

    }
}
