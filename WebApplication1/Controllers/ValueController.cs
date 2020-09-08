using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DB;
using Repositories.AbstractProducts;

namespace WebApplication1.Controllers
{
    public class ValueController : ApiController
    {
        private PostEntities db = new PostEntities();

        public ValueController(): base()
        {
            
        }

        [HttpGet]
        [Route("api/value")]
        public IEnumerable<People> Get()
        {
            var a = db.People.Count();
            return db.People.ToList();
        }

        [HttpGet]
        [Route("api/value/{id}")]
        public People Get(int id)
        {
            return db.People.Find(id);
        }

        [HttpPost]
        [Route("api/value")]
        public void Post([FromBody]People people)
        {
            db.People.Add(people);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("api/value")]
        public void Put(int id, [FromBody]People people)
        {
            if (id == people.Id)
            {
                db.Entry(people).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("api/value/{id}")]
        public void Delete(int id)
        {
            var person = db.People.Find(id);
            if (person != null)
            {
                db.People.Remove(person);
                db.SaveChanges();
            }

        }
    }
}
