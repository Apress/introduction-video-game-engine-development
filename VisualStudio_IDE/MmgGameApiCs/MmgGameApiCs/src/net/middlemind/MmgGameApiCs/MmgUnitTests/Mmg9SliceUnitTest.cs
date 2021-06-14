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
    public class Mmg9SliceUnitTest
    {
        public Mmg9SliceUnitTest()
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

        public void testStaticMembers()
        {
        }

        public void testEquals()
        {
            /*
            //VARS
            MmgBmp b1;
            MmgBmp b2;
            MmgBmp b3;
            MmgObj o1;
            MmgObj o2;
            Image i = null;
            String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";

            //TEST 1
            b1 = new MmgBmp();
            b2 = new MmgBmp();
            apiEqualityTests(b1, b2);

            //TEST 2
            o1 = new MmgObj(10, 10, 50, 50, true, MmgColor.GetBlack());
            o2 = new MmgObj(10, 10, 50, 50, true, MmgColor.GetBlack());
            b1 = new MmgBmp(o1);
            b2 = new MmgBmp(o2);
            apiEqualityTests(b1, b2);

            //TEST 3
            b3 = new MmgBmp();
            b1 = new MmgBmp(b3);
            b2 = new MmgBmp(b3);
            apiEqualityTests(b1, b2);

            //TEST 4
            try {
                i = ImageIO.read(new File(src));
            }catch(Exception e) {
                MmgApiUtils.wrErr(e);
            }

            b1 = new MmgBmp(i);
            b2 = new MmgBmp(i);
            apiEqualityTests(b1, b2);

            //TEST 5
            b1 = new MmgBmp(i, null, null, MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
            b2 = new MmgBmp(i, null, null, MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
            apiEqualityTests(b1, b2);

            //TEST 6
            b1 = new MmgBmp(i, MmgVector2.GetOriginVec(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
            b2 = new MmgBmp(i, MmgVector2.GetOriginVec(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
            apiEqualityTests(b1, b2);
            */
        }

        private void testEqualityMmg(Mmg9Slice o1, Mmg9Slice o2)
        {
            //VARS
            /*
            MmgVector2 o;
            MmgRect s;
            MmgRect d;
            Image i = null;
            String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";
            float r;

            //TEST 1
            Assert.AreEqual(true, b1.Equals(b2));

            //TEST 2
            o = new MmgVector2(20, 20);
            b1.SetOrigin(o);
            Assert.AreEqual(false, b1.Equals(b2));
            b2.SetOrigin(o);
            Assert.AreEqual(true, b1.Equals(b2));

            //TEST 3
            o = new MmgVector2(0.15, 0.15);
            b1.SetScaling(o);
            Assert.AreEqual(false, b1.Equals(b2));
            b2.SetScaling(o);
            Assert.AreEqual(true, b1.Equals(b2));

            //TEST 4
            s = new MmgRect(0, 0, 20, 20);
            b1.SetSrcRect(s);
            Assert.AreEqual(false, b1.Equals(b2));
            b2.SetSrcRect(s);
            Assert.AreEqual(true, b1.Equals(b2));

            //TEST 5
            d = new MmgRect(0, 0, 30, 30);
            b1.SetDstRect(d);
            Assert.AreEqual(false, b1.Equals(b2));
            b2.SetDstRect(d);
            Assert.AreEqual(true, b1.Equals(b2));

            //TEST 6        
            try {
                i = ImageIO.read(new File(src));
            }catch(Exception e) {
                MmgApiUtils.wrErr(e);
            }

            b1.SetImage(i);
            Assert.AreEqual(false, b1.Equals(b2));
            b2.SetImage(i);
            Assert.AreEqual(true, b1.Equals(b2));

            //TEST 7
            r = 90;
            b1.SetRotation(r);
            Assert.AreEqual(false, b1.Equals(b2));
            b2.SetRotation(r);
            Assert.AreEqual(true, b1.Equals(b2));

            //TEST 8 
            b1.DRAW_MODE = MmgBmp.MmgBmpDrawMode.DRAW_BMP_BASIC_CACHE;
            Assert.AreEqual(false, b1.Equals(b2));
            b2.DRAW_MODE = MmgBmp.MmgBmpDrawMode.DRAW_BMP_BASIC_CACHE;
            Assert.AreEqual(true, b1.Equals(b2));
            */
        }

        private void testEqualityJava(Mmg9Slice o1, Mmg9Slice o2)
        {

        }

        private void testGetAndSet(Mmg9Slice o1, Mmg9Slice o2)
        {

        }

        private void testClone(Mmg9Slice o1, Mmg9Slice o2)
        {

        }

        [TestMethod]
        public void testGettersSetters()
        {
            //VARS
            MmgBmp b1;
            String s;
            MmgRect d;
            Texture2D i = null;
            String src = "/Users/victor/Documents/files/visualstudio_workspace/MmgGameApiCs/MmgGameApiCs/cfg/drawable/auto_load/a_btn.png";
            MmgVector2 v;
            float f;

            //TEST 1
            b1 = new MmgBmp();
            s = "T1";
            b1.SetBmpIdStr(s);
            Assert.AreEqual(s, b1.GetBmpIdStr());

            //TEST 2
            d = new MmgRect(0, 0, 50, 50);
            b1.SetDstRect(d);
            Assert.AreEqual(true, d.Equals(b1.GetDstRect()));

            d = new MmgRect(0, 0, 100, 100);
            b1.SetSrcRect(d);
            Assert.AreEqual(true, d.Equals(b1.GetSrcRect()));

            //TEST 3        
            try
            {
                i = Texture2D.FromFile(MmgScreenData.GRAPHICS_CONFIG, src);
            }
            catch (Exception e)
            {
                MmgApiUtils.wrErr(e);
            }
            b1.SetImage(i);
            Assert.AreEqual(i, b1.GetImage());
            Assert.AreEqual(i, b1.GetTexture2D());

            b1.SetTexture2D(i);
            Assert.AreEqual(i, b1.GetImage());
            Assert.AreEqual(i, b1.GetTexture2D());

            //TEST 4
            v = new MmgVector2(100, 100);
            b1.SetOrigin(v);
            Assert.AreEqual(true, v.ApiEquals(b1.GetOrigin()));

            v = new MmgVector2(50, 50);
            b1.SetPosition(v);
            Assert.AreEqual(true, v.ApiEquals(b1.GetPosition()));

            v = new MmgVector2(2, 2);
            b1.SetScaling(v);
            Assert.AreEqual(true, v.ApiEquals(b1.GetScaling()));

            //TEST 5
            f = 32.0f;
            b1.SetRotation(f);
            Assert.AreEqual(f, b1.GetRotation(), MmgApiTestSuite.DELTA_D);

            int t = 25;
            f = 25.0f;
            b1.SetWidth(t);

            Assert.IsTrue(t == b1.GetUnscaledWidth());
            Assert.IsFalse(t == b1.GetWidth());
            Assert.IsTrue(f * v.GetX() == b1.GetWidth());
            Assert.IsFalse(f == b1.GetWidthFloat());
            Assert.IsTrue(f * v.GetXFloat() == b1.GetWidthFloat());

            t = 50;
            f = 50.0f;
            b1.SetHeight(t);
            Assert.IsTrue(t == b1.GetUnscaledHeight());
            Assert.IsFalse(t == b1.GetHeight());
            Assert.IsTrue(f * v.GetY() == b1.GetHeight());
            Assert.IsFalse(f == b1.GetHeightFloat());
            Assert.IsTrue(f * v.GetYFloat() == b1.GetHeightFloat());

            t = 100;
            Assert.IsTrue(t == b1.GetScaledHeight());

            t = 50;
            Assert.IsTrue(t == b1.GetScaledWidth());
        }

        [TestMethod]
        public void testCloning()
        {
            //VARS
            MmgBmp b1;
            MmgBmp b2;
            Texture2D i = null;
            String src = "/Users/victor/Documents/files/visualstudio_workspace/MmgGameApiCs/MmgGameApiCs/cfg/drawable/auto_load/a_btn.png";

            b1 = new MmgBmp();
            //TEST 3        
            try
            {
                i = Texture2D.FromFile(MmgScreenData.GRAPHICS_CONFIG, src);
            }
            catch (Exception e)
            {
                MmgApiUtils.wrErr(e);
            }
            b1.SetImage(i);
            b1.SetWidth(i.Width);
            b1.SetHeight(i.Height);
            b1.SetMmgColor(MmgColor.GetDarkBlue());
            b1.SetPosition(new MmgVector2(20, 20));
            b1.SetRotation(90.0f);
            b1.SetOrigin(MmgVector2.GetOriginVec());
            b1.SetScaling(new MmgVector2(2, 2));
            b1.SetDstRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));
            b1.SetSrcRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));

            b2 = b1.CloneTyped();
            Assert.IsTrue(b2.ApiEquals(b1));
            Assert.AreEqual(b2.GetWidth(), b1.GetWidth());
            Assert.AreEqual(b2.GetHeight(), b1.GetHeight());
            Assert.AreEqual(b2.GetImage(), b1.GetImage());
            Assert.AreEqual(b2.GetTexture2D(), b1.GetTexture2D());
            Assert.IsTrue(b2.GetMmgColor().ApiEquals(b1.GetMmgColor()));
            Assert.IsTrue(b2.GetPosition().ApiEquals(b1.GetPosition()));
            Assert.IsFalse((b2.GetBmpId() == b1.GetBmpId()));
            Assert.IsFalse((b2.GetBmpIdStr().Equals(b1.GetBmpIdStr())));
            Assert.IsTrue(b2.GetRotation() == b1.GetRotation());
            Assert.IsTrue(b2.GetOrigin().ApiEquals(b1.GetOrigin()));
            Assert.IsTrue(b2.GetSrcRect().ApiEquals(b1.GetSrcRect()));
            Assert.IsTrue(b2.GetDstRect().ApiEquals(b1.GetDstRect()));
            Assert.IsTrue(b1.GetScaledHeight() == b2.GetScaledHeight());
            Assert.IsTrue(b1.GetScaledWidth() == b2.GetScaledWidth());
            Assert.IsTrue(b1.GetUnscaledHeight() == b2.GetUnscaledHeight());
            Assert.IsTrue(b1.GetUnscaledWidth() == b2.GetUnscaledWidth());
            Assert.IsTrue(b1.GetHeightFloat() == b2.GetHeightFloat());
            Assert.IsTrue(b1.GetWidthFloat() == b2.GetWidthFloat());
            Assert.AreNotEqual(b2, b1);
            b1.SetPosition(new MmgVector2(100, 100));
            Assert.IsFalse(b1.GetPosition().ApiEquals(b2.GetPosition()));

            b1 = new MmgBmp();
            b1.SetImage(i);
            b1.SetWidth(i.Width);
            b1.SetHeight(i.Height);
            b1.SetMmgColor(MmgColor.GetDarkBlue());
            b1.SetPosition(new MmgVector2(20, 20));
            b1.SetRotation(90.0f);
            b1.SetOrigin(MmgVector2.GetOriginVec());
            b1.SetScaling(new MmgVector2(2, 2));
            b1.SetDstRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));
            b1.SetSrcRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));

            b2 = (MmgBmp)b1.Clone();
            Assert.IsTrue(b2.ApiEquals(b1));
            Assert.AreEqual(b2.GetWidth(), b1.GetWidth());
            Assert.AreEqual(b2.GetWidth(), b1.GetWidth());
            Assert.AreEqual(b2.GetImage(), b1.GetImage());
            Assert.AreEqual(b2.GetTexture2D(), b1.GetTexture2D());
            Assert.IsTrue(b2.GetMmgColor().ApiEquals(b1.GetMmgColor()));
            Assert.IsTrue(b2.GetPosition().ApiEquals(b1.GetPosition()));
            Assert.IsFalse((b2.GetBmpId() == b1.GetBmpId()));
            Assert.IsFalse((b2.GetBmpIdStr().Equals(b1.GetBmpIdStr())));
            Assert.IsTrue(b2.GetRotation() == b1.GetRotation());
            Assert.IsTrue(b2.GetOrigin().ApiEquals(b1.GetOrigin()));
            Assert.IsTrue(b2.GetSrcRect().ApiEquals(b1.GetSrcRect()));
            Assert.IsTrue(b2.GetDstRect().ApiEquals(b1.GetDstRect()));
            Assert.IsTrue(b1.GetScaledHeight() == b2.GetScaledHeight());
            Assert.IsTrue(b1.GetScaledWidth() == b2.GetScaledWidth());
            Assert.IsTrue(b1.GetUnscaledHeight() == b2.GetUnscaledHeight());
            Assert.IsTrue(b1.GetUnscaledWidth() == b2.GetUnscaledWidth());
            Assert.IsTrue(b1.GetHeightFloat() == b2.GetHeightFloat());
            Assert.IsTrue(b1.GetWidthFloat() == b2.GetWidthFloat());
            Assert.AreNotEqual(b2, b1);
            b1.SetPosition(new MmgVector2(100, 100));
            Assert.IsFalse(b1.GetPosition().ApiEquals(b2.GetPosition()));
        }

        [TestMethod]
        public void testConstructors()
        {
            MmgBmp b1;
            MmgBmp b2;

            b1 = new MmgBmp();
            Assert.IsTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
            Assert.IsTrue(b1.GetScaling().ApiEquals(new MmgVector2(1, 1)));
            Assert.IsTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
            Assert.IsTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
            Assert.IsNull(b1.GetImage());
            Assert.IsNull(b1.GetTexture2D());
            Assert.IsTrue(b1.GetRotation() == 0f);
            Assert.IsTrue(b1.GetHeight() == 0);
            Assert.IsTrue(b1.GetHeightFloat() == 0.0f);
            Assert.IsTrue(b1.GetWidth() == 0);
            Assert.IsTrue(b1.GetWidthFloat() == 0.0f);
            Assert.IsTrue(b1.GetUnscaledHeight() == 0);
            Assert.IsTrue(b1.GetUnscaledWidth() == 0);
            Assert.IsTrue(b1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
            Assert.IsTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            MmgObj obj = new MmgObj();
            obj.SetWidth(20);
            obj.SetHeight(20);
            b1 = new MmgBmp(obj);

            Assert.IsTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
            Assert.IsTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.IsTrue(b1.GetScaling().ApiEquals(new MmgVector2(1, 1)));
            Assert.IsTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
            Assert.IsTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
            Assert.IsNull(b1.GetImage());
            Assert.IsNull(b1.GetTexture2D());
            Assert.IsTrue(b1.GetRotation() == 0f);
            MmgHelper.wr("=========GetHeight: " + b1.GetHeight() + " H: " + ((MmgObj)b1).GetHeight());
            Assert.IsTrue(b1.GetHeight() == 20);
            Assert.IsTrue(b1.GetHeightFloat() == 20.0f);
            Assert.IsTrue(b1.GetWidth() == 20);
            Assert.IsTrue(b1.GetWidthFloat() == 20.0f);
            Assert.IsTrue(b1.GetUnscaledHeight() == 20);
            Assert.IsTrue(b1.GetUnscaledWidth() == 20);
            Assert.IsTrue(b1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
            Assert.IsTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            b2 = new MmgBmp(b1);
            Assert.IsTrue(b2.ApiEquals(b1));
            Assert.AreEqual(b2.GetWidth(), b1.GetWidth());
            Assert.AreEqual(b2.GetImage(), b1.GetImage());
            Assert.IsNull(b1.GetTexture2D());
            Assert.IsTrue(b2.GetMmgColor().ApiEquals(b1.GetMmgColor()));
            Assert.IsTrue(b2.GetPosition().ApiEquals(b1.GetPosition()));
            Assert.IsFalse((b2.GetBmpId() == b1.GetBmpId()));
            Assert.IsFalse((b2.GetBmpIdStr().Equals(b1.GetBmpIdStr())));
            Assert.IsTrue(b2.GetRotation() == b1.GetRotation());
            Assert.IsTrue(b2.GetOrigin().ApiEquals(b1.GetOrigin()));
            Assert.IsTrue(b2.GetScaling().ApiEquals(b1.GetScaling()));
            Assert.IsTrue(b2.GetSrcRect().ApiEquals(b1.GetSrcRect()));
            Assert.IsTrue(b2.GetDstRect().ApiEquals(b1.GetDstRect()));
            Assert.IsTrue(b1.GetScaledHeight() == b2.GetScaledHeight());
            Assert.IsTrue(b1.GetScaledWidth() == b2.GetScaledWidth());
            Assert.IsTrue(b1.GetUnscaledHeight() == b2.GetUnscaledHeight());
            Assert.IsTrue(b1.GetUnscaledWidth() == b2.GetUnscaledWidth());
            Assert.IsTrue(b1.GetHeightFloat() == b2.GetHeightFloat());
            Assert.IsTrue(b1.GetWidthFloat() == b2.GetWidthFloat());
            Assert.AreNotEqual(b2, b1);
            b1.SetPosition(new MmgVector2(100, 100));
            Assert.IsFalse(b1.GetPosition().ApiEquals(b2.GetPosition()));

            Texture2D i = null;
            String src = "/Users/victor/Documents/files/visualstudio_workspace/MmgGameApiCs/MmgGameApiCs/cfg/drawable/auto_load/a_btn.png";

            b1 = new MmgBmp();
            //TEST 3        
            try
            {
                i = Texture2D.FromFile(MmgScreenData.GRAPHICS_CONFIG, src);
            }
            catch (Exception e)
            {
                MmgApiUtils.wrErr(e);
            }
            b1 = new MmgBmp(i);
            Assert.IsTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
            Assert.IsTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.IsTrue(b1.GetScaling().ApiEquals(new MmgVector2(1, 1)));
            Assert.IsTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth())));
            Assert.IsTrue(b1.GetDstRect() == null);
            Assert.IsNotNull(b1.GetImage());
            Assert.IsTrue(b1.GetRotation() == 0f);
            Assert.IsTrue(b1.GetHeight() == 64);
            Assert.IsTrue(b1.GetHeightFloat() == 64.0f);
            Assert.IsTrue(b1.GetWidth() == 64);
            Assert.IsTrue(b1.GetWidthFloat() == 64.0f);
            Assert.IsTrue(b1.GetUnscaledHeight() == 64);
            Assert.IsTrue(b1.GetUnscaledWidth() == 64);
            Assert.IsTrue(b1.GetMmgColor() == null);
            Assert.IsTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            b1 = new MmgBmp(i, MmgRect.GetUnitRect(), new MmgRect(0, 0, 2, 2), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
            Assert.IsTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
            Assert.IsTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.IsTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
            Assert.IsTrue(b1.GetDstRect().ApiEquals(new MmgRect(0, 0, 2, 2)));
            Assert.IsNotNull(b1.GetImage());
            Assert.IsTrue(b1.GetRotation() == 45.0f);
            Assert.IsTrue(b1.GetHeight() == 64);
            Assert.IsTrue(b1.GetHeightFloat() == 64.0f);
            Assert.IsTrue(b1.GetWidth() == 64);
            Assert.IsTrue(b1.GetWidthFloat() == 64.0f);
            Assert.IsTrue(b1.GetUnscaledHeight() == 64);
            Assert.IsTrue(b1.GetUnscaledWidth() == 64);
            Assert.IsTrue(b1.GetMmgColor() == null);
            Assert.IsTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            b1 = new MmgBmp(i, MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), MmgVector2.GetUnitVec(), 45.0f);
            Assert.IsTrue(b1.GetOrigin().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.IsTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
            Assert.IsTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth())));
            Assert.IsTrue(b1.GetDstRect() == null);
            Assert.IsNotNull(b1.GetImage());
            Assert.IsTrue(b1.GetRotation() == 45.0f);
            Assert.IsTrue(b1.GetHeight() == 64);
            Assert.IsTrue(b1.GetHeightFloat() == 64.0f);
            Assert.IsTrue(b1.GetWidth() == 64);
            Assert.IsTrue(b1.GetWidthFloat() == 64.0f);
            Assert.IsTrue(b1.GetUnscaledHeight() == 64);
            Assert.IsTrue(b1.GetUnscaledWidth() == 64);
            Assert.IsTrue(b1.GetMmgColor() == null);
            Assert.IsTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
        }

        [TestMethod]
        public void testScaling()
        {
            //VARS
            MmgBmp b1;
            Texture2D i = null;
            String src = "/Users/victor/Documents/files/visualstudio_workspace/MmgGameApiCs/MmgGameApiCs/cfg/drawable/auto_load/a_btn.png";

            b1 = new MmgBmp();
            //TEST 3        
            try
            {
                i = Texture2D.FromFile(MmgScreenData.GRAPHICS_CONFIG, src);
            }
            catch (Exception e)
            {
                MmgApiUtils.wrErr(e);
            }
            b1.SetImage(i);
            b1.SetWidth(i.Width);
            b1.SetHeight(i.Height);
            b1.SetMmgColor(MmgColor.GetDarkBlue());
            b1.SetPosition(new MmgVector2(20, 20));
            b1.SetRotation(90.0f);
            b1.SetScaling(new MmgVector2(2, 2));
            b1.SetOrigin(MmgVector2.GetOriginVec());
            b1.SetDstRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));
            b1.SetSrcRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));

            //System.err.println("B1.ScaledHeight: " + b1.GetScaledHeight() + " ScalingX: " + b1.GetScaling().GetXDouble() + " GetHeight: " + b1.GetHeight());
            Assert.IsTrue(b1.GetScaledHeight() == (64 * 2));
            Assert.IsTrue(b1.GetScaledWidth() == (64 * 2));
            Assert.IsTrue(b1.GetUnscaledHeight() == 64);
            Assert.IsTrue(b1.GetUnscaledWidth() == 64);
            Assert.IsTrue(b1.GetHeightFloat() == 128.0f);
            Assert.IsTrue(b1.GetWidthFloat() == 128.0f);
            b1.SetPosition(new MmgVector2(100, 100));
            Assert.IsTrue(b1.GetPosition().ApiEquals(new MmgVector2(100, 100)));
        }
    }
}