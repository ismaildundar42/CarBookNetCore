using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Features.CQRS.Commands.CategoryCommdans
{
    public class CreateCategoryCommand
    {
        public string Name { get; set; }
    }
}
