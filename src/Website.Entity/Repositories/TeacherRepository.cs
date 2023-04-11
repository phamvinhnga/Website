using Website.Entity.Entities;
using Website.Entity.Model;
using Website.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Website.Entity.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public Task<Teacher> GetByIdAsync(int id)
        {
            return _context.Teacher.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<BasePageOutputModel<Teacher>> GetListAsync(BasePageInputModel input)
        {
            var query = _context.Teacher.AsNoTracking().Where(w => w.FullName.StartsWith(input.Search));

            var count = await query.CountAsync();

            var items = await query.Skip(input.SkipCount).Take(input.MaxCountResult).ToListAsync();

            return new BasePageOutputModel<Teacher>(count, items);
        }

        public async Task<Teacher> CreateAsync(Teacher input)
        {
            await _context.Teacher.AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(Teacher input)
        {
            return Task.Run(async () => {
                _context.Teacher.Remove(input);
                await _context.SaveChangesAsync();
            });
        }

        public Task UpdateAsync(Teacher input)
        {
            return Task.Run(async () => {
                _context.Attach(input);
                _context.Entry(input).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            });
        }
    }
}
