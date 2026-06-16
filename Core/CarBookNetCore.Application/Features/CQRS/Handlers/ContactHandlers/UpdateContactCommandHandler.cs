using CarBookNetCore.Application.Features.CQRS.Commands.ContactCommands;
using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ContactId);
            values.Email = command.Email;
            values.Subject = command.Subject;
            values.SendDate = command.SendDate;
            values.Name = command.Name;
            values.Message = command.Message;
            await _repository.UpdateAsync(values);
        }
    }
}
