using CarBookNetCore.Application.Features.CQRS.Results.CarResults;
using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Features.Interfaces.CarInterfaces;
using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = _repository.GetCarsWithBrands();

            var result = values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CarId = x.CarId,
                CoverImage = x.CoverImage,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();

            return Task.FromResult(result);
        }
    }
}
