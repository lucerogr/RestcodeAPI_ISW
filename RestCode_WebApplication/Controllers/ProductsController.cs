using AutoMapper;
using RestCode_WebApplication.Extensions;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace RestCode_WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all products",
            Description = "List all products",
            OperationId = "ListAllProducts",
            Tags = new[] { "Products" })]
        [SwaggerResponse(200, "List of products", typeof(IEnumerable<ProductResource>))]
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get an existing product",
            Description = "Requires id",
            OperationId = "GetExistingProduct",
            Tags = new[] { "Products" })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);

        }

        [SwaggerOperation(
            Summary = "Create a new product",
            Description = "Requires name, price and categoryId",
            OperationId = "CreateNewProduct",
            Tags = new[] { "Products" })]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        [SwaggerOperation(
            Summary = "Update an existing product",
            Description = "Requires name, price and categoryId",
            OperationId = "UpdateExistingProduct",
            Tags = new[] { "Products" })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        [SwaggerOperation(
            Summary = "Delete an existing product",
            Description = "Requires id",
            OperationId = "DeleteExistingProduct",
            Tags = new[] { "Products" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

    }
}
