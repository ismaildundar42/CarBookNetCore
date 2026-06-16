using CarBookNetCore.Application.CQRS.Queries.BrandQueries;
using CarBookNetCore.Application.CQRS.Results.BrandResults;
using CarBookNetCore.Application.Interfaces;
using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandByIdQueryHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var values = await _brandRepository.GetByIdAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandId = values.BrandId,
                Name = values.Name
            };
        }
    }
}
