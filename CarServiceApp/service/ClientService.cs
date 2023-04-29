using CarServiceApp.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service
{
    internal interface ClientService
    {
        Client findById(Guid Id);
        List<Client> findAll();
        void addClient(Client client);

        string exportCSV();
    }
}
