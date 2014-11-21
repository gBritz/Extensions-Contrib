using EC.FileExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ExtensionsContrib.FileTest
{
    [TestClass]
    public class FileInfoExtensionsTest
    {
        private readonly String filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt");

        [TestInitialize]
        public void CreateFileTest()
        {
            File.AppendAllText(filePath, "Test...");
        }

        [TestCleanup]
        public void DeleteFileTest()
        {
            File.Delete(filePath);
        }

        [TestMethod]
        public void File_should_be_is_in_use()
        {
            using (var file = File.Open(filePath, FileMode.Open)) 
            {
                var info = new FileInfo(filePath);
                info.IsLocked().Should().BeTrue();
            }
        }

        [TestMethod]
        public void File_should_not_be_is_in_use()
        {
            var info = new FileInfo(filePath);
            info.IsLocked().Should().BeFalse();
        }

        [TestMethod]
        public void Throw_exception_when_parameter_is_null_or_invalid()
        {
            Action stringIsNull = () => ((String)null).IsFileLocked();
            Action stringIsEmpty = () => String.Empty.IsFileLocked();
            Action fileInfoIsNull = () => ((FileInfo)null).IsLocked();

            stringIsNull.ShouldThrow<ArgumentNullException>()
                .And.ParamName
                    .Should().Be("filePath");

            stringIsEmpty.ShouldThrow<ArgumentException>()
                .And.ParamName
                    .Should().Be("filePath");

            fileInfoIsNull.ShouldThrow<ArgumentNullException>()
                .And.ParamName
                    .Should().Be("file");
        }
    }
}