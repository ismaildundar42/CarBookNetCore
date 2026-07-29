using CarBookNetCore.Application.Features.Mediator.Commands.CommentCommands;
using CarBookNetCore.Application.Features.RepositoryPattern;
using CarBookNetCore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentsRepository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> commentsRepository, IMediator mediator)
        {
            _commentsRepository = commentsRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var value = _commentsRepository.GetAll();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Comment başarılı bir şekilde eklendi!");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveComment(int id)
        {
            var value = _commentsRepository.GetById(id);
            _commentsRepository.Remove(value);
            return Ok("Comment başarılı bir şekilde silindi!");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentsRepository.Update(comment);
            return Ok("Comment başarılı bir şekilde güncellendi!");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentsRepository.GetById(id);
            return Ok(value);
        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var comments = _commentsRepository.GetCommentsByBlogId(id);
            var result = comments.Select(x => new
            {
                x.CommentId,
                x.Name,
                x.Description,
                x.CreatedDate,
                x.BlogId,
                BlogTitle = x.Blog != null ? x.Blog.Title : string.Empty
            });
            return Ok(result);
        }
        [HttpGet("GetCountCommentByBlog")]
        public IActionResult GetCountCommentByBlog(int id)
        {
            var value = _commentsRepository.GetCountCommentByBlog(id);
            return Ok(value);
        }
    }
}
