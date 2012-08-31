//-----------------------------------------------------------------------
// <copyright file="IDBManagerService.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using GirlsWeekly.Models;

    /// <summary>
    /// ICommonUIService Interface
    /// </summary>
    public interface IDBManagerService
    {
        /// <summary>
        /// Gets the packages.
        /// </summary>
        /// <returns>get all packages</returns>
        IList<Package> GetPackages();

        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <param name="packageId">The package id.</param>
        /// <returns>package id</returns>
        Package GetPackage(int packageId);

        /// <summary>
        /// Inserts the or update package.
        /// </summary>
        /// <param name="package">The package.</param>
        void InsertOrUpdatePackage(Package package);

        /// <summary>
        /// Inserts the or update packages.
        /// </summary>
        /// <param name="packages">The packages.</param>
        void InsertOrUpdatePackages(ICollection<Package> packages);
    }
}
