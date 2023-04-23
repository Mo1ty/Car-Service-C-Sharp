using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.EFCore.common
{
    internal interface IEntity
    {
        public Guid Id { get; set; }
    }
}
