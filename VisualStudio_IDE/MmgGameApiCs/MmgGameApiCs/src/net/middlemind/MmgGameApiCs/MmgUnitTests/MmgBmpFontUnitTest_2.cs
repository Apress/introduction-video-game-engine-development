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
    public class MmgBmpFontUnitTest_2
    {
        public MmgBmpFontUnitTest_2()
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
            MmgBmp b1, b2 = null;
            MmgBmpFont f1, f2, f3 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_black.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_white.png");
            f1 = new MmgBmpFont(b1);
            f3 = new MmgBmpFont(b2);

            Assert.AreEqual(true, b1.Equals(f1.GetSrc()));
            Assert.AreEqual(true, " ".Equals(f1.GetText()));

            f1.SetHeight(64);
            f1.SetWidth(64);

            Assert.AreEqual(f1.GetHeight(), 64);
            Assert.AreEqual(f1.GetWidth(), 64);

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, MmgVector2.GetUnitVec().ApiEquals(f1.GetPosition()));

            f1.SetMmgColor(MmgColor.GetBlueGray());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));

            MmgBmp[] crs = f1.GetChars();
            crs[0] = crs[crs.Length - 1];
            f1.SetChars(crs);

            Assert.AreEqual(true, crs.Equals(f1.GetChars()));
            Assert.AreEqual(true, crs[0].Equals(f1.GetChar(crs.Length - 1)));
            Assert.AreEqual(false, f1.GetDst() == null);
        }

        [TestMethod]
        public void test2()
        {
            MmgBmp b1, b2 = null;
            MmgBmpFont f1, f2, f3 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_black.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_white.png");
            f1 = new MmgBmpFont(b1, "Test 1");
            f3 = new MmgBmpFont(b2, "Test 2");

            Assert.AreEqual(true, b1.Equals(f1.GetSrc()));
            Assert.AreEqual(true, "Test 1".Equals(f1.GetText()));

            f1.SetHeight(64);
            f1.SetWidth(64);

            Assert.AreEqual(f1.GetHeight(), 64);
            Assert.AreEqual(f1.GetWidth(), 64);

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, MmgVector2.GetUnitVec().ApiEquals(f1.GetPosition()));

            f1.SetMmgColor(MmgColor.GetBlueGray());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));

            MmgBmp[] crs = f1.GetChars();
            crs[0] = crs[crs.Length - 1];
            f1.SetChars(crs);

            Assert.AreEqual(true, crs.Equals(f1.GetChars()));
            Assert.AreEqual(true, crs[0].Equals(f1.GetChar(crs.Length - 1)));
            Assert.AreEqual(false, f1.GetDst() == null);
        }

        [TestMethod]
        public void test3()
        {
            MmgBmp b1, b2 = null;
            MmgBmpFont f1, f2, f3, f4 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_black.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_white.png");
            f4 = new MmgBmpFont(b1, "Test 1");
            f1 = new MmgBmpFont(f4);
            f3 = new MmgBmpFont(b2, "Test 2");

            Assert.AreEqual(true, b1.ApiEquals(f1.GetSrc()));
            Assert.AreEqual(true, "Test 1".Equals(f1.GetText()));

            f1.SetHeight(64);
            f1.SetWidth(64);

            Assert.AreEqual(f1.GetHeight(), 64);
            Assert.AreEqual(f1.GetWidth(), 64);

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, MmgVector2.GetUnitVec().ApiEquals(f1.GetPosition()));

            f1.SetMmgColor(MmgColor.GetBlueGray());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));

            MmgBmp[] crs = f1.GetChars();
            crs[0] = crs[crs.Length - 1];
            f1.SetChars(crs);

            Assert.AreEqual(true, crs.Equals(f1.GetChars()));
            Assert.AreEqual(true, crs[0].Equals(f1.GetChar(crs.Length - 1)));
            Assert.AreEqual(false, f1.GetDst() == null);
        }
    }
}