using System;
using AnemicModel.Model;
using AnemicModel.Service.Workflow;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace Service
{
    public class CustomerService : Workflow<CustomerState>
    {
        public CustomerService()
        {
            RegisterTransition(CustomerTransition.Create(CustomerState.Undefined, CustomerState.New),
                new UndefinedToNewCommand());

            RegisterTransition(CustomerTransition.Create(CustomerState.New, CustomerState.Confirmed),
                new NewToConfirmedCommand());


            RegisterTransition(CustomerTransition.Create(CustomerState.New, CustomerState.Unconfirmed),
                new NewToUnconfirmedCommand());
        }

        public void ChangeStateToNew(Customer customer)
        {
            ChangeState(customer, CustomerState.New);
        }

        public void ChangeStateToConfirmed(Customer customer)
        {
            ChangeState(customer, CustomerState.Confirmed);
        }

        public void ChangeStateToUnconfirmed(Customer customer)
        {
            ChangeState(customer, CustomerState.Unconfirmed);
        }

        private void ChangeState(Customer customer, CustomerState dest)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));


            var command = GetCommand(CustomerTransition.Create(customer.State, dest));
            if (command == null)
                throw new Exception($"Command is null for {customer.State} -> {dest}");
            var baseCustomerCommand = (BaseCustomerCommand) command;
            baseCustomerCommand.SetCustomer(customer);
            command.Execute();
        }
    }
}