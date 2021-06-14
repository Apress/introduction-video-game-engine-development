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
    [TestClass]
    public class MmgTextFieldUnitTest_2
    {

        public MmgTextFieldUnitTest_2()
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
            MmgBmp b1, b2, b3, b4, b5 = null;
            MmgFont f1, f2, f3 = null;
            MmgTextField t1, t2, t3 = null;
            MmgVector2Int v1 = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");

            f1 = MmgFontData.GetMmgFontBold();
            f2 = MmgFontData.GetMmgFontItalic();
            f3 = MmgFontData.GetMmgFontNorm();

            Mmg9Slice n1, n2 = null;

            b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
            b5 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");

            n1 = new Mmg9Slice(10, b4, 200, 200, MmgVector2.GetUnitVec());
            n2 = new Mmg9Slice(12, b5, 300, 300);

            t1 = new MmgTextField(b1, f1, 100, 100, 4, 20);
            t3 = new MmgTextField(b2, f2, 300, 300, 12, 20);

            Assert.AreEqual(true, t1.GetBgroundSrc().ApiEquals(b1));
            Assert.AreEqual(true, t1.GetBgroundSrc().Equals(b1));
            Assert.AreEqual(true, t1.GetFont().ApiEquals(f1));
            Assert.AreEqual(true, t1.GetFont().Equals(f1));
            Assert.AreEqual(true, t1.GetPadding() == 4);
            Assert.AreEqual(true, t1.GetDisplayChars() == 20);
            Assert.AreEqual(true, t1.GetWidth() == 100);
            Assert.AreEqual(true, t1.GetHeight() == 100);
            Assert.AreEqual(true, t1.GetMaxLength() == MmgTextField.DEFAULT_MAX_LENGTH);
            Assert.AreEqual(true, t1.GetTextFieldString().Equals(""));

            t1.SetBground(n1);
            t1.SetBgroundSrc(b3);
            t1.SetDisplayChars(24);

            Assert.AreEqual(true, t1.GetBground().ApiEquals(n1));
            Assert.AreEqual(true, t1.GetBground().Equals(n1));
            Assert.AreEqual(true, t1.GetBgroundSrc().ApiEquals(b3));
            Assert.AreEqual(true, t1.GetBgroundSrc().Equals(b3));
            Assert.AreEqual(true, t1.GetDisplayChars() == 24);

            t1.SetFont(f3);
            t1.SetFontHeight(15);
            t1.SetIsDirty(true);
            t1.SetMaxLength(30);
            t1.SetMaxLengthOn(true);

            Assert.AreEqual(true, t1.GetFont().ApiEquals(f3));
            Assert.AreEqual(true, t1.GetFont().Equals(f3));
            Assert.AreEqual(true, t1.GetMaxLength() == 30);
            Assert.AreEqual(true, t1.GetMaxLengthOn() == true);

            v1 = new MmgVector2Int(32, 32);
            t1.SetPadding(8);
            t1.SetPosition(v1);
            t1.SetTextFieldString("Test textfield string");

            Assert.AreEqual(true, t1.GetPadding() == 8);
            Assert.AreEqual(true, t1.GetPosition().ApiEquals(v1));
            Assert.AreEqual(true, t1.GetPosition().Equals(v1));
            Assert.AreEqual(true, t1.GetTextFieldString().Equals("Test textfield string"));

            t1.SetX(88);
            t1.SetY(88);
            v1 = new MmgVector2Int(88, 88);
            Assert.AreEqual(true, t1.GetPosition().ApiEquals(v1));

            t2 = t1.CloneTyped();

            Assert.AreEqual(true, t1.ApiEquals(t1));
            Assert.AreEqual(true, t1.ApiEquals(t2));
            Assert.AreEqual(true, t2.ApiEquals(t1));
            Assert.AreEqual(true, t2.ApiEquals(t1));
            Assert.AreEqual(false, t3.ApiEquals(t1));
            Assert.AreEqual(false, t1.ApiEquals(t3));

            Assert.AreEqual(true, MmgTextField.DEFAULT_MAX_LENGTH == 20);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID == 1);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_TYPE == 0);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_CURSOR_BLINK_RATE_MS == 350L);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_CURSOR.Equals("_"));
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_9_SLICE_OFFSET == MmgHelper.ScaleValue(8));
        }

        [TestMethod]
        public void test2()
        {
            MmgBmp b1, b2, b3, b4, b5 = null;
            MmgFont f1, f2, f3 = null;
            MmgTextField t1, t2, t3 = null;
            MmgVector2Int v1 = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");

            f1 = MmgFontData.GetMmgFontBold();
            f2 = MmgFontData.GetMmgFontItalic();
            f3 = MmgFontData.GetMmgFontNorm();

            Mmg9Slice n1, n2 = null;

            b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
            b5 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");

            n1 = new Mmg9Slice(10, b4, 200, 200, MmgVector2.GetUnitVec());
            n2 = new Mmg9Slice(12, b5, 300, 300);

            t1 = new MmgTextField(new MmgTextField(b1, f1, 100, 100, 4, 20));
            t3 = new MmgTextField(b2, f2, 300, 300, 12, 20);

            Assert.AreEqual(true, t1.GetBgroundSrc().ApiEquals(b1));
            Assert.AreEqual(false, t1.GetBgroundSrc().Equals(b1));
            Assert.AreEqual(false, t1.GetFont().ApiEquals(f1));
            Assert.AreEqual(false, t1.GetFont().Equals(f1));
            Assert.AreEqual(true, t1.GetPadding() == 4);
            Assert.AreEqual(true, t1.GetDisplayChars() == 20);
            Assert.AreEqual(true, t1.GetWidth() == 100);
            Assert.AreEqual(true, t1.GetHeight() == 100);
            Assert.AreEqual(true, t1.GetMaxLength() == MmgTextField.DEFAULT_MAX_LENGTH);
            Assert.AreEqual(true, t1.GetTextFieldString().Equals(""));

            t1.SetBground(n1);
            t1.SetBgroundSrc(b3);
            t1.SetDisplayChars(24);

            Assert.AreEqual(true, t1.GetBground().ApiEquals(n1));
            Assert.AreEqual(true, t1.GetBground().Equals(n1));
            Assert.AreEqual(true, t1.GetBgroundSrc().ApiEquals(b3));
            Assert.AreEqual(true, t1.GetBgroundSrc().Equals(b3));
            Assert.AreEqual(true, t1.GetDisplayChars() == 24);

            t1.SetFont(f3);
            t1.SetFontHeight(15);
            t1.SetIsDirty(true);
            t1.SetMaxLength(30);
            t1.SetMaxLengthOn(true);

            Assert.AreEqual(true, t1.GetFont().ApiEquals(f3));
            Assert.AreEqual(true, t1.GetFont().Equals(f3));
            Assert.AreEqual(true, t1.GetMaxLength() == 30);
            Assert.AreEqual(true, t1.GetMaxLengthOn() == true);

            v1 = new MmgVector2Int(32, 32);
            t1.SetPadding(8);
            t1.SetPosition(v1);
            t1.SetTextFieldString("Test textfield string");

            Assert.AreEqual(true, t1.GetPadding() == 8);
            Assert.AreEqual(true, t1.GetPosition().ApiEquals(v1));
            Assert.AreEqual(true, t1.GetPosition().Equals(v1));
            Assert.AreEqual(true, t1.GetTextFieldString().Equals("Test textfield string"));

            t1.SetX(88);
            t1.SetY(88);
            v1 = new MmgVector2Int(88, 88);
            Assert.AreEqual(true, t1.GetPosition().ApiEquals(v1));

            t2 = t1.CloneTyped();

            Assert.AreEqual(true, t1.ApiEquals(t1));
            Assert.AreEqual(true, t1.ApiEquals(t2));
            Assert.AreEqual(true, t2.ApiEquals(t1));
            Assert.AreEqual(true, t2.ApiEquals(t1));
            Assert.AreEqual(false, t3.ApiEquals(t1));
            Assert.AreEqual(false, t1.ApiEquals(t3));

            Assert.AreEqual(true, MmgTextField.DEFAULT_MAX_LENGTH == 20);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID == 1);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_TYPE == 0);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_CURSOR_BLINK_RATE_MS == 350L);
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_CURSOR.Equals("_"));
            Assert.AreEqual(true, MmgTextField.TEXT_FIELD_9_SLICE_OFFSET == MmgHelper.ScaleValue(8));
        }
    }
}