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
    public class GetLast3BlogWithAuthorQueryHandler : IRequestHandler<GetLast3BlogWithAuthorQuery, List<GetLast3BlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogWithAuthorQueryResult>> Handle(GetLast3BlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogWithAuthor();
            return values.Select(x => new GetLast3BlogWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name
            }).ToList();


        }
    }
}
