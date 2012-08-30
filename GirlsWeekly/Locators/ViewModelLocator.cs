//-----------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:GirlsWeekly"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

namespace GirlsWeekly.Locators
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using GirlsWeekly.Services;
    using GirlsWeekly.ViewModel;
    using SimpleMvvmToolkit;

    /// <summary>
    /// This class creates ViewModels on demand for Views, supplying a
    /// ServiceAgent to the ViewModel if required.
    /// <para>
    /// Place the ViewModelLocator in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocator xmlns:vm="clr-namespace:GirlsWeekly"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// Use the <strong>mvvmlocator</strong> or <strong>mvvmlocatornosa</strong>
    /// code snippets to add ViewModels to this locator.
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Gets the view package page view model.
        /// </summary>
        public ViewPackagePageViewModel ViewPackagePageViewModel
        {
            get { return new ViewPackagePageViewModel(); }
        }

        /// <summary>
        /// Gets the main view model.
        /// </summary>
        public MainViewModel MainViewModel
        {
            get { return new MainViewModel(); }
        }

        /// <summary>
        /// Gets the view picture page view model.
        /// </summary>
        public ViewPicturePageViewModel ViewPicturePageViewModel
        {
            get { return new ViewPicturePageViewModel(); }
        }
    }
}