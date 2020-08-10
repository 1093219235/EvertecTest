using EvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEvertecTest.DTO.Mapping
{
    public static class logMapping
    {
        public static loginDTO Map(this login entity)
        {
            var dto = new loginDTO()
            { customer_email = entity.customer_email,
                password = entity.password,
               admin=entity.admin
            };
            return dto;
        }
        public static login Map(this loginDTO dto)
        {

            var login = new login()
            {
                customer_email = dto.customer_email,
                password = dto.password,
                admin=dto.admin
            };
            return login;
        }
    }
   
}
