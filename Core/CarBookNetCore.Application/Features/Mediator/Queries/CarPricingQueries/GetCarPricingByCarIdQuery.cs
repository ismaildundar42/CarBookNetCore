using CarBookNetCore.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByCarIdQuery : IRequest<List<GetCarPricingByCarIdQueryResult>>
    {
        public int CarId { get; set; }

        public GetCarPricingByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
