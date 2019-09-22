namespace MvcExtensionsCore
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a class to store custom validation metadata.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomValidationMetadata<T> : IModelValidationMetadata
        where T : ValidationAttribute
    {
        /// <summary>
        /// The configuration
        /// </summary>
        public Action<T> Configure
        {
            get;
            set;
        }

        /// <summary>
        /// The factory
        /// </summary>
        public Func<T> Factory
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        public ValidationAttribute CreateValidator()
        {
            var validator = Factory();
            Configure(validator);
            return validator;
        }
    }
}