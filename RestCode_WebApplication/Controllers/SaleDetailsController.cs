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
    public class Sale_DetailsController : Controller
    {
        private readonly ISaleDetailService _saleDetailService;
        private readonly IMapper _mapper;

        public Sale_DetailsController(ISaleDetailService saleDetailService, IMapper mapper)
        {
            _mapper = mapper;
            _saleDetailService = saleDetailService;
        }

        [SwaggerOperation(
            Summary = "List all sale details",
            Description = "List of sale details",
            OperationId = "ListAllSaleDetails",
            Tags = new[] { "SaleDetails" })]
        [SwaggerResponse(200, "List of Sale Details", typeof(IEnumerable<SaleDetailResource>))]
        [HttpGet]
        public async Task<IEnumerable<SaleDetailResource>> GetAllAsync()
        {
            var saleDetail = await _saleDetailService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<SaleDetail>, IEnumerable<SaleDetailResource>>(saleDetail);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get an existing sale detail",
            Description = "Requires id",
            OperationId = "GetExistingSaleDetail",
            Tags = new[] { "SaleDetails" })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _saleDetailService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);

        }

        [SwaggerOperation(
            Summary = "Create a new sale detail",
            Description = "Requires quantity, productId and saleId",
            OperationId = "CreateNewSaleDetail",
            Tags = new[] { "SaleDetails" })]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSaleDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var saleDetail = _mapper.Map<SaveSaleDetailResource, SaleDetail>(resource);
            var result = await _saleDetailService.SaveAsync(saleDetail);

            if (!result.Success)
                return BadRequest(result.Message);

            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);
        }

        [SwaggerOperation(
            Summary = "Update an existing sale detail",
            Description = "Requires quantity, productId and saleId",
            OperationId = "UpdateExistingSaleDetail",
            Tags = new[] { "SaleDetails" })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSaleDetailResource resource)
        {
            var saleDetail = _mapper.Map<SaveSaleDetailResource, SaleDetail>(resource);
            var result = await _saleDetailService.UpdateAsync(id, saleDetail);

            if (!result.Success)
                return BadRequest(result.Message);
            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);
        }

        [SwaggerOperation(
            Summary = "Delete an existing sale detail",
            Description = "Requires Id",
            OperationId = "DeleteExistingSaleDetail",
            Tags = new[] { "SaleDetails" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _saleDetailService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var saleDetailResource = _mapper.Map<SaleDetail, SaleDetailResource>(result.Resource);
            return Ok(saleDetailResource);
        }
    }
}
