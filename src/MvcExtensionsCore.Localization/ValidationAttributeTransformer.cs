﻿#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, 2012 - 2020 alexbar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using JetBrains.Annotations;

    /// <summary>
    /// Transforms error message for <see cref="ValidationAttribute"/>. Applies conventions.
    /// </summary>
    public static class ValidationAttributeTransformer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="containerType"> </param>
        /// <param name="propertyName"> </param>
        /// <param name="defaultResource"> </param>
        public static void Transform(
            [NotNull] ValidationAttribute attr,
            Type containerType,
            string propertyName,
            Type defaultResource)
        {
            if (!string.IsNullOrEmpty(attr.ErrorMessage) ||
                attr.ErrorMessageResourceType != null && !string.IsNullOrEmpty(attr.ErrorMessageResourceName))
            {
                return;
            }

            var resourceType = attr.ErrorMessageResourceType ?? defaultResource;

            // do not apply convensions if no resource type found
            if (resourceType == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(attr.ErrorMessageResourceName) && ResourceUtil.HasResourceValue(resourceType, attr.ErrorMessageResourceName))
            {
                attr.ErrorMessageResourceType = resourceType;
            }
            else
            {
                var attributeName = attr.GetType().Name.Replace("Attribute", String.Empty);
                string resourceKey = null;
                var resouceFound = false;
                if (containerType != null && propertyName != null)
                {
                    resourceKey = string.Format("{0}_{1}", ResourceUtil.GetResourceKey(containerType, propertyName), attributeName);
                    resouceFound = ResourceUtil.HasResourceValue(resourceType, resourceKey);
                }

                if (!resouceFound)
                {
                    resourceKey = string.Format("Validation_{0}", attributeName);
                    resouceFound = ResourceUtil.HasResourceValue(resourceType, resourceKey);
                }

                if (resouceFound)
                {
                    attr.ErrorMessageResourceType = resourceType;
                    attr.ErrorMessageResourceName = resourceKey;
                }
            }
        }
        
    }
}
