using CarServiceApp.EFCore;
using CarServiceApp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service.impl
{
    internal class DealServiceImpl : DealService
    {
        DealRepository dealRepository = new DealRepository();
        CarRepository carRepository = new CarRepository();
        ClientRepository clientRepository = new ClientRepository();

        public void addDeal(Deal deal)
        {
            try
            {
                if (!carRepository.existsById<Car>(deal.CarId))
                    throw new ArgumentException("Attempt to add a car failed due to non-existent car identifier!");
                if (!clientRepository.existsById<Client>(deal.ClientId))
                    throw new ArgumentException("Attempt to add a deal failed due to non-existent client identifier!");
            }
            catch { throw; }
            dealRepository.addEntity<Deal>(deal);
        }

        public List<Deal> findAll()
        {
            return dealRepository.findAll<Deal>();
        }

        public Deal findById(Guid Id)
        {
            return dealRepository.findById<Deal>(Id);
        }

        public string exportCSV(string Path)
        {
            return dealRepository.exportToCSV(Path);
        }
    }
}
