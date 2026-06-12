using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.CQRS.Queries
{
    public class GetBannerByIdQuery
    {
        public GetBannerByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
