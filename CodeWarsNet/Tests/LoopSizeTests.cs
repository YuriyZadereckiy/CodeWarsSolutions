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
    internal class LoopSizeTests
    {
        [Test]
        public void ShouldGetLoopSize()
        {
            LoopDetector.Node n1 = null;
            Assert.AreEqual(0, LoopSize.getLoopSize(n1)); 
                
            n1 = new LoopDetector.Node();
            Assert.AreEqual(0, LoopSize.getLoopSize(n1)); 

            n1.next = n1;
            Assert.AreEqual(1, LoopSize.getLoopSize(n1));

            var n2 =new LoopDetector.Node();
            n1.next = n2;
            Assert.AreEqual(0, LoopSize.getLoopSize(n1));

            n2.next = n1;
            Assert.AreEqual(2, LoopSize.getLoopSize(n1));

            var n3 =new LoopDetector.Node();
            n2.next = n3;
            n3.next = n3;
            Assert.AreEqual(1, LoopSize.getLoopSize(n1));

            var n4 =new LoopDetector.Node();
            n3.next = n4;
            n4.next = n2;
            Assert.AreEqual(3, LoopSize.getLoopSize(n1));

            n4.next = null;
            Assert.AreEqual(0, LoopSize.getLoopSize(n1));
        }
    }
}
