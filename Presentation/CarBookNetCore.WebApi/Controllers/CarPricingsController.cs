using CarBookNetCore.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBookNetCore.Application.Features.Mediator.Handlers.CarPricingHandlers;
using CarBookNetCore.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarPricingWithCarsList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }
        [HttpGet("GetCarPricingWithTimePeriod")]
        public async Task<IActionResult> GetCarPricingWithTimePeriod()
        {
            var values = await _mediator.Send(
                new GetCarPricingWithTimePeriodQuery()
            );

            return Ok(values);
        }

        [HttpGet("GetCarPricingByCarId/{id}")]
        public async Task<IActionResult> GetCarPricingByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarPricingByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araç fiyatlandırması başarıyla eklendi.");
        }
    }
}
