using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Repositories.AbstractProducts
{
    public interface ITypesRepository
    {
        IEnumerable<Types> GetAll();
        void Add(Types types);
        void Update(Types types);
        void Remove(Types types);
    }
}
