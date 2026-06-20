using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.Mediator.Commands.FooterAddressCommand
{
    public class RemoveFooterAddressCommand : IRequest
    {
        public RemoveFooterAddressCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
