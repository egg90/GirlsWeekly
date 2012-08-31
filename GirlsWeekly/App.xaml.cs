//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using GirlsWeekly.Models;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;

    /// <summary>
    /// App class
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Avoid double-initialization
        /// </summary>
        private bool phoneApplicationInitialized = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            this.UnhandledException += this.Application_UnhandledException;

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                // Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are being GPU accelerated with a colored overlay.
                // Application.Current.Host.Settings.EnableCacheVisualization = true;
            }

            // Standard Silverlight initialization
            this.InitializeComponent();

            // Phone-specific initialization
            this.InitializePhoneApplication();
            
            this.SetupUriMapper();
            this.LoadInternalPackages();
        }

        /// <summary>
        /// Gets the root frame of the application
        /// </summary>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Loads the internal packages.
        /// </summary>
        private void LoadInternalPackages()
        {
            var packageManager = new PackageManager();
            packageManager.UpdateInternalPackagesIntoDB();
        }

        /// <summary>
        /// Setups the URI mapper.
        /// </summary>
        private void SetupUriMapper()
        {
            UriMapper mapper = new UriMapper();
            mapper.UriMappings.Add(new UriMapping());
            mapper.UriMappings[0].Uri = new Uri("/StartPage.xaml", UriKind.Relative);
            //// mapper.UriMappings[0].MappedUri = new Uri("/Views/ViewPicturePage.xaml", UriKind.Relative);
            mapper.UriMappings[0].MappedUri = new Uri("/Views/Main.xaml", UriKind.Relative);
            //// mapper.UriMappings[0].MappedUri = new Uri("/Views/ViewPackagePage.xaml", UriKind.Relative);
            this.RootFrame.UriMapper = mapper;
        }

        /// <summary>
        /// Handles the Launching event of the Application control.
        /// This code will not execute when the application is reactivated
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Phone.Shell.LaunchingEventArgs"/> instance containing the event data.</param>
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Activated event of the Application control.
        /// This code will not execute when the application is first launched
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Phone.Shell.ActivatedEventArgs"/> instance containing the event data.</param>
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Deactivated event of the Application control.
        /// Code to execute when the application is deactivated (sent to background)
        /// This code will not execute when the application is closing
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Phone.Shell.DeactivatedEventArgs"/> instance containing the event data.</param>
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Closing event of the Application control.
        /// Code to execute when the application is closing (eg, user hit Back)
        /// This code will not execute when the application is deactivated
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Phone.Shell.ClosingEventArgs"/> instance containing the event data.</param>
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        /// <summary>
        /// Handles the NavigationFailed event of the RootFrame control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Navigation.NavigationFailedEventArgs"/> instance containing the event data.</param>
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        /// <summary>
        /// Handles the UnhandledException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.ApplicationUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        /// <summary>
        /// Initializes the phone application.
        /// Do not add any additional code to this method
        /// </summary>
        private void InitializePhoneApplication()
        {
            if (this.phoneApplicationInitialized)
            {
                return;
            }

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            this.RootFrame = new PhoneApplicationFrame();
            this.RootFrame.Navigated += this.CompleteInitializePhoneApplication;

            // Handle navigation failures
            this.RootFrame.NavigationFailed += this.RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            this.phoneApplicationInitialized = true;
        }

        /// <summary>
        /// Completes the initialize phone application.
        /// Do not add any additional code to this method
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Navigation.NavigationEventArgs"/> instance containing the event data.</param>
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (this.RootVisual != this.RootFrame)
            {
                this.RootVisual = this.RootFrame;
            }

            // Remove this handler since it is no longer needed
            this.RootFrame.Navigated -= this.CompleteInitializePhoneApplication;
        }

        #endregion
    }
}