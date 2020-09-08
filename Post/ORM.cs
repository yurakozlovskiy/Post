using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.AbstractProducts;
using DB;
using Repositories.ConcreteFactories;
using Repositories.Factory;

namespace Post
{
    public class ORM
    {
        private IPeopleRepository peopleRepository;
        private ICarsRepository carsRepository;
        private ITypesRepository typesRepository;
        private IStatusRepository statusRepository;
        private IAddressesRepository addressesRepository;

        public ORM(IFactory factory)
        {
            peopleRepository = factory.GetPeopleRepository();
            carsRepository = factory.GetCarsRepository();
            typesRepository = factory.GetTypesRepository();
            statusRepository = factory.GetStatusRepository();
            addressesRepository = factory.GetAddressesRepository();
        }

        #region Addresses
        public void Add(Addresses address)
        {
            addressesRepository.Add(address);
        }

        public void Update(Addresses address)
        {
            addressesRepository.Update(address);
        }

        public void Remove(Addresses address)
        {
            addressesRepository.Remove(address);
        }

        public IEnumerable<Addresses> GetAllAddresses()
        {

            return addressesRepository.GetAll();
        }
        #endregion
        #region People
        public void Add(People people)
        {
            peopleRepository.Add(people);
        }

        public void Update(People people)
        {
            peopleRepository.Update(people);
        }

        public void Remove(People people)
        {
            peopleRepository.Remove(people);
        }

        public IEnumerable<People> GetAllPeople() 
        {
            
            return peopleRepository.GetAll();
        }

        #endregion
        #region Cars
        public void Add(Cars car)
        {
            carsRepository.Add(car);
        }

        public void Update(Cars car)
        {
            carsRepository.Update(car);
        }

        public void Remove(Cars car)
        {
            carsRepository.Remove(car);
        }

        public IEnumerable<Cars> GetAllCars()
        {
            return carsRepository.GetAll();
        }

        #endregion
        #region Types
        public void Add(Types types)
        {
            typesRepository.Add(types);
        }

        public void Update(Types types)
        {
            typesRepository.Update(types);
        }

        public void Remove(Types types)
        {
            typesRepository.Remove(types);
        }

        public IEnumerable<Types> GetAllTypes()
        {

            return typesRepository.GetAll();
        }
        #endregion
        #region Status
        public void Add(DeliveryStatus status)
        {
            statusRepository.Add(status);
        }

        public void Update(DeliveryStatus status)
        {
            statusRepository.Update(status);
        }

        public void Remove(DeliveryStatus status)
        {
            statusRepository.Remove(status);
        }

        public IEnumerable<DeliveryStatus> GetAllStatus()
        {

            return statusRepository.GetAll();
        }
        #endregion
        
    }
}
