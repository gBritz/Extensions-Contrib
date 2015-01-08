using EC.SystemExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EC.SystemExtensionsTest
{
    [TestClass]
    public class HasImplemented
    {
        public interface IAnimal { }

        public abstract class Mammal : IAnimal
        {

        }

        public class Dog : Mammal
        {

        }

        [TestMethod]
        public void Dog_has_implemented_Mammal()
        {
            typeof(Dog).HasImplemented<Mammal>().Should().BeTrue();
        }

        [TestMethod]
        public void Dog_has_implemented_IAnimal()
        {
            typeof(Dog).HasImplemented<IAnimal>().Should().BeTrue();
        }

        [TestMethod]
        public void Mammal_has_implemented_IAnimal()
        {
            typeof(Mammal).HasImplemented<IAnimal>().Should().BeTrue();
        }
    }
}