using CarBookNetCore.Application.Features.CQRS.Queries.ContactQueries;
using CarBookNetCore.Application.Features.CQRS.Results.ContactResults;
using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
               ContactId = values.ContactId,
               Subject = values.Subject,
               SendDate = values.SendDate,
               Name = values.Name,
               Message = values.Message,
               Email = values.Email
            };
        }
    }
}
