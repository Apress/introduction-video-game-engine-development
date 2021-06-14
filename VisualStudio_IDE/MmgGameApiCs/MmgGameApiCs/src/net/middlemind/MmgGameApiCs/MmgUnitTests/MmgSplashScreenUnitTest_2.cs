using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    public class MmgSplashScreenUnitTest_2
    {
        public MmgSplashScreenUnitTest_2()
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
            MmgSplashScreen s1, s2, s3 = null;

            s1 = new MmgSplashScreen();
            s3 = new MmgSplashScreen(2000);

            Assert.AreEqual(s1.GetDisplayTime(), 3000);
            Assert.AreEqual(MmgSplashScreen.DEFAULT_DISPLAY_TIME_MS, 3000);

            s1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, s1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            s1.SetHeight(64);
            s1.SetWidth(64);

            Assert.AreEqual(s1.GetHeight(), 64);
            Assert.AreEqual(s1.GetWidth(), 64);

            s1.SetMmgColor(MmgColor.GetBlueGray());

            Assert.AreEqual(true, s1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

            s2 = s1.CloneTyped();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(false, s3.ApiEquals(s1));
            Assert.AreEqual(false, s1.ApiEquals(s3));
        }

        [TestMethod]
        public void test2()
        {
            MmgSplashScreen s1, s2, s3 = null;

            s1 = new MmgSplashScreen(1000);
            s3 = new MmgSplashScreen(2000);

            Assert.AreEqual(s1.GetDisplayTime(), 1000);
            Assert.AreEqual(MmgSplashScreen.DEFAULT_DISPLAY_TIME_MS, 3000);

            s1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, s1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            s1.SetHeight(64);
            s1.SetWidth(64);

            Assert.AreEqual(s1.GetHeight(), 64);
            Assert.AreEqual(s1.GetWidth(), 64);

            s1.SetMmgColor(MmgColor.GetBlueGray());

            Assert.AreEqual(true, s1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

            s2 = s1.CloneTyped();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(false, s3.ApiEquals(s1));
            Assert.AreEqual(false, s1.ApiEquals(s3));
        }

        [TestMethod]
        public void test3()
        {
            MmgSplashScreen s1, s2, s3, s4 = null;

            s4 = new MmgSplashScreen(1000);
            s1 = new MmgSplashScreen(s4);
            s3 = new MmgSplashScreen(2000);

            Assert.AreEqual(s1.GetDisplayTime(), 1000);
            Assert.AreEqual(MmgSplashScreen.DEFAULT_DISPLAY_TIME_MS, 3000);

            s1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, s1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            s1.SetHeight(64);
            s1.SetWidth(64);

            Assert.AreEqual(s1.GetHeight(), 64);
            Assert.AreEqual(s1.GetWidth(), 64);

            s1.SetMmgColor(MmgColor.GetBlueGray());

            Assert.AreEqual(true, s1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

            s2 = s1.CloneTyped();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(true, s2.ApiEquals(s1));
            Assert.AreEqual(false, s3.ApiEquals(s1));
            Assert.AreEqual(false, s1.ApiEquals(s3));
        }
    }
}