using EC.SystemExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EC.SystemExtensionsTest
{
    [TestClass]
    public class ObjectExtensionsTest
    {
        public class User
        {
            public String Name { get; set; }
            public Int16 Age { get; set; }
            public Boolean IsActive { get; set; }
        }

        [TestMethod]
        public void Create_shallow_copy_From_user()
        {
            var user = new User
            {
                Name = "Julianito",
                Age = 27,
                IsActive = true
            };

            var userCopy = user.CreateShallowCopy();

            userCopy.Should().NotBe(user);
            userCopy.ShouldBeEquivalentTo(user);
        }
    }
}