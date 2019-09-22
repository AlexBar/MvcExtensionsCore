#region Copyright
// Copyright (c) 2009 - 2013, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2013 hazzik <hazzik@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// Define a class that is used to store the render action element setting.
    /// </summary>
    public class RenderActionSetting : IModelMetadataAdditionalSetting
    {
        /// <summary>
        /// Get or sets the delegate which is used to invoke child action.
        /// </summary>
        public Func<IHtmlHelper, IHtmlContent> Action
        {
            get;
            set;
        }

        public Type ViewComponentType
        {
            get;
            set;
        }

        public string ViewComponentName
        {
            get;
            set;
        }

        public IDictionary<string, object> ViewComponentParams
        {
            get;
            set;
        } = new Dictionary<string, object>();
    }
}