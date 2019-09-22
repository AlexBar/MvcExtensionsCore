#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, hazzik <hazzik@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    /*    /// <summary>
        /// Extensions for <see cref="ModelMetadata"/> and <see cref="ViewDataDictionary"/> which add ability to retrive <see cref="RenderActionSetting"/> 
        /// </summary>
        public static class RenderActionSettingExtensions
        {
            /// <summary>
            /// Retrives the <see cref="RenderActionSetting"/> from the <see cref="ModelMetadata"/>
            /// </summary>
            /// <param name="modelMetadata"> The model metadata </param>
            /// <returns></returns>
            [NotNull]
            public static RenderActionSetting GetRenderActionSetting(this ModelMetadata modelMetadata)
            {
                if (!modelMetadata.AdditionalValues.ContainsKey(MvcExtensionsCoreMetadataProvider.MvcExtensionsCoreModelMetadataItemKey))
                {
                    return new RenderActionSetting();
                }

                var item = (ModelMetadataItem)modelMetadata.AdditionalValues[MvcExtensionsCoreMetadataProvider.MvcExtensionsCoreModelMetadataItemKey];

                return item.GetAdditionalSettingOrCreateNew<RenderActionSetting>();
            }

            /// <summary>
            /// Retrives the <see cref="RenderActionSetting"/> from the <see cref="ViewDataDictionary"/>
            /// </summary>
            /// <param name="viewData"> The view data dicionary </param>
            /// <returns></returns>
            [NotNull]
            public static RenderActionSetting GetRenderActionSetting([NotNull] this ViewDataDictionary viewData)
            {
                Invariant.IsNotNull(viewData, "viewData");

                return GetRenderActionSetting(viewData.ModelMetadata);
            }
        }*/
}