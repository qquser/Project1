using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Project1.Common;

namespace Project1.Test
{
    [TestFixture]
    public class TestExample
    {
        [Test]
        public void NonEmptyIdentity_Test()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(()=> new NonEmptyIdentity(Guid.Empty));
        }
    }
}
