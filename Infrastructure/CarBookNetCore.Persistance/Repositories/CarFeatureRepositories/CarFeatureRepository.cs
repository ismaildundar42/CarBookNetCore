using CarBookNetCore.Application.Features.Interfaces.CarFeatureInterface;
using CarBookNetCore.Domain.Entities;
using CarBookNetCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarbookContext _context;

        public CarFeatureRepository(CarbookContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var value = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            if (value != null)
            {
                value.Available = false;
            }
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var value = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            if (value != null)
            {
                value.Available = true;
            }
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeaturesByCarId(int carId)
        {
            var values = _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarId == carId).ToList();
            return values;
        }
    }
}
