using CarBookNetCore.Application.CQRS.Commands.BannerCommands;
using CarBookNetCore.Application.Interfaces;
using CarBookNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookNetCore.Application.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BannerId);

            values.Description = command.Description;
            values.VideoDescription = command.VideoDescription;
            values.Title = command.Title;
            values.VideoUrl = command.VideoUrl;

            await _repository.UpdateAsync(values);
        }
    }
}
