#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore.Tests
{
    using MvcExtensionsCore;
    using Xunit;

    public class RegularExpressionValidationMetadataTests : ValidationMetadataTestsBase
    {
        [Fact]
        public void Should_be_able_to_create_validator()
        {
            var metadata = new RegularExpressionValidationMetadata { Pattern = "^[a-zA-Z0-9]+$" };
            var validator = metadata.CreateValidator();

            Assert.NotNull(validator);
        }
    }
}