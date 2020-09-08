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
    public class EntityTypeRepository : ITypesRepository
    {
        public void Add(Types types)
        {
            using (var db = new PostEntities())
            {
                db.Types.Add(types);
                db.SaveChanges();
            }
        }

        public IEnumerable<Types> GetAll()
        {
            using (var db = new PostEntities())
            {
                return db.Types.ToList();
                
            }
        }

        public void Remove(Types types)
        {
            using (var db = new PostEntities())
            {
                var t = db.People.Where(x => x.Id == types.Id).FirstOrDefault();
                db.People.Remove(t);
                db.SaveChanges();

            }
        }

        public void Update(Types types)
        {
            using (var db = new PostEntities())
            {
                db.Entry(types).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
