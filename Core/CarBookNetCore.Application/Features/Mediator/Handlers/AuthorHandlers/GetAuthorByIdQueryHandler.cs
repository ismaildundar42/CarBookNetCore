using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Features.Mediator.Queries.AuthorQueries;
using CarBookNetCore.Application.Features.Mediator.Results.AuthorResults;
using CarBookNetCore.Application.Features.Mediator.Results.FeatureResults;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                ImageUrl = values.ImageUrl,
                AuthorId = values.AuthorId,
                Description = values.Description,
                Name = values.Name
            };
        }
    }
}
