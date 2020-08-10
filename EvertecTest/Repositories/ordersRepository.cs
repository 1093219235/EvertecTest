using EvertecTest.DBcontext;
using PersistenceEvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceEvertecTest.Repositories
{
    public class ordersRepository:IordersRepository
    {
        ordersContext db = new ordersContext();
        public orders GetById(int id)
        {
         
            return db.orders.Where(x=>x.id==id).FirstOrDefault();
        }
        public List<orders> Get()
        {
            return db.orders.ToList(); 
        }
        public List<orders> GetByUser(string user_email)
        {
            return db.orders.Where(x => x.user_email == user_email).ToList();
        }
        public orders  Create(orders order)
        {
            db.orders.Add(order);
            db.SaveChanges();
            return order;
        }
        public orders update(orders order)
        {
          orders o=  db.orders.Find(order.id);
            o.price = order.price;
            o.status = order.status;
            o.transaction_id = order.transaction_id;
            o.updated_at = order.updated_at;
            o.url_payment = order.url_payment;
            o.user_email = order.user_email;
            o.paymentStatus = order.paymentStatus;
            db.SaveChanges();
            return order;
        }
    }
}
