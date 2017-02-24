using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Customer
{
    public class Customer
    {
        private readonly Guid _CustomerId;
        public CustomerState State { get; private set; }

        public Customer(Guid customerId)
        {
            _CustomerId = customerId;
            State = CustomerState.Undefined;
        }
    }
}
