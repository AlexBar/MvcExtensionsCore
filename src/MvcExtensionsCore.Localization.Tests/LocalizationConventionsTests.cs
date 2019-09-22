#region Copyright
// Copyright (c) 2009 - 2012, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, 2011 - 2012 hazzik <hazzik@gmail.com>, 2012 - 2020 alexbar <abarbashin@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore.Tests
{
    using System;
    using Localization.Tests.Resources;
    using MvcExtensionsCore;
    using Xunit;

    public class LocalizationConventionsTests : IDisposable
    {
        public LocalizationConventionsTests()
        {
            LocalizationConventions.DefaultResourceType = null;
            LocalizationConventions.RequireConventionAttribute = false;
        }

       
        [Fact]
        public void GetDefaultResourceType_should_return_defaultResourceType_if_convensions_is_acivated()
        {
            // arrange
            LocalizationConventions.DefaultResourceType = typeof(TestResource);
            Type containerType = typeof(DummyContainer);

            // act
            var type = LocalizationConventions.GetDefaultResourceType(containerType);

            // assert
            Assert.NotNull(type);
            Assert.Equal(type, typeof(TestResource));
        }

        [Fact]
        public void GetDefaultResourceType_should_return_type_from_attributeMetadataConventions()
        {
            // arrange
            LocalizationConventions.DefaultResourceType = typeof(TestResource);
            Type containerType = typeof(DummyContainerWithAttributeAndResourceType);

            // act
            var type = LocalizationConventions.GetDefaultResourceType(containerType);

            // assert
            Assert.NotNull(type);
            Assert.Equal(type, typeof(TestResource2));
        }

        [Fact]
        public void GetDefaultResourceType_should_return_defaultResourceType_if_metadataConventionsAttribute_has_no_type()
        {
            // arrange
            LocalizationConventions.DefaultResourceType = typeof(TestResource);
            Type containerType = typeof(DummyContainerWithEmptyAttribute);

            // act
            var type = LocalizationConventions.GetDefaultResourceType(containerType);

            // assert
            Assert.NotNull(type);
            Assert.Equal(type, typeof(TestResource));
        }

        [Fact]
        public void GetDefaultResourceType_should_return_null_if_defaultResourceType_and_metadataConventionsAttribute_has_no_type()
        {
            // arrange
            LocalizationConventions.DefaultResourceType = null;
            Type containerType = typeof(DummyContainerWithEmptyAttribute);

            // act
            var type = LocalizationConventions.GetDefaultResourceType(containerType);

            // assert
            Assert.Null(type);
        }

        [Fact]
        public void GetDefaultResourceType_should_return_null_if_metadataConventionsAttribute_has_no_type_and_requireConventionAttribute_is_true()
        {
            // arrange
            LocalizationConventions.DefaultResourceType = null;
            LocalizationConventions.RequireConventionAttribute = true;
            Type containerType = typeof(DummyContainerWithEmptyAttribute);

            // act
            var type = LocalizationConventions.GetDefaultResourceType(containerType);

            // assert
            Assert.Null(type);
        }


        public void Dispose()
        {
            LocalizationConventions.DefaultResourceType = null;
            LocalizationConventions.RequireConventionAttribute = false;
        }

        public class DummyContainer
        {
             
        }

        [MetadataConventions]
        public class DummyContainerWithEmptyAttribute
        {

        }

        [MetadataConventions(typeof(TestResource2))]
        public class DummyContainerWithAttributeAndResourceType
        {

        }
        
    }
}