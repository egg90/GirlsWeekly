//-----------------------------------------------------------------------
// <copyright file="ViewPicturePageViewModel.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Windows;
    using GirlsWeekly.Locators;
    using GirlsWeekly.Models;
    using GirlsWeekly.Services;
    using SimpleMvvmToolkit;
    using SimpleMvvmToolkit.ModelExtensions;

    /// <summary>
    /// ViewPicturePageViewModel class
    /// </summary>
    public class ViewPicturePageViewModel : ViewModelBase<ViewPicturePageViewModel>
    {
        /// <summary>
        /// Package Id
        /// </summary>
        private int packageId = -1;

        /// <summary>
        /// Picture Group Id
        /// </summary>
        private int pictureGroupIndex = -1;

        /// <summary>
        /// package object
        /// </summary>
        private Package package = null;

        #region Initialization and Cleanup

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPicturePageViewModel"/> class.
        /// </summary>
        public ViewPicturePageViewModel()
        {
        }

        #endregion

        #region Notifications

        #endregion

        #region Properties

        /// <summary>
        /// Gets the photos.
        /// </summary>
        public List<string> Photos
        {
            get
            {
                return this.Package.PictureGroups[this.PictureGroupIndex].PictureList;
            }
        }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        /// <value>
        /// The package id.
        /// </value>
        public int PackageId
        {
            get
            {
                return this.packageId;
            }

            set
            {
                this.packageId = value;
                Package package = ServiceLocator.Get<IDBManagerService>().GetPackage(value);
                if (package != null)
                {
                    this.Package = package;
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the picture group.
        /// </summary>
        /// <value>
        /// The index of the picture group.
        /// </value>
        public int PictureGroupIndex
        {
            get
            {
                return this.pictureGroupIndex;
            }

            set
            {
                this.pictureGroupIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the package.
        /// </summary>
        /// <value>
        /// The package.
        /// </value>
        public Package Package
        {
            get
            {
                return this.package;
            }

            set
            {
                if (this.package != value)
                {
                    this.package = value;
                }

                NotifyPropertyChanged(m => m.Package);
            }
        }

        #endregion

        #region Methods

        #endregion

        #region Callbacks

        /// <summary>
        /// Called when [app bar like button click].
        /// </summary>
        public void OnAppBarLikeButtonClick()
        {
            MessageBox.Show("OnAppBarLikeButtonClick");
        }

        /// <summary>
        /// Called when [app bar about menu click].
        /// </summary>
        public void OnAppBarAboutMenuClick()
        {
            MessageBox.Show("OnAppBarAboutMenuClick");
        }

        #endregion

        #region Helpers

        #endregion
    }
}
