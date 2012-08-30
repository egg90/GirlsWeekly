//-----------------------------------------------------------------------
// <copyright file="DBContext.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Models
{
    using System;
    using System.Data.Linq;

    /// <summary>
    /// Database Context
    /// </summary>
    public class DBContext : DataContext
    {
        /// <summary>
        /// database connection string
        /// </summary>
        public const string DBConnectionString = "Data Source=isostore:/Database.sdf";

        /// <summary>
        /// Initializes a new instance of the <see cref="DBContext"/> class.
        /// </summary>
        public DBContext()
            : base(DBConnectionString)
        {
        }

        /// <summary>
        /// Gets the packages.
        /// </summary>
        public Table<Package> PackageTable
        {
            get
            {
                return this.GetTable<Package>();
            }
        }
    }
}
