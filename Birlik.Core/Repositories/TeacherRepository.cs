using Birlik.Core.Interfaces;
using Birlik.Data.Context;
using Birlik.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Birlik.Core.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly BirlikDbContext _context;

        public TeacherRepository(BirlikDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Teacher model)
        {
            await _context.Teachers.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id; 
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _context.Teachers.FindAsync(id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetAsync(string UIN)
        {
            return await _context.Teachers.Where(x=>x.UIN == UIN).FirstOrDefaultAsync();
        }

        public async Task<Teacher> GetAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Teacher model)
        {
            model.Id = id;
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}