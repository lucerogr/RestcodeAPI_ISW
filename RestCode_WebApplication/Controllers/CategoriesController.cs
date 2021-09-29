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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all categories",
            Description = "List all categories",
            OperationId = "ListAllCategories",
            Tags = new[] { "Categories" })]
        [SwaggerResponse(200, "List of Categories", typeof(IEnumerable<CategoryResource>))]
        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get an existing category",
            Description = "Requires Id",
            OperationId = "GetExistingCategory",
            Tags = new[] { "Categories" })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);

        }

        [SwaggerOperation(
            Summary = "Create a new category",
            Description = "Requires name and restaurantId",
            OperationId = "CreateNewCategory",
            Tags = new[] { "Categories" })]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }

        [SwaggerOperation(
            Summary = "Update an existing category",
            Description = "Requires name and restaurantId",
            OperationId = "UpdateExistingCategory",
            Tags = new[] { "Categories" })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }

        [SwaggerOperation(
            Summary = "Delete an existing category",
            Description = "Requires id",
            OperationId = "DeleteExistingCategory",
            Tags = new[] { "Categories" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}
