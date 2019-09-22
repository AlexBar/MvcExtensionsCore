namespace MvcExtensionsCore
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

    public class MvcExtensionsCoreMetadataProvider : IBindingMetadataProvider,
        IDisplayMetadataProvider,
        IValidationMetadataProvider
    {
        //TODO: move outside
        internal const string MvcExtensionsCoreModelMetadataItemKey = "MvcExtensionsCore.ModelMetadataItem";
        private readonly IModelMetadataRegistry registry;

        public MvcExtensionsCoreMetadataProvider(IModelMetadataRegistry registry)
        {
            this.registry = registry;
        }

        public void CreateBindingMetadata(BindingMetadataProviderContext context)
        {
            if (context.Key.ContainerType == null || context.Key.MetadataKind != ModelMetadataKind.Property)
                return;

            var m = registry.GetModelPropertyMetadata(context.Key.ContainerType, context.Key.Name);
            if (m?.IsReadOnly != null) context.BindingMetadata.IsReadOnly = m.IsReadOnly;
        }

        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.Key.ContainerType == null || context.Key.MetadataKind != ModelMetadataKind.Property)
                return;

            var m = registry.GetModelPropertyMetadata(context.Key.ContainerType, context.Key.Name);
            if (m != null) Copy(m, context.DisplayMetadata);
        }

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            if (context.Key.ContainerType == null || context.Key.MetadataKind != ModelMetadataKind.Property)
                return;

            var m = registry.GetModelPropertyMetadata(context.Key.ContainerType, context.Key.Name);
            if (m == null)
                return;

            foreach (var attribute in m.Validations.Select(x => x.CreateValidator()))
            {
                context.ValidationMetadata.ValidatorMetadata.Add(attribute);
            }

            context.ValidationMetadata.IsRequired = m.IsRequired;
        }

        private static void Copy(ModelMetadataItem metadataItem, DisplayMetadata metadata)
        {
            metadata.ShowForDisplay = metadataItem.ShowForDisplay;

            if (metadataItem.DisplayName != null)
            {
                metadata.DisplayName = metadataItem.DisplayName;
            }

            if (metadataItem.ShortDisplayName != null)
            {
                metadata.SimpleDisplayProperty = metadataItem.ShortDisplayName();
            }

            if (!string.IsNullOrEmpty(metadataItem.TemplateName))
            {
                metadata.TemplateHint = metadataItem.TemplateName;
            }

            if (metadataItem.Description != null)
            {
                metadata.Description = metadataItem.Description;
            }

            if (metadataItem.NullDisplayText != null)
            {
                metadata.NullDisplayText = metadataItem.NullDisplayText();
            }

            if (metadataItem.Watermark != null)
            {
                metadata.Placeholder = metadataItem.Watermark;
            }

            if (metadataItem.HideSurroundingHtml.HasValue)
            {
                metadata.HideSurroundingHtml = metadataItem.HideSurroundingHtml.Value;
            }

            if (metadataItem.HtmlEncode.HasValue)
            {
                metadata.HtmlEncode = metadataItem.HtmlEncode.Value;
            }
            
            /*if (metadataItem.RequestValidationEnabled.HasValue)
            {
                metadata.RequestValidationEnabled = metadataItem.RequestValidationEnabled.Value;
               // metadata.HtmlEncode = metadataItem.RequestValidationEnabled.Value;
            }*/

            /*if (metadataItem.IsReadOnly.HasValue)
            {
                metadata.IsReadOnly = metadataItem.IsReadOnly.Value;
            }*/

            /*if (metadataItem.IsRequired.HasValue)
            {
                metadata.IsRequired = metadataItem.IsRequired.Value;
            }*/

            if (metadataItem.ShowForEdit.HasValue)
            {
                metadata.ShowForEdit = metadataItem.ShowForEdit.Value;
            }
            else if (metadataItem.IsReadOnly != null)
            {
                metadata.ShowForEdit = !metadataItem.IsReadOnly.Value;
            }

            if (metadataItem.Order.HasValue)
            {
                metadata.Order = metadataItem.Order.Value;
            }

            if (metadataItem.DisplayFormat != null)
            {
                metadata.DisplayFormatString = metadataItem.DisplayFormat();
            }

            if (metadataItem.ApplyFormatInEditMode && metadata.ShowForEdit && metadataItem.EditFormat != null)
            {
                metadata.EditFormatString = metadataItem.EditFormat();
            }

            if (metadataItem.ConvertEmptyStringToNull.HasValue)
            {
                metadata.ConvertEmptyStringToNull = metadataItem.ConvertEmptyStringToNull.Value;
            }
            
            metadata.AdditionalValues.Add(MvcExtensionsCoreModelMetadataItemKey, metadataItem);
        }
    }
}