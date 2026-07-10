using CarBookNetCore.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByKmSmallerThan50kQuery : IRequest<GetCarCountByKmSmallerThan50kQueryResult>
    {
    }
}
