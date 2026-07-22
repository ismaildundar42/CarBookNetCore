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
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod();

            var result = values
                .GroupBy(x => new
                {
                    x.CarId,
                    x.Car.CoverImage,
                    BrandName = x.Car.Brand.Name,
                    x.Car.Model
                })
                .Select(x => new GetCarPricingWithTimePeriodQueryResult
                {
                    CarModel = x.Key.BrandName + " " + x.Key.Model,
                    CoverImageUrl = x.Key.CoverImage,

                    DailyAmount = x
                        .Where(y => y.PricingId == 3)
                        .Select(y => y.Amount)
                        .FirstOrDefault(),

                    WeeklyAmount = x
                        .Where(y => y.PricingId == 4)
                        .Select(y => y.Amount)
                        .FirstOrDefault(),

                    MonthlyAmount = x
                        .Where(y => y.PricingId == 5)
                        .Select(y => y.Amount)
                        .FirstOrDefault()
                })
                .ToList();

            return await Task.FromResult(result);
        }
    }
}
