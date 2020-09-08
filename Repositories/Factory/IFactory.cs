using System;
using Repositories.AbstractProducts;

namespace Repositories.Factory
{
    public interface IFactory
    {
        IPeopleRepository GetPeopleRepository();
        ICarsRepository GetCarsRepository();
        ITypesRepository GetTypesRepository();
        IStatusRepository GetStatusRepository();
        IAddressesRepository GetAddressesRepository();
    }
}
