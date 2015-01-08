using EC.SystemExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EC.SystemExtensionsTest
{
    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void object_value_1_convert_to_SByte()
        {
            Object value = 1;
            var converted = value.Convert<SByte>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_Byte()
        {
            Object value = 1;
            var converted = value.Convert<Byte>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_Int16()
        {
            Object value = 1;
            var converted = value.Convert<Int16>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_UInt16()
        {
            Object value = 1;
            var converted = value.Convert<UInt16>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_Int32()
        {
            Object value = 1;
            var converted = value.Convert<Int32>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_UInt32()
        {
            Object value = 1;
            var converted = value.Convert<UInt32>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_Int64()
        {
            Object value = 1;
            var converted = value.Convert<Int64>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_UInt64()
        {
            Object value = 1;
            var converted = value.Convert<UInt64>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_Single()
        {
            Object value = 1;
            var converted = value.Convert<Single>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_Double()
        {
            Object value = 1;
            var converted = value.Convert<Double>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_1_convert_to_Decimal()
        {
            Object value = 1;
            var converted = value.Convert<Decimal>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void object_value_C_convert_to_Char()
        {
            Object value = 'C';
            var converted = value.Convert<Char>();
            converted.Should().Be('C');
        }

        [TestMethod]
        public void object_value_true_convert_to_Boolean()
        {
            Object value = true;
            var converted = value.Convert<Boolean>();
            converted.Should().BeTrue();
        }

        [TestMethod]
        public void object_value_min_DateTime_convert_to_DateTime()
        {
            Object value = DateTime.MinValue;
            var converted = value.Convert<DateTime>();
            converted.Should().Be(DateTime.MinValue);
        }

        [TestMethod]
        public void string_value_1_convert_to_SByte()
        {
            String value = "1";
            var converted = value.Convert<SByte>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_Byte()
        {
            String value = "1";
            var converted = value.Convert<Byte>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_Int16()
        {
            String value = "1";
            var converted = value.Convert<Int16>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_UInt16()
        {
            String value = "1";
            var converted = value.Convert<UInt16>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_Int32()
        {
            String value = "1";
            var converted = value.Convert<Int32>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_UInt32()
        {
            String value = "1";
            var converted = value.Convert<UInt32>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_Int64()
        {
            String value = "1";
            var converted = value.Convert<Int64>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_UInt64()
        {
            String value = "1";
            var converted = value.Convert<UInt64>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_Single()
        {
            String value = "1";
            var converted = value.Convert<Single>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_Double()
        {
            String value = "1";
            var converted = value.Convert<Double>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_1_convert_to_Decimal()
        {
            String value = "1";
            var converted = value.Convert<Decimal>();
            converted.Should().Be(1);
        }

        [TestMethod]
        public void string_value_C_convert_to_Char()
        {
            String value = "C";
            var converted = value.Convert<Char>();
            converted.Should().Be('C');
        }

        [TestMethod]
        public void string_value_true_convert_to_Boolean()
        {
            String value = "true";
            var converted = value.Convert<Boolean>();
            converted.Should().BeTrue();
        }

        [TestMethod]
        public void string_value_min_DateTime_convert_to_DateTime()
        {
            String value = DateTime.MinValue.ToString();
            var converted = value.Convert<DateTime>();
            converted.Should().Be(DateTime.MinValue);
        }

        public enum TestEnum
        {
            Enum1 = 1,
            Enum2 = 2,
            Enum3 = 3
        }


    }
}