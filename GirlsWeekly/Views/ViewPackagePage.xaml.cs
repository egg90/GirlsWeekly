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
    }
}