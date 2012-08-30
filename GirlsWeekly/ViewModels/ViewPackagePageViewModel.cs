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
        /// the picture groups
        /// </summary>
        private List<PictureGroup> pictureGroups = new List<PictureGroup>
        {
            new PictureGroup { Title = "周杰伦xxxxxxxx", MainPicture = "/Pictures/1-1.png" },
            new PictureGroup { Title = "甄子丹xxxxxxxxx甄子丹", MainPicture = "/Pictures/1-2.png" },
            new PictureGroup { Title = "xxxx陈小春xxx", MainPicture = "/Pictures/1-3.png" },
            new PictureGroup { Title = "陈意涵xxxxxxx", MainPicture = "/Pictures/1-4.png" },
            new PictureGroup { Title = "大S sssssss", MainPicture = "/Pictures/1-5.png" },
            new PictureGroup { Title = "古天乐dddddddd", MainPicture = "/Pictures/1-6.png" },

            new PictureGroup { Title = "周杰伦xxxxxxxx", MainPicture = "/Pictures/2-1.jpg" },
            new PictureGroup { Title = "甄子丹xxxxxxxxx甄子丹", MainPicture = "/Pictures/2-2.jpg" },
            new PictureGroup { Title = "xxxx陈小春xxx", MainPicture = "/Pictures/2-3.jpg" },
            new PictureGroup { Title = "大大xxxxxxx", MainPicture = "/Pictures/2-4.jpg" },
            new PictureGroup { Title = "大S sssssss", MainPicture = "/Pictures/2-5.jpg" },
            new PictureGroup { Title = "古天乐dddddddd", MainPicture = "/Pictures/2-6.jpg" },
            new PictureGroup { Title = "大S sssssss", MainPicture = "/Pictures/2-7.jpg" },
            new PictureGroup { Title = "古天乐dddddddd", MainPicture = "/Pictures/2-8.jpg" },
            new PictureGroup { Title = "大S sssssss", MainPicture = "/Pictures/2-9.jpg" },
            new PictureGroup { Title = "古天乐dddddddd", MainPicture = "/Pictures/2-10.jpg" },
        };

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
        /// Gets the photos.
        /// </summary>
        public List<PictureGroup> PictureGroups
        {
            get
            {
                return this.pictureGroups;
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

        /// <summary>
        /// Called when [picture group list box tap].
        /// </summary>
        /// <param name="args">The args.</param>
        public void OnPictureGroupListBoxTap(PictureGroup args)
        {
            string target = string.Format("/Views/ViewPicturePage.xaml?id={0}", 0);
            ServiceLocator.Get<INavigator>().NavigateTo(target);
        }

        #endregion

        #region Helpers

        #endregion
    }
}
