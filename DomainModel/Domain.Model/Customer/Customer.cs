using System;
using Domain.Model;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace DomainModel.Domain.Model.Customer
{
    public class Customer : StateMachine<CustomerState>
    {
        public readonly Guid CustomerId;


        public Customer(Guid customerId)
        {
            CustomerId = customerId;
            State = CustomerState.New;

            RegisterTransition(new CustomerTransition(CustomerState.New, CustomerState.Confirmed));
            RegisterTransition(new CustomerTransition(CustomerState.New, CustomerState.Unconfirmed));
        }

        public bool DocumentsSigned { get; private set; }

        public CustomerState State { get; private set; }


        public void ChangeStateToConfirmed()
        {
            var transition = new CustomerTransition(State, CustomerState.Confirmed);
            if (!HasTransition(transition))
                throw new InvalidOperationException(transition.ToString());


            if (!DocumentsSigned)
                throw new Exception("Documents are not signed.");

            State = CustomerState.Confirmed;
        }

        public void ChangeStateToUnconfirmed()
        {
            var transition = new CustomerTransition(State, CustomerState.Unconfirmed);
            if (!HasTransition(transition))
                throw new InvalidOperationException(transition.ToString());

            if (DocumentsSigned)
                throw new Exception("Documents are signed!");

            State = CustomerState.Unconfirmed;
        }


        public void SignDocuments()
        {
            DocumentsSigned = true;
        }

        private class CustomerTransition : Transition<CustomerState>
        {
            public CustomerTransition(CustomerState currentState, CustomerState destinationState) : base(currentState,
                destinationState)
            {
            }
        }
    }
}