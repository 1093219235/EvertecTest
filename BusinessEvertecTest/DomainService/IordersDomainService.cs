using BusinessEvertecTest.DTO;
using EvertecTest;
using PersistenceEvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEvertecTest.DomainService
{
    public interface IordersDomainService
    {
        ordersDTO GetById(int id);
        List<ordersDTO> Get();
        orders Create(orders order);
        orders update(orders order);
        List<ordersDTO> GetByUser(string user_email);
    }
}
