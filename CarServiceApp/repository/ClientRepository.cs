using CarServiceApp.EFCore;
using CarServiceApp.repository.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.repository
{
    internal class ClientRepository : GenericRepository<Client>
    {
        public Client addClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
