using CarServiceApp.EFCore.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.EFCore
{
    internal class Address : IEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; } // String is used in case you need to write the building (3k2, 2B etc.).
        public string PostalCode { get; set; }
    }
}
