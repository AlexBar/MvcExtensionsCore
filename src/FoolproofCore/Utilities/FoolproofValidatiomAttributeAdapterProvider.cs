namespace FoolproofCore
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
    using Microsoft.Extensions.Localization;

    public class FoolproofValidatiomAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider baseProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            var fpAttr = attribute as ModelAwareValidationAttribute;
            return fpAttr != null
                ? new FoolproofAttributeAdapter(fpAttr, stringLocalizer)
                : baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}