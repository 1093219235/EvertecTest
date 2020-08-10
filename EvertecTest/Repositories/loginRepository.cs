using EvertecTest.DBcontext;
using EvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertecTest.Repositories
{
    public class loginRepository:IloginRepository
    {
        ordersContext db = new ordersContext();
        public login GetLogin(login log)
        {

            return db.login.Where(x => x.customer_email == log.customer_email).Where(x => x.password == log.password).FirstOrDefault();
        }

        public login Create(login log)
        {
            db.login.Add(log);
            db.SaveChanges();
            return log;
        }
    }
}
