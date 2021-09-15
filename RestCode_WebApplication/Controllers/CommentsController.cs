using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all comments",
            Description = "List of Comments",
            OperationId = "ListAllComments",
            Tags = new[] { "Comments" })]
        [SwaggerResponse(200, "List of comments", typeof(IEnumerable<CommentResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CommentResource>), 200)]
        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            var comments = await _commentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return comments;
        }

        [SwaggerOperation(
            Summary = "Creates a new comment",
            Description = "Requires date, description and publicationId",
            OperationId = "CreateComment",
            Tags = new[] { "Comments" }
        )]
        [HttpPost]
        public async Task<IActionResult> PostAsync(SaveCommentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentService.SaveAsync(comment);

            if (!result.Success)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }

        [SwaggerOperation(
            Summary = "Updates an existing comment",
            Description = "Requires id, date and description",
            OperationId = "UpdateComment",
            Tags = new[] { "Comments" })]

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCommentResource resource)
        {
            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentService.UpdateAsync(id, comment);

            if (!result.Success)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }

        [SwaggerOperation(
            Summary = "Deletes a comment",
            Description = "Requires id",
            OperationId = "DeleteComment",
            Tags = new[] { "Comments" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _commentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
    }
}
