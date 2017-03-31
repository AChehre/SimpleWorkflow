using System;
using AnemicModel.Model;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace AnemicModel.Service.Workflow
{
    public class NewToUnconfirmedCommand : BaseCustomerCommand, ICommand
    {
       
        public void Execute()
        {
            if (Customer.DocumentsSigned)
                throw new Exception("Documents are signed!");

            Customer.State = CustomerState.Unconfirmed;
        }
    }
}