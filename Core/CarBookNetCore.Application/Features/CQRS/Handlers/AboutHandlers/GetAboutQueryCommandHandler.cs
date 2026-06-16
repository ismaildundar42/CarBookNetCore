using CarBookNetCore.Application.Features.CQRS.Results.AboutResults;
using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryCommandHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutQueryResults>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetAboutQueryResults
            {
                AboutId = x.AboutId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
