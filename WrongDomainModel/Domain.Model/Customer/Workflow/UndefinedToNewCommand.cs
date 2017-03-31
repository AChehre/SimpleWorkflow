using System;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace WrongDomainModel.Domain.Model.Customer.Workflow
{
    public class UndefinedToNewCommand : ICommand
    {
        private readonly Customer _customer;

        public UndefinedToNewCommand(Customer customer)
        {
            _customer = customer;
        }

        public void Execute()
        {
            if (_customer == null || _customer.CustomerId == Guid.Empty)
                throw new Exception("Invalid customer");

            _customer.State = CustomerState.New;
        }
    }
}