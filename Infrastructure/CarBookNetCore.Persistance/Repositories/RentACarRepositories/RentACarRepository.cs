using CarBookNetCore.Application.Features.Interfaces.RentACarInterfaces;
using CarBookNetCore.Domain.Entities;
using CarBookNetCore.Persistence.Context;
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

        public List<RentACar> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = _context.RentACars.Where(filter);
            return values.ToList();
        }
    }
}
