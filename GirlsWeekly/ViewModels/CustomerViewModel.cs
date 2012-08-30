//-----------------------------------------------------------------------
// <copyright file="CustomerViewModel.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Input;
    using GirlsWeekly.Models;
    using GirlsWeekly.Services;
    using SimpleMvvmToolkit;
    using SimpleMvvmToolkit.ModelExtensions;

    /// <summary>
    /// This class extends ViewModelDetailBase which implements IEditableDataObject.
    /// <para>
    /// Specify type being edited <strong>DetailType</strong> as the second type argument
    /// and as a parameter to the seccond ctor.
    /// </para>
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class CustomerViewModel : ViewModelDetailBase<CustomerViewModel, Customer>
    {
        #region Initialization and Cleanup

        /// <summary>
        /// Service agent
        /// Add a member for ICustomerServiceAgent
        /// </summary>
        private ICustomerServiceAgent serviceAgent;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerViewModel"/> class.
        /// </summary>
        public CustomerViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerViewModel"/> class.
        /// </summary>
        /// <param name="serviceAgent">The service agent.</param>
        public CustomerViewModel(ICustomerServiceAgent serviceAgent)
        {
            this.serviceAgent = serviceAgent;
        }

        #endregion

        #region Notifications

        /// <summary>
        /// Occurs when [error notice].
        /// Add events to notify the view or obtain data from the view
        /// </summary>
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        #endregion

        #region Properties

        #endregion

        #region Commands

        /// <summary>
        /// Gets the new customer command.
        /// </summary>
        public ICommand NewCustomerCommand
        {
            get
            {
                return new DelegateCommand(this.NewCustomer);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// News the customer.
        /// Set the model to a new customer
        /// </summary>
        public void NewCustomer()
        {
            this.Model = this.serviceAgent.CreateCustomer();
        }

        #endregion

        #region Completion Callbacks

        #endregion

        #region Helpers

        /// <summary>
        /// Notifies the error.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            this.Notify(this.ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }

        #endregion
    }
}