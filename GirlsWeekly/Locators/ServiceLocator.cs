//-----------------------------------------------------------------------
// <copyright file="ServiceLocator.cs" company="eggfly">
//     Copyright (c) eggfly. All rights reserved.
// </copyright>
// <author>eggfly</author>
//-----------------------------------------------------------------------

namespace GirlsWeekly.Locators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using GirlsWeekly.Services;
    using SimpleMvvmToolkit;

    /// <summary>
    /// service locator
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary>
        /// services dict
        /// </summary>
        private static Dictionary<Type, object> services = new Dictionary<Type, object>();

        /// <summary>
        /// service lock
        /// </summary>
        private static object serviceLock = new object();

        /// <summary>
        /// Initializes static members of the <see cref="ServiceLocator"/> class.
        /// </summary>
        static ServiceLocator()
        {
            RegisterSingleton<ICommonUIService, CommonUIService>();
            RegisterSingleton<IApplicationInfoService, ApplicationInfoService>();
            RegisterSingleton<IDBManagerService, DBManagerService>();
            RegisterSingleton<INavigator, Navigator>();
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <returns>Service Interface Instance</returns>
        public static TInterface Get<TInterface>()
        {
            lock (serviceLock)
            {
                return (TInterface)services[typeof(TInterface)];
            }
        }

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplemention">The type of the implemention.</typeparam>
        private static void RegisterSingleton<TInterface, TImplemention>() where TImplemention : TInterface
        {
            if (!services.ContainsKey(typeof(TInterface)))
            {
                services[typeof(TInterface)] = CreateInstance(typeof(TImplemention));
            }
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>the instance object</returns>
        private static object CreateInstance(Type type)
        {
            if (services.ContainsKey(type))
            {
                return services[type];
            }

            ConstructorInfo ctor = type.GetConstructors().First();

            var parameters =
                from parameter in ctor.GetParameters()
                select CreateInstance(parameter.ParameterType);

            return Activator.CreateInstance(type, parameters.ToArray());
        }
    }
}
