using PersistenceEvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEvertecTest.DTO.Mapping
{
    public static class ordersMapping
    {
        public static ordersDTO Map(this orders entity)
        {
           
            var dto = new ordersDTO()
          
            {
                id = entity.id,
                customer_name=entity.customer_name,
                customer_email=entity.customer_email,
                customer_mobile=entity.customer_mobile,
                created_at=entity.created_at,
                updated_at=entity.updated_at,
                status=entity.status,
                price=entity.price,
                transaction_id=entity.transaction_id,
                user_email=entity.user_email,
                url_payment=entity.url_payment,
                paymentStatus=entity.paymentStatus,

            };
            return dto;
        }

        public static orders Map(this ordersDTO dto)
        {

            var order = new orders()
            {
                id = dto.id,
                customer_name = dto.customer_name,
                customer_email = dto.customer_email,
                customer_mobile = dto.customer_mobile,
                created_at = dto.created_at,
                updated_at = dto.updated_at,
                status = dto.status,
                price=dto.price,
                transaction_id=dto.transaction_id,
                user_email = dto.user_email,
               url_payment=dto.url_payment ,
               paymentStatus=dto.paymentStatus,

            };
            return order;
        }

        public static List<ordersDTO> Map(this List<orders> entities)
        {
            var ordersDtos = new List<ordersDTO>();
            foreach (var ent in entities)
            {
                ordersDtos.Add(ent.Map());
            }
            return ordersDtos;
        }

    }
}
