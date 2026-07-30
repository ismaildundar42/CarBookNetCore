using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Dtos.CarPricingDtos
{
    public class ResultCarPricingByCarIdDto
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public string PricingName { get; set; }
        public decimal Amount { get; set; }
    }
}
