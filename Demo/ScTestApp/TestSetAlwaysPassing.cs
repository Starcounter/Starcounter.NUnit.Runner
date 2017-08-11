using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ScTestApp
{
    [TestFixture]
    public class TestSetAlwaysPassing
    {
        [Test]
        public void TestCase_AlwaysPassing_1()
        {
            Assert.True(true, "This assertion will always pass");
        }

        [Test]
        public void TestCase_AlwaysPassing_2()
        {
            Assert.True(true, "This assertion will always pass");
        }

        [Test]
        public void TestCase_AlwaysPassing_3()
        {
            Assert.True(true, "This assertion will always pass");
            Assert.True(true, "This assertion will also always pass");
        }
    }
}
