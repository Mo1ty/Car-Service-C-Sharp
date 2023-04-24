using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarServiceApp.EFCore;

namespace CarServiceApp.EFCore.Context
{
    internal static class ContextConfiguration
    {
        public static CarServiceContext Context { get; private set; } = new CarServiceContext();
    }
}
