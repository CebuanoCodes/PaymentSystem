using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Repositories;

namespace PaymentSystem.Models.DataManager
{
    public class UserDataManager : IDataRepository
    {
        readonly UserContext _userContext;

        public UserDataManager(UserContext userContext)
        {
            _userContext = userContext;
        }

        public  IEnumerable<User> GetAll()
        {

            var users =  _userContext.Users
                .Include("Payments")
                .ToList();

            //// Paging
            //int pageSize = 5;
            //users = PaginatedList<User>.Create(users.AsQueryable(), pageNumber ?? 1, pageSize);

            return users;
        }
        public User Get(int id)
        {
            return _userContext.Users
                .Include(a => a.Payments.OrderByDescending(o => o.Date))
                .Single(b => b.Id == id);
        }

    }
}
