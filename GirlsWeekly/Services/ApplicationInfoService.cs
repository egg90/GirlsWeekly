//-----------------------------------------------------------------------
// <copyright file="ApplicationInfoService.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using Microsoft.Phone.Info;
    using Microsoft.Phone.Net.NetworkInformation;
    using Newtonsoft.Json;

    /// <summary>
    /// ApplicationInfo Service
    /// </summary>
    public class ApplicationInfoService : IApplicationInfoService
    {
        /// <summary>
        /// Gets the device unique id.
        /// </summary>
        public string DeviceUniqueId
        {
            get
            {
                object uniqueId = null;
                if (Microsoft.Phone.Info.DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out uniqueId))
                {
                    var id = uniqueId as byte[];
                    if (id != null)
                    {
                        return Convert.ToBase64String(id);
                    }
                }

                // return default user id if in emulator.
                return "322211115340864";
            }
        }

        /// <summary>
        /// Gets the OS version.
        /// </summary>
        public string OSVersion
        {
            get
            {
                return "WindowsPhone" + Environment.OSVersion.Version.ToString();
            }
        }

        /// <summary>
        /// Gets the OS version.
        /// </summary>
        public string VersionNumber
        {
            get
            {
                string name = Assembly.GetCallingAssembly().FullName;
                AssemblyName assemblyName = new AssemblyName(name);
                Version buildVersion = assemblyName.Version;
                string version = string.Format("{0}.{1}.{2}", buildVersion.Major, buildVersion.Minor, buildVersion.Build);

                return version;
            }
        }

        /// <summary>
        /// Gets the device status string.
        /// </summary>
        public string DeviceStatusString
        {
            get
            {
                Dictionary<string, object> deviceStatus = new Dictionary<string, object>();
                deviceStatus.Add("ApplicationCurrentMemoryUsage", DeviceStatus.ApplicationCurrentMemoryUsage);
                deviceStatus.Add("ApplicationMemoryUsageLimit", DeviceStatus.ApplicationMemoryUsageLimit);
                deviceStatus.Add("ApplicationPeakMemoryUsage", DeviceStatus.ApplicationPeakMemoryUsage);
                deviceStatus.Add("DeviceFirmwareVersion", DeviceStatus.DeviceFirmwareVersion);
                deviceStatus.Add("DeviceHardwareVersion", DeviceStatus.DeviceHardwareVersion);
                deviceStatus.Add("DeviceManufacturer", DeviceStatus.DeviceManufacturer);
                deviceStatus.Add("DeviceName", DeviceStatus.DeviceName);
                deviceStatus.Add("DeviceTotalMemory", DeviceStatus.DeviceTotalMemory);
                deviceStatus.Add("IsKeyboardDeployed", DeviceStatus.IsKeyboardDeployed);
                deviceStatus.Add("IsKeyboardPresent", DeviceStatus.IsKeyboardPresent);
                deviceStatus.Add("PowerSource", DeviceStatus.PowerSource.ToString("F"));
                return JsonConvert.SerializeObject(deviceStatus);
            }
        }

        /// <summary>
        /// Gets the network status.
        /// </summary>
        public NetworkStatusEnum NetworkStatus
        {
            get
            {
                if (!DeviceNetworkInformation.IsNetworkAvailable)
                {
                    return NetworkStatusEnum.Disconnected;
                }
                else if (DeviceNetworkInformation.IsWiFiEnabled)
                {
                    return NetworkStatusEnum.WiFi;
                }
                else if (DeviceNetworkInformation.IsCellularDataEnabled)
                {
                    return NetworkStatusEnum.Mobile;
                }
                else
                {
                    return NetworkStatusEnum.Unknown;
                }
            }
        }

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        public string DeviceName
        {
            get
            {
                object deviceName = null;
                if (Microsoft.Phone.Info.DeviceExtendedProperties.TryGetValue("DeviceName", out deviceName))
                {
                    if (deviceName != null)
                    {
                        return deviceName.ToString();
                    }
                }

                // return default user id if in emulator.
                return "Emulator";
            }
        }

        /// <summary>
        /// Gets the app ID.
        /// </summary>
        public string AppID
        {
            get
            {
                return "cde80412-d5e7-4bd5-9231-e214c361820c";
            }
        }
    }
}