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
    public class MmgContainerUnitTest
    {
        public MmgContainerUnitTest()
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
        public void testConstructors()
        {
            //VAR
            MmgContainer m1;
            MmgVector2 v1;
            int w;
            int h;
            MmgColor c1;

            //PREP TEST 1
            m1 = new MmgContainer();
            v1 = new MmgVector2(0, 0);
            w = 0;
            h = 0;
            c1 = new MmgColor(Color.Orange);

            //TEST 1
            Assert.AreEqual(true, v1.ApiEquals(m1.GetPosition()));
            Assert.AreEqual(w, m1.GetWidth());
            Assert.AreEqual(h, m1.GetHeight());
        }
    }
}