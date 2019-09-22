#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, hazzik <hazzik@gmail.com>, AlexBar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents RemoteValidationMetadata class
    /// </summary>
    public class RemoteValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the name of the area.
        /// </summary>
        public string Area
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the controller.
        /// </summary>
        public string Controller
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the action method.
        /// </summary>
        public string Action
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the additional fields that are required for validation.
        /// </summary>
        /// <returns>The additional fields that are required for validation</returns>
        public string AdditionalFields
        {
            get;
            set;
        }

        /// <summary>
        /// The route name
        /// </summary>
        public string RouteName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HTTP method used for remote validation.
        /// </summary>
        /// <returns>The HTTP method used for remote validation. The default value is "Get".</returns>
        public string HttpMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <returns> </returns>
        protected override ValidationAttribute CreateValidatorCore()
        {
            var attribute = Area == null && Controller == null
                                ? new RemoteAttribute(RouteName)
                                : new RemoteAttribute(Action, Controller, Area);

            attribute.AdditionalFields = AdditionalFields;
            attribute.HttpMethod = HttpMethod;
            return attribute;
        }
    }
}