using CarBookNetCore.Application.Features.Interfaces.RentACarInterfaces;
using CarBookNetCore.Application.Features.Mediator.Queries.RentACarQueries;
using CarBookNetCore.Application.Features.Mediator.Results.RentACarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            var results = values.Select(y => new GetRentACarQueryResult
            {
                CarId = y.CarId
            }).ToList();
            return results;
        }
    }
}
