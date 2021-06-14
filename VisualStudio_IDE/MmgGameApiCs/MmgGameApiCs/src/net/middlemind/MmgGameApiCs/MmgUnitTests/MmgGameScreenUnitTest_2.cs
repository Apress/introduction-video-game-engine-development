using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgGameScreenUnitTest_2
    {
        public MmgGameScreenUnitTest_2()
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
            MmgGameScreen s1, s2, s3 = null;
            MmgBmp b1, b2, b3 = null;
            MmgMenuContainer mm1 = null;
            MmgObj o1 = null;
            MmgContainer c1 = null;

            s1 = new MmgGameScreen();
            s3 = new MmgGameScreen();

            Assert.AreEqual(true, s1.GetObjects() != null);
            Assert.AreEqual(true, s1.GetMenu() != null);
            Assert.AreEqual(true, s1.GetBackground() == null);
            Assert.AreEqual(true, s1.GetForeground() == null);
            Assert.AreEqual(true, s1.GetHeader() == null);
            Assert.AreEqual(true, s1.GetFooter() == null);
            Assert.AreEqual(true, s1.GetLeftCursor() == null);
            Assert.AreEqual(true, s1.GetRightCursor() == null);
            Assert.AreEqual(true, s1.GetMessage() == null);
            Assert.AreEqual(true, s1.GetMenuIdx() == 0);
            Assert.AreEqual(true, s1.GetMenuStart() == 0);
            Assert.AreEqual(true, s1.GetMenuStop() == 0);
            Assert.AreEqual(true, s1.GetMenuOn() == false);
            Assert.AreEqual(true, s1.GetWidth() == MmgScreenData.GetGameWidth());
            Assert.AreEqual(true, s1.GetHeight() == MmgScreenData.GetGameHeight());
            Assert.AreEqual(true, s1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            s1.SetBackground(b1);

            Assert.AreEqual(true, s1.GetBackground().ApiEquals(b1));
            Assert.AreEqual(true, s1.GetBackground().Equals(b1));

            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            s1.SetForeground(b2);

            Assert.AreEqual(true, s1.GetForeground().ApiEquals(b2));
            Assert.AreEqual(true, s1.GetForeground().Equals(b2));

            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
            s1.SetHeader(b3);

            Assert.AreEqual(true, s1.GetHeader().ApiEquals(b3));
            Assert.AreEqual(true, s1.GetHeader().Equals(b3));

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            s1.SetFooter(b1);

            Assert.AreEqual(true, s1.GetFooter().ApiEquals(b1));
            Assert.AreEqual(true, s1.GetFooter().Equals(b1));

            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "loading_bar.png");
            s1.SetLeftCursor(b2);

            Assert.AreEqual(true, s1.GetLeftCursor().ApiEquals(b2));
            Assert.AreEqual(true, s1.GetLeftCursor().Equals(b2));

            mm1 = new MmgMenuContainer();
            s1.SetMenu(mm1);

            Assert.AreEqual(true, s1.GetMenu().ApiEquals(mm1));
            Assert.AreEqual(true, s1.GetMenu().Equals(mm1));

            s1.SetMenuCursorLeftOffsetX(12);
            s1.SetMenuCursorLeftOffsetY(12);
            s1.SetMenuCursorRightOffsetX(14);
            s1.SetMenuCursorRightOffsetY(14);
            s1.SetMenuIdx(0);
            s1.SetMenuOn(false);

            Assert.AreEqual(true, s1.GetMenuCursorLeftOffsetX() == 12);
            Assert.AreEqual(true, s1.GetMenuCursorLeftOffsetY() == 12);
            Assert.AreEqual(true, s1.GetMenuCursorRightOffsetX() == 14);
            Assert.AreEqual(true, s1.GetMenuCursorRightOffsetY() == 14);
            Assert.AreEqual(true, s1.GetMenuIdx() == 0);
            Assert.AreEqual(true, s1.GetMenuOn() == false);

            c1 = new MmgContainer();
            o1 = new MmgObj();
            s1.SetMenuStart(0);
            s1.SetMenuStop(10);
            s1.SetMessage(o1);
            s1.SetObjects(c1);

            Assert.AreEqual(true, s1.GetMenuStart() == 0);
            Assert.AreEqual(true, s1.GetMenuStop() == 10);
            Assert.AreEqual(true, s1.GetMessage().ApiEquals(o1));
            Assert.AreEqual(true, s1.GetMessage().Equals(o1));
            Assert.AreEqual(true, s1.GetObjects().ApiEquals(c1));
            Assert.AreEqual(true, s1.GetObjects().Equals(c1));

            s1.SetX(50);
            s1.SetY(50);

            Assert.AreEqual(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

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
            MmgGameScreen s1, s2, s3 = null;
            MmgBmp b1, b2, b3 = null;
            MmgMenuContainer mm1 = null;
            MmgObj o1 = null;
            MmgContainer c1 = null;

            s1 = new MmgGameScreen(new MmgGameScreen());
            s3 = new MmgGameScreen();

            Assert.AreEqual(true, s1.GetObjects() != null);
            Assert.AreEqual(true, s1.GetMenu() != null);
            Assert.AreEqual(true, s1.GetBackground() == null);
            Assert.AreEqual(true, s1.GetForeground() == null);
            Assert.AreEqual(true, s1.GetHeader() == null);
            Assert.AreEqual(true, s1.GetFooter() == null);
            Assert.AreEqual(true, s1.GetLeftCursor() == null);
            Assert.AreEqual(true, s1.GetRightCursor() == null);
            Assert.AreEqual(true, s1.GetMessage() == null);
            Assert.AreEqual(true, s1.GetMenuIdx() == 0);
            Assert.AreEqual(true, s1.GetMenuStart() == 0);
            Assert.AreEqual(true, s1.GetMenuStop() == 0);
            Assert.AreEqual(true, s1.GetMenuOn() == false);
            Assert.AreEqual(true, s1.GetWidth() == MmgScreenData.GetGameWidth());
            Assert.AreEqual(true, s1.GetHeight() == MmgScreenData.GetGameHeight());
            Assert.AreEqual(true, s1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            s1.SetBackground(b1);

            Assert.AreEqual(true, s1.GetBackground().ApiEquals(b1));
            Assert.AreEqual(true, s1.GetBackground().Equals(b1));

            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            s1.SetForeground(b2);

            Assert.AreEqual(true, s1.GetForeground().ApiEquals(b2));
            Assert.AreEqual(true, s1.GetForeground().Equals(b2));

            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
            s1.SetHeader(b3);

            Assert.AreEqual(true, s1.GetHeader().ApiEquals(b3));
            Assert.AreEqual(true, s1.GetHeader().Equals(b3));

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            s1.SetFooter(b1);

            Assert.AreEqual(true, s1.GetFooter().ApiEquals(b1));
            Assert.AreEqual(true, s1.GetFooter().Equals(b1));

            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "loading_bar.png");
            s1.SetLeftCursor(b2);

            Assert.AreEqual(true, s1.GetLeftCursor().ApiEquals(b2));
            Assert.AreEqual(true, s1.GetLeftCursor().Equals(b2));

            mm1 = new MmgMenuContainer();
            s1.SetMenu(mm1);

            Assert.AreEqual(true, s1.GetMenu().ApiEquals(mm1));
            Assert.AreEqual(true, s1.GetMenu().Equals(mm1));

            s1.SetMenuCursorLeftOffsetX(12);
            s1.SetMenuCursorLeftOffsetY(12);
            s1.SetMenuCursorRightOffsetX(14);
            s1.SetMenuCursorRightOffsetY(14);
            s1.SetMenuIdx(0);
            s1.SetMenuOn(false);

            Assert.AreEqual(true, s1.GetMenuCursorLeftOffsetX() == 12);
            Assert.AreEqual(true, s1.GetMenuCursorLeftOffsetY() == 12);
            Assert.AreEqual(true, s1.GetMenuCursorRightOffsetX() == 14);
            Assert.AreEqual(true, s1.GetMenuCursorRightOffsetY() == 14);
            Assert.AreEqual(true, s1.GetMenuIdx() == 0);
            Assert.AreEqual(true, s1.GetMenuOn() == false);

            c1 = new MmgContainer();
            o1 = new MmgObj();
            s1.SetMenuStart(0);
            s1.SetMenuStop(10);
            s1.SetMessage(o1);
            s1.SetObjects(c1);

            Assert.AreEqual(true, s1.GetMenuStart() == 0);
            Assert.AreEqual(true, s1.GetMenuStop() == 10);
            Assert.AreEqual(true, s1.GetMessage().ApiEquals(o1));
            Assert.AreEqual(true, s1.GetMessage().Equals(o1));
            Assert.AreEqual(true, s1.GetObjects().ApiEquals(c1));
            Assert.AreEqual(true, s1.GetObjects().Equals(c1));

            s1.SetX(50);
            s1.SetY(50);

            Assert.AreEqual(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

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