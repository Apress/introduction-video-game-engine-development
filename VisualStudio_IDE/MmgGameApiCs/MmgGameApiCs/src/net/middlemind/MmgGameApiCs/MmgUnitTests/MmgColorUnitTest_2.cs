using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using net.middlemind.MmgGameApiCs.MmgBase;

//Converted equals and Equals
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgColorUnitTest_2
    {
        public MmgColorUnitTest_2()
        {
        }

        [TestInitialize]
        public static void setUpClass()
        {
        }

        [TestCleanup]
        public static void tearDownClass()
        {
        }

        public void setUp()
        {
        }

        public void tearDown()
        {
        }

        [TestMethod]
        public void test1()
        {
            MmgColor c1;
            MmgColor c2;
            MmgColor c3;

            c3 = new MmgColor(Color.Yellow);
            c1 = new MmgColor();
            Assert.AreEqual(c1.GetColor(), Color.White);

            c2 = c1.Clone();
            Assert.AreEqual(true, c1.ApiEquals(c2));
            Assert.AreEqual(true, c1.ApiEquals(c1));
            Assert.AreEqual(false, c1.ApiEquals(c3));

            c1.SetColor(Color.Red);
            Assert.AreEqual(c1.GetColor(), Color.Red);
        }

        [TestMethod]
        public void test2()
        {
            MmgColor c1;
            MmgColor c2;
            MmgColor c3;

            c3 = new MmgColor(Color.Yellow);
            c1 = new MmgColor(new MmgColor());
            Assert.AreEqual(c1.GetColor(), Color.White);

            c2 = c1.Clone();
            Assert.AreEqual(true, c1.ApiEquals(c2));
            Assert.AreEqual(true, c1.ApiEquals(c1));
            Assert.AreEqual(false, c1.ApiEquals(c3));

            c1.SetColor(Color.Red);
            Assert.AreEqual(c1.GetColor(), Color.Red);
        }

        [TestMethod]
        public void test3()
        {
            MmgColor c1;
            MmgColor c2;
            MmgColor c3;

            c3 = new MmgColor();
            c1 = new MmgColor(Color.Blue);
            Assert.AreEqual(c1.GetColor(), Color.Blue);

            c2 = c1.Clone();
            Assert.AreEqual(true, c1.ApiEquals(c2));
            Assert.AreEqual(true, c1.ApiEquals(c1));
            Assert.AreEqual(false, c1.ApiEquals(c3));

            c1.SetColor(Color.Red);
            Assert.AreEqual(c1.GetColor(), Color.Red);
        }
    }
}