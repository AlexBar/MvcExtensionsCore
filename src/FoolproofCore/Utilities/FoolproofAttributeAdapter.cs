namespace FoolproofCore
{
    using Microsoft.AspNetCore.Mvc.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.Extensions.Localization;
    using System;

    public class FoolproofAttributeAdapter : AttributeAdapterBase<ModelAwareValidationAttribute>
    {
        private readonly IStringLocalizer _stringLocalizer;

        public FoolproofAttributeAdapter(
            ModelAwareValidationAttribute attribute,
            IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            var dataVal = "data-val";
            MergeAttribute(context.Attributes, dataVal, "true");
            var attrType = $"{dataVal}-{Attribute.ClientTypeName}";
            MergeAttribute(context.Attributes, attrType, GetErrorMessage(context));
            foreach (var validationParam in Attribute.ClientValidationParameters)
            {
                MergeAttribute(
                    context.Attributes,
                    $"{attrType}-{validationParam.Key}",
                    validationParam.Value.ToString());
            }
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (Attribute is ContingentValidationAttribute cva && 
                cva.DependentProperty != null && 
                cva.DependentPropertyDisplayName == null &&
                validationContext.ModelMetadata.ContainerType != null)
            {
                var m = validationContext.MetadataProvider.GetMetadataForType(validationContext.ModelMetadata.ContainerType);
                if (m != null)
                {
                    foreach (var item in m.Properties)
                    {
                        if (string.Equals(item.Name, cva.DependentProperty, StringComparison.InvariantCultureIgnoreCase))
                        {
                            cva.DependentPropertyDisplayName = item.GetDisplayName();
                            break;
                        }
                    }
                }
            }

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }
}
