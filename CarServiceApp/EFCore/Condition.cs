using CarServiceApp.EFCore.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.EFCore
{
    internal class Condition : IEntity
    {
        public Guid Id { get; set; }
        public string ConditionState { get; set; }
        public string Description { get; set; }
    }
}
