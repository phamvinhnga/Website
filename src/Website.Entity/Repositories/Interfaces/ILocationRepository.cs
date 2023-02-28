using Website.Entity.Entities;
using Website.Entity.Model;

namespace Website.Entity.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> CreateAsync(Location input);
        Task UpdateAsync(Location input);
        Task<Location> GetByIdAsync(int id);
        Task DeleteAsync(Location input);
        Task<BasePageOutputModel<Location>> GetListAsync(LocationBasePageInputModel input);
    }
}
