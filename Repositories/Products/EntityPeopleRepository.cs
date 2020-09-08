using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DB;
using Repositories.AbstractProducts;

namespace Repositories.Products
{
    public class EntityPeopleRepository : IPeopleRepository
    {
        public void Add(People people)
        {
            using (var db = new PostEntities())
            {
                db.People.Add(people);
                db.SaveChanges();

                //return true;
                Console.WriteLine("\nAdd new person \n");
            }
        }

        public People Get(int id)
        {
            using (var db = new PostEntities())
            {
                var person = db.People.FirstOrDefault(x => x.Id == id);
                return person;
            }
        }

        public IEnumerable<People> GetAll()
        {
            using (var db = new PostEntities())
            {
                return db.People.ToList();
            }
        }

        public void Remove(People people)
        {
            using (var db = new PostEntities())
            {
                var p = db.People.Where(x => x.Id == people.Id).FirstOrDefault();
                db.People.Remove(p);
                db.SaveChanges();

                Console.WriteLine("\nRemove person with Id={0}\n", p.Id);
            }
        }

        public void Update(People people)
        {
            using (var db = new PostEntities())
            {
                db.Entry(people).State = EntityState.Modified;
                db.SaveChanges();

                Console.WriteLine("\nUpdate person with Id = {0}\n", people.Id);
            }
        }
    }
}
