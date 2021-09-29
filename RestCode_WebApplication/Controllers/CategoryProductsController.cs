﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Controllers
{
    [Route("/api/categories/{categoryId}/products")]
    public class Category_ProductsController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public Category_ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all products by category id",
            Description = "Requires category Id",
            OperationId = "ListAllProductsByCategoryId",
            Tags = new[] { "ProductsCategory" })]
        [SwaggerResponse(200, "List of Products by Category Id", typeof(IEnumerable<AppointmentResource>))]
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllByCategoryIdAsync(int categoryId)
        {
            var products = await _productService.ListByCategoryIdAsync(categoryId);
            var resources = _mapper
                .Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }
    }
}
