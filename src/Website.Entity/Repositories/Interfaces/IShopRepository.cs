using Website.Entity.Entities;
using Website.Entity.Model;

namespace Website.Entity.Repositories.Interfaces
{
    public interface IShopRepository
    {
        Task<Shop> CreateAsync(Shop input);
        Task UpdateAsync(Shop input);
        Task<Shop> GetByIdAsync(int id);
        Task DeleteAsync(Shop input);
        Task<BasePageOutputModel<Shop>> GetListAsync(ShopPageInputModel input);
    }
}
