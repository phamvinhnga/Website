﻿using Website.Entity.Model;

namespace Website.Biz.Managers.Interfaces
{
    public interface IShopManager
    {
        Task CreateAsync(ShopInputModel input, int userId);
        Task UpdateAsync(ShopInputModel input, int userId);
        Task<ShopOutputModel> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<BasePageOutputModel<ShopOutputModel>> GetListAsync(ShopPageInputModel input);
    }
}
