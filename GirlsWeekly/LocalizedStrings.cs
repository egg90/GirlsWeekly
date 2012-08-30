//-----------------------------------------------------------------------
// <copyright file="LocalizedStrings.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly
{
    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using GirlsWeekly.Resources;

    /// <summary>
    /// LocalizedStrings class
    /// </summary>
    public class LocalizedStrings
    {
        /// <summary>
        /// Localized resources
        /// </summary>
        private static AppResources localizedResources = new AppResources();

        /// <summary>
        /// Gets the localized resources.
        /// </summary>
        public AppResources LocalizedResources
        {
            get
            {
                return localizedResources;
            }
        }
    }
}
