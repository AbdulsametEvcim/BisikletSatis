using BisikletSatis.Data;
using BisikletSatis.Data.Concrete;
using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;

namespace BisikletSatis.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {
        }
    }
}
