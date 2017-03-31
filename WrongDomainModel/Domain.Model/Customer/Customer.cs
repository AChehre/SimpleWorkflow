using System;
using System.Diagnostics;
using WrongDomainModel.Domain.Model.Customer.Workflow;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace WrongDomainModel.Domain.Model.Customer
{
    public class Customer : Workflow<CustomerState>
    {
        public readonly Guid CustomerId;

        public Customer(Guid customerId)
        {
            CustomerId = customerId;
            State = CustomerState.Undefined;


            RegisterTransition(CustomerTransition.Create(CustomerState.Undefined, CustomerState.New),
                new UndefinedToNewCommand(this));

            RegisterTransition(CustomerTransition.Create(CustomerState.New, CustomerState.Confirmed),
                new NewToConfirmedCommand(this));


            RegisterTransition(CustomerTransition.Create(CustomerState.New, CustomerState.Unconfirmed),
                new NewToUnconfirmedCommand(this));

            ChangeStateToNew();
        }

        public bool DocumentsSigned { get; set; }

        public CustomerState State { get; set; }

        public void ChangeStateToNew()
        {
          ChangeState(CustomerState.New);
        }

        public void ChangeStateToConfirmed()
        {
          ChangeState(CustomerState.Confirmed);
        }

        public void ChangeStateToUnconfirmed()
        {
          ChangeState(CustomerState.Unconfirmed);
        }

        private void ChangeState(CustomerState dest)
        {
            var command = GetCommand(CustomerTransition.Create(State, dest));
            if (command == null)
                throw new Exception($"Command is null for {State} -> {dest}");
            command.Execute();
        }

        public void SignDocuments()
        {
            DocumentsSigned = true;
        }
    }
}