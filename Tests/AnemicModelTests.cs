using System;
using AnemicModel.Model;
using Service;
using Xunit;

namespace Tests
{
    public class AnemicModelTests
    {
        [Fact]
        public void ChangeStateStatus_CustomerIsNull_ThrowException()
        {
            var customerService = new CustomerService();


            Assert.Throws<ArgumentNullException>(() => customerService.ChangeStateToConfirmed(null));
        }

        [Fact]
        public void ChangeStateToConfirmed_DocumentsAreNotSigned_ThrowException()
        {
            var customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                DocumentsSigned = false
            };

            var customerService = new CustomerService();


            Assert.Throws<Exception>(() => customerService.ChangeStateToConfirmed(customer));
        }

        [Fact]
        public void ChangeStateToConfirmed_DocumentsAreSigned_StateChangeToConfirmed()
        {
            var customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                State = CustomerState.New,
                DocumentsSigned = true
            };

            var customerService = new CustomerService();
            customerService.ChangeStateToConfirmed(customer);
            Assert.Equal(customer.State, CustomerState.Confirmed);
        }


        [Fact]
        public void ChangeStateToNew_CustomerHasId_StateChangeToNew()
        {
            var customer = new Customer
            {
                State = CustomerState.Undefined,
                CustomerId = Guid.NewGuid()
            };
            var customerService = new CustomerService();
            customerService.ChangeStateToNew(customer);

            Assert.Equal(customer.State, CustomerState.New);
        }

        [Fact]
        public void ChangeStateToNew_CustomerHasNotId_ThrowException()
        {
            var customer = new Customer
            {
                State = CustomerState.Undefined
            };
            var customerService = new CustomerService();


            Assert.Throws<ArgumentOutOfRangeException>(() => customerService.ChangeStateToNew(customer));
        }

        [Fact]
        public void ChangeStateToUnconfirmed_DocumentsAreNotSigned_StateChangeToUnconfirmed()
        {
            var customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                State = CustomerState.New,
                DocumentsSigned = false
            };

            var customerService = new CustomerService();
            customerService.ChangeStateToUnconfirmed(customer);
            Assert.Equal(customer.State, CustomerState.Unconfirmed);
        }

        [Fact]
        public void ChangeStateToUnconfirmed_DocumentsAreSigned_ThrowException()
        {
            var customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                DocumentsSigned = true
            };

            var customerService = new CustomerService();
            Assert.Throws<Exception>(() => customerService.ChangeStateToUnconfirmed(customer));
        }
    }
}