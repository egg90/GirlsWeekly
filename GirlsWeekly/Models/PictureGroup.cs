//-----------------------------------------------------------------------
// <copyright file="PictureGroup.cs" company="eggfly">
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
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using SimpleMvvmToolkit;

    /// <summary>
    /// PictureGroup Model
    /// </summary>
    [DataContract]
    public class PictureGroup : ModelBase<PictureGroup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PictureGroup"/> class.
        /// </summary>
        public PictureGroup()
        {
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the main picture.
        /// </summary>
        /// <value>
        /// The main picture.
        /// </value>
        [DataMember]
        public string MainPicture { get; set; }

        /// <summary>
        /// Gets or sets the picture list.
        /// </summary>
        /// <value>
        /// The picture list.
        /// </value>
        [DataMember]
        public List<string> PictureList { get; set; }
    }
}
