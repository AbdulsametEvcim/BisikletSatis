using BisikletSatis.Data;
using BisikletSatis.Data.Concrete;
using BisikletSatis.Service.Abstract;

namespace BisikletSatis.Service.Concrete
{
    public class UserService : UserRepository, IUserService
    {
        public UserService(DatabaseContext context) : base(context)
        {
        }
    }
}
