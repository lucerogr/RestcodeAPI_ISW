using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class SalesController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        public SalesController(ISaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SaleResource>> GetAllAsync()
        {
            var sale = await _saleService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Sale>, IEnumerable<SaleResource>>(sale);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _saleService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var saleResource = _mapper.Map<Sale, SaleResource>(result.Resource);
            return Ok(saleResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSaleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var sale = _mapper.Map<SaveSaleResource, Sale>(resource);
            var result = await _saleService.SaveAsync(sale);

            if (!result.Success)
                return BadRequest(result.Message);

            var saleResource = _mapper.Map<Sale, SaleResource>(result.Resource);
            return Ok(saleResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSaleResource resource)
        {
            var sale = _mapper.Map<SaveSaleResource, Sale>(resource);
            var result = await _saleService.UpdateAsync(id, sale);

            if (!result.Success)
                return BadRequest(result.Message);
            var saleResource = _mapper.Map<Sale, SaleResource>(result.Resource);
            return Ok(saleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _saleService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var saleResource = _mapper.Map<Sale, SaleResource>(result.Resource);
            return Ok(saleResource);
        }
    }
}
