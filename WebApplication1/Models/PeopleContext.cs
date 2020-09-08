using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class PeopleContext: DbContext
    {
        public PeopleContext(): base("PostEntities")
        {

        }

        public DbSet<People> People { get; set; }
    }
}