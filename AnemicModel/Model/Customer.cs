using System;

namespace Model
{
    public class Customer
    {
        public readonly Guid CustomerId;
        public bool DocumentsSigned { get; set; }

        public CustomerState State { get; set; }
    }
}