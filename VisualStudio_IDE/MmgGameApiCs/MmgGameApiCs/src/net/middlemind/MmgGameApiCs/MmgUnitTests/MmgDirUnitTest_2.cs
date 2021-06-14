using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;

//Converted
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgDirUnitTest_2
    {
        public MmgDirUnitTest_2()
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
            Assert.AreEqual(MmgDir.DIR_FRONT, 0);
            Assert.AreEqual(MmgDir.DIR_BOTTOM, 0);
            Assert.AreEqual(MmgDir.DIR_FRONT, MmgDir.DIR_BOTTOM, 0);
            Assert.AreEqual(MmgDir.DIR_BACK, 1);
            Assert.AreEqual(MmgDir.DIR_TOP, 1);
            Assert.AreEqual(MmgDir.DIR_BACK, MmgDir.DIR_TOP, 0);
            Assert.AreEqual(MmgDir.DIR_LEFT, 2);
            Assert.AreEqual(MmgDir.DIR_RIGHT, 3);
        }
    }
}