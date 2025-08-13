using BisikletSatis.Entities;
using System.Linq.Expressions;

namespace BisikletSatis.Data.Abstract
{
    public interface IBicycleRepository : IRepository<Bisiklet>
    {
        Task<List<Bisiklet>> GetCustomBicycleList();
        Task<List<Bisiklet>> GetCustomBicycleList(Expression<Func<Bisiklet, bool>> expression);
        Task<Bisiklet> GetCustomBicycle(int id);
    }
}
