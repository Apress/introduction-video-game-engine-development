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
    public class MmgSpriteSheetUnitTest_2
    {
        public MmgSpriteSheetUnitTest_2()
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
            MmgSpriteSheet s1, s2, s3 = null;
            MmgBmp[] ba1 = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "knight_run_spritesheet.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
            s1 = new MmgSpriteSheet(b1, 16, 16);
            s3 = new MmgSpriteSheet(b2, b2.GetWidth(), b2.GetHeight());

            ba1 = new MmgBmp[3];
            ba1[0] = b2;
            ba1[1] = b3;
            ba1[2] = b4;

            Assert.AreEqual(true, s1.GetSrc().ApiEquals(b1));
            Assert.AreEqual(true, s1.GetSrc().Equals(b1));

            s1.SetFrame(b4, 0);

            Assert.AreEqual(true, s1.GetFrame(0).ApiEquals(b4));
            Assert.AreEqual(true, s1.GetFrame(0).Equals(b4));

            s1.SetFrames(ba1);

            Assert.AreEqual(true, s1.GetFrames().Equals(ba1));

            s1.SetHeight(64);
            s1.SetWidth(64);

            Assert.AreEqual(true, s1.GetHeight() == 64);
            Assert.AreEqual(true, s1.GetWidth() == 64);

            s1.SetSrc(b2);

            Assert.AreEqual(true, s1.GetSrc().ApiEquals(b2));
            Assert.AreEqual(true, s1.GetSrc().Equals(b2));

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
            MmgBmp b1, b2, b3, b4 = null;
            MmgSpriteSheet s1, s2, s3 = null;
            MmgBmp[] ba1 = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "knight_run_spritesheet.png");
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
            s1 = new MmgSpriteSheet(new MmgSpriteSheet(b1, 16, 16));
            s3 = new MmgSpriteSheet(b2, b2.GetWidth(), b2.GetHeight());

            ba1 = new MmgBmp[3];
            ba1[0] = b2;
            ba1[1] = b3;
            ba1[2] = b4;

            Assert.AreEqual(true, s1.GetSrc().ApiEquals(b1));
            Assert.AreEqual(false, s1.GetSrc().Equals(b1));

            s1.SetFrame(b4, 0);

            Assert.AreEqual(true, s1.GetFrame(0).ApiEquals(b4));
            Assert.AreEqual(true, s1.GetFrame(0).Equals(b4));

            s1.SetFrames(ba1);

            Assert.AreEqual(true, s1.GetFrames().Equals(ba1));

            s1.SetHeight(64);
            s1.SetWidth(64);

            Assert.AreEqual(true, s1.GetHeight() == 64);
            Assert.AreEqual(true, s1.GetWidth() == 64);

            s1.SetSrc(b2);

            Assert.AreEqual(true, s1.GetSrc().ApiEquals(b2));
            Assert.AreEqual(true, s1.GetSrc().Equals(b2));

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
