using CarBookNetCore.Application.Features.Interfaces.CarInterfaces;
using CarBookNetCore.Domain.Entities;
using CarBookNetCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarbookContext _context;

        public CarRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }
        public List<Car> GetLast5CarWithBrands()
        {
            var values = _context.Cars.Include(_x => _x.Brand).OrderByDescending(y => y.CarId).Take(5).ToList();
            return values;
        }
    }
}
