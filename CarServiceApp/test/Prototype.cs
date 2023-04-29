using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.test
{
    internal class Prototype
    {
        public Condition GoodCondition = new Condition() { ConditionState = "Good", Description = "The car is in good condition and does not require any service." };
        private Condition OkayCondition = new Condition() { ConditionState = "OK", Description = "The car's condition is OK to sell it but some maintenance is required/desirable." };
        private Condition SoldCondition = new Condition() { ConditionState = "Sold", Description = "The car was sold and is an archived value for guarantee and statistic purposes." };

        private Address BrnoAddress = new Address() { City = "Brno", Street = "Kolejní", HouseNumber = "2905", PostalCode = "612 00" };
        private Address PrahaAddress = new Address() { City = "Praha", Street = "Rooseveltova", HouseNumber = "598", PostalCode = "160 00" };
        private Address OstravaAddress = new Address() { City = "Ostrava", Street = "Jirská", HouseNumber = "2752", PostalCode = "702 00" };
        private Address PlzenAddress = new Address() { City = "Plzeň", Street = "Bendova", HouseNumber = "2009",  PostalCode = "301 00" };
        private Address OlomoucAddress = new Address() { City = "Olomouc", Street = "Dlouhá", HouseNumber = "523", PostalCode = "779 00" };

        

        private Client BrnoClient = new Client() { Name = "Martin", Surname = "Novak", 
            BirthDate = new DateTime(year: 2000, month: 4, day: 3), DriverLicense = "AB#21324S82", Email = "brno_human@seznam.cz"};
        private Client PragueClient = new Client(){ Name = "Alzbeta", Surname = "Sedlakova",
            BirthDate = new DateTime(year: 2000, month: 4, day: 3), DriverLicense = "AS#2309472D", Email = "prague_human@seznam.cz"};
        private Client OstravaClient = new Client() { Name = "Tomas", Surname = "Martin", 
            BirthDate = new DateTime(year: 2000, month: 4, day: 3), DriverLicense = "BS#Q234129U", Email = "prague_human@seznam.cz" };
        private Client PlzenClient = new Client() { Name = "Pavel", Surname = "Roosevelt", 
            BirthDate = new DateTime(year: 2000, month: 4, day: 3), DriverLicense = "CD#Q239-RYU", Email = "prague_human@seznam.cz" };
        private Client OlomoucClient = new Client() { Name = "Petr", Surname = "Malik",
            BirthDate = new DateTime(year: 2000, month: 4, day: 3), DriverLicense = "MF#139458SD", Email = "prague_human@seznam.cz" };

        private Car BrnoCar = new Car() { Brand = "Tesla", Model = "X", IdentificationNumber = "VQ459NY8TT34N8Q", CarNumber = "WR912", 
            ProductionTime = new DateTime(year: 2002, month: 9, day: 1), TestDriveable = true };
        private Car OstravaCar = new Car() { Brand = "Volkswagen", Model = "Polo", IdentificationNumber = "213VR23R13DVR12", CarNumber = "EF342", 
            ProductionTime = new DateTime(year: 2002, month: 9, day: 1), TestDriveable = false };
        private Car PlzenCar = new Car() {Brand = "Audi", Model = "A8", IdentificationNumber = "8F4VT53V0139BTP", CarNumber = "AN231", 
            ProductionTime = new DateTime(year: 2002, month: 9, day: 1), TestDriveable = false };



        public void addConditions()
        {
            using (CarServiceContext context = ContextConfiguration.Context)
            {
                context.Conditions.Add(GoodCondition);
                context.Conditions.Add(OkayCondition);
                context.Conditions.Add(SoldCondition);
                context.SaveChanges();
            }
        }

        public void addAll()
        {
            using (CarServiceContext context = ContextConfiguration.Context)
            {
                context.Conditions.Add(GoodCondition);
                context.Conditions.Add(OkayCondition);
                context.Conditions.Add(SoldCondition);
                context.SaveChanges();

                context.Addresses.Add(BrnoAddress);
                context.Addresses.Add(PrahaAddress);
                context.Addresses.Add(OstravaAddress);
                context.Addresses.Add(OlomoucAddress);
                context.Addresses.Add(PlzenAddress);
                context.SaveChanges();

                BrnoCar.ConditionId = GoodCondition.Id;
                context.Cars.Add(BrnoCar);
                OstravaCar.ConditionId = SoldCondition.Id;
                context.Cars.Add(OstravaCar);
                PlzenCar.ConditionId = OkayCondition.Id;
                context.Cars.Add(PlzenCar);
                context.SaveChanges();

                BrnoClient.AddressId = BrnoAddress.Id;
                context.Clients.Add(BrnoClient);
                PragueClient.AddressId = PrahaAddress.Id;
                context.Clients.Add(PragueClient);
                OstravaClient.AddressId = OstravaAddress.Id;
                context.Clients.Add(OstravaClient);
                OlomoucClient.AddressId = OlomoucAddress.Id;
                context.Clients.Add(OlomoucClient);
                PlzenClient.AddressId = PlzenAddress.Id;
                context.Clients.Add(PlzenClient);
                context.SaveChanges();

                Deal OstravaDeal = new Deal() { ClientId = OstravaClient.Id, CarId = OstravaCar.Id, 
                    DealDateTime = new DateTime(year: 2022, month: 3, day: 4), PaymentAccount = 2380572352, PaymentCode = 124182941};
                context.Deals.Add(OstravaDeal);
                context.SaveChanges();
            }
        }
    }
}
