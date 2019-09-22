#region Copyright
// Copyright (c) 2009 - 2011, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore
{
    using FoolproofCore;

    /// <summary>
    /// Represents a class to store equal-to validation metadata.
    /// </summary>
    public class GreaterThanAttributeMetadata : IsAttributeMetadata
    {
        /// <summary>
        /// Creates an instence of Foolproof attribute
        /// </summary>
        /// <returns></returns>
        protected override IsAttribute CreateAttribute()
        {
            return new GreaterThanAttribute(OtherProperty);
        }
    }
}