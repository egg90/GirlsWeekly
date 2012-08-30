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
    using SimpleMvvmToolkit;
    using SimpleMvvmToolkit.ModelExtensions;

    /// <summary>
    /// ViewPicturePageViewModel class
    /// </summary>
    public class ViewPicturePageViewModel : ViewModelBase<ViewPicturePageViewModel>
    {
        /// <summary>
        /// photo strings
        /// </summary>
        private List<string> photos = new List<string>
        {
            "http://qcimg1.mnsfz.com/pic/qingchun/2012-8-17/1/1.jpg",
            "http://qcimg1.mnsfz.com/pic/qingchun/2012-8-17/1/10.jpg",
            "http://imgs.xiuna.com/xiezhen/2012-8-22/1/1.jpg",

            "http://image.hnol.net/c/2012-08/22/20/201208222049111388-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/20120822204911899-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491187610-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491225211-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491235812-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222049109761-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222049119642-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222049113443-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222049115944-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222049118355-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491186-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222049118117-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491248513-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491217914-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491239815-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491268916-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222049126417-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/2012082220491297518-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/20120822205431931-1559530.jpg",
            "http://image.hnol.net/c/2012-08/22/20/201208222054322162-1559530.jpg",
        };

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
                return this.photos;
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
