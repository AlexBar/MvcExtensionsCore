namespace FoolproofCore.Tests
{
    using System.Reflection;

    public abstract class ModelBase<T>
        where T : ContingentValidationAttribute
    {
        public T GetAttribute(string property)
        {
            return GetType().GetProperty(property).GetCustomAttribute<T>(false);
        }

        public bool IsValid(string property)
        {
            var attribute = GetAttribute(property);
            return attribute.IsValid(GetType().GetProperty(property).GetValue(this, null), this);
        }
    }
}
