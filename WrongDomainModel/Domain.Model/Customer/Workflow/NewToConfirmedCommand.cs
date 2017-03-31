using System;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace WrongDomainModel.Domain.Model.Customer.Workflow
{
    public class NewToConfirmedCommand : ICommand
    {
        private readonly Customer _customer;

        public NewToConfirmedCommand(Customer customer)
        {
            _customer = customer;
        }

        public void Execute()
        {
            if (!_customer.DocumentsSigned)
                throw new Exception("Documents are not signed.");

            _customer.State = CustomerState.Confirmed;
        }
    }
}