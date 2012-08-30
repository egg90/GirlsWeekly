//-----------------------------------------------------------------------
// <copyright file="Category.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using SimpleMvvmToolkit;

    /// <summary>
    /// PictureGroup Model
    /// </summary>
    public class Category : ModelBase<Category>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="packages">The packages.</param>
        public Category(string title, List<Package> packages)
        {
            this.Title = title;
            this.Packages = packages;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the picture groups.
        /// </summary>
        /// <value>
        /// The picture groups.
        /// </value>
        public List<Package> Packages { get; set; }
    }
}
