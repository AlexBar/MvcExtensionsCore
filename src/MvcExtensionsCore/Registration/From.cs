#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, 2012 - 2020 alexbar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using JetBrains.Annotations;

    /// <summary>
    /// Helps with configuration types search
    /// </summary>
    public static class From
    {
        /// <summary>
        /// Register configuration types from the assembly containing type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Assembly> AssemblyContainingType([NotNull] Type type)
        {
            Invariant.IsNotNull(type, "type");
            yield return type.Assembly;
        }

        /// <summary>
        /// Register configuration types from the assembly containing type
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public static IEnumerable<Assembly> AssemblyContainingType<T>()
        {
            return AssemblyContainingType(typeof(T));
        }

        /// <summary>
        /// Register configuration types from current assembly
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public static IEnumerable<Assembly> ThisAssembly()
        {
            return new[] { Assembly.GetCallingAssembly() };
        }
    }
}
