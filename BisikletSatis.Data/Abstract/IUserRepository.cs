using BisikletSatis.Entities;
using System.Linq.Expressions;

namespace BisikletSatis.Data.Abstract
{
    public interface IUserRepository : IRepository<Kullanici>
    {
        Task<List<Kullanici>> GetCustomList();
        Task<List<Kullanici>> GetCustomList(Expression<Func<Kullanici, bool>> expression);
    }
}
