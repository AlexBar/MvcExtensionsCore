#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a class to store string length validation metadata.
    /// </summary>
    public class StringLengthValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthValidationMetadata"/> class
        /// </summary>
        public StringLengthValidationMetadata()
        {
            Maximum = int.MaxValue;
            Minimum = 0;
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <returns></returns>
        protected override ValidationAttribute CreateValidatorCore()
        {
            return new StringLengthAttribute(Maximum)
            {
                MinimumLength = Minimum
            };
        }
    }
}