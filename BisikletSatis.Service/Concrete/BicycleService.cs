using BisikletSatis.Data;
using BisikletSatis.Data.Concrete;
using BisikletSatis.Service.Abstract;

namespace BisikletSatis.Service.Concrete
{
    public class BicycleService : BicycleRepository, IBicycleService
    {
        public BicycleService(DatabaseContext context) : base(context)
        {
        }
    }
}
