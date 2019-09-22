using System;
using System.Reflection;

using MvcExtensionsCore;

namespace MvcExtensionsCore.Sample1.Infrastructure
{
    public class StringPropertyMetadataConvention : DefaultPropertyModelMetadataConvention<string>
    {
        private const string Pattern = @"^[A-Za-z0-9,_.\s+\-=()&?/\\^:;$#%@'""]*$";

        public override bool IsApplicable(PropertyInfo propertyInfo)
        {
            var attributeType = typeof(LimitAllowedSymbolsAttribute);
            return propertyInfo.PropertyType == typeof(string) &&
                   (propertyInfo.IsDefined(attributeType, true) ||
                    propertyInfo.ReflectedType.IsDefined(attributeType, true));
        }

        protected override void Apply(ModelMetadataItemBuilder<string> builder)
        {
            builder.Expression(Pattern, "Not allowed symbols are entered.");
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class LimitAllowedSymbolsAttribute : Attribute
    {
    }
}