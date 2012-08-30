//-----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Threading;
    using System.Windows;
    using GirlsWeekly.Locators;
    using GirlsWeekly.Models;
    using GirlsWeekly.Services;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SimpleMvvmToolkit;

    /// <summary>
    /// MainViewModel class
    /// </summary>
    public class MainViewModel : ViewModelBase<MainViewModel>
    {
        /// <summary>
        /// the categories
        /// </summary>
        private List<Category> categories = new List<Category>
        {
        };

        /// <summary>
        /// the package list tap command
        /// </summary>
        private DelegateCommand<Package> packageListTapCommand;

        #region Initialization and Cleanup

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            ////this.TestAppInfos();
            ////this.TestModels();
            this.TestDumpInternalPackages();
            this.TestLoadInternalPackages();
        }

        #endregion

        #region Notifications

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public List<Category> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
                NotifyPropertyChanged(m => m.Categories);
            }
        }

        /// <summary>
        /// Gets the package list tap command.
        /// </summary>
        public DelegateCommand<Package> PackageListTapCommand
        {
            get
            {
                return this.packageListTapCommand ?? (this.packageListTapCommand = new DelegateCommand<Package>(this.OnPackageListBoxTap));
            }
        }

        #endregion

        #region Methods and Callbacks

        /// <summary>
        /// Called when [package list box tap].
        /// </summary>
        /// <param name="package">The package.</param>
        public void OnPackageListBoxTap(Package package)
        {
            //// ServiceLocator.Get<ICommonUIService>().ShowMessageBox(args.ToString(), "title");
            string target = string.Format("/Views/ViewPackagePage.xaml?id={0}", package.PackageId);
            ServiceLocator.Get<INavigator>().NavigateTo(target);
        }

        /// <summary>
        /// Tests the app infos.
        /// </summary>
        private void TestAppInfos()
        {
            ServiceLocator.Get<ICommonUIService>().ShowMessageBox(ServiceLocator.Get<IApplicationInfoService>().DeviceStatusString, "DeviceStatusString");
            ServiceLocator.Get<ICommonUIService>().ShowMessageBox(ServiceLocator.Get<IApplicationInfoService>().DeviceUniqueId, "DeviceUniqueId");
            ServiceLocator.Get<ICommonUIService>().ShowMessageBox(ServiceLocator.Get<IApplicationInfoService>().OSVersion, "OSVersion");
            ServiceLocator.Get<ICommonUIService>().ShowMessageBox(ServiceLocator.Get<IApplicationInfoService>().VersionNumber, "VersionNumber");
            ServiceLocator.Get<ICommonUIService>().ShowMessageBox(ServiceLocator.Get<IApplicationInfoService>().AppID, "AppID");
            ServiceLocator.Get<ICommonUIService>().ShowMessageBox(ServiceLocator.Get<IApplicationInfoService>().NetworkStatus.ToString("F"), "NetworkStatus");
        }

        /// <summary>
        /// Tests the models.
        /// </summary>
        private void TestModels()
        {
            string json;

            //// picture group
            PictureGroup pictureGroup = new PictureGroup { Title = "组图", MainPicture = "主图像url" };
            pictureGroup.PictureList = new List<string> { "url1", "url2" };

            json = JsonConvert.SerializeObject(pictureGroup);
            PictureGroup group = JsonConvert.DeserializeObject<PictureGroup>(json);

            //// package
            Package package = this.categories[0].Packages[0];
            package.Category = string.Empty;
            package.CreateTime = DateTime.Now;
            package.PictureGroups = new List<PictureGroup> { pictureGroup, pictureGroup, };

            json = JsonConvert.SerializeObject(package);
            Package package2 = JsonConvert.DeserializeObject<Package>(json);

            ServiceLocator.Get<IDBManagerService>().InsertOrUpdatePackage(package2);

            ServiceLocator.Get<IDBManagerService>().InsertOrUpdatePackages(new List<Package> { package, package2 });

            var packages = ServiceLocator.Get<IDBManagerService>().GetPackages();
        }

        /// <summary>
        /// Tests the dump internal packages.
        /// </summary>
        private void TestDumpInternalPackages()
        {
            ////var l = new List<Package>
            ////{
            ////    new Package { Title = "Charm(2012.8.15)", MainPicture = "/Pictures/2-7.jpg", CreateTime = DateTime.Now, Category = "Charm" },
            ////    new Package { Title = "Charm(2012.8.22)", MainPicture = "/Pictures/1-4.png", CreateTime = DateTime.Now, Category = "Charm" },
            ////    new Package { Title = "Charm(2012.8.15)", MainPicture = "/Pictures/2-7.jpg", CreateTime = DateTime.Now, Category = "Pure" },
            ////    new Package { Title = "Charm(2012.8.22)", MainPicture = "/Pictures/1-4.png", CreateTime = DateTime.Now, Category = "Pure" },
            ////};

            new PackageManager().DumpInternalPackages();
        }

        /// <summary>
        /// Tests the load internal packages.
        /// </summary>
        private void TestLoadInternalPackages()
        {
            var packageManager = new PackageManager();
            this.Categories = packageManager.PackagesToCategories(packageManager.InternalPackages);
        }

        #endregion

        #region Helpers

        #endregion
    }
}
