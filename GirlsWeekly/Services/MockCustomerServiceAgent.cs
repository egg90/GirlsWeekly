//-----------------------------------------------------------------------
// <copyright file="MockCustomerServiceAgent.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Services
{
    using System;
    using System.Linq;
    using GirlsWeekly.Models;

    /// <summary>
    /// MockCustomerServiceAgent class
    /// </summary>
    public class MockCustomerServiceAgent : ICustomerServiceAgent
    {
        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <returns>
        /// Cusomer instance
        /// </returns>
        public Customer CreateCustomer()
        {
            return new Customer
            {
                CustomerId = 1,
                CustomerName = "John Doe",
                City = "Dallas"
            };
        }
    }
}
