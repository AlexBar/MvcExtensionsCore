namespace MvcExtensionsCore
{
    using System.ComponentModel.DataAnnotations;
    using FoolproofCore;

    /// <summary>
    /// Represents a class to store is validation metadata.
    /// </summary>
    public abstract class IsAttributeMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets whether validation shouldpass on null property value.
        /// </summary>
        /// <value>The property.</value>
        public bool PassOnNull
        {
            get;
            set;
        }

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
            var attribute = CreateAttribute();
            attribute.PassOnNull = PassOnNull;
            return attribute;
        }

        /// <summary>
        /// Creates an instence of Foolproof attribute
        /// </summary>
        /// <returns></returns>
        protected abstract IsAttribute CreateAttribute();
    }
}