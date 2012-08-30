//-----------------------------------------------------------------------
// <copyright file="Customer.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SimpleMvvmToolkit;

    /// <summary>
    /// Customer Model
    /// </summary>
    public class Customer : ModelBase<Customer>
    {
        /// <summary>
        /// Customer id
        /// </summary>
        private int customerId;

        /// <summary>
        /// Customer name
        /// </summary>
        private string customerName;

        /// <summary>
        /// city string
        /// </summary>
        private string city;

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>
        /// The customer id.
        /// </value>
        public int CustomerId
        {
            get
            {
                return this.customerId;
            }

            set
            {
                this.customerId = value;
                NotifyPropertyChanged(m => m.CustomerId);
            }
        }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName
        {
            get
            {
                return this.customerName;
            }

            set
            {
                this.customerName = value;
                NotifyPropertyChanged(m => m.CustomerName);
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
                NotifyPropertyChanged(m => m.City);
            }
        }
    }
}
