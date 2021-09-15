using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Resources;

namespace RestCode_WebApplication.Controllers
{
    [Route("/api/[controller]")]
    //[ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        private readonly IMapper _mapper;
        public ConsultantsController(IConsultantService consultantService, IMapper mapper)
        {
            _consultantService = consultantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Consultant>> GetAllAsync()
        {
            var consultants = await _consultantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Consultant>, IEnumerable<ConsultantResource>>(consultants);
            return consultants;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _consultantService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var consultantResource = _mapper.Map<Consultant, ConsultantResource>(result.Resource);
            return Ok(consultantResource);

        }

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
