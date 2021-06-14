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
    public class MmgLoadingBarUnitTest_2
    {
        public MmgLoadingBarUnitTest_2()
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
            MmgLoadingBar l1, l2, l3 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            l1 = new MmgLoadingBar();
            l3 = new MmgLoadingBar();

            l1.SetFillAmt(0.25f);
            l1.SetFillHeight(20);
            l1.SetFillWidth(40);

            Assert.AreEqual(l1.GetFillAmt(), 0.25, 0.001);
            Assert.AreEqual(l1.GetFillHeight(), 20);
            Assert.AreEqual(l1.GetFillWidth(), 40);

            l1.SetLoadingBarBack(b1);
            l1.SetLoadingBarFront(b2);
            l1.SetPaddingX(12);
            l1.SetPaddingY(12);

            Assert.AreEqual(true, l1.GetLoadingBarBack().Equals(b1));
            Assert.AreEqual(true, l1.GetLoadingBarBack().ApiEquals(b1));
            Assert.AreEqual(l1.GetPaddingX(), 12);
            Assert.AreEqual(l1.GetPaddingY(), 12);

            l1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(l1.GetX(), 1);
            Assert.AreEqual(l1.GetY(), 1);

            l1.SetX(2);
            l1.SetY(2);

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(new MmgVector2(2, 2)));
            Assert.AreEqual(l1.GetX(), 2);
            Assert.AreEqual(l1.GetY(), 2);

            l2 = l1.CloneTyped();

            Assert.AreEqual(true, l1.ApiEquals(l1));
            Assert.AreEqual(true, l1.ApiEquals(l2));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(false, l3.ApiEquals(l1));
            Assert.AreEqual(false, l1.ApiEquals(l3));
        }

        [TestMethod]
        public void test2()
        {
            MmgBmp b1, b2 = null;
            MmgLoadingBar l1, l2, l3 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            l1 = new MmgLoadingBar(b1, b2);
            l3 = new MmgLoadingBar(b2, b1);

            l1.SetFillAmt(0.25f);
            l1.SetFillHeight(20);
            l1.SetFillWidth(40);

            Assert.AreEqual(l1.GetFillAmt(), 0.25, 0.001);
            Assert.AreEqual(l1.GetFillHeight(), 20);
            Assert.AreEqual(l1.GetFillWidth(), 40);

            l1.SetLoadingBarBack(b1);
            l1.SetLoadingBarFront(b2);
            l1.SetPaddingX(12);
            l1.SetPaddingY(12);

            Assert.AreEqual(true, l1.GetLoadingBarBack().Equals(b1));
            Assert.AreEqual(true, l1.GetLoadingBarBack().ApiEquals(b1));
            Assert.AreEqual(l1.GetPaddingX(), 12);
            Assert.AreEqual(l1.GetPaddingY(), 12);

            l1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(l1.GetX(), 1);
            Assert.AreEqual(l1.GetY(), 1);

            l1.SetX(2);
            l1.SetY(2);

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(new MmgVector2(2, 2)));
            Assert.AreEqual(l1.GetX(), 2);
            Assert.AreEqual(l1.GetY(), 2);

            l2 = l1.CloneTyped();

            Assert.AreEqual(true, l1.ApiEquals(l1));
            Assert.AreEqual(true, l1.ApiEquals(l2));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(false, l3.ApiEquals(l1));
            Assert.AreEqual(false, l1.ApiEquals(l3));
        }

        [TestMethod]
        public void test3()
        {
            MmgBmp b1, b2 = null;
            MmgLoadingBar l1, l2, l3, l4 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");

            l4 = new MmgLoadingBar(b1, b2);
            l1 = new MmgLoadingBar(l4);
            l3 = new MmgLoadingBar(b2, b1);

            l1.SetFillAmt(0.25f);
            l1.SetFillHeight(20);
            l1.SetFillWidth(40);

            Assert.AreEqual(l1.GetFillAmt(), 0.25, 0.001);
            Assert.AreEqual(l1.GetFillHeight(), 20);
            Assert.AreEqual(l1.GetFillWidth(), 40);

            l1.SetLoadingBarBack(b1);
            l1.SetLoadingBarFront(b2);
            l1.SetPaddingX(12);
            l1.SetPaddingY(12);

            Assert.AreEqual(true, l1.GetLoadingBarBack().Equals(b1));
            Assert.AreEqual(true, l1.GetLoadingBarBack().ApiEquals(b1));
            Assert.AreEqual(l1.GetPaddingX(), 12);
            Assert.AreEqual(l1.GetPaddingY(), 12);

            l1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(l1.GetX(), 1);
            Assert.AreEqual(l1.GetY(), 1);

            l1.SetX(2);
            l1.SetY(2);

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(new MmgVector2(2, 2)));
            Assert.AreEqual(l1.GetX(), 2);
            Assert.AreEqual(l1.GetY(), 2);

            l2 = l1.CloneTyped();

            Assert.AreEqual(true, l1.ApiEquals(l1));
            Assert.AreEqual(true, l1.ApiEquals(l2));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(false, l3.ApiEquals(l1));
            Assert.AreEqual(false, l1.ApiEquals(l3));
        }
    }
}