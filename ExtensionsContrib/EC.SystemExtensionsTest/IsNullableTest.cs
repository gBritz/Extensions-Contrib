using EC.SystemExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EC.SystemExtensionsTest
{
    [TestClass]
    public class IsNullableTest
    {
        [TestMethod]
        public void Byte_type_is_nullable()
        {
            var type = typeof(Nullable<Byte>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Int16_type_is_nullable()
        {
            var type = typeof(Nullable<Int16>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void UInt16_type_is_nullable()
        {
            var type = typeof(Nullable<UInt16>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Int32_type_is_nullable()
        {
            var type = typeof(Nullable<Int32>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void UInt32_type_is_nullable()
        {
            var type = typeof(Nullable<UInt32>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Int64_type_is_nullable()
        {
            var type = typeof(Nullable<Int64>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void UInt64_type_is_nullable()
        {
            var type = typeof(Nullable<UInt64>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Single_type_is_nullable()
        {
            var type = typeof(Nullable<Single>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Double_type_is_nullable()
        {
            var type = typeof(Nullable<Double>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Decimal_type_is_nullable()
        {
            var type = typeof(Nullable<Decimal>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Char_type_is_nullable()
        {
            var type = typeof(Nullable<Char>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void Boolean_type_is_nullable()
        {
            var type = typeof(Nullable<Boolean>);
            type.IsNullable().Should().BeTrue();
        }

        [TestMethod]
        public void DateTime_type_is_nullable()
        {
            var type = typeof(Nullable<DateTime>);
            type.IsNullable().Should().BeTrue();
        }
    }
}