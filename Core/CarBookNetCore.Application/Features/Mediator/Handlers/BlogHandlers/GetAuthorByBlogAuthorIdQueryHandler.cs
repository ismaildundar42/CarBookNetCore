using CarBookNetCore.Application.Features.Interfaces.BlogInterfaces;
using CarBookNetCore.Application.Features.Mediator.Queries.BlogQueries;
using CarBookNetCore.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAuthorByBlogAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetAuthorByBlogAuthorIdResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAuthorByBlogAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorByBlogAuthorIdResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogByAuthorId(request.Id);
            return values.Select(x => new GetAuthorByBlogAuthorIdResult
            {
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
