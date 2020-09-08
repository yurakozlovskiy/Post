using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Repositories.AbstractProducts;
using System.Data.Entity;

namespace Repositories.Products
{
    public class EntityStatusRepository : IStatusRepository
    {
        public void Add(DeliveryStatus status)
        {
            using (var db = new PostEntities())
            {
                db.DeliveryStatus.Add(status);
                db.SaveChanges();
            }
        }

        public IEnumerable<DeliveryStatus> GetAll()
        {
            using (var db = new PostEntities())
            {
                return db.DeliveryStatus.ToList();
            }
        }

        public void Remove(DeliveryStatus status)
        {
            using (var db = new PostEntities())
            {
                var s = db.People.Where(x => x.Id == status.Id).FirstOrDefault();
                db.People.Remove(s);
                db.SaveChanges();
            }
        }

        public void Update(DeliveryStatus status)
        {
            using (var db = new PostEntities())
            {
                db.Entry(status).State = EntityState.Modified;
            }
        }
    }
}
