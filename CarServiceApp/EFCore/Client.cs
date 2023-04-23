using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.EFCore
{
    internal class Client
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriverLicense { get; set; }

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
