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
    /// Represents an interface to store validation metadata.
    /// </summary>
    public interface IModelValidationMetadata
    {
        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <returns></returns>
        ValidationAttribute CreateValidator();
    }
}