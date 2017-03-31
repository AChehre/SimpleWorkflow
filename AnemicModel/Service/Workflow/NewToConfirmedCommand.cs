using System;
using AnemicModel.Model;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace AnemicModel.Service.Workflow
{
    public class NewToConfirmedCommand : BaseCustomerCommand, ICommand
    {
      

        public void Execute()
        {
            if (!Customer.DocumentsSigned)
                throw new Exception("Documents are not signed.");

            Customer.State = CustomerState.Confirmed;
        }
    }
}