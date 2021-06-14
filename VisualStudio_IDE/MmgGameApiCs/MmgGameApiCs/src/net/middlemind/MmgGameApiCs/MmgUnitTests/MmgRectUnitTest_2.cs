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
    public class MmgRectUnitTest_2
    {
        public MmgRectUnitTest_2()
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
            MmgRect r1;
            MmgRect r2;
            Rectangle r3;
            int i1, i2, i3, i4, i5, i6;
            String s1;

            r1 = new MmgRect();
            r2 = r1.Clone();

            Assert.AreEqual(true, r1.ApiEquals(r2));
            Assert.AreEqual(true, r2.ApiEquals(r1));
            Assert.AreEqual(true, r1.ApiEquals(r1));

            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());

            Assert.AreEqual(1, r1.GetHeight());
            Assert.AreEqual(1, r1.GetWidth());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r3 = r1.GetRect();
            Assert.AreEqual(0, r3.X);
            Assert.AreEqual(0, r3.Y);
            Assert.AreEqual(1, r3.Width);
            Assert.AreEqual(1, r3.Height);

            r1.SetHeight(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(1, r1.GetRight());

            r1.SetWidth(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(10, r1.GetRight());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r1.SetPosition(MmgVector2.GetUnitVec());
            Assert.AreEqual(1, r1.GetTop());
            Assert.AreEqual(1, r1.GetLeft());
            Assert.AreEqual(11, r1.GetBottom());
            Assert.AreEqual(11, r1.GetRight());

            r1.SetPosition(2, 2);
            Assert.AreEqual(2, r1.GetTop());
            Assert.AreEqual(2, r1.GetLeft());
            Assert.AreEqual(12, r1.GetBottom());
            Assert.AreEqual(12, r1.GetRight());

            i1 = r1.GetDiffX(0, MmgDir.DIR_LEFT, true);     //-2
            i2 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, true);    //-12
            i3 = r1.GetDiffX(0, MmgDir.DIR_LEFT, false);    //2
            i4 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, false);   //12
            i5 = r1.GetDiffX(0, MmgDir.DIR_TOP, false);     //0 
            i6 = r1.GetDiffX(0, MmgDir.DIR_BOTTOM, false);     //0         

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(0, MmgDir.DIR_TOP, true);      //-2
            i2 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, true);   //-12
            i3 = r1.GetDiffY(0, MmgDir.DIR_TOP, false);     //2
            i4 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, false);  //12
            i5 = r1.GetDiffY(0, MmgDir.DIR_LEFT, false);    //0
            i6 = r1.GetDiffY(0, MmgDir.DIR_RIGHT, false);   //0

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            r3 = new Rectangle(4, 4, 20, 20);
            r1.SetRect(r3);
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(24, r1.GetBottom());
            Assert.AreEqual(24, r1.GetRight());
            Assert.AreEqual(20, r1.GetWidth());
            Assert.AreEqual(20, r1.GetHeight());

            r2 = new MmgRect(0, 0, 10, 10);
            i1 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, false);      //-4
            i2 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, false);     //4        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, true);       //-24
            i4 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, true);      //-6
            i5 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, false, true);     //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, true, false);    //0                

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, false);   //-14
            i2 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, false);  //14        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, true);    //6
            i4 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, true);   //24
            i5 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, false, true);    //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, true, false);     //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            //r1 = 4, 4, 24, 24
            //r2 = 0, 0, 10, 10
            i1 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, false);     //-4
            i2 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, false);    //4        
            i3 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, true);      //-24
            i4 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, true);     //-6
            i5 = r1.GetDiffX(r2, MmgDir.DIR_TOP, false, true);      //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, true, false);   //0        

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, false);    //-14
            i2 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, false);   //14      
            i3 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, true);     //6
            i4 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, true);    //24
            i5 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, false, true);   //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_TOP, true, false);      //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            s1 = "MmgRect: L: " + r1.GetLeft() + " R: " + r1.GetRight() + " T: " + r1.GetTop() + " B: " + r1.GetBottom() + ", W: " + r1.GetWidth() + " H: " + r1.GetHeight();

            Assert.AreEqual(s1, r1.ApiToString());

            r2.ShiftRect(2, 2);

            Assert.AreEqual(2, r2.GetLeft());
            Assert.AreEqual(12, r2.GetRight());
            Assert.AreEqual(2, r2.GetTop());
            Assert.AreEqual(12, r2.GetBottom());
            Assert.AreEqual(10, r2.GetWidth());
            Assert.AreEqual(10, r2.GetHeight());

            r1 = r2.ToShiftedRect(2, 2);

            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(14, r1.GetRight());
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(14, r1.GetBottom());
            Assert.AreEqual(10, r1.GetWidth());
            Assert.AreEqual(10, r1.GetHeight());

            r1 = MmgRect.GetUnitRect();

            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(1, r1.GetWidth());
            Assert.AreEqual(1, r1.GetHeight());
        }

        [TestMethod]
        public void test2()
        {
            MmgRect r1;
            MmgRect r2;
            Rectangle r3;
            int i1, i2, i3, i4, i5, i6;
            String s1;

            r1 = new MmgRect(new MmgRect());
            r2 = r1.Clone();

            Assert.AreEqual(true, r1.ApiEquals(r2));
            Assert.AreEqual(true, r2.ApiEquals(r1));
            Assert.AreEqual(true, r1.ApiEquals(r1));

            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());

            Assert.AreEqual(1, r1.GetHeight());
            Assert.AreEqual(1, r1.GetWidth());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r3 = r1.GetRect();
            Assert.AreEqual(0, r3.X);
            Assert.AreEqual(0, r3.Y);
            Assert.AreEqual(1, r3.Width);
            Assert.AreEqual(1, r3.Height);

            r1.SetHeight(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(1, r1.GetRight());

            r1.SetWidth(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(10, r1.GetRight());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r1.SetPosition(MmgVector2.GetUnitVec());
            Assert.AreEqual(1, r1.GetTop());
            Assert.AreEqual(1, r1.GetLeft());
            Assert.AreEqual(11, r1.GetBottom());
            Assert.AreEqual(11, r1.GetRight());

            r1.SetPosition(2, 2);
            Assert.AreEqual(2, r1.GetTop());
            Assert.AreEqual(2, r1.GetLeft());
            Assert.AreEqual(12, r1.GetBottom());
            Assert.AreEqual(12, r1.GetRight());

            i1 = r1.GetDiffX(0, MmgDir.DIR_LEFT, true);     //-2
            i2 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, true);    //-12
            i3 = r1.GetDiffX(0, MmgDir.DIR_LEFT, false);    //2
            i4 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, false);   //12
            i5 = r1.GetDiffX(0, MmgDir.DIR_TOP, false);     //0 
            i6 = r1.GetDiffX(0, MmgDir.DIR_BOTTOM, false);     //0         

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(0, MmgDir.DIR_TOP, true);      //-2
            i2 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, true);   //-12
            i3 = r1.GetDiffY(0, MmgDir.DIR_TOP, false);     //2
            i4 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, false);  //12
            i5 = r1.GetDiffY(0, MmgDir.DIR_LEFT, false);    //0
            i6 = r1.GetDiffY(0, MmgDir.DIR_RIGHT, false);   //0

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            r3 = new Rectangle(4, 4, 20, 20);
            r1.SetRect(r3);
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(24, r1.GetBottom());
            Assert.AreEqual(24, r1.GetRight());
            Assert.AreEqual(20, r1.GetWidth());
            Assert.AreEqual(20, r1.GetHeight());

            r2 = new MmgRect(0, 0, 10, 10);
            i1 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, false);      //-4
            i2 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, false);     //4        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, true);       //-24
            i4 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, true);      //-6
            i5 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, false, true);     //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, true, false);    //0                

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, false);   //-14
            i2 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, false);  //14        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, true);    //6
            i4 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, true);   //24
            i5 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, false, true);    //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, true, false);     //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            //r1 = 4, 4, 24, 24
            //r2 = 0, 0, 10, 10
            i1 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, false);     //-4
            i2 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, false);    //4        
            i3 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, true);      //-24
            i4 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, true);     //-6
            i5 = r1.GetDiffX(r2, MmgDir.DIR_TOP, false, true);      //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, true, false);   //0        

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, false);    //-14
            i2 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, false);   //14      
            i3 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, true);     //6
            i4 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, true);    //24
            i5 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, false, true);   //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_TOP, true, false);      //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            s1 = "MmgRect: L: " + r1.GetLeft() + " R: " + r1.GetRight() + " T: " + r1.GetTop() + " B: " + r1.GetBottom() + ", W: " + r1.GetWidth() + " H: " + r1.GetHeight();

            Assert.AreEqual(s1, r1.ApiToString());

            r2.ShiftRect(2, 2);

            Assert.AreEqual(2, r2.GetLeft());
            Assert.AreEqual(12, r2.GetRight());
            Assert.AreEqual(2, r2.GetTop());
            Assert.AreEqual(12, r2.GetBottom());
            Assert.AreEqual(10, r2.GetWidth());
            Assert.AreEqual(10, r2.GetHeight());

            r1 = r2.ToShiftedRect(2, 2);

            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(14, r1.GetRight());
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(14, r1.GetBottom());
            Assert.AreEqual(10, r1.GetWidth());
            Assert.AreEqual(10, r1.GetHeight());

            r1 = MmgRect.GetUnitRect();

            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(1, r1.GetWidth());
            Assert.AreEqual(1, r1.GetHeight());
        }

        [TestMethod]
        public void test3()
        {
            MmgRect r1;
            MmgRect r2;
            Rectangle r3;
            int i1, i2, i3, i4, i5, i6;
            String s1;

            r1 = new MmgRect(0, 0, 1, 1);
            r2 = r1.Clone();

            Assert.AreEqual(true, r1.ApiEquals(r2));
            Assert.AreEqual(true, r2.ApiEquals(r1));
            Assert.AreEqual(true, r1.ApiEquals(r1));

            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());

            Assert.AreEqual(1, r1.GetHeight());
            Assert.AreEqual(1, r1.GetWidth());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r3 = r1.GetRect();
            Assert.AreEqual(0, r3.X);
            Assert.AreEqual(0, r3.Y);
            Assert.AreEqual(1, r3.Width);
            Assert.AreEqual(1, r3.Height);

            r1.SetHeight(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(1, r1.GetRight());

            r1.SetWidth(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(10, r1.GetRight());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r1.SetPosition(MmgVector2.GetUnitVec());
            Assert.AreEqual(1, r1.GetTop());
            Assert.AreEqual(1, r1.GetLeft());
            Assert.AreEqual(11, r1.GetBottom());
            Assert.AreEqual(11, r1.GetRight());

            r1.SetPosition(2, 2);
            Assert.AreEqual(2, r1.GetTop());
            Assert.AreEqual(2, r1.GetLeft());
            Assert.AreEqual(12, r1.GetBottom());
            Assert.AreEqual(12, r1.GetRight());

            i1 = r1.GetDiffX(0, MmgDir.DIR_LEFT, true);     //-2
            i2 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, true);    //-12
            i3 = r1.GetDiffX(0, MmgDir.DIR_LEFT, false);    //2
            i4 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, false);   //12
            i5 = r1.GetDiffX(0, MmgDir.DIR_TOP, false);     //0 
            i6 = r1.GetDiffX(0, MmgDir.DIR_BOTTOM, false);     //0         

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(0, MmgDir.DIR_TOP, true);      //-2
            i2 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, true);   //-12
            i3 = r1.GetDiffY(0, MmgDir.DIR_TOP, false);     //2
            i4 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, false);  //12
            i5 = r1.GetDiffY(0, MmgDir.DIR_LEFT, false);    //0
            i6 = r1.GetDiffY(0, MmgDir.DIR_RIGHT, false);   //0

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            r3 = new Rectangle(4, 4, 20, 20);
            r1.SetRect(r3);
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(24, r1.GetBottom());
            Assert.AreEqual(24, r1.GetRight());
            Assert.AreEqual(20, r1.GetWidth());
            Assert.AreEqual(20, r1.GetHeight());

            r2 = new MmgRect(0, 0, 10, 10);
            i1 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, false);      //-4
            i2 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, false);     //4        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, true);       //-24
            i4 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, true);      //-6
            i5 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, false, true);     //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, true, false);    //0                

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, false);   //-14
            i2 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, false);  //14        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, true);    //6
            i4 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, true);   //24
            i5 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, false, true);    //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, true, false);     //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            //r1 = 4, 4, 24, 24
            //r2 = 0, 0, 10, 10
            i1 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, false);     //-4
            i2 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, false);    //4        
            i3 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, true);      //-24
            i4 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, true);     //-6
            i5 = r1.GetDiffX(r2, MmgDir.DIR_TOP, false, true);      //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, true, false);   //0        

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, false);    //-14
            i2 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, false);   //14      
            i3 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, true);     //6
            i4 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, true);    //24
            i5 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, false, true);   //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_TOP, true, false);      //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            s1 = "MmgRect: L: " + r1.GetLeft() + " R: " + r1.GetRight() + " T: " + r1.GetTop() + " B: " + r1.GetBottom() + ", W: " + r1.GetWidth() + " H: " + r1.GetHeight();

            Assert.AreEqual(s1, r1.ApiToString());

            r2.ShiftRect(2, 2);

            Assert.AreEqual(2, r2.GetLeft());
            Assert.AreEqual(12, r2.GetRight());
            Assert.AreEqual(2, r2.GetTop());
            Assert.AreEqual(12, r2.GetBottom());
            Assert.AreEqual(10, r2.GetWidth());
            Assert.AreEqual(10, r2.GetHeight());

            r1 = r2.ToShiftedRect(2, 2);

            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(14, r1.GetRight());
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(14, r1.GetBottom());
            Assert.AreEqual(10, r1.GetWidth());
            Assert.AreEqual(10, r1.GetHeight());

            r1 = MmgRect.GetUnitRect();

            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(1, r1.GetWidth());
            Assert.AreEqual(1, r1.GetHeight());
        }

        [TestMethod]
        public void test4()
        {
            MmgRect r1;
            MmgRect r2;
            Rectangle r3;
            int i1, i2, i3, i4, i5, i6;
            String s1;

            r1 = new MmgRect(MmgVector2.GetOriginVec(), 1, 1);
            r2 = r1.Clone();

            Assert.AreEqual(true, r1.ApiEquals(r2));
            Assert.AreEqual(true, r2.ApiEquals(r1));
            Assert.AreEqual(true, r1.ApiEquals(r1));

            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());

            Assert.AreEqual(1, r1.GetHeight());
            Assert.AreEqual(1, r1.GetWidth());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r3 = r1.GetRect();
            Assert.AreEqual(0, r3.X);
            Assert.AreEqual(0, r3.Y);
            Assert.AreEqual(1, r3.Width);
            Assert.AreEqual(1, r3.Height);

            r1.SetHeight(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(1, r1.GetRight());

            r1.SetWidth(10);
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(10, r1.GetBottom());
            Assert.AreEqual(10, r1.GetRight());

            Assert.AreEqual(true, r1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

            r1.SetPosition(MmgVector2.GetUnitVec());
            Assert.AreEqual(1, r1.GetTop());
            Assert.AreEqual(1, r1.GetLeft());
            Assert.AreEqual(11, r1.GetBottom());
            Assert.AreEqual(11, r1.GetRight());

            r1.SetPosition(2, 2);
            Assert.AreEqual(2, r1.GetTop());
            Assert.AreEqual(2, r1.GetLeft());
            Assert.AreEqual(12, r1.GetBottom());
            Assert.AreEqual(12, r1.GetRight());

            i1 = r1.GetDiffX(0, MmgDir.DIR_LEFT, true);     //-2
            i2 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, true);    //-12
            i3 = r1.GetDiffX(0, MmgDir.DIR_LEFT, false);    //2
            i4 = r1.GetDiffX(0, MmgDir.DIR_RIGHT, false);   //12
            i5 = r1.GetDiffX(0, MmgDir.DIR_TOP, false);     //0 
            i6 = r1.GetDiffX(0, MmgDir.DIR_BOTTOM, false);     //0         

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(0, MmgDir.DIR_TOP, true);      //-2
            i2 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, true);   //-12
            i3 = r1.GetDiffY(0, MmgDir.DIR_TOP, false);     //2
            i4 = r1.GetDiffY(0, MmgDir.DIR_BOTTOM, false);  //12
            i5 = r1.GetDiffY(0, MmgDir.DIR_LEFT, false);    //0
            i6 = r1.GetDiffY(0, MmgDir.DIR_RIGHT, false);   //0

            Assert.AreEqual(i1, -2);
            Assert.AreEqual(i2, -12);
            Assert.AreEqual(i3, 2);
            Assert.AreEqual(i4, 12);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            r3 = new Rectangle(4, 4, 20, 20);
            r1.SetRect(r3);
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(24, r1.GetBottom());
            Assert.AreEqual(24, r1.GetRight());
            Assert.AreEqual(20, r1.GetWidth());
            Assert.AreEqual(20, r1.GetHeight());

            r2 = new MmgRect(0, 0, 10, 10);
            i1 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, false);      //-4
            i2 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, false);     //4        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_TOP, true, true);       //-24
            i4 = r1.GetDiffY(r2, MmgDir.DIR_TOP, false, true);      //-6
            i5 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, false, true);     //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, true, false);    //0                

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, false);   //-14
            i2 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, false);  //14        
            i3 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, true, true);    //6
            i4 = r1.GetDiffY(r2, MmgDir.DIR_BOTTOM, false, true);   //24
            i5 = r1.GetDiffY(r2, MmgDir.DIR_RIGHT, false, true);    //0
            i6 = r1.GetDiffY(r2, MmgDir.DIR_LEFT, true, false);     //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            //r1 = 4, 4, 24, 24
            //r2 = 0, 0, 10, 10
            i1 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, false);     //-4
            i2 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, false);    //4        
            i3 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, true, true);      //-24
            i4 = r1.GetDiffX(r2, MmgDir.DIR_LEFT, false, true);     //-6
            i5 = r1.GetDiffX(r2, MmgDir.DIR_TOP, false, true);      //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, true, false);   //0        

            Assert.AreEqual(i1, -4);
            Assert.AreEqual(i2, 4);
            Assert.AreEqual(i3, -24);
            Assert.AreEqual(i4, -6);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            i1 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, false);    //-14
            i2 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, false);   //14      
            i3 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, true, true);     //6
            i4 = r1.GetDiffX(r2, MmgDir.DIR_RIGHT, false, true);    //24
            i5 = r1.GetDiffX(r2, MmgDir.DIR_BOTTOM, false, true);   //0
            i6 = r1.GetDiffX(r2, MmgDir.DIR_TOP, true, false);      //0

            Assert.AreEqual(i1, -14);
            Assert.AreEqual(i2, 14);
            Assert.AreEqual(i3, 6);
            Assert.AreEqual(i4, 24);
            Assert.AreEqual(i5, 0);
            Assert.AreEqual(i6, 0);

            s1 = "MmgRect: L: " + r1.GetLeft() + " R: " + r1.GetRight() + " T: " + r1.GetTop() + " B: " + r1.GetBottom() + ", W: " + r1.GetWidth() + " H: " + r1.GetHeight();

            Assert.AreEqual(s1, r1.ApiToString());

            r2.ShiftRect(2, 2);

            Assert.AreEqual(2, r2.GetLeft());
            Assert.AreEqual(12, r2.GetRight());
            Assert.AreEqual(2, r2.GetTop());
            Assert.AreEqual(12, r2.GetBottom());
            Assert.AreEqual(10, r2.GetWidth());
            Assert.AreEqual(10, r2.GetHeight());

            r1 = r2.ToShiftedRect(2, 2);

            Assert.AreEqual(4, r1.GetLeft());
            Assert.AreEqual(14, r1.GetRight());
            Assert.AreEqual(4, r1.GetTop());
            Assert.AreEqual(14, r1.GetBottom());
            Assert.AreEqual(10, r1.GetWidth());
            Assert.AreEqual(10, r1.GetHeight());

            r1 = MmgRect.GetUnitRect();

            Assert.AreEqual(0, r1.GetLeft());
            Assert.AreEqual(1, r1.GetRight());
            Assert.AreEqual(0, r1.GetTop());
            Assert.AreEqual(1, r1.GetBottom());
            Assert.AreEqual(1, r1.GetWidth());
            Assert.AreEqual(1, r1.GetHeight());
        }
    }
}
