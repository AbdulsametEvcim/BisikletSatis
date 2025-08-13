using BisikletSatis.Data.Abstract;
using BisikletSatis.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BisikletSatis.Data.Concrete
{
    public class BicycleRepository : Repository<Bisiklet>, IBicycleRepository
    {
        public BicycleRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Bisiklet> GetCustomBicycle(int id)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Marka).FirstOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<List<Bisiklet>> GetCustomBicycleList()
        {
            return await _dbSet.AsNoTracking().Include(x=>x.Marka).ToListAsync();
        }

        public async Task<List<Bisiklet>> GetCustomBicycleList(Expression<Func<Bisiklet, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Marka).ToListAsync();
        }
    }
}
