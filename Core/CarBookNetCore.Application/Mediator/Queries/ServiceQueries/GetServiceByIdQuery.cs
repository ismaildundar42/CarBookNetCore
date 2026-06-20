using CarBookNetCore.Application.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBookNetCore.Application.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
    {
        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}