#region Copyright
// Copyright (c) 2009 - 2011, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, hazzik <hazzik@gmail.com>.
// This source is subject to the Microsoft public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using FoolproofCore;

    /// <summary>
    /// Adds validation for <see cref="RequiredIfRegExMatchAttribute"/>
    /// </summary>
    public static class RequiredIfRegExMatchModelMetadataItemBuilderExtensions
    {
        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> RequiredIfRegExMatch<TValue>(this ModelMetadataItemBuilder<TValue> self, string otherProperty, string expression) 
        {
            return RequiredIfRegExMatch(self, otherProperty, expression, null, null, null);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="expression"></param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> RequiredIfRegExMatch<TValue>(this ModelMetadataItemBuilder<TValue> self, string otherProperty, string expression, string errorMessage) 
        {
            return RequiredIfRegExMatch(self, otherProperty, expression, () => errorMessage);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="expression"></param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> RequiredIfRegExMatch<TValue>(this ModelMetadataItemBuilder<TValue> self, string otherProperty, string expression, Func<string> errorMessage) 
        {
            return RequiredIfRegExMatch(self, otherProperty, expression, errorMessage, null, null);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="expression"></param>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> RequiredIfRegExMatch<TValue>(this ModelMetadataItemBuilder<TValue> self, string otherProperty, string expression, Type errorMessageResourceType, string errorMessageResourceName) 
        {
            return RequiredIfRegExMatch(self, otherProperty, expression, null, errorMessageResourceType, errorMessageResourceName);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="expression"></param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <returns></returns>
        private static ModelMetadataItemBuilder<TValue> RequiredIfRegExMatch<TValue>(this ModelMetadataItemBuilder<TValue> self, string otherProperty, string expression, Func<string> errorMessage, Type errorMessageResourceType, string errorMessageResourceName)
        {
            self.AddAction(m =>
            {
                var validation = m.GetValidationOrCreateNew<RequiredIfRegExMatchAttributeMetadata>();

                validation.OtherProperty = otherProperty;
                validation.Expression = expression;
                validation.ErrorMessage = errorMessage;
                validation.ErrorMessageResourceType = errorMessageResourceType;
                validation.ErrorMessageResourceName = errorMessageResourceName;
            });

            return self;
        }
    }
}