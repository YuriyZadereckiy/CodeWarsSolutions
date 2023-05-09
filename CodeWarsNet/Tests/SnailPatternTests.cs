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
    internal class SnailPatternTests
    {
        [Test]
        public void TestCases()
        {
            CollectionAssert.AreEqual(new int[]{}, SnailPattern.Snail(Array.Empty<int[]>()));
            CollectionAssert.AreEqual(new int[] { }, SnailPattern.Snail(new int[1][]
            {
                Array.Empty<int>()
            }));

            CollectionAssert.AreEqual(new []{1}, SnailPattern.Snail(new int[1][]
            {
                new [] {1}
            }));

            CollectionAssert.AreEqual(new []{1,3, 4,5}, SnailPattern.Snail(new int[2][]
            {
                new [] {1,3},
                new [] {5,4},
            }));

            CollectionAssert.AreEqual(new []{1,2,3,4,5,6,7,8,9}, SnailPattern.Snail(new int[3][]
            {
                new [] {1,2,3},
                new [] {8,9,4},
                new [] {7,6,5},
            }));

            CollectionAssert.AreEqual(Enumerable.Range(1,25).ToList(), SnailPattern.Snail(new int[5][]
            {
                new [] {1,2,3,4,5},
                new [] {16,17,18,19,6},
                new [] {15,24,25,20,7},
                new [] {14,23,22,21,8},
                new [] {13,12,11,10,9},
            }));
        }
    }
}
