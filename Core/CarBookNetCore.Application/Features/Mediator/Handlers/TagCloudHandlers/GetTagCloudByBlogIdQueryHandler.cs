using CarBookNetCore.Application.Features.Interfaces.TagCloudInterfaces;
using CarBookNetCore.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBookNetCore.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudsByBlogId(request.Id);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                TagCloudeId = x.TagCloudId,
                Title = x.Title
            }).ToList();
        }
    }
}
