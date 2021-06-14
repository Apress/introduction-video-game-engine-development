using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgLoadingScreenUnitTest_2
    {
        public MmgLoadingScreenUnitTest_2()
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
            MmgBmp b1, b2, b3, b4 = null;
            MmgLoadingBar l1, l2, l3 = null;
            MmgLoadingScreen s1, s2, s3 = null;

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            b3 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetBlue());
            b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            l1 = new MmgLoadingBar(b1, b2);
            l2 = new MmgLoadingBar(b3, b4);
            l3 = new MmgLoadingBar(b2, b1);

            s1 = new MmgLoadingScreen();
            s1.SetLoadingBar(l1, 5.0f);
            s3 = new MmgLoadingScreen(l3, 10.0f);

            Assert.AreEqual(true, s1.GetLoadingBar().ApiEquals(l1));
            Assert.AreEqual(true, s1.GetLoadingBar().Equals(l1));
            Assert.AreEqual(false, s1.GetLoadingBar().ApiEquals(l2));
            Assert.AreEqual(false, s1.GetLoadingBar().Equals(l2));

            s2 = s1.CloneTyped();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(false, s3.ApiEquals(s1));
            Assert.AreEqual(false, s1.ApiEquals(s3));

            Assert.AreEqual(s1.GetLoadingBarOffsetBottom(), 5.0f, 0.001);
        }

        [TestMethod]
        public void test2()
        {
            MmgBmp b1, b2, b3, b4 = null;
            MmgLoadingBar l1, l2, l3 = null;
            MmgLoadingScreen s1, s2, s3 = null;

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            b3 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetBlue());
            b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            l1 = new MmgLoadingBar(b1, b2);
            l2 = new MmgLoadingBar(b3, b4);
            l3 = new MmgLoadingBar(b2, b1);

            s1 = new MmgLoadingScreen(l1, 10.0f);
            s1.SetLoadingBar(l1, 5);
            s3 = new MmgLoadingScreen(l3, 10.0f);

            Assert.AreEqual(true, s1.GetLoadingBar().ApiEquals(l1));
            Assert.AreEqual(true, s1.GetLoadingBar().Equals(l1));
            Assert.AreEqual(false, s1.GetLoadingBar().ApiEquals(l2));
            Assert.AreEqual(false, s1.GetLoadingBar().Equals(l2));

            s2 = s1.CloneTyped();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(false, s3.ApiEquals(s1));
            Assert.AreEqual(false, s1.ApiEquals(s3));

            Assert.AreEqual(s1.GetLoadingBarOffsetBottom(), 5.0f, 0.001);
        }

        [TestMethod]
        public void test3()
        {
            MmgBmp b1, b2, b3, b4 = null;
            MmgLoadingBar l1, l2, l3 = null;
            MmgLoadingScreen s1, s2, s3 = null;

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            b3 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetBlue());
            b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            l1 = new MmgLoadingBar(b1, b2);
            l2 = new MmgLoadingBar(b3, b4);
            l3 = new MmgLoadingBar(b2, b1);

            s1 = new MmgLoadingScreen(new MmgLoadingScreen(l1, 10.0f));
            s1.SetLoadingBar(l1, 5);
            s3 = new MmgLoadingScreen(l3, 10.0f);

            Assert.AreEqual(true, s1.GetLoadingBar().ApiEquals(l1));
            Assert.AreEqual(true, s1.GetLoadingBar().Equals(l1));
            Assert.AreEqual(false, s1.GetLoadingBar().ApiEquals(l2));
            Assert.AreEqual(false, s1.GetLoadingBar().Equals(l2));

            s2 = s1.CloneTyped();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(false, s3.ApiEquals(s1));
            Assert.AreEqual(false, s1.ApiEquals(s3));

            Assert.AreEqual(s1.GetLoadingBarOffsetBottom(), 5.0f, 0.001);
        }
    }
}