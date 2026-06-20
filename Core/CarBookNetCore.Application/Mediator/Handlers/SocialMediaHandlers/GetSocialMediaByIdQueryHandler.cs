using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Mediator.Queries.SocialMediaQueries;
using CarBookNetCore.Application.Mediator.Results.SocialMediaResults;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                Url = value.Url,
                Name = value.Name,
                Icon = value.Icon,
                SocialMediaId = value.SocialMediaId
            };
        }
    }
}
