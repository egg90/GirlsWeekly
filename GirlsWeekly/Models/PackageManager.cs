//-----------------------------------------------------------------------
// <copyright file="PackageManager.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Net;
    using System.Windows;
    using GirlsWeekly.Locators;
    using GirlsWeekly.Resources;
    using GirlsWeekly.Services;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Package Manager
    /// </summary>
    public class PackageManager
    {
        /// <summary>
        /// Internal Packages File Path
        /// </summary>
        public const string InternalPackagesFilePath = "Pictures/InternalPackages.json";

        /// <summary>
        /// internal packages
        /// </summary>
        private List<Package> internalPackages;

        /// <summary>
        /// Gets or sets the internal packages.
        /// </summary>
        /// <value>
        /// The internal packages.
        /// </value>
        public List<Package> InternalPackages
        {
            get
            {
                if (this.internalPackages == null)
                {
                    this.InternalPackages = this.LoadInternalPackages();
                }

                return this.internalPackages;
            }

            set
            {
                this.internalPackages = value;
            }
        }

        /// <summary>
        /// Dumps the internal packages.
        /// </summary>
        public void DumpInternalPackages()
        {
            var internalPackages = new List<Package>();
            var p = internalPackages;

            p.Add(new Package { Category = AppResources.PureCategory, PackageId = 1, Title = "Pure(2012.8.15)", MainPicture = "/Pictures/2-7.jpg", CreateTime = DateTime.Now, IsInternal = true, PictureGroups = new List<PictureGroup> { } });
            p.Add(new Package { Category = AppResources.PureCategory, PackageId = 2, Title = "Pure(2012.8.25)", MainPicture = "/Pictures/1-4.png", CreateTime = DateTime.Now, IsInternal = true });
            p.Add(new Package { Category = AppResources.CharmCategory, PackageId = 3, Title = "Charm(2012.8.15)", MainPicture = "/Pictures/2-7.jpg", CreateTime = DateTime.Now, IsInternal = true });
            p.Add(new Package { Category = AppResources.CharmCategory, PackageId = 4, Title = "Charm(2012.8.25)", MainPicture = "/Pictures/1-4.png", CreateTime = DateTime.Now, IsInternal = true });

            var d = new Dictionary<string, object>();
            d.Add("InternalPackages", internalPackages);

            string packages = JsonConvert.SerializeObject(d);

            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var isoFileStream = new IsolatedStorageFileStream("InternalPackages.json", System.IO.FileMode.OpenOrCreate, file))
                {
                    using (var writer = new StreamWriter(isoFileStream))
                    {
                        writer.Write(packages);
                    }
                }
            }
        }

        /// <summary>
        /// Loads the internal packages.
        /// </summary>
        /// <returns>Package List</returns>
        public List<Package> LoadInternalPackages()
        {
            string jstr;
            using (var stream = Application.GetResourceStream(new Uri(InternalPackagesFilePath, UriKind.Relative)).Stream)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    jstr = reader.ReadToEnd();
                }
            }

            var json = JObject.Parse(jstr);
            jstr = json["InternalPackages"].ToString();

            var packages = JsonConvert.DeserializeObject<List<Package>>(jstr);
            return packages;
        }

        /// <summary>
        /// Packageses to categories.
        /// </summary>
        /// <param name="packages">The packages.</param>
        /// <returns>Category List</returns>
        public List<Category> PackagesToCategories(ICollection<Package> packages)
        {
            var categories = new Dictionary<string, ICollection<Package>>();

            foreach (var package in packages)
            {
                if (categories.ContainsKey(package.Category))
                {
                    categories[package.Category].Add(package);
                }
                else
                {
                    categories.Add(package.Category, new List<Package> { package, });
                }
            }

            List<Category> categoryList = new List<Category>();
            foreach (var pair in categories)
            {
                categoryList.Add(new Category(pair.Key, new List<Package>(pair.Value)));
            }

            return categoryList;
        }

        /// <summary>
        /// Updates the internal packages into DB.
        /// </summary>
        public void UpdateInternalPackagesIntoDB()
        {
            ServiceLocator.Get<IDBManagerService>().InsertOrUpdatePackages(this.InternalPackages);
        }
    }
}
