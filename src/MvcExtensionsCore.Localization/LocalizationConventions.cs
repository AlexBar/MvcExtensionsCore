#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, 2012 - 2020 alexbar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;

    /// <summary>
    /// Holds settings that are use to apply convensions for metadata string messages.
    /// </summary>
    public static class LocalizationConventions
    {
        /// <summary>
        /// Default resource type to use when appling convensions
        /// </summary>
        public static Type DefaultResourceType { get; set; }

        /// <summary>
        /// If true, will require attribute per type or containing assembly. 
        /// </summary>
        public static bool RequireConventionAttribute { get; set; }
        
        /// <summary>
        /// Get default resource type
        /// </summary>
        internal static Type GetDefaultResourceType(Type containerType)
        {
            Type resourceType = null;
            var attribute = containerType.GetAttributeOnTypeOrAssembly<MetadataConventionsAttribute>();
            if (attribute == null && RequireConventionAttribute)
            {
                return null;
            }

            if (attribute != null && attribute.ResourceType != null)
            {
                resourceType = attribute.ResourceType;
            }

            return resourceType ?? DefaultResourceType;
        }
    }
}
