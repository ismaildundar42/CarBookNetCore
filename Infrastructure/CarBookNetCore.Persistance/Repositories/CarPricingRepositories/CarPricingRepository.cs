using CarBookNetCore.Application.Features.Interfaces.CarPricingInterface;
using CarBookNetCore.Domain.Entities;
using CarBookNetCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarbookContext _context;

        public CarPricingRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(t => t.PricingId==3).ToList();
            return values;  
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            int[] pricingIds = { 3, 4, 5 };

            return _context.CarPricings
                .Include(x => x.Car)
                    .ThenInclude(x => x.Brand)
                .Include(x => x.Pricing)
                .Where(x => pricingIds.Contains(x.PricingId))
                .AsNoTracking()
                .ToList();
        }
    }
}
