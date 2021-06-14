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
    public class MmgSpriteUnitTest_2
    {
        public MmgSpriteUnitTest_2()
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
            MmgBmp frame1, frame2, frame3 = null;
            MmgBmp[] frames1, frames2 = null;
            MmgSprite sprite1, sprite2, sprite3 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            frame1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame1);

            frame2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame2);

            frame3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
            frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame3);

            frames1 = new MmgBmp[4];
            frames1[0] = frame1;
            frames1[1] = frame2;
            frames1[2] = frame3;
            frames1[3] = frame2;

            frames2 = new MmgBmp[4];
            frames2[0] = frame1;
            frames2[1] = frame2;
            frames2[2] = frame3;

            sprite1 = new MmgSprite(frames1, frame1.GetPosition().Clone());
            sprite1.SetFrameTime(200L);

            sprite3 = new MmgSprite(frames2, frame1.GetPosition().Clone());
            sprite3.SetFrameTime(200L);

            Assert.AreEqual(sprite1.GetRotation(), 0.0f, 0.01);
            Assert.AreEqual(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, sprite1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(sprite1.GetSrcRect(), null);
            Assert.AreEqual(sprite1.GetDstRect(), null);
            Assert.AreEqual(true, sprite1.GetBmpArray().Equals(frames1));
            Assert.AreEqual(true, sprite1.GetPosition().ApiEquals(frame1.GetPosition()));
            Assert.AreEqual(sprite1.GetIsVisible(), true);
            Assert.AreEqual(sprite1.GetSimpleRendering(), true);
            Assert.AreEqual(sprite1.GetMsPerFrame(), 100L);
            Assert.AreEqual(sprite1.GetFrameTime(), 200L);

            sprite2 = (MmgSprite)sprite1.Clone();

            Assert.AreEqual(true, sprite1.ApiEquals(sprite2));
            Assert.AreEqual(true, sprite2.ApiEquals(sprite1));
            Assert.AreEqual(true, sprite1.ApiEquals(sprite1));
            Assert.AreEqual(false, sprite1.ApiEquals(null));
            Assert.AreEqual(false, sprite1.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite2.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite3.ApiEquals(sprite2));

            sprite2 = sprite1.CloneTyped();

            Assert.AreEqual(true, sprite1.ApiEquals(sprite2));
            Assert.AreEqual(true, sprite2.ApiEquals(sprite1));
            Assert.AreEqual(true, sprite1.ApiEquals(sprite1));
            Assert.AreEqual(false, sprite1.ApiEquals(null));
            Assert.AreEqual(false, sprite1.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite2.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite3.ApiEquals(sprite2));

            sprite1.SetTimerOnly(true);

            sprite1.SetSrcRect(MmgRect.GetUnitRect());

            Assert.AreEqual(true, sprite1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));

            sprite1.SetDstRect(MmgRect.GetUnitRect());

            Assert.AreEqual(true, sprite1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));

            sprite1.SetPrevFrameTime(300);

            Assert.AreEqual(sprite1.GetPrevFrameTime(), 300);

            sprite1.SetOrigin(MmgVector2.GetOriginVec());

            Assert.AreEqual(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));

            sprite1.SetMsPerFrame(500);

            Assert.AreEqual(sprite1.GetMsPerFrame(), 500, 0);

            sprite1.SetFrameTime(2000L);

            Assert.AreEqual(sprite1.GetFrameTime(), 2000L, 0);

            sprite1.SetFrameStop(5);

            Assert.AreEqual(sprite1.GetFrameStop(), 5, 0);

            sprite1.SetFrameStart(1);

            Assert.AreEqual(sprite1.GetFrameStart(), 1, 0);

            sprite1.SetFrameIdx(3);

            Assert.AreEqual(sprite1.GetFrameIdx(), 3, 0);

            sprite1.SetCurrentFrame(frame1);

            Assert.AreEqual(true, sprite1.GetBmpArray()[sprite1.GetFrameIdx()].Equals(frame1));
        }

        [TestMethod]
        public void test2()
        {
            MmgBmp frame1, frame2, frame3 = null;
            MmgBmp[] frames1, frames2 = null;
            MmgSprite sprite1, sprite2, sprite3 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            frame1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame1);

            frame2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame2);

            frame3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
            frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame3);

            frames1 = new MmgBmp[4];
            frames1[0] = frame1;
            frames1[1] = frame2;
            frames1[2] = frame3;
            frames1[3] = frame2;

            frames2 = new MmgBmp[4];
            frames2[0] = frame1;
            frames2[1] = frame2;
            frames2[2] = frame3;

            sprite1 = new MmgSprite(frames1, frame1.GetPosition().Clone(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
            sprite1.SetFrameTime(200L);

            sprite3 = new MmgSprite(frames2, frame1.GetPosition().Clone());
            sprite3.SetFrameTime(200L);

            Assert.AreEqual(sprite1.GetRotation(), 0.0f, 0.01);
            Assert.AreEqual(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, sprite1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(true, sprite1.GetSrcRect().ApiEquals(new MmgRect(sprite1.GetPosition(), frame1.GetWidth(), frame1.GetHeight())));
            Assert.AreEqual(sprite1.GetDstRect(), null);
            Assert.AreEqual(true, sprite1.GetBmpArray().Equals(frames1));
            Assert.AreEqual(true, sprite1.GetPosition().ApiEquals(frame1.GetPosition()));
            Assert.AreEqual(sprite1.GetIsVisible(), true);
            Assert.AreEqual(sprite1.GetSimpleRendering(), true);
            Assert.AreEqual(sprite1.GetMsPerFrame(), 100L);
            Assert.AreEqual(sprite1.GetFrameTime(), 200L);

            sprite2 = (MmgSprite)sprite1.Clone();

            Assert.AreEqual(true, sprite1.ApiEquals(sprite2));
            Assert.AreEqual(true, sprite2.ApiEquals(sprite1));
            Assert.AreEqual(true, sprite1.ApiEquals(sprite1));
            Assert.AreEqual(false, sprite1.ApiEquals(null));
            Assert.AreEqual(false, sprite1.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite2.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite3.ApiEquals(sprite2));

            sprite2 = sprite1.CloneTyped();

            Assert.AreEqual(true, sprite1.ApiEquals(sprite2));
            Assert.AreEqual(true, sprite2.ApiEquals(sprite1));
            Assert.AreEqual(true, sprite1.ApiEquals(sprite1));
            Assert.AreEqual(false, sprite1.ApiEquals(null));
            Assert.AreEqual(false, sprite1.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite2.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite3.ApiEquals(sprite2));

            sprite1.SetTimerOnly(true);

            sprite1.SetSrcRect(MmgRect.GetUnitRect());

            Assert.AreEqual(true, sprite1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));

            sprite1.SetDstRect(MmgRect.GetUnitRect());

            Assert.AreEqual(true, sprite1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));

            sprite1.SetPrevFrameTime(300);

            Assert.AreEqual(sprite1.GetPrevFrameTime(), 300);

            sprite1.SetOrigin(MmgVector2.GetOriginVec());

            Assert.AreEqual(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));

            sprite1.SetMsPerFrame(500);

            Assert.AreEqual(sprite1.GetMsPerFrame(), 500, 0);

            sprite1.SetFrameTime(2000L);

            Assert.AreEqual(sprite1.GetFrameTime(), 2000L, 0);

            sprite1.SetFrameStop(5);

            Assert.AreEqual(sprite1.GetFrameStop(), 5, 0);

            sprite1.SetFrameStart(1);

            Assert.AreEqual(sprite1.GetFrameStart(), 1, 0);

            sprite1.SetFrameIdx(3);

            Assert.AreEqual(sprite1.GetFrameIdx(), 3, 0);

            sprite1.SetCurrentFrame(frame1);

            Assert.AreEqual(true, sprite1.GetBmpArray()[sprite1.GetFrameIdx()].Equals(frame1));
        }

        [TestMethod]
        public void test3()
        {
            MmgBmp frame1, frame2, frame3 = null;
            MmgBmp[] frames1, frames2 = null;
            MmgSprite sprite1, sprite2, sprite3 = null;

            MmgScreenData.SetScale(MmgVector2.GetUnitVec());

            frame1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame1);

            frame2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
            frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame2);

            frame3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
            frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame3);

            frames1 = new MmgBmp[4];
            frames1[0] = frame1;
            frames1[1] = frame2;
            frames1[2] = frame3;
            frames1[3] = frame2;

            frames2 = new MmgBmp[4];
            frames2[0] = frame1;
            frames2[1] = frame2;
            frames2[2] = frame3;

            sprite1 = new MmgSprite(frames1, new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth()), new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth()), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
            sprite1.SetFrameTime(200L);

            sprite3 = new MmgSprite(frames2, frame1.GetPosition().Clone());
            sprite3.SetFrameTime(200L);

            Assert.AreEqual(sprite1.GetRotation(), 0.0f, 0.01);
            Assert.AreEqual(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, sprite1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(true, sprite1.GetSrcRect().ApiEquals(new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth())));
            Assert.AreEqual(true, sprite1.GetDstRect().ApiEquals(new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth())));
            Assert.AreEqual(true, sprite1.GetBmpArray().Equals(frames1));
            Assert.AreEqual(true, sprite1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(sprite1.GetIsVisible(), true);
            Assert.AreEqual(sprite1.GetSimpleRendering(), true);
            Assert.AreEqual(sprite1.GetMsPerFrame(), 100L);
            Assert.AreEqual(sprite1.GetFrameTime(), 200L);

            sprite2 = (MmgSprite)sprite1.Clone();

            Assert.AreEqual(true, sprite1.ApiEquals(sprite2));
            Assert.AreEqual(true, sprite2.ApiEquals(sprite1));
            Assert.AreEqual(true, sprite1.ApiEquals(sprite1));
            Assert.AreEqual(false, sprite1.ApiEquals(null));
            Assert.AreEqual(false, sprite1.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite2.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite3.ApiEquals(sprite2));

            sprite2 = sprite1.CloneTyped();

            Assert.AreEqual(true, sprite1.ApiEquals(sprite2));
            Assert.AreEqual(true, sprite2.ApiEquals(sprite1));
            Assert.AreEqual(true, sprite1.ApiEquals(sprite1));
            Assert.AreEqual(false, sprite1.ApiEquals(null));
            Assert.AreEqual(false, sprite1.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite2.ApiEquals(sprite3));
            Assert.AreEqual(false, sprite3.ApiEquals(sprite2));

            sprite1.SetTimerOnly(true);

            sprite1.SetSrcRect(MmgRect.GetUnitRect());

            Assert.AreEqual(true, sprite1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));

            sprite1.SetDstRect(MmgRect.GetUnitRect());

            Assert.AreEqual(true, sprite1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));

            sprite1.SetPrevFrameTime(300);

            Assert.AreEqual(sprite1.GetPrevFrameTime(), 300);

            sprite1.SetOrigin(MmgVector2.GetOriginVec());

            Assert.AreEqual(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));

            sprite1.SetMsPerFrame(500);

            Assert.AreEqual(sprite1.GetMsPerFrame(), 500, 0);

            sprite1.SetFrameTime(2000L);

            Assert.AreEqual(sprite1.GetFrameTime(), 2000L, 0);

            sprite1.SetFrameStop(5);

            Assert.AreEqual(sprite1.GetFrameStop(), 5, 0);

            sprite1.SetFrameStart(1);

            Assert.AreEqual(sprite1.GetFrameStart(), 1, 0);

            sprite1.SetFrameIdx(3);

            Assert.AreEqual(sprite1.GetFrameIdx(), 3, 0);

            sprite1.SetCurrentFrame(frame1);

            Assert.AreEqual(true, sprite1.GetBmpArray()[sprite1.GetFrameIdx()].Equals(frame1));
        }
    }
}