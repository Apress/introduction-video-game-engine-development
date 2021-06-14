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
    public class MmgColorUnitTest
    {
        public MmgColorUnitTest()
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
        public void testStaticMembers()
        {
            //VARS
            Color cr;
            MmgColor c1;

            //TEST 1
            cr = Color.White;
            Assert.AreEqual(true, MmgColor.GetWhite().ApiEquals(new MmgColor(cr)));

            //TEST 2
            cr = Color.Black;
            Assert.AreEqual(true, MmgColor.GetBlack().ApiEquals(new MmgColor(cr)));

            //TEST 3
            c1 = new MmgColor(Color.White);
            Assert.AreEqual(true, MmgColor.GetWhite().ApiEquals(new MmgColor(c1)));

            //TEST 4
            c1 = new MmgColor(Color.Black);
            Assert.AreEqual(true, MmgColor.GetBlack().ApiEquals(new MmgColor(c1)));
        }

        [TestMethod]
        public void testEquals()
        {
            //VARS
            MmgColor c1;
            MmgColor c2;
            Color cr;

            //TEST 1
            cr = Color.Green;
            c1 = new MmgColor(cr);
            c2 = new MmgColor(c1);
            Assert.AreEqual(true, c1.ApiEquals(c2));
        }

        [TestMethod]
        public void testGettersSetters()
        {
            //VARS
            MmgColor c1;
            Color cr;

            //TEST 1
            cr = Color.Green;
            c1 = new MmgColor();
            c1.SetColor(cr);
            Assert.AreEqual(cr, c1.GetColor());

            //TEST 2
            cr = Color.Gray;
            c1.SetColor(cr);
            Assert.AreEqual(cr, c1.GetColor());
        }

        [TestMethod]
        public void testCloning()
        {
            //VARS
            MmgColor c1;
            MmgColor c2;
            Color cr;

            //TEST 1
            cr = Color.Pink;
            c1 = new MmgColor(cr);
            c2 = c1.Clone();

            Assert.AreNotEqual(c1, c2);
            Assert.AreNotEqual(c1, c2);
            Assert.AreEqual(c1.GetColor(), c2.GetColor());
            Assert.IsTrue(c1.ApiEquals(c2));
        }

        [TestMethod]
        public void testConstructors()
        {
            //VARS
            MmgColor c1;
            MmgColor c2;
            Color cr;

            //TEST 1 PREP
            c1 = new MmgColor();
            cr = Color.White;

            //TEST 1
            Assert.AreEqual(cr, c1.GetColor());

            //TEST 2 PREP
            cr = Color.Black;
            c1 = new MmgColor();
            c1.SetColor(cr);
            c2 = new MmgColor(cr);

            //TEST 2
            Assert.AreEqual(cr, c2.GetColor());

            //TEST 3 PREP
            cr = Color.Red;
            c1 = new MmgColor(cr);
            c2 = new MmgColor(c1);

            //TEST 3
            Assert.AreEqual(cr, c2.GetColor());
        }
    }
}