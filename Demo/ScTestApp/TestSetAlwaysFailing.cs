using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ScTestApp
{
    [TestFixture]
    public class TestSetAlwaysFailing
    {
        [Test]
        public void TestCase_AlwaysFailing_1()
        {
            Assert.True(false, "This assertion will always fail");
        }

        [Test]
        public void TestCase_AlwaysFailing_2()
        {
            Assert.True(false, "This assertion will always fail");
        }

        [Test]
        public void TestCase_AlwaysFailing_3()
        {
            Assert.True(false, "This assertion will always fail");
            Assert.True(false, "This assertion will also always fail");
        }
    }
}
