using AnemicModel.Model;

namespace AnemicModel.Service.Workflow
{
    public class BaseCustomerCommand
    {
        protected Customer Customer { get; set; }

        public void SetCustomer(Customer customer)
        {
            Customer = customer;
        }
    }
}