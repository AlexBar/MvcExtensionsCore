#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, 2012 - 2020 alexbar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion
namespace MvcExtensionsCore.Tests
{
    using System;
    using MvcExtensionsCore;
    using Xunit;

    public class NoConventionsResourceSetTests : IDisposable
    {
        public NoConventionsResourceSetTests()
        {
            LocalizationConventions.DefaultResourceType = null;
        }

        [Fact]
        public void Should_not_throw_if_сonventions_is_enabled_but_resurce_is_not_set()
        {
            var metadata = new RequiredValidationMetadata();
            var validator = metadata.CreateValidator();

            Assert.NotNull(validator);
        }

        public void Dispose()
        {
            LocalizationConventions.DefaultResourceType = null;
        }
    }
}