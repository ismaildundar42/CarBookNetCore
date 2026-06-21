using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsWithBrands();
        List<Car> GetLast5CarWithBrands();
    }
}
