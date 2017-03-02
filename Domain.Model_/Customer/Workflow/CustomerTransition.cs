using Infrastructure.Common.Workflow;

namespace Domain.Model.Customer.Workflow
{
    public class CustomerTransition : Transition<CustomerState>
    {
        public CustomerTransition(CustomerState currentState, CustomerState destinationState)
            : base(currentState, destinationState)
        {
        }

        public static CustomerTransition Create(CustomerState currentState, CustomerState destinationState)
        {
            return new CustomerTransition(currentState, destinationState);
        }
    }
}