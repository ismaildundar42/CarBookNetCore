using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Features.Mediator.Commands.CommentCommands;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public CreateCommentHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                BlogId = request.BlogId,
                CreatedDate = DateTime.Parse(DateTime.Now.ToString()),
                Description = request.Description,
                Name = request.Name,
                Email = request.Email
            });
        }
    }
}
