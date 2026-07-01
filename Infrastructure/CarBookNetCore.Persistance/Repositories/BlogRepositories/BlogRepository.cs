using CarBookNetCore.Application.Features.Interfaces.BlogInterfaces;
using CarBookNetCore.Domain.Entities;
using CarBookNetCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarbookContext _context;

        public BlogRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _context.Blogs
                .Include(x => x.Author)
                .Include(x => x.Category)
                .ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
           var values = _context.Blogs.Include(x => x.Author).Where(y => y.BlogId == id).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogWithAuthor()
        {
            var values = _context.Blogs.Include(b => b.Author).OrderByDescending(x => x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
