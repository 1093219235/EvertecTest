using PersistenceEvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceEvertecTest.Repositories
{
    public interface IordersRepository
    {
        orders GetById(int id);
        List<orders> Get();
        orders Create(orders order);
        orders update(orders order);
        List<orders> GetByUser(string user_email);
    }
}
