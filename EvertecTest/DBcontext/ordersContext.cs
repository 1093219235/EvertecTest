using EvertecTest.Entities;
using PersistenceEvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertecTest.DBcontext
{
    class ordersContext: DbContext
    {
          public ordersContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<orders> orders { get; set; }
        public DbSet<login> login { get; set; }

       
    }
}
