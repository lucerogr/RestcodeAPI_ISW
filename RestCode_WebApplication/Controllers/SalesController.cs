using AutoMapper;
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

        [SwaggerOperation(
            Summary = "List all sales",
            Description = "List of sales",
            OperationId = "ListAllSales",
            Tags = new[] { "Sales" })]
        [SwaggerResponse(200, "List of Sales", typeof(IEnumerable<SaleResource>))]
        [HttpGet]
        public async Task<IEnumerable<SaleResource>> GetAllAsync()
        {
            var sale = await _saleService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Sale>, IEnumerable<SaleResource>>(sale);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get an existing sale",
            Description = "Requires id",
            OperationId = "GetExistingSale",
            Tags = new[] { "Sales" })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _saleService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var saleResource = _mapper.Map<Sale, SaleResource>(result.Resource);
            return Ok(saleResource);

        }

        [SwaggerOperation(
            Summary = "Create a new sale",
            Description = "Requires date, clientFullName and restaurantId",
            OperationId = "CreateNewSale",
            Tags = new[] { "Sales" })]
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

        [SwaggerOperation(
            Summary = "Update an existing sale",
            Description = "Requires date, clientFullName and restaurantId",
            OperationId = "UpdateExistingSale",
            Tags = new[] { "Sales" })]
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

        [SwaggerOperation(
            Summary = "Delete an existing sale",
            Description = "Requires Id",
            OperationId = "DeleteExistingSale",
            Tags = new[] { "Sales" })]
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
