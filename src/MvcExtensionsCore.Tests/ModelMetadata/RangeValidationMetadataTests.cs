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

    public class RangeValidationMetadataTests : ValidationMetadataTestsBase
    {
        [Fact]
        public void Should_be_able_to_create_validator()
        {
            var metadata = new RangeValidationMetadata<int>();
            var validator = metadata.CreateValidator();

            Assert.NotNull(validator);
        }

        [Fact]
        public void Should_be_able_to_create_validator_for_nullable_type()
        {
            var metadata = new RangeValidationMetadata<int?>
                               {
                                   Minimum = 100,
                                   Maximum = 500
                               };
            var validator = metadata.CreateValidator();

            Assert.NotNull(validator);
        }
    }
}