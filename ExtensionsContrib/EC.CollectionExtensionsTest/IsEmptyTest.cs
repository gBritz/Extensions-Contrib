using EC.CollectionExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EC.CollectionExtensionsTest
{
    [TestClass]
    public class IsEmptyTest
    {
        [TestMethod]
        public void Int32_array_is_empty()
        {
            var value = new Int32[0];
            value.IsEmpty().Should().BeTrue();
        }

        [TestMethod]
        public void Null_Int32_array_is_empty()
        {
            Int32[] value = null;
            value.IsEmpty().Should().BeTrue();
        }

        [TestMethod]
        public void Int32_array_with_value_is_not_empty()
        {
            var value = new Int32[1] { 1 };
            value.IsEmpty().Should().BeFalse();
        }
    }
}