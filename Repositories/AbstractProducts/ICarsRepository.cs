using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Repositories.AbstractProducts
{
    public interface ICarsRepository
    {
        IEnumerable<Cars> GetAll();
        void Add(Cars car);
        void Update(Cars car);
        void Remove(Cars car);
    }
}
