//-----------------------------------------------------------------------
// <copyright file="ViewPackagePage.xaml.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using GirlsWeekly.Locators;
    using GirlsWeekly.Services;
    using GirlsWeekly.ViewModel;
    using Microsoft.Phone.Controls;

    /// <summary>
    /// ViewPackagePage class
    /// </summary>
    public partial class ViewPackagePage : PhoneApplicationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPackagePage"/> class.
        /// </summary>
        public ViewPackagePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Called when a page becomes the active page in a frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var queryString = NavigationContext.QueryString;
            string packageIdString = string.Empty;
            queryString.TryGetValue("PackageId", out packageIdString);
            int packageId = -1;
            int.TryParse(packageIdString, out packageId);
            ViewPackagePageViewModel viewModel = this.DataContext as ViewPackagePageViewModel;
            if (viewModel != null)
            {
                viewModel.PackageId = packageId;
            }
        }
    }
}