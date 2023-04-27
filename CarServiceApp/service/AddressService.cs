using CarServiceApp.EFCore;
using CarServiceApp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service
{
    internal interface AddressService
    {
        Address findById(Guid Id);
        List<Address> findAll();
        void addAddress(Address address);

    }
}
