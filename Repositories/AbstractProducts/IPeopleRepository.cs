using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Repositories.AbstractProducts
{
    public interface IPeopleRepository
    {
        IEnumerable<People> GetAll();
        void Add(People people);
        void Update(People people);
        void Remove(People people);
        People Get(int id);
    }
}
