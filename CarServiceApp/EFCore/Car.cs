using CarServiceApp.EFCore;
using CarServiceApp.EFCore.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.EFCore
{
    internal class Car : IEntity
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string IdentificationNumber { get; set; }
        public string CarNumber { get; set; }
        public DateTime ProductionTime { get; set; }
        public bool TestDriveable { get; set; }

        public Guid ConditionId { get; set; }
        public virtual Condition Condition { get; set; }
    }
}
