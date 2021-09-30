using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnersController(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all restaurant owners",
            Description = "List all restaurant owners",
            OperationId = "ListAllRestaurantOwners",
            Tags = new[] { "Owners" })]
        [SwaggerResponse(200, "List of restaurant owners", typeof(IEnumerable<OwnerResource>))]
        [HttpGet]
        public async Task<IEnumerable<OwnerResource>> GetAllAsync()
        {
            var owners = await _ownerService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Owner>, IEnumerable<OwnerResource>>(owners);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get an existing restaurant owner",
            Description = "Requires id",
            OperationId = "GetExistingRestaurantOwner",
            Tags = new[] { "Owners" })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _ownerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var ownerResource = _mapper.Map<Owner, OwnerResource>(result.Resource);
            return Ok(ownerResource);

        }

        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Create a new restaurant owner",
            Description = "Requires userName, firstName, lastName, cellphone, email, password and ruc",
            OperationId = "CreateNewRestaurantOwner",
            Tags = new[] { "Owners" })]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOwnerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var owner = _mapper.Map<SaveOwnerResource, Owner>(resource);
            var result = await _ownerService.SaveAsync(owner);

            if (!result.Success)
                return BadRequest(result.Message);

            var ownerResource = _mapper.Map<Owner, OwnerResource>(result.Resource);
            return Ok(ownerResource);
        }

        [SwaggerOperation(
            Summary = "Update an existing restaurant owner",
            Description = "Requires userName, firstName, lastName, cellphone, email, password and ruc",
            OperationId = "UpdateExistingRestaurantOwner",
            Tags = new[] { "Owners" })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOwnerResource resource)
        {
            var owner = _mapper.Map<SaveOwnerResource, Owner>(resource);
            var result = await _ownerService.UpdateAsync(id, owner);

            if (!result.Success)
                return BadRequest(result.Message);
            var ownerResource = _mapper.Map<Owner, OwnerResource>(result.Resource);
            return Ok(ownerResource);
        }

        [SwaggerOperation(
            Summary = "Delete an existing restaurant owner",
            Description = "Requires id",
            OperationId = "DeleteExistingRestaurantOwner",
            Tags = new[] { "Owners" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ownerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var ownerResource = _mapper.Map<Owner, OwnerResource>(result.Resource);
            return Ok(ownerResource);
        }
    }
}
