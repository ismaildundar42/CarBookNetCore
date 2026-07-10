using CarBookNetCore.Application.Features.Interfaces.StatisticsInterfaces;
using CarBookNetCore.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookNetCore.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogCount();
            return new GetBlogCountQueryResult
            {
                BlogCount = value
            };
        }
    }
}
