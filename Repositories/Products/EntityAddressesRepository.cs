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
    public class EntityAddressesRepository : IAddressesRepository
    {
        public void Add(Addresses address)
        {
            using (var db = new PostEntities())
            {
                db.Addresses.Add(address);
                db.SaveChanges();
            }
        }

        public IEnumerable<Addresses> GetAll()
        {
            using (var db = new PostEntities())
            {
                return db.Addresses.ToList();
            }
        }

        public void Remove(Addresses address)
        {
            using (var db = new PostEntities())
            {
                var a = db.Addresses.Where(x => x.Id == address.Id).FirstOrDefault();

                db.Addresses.Remove(a);
                db.SaveChanges();

                Console.WriteLine("\nRemove person with Id={0}\n", a.Id);
            }
        }

        public void Update(Addresses address)
        {
            using (var db = new PostEntities())
            {
                db.Entry(address).State = EntityState.Modified;
            }
        }
    }
}
