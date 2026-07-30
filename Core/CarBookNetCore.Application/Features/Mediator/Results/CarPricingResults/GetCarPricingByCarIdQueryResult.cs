using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingByCarIdQueryResult
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public string PricingName { get; set; }
        public decimal Amount { get; set; }
    }
}
