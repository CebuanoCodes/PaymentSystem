using PaymentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Repositories
{
    public interface IDataRepository
    {
         IEnumerable<User> GetAll();
         User Get(int id);
    }
}