using CarBookNetCore.Application.Features.CQRS.Queries.BrandQueries;
using CarBookNetCore.Application.Features.CQRS.Queries.CategoryQueries;
using CarBookNetCore.Application.Features.CQRS.Results.BrandResults;
using CarBookNetCore.Application.Features.CQRS.Results.CategoryResults;
using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _categoryRepository.GetByIdAsync(query.Id);
            if (values == null)
            {
                return null;
            }
            return new GetCategoryByIdQueryResult
            {
                CategoryId = values.CategoryId,
                Name = values.Name
            };
        }
    }
}
