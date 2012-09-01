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
        /// InternalPackages Key
        /// </summary>
        public const string InternalPackagesKey = "InternalPackages";

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

            p.Add(new Package
            {
                Category = CategoryType.Pure,
                PackageId = 1,
                Title = "Pure(2012.8.15)",
                MainPicture = "/Pictures/2-7.jpg",
                CreateTime = DateTime.Now,
                IsInternal = true,
                PictureGroups = new List<PictureGroup>
                {
                    new PictureGroup
                    {
                        Title = "迷人的早晨慵懒的梦",
                        MainPicture = "http://imgs.xiuna.com/xiezhen/2012-7-6/3/1.jpg",
                        PictureList = new List<string>
                        {
                            "http://imgs.xiuna.com/xiezhen/2012-7-6/3/1.jpg", "http://imgs.xiuna.com/xiezhen/2012-7-6/3/2.jpg", "http://imgs.xiuna.com/xiezhen/2012-7-6/3/3.jpg", "http://imgs.xiuna.com/xiezhen/2012-7-6/3/4.jpg", "http://imgs.xiuna.com/xiezhen/2012-7-6/3/5.jpg", "http://imgs.xiuna.com/xiezhen/2012-7-6/3/6.jpg", "http://imgs.xiuna.com/xiezhen/2012-7-6/3/7.jpg", "http://imgs.xiuna.com/xiezhen/2012-7-6/3/8.jpg"
                        }
                    },
                    new PictureGroup
                    {
                        Title = "阳光mm写真",
                        MainPicture = "http://qcimg1.mnsfz.com/pic/qingchun/2012-8-17/1/1.jpg",
                        PictureList = new List<string>
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
                        }
                    },
                },
            });
            p.Add(new Package { Category = CategoryType.Pure, PackageId = 2, Title = "Pure(2012.8.25)", MainPicture = "/Pictures/1-4.png", CreateTime = DateTime.Now, IsInternal = true });
            p.Add(new Package { Category = CategoryType.Charm, PackageId = 3, Title = "Charm(2012.8.15)", MainPicture = "/Pictures/2-7.jpg", CreateTime = DateTime.Now, IsInternal = true });
            p.Add(new Package { Category = CategoryType.Charm, PackageId = 4, Title = "Charm(2012.8.25)", MainPicture = "/Pictures/1-4.png", CreateTime = DateTime.Now, IsInternal = true });

            var d = new Dictionary<string, object>();
            d.Add(InternalPackagesKey, internalPackages);

            string packages = JsonConvert.SerializeObject(d);
            //// format as human readable string
            packages = JObject.Parse(packages).ToString();

            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var isoFileStream = new IsolatedStorageFileStream("InternalPackages.json", System.IO.FileMode.Create, file))
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
            jstr = json[InternalPackagesKey].ToString();

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
            var categories = new Dictionary<CategoryType, ICollection<Package>>();

            foreach (var package in packages)
            {
                if (categories.ContainsKey(package.Category))
                {
                    categories[package.Category].Add(package);
                }
                else
                {
                    categories[package.Category] = new List<Package> { package, };
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
