using System;

namespace AnemicModel.Model
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public bool DocumentsSigned { get; set; }

        public CustomerState State { get; set; }
    }
}