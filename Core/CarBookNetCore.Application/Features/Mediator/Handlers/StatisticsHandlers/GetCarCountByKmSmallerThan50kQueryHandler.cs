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
    public class GetCarCountByKmSmallerThan50kQueryHandler : IRequestHandler<GetCarCountByKmSmallerThan50kQuery, GetCarCountByKmSmallerThan50kQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmSmallerThan50kQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmSmallerThan50kQueryResult> Handle(GetCarCountByKmSmallerThan50kQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByKmSmallerThan50k();
            return new GetCarCountByKmSmallerThan50kQueryResult
            {
                CarCountByKmSmallerThan50k = value
            };
        }
    }
}
