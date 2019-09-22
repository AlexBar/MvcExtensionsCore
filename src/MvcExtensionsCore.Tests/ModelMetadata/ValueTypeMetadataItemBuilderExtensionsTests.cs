#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensionsCore.Tests
{
    using System;
    using MvcExtensionsCore;
    using Xunit;

    public class ValueTypeMetadataItemBuilderExtensionsTests
    {
        [Fact]
        public void Should_be_able_to_format_as_currency_with_decimal()
        {
            var builder = new ModelMetadataItemBuilder<decimal>(new ModelMetadataItem());

            builder.FormatAsCurrency();

            var configurator = (IModelMetadataItemConfigurator)builder;
            var item1 = new ModelMetadataItem();
            configurator.Configure(item1);
            var item = item1;
            Assert.Equal("{0:c}", item.DisplayFormat());
            Assert.Equal("{0:c}", item.EditFormat());
        }

        [Fact]
        public void Should_be_able_to_format_as_currency_with_nullable_decimal()
        {
            var builder = new ModelMetadataItemBuilder<decimal?>(new ModelMetadataItem());

            builder.FormatAsCurrency();

            var configurator = (IModelMetadataItemConfigurator)builder;
            var item1 = new ModelMetadataItem();
            configurator.Configure(item1);
            var item = item1;
            Assert.Equal("{0:c}", item.DisplayFormat());
            Assert.Equal("{0:c}", item.EditFormat());
        }

        [Fact]
        public void Should_be_able_to_format_as_date_with_date_time()
        {
            var builder = new ModelMetadataItemBuilder<DateTime>(new ModelMetadataItem());

            builder.FormatAsDateOnly();

            var configurator = (IModelMetadataItemConfigurator)builder;
            var item1 = new ModelMetadataItem();
            configurator.Configure(item1);
            var item = item1;
            Assert.Equal("{0:d}", item.DisplayFormat());
            Assert.Equal("{0:d}", item.EditFormat());
        }

        [Fact]
        public void Should_be_able_to_format_as_date_with_nullable_date_time()
        {
            var builder = new ModelMetadataItemBuilder<DateTime?>(new ModelMetadataItem());

            builder.FormatAsDateOnly();

            var configurator = (IModelMetadataItemConfigurator)builder;
            var item1 = new ModelMetadataItem();
            configurator.Configure(item1);
            var item = item1;
            Assert.Equal("{0:d}", item.DisplayFormat());
            Assert.Equal("{0:d}", item.EditFormat());
        }

        [Fact]
        public void Should_be_able_to_format_as_time_with_date_time()
        {
            var builder = new ModelMetadataItemBuilder<DateTime>(new ModelMetadataItem());

            builder.FormatAsTimeOnly();

            var configurator = (IModelMetadataItemConfigurator)builder;
            var item1 = new ModelMetadataItem();
            configurator.Configure(item1);
            var item = item1;
            Assert.Equal("{0:t}", item.DisplayFormat());
            Assert.Equal("{0:t}", item.EditFormat());
        }

        [Fact]
        public void Should_be_able_to_format_as_time_with_nullable_date_time()
        {
            var builder = new ModelMetadataItemBuilder<DateTime?>(new ModelMetadataItem());

            builder.FormatAsTimeOnly();

            var configurator = (IModelMetadataItemConfigurator)builder;
            var item1 = new ModelMetadataItem();
            configurator.Configure(item1);
            var item = item1;
            Assert.Equal("{0:t}", item.DisplayFormat());
            Assert.Equal("{0:t}", item.EditFormat());
        }
    }
}