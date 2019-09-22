#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

    /// <summary>
    /// Defines a base class that is used to configure metadata of a model fluently.
    /// </summary>
    public abstract class ModelMetadataConfiguration<TModel> : IModelMetadataConfiguration where TModel : class
    {
        #region IModelMetadataConfiguration Members
        /// <summary>
        /// Gets the type of the model.
        /// </summary>
        /// <value>The type of the model.</value>
        public Type ModelType { get; } = typeof(TModel);

        /// <summary>
        /// Gets the configurations.
        /// </summary>
        /// <value>The configurations.</value>
        public virtual IDictionary<string, IModelMetadataItemConfigurator> Configurations { get; } = new Dictionary<string, IModelMetadataItemConfigurator>(StringComparer.OrdinalIgnoreCase);
        #endregion

        /// <summary>
        /// Configures the specified value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        [NotNull]
        protected ModelMetadataItemBuilder<TValue> Configure<TValue>([NotNull] Expression<Func<TModel, TValue>> expression)
        {
            Invariant.IsNotNull(expression, nameof(expression));
            string property = ExpressionHelper.GetExpressionText(expression);
            Invariant.IsNotNull(property, nameof(property));

            var builder = new ModelMetadataItemBuilder<TValue>(new ModelMetadataItem());
            Configurations[property] = builder;
            return builder;
        }

        /// <summary>
        /// Configures the specified value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="property">The expression.</param>
        /// <returns></returns>
        [NotNull]
        protected ModelMetadataItemBuilder<TValue> Configure<TValue>([NotNull] string property)
        {
            Invariant.IsNotNull(property, "property");

            return Create<TValue>(property);
        }

        /// <summary>
        /// Configures the specified value.
        /// </summary>
        /// <param name="property">The expression.</param>
        /// <returns></returns>
        [NotNull]
        protected ModelMetadataItemBuilder<object> Configure([NotNull] string property)
        {
            Invariant.IsNotNull(property, "property");
            var item = new ModelMetadataItem();

            var builder = new ModelMetadataItemBuilder<object>(item);
            Configurations[property] = builder;
            return builder;
        }

        private ModelMetadataItemBuilder<TValue> Create<TValue>(string property)
        {
            var builder = new ModelMetadataItemBuilder<TValue>(new ModelMetadataItem());

            Configurations[property] = builder;

            return builder;
        }
    }
}