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
        public void ChangeStateToConfirmed_DocumentsAreNotSigned_ThrowException()
        {
            var customer = new Customer(Guid.NewGuid());
   
            Assert.Throws<Exception>(()=>customer.ChangeStateToConfirmed());
        }

        [Fact]
        public void ChangeStateToUnconfirmed_DocumentsAreNotSigned_StateChangeToUnconfirmed()
        {
            var customer = new Customer(Guid.NewGuid());
            customer.ChangeStateToUnconfirmed();

            Assert.Equal(customer.State, CustomerState.Unconfirmed);
        }

        [Fact]
        public void ChangeStateToUnconfirmed_DocumentsAreSigned_ThrowException()
        {
            var customer = new Customer(Guid.NewGuid());
           customer.SignDocuments();

            Assert.Throws<Exception>(() => customer.ChangeStateToUnconfirmed());
        }


    }
}