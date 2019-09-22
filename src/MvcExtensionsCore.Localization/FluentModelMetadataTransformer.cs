#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, 2012 - 2020 alexbar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

    /// <summary>
    /// Transforms <see cref="DisplayMetadata"/> to apply convensions
    /// </summary>
    public static class FluentModelMetadataTransformer
    {
        private const string DescriptionSuffix = "_Description";
        private const string ShortDisplayNameSuffix = "_SimpleName";
        private const string PlaceholderSuffix = "_Placeholder";

        /// <summary>
        /// Tranform <see cref="DisplayMetadata"/>
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="identity"></param>
        public static void Transform([NotNull] DisplayMetadata metadata, ModelMetadataIdentity identity)
        {
            Invariant.IsNotNull(metadata, "metadata");
            Invariant.IsNotNull(identity, "identity");

            if (identity.ContainerType == null || string.IsNullOrEmpty(identity.Name))
            {
                return;
            }
            
            var containerType = identity.ContainerType;
            // fluent configuration does not have ResourceType, so get it from type
            var resourceType = LocalizationConventions.GetDefaultResourceType(containerType);
            var propertyName = identity.Name;
            if (resourceType != null && !string.IsNullOrEmpty(propertyName))
            {
                var key = ResourceUtil.GetResourceKey(containerType, propertyName);
                if (metadata.DisplayName == null)
                {
                    metadata.DisplayName = RetrieveValue(resourceType, key, propertyName);
                }

                if (metadata.SimpleDisplayProperty == null)
                {
                    metadata.SimpleDisplayProperty = RetrieveValue(resourceType, key + ShortDisplayNameSuffix, propertyName + ShortDisplayNameSuffix)();
                }

                if (metadata.Placeholder == null)
                {
                    metadata.Placeholder = RetrieveValue(resourceType, key + PlaceholderSuffix, propertyName + PlaceholderSuffix);
                }

                if (metadata.Description == null)
                {
                    metadata.Description = RetrieveValue(resourceType, key + DescriptionSuffix, propertyName + DescriptionSuffix);
                }
            }
        }

        private static Func<string> RetrieveValue([NotNull] Type resourceType, string key, string propertyName)
        {
            return () => resourceType.GetResourceValueByPropertyLookup(key) ?? resourceType.GetResourceValueByPropertyLookup(propertyName);
        }
    }
}
