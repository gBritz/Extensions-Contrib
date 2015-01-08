using EC.SystemExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EC.SystemExtensionsTest
{
    [TestClass]
    public class IsStringTest
    {
        [TestMethod]
        public void value_abc_is_string()
        {
            String value = "abc";
            value.GetType().IsString().Should().BeTrue();
        }

        [TestMethod]
        public void value_0_is_not_string()
        {
            Int32 value = 0;
            value.GetType().IsString().Should().BeFalse();
        }
    }
}