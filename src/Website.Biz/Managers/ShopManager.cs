using AutoMapper;
using Website.Biz.Managers.Interfaces;
using Website.Entity.Entities;
using Website.Entity.Model;
using Website.Entity.Repositories.Interfaces;
using Website.Shared.Exceptions;
using Website.Shared.Extensions;
using static Website.Shared.Common.CoreEnum;

namespace Website.Biz.Managers
{
    public class ShopManager : IShopManager
    {
        private readonly IShopRepository _shopRepository;
        private readonly IFileManager _fileManager;
        private readonly IMapper _mapper;

        public ShopManager(
            IShopRepository ShopRepository,
            IFileManager fileManager,
            IMapper mapper
        )
        {
            _shopRepository = ShopRepository;
            _fileManager = fileManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(ShopInputModel input, int userId)
        {
            var entity = _mapper.Map<Shop>(input);
            entity.SetCreateDefault(userId);
            if (input.Thumbnail != null && string.IsNullOrEmpty(input.Thumbnail.Id))
            {
                var file = _fileManager.Upload(input.Thumbnail, Folder.Shop);
                entity.Thumbnail = file.ConvertToJson();
            }
            else
            {
                entity.Thumbnail = null;
            }
            await _shopRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ShopInputModel input, int userId)
        {
            var entity = await _shopRepository.GetByIdAsync(input.Id);
            if (entity == null)
            {
                throw new BadRequestException($"Cannot find ShopId {input.Id}");
            }
            _mapper.Map(input, entity);
            entity.SetModifyDefault(userId);
            if (input.Thumbnail != null && string.IsNullOrEmpty(input.Thumbnail.Id))
            {
                var file = _fileManager.Upload(input.Thumbnail, Folder.Shop);
                entity.Thumbnail = file.ConvertToJson();
            }
            else
            {
                entity.Thumbnail = null;
            }
            await _shopRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _shopRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new BadRequestException($"Cannot find ShopId {id}");
            }
            await _shopRepository.DeleteAsync(entity);
        }

        public async Task<ShopOutputModel> GetByIdAsync(int id)
        {
            var query = await _shopRepository.GetByIdAsync(id);
            if (query == null)
            {
                throw new BadRequestException($"Cannot find ShopId {id}");
            }
            return _mapper.Map<ShopOutputModel>(query);
        }

        public async Task<BasePageOutputModel<ShopOutputModel>> GetListAsync(ShopPageInputModel input)
        {
            var query = await _shopRepository.GetListAsync(input);
            return new BasePageOutputModel<ShopOutputModel>(query.TotalItem, _mapper.Map<List<ShopOutputModel>>(query.Items));
        }
    }
}
