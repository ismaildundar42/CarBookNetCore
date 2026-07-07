using CarBookNetCore.Application.Features.Interfaces.StatisticsInterfaces;
using CarBookNetCore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarbookContext _context;

        public StatisticsRepository(CarbookContext context)
        {
            _context = context;
        }

        public string BlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string BrandNameByMaxCar()
        {
            var value = _context.Cars
            .GroupBy(x => new { x.BrandId, x.Brand.Name })
            .Select(y => new
            {
                BrandId = y.Key.BrandId,
                BrandName = y.Key.Name,
                Count = y.Count()
            })
            .OrderByDescending(z => z.Count)
            .FirstOrDefault();

            return value.BrandName;
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var averagePrice = _context.CarPricings
            .Where(x => x.Pricing.Name == "Günlük")
            .Average(x => x.Amount);

            return averagePrice;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var averagePrice = _context.CarPricings
            .Where(x => x.Pricing.Name == "Aylık")
            .Average(x => x.Amount);

            return averagePrice;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var averagePrice = _context.CarPricings
            .Where(x => x.Pricing.Name == "Haftalık")
            .Average(x => x.Amount);

            return averagePrice;
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = _context.CarPricings
                .Where(x => x.Pricing.Name == "Günlük")
                .OrderByDescending(x => x.Amount)
                .Select(x => x.Car.Brand.Name + " " + x.Car.Model)
                .FirstOrDefault();

            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = _context.CarPricings
            .Where(x => x.Pricing.Name == "Günlük")
            .OrderBy(x => x.Amount)
            .Select(x => x.Car.Brand.Name + " " + x.Car.Model)
            .FirstOrDefault();

            return value;
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThan50k()
        {
            var value = _context.Cars.Where(x => x.Km <= 50000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
