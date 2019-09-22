#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, .
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

    /// <summary>
    /// Represents a base class to store validation metadata.
    /// </summary>
    public abstract class ModelValidationMetadata : IModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public Func<string> ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the name of the error message resource.
        /// </summary>
        /// <value>The name of the error message resource.</value>
        public string ErrorMessageResourceName { get; set; }

        /// <summary>
        /// Gets or sets the type of the error message resource.
        /// </summary>
        /// <value>The type of the error message resource.</value>
        public Type ErrorMessageResourceType { get; set; }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ValidationAttribute CreateValidator()
        {
            var validationAttribute = CreateValidatorCore();
            PopulateErrorMessage(validationAttribute);
            return validationAttribute;
        }

        /// <summary>
        /// Populates the error message from the given metadata.
        /// </summary>
        /// <param name="validationAttribute"></param>
        private void PopulateErrorMessage([NotNull] ValidationAttribute validationAttribute)
        {
            Invariant.IsNotNull(validationAttribute, "validationMetadata");

            string errorMessage = null;

            if (ErrorMessage != null)
            {
                errorMessage = ErrorMessage();
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                validationAttribute.ErrorMessage = errorMessage;
            }
            else
            {
                if (ErrorMessageResourceType != null)
                {
                    validationAttribute.ErrorMessageResourceType = ErrorMessageResourceType;
                }

                if (!string.IsNullOrEmpty(ErrorMessageResourceName))
                {
                    validationAttribute.ErrorMessageResourceName = ErrorMessageResourceName;
                }
            }
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        protected abstract ValidationAttribute CreateValidatorCore();
    }
}
