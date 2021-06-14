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
    public class MmgObjUnitTest
    {
        public MmgObjUnitTest()
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
        public void testEquals()
        {
            //VARS
            MmgObj obj1;
            int x;
            int y;
            int w;
            int h;
            MmgVector2 pos;
            bool viz;
            MmgColor c;
            string n;
            string id;
            MmgObj obj2;

            //PREP TEST 1
            x = 1;
            y = 2;
            w = 10;
            h = 11;
            pos = new MmgVector2(x, y);
            viz = true;
            c = MmgColor.GetBlack();
            n = "";
            id = "";

            //TEST 1
            obj1 = new MmgObj(x, y, w, h, viz, c);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            obj2 = obj1.Clone();
            Assert.AreNotSame(obj1, obj2);
            Assert.AreEqual(obj1.GetWidth(), obj2.GetWidth());
            Assert.AreEqual(obj1.GetHeight(), obj2.GetHeight());
            Assert.AreEqual(true, obj1.GetPosition().ApiEquals(obj2.GetPosition()));
            Assert.AreEqual(obj1.GetIsVisible(), obj2.GetIsVisible());
            Assert.AreEqual(true, obj1.GetMmgColor().ApiEquals(obj2.GetMmgColor()));
            Assert.AreEqual(obj1.GetHasParent(), obj2.GetHasParent());
            Assert.AreEqual(obj1.GetParent(), obj2.GetParent());
            Assert.AreEqual(obj1.GetName(), obj2.GetName());
            Assert.AreEqual(obj1.GetId(), obj2.GetId());

            Assert.AreEqual(true, obj1.ApiEquals(obj2));
        }

        [TestMethod]
        public void testGettersSetters()
        {
            //VARS
            MmgObj obj1;
            int x;
            int y;
            int w;
            int h;
            MmgVector2 pos;
            bool viz;
            MmgColor c;
            string n;
            string id;
            bool hp;
            MmgObj p;
            string ver;

            //PREP TEST 1
            x = 5;
            y = 6;
            w = 200;
            h = 100;
            pos = new MmgVector2(x, y);
            viz = true;
            c = MmgColor.GetBlack();
            n = "vb243";
            id = "243";
            hp = true;
            p = null;
            obj1 = new MmgObj();
            ver = "1.0.8";

            //TEST 1 - Has Parent        
            obj1.SetHasParent(hp);
            Assert.AreEqual(hp, obj1.GetHasParent());
            hp = !hp;
            Assert.AreEqual(!hp, obj1.GetHasParent());
            obj1.SetHasParent(hp);
            Assert.AreEqual(hp, obj1.GetHasParent());

            //TEST 2 - Parent
            p = new MmgObj("t", "t243");
            obj1.SetParent(p);
            Assert.AreEqual(p, obj1.GetParent());
            obj1.SetParent(null);
            Assert.AreNotSame(p, obj1.GetParent());
            Assert.IsNull(obj1.GetParent());

            //TEST 3 - Is Visible
            obj1.SetIsVisible(viz);
            Assert.AreEqual(viz, obj1.GetIsVisible());
            viz = !viz;
            Assert.AreEqual(!viz, obj1.GetIsVisible());
            obj1.SetIsVisible(viz);
            Assert.AreEqual(viz, obj1.GetIsVisible());

            //TEST 4 - Width
            obj1.SetWidth(w);
            Assert.AreEqual(w, obj1.GetWidth());
            w += 10;
            Assert.AreEqual(w - 10, obj1.GetWidth());
            obj1.SetWidth(w);
            Assert.AreEqual(w, obj1.GetWidth());

            //TEST 5 - Height
            obj1.SetHeight(h);
            Assert.AreEqual(h, obj1.GetHeight());
            h += 12;
            Assert.AreEqual(h - 12, obj1.GetHeight());
            obj1.SetHeight(h);
            Assert.AreEqual(h, obj1.GetHeight());

            //TEST 6 - Name
            obj1.SetName(n);
            Assert.AreEqual(n, obj1.GetName());
            n += "....";
            Assert.AreNotSame(n, obj1.GetName());
            obj1.SetName(n);
            Assert.AreEqual(n, obj1.GetName());

            //TEST 7 - Id
            obj1.SetId(id);
            Assert.AreEqual(id, obj1.GetId());
            id += "..1234";
            Assert.AreNotSame(id, obj1.GetId());
            obj1.SetId(id);
            Assert.AreEqual(id, obj1.GetId());

            //TEST 8 - Color
            obj1.SetMmgColor(c);
            Assert.AreEqual(c, obj1.GetMmgColor());
            c = MmgColor.GetWhite();
            Assert.AreNotSame(c, obj1.GetMmgColor());
            obj1.SetMmgColor(c);
            Assert.AreEqual(c, obj1.GetMmgColor());

            //TEST 9 - Position
            obj1.SetPosition(pos);
            Assert.AreEqual(pos, obj1.GetPosition());
            pos = new MmgVector2(101, 203);
            Assert.AreNotSame(pos, obj1.GetPosition());
            obj1.SetPosition(pos);
            Assert.AreEqual(pos, obj1.GetPosition());

            //TEST 10 - Version
            Assert.AreEqual(ver, obj1.GetVersion());

            //TEST 11 - Set X,Y
            pos = new MmgVector2(101, 203);
            obj1.SetX(pos.GetX() + 10);
            Assert.AreEqual(pos.GetX() + 10, obj1.GetPosition().GetX());
            obj1.SetY(pos.GetY() + 5);
            Assert.AreEqual(pos.GetY() + 5, obj1.GetPosition().GetY());

            //TEST 12 - ToString
            string tmp = "MmgObj: Name: " + obj1.GetName() + " Id: " + obj1.GetId() + " - " + obj1.GetPosition().ApiToString() + " HasParent: " + obj1.GetHasParent() + " Width: " + w + " Height: " + h;
            //System.err.println(tmp);
            //System.err.println(obj1.ToString());
            Assert.AreEqual(tmp, obj1.ApiToString());
        }

        [TestMethod]
        public void testCloning()
        {
            //VARS
            MmgObj obj1;
            int x;
            int y;
            int w;
            int h;
            MmgVector2 pos;
            bool viz;
            MmgColor c;
            string n;
            string id;
            MmgObj obj2;

            //PREP TEST 1
            x = 1;
            y = 2;
            w = 10;
            h = 11;
            pos = new MmgVector2(x, y);
            viz = true;
            c = MmgColor.GetBlack();
            n = "";
            id = "";

            //TEST 1
            obj1 = new MmgObj(x, y, w, h, viz, c);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            obj2 = obj1.Clone();
            Assert.AreNotSame(obj1, obj2);
            Assert.AreEqual(obj1.GetWidth(), obj2.GetWidth());
            Assert.AreEqual(obj1.GetHeight(), obj2.GetHeight());
            Assert.AreEqual(true, obj1.GetPosition().ApiEquals(obj2.GetPosition()));
            Assert.AreEqual(obj1.GetIsVisible(), obj2.GetIsVisible());
            Assert.AreEqual(true, obj1.GetMmgColor().ApiEquals(obj2.GetMmgColor()));
            Assert.AreEqual(obj1.GetHasParent(), obj2.GetHasParent());
            Assert.AreEqual(obj1.GetParent(), obj2.GetParent());
            Assert.AreEqual(obj1.GetName(), obj2.GetName());
            Assert.AreEqual(obj1.GetId(), obj2.GetId());
        }

        [TestMethod]
        public void testConstructors()
        {
            //VARS
            MmgObj obj1;
            int x;
            int y;
            int w;
            int h;
            MmgVector2 pos;
            bool viz;
            MmgColor c;
            string n;
            string id;
            MmgObj obj2;

            //PREP TEST 1
            w = 0;
            h = 0;
            pos = MmgVector2.GetOriginVec();
            viz = true;
            c = MmgColor.GetWhite();
            n = "";
            id = "";

            //TEST 1
            obj1 = new MmgObj();
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            //PREP TEST 2
            x = 1;
            y = 2;
            w = 10;
            h = 11;
            pos = new MmgVector2(x, y);
            viz = true;
            c = MmgColor.GetBlack();
            n = "";
            id = "";

            //TEST 2
            obj1 = new MmgObj(x, y, w, h, viz, c);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            //PREP TEST 3
            x = 5;
            y = 6;
            w = 13;
            h = 16;
            pos = new MmgVector2(x, y);
            viz = false;
            c = MmgColor.GetWhite();
            n = "";
            id = "";

            //TEST 3
            obj1 = new MmgObj(pos, w, h, viz, c);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            //PREP TEST 4
            x = 0;
            y = 0;
            w = 0;
            h = 0;
            viz = true;
            pos = MmgVector2.GetOriginVec();
            c = MmgColor.GetWhite();
            n = "vb";
            id = "vbMmgObj";

            //TEST 4
            obj1 = new MmgObj(n, id);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            //PREP TEST 5
            x = 2;
            y = 3;
            w = 21;
            h = 22;
            pos = new MmgVector2(x, y);
            viz = false;
            c = MmgColor.GetBlack();
            n = "vb";
            id = "vbMmgObj";

            //TEST 5
            obj1 = new MmgObj(x, y, w, h, viz, c, n, id);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            //PREP TEST 6
            x = 8;
            y = 9;
            w = 32;
            h = 30;
            pos = new MmgVector2(x, y);
            viz = true;
            c = MmgColor.GetBlack();
            n = "vb";
            id = "vbMmgHi!";

            //TEST 6
            obj1 = new MmgObj(pos, w, h, viz, c, n, id);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());

            //PREP TEST 7
            x = 1;
            y = 2;
            w = 33;
            h = 35;
            pos = new MmgVector2(x, y);
            viz = true;
            c = MmgColor.GetWhite();
            n = "vb123";
            id = "vbMmg123";

            //TEST 6
            obj2 = new MmgObj(pos, w, h, viz, c, n, id);
            Assert.AreEqual(w, obj2.GetWidth());
            Assert.AreEqual(h, obj2.GetHeight());
            Assert.AreEqual(n, obj2.GetName());
            Assert.AreEqual(id, obj2.GetId());

            obj1 = new MmgObj(obj2);
            Assert.AreEqual(w, obj1.GetWidth());
            Assert.AreEqual(h, obj1.GetHeight());
            Assert.AreEqual(true, pos.ApiEquals(obj1.GetPosition()));
            Assert.AreEqual(viz, obj1.GetIsVisible());
            Assert.AreEqual(true, c.ApiEquals(obj1.GetMmgColor()));
            Assert.AreEqual(false, obj1.GetHasParent());
            Assert.AreEqual(null, obj1.GetParent());
            Assert.AreEqual(n, obj1.GetName());
            Assert.AreEqual(id, obj1.GetId());
        }
    }
}