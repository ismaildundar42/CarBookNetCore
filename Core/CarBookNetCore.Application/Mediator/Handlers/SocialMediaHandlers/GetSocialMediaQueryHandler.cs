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
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetSocialMediaQueryResult
            {
                SocialMediaId = x.SocialMediaId,
                Icon = x.Icon,
                Name = x.Name,
                Url = x.Url
            }).ToList();
        }
    }
}
