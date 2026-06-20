using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Mediator.Commands.ServiceCommands;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ServiceId);
            values.Description = request.Description;
            values.Title = request.Title;
            values.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
