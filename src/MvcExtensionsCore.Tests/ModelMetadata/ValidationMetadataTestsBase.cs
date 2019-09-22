#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore.Tests
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

    public abstract class ValidationMetadataTestsBase
    {
        protected ModelMetadataIdentity CreateMetadata()
        {
            return ModelMetadataIdentity.ForType(typeof(DummyObject));
        }

        public class DummyObject
        {
        }
    }
}