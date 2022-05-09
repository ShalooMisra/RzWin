using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

using NUnit.Framework;

using Core;

namespace CoreTest
{
    [TestFixture]
    public class ItemTest
    {
        Context TheContext;

        [SetUp]
        public void Init()
        {
            TheContext = new Context();
        }


        [Test]
        public void CountMaxTest()
        {
            Item i = new Item(new ItemArgs(TheContext));
            Assert.AreEqual(i.CountMax, 1, "The CountMax of an item should always be 1");
        }
    }
}
