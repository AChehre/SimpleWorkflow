using System;
using AnemicModel.Domain.Model;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace AnemicModel.Service.Workflow
{
    public class UndefinedToNewCommand : BaseCustomerCommand, ICommand
    {
        public void Execute()
        {
            if (Customer == null)
                throw new ArgumentNullException(nameof(Customer));
            if (Customer.CustomerId == Guid.Empty)
                throw new ArgumentOutOfRangeException(nameof(Customer.CustomerId));

            Customer.State = CustomerState.New;
        }
    }
}