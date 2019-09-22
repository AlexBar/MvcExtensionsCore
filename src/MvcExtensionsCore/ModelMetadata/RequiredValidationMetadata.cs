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
    /// Represents a class to store required validation metadata.
    /// </summary>
    public class RequiredValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <returns></returns>
        protected override ValidationAttribute CreateValidatorCore()
        {
            return new RequiredAttribute();
        }
    }
}