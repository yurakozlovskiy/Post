using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.AbstractProducts;
using Repositories.Factory;
using Repositories.Products;

namespace Repositories.ConcreteFactories
{
    public class AdoFactory : IFactory
    {
        public IAddressesRepository GetAddressesRepository()
        {
            return new AdoAddressesRepository();
        }

        public ICarsRepository GetCarsRepository()
        {
            return new AdoCarRepository();
        }

        public IPeopleRepository GetPeopleRepository()
        {
            return new AdoPeopleRepository();
        }

        public IStatusRepository GetStatusRepository()
        {
            return new AdoStatusRepository();
        }

        public ITypesRepository GetTypesRepository()
        {
            return new AdoTypesRepository();
        }
    }
}
