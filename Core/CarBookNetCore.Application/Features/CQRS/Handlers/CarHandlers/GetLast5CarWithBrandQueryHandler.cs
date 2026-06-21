using CarBookNetCore.Application.Features.CQRS.Results.CarResults;
using CarBookNetCore.Application.Features.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetLast5CarWithBrandQueryResult>> Handle()
        {
            var values = _repository.GetLast5CarWithBrands();

            var result = values.Select(x => new GetLast5CarWithBrandQueryResult
            {
                BrandName = x.Brand != null ? x.Brand.Name : "",
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
