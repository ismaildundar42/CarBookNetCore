using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Features.Mediator.Queries.BlogQueries;
using CarBookNetCore.Application.Features.Mediator.Results.AuthorResults;
using CarBookNetCore.Application.Features.Mediator.Results.BlogResults;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                AuthorId = values.AuthorId,
                BlogId = values.BlogId,
                CategoryId = values.CategoryId,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                Title = values.Title,
                Description = values.Description
            };
        }
    }
}
