//-----------------------------------------------------------------------
// <copyright file="ViewPicturePage.xaml.cs" company="eggfly">
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
    using GirlsWeekly.Resources;
    using GirlsWeekly.ViewModel;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;

    /// <summary>
    /// ViewPicture Page
    /// </summary>
    public partial class ViewPicturePage : PhoneApplicationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPicturePage"/> class.
        /// </summary>
        public ViewPicturePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 当页面变为框架中的活动页面时 调用。
        /// </summary>
        /// <param name="e">包含 事件数据的对象。</param>
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var queryString = NavigationContext.QueryString;
            string packageIdString = string.Empty;
            string pictureGroupIndexString = string.Empty;
            queryString.TryGetValue("PackageId", out packageIdString);
            queryString.TryGetValue("PictureGroupIndex", out pictureGroupIndexString);
            int packageId = -1;
            int pictureGroupIndex = -1;
            int.TryParse(packageIdString, out packageId);
            int.TryParse(pictureGroupIndexString, out pictureGroupIndex);
            ViewPicturePageViewModel viewModel = this.DataContext as ViewPicturePageViewModel;
            if (viewModel != null)
            {
                viewModel.PackageId = packageId;
                viewModel.PictureGroupIndex = pictureGroupIndex;
            }
        }
    }
}