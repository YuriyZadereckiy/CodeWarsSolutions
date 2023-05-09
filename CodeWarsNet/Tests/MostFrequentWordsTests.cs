using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.Source;
using NUnit.Framework;

namespace CodeWars.Tests
{
    internal class MostFrequentWordsTests
    {
        [Test]
        public void ShouldFindMostFrequent_Default()
        {
            CollectionAssert.AreEqual(new[] { "a", "of", "on" }, MostFrequentWords.FindMostFrequentWords("In a village of La Mancha, the name of which I have no desire to call to\r\nmind, there lived not long since one of those gentlemen that keep a lance\r\nin the lance-rack, an old buckler, a lean hack, and a greyhound for\r\ncoursing. An olla of rather more beef than mutton, a salad on most\r\nnights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra\r\non Sundays, made away with three-quarters of his income."));

            CollectionAssert.AreEqual(new[] { "e", "ddd", "aa" },
                MostFrequentWords.FindMostFrequentWords("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));

            CollectionAssert.AreEqual(new[] { "won't", "wont" },
                MostFrequentWords.FindMostFrequentWords("  //wont won't won't"));

            CollectionAssert.AreEqual(Array.Empty<string>(),
                MostFrequentWords.FindMostFrequentWords(""));

            CollectionAssert.AreEqual(new []{"aaa"},
                MostFrequentWords.FindMostFrequentWords("aaa"));

            CollectionAssert.AreEqual(new []{"aaa", "b"}, 
                MostFrequentWords.FindMostFrequentWords("aaa b"));
            CollectionAssert.AreEqual(new []{"a", "aa", "b"}, 
                MostFrequentWords.FindMostFrequentWords("  aa2a1 a b,56it "));
            CollectionAssert.AreEqual(new []{"as", "bb"}, 
                MostFrequentWords.FindMostFrequentWords(" As   bB4  "));

            CollectionAssert.AreEqual(new string[0], 
                MostFrequentWords.FindMostFrequentWords(" '  "));

            CollectionAssert.AreEqual(new string[0], 
                MostFrequentWords.FindMostFrequentWords(" '''  "));

        }
    }
}
