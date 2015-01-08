using EC.CollectionExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EC.SystemExtensionsTest
{
    [TestClass]
    public class AsDictionaryTest
    {
        [TestMethod]
        public void Transform_anonymous_object_as_dictionary()
        {
            var user = new 
            {
                Name = "Juan Medeiros",
                Age = 16,
                IsActive = true
            };

            var userValues = user.AsDictionary();

            var dic = new Dictionary<String, Object> 
            {
                { "Name", "Juan Medeiros" },
                { "Age", 16 },
                { "IsActive", true },
            };

            userValues.ShouldBeEquivalentTo(dic);
        }
    }
}