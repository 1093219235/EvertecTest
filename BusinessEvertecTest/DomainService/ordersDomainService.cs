using BusinessEvertecTest.DTO;
using BusinessEvertecTest.DTO.Mapping;
using PersistenceEvertecTest.Entities;
using PersistenceEvertecTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEvertecTest.DomainService
{
    public class ordersDomainService:IordersDomainService
    {
        public readonly IordersRepository _ordersRepository;
        public ordersDomainService(IordersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public ordersDTO GetById(int id)
        {
            var orders = _ordersRepository.GetById(id);
            if (orders == null)
            {
                return null;
            }
             var ordersDto = orders.Map();
       return ordersDto;
        }
        public List<ordersDTO> Get()
        {
            var orders = _ordersRepository.Get();
            if (orders == null)
            {
                return null;
            }
            var ordersDto = orders.Map();
            return ordersDto;
        }
        public ordersDTO Create(ordersDTO order)
        {
            order=_ordersRepository.Create(order.Map()).Map();
            return order;
        }
        public ordersDTO update(ordersDTO order)
        {
            _ordersRepository.update(order.Map());
            return order;
        }
        public List<ordersDTO> GetByUser(string user_email)
        {
        return _ordersRepository.GetByUser(user_email).Map(); 
        }
    }
}
