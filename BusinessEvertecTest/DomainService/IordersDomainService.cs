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
        ordersDTO Create(ordersDTO order);
        ordersDTO update(ordersDTO order);
        List<ordersDTO> GetByUser(string user_email);
    }
}
