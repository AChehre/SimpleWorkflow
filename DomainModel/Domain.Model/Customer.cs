using System;

namespace DomainModel.Domain.Model
{
    public class Customer
    {
        public readonly Guid CustomerId;

        public Customer(Guid customerId)
        {
            CustomerId = customerId;
            State = CustomerState.New;
        }

        public bool DocumentsSigned { get; private set; }

        public CustomerState State { get; private set; }

      

        public void ChangeStateToConfirmed()
        {
            // Transition must be checked

            if (!DocumentsSigned)
                throw new Exception("Documents are not signed.");

            State = CustomerState.Confirmed;
        }

        public void ChangeStateToUnconfirmed()
        {
            // Transition must be checked
            if (DocumentsSigned)
                throw new Exception("Documents are signed!");

            State = CustomerState.Unconfirmed;
        }


        public void SignDocuments()
        {
            DocumentsSigned = true;
        }
    }
}