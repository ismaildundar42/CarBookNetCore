using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudByBlogIdQueryResult
    {
        public int TagCloudeId { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
