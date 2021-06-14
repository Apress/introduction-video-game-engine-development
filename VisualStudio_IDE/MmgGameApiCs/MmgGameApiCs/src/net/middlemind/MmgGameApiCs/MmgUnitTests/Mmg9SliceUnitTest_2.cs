using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework.Graphics;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;

//Converted
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class Mmg9SliceUnitTest_2
    {
        public Mmg9SliceUnitTest_2()
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

        [TestMethod]
        public void test1()
        {
            MmgBmp b1, b2 = null;
            Mmg9Slice n1, n2, n3 = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");

            n1 = new Mmg9Slice(10, b1, 200, 200);
            n3 = new Mmg9Slice(12, b2, 300, 300);

            Assert.AreEqual(n1.GetOffset(), 10);
            Assert.AreEqual(true, n1.GetSrc().ApiEquals(b1));
            Assert.AreEqual(true, n1.GetSrc().Equals(b1));
            Assert.AreEqual(n1.GetWidth(), 200);
            Assert.AreEqual(n1.GetHeight(), 200);
            Assert.AreEqual(true, n1.GetIsVisible());
            Assert.AreEqual(true, n1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            n1.SetDest(b2);
            n1.SetOffset(12);
            n1.SetSrc(b2);

            Assert.AreEqual(true, n1.GetDest().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetDest().Equals(b2));
            Assert.AreEqual(true, n1.GetSrc().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetSrc().Equals(b2));
            Assert.AreEqual(true, n1.GetDest().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetOffset() == 12);

            n2 = n1.CloneTyped();

            Assert.AreEqual(true, n1.ApiEquals(n1));
            Assert.AreEqual(true, n1.ApiEquals(n2));
            Assert.AreEqual(true, n2.ApiEquals(n1));
            Assert.AreEqual(true, n2.ApiEquals(n1));
            Assert.AreEqual(false, n3.ApiEquals(n1));
            Assert.AreEqual(false, n1.ApiEquals(n3));
        }

        [TestMethod]
        public void test2()
        {
            MmgBmp b1, b2 = null;
            Mmg9Slice n1, n2, n3 = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");

            n1 = new Mmg9Slice(10, b1, 200, 200, MmgVector2.GetUnitVec());
            n3 = new Mmg9Slice(12, b2, 300, 300);

            Assert.AreEqual(n1.GetOffset(), 10);
            Assert.AreEqual(true, n1.GetSrc().ApiEquals(b1));
            Assert.AreEqual(true, n1.GetSrc().Equals(b1));
            Assert.AreEqual(n1.GetWidth(), 200);
            Assert.AreEqual(n1.GetHeight(), 200);
            Assert.AreEqual(true, n1.GetIsVisible());
            Assert.AreEqual(true, n1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            n1.SetDest(b2);
            n1.SetOffset(12);
            n1.SetSrc(b2);

            Assert.AreEqual(true, n1.GetDest().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetDest().Equals(b2));
            Assert.AreEqual(true, n1.GetSrc().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetSrc().Equals(b2));
            Assert.AreEqual(true, n1.GetDest().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetOffset() == 12);

            n2 = n1.CloneTyped();

            Assert.AreEqual(true, n1.ApiEquals(n1));
            Assert.AreEqual(true, n1.ApiEquals(n2));
            Assert.AreEqual(true, n2.ApiEquals(n1));
            Assert.AreEqual(true, n2.ApiEquals(n1));
            Assert.AreEqual(false, n3.ApiEquals(n1));
            Assert.AreEqual(false, n1.ApiEquals(n3));
        }

        [TestMethod]
        public void test3()
        {
            MmgBmp b1, b2 = null;
            Mmg9Slice n1, n2, n3 = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");

            n1 = new Mmg9Slice(new Mmg9Slice(10, b1, 200, 200, MmgVector2.GetUnitVec()));
            n3 = new Mmg9Slice(12, b2, 300, 300);

            Assert.AreEqual(n1.GetOffset(), 10);
            Assert.AreEqual(true, n1.GetSrc().ApiEquals(b1));
            Assert.AreEqual(false, n1.GetSrc().Equals(b1));
            Assert.AreEqual(n1.GetWidth(), 200);
            Assert.AreEqual(n1.GetHeight(), 200);
            Assert.AreEqual(true, n1.GetIsVisible());
            Assert.AreEqual(true, n1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            n1.SetDest(b2);
            n1.SetOffset(12);
            n1.SetSrc(b2);

            Assert.AreEqual(true, n1.GetDest().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetDest().Equals(b2));
            Assert.AreEqual(true, n1.GetSrc().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetSrc().Equals(b2));
            Assert.AreEqual(true, n1.GetDest().ApiEquals(b2));
            Assert.AreEqual(true, n1.GetOffset() == 12);

            n1.SetX(2);
            n1.SetY(2);

            Assert.AreEqual(true, n1.GetPosition().ApiEquals(new MmgVector2(2, 2)));

            n2 = n1.CloneTyped();

            Assert.AreEqual(true, n1.ApiEquals(n1));
            Assert.AreEqual(true, n1.ApiEquals(n2));
            Assert.AreEqual(true, n2.ApiEquals(n1));
            Assert.AreEqual(true, n2.ApiEquals(n1));
            Assert.AreEqual(false, n3.ApiEquals(n1));
            Assert.AreEqual(false, n1.ApiEquals(n3));
        }
    }
}