using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Features.Mediator.Commands.BlogCommands;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.AuthorId = request.AuthorId;
            value.CreatedDate = request.CreatedDate;
            value.CategoryId= request.CategoryId;
            value.BlogId= request.BlogId;
            value.CoverImageUrl= request.CoverImageUrl;
            value.CreatedDate= request.CreatedDate;
            await _repository.UpdateAsync(value);
        }
    }
}
