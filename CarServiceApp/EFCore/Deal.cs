using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.EFCore
{
    internal class Deal
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public DateTime DealDateTime { get; set; }
        public long PaymentAccount { get; set; }
        public long PaymentCode { get; set; }
    }
}
