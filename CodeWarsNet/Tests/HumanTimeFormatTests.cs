using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWarsNet.Source;
using NUnit.Framework;

namespace CodeWarsNet.Tests
{
    [TestFixture]
    internal class HumanTimeFormatTests
    {
        [Test]
        public void TestCases()
        {
            Assert.AreEqual("now", HumanTimeFormat.formatDuration(0));
            Assert.AreEqual("1 second", HumanTimeFormat.formatDuration(1));
            Assert.AreEqual("2 seconds", HumanTimeFormat.formatDuration(2));

            Assert.AreEqual("1 minute and 1 second", HumanTimeFormat.formatDuration(61));
            Assert.AreEqual("1 minute and 2 seconds", HumanTimeFormat.formatDuration(62));

            Assert.AreEqual("11 minutes and 6 seconds", HumanTimeFormat.formatDuration(666));
            Assert.AreEqual("7 days, 17 hours, 11 minutes and 6 seconds", HumanTimeFormat.formatDuration(666666));

            Assert.AreEqual("1 year and 2 seconds", HumanTimeFormat.formatDuration(31536002));
            Assert.AreEqual("10 years and 1 hour", HumanTimeFormat.formatDuration(315363600));
        }
    }
}
