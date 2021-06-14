using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework.Graphics;
using net.middlemind.MmgGameApiCs.MmgBase;

//Converted
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgBmpUnitTest_2
    {
        public MmgBmpUnitTest_2()
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
            MmgBmp b1, b2, b3 = null;
            MmgRect r1 = null;
            MmgVector2 v1 = null;

            b1 = new MmgBmp();
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetImage() == null);
            Assert.AreEqual(true, b1.GetRotation() == 0f);

            b1.SetBmpIdStr("Test String");

            Assert.AreEqual(true, b1.GetBmpIdStr().Equals("Test String"));

            r1 = new MmgRect(0, 0, 10, 10);
            b1.SetDstRect(r1);

            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetDstRect().Equals(r1));

            b1.SetImage(b2.GetImage());

            Assert.AreEqual(true, b1.GetImage().Equals(b2.GetImage()));

            v1 = new MmgVector2(20, 20);
            b1.SetOrigin(v1);

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetOrigin().Equals(v1));

            b1.SetRotation(90.0f);

            Assert.AreEqual(true, b1.GetRotation() == 90.0f);

            v1 = new MmgVector2(24, 24);
            b1.SetScaling(v1);

            Assert.AreEqual(true, b1.GetScaling().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetScaling().Equals(v1));

            r1 = new MmgRect(0, 0, 12, 12);
            b1.SetSrcRect(r1);

            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetSrcRect().Equals(r1));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }

        [TestMethod]
        public void test2()
        {
            MmgBmp b1, b2, b3 = null;
            MmgRect r1 = null;
            MmgVector2 v1 = null;

            b1 = new MmgBmp(new MmgObj(10, 10));
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetImage() == null);
            Assert.AreEqual(true, b1.GetRotation() == 0f);

            b1.SetBmpIdStr("Test String");

            Assert.AreEqual(true, b1.GetBmpIdStr().Equals("Test String"));

            r1 = new MmgRect(0, 0, 10, 10);
            b1.SetDstRect(r1);

            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetDstRect().Equals(r1));

            b1.SetImage(b2.GetImage());

            Assert.AreEqual(true, b1.GetImage().Equals(b2.GetImage()));

            v1 = new MmgVector2(20, 20);
            b1.SetOrigin(v1);

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetOrigin().Equals(v1));

            b1.SetRotation(90.0f);

            Assert.AreEqual(true, b1.GetRotation() == 90.0f);

            v1 = new MmgVector2(24, 24);
            b1.SetScaling(v1);

            Assert.AreEqual(true, b1.GetScaling().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetScaling().Equals(v1));

            r1 = new MmgRect(0, 0, 12, 12);
            b1.SetSrcRect(r1);

            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetSrcRect().Equals(r1));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }

        [TestMethod]
        public void test3()
        {
            MmgBmp b1, b2, b3 = null;
            MmgRect r1 = null;
            MmgVector2 v1 = null;

            b1 = new MmgBmp(new MmgBmp(new MmgObj(10, 10)));
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetImage() == null);
            Assert.AreEqual(true, b1.GetRotation() == 0f);

            b1.SetBmpIdStr("Test String");

            Assert.AreEqual(true, b1.GetBmpIdStr().Equals("Test String"));

            r1 = new MmgRect(0, 0, 10, 10);
            b1.SetDstRect(r1);

            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetDstRect().Equals(r1));

            b1.SetImage(b2.GetImage());

            Assert.AreEqual(true, b1.GetImage().Equals(b2.GetImage()));

            v1 = new MmgVector2(20, 20);
            b1.SetOrigin(v1);

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetOrigin().Equals(v1));

            b1.SetRotation(90.0f);

            Assert.AreEqual(true, b1.GetRotation() == 90.0f);

            v1 = new MmgVector2(24, 24);
            b1.SetScaling(v1);

            Assert.AreEqual(true, b1.GetScaling().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetScaling().Equals(v1));

            r1 = new MmgRect(0, 0, 12, 12);
            b1.SetSrcRect(r1);

            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetSrcRect().Equals(r1));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }

        [TestMethod]
        public void test4()
        {
            MmgBmp b1, b2, b3 = null;
            MmgRect r1 = null;
            MmgVector2 v1 = null;

            b1 = new MmgBmp(MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png").GetImage());
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(false, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetDstRect() == null);
            Assert.AreEqual(false, b1.GetImage() == null);
            Assert.AreEqual(true, b1.GetRotation() == 0f);

            b1.SetBmpIdStr("Test String");

            Assert.AreEqual(true, b1.GetBmpIdStr().Equals("Test String"));

            r1 = new MmgRect(0, 0, 10, 10);
            b1.SetDstRect(r1);

            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetDstRect().Equals(r1));

            b1.SetImage(b2.GetImage());

            Assert.AreEqual(true, b1.GetImage().Equals(b2.GetImage()));

            v1 = new MmgVector2(20, 20);
            b1.SetOrigin(v1);

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetOrigin().Equals(v1));

            b1.SetRotation(90.0f);

            Assert.AreEqual(true, b1.GetRotation() == 90.0f);

            v1 = new MmgVector2(24, 24);
            b1.SetScaling(v1);

            Assert.AreEqual(true, b1.GetScaling().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetScaling().Equals(v1));

            r1 = new MmgRect(0, 0, 12, 12);
            b1.SetSrcRect(r1);

            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetSrcRect().Equals(r1));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }

        [TestMethod]
        public void test5()
        {
            MmgBmp b1, b2, b3 = null;
            MmgRect r1 = null;
            MmgVector2 v1 = null;

            b1 = new MmgBmp(MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png").GetImage(), MmgRect.GetUnitRect(), MmgRect.GetUnitRect(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(false, b1.GetDstRect() == null);
            Assert.AreEqual(false, b1.GetImage() == null);
            Assert.AreEqual(true, b1.GetRotation() == 0f);

            b1.SetBmpIdStr("Test String");

            Assert.AreEqual(true, b1.GetBmpIdStr().Equals("Test String"));

            r1 = new MmgRect(0, 0, 10, 10);
            b1.SetDstRect(r1);

            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetDstRect().Equals(r1));

            b1.SetImage(b2.GetImage());

            Assert.AreEqual(true, b1.GetImage().Equals(b2.GetImage()));

            v1 = new MmgVector2(20, 20);
            b1.SetOrigin(v1);

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetOrigin().Equals(v1));

            b1.SetRotation(90.0f);

            Assert.AreEqual(true, b1.GetRotation() == 90.0f);

            v1 = new MmgVector2(24, 24);
            b1.SetScaling(v1);

            Assert.AreEqual(true, b1.GetScaling().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetScaling().Equals(v1));

            r1 = new MmgRect(0, 0, 12, 12);
            b1.SetSrcRect(r1);

            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetSrcRect().Equals(r1));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }

        [TestMethod]
        public void test6()
        {
            MmgBmp b1, b2, b3 = null;
            MmgRect r1 = null;
            MmgVector2 v1 = null;

            b1 = new MmgBmp(MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png").GetImage(), MmgVector2.GetOriginVec(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
            b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.AreEqual(false, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
            Assert.AreEqual(true, b1.GetDstRect() == null);
            Assert.AreEqual(false, b1.GetImage() == null);
            Assert.AreEqual(true, b1.GetRotation() == 0f);

            b1.SetBmpIdStr("Test String");

            Assert.AreEqual(true, b1.GetBmpIdStr().Equals("Test String"));

            r1 = new MmgRect(0, 0, 10, 10);
            b1.SetDstRect(r1);

            Assert.AreEqual(true, b1.GetDstRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetDstRect().Equals(r1));

            b1.SetImage(b2.GetImage());

            Assert.AreEqual(true, b1.GetImage().Equals(b2.GetImage()));

            v1 = new MmgVector2(20, 20);
            b1.SetOrigin(v1);

            Assert.AreEqual(true, b1.GetOrigin().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetOrigin().Equals(v1));

            b1.SetRotation(90.0f);

            Assert.AreEqual(true, b1.GetRotation() == 90.0f);

            v1 = new MmgVector2(24, 24);
            b1.SetScaling(v1);

            Assert.AreEqual(true, b1.GetScaling().ApiEquals(v1));
            Assert.AreEqual(true, b1.GetScaling().Equals(v1));

            r1 = new MmgRect(0, 0, 12, 12);
            b1.SetSrcRect(r1);

            Assert.AreEqual(true, b1.GetSrcRect().ApiEquals(r1));
            Assert.AreEqual(true, b1.GetSrcRect().Equals(r1));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }
    }
}