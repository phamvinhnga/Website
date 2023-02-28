using Website.Entity.Entities;
using Website.Entity.Model;
using Website.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Website.Entity.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Location> CreateAsync(Location input)
        {
            await _context.Location.AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(Location input)
        {
            return Task.Run(async () => {
                _context.Location.Remove(input);
                await _context.SaveChangesAsync();
            });
        }

        public Task<Location> GetByIdAsync(int id)
        {
            return _context.Location.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<BasePageOutputModel<Location>> GetListAsync(LocationBasePageInputModel input)
        {
            var query = await _context.Location
                .Where(w => w.ParentId == input.ParentId && w.Type == input.Type)
                .OrderBy(o => o.Name)
                .ToListAsync();
            return new BasePageOutputModel<Location>(query.Count(), query);
        }

        public Task UpdateAsync(Location input)
        {
            return Task.Run(async () => {
                _context.Attach(input);
                _context.Entry(input).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            });
        }
    }
}
