#region Copyright
// Copyright (c) 2009 - 2011, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using System.ComponentModel.DataAnnotations;
    using FoolproofCore;

    /// <summary>
    /// Represents a class to store regular-expression-if validation metadata.
    /// </summary>
    public class RegularExpressionIfAttributeMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the other property.
        /// </summary>
        /// <value>The property.</value>
        public string OtherProperty
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        /// <value>The expression.</value>
        public string Expression
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>The operator.</value>
        public Operator Operator
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the dependent value.
        /// </summary>
        /// <value>The dependent value.</value>
        public object DependentValue
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
            return new RegularExpressionIfAttribute(Expression, OtherProperty, Operator, DependentValue);
        }
    }
}