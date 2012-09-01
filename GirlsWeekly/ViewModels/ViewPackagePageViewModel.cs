//-----------------------------------------------------------------------
// <copyright file="ViewPackagePageViewModel.cs" company="eggfly">
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
    /// MainViewModel class
    /// </summary>
    public class ViewPackagePageViewModel : ViewModelBase<ViewPackagePageViewModel>
    {
        /// <summary>
        /// package id
        /// </summary>
        private int packageId;

        /// <summary>
        /// package object
        /// </summary>
        private Package package;

        /// <summary>
        /// pictureGroup List Tap Command
        /// </summary>
        private DelegateCommand<PictureGroup> pictureGroupListTapCommand;

        #region Initialization and Cleanup

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPackagePageViewModel"/> class.
        /// </summary>
        public ViewPackagePageViewModel()
        {
        }

        #endregion

        #region Notifications

        #endregion

        #region Properties

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
                Package package = ServiceLocator.Get<IDBManagerService>().GetPackage(this.packageId);
                if (package != null)
                {
                    this.Package = package;
                }
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
                    NotifyPropertyChanged(m => m.Package);
                }
            }
        }

        /// <summary>
        /// Gets the picture group list tap command.
        /// </summary>
        public DelegateCommand<PictureGroup> PictureGroupListTapCommand
        {
            get
            {
                return this.pictureGroupListTapCommand ?? (this.pictureGroupListTapCommand = new DelegateCommand<PictureGroup>(this.OnPictureGroupListBoxTap));
            }
        }

        #endregion

        #region Callbacks and Methods

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

        /// <summary>
        /// Called when [picture group list box tap].
        /// </summary>
        /// <param name="pictureGroup">The picture group.</param>
        public void OnPictureGroupListBoxTap(PictureGroup pictureGroup)
        {
            string target = string.Format("/Views/ViewPicturePage.xaml?PackageId={0}&PictureGroupIndex={1}", this.PackageId, this.Package.PictureGroups.IndexOf(pictureGroup));
            ServiceLocator.Get<INavigator>().NavigateTo(target);
        }

        #endregion

        #region Helpers

        #endregion
    }
}
