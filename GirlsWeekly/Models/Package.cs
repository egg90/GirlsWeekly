//-----------------------------------------------------------------------
// <copyright file="Package.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Linq.Mapping;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using SimpleMvvmToolkit;

    /// <summary>
    /// Package Model
    /// </summary>
    [Table]
    [DataContract]
    public class Package : ModelBase<Package>
    {
        /// <summary>
        /// picture groups
        /// </summary>
        private List<PictureGroup> pictureGroups = null;

        /// <summary>
        /// picture groups json
        /// </summary>
        private string pictureGroupsJson = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Package"/> class.
        /// </summary>
        public Package()
        {
        }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        /// <value>
        /// The package id.
        /// </value>
        [Column(CanBeNull = false)]
        [DataMember]
        public int PackageId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [Column(CanBeNull = false)]
        [DataMember]
        public CategoryType Category { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Column(CanBeNull = false)]
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the main picture.
        /// </summary>
        /// <value>
        /// The main picture.
        /// </value>
        [Column(CanBeNull = false)]
        [DataMember]
        public string MainPicture { get; set; }

        /// <summary>
        /// Gets or sets the picture groups.
        /// </summary>
        /// <value>
        /// The picture groups.
        /// </value>
        [DataMember]
        public List<PictureGroup> PictureGroups
        {
            get
            {
                return this.pictureGroups;
            }

            set
            {
                this.pictureGroups = value;
                this.pictureGroupsJson = JsonConvert.SerializeObject(value);
            }
        }
        
        /// <summary>
        /// Gets or sets a value indicating whether this instance is internal.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is internal; otherwise, <c>false</c>.
        /// </value>
        [Column]
        [DataMember]
        public bool IsInternal { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        [Column]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        private int Id { get; set; }

        /// <summary>
        /// Gets or sets the picture groups json.
        /// </summary>
        /// <value>
        /// The picture groups json.
        /// </value>
        [Column]
        private string PictureGroupsJson
        {
            get
            {
                return this.pictureGroupsJson;
            }

            set
            {
                this.pictureGroupsJson = value;
                this.pictureGroups = JsonConvert.DeserializeObject<List<PictureGroup>>(value);
            }
        }

        /// <summary>
        /// Copies from.
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyFrom(Package source)
        {
            if (this.Equals(source))
            {
                return;
            }

            //// this.Id won't be modified.
            this.Category = source.Category;
            this.CreateTime = source.CreateTime;
            this.IsInternal = source.IsInternal;
            this.MainPicture = source.MainPicture;
            this.PackageId = source.PackageId;
            this.PictureGroups = source.PictureGroups;
            this.Title = source.Title;
        }
    }
}
