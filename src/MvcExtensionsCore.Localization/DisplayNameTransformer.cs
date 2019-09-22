#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, 2012 - 2020 alexbar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

    /// <summary>
    /// Splits DisplayName attribute by cammel cases
    /// </summary>
    public static class DisplayNameTransformer
    {
        /// <summary>
        /// If true, upper case property name won't be splitted
        /// </summary>
        public static bool DisableNameProcessing
        {
            get;
            set;
        }

        /// <summary>
        /// Process display attibute
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="identity"></param>
        public static void Transform([NotNull] DisplayMetadata metadata, ModelMetadataIdentity identity)
        {
            Invariant.IsNotNull(metadata, "metadata");

            if (!DisableNameProcessing && (metadata.DisplayName == null || metadata.DisplayName() == identity.Name))
            {
                metadata.DisplayName = () => identity.Name.SplitUpperCaseToString();
            }
        }
    }
}
