namespace FoolproofCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ContingentValidationAttribute : ModelAwareValidationAttribute
    {
        protected ContingentValidationAttribute(string dependentProperty)
        {
            DependentProperty = dependentProperty;
        }

        public override string DefaultErrorMessage => "{0} is invalid due to {1}.";

        public string DependentProperty { get; }

        public string DependentPropertyDisplayName { get; set; }

        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(ErrorMessageResourceName) && string.IsNullOrEmpty(ErrorMessage))
            {
                ErrorMessage = DefaultErrorMessage;
            }

            return string.Format(ErrorMessageString, name, DependentPropertyDisplayName ?? DependentProperty);
        }

        public override bool IsValid(object value, object container)
        {
            return IsValid(value, GetDependentPropertyValue(container), container);
        }

        public abstract bool IsValid(object value, object dependentValue, object container);

        protected override IEnumerable<KeyValuePair<string, object>> GetClientValidationParameters()
        {
            return base.GetClientValidationParameters()
                .Union(new[] { new KeyValuePair<string, object>("DependentProperty", DependentProperty) });
        }

        private object GetDependentPropertyValue(object container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var currentType = container.GetType();
            var value = container;

            foreach (string propertyName in DependentProperty.Split('.'))
            {
                var property = currentType.GetProperty(propertyName);
                if (property != null)
                {
                    value = property.GetValue(value, null);
                    currentType = property.PropertyType;
                }
            }

            return value;
        }
    }
}
