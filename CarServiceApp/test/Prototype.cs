using CarServiceApp.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.test
{
    internal class Prototype
    {
        private Address BrnoAddress = new Address() { City = "Brno", Street = "Kolejní", HouseNumber = "2905", PostalCode = "612 00" };
        private Address PrahaAddress = new Address() { City = "Praha", Street = "Rooseveltova", HouseNumber = "598", PostalCode = "160 00" };
        private Address OstravaAddress = new Address() { City = "Ostrava", Street = "Jirská", HouseNumber = "2752", PostalCode = "702 00" };
        private Address PlzenAddress = new Address() { City = "Plzeň", Street = "Bendova", HouseNumber = "2009",  PostalCode = "301 00" };
        private Address OlomoucAddress = new Address() { City = "Olomouc", Street = "Dlouhá", HouseNumber = "523", PostalCode = "779 00" };

        private Condition GoodCondition = new Condition() { ConditionState = "Good", Description = "The car is in good condition and does not require any service." };
        private Condition OkayCondition = new Condition() { ConditionState = "OK", Description = "The car's condition is OK to sell it but some maintenance is required/desirable." };
        private Condition SoldCondition = new Condition() { ConditionState = "Sold", Description = "The car was sold and is an archived value for guarantee and statistic purposes." };
    }
}
