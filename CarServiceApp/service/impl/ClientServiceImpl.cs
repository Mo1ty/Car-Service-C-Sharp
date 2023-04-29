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
    internal class ClientServiceImpl : ClientService
    {
        private ClientRepository clientRepository = new ClientRepository();
        private AddressRepository addressRepository = new AddressRepository();

        public void addClient(Client client)
        {
            
            try
            {
                if (!addressRepository.existsById<Address>(client.AddressId))
                    throw new ArgumentException("Attempt to add a client failed due to non-existent address identifier!");
            }
            catch { throw; }
            
            clientRepository.addEntity(client);
        }

        public List<Client> findAll()
        {
            return clientRepository.findAll<Client>();
        }

        public Client findById(Guid Id)
        {
            return clientRepository.findById<Client>(Id);
        }

        public string exportCSV(string Path)
        {
            return clientRepository.exportToCSV(Path);
        }
    }
}
