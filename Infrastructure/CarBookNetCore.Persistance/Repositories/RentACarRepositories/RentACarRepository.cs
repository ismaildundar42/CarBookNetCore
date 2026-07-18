using CarBookNetCore.Application.Features.Interfaces.RentACarInterfaces;
using CarBookNetCore.Domain.Entities;
using CarBookNetCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarbookContext _context;

        public RentACarRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = await _context.RentACars.Where(filter).ToListAsync();
            return values;
        }
    }
}
