using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Repositories.AbstractProducts
{
    public interface IAddressesRepository
    {
        IEnumerable<Addresses> GetAll();
        void Add(Addresses address);
        void Update(Addresses address);
        void Remove(Addresses address);
    }
}
