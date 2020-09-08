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
    public class EntityCarRepository : ICarsRepository
    {
        public void Add(Cars car)
        {
            using (var db = new PostEntities())
            {
                db.Cars.Add(car);
                db.SaveChanges();

                Console.WriteLine("\nAdd new person \n");
            }
        }

        public IEnumerable<Cars> GetAll()
        {
            using (var db = new PostEntities())
            {
                return db.Cars.ToList();
            }
        }

        public void Remove(Cars car)
        {
            using (var db = new PostEntities())
            {
                var c = db.Cars.Where(x => x.Id == car.Id).FirstOrDefault();

                db.Cars.Remove(c);
                db.SaveChanges();

                Console.WriteLine("\nRemove person with Id={0}\n", c.Id);
            }
        }

        public void Update(Cars car)
        {
            using (var db = new PostEntities())
            {
                if (car != null)
                {
                    db.Entry(car).State = EntityState.Modified;
                    db.SaveChanges();
                }
                Console.WriteLine("\nUpdate person with Id = {0}\n", car.Id);
            }
        }
    }
}
