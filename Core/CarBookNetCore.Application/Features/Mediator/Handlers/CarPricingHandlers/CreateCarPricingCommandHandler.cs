using CarBookNetCore.Application.Features.Interfaces.CarPricingInterface;
using CarBookNetCore.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommand>
    {
        private readonly ICarPricingRepository _repository;

        public CreateCarPricingCommandHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            _repository.SaveCarPricing(request.CarId, request.PricingId, request.Amount);
            await Task.CompletedTask;
        }
    }
}
