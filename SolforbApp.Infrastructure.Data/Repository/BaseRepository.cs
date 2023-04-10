using Microsoft.EntityFrameworkCore;
using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbApp.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntitu
    {
        private SolforbDbContext _context;

        public BaseRepository(SolforbDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entety)
        {
            await _context.Set<T>().AddAsync(entety);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await _context.Set<T>().FirstAsync(p => p.Id == id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T?> Get(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
