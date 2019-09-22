namespace FoolproofCore
{
    public class RequiredIfNotEmptyAttribute : ContingentValidationAttribute
    {
        public RequiredIfNotEmptyAttribute(string dependentProperty)
            : base(dependentProperty) { }

        public override bool IsValid(object value, object dependentValue, object container)
        {
            if (!string.IsNullOrEmpty((dependentValue ?? string.Empty).ToString().Trim()))
                return !string.IsNullOrEmpty(value?.ToString().Trim());

            return true;
        }

        public override string DefaultErrorMessage => "{0} is required due to {1} not being empty.";
    }
}
