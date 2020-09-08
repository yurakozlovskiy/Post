using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Repositories.AbstractProducts
{
    public interface IStatusRepository
    {
        IEnumerable<DeliveryStatus> GetAll();
        void Add(DeliveryStatus status);
        void Update(DeliveryStatus status);
        void Remove(DeliveryStatus status);
    }
}
