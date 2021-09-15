using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace RestCode_WebApplication.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/publications/{publicationId}/comments")]
    public class PublicationCommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public PublicationCommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all comments by publication",
            Description = "List of Comments for an specific Publication",
            OperationId = "ListCommentByPublication",
            Tags = new[] { "Publications" })]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CommentResource>),200)]
        public async Task<IEnumerable<CommentResource>> GetAllByPublicationIdAsync(int publicationId)
        {
            var comments = await _commentService.ListByPublicationIdAsync(publicationId);
            var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return resources;
        }
    }
}
