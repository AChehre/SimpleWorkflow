using System;
using Domain.Model.Customer;
using Xunit;

namespace Tests
{
    public class CustomerTests
    {

        [Fact]
        public void ChangeStateToConfirmed_DocumentsAreSigned_StateChangeToConfirmed()
        {
            var customer = new Customer(Guid.NewGuid());
            customer.SignDocuments();

            customer.ChangeStateToConfirmed();
            Assert.Equal(customer.State, CustomerState.Confirmed);
        }

        [Fact]
        public void ChangeStateToUnconfirmed_DocumentsAreNotSigned_StateChangeToUnconfirmed()
        {
            var customer = new Customer(Guid.NewGuid());
            customer.ChangeStateToUnconfirmed();

            Assert.Equal(customer.State, CustomerState.Unconfirmed);
        }

      
    }
}