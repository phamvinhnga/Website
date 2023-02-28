﻿using Website.Biz.Managers.Interfaces;
using Website.Entity.Entities;
using Website.Entity.Model;
using Website.Entity.Repositories.Interfaces;
using Website.Shared.Exceptions;
using Website.Shared.Extensions;

namespace Website.Biz.Managers
{
    public class LocationManager : ILocationManager
    {
        private readonly ILocationRepository _locationRepository;

        public LocationManager(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task CreateAsync(LocationInputModel input, int userId)
        {
            var entity = input.JsonMapTo<Location>();
            entity.SetCreateDefault(userId);
            await _locationRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _locationRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new BadRequestException($"Cannot find locationId {id}");
            }
            await _locationRepository.DeleteAsync(entity);
        }

        public async Task<LocationOutputModel> GetByIdAsync(int id)
        {
            var query = await _locationRepository.GetByIdAsync(id);
            if (query == null)
            {
                throw new BadRequestException($"Cannot find locationId {id}");
            }
            return query.JsonMapTo<LocationOutputModel>();
        }

        public async Task<BasePageOutputModel<LocationOutputModel>> GetListAsync(LocationBasePageInputModel input)
        {
            var query = await _locationRepository.GetListAsync(input);
            return query.JsonMapTo<BasePageOutputModel<LocationOutputModel>>();
        }

        public async Task UpdateAsync(LocationInputModel input, int userId)
        {
            var entity = await _locationRepository.GetByIdAsync(input.Id);
            if (entity == null)
            {
                throw new BadRequestException($"Cannot find postId {input.Id}");
            }
            entity.Name = input.Name;
            entity.Status = input.Status;
            entity.SetModifyDefault(userId, DateTime.Now);
            await _locationRepository.UpdateAsync(entity);
        }
    }
}
