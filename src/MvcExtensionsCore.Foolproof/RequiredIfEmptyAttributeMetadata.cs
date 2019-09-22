#region Copyright
// Copyright (c) 2009 - 2017, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, hazzik <hazzik@gmail.com>,  AlexBar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System.ComponentModel.DataAnnotations;
    using FoolproofCore;

    /// <summary>
    /// Represents a class to store required-if-empty validation metadata.
    /// </summary>
    public class RequiredIfEmptyAttributeMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the other property.
        /// </summary>
        /// <value>The property.</value>
        public string OtherProperty
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        protected override ValidationAttribute CreateValidatorCore()
        {
            return new RequiredIfEmptyAttribute(OtherProperty);
        }
    }
}