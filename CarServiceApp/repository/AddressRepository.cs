using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarServiceApp.repository
{
    internal class AddressRepository
    {
        private CarServiceContext context = ContextConfiguration.Context;

        public void addAddress(Address address)
        {
            try
            {
                context.Addresses.Add(address);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool existsById(Guid Id)
        {
            List<Address> addresses = (from a in context.Addresses
                                       where a.Id == Id
                                       select a).ToList();
            return addresses.Count != 0 ? true : false;
        }

        public List<Address> findAll()
        {
            IEnumerable<Address> addresses = from a in context.Addresses
                                             select a;
            return addresses.ToList();
        }

        public Address? findById(Guid Id)
        {
            List<Address> addresses = (from a in context.Addresses
                                       where a.Id == Id
                                       select a).ToList();
            if (addresses.Count == 1)
                return addresses[0];
            else if (addresses.Count > 1)
                throw new Exception("Multiple addresses with this ID found in the database!");
            return null;
        }

    }
}
