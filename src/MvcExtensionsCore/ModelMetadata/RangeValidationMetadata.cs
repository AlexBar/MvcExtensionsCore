#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using JetBrains.Annotations;

    /// <summary>
    /// Represents a class to store range validation metadata.
    /// </summary>
    /// <typeparam name="TValueType">The type of the value type.</typeparam>
    public class RangeValidationMetadata<TValueType> : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public TValueType Minimum
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public TValueType Maximum
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <returns></returns>
        protected override ValidationAttribute CreateValidatorCore()
        {
            return new RangeAttribute(UnwrapNullable(typeof(TValueType)), Minimum.ToString(), Maximum.ToString());
        }

        private static Type UnwrapNullable([NotNull] Type type)
        {
            Invariant.IsNotNull(type, "type");

            return IsNullable(type)
                       ? type.GetGenericArguments().First()
                       : type;
        }

        private static bool IsNullable([NotNull] Type type)
        {
            Invariant.IsNotNull(type, "type");

            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}