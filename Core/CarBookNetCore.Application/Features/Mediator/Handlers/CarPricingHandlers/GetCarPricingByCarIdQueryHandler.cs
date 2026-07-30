using CarBookNetCore.Application.Features.Interfaces.CarPricingInterface;
using CarBookNetCore.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookNetCore.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByCarIdQueryHandler : IRequestHandler<GetCarPricingByCarIdQuery, List<GetCarPricingByCarIdQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingByCarIdQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingByCarIdQueryResult>> Handle(GetCarPricingByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingByCarId(request.CarId);
            var results = values.Select(x => new GetCarPricingByCarIdQueryResult
            {
                CarPricingId = x.CarPricingId,
                CarId = x.CarId,
                PricingId = x.PricingId,
                PricingName = x.Pricing != null ? x.Pricing.Name : "",
                Amount = x.Amount
            }).ToList();

            return await Task.FromResult(results);
        }
    }
}
