#region Copyright
// Copyright (c) 2009 - 2011, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, hazzik <hazzik@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System.ComponentModel.DataAnnotations;
    using FoolproofCore;

    /// <summary>
    /// Represents a class to store required-if-not-regex-match validation metadata.
    /// </summary>
    public class RequiredIfNotRegExMatchAttributeMetadata : ModelValidationMetadata
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
        /// Gets or sets the expression.
        /// </summary>
        /// <value>The expression.</value>
        public string Expression
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        protected override ValidationAttribute CreateValidatorCore()
        {
            return new RequiredIfNotRegExMatchAttribute(OtherProperty, Expression);
        }
    }
}