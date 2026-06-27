using CarBookNetCore.Application.Features.Interfaces.TagCloudInterfaces;
using CarBookNetCore.Domain.Entities;
using CarBookNetCore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarbookContext _context;

        public TagCloudRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            var values = _context.TagCloudes.Where(x => x.BlogId == id).ToList();
            return values;
        }
    }
}
