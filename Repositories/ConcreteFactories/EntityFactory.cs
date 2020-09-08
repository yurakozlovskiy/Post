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
    public class EntityFactory : IFactory
    {
        public IAddressesRepository GetAddressesRepository()
        {
            return new EntityAddressesRepository();
        }

        public ICarsRepository GetCarsRepository()
        {
            return new EntityCarRepository();
        }

        public IPeopleRepository GetPeopleRepository()
        {
            return new EntityPeopleRepository();
        }

        public IStatusRepository GetStatusRepository()
        {
            return new EntityStatusRepository();
        }

        public ITypesRepository GetTypesRepository()
        {
            return new EntityTypeRepository();
        }
    }
}
