namespace FoolproofCore.Tests
{
    using FoolproofCore;

    using Xunit;

    public class EqualToAttributeTest
    {
        [Fact]
        public void IsNotValid()
        {
            var model = new Model { Value1 = "hello", Value2 = "goodbye" };
            Assert.False(model.IsValid("Value2"));
        }

        [Fact]
        public void IsNotValidWithValue1Null()
        {
            var model = new Model { Value2 = "hello" };
            Assert.False(model.IsValid("Value2"));
        }

        [Fact]
        public void IsNotValidWithValue2Null()
        {
            var model = new Model { Value1 = "hello" };
            Assert.False(model.IsValid("Value2"));
        }

        [Fact]
        public void IsValid()
        {
            var model = new Model { Value1 = "hello", Value2 = "hello" };
            Assert.True(model.IsValid("Value2"));
        }

        [Fact]
        public void IsValidWithNulls()
        {
            var model = new Model();
            Assert.True(model.IsValid("Value2"));
        }

        [Fact]
        public void IsValidWithValue1Null()
        {
            var model = new ModelWithPassOnNull { Value2 = "hello" };
            Assert.True(model.IsValid("Value2"));
        }

        [Fact]
        public void IsValidWithValue2Null()
        {
            var model = new ModelWithPassOnNull { Value1 = "hello" };
            Assert.True(model.IsValid("Value2"));
        }

        private class Model : ModelBase<EqualToAttribute>
        {
            public string Value1 { get; set; }

            [EqualTo("Value1")]
            public string Value2 { get; set; }
        }

        private class ModelWithPassOnNull : ModelBase<EqualToAttribute>
        {
            public string Value1 { get; set; }

            [EqualTo("Value1", PassOnNull = true)]
            public string Value2 { get; set; }
        }
    }
}