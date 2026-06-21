using CarBookNetCore.Application.Features.Interfaces;
using CarBookNetCore.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBookNetCore.Application.Features.Mediator.Results.TestimonialResults;
using CarBookNetCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                Title = value.Title,
                ImageUrl = value.ImageUrl,
                Comment = value.Comment,
                Name = value.Name
            };
        }
    }
}

