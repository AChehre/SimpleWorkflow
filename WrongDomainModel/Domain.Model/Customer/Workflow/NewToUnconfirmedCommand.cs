﻿using System;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace WrongDomainModel.Domain.Model.Customer.Workflow
{
    public class NewToUnconfirmedCommand : ICommand
    {
        private readonly Customer _customer;

        public NewToUnconfirmedCommand(Customer customer)
        {
            _customer = customer;
        }

        public void Execute()
        {
            if (_customer.DocumentsSigned)
                throw new Exception("Documents are signed!");

            _customer.State = CustomerState.Unconfirmed;
        }
    }
}