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
    using GirlsWeekly.Resources;
    using SimpleMvvmToolkit;

    /// <summary>
    /// Category type
    /// </summary>
    public enum CategoryType
    {
        /// <summary>
        /// Pure Pics
        /// </summary>
        Pure,

        /// <summary>
        /// Charm Pics
        /// </summary>
        Charm,

        /// <summary>
        /// Sunny Pics
        /// </summary>
        Sunny,

        /// <summary>
        /// Cute Pics
        /// </summary>
        Cute,

        /// <summary>
        /// Plain Pics
        /// </summary>
        Plain,

        /// <summary>
        /// Campus Pics
        /// </summary>
        Campus,

        /// <summary>
        /// Autodyne Pics
        /// </summary>
        Autodyne,

        /// <summary>
        /// After90 Pics
        /// </summary>
        After90,

        /// <summary>
        /// Hot Pics
        /// </summary>
        Hot,

        /// <summary>
        /// Cool Pics
        /// </summary>
        Cool,

        /// <summary>
        /// Model Pics
        /// </summary>
        Model,

        /// <summary>
        /// Recommended Pics
        /// </summary>
        Recommended,

        /// <summary>
        /// Featured Pics
        /// </summary>
        Featured,

        /// <summary>
        /// Others Pics
        /// </summary>
        Others,
    }

    /// <summary>
    /// PictureGroup Model
    /// </summary>
    public class Category : ModelBase<Category>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="packages">The packages.</param>
        public Category(CategoryType type, List<Package> packages)
        {
            this.Type = type;
            this.Packages = packages;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public CategoryType Type { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.GetName();
            }
        }

        /// <summary>
        /// Gets or sets the picture groups.
        /// </summary>
        /// <value>
        /// The picture groups.
        /// </value>
        public List<Package> Packages { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>localized type name</returns>
        private string GetName()
        {
            switch (this.Type)
            {
                case CategoryType.After90:
                    return AppResources.CategoryAfter90;
                case CategoryType.Autodyne:
                    return AppResources.CategoryAutodyne;
                case CategoryType.Campus:
                    return AppResources.CategoryCampus;
                case CategoryType.Charm:
                    return AppResources.CategoryCharm;
                case CategoryType.Cool:
                    return AppResources.CategoryCool;
                case CategoryType.Cute:
                    return AppResources.CategoryCute;
                case CategoryType.Featured:
                    return AppResources.CategoryFeatured;
                case CategoryType.Hot:
                    return AppResources.CategoryHot;
                case CategoryType.Model:
                    return AppResources.CategoryModel;
                case CategoryType.Others:
                    return AppResources.CategoryOthers;
                case CategoryType.Plain:
                    return AppResources.CategoryPlain;
                case CategoryType.Pure:
                    return AppResources.CategoryPure;
                case CategoryType.Recommended:
                    return AppResources.CategoryRecommended;
                case CategoryType.Sunny:
                    return AppResources.CategorySunny;
                default:
                    return AppResources.CategoryOthers;
            }
        }
    }
}
