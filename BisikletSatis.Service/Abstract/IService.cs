using BisikletSatis.Data.Abstract;
using BisikletSatis.Entities;

namespace BisikletSatis.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()  
    {
    }
}
