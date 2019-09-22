namespace MvcExtensionsCore
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Allow to validate value with delegate based validation
    /// </summary>
    public class DelegateBasedValidator : ValidationAttribute
    {
        private readonly Func<object, object, bool> validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateBasedValidator"/> class.
        /// </summary>
        /// <param name="validator">The validator</param>
        public DelegateBasedValidator(Func<object, object, bool> validator)
        {
            this.validator = validator;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            
            if (!validator(validationContext.ObjectInstance, value))
            {
                string[] memberNames = validationContext.MemberName != null ? new[] { validationContext.MemberName } : null;
                result = new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
            }

            return result;
        }
    }
}