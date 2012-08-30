//-----------------------------------------------------------------------
// <copyright file="IApplicationInfoService.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Services
{
    using System;
    using System.Linq;
    using System.Windows;
    using GirlsWeekly.Services;

    /// <summary>
    /// Network Status Enum
    /// </summary>
    public enum NetworkStatusEnum
    {
        /// <summary>
        /// no network
        /// </summary>
        Disconnected = 0,

        /// <summary>
        /// WiFi network
        /// </summary>
        WiFi,

        /// <summary>
        /// Cellular network
        /// </summary>
        Mobile,

        /// <summary>
        /// Unknown network status
        /// </summary>
        Unknown,
    }

    /// <summary>
    /// IApplicationInfoService Interface
    /// </summary>
    public interface IApplicationInfoService
    {
        /// <summary>
        /// Gets the device unique id.
        /// </summary>
        string DeviceUniqueId
        {
            get;
        }

        /// <summary>
        /// Gets the OS version.
        /// </summary>
        string OSVersion
        {
            get;
        }

        /// <summary>
        /// Gets the OS version.
        /// </summary>
        string VersionNumber
        {
            get;
        }

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        string DeviceName
        {
            get;
        }

        /// <summary>
        /// Gets the device status string.
        /// </summary>
        string DeviceStatusString
        {
            get;
        }

        /// <summary>
        /// Gets the network status.
        /// </summary>
        NetworkStatusEnum NetworkStatus
        {
            get;
        }

        /// <summary>
        /// Gets the app ID.
        /// </summary>
        string AppID
        {
            get;
        }
    }
}
