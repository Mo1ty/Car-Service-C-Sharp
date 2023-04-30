using CarServiceApp.EFCore;
using CarServiceApp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service.impl
{
    internal class AddressServiceImpl : AddressService
    {
        AddressRepository addressRepository = new AddressRepository();

        public void addAddress(Address address)
        {
            addressRepository.addEntity<Address>(address);
        }

        public List<Address> findAll()
        {
            return addressRepository.findAll<Address>();
        }

        public Address findById(Guid Id)
        {
            return addressRepository.findById<Address>(Id);
        }
        
        public string exportCSV(string Path)
        {
            return addressRepository.exportToCSV(Path);
        }

        public void importCSV(string Path)
        {
            addressRepository.importCSV(Path);
        }
        
    }
}
