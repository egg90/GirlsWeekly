//-----------------------------------------------------------------------
// <copyright file="DBManagerService.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Linq;
    using System.Linq;
    using System.Windows;
    using GirlsWeekly.Models;

    /// <summary>
    /// DBManager Service
    /// </summary>
    public class DBManagerService : IDBManagerService
    {
        /// <summary>
        /// data conext lock
        /// </summary>
        private object dataContextLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="DBManagerService"/> class.
        /// </summary>
        public DBManagerService()
        {
        }

        /// <summary>
        /// Gets the packages.
        /// </summary>
        /// <returns>
        /// get all packages
        /// </returns>
        public IList<Package> GetPackages()
        {
            lock (this.dataContextLock)
            {
                this.CreateDBIfNotExist();
                using (var dataContext = new DBContext())
                {
                    return dataContext.PackageTable.OrderByDescending(m => m.PackageId).ToList();
                }
            }
        }

        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <param name="packageId">The package id.</param>
        /// <returns>
        /// package id
        /// </returns>
        public Package GetPackage(int packageId)
        {
            lock (this.dataContextLock)
            {
                this.CreateDBIfNotExist();
                using (var dataContext = new DBContext())
                {
                    var queryPackage = from item in dataContext.PackageTable where item.PackageId == packageId select item;
                    if (queryPackage.Any())
                    {
                        return queryPackage.First();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Inserts the or update package.
        /// </summary>
        /// <param name="package">The package.</param>
        public void InsertOrUpdatePackage(Package package)
        {
            lock (this.dataContextLock)
            {
                this.CreateDBIfNotExist();
                using (var dataContext = new DBContext())
                {
                    var queryPackage = from item in dataContext.PackageTable where item.PackageId == package.PackageId select item;
                    if (queryPackage.Any())
                    {
                        Package databasePackage = queryPackage.First();
                        databasePackage.CopyFrom(package);
                    }
                    else
                    {
                        dataContext.PackageTable.InsertOnSubmit(package);
                    }

                    dataContext.SubmitChanges();
                }
            }
        }

        /// <summary>
        /// Inserts the or update packages.
        /// </summary>
        /// <param name="packages">The packages.</param>
        public void InsertOrUpdatePackages(ICollection<Package> packages)
        {
            foreach (Package package in packages)
            {
                this.InsertOrUpdatePackage(package);
            }
        }

        /// <summary>
        /// Creates the DB if not exist.
        /// </summary>
        private void CreateDBIfNotExist()
        {
            lock (this.dataContextLock)
            {
                using (var dataContext = new DBContext())
                {
                    if (!dataContext.DatabaseExists())
                    {
                        dataContext.CreateDatabase();
                    }
                }
            }
        }
    }
}
