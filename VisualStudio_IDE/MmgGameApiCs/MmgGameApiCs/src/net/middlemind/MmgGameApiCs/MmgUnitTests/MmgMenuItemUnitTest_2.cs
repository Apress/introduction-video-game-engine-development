using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games 
    /// </summary>
    [TestClass]
    public class MmgMenuItemUnitTest_2
    {
        public MmgMenuItemUnitTest_2()
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

        public MmgMenuItem GetBasicMenuItem1(MmgEventHandler handler, String name, int eventId, int eventType, MmgBmp img)
        {
            MmgMenuItem itm;
            itm = new MmgMenuItem();
            itm.SetNormal(img);
            itm.SetSelected(img);
            itm.SetInactive(img);
            itm.SetPosition(img.GetPosition());
            itm.SetState(MmgMenuItem.STATE_NORMAL);
            itm.SetEventPress(new MmgEvent(handler, name, eventId, eventType, handler, null));
            itm.SetMmgColor(null);
            return itm;
        }

        public MmgMenuItem GetBasicMenuItem2(MmgEventHandler handler, String name, int eventId, int eventType, MmgBmp img)
        {
            MmgMenuItem itm;
            itm = new MmgMenuItem(new MmgObj(10, 10));
            itm.SetNormal(img);
            itm.SetSelected(img);
            itm.SetInactive(img);
            itm.SetPosition(img.GetPosition());
            itm.SetState(MmgMenuItem.STATE_NORMAL);
            itm.SetEventPress(new MmgEvent(handler, name, eventId, eventType, handler, null));
            itm.SetMmgColor(null);
            return itm;
        }

        public MmgMenuItem GetBasicMenuItem3(MmgEventHandler handler, String name, int eventId, int eventType, MmgBmp img)
        {
            MmgMenuItem itm;
            itm = new MmgMenuItem(new MmgMenuItem());
            itm.SetNormal(img);
            itm.SetSelected(img);
            itm.SetInactive(img);
            itm.SetPosition(img.GetPosition());
            itm.SetState(MmgMenuItem.STATE_NORMAL);
            itm.SetEventPress(new MmgEvent(handler, name, eventId, eventType, handler, null));
            itm.SetMmgColor(null);
            return itm;
        }

        [TestMethod]
        public void test1()
        {
            String name1 = "Test Name 1";
            String name2 = "Test Name 2";
            String name3 = "Test Name 3";
            int id1 = 255;
            int type1 = 256;
            int id2 = 127;
            int type2 = 128;
            int id3 = 124;
            int type3 = 125;
            MmgBmp b1, b2, b3 = null;
            MmgMenuItem i1, i2, i3 = null;
            MmgSound s1, s2 = null;

            s1 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");
            s2 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump2.wav");

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.CreateFilledBmp(12, 12, MmgColor.GetCharcoal());
            b3 = MmgHelper.CreateFilledBmp(18, 18, MmgColor.GetDarkRed());

            i1 = GetBasicMenuItem1(null, name1, id1, type1, b1);
            i2 = GetBasicMenuItem1(null, name2, id2, type2, b2);
            i3 = GetBasicMenuItem1(null, name3, id3, type3, b3);

            Assert.AreEqual(true, i1.GetEventPress().GetMessage().Equals(name1));
            Assert.AreEqual(true, i1.GetEventPress().GetEventId() == id1);
            Assert.AreEqual(true, i1.GetEventPress().GetEventType() == type1);

            Assert.AreEqual(true, i1.GetNormal().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetNormal().Equals(b1));

            Assert.AreEqual(true, i1.GetSelected().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetSelected().Equals(b1));

            Assert.AreEqual(true, i1.GetInactive().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetInactive().Equals(b1));

            Assert.AreEqual(true, i1.GetState() == MmgMenuItem.STATE_NORMAL);
            Assert.AreEqual(true, i1.GetMmgColor() == null);

            i1.SetHeight(64);
            i1.SetWidth(64);
            i1.SetSound(s1);

            Assert.AreEqual(i1.GetHeight(), 64);
            Assert.AreEqual(i1.GetWidth(), 64);
            Assert.AreEqual(true, i1.GetSound().ApiEquals(s1));
            Assert.AreEqual(true, i1.GetSound().Equals(s1));

            i1.SetX(24);
            i1.SetY(32);

            Assert.AreEqual(i1.GetX(), 24);
            Assert.AreEqual(i1.GetY(), 32);

            i2 = i1.CloneTyped();

            Assert.AreEqual(true, i1.ApiEquals(i1));
            Assert.AreEqual(true, i1.ApiEquals(i2));
            Assert.AreEqual(true, i2.ApiEquals(i1));
            Assert.AreEqual(true, i2.ApiEquals(i1));
            Assert.AreEqual(false, i3.ApiEquals(i1));
            Assert.AreEqual(false, i1.ApiEquals(i3));
        }

        [TestMethod]
        public void test2()
        {
            String name1 = "Test Name 1";
            String name2 = "Test Name 2";
            String name3 = "Test Name 3";
            int id1 = 255;
            int type1 = 256;
            int id2 = 127;
            int type2 = 128;
            int id3 = 124;
            int type3 = 125;
            MmgBmp b1, b2, b3 = null;
            MmgMenuItem i1, i2, i3 = null;
            MmgSound s1, s2 = null;

            s1 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");
            s2 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump2.wav");

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.CreateFilledBmp(12, 12, MmgColor.GetCharcoal());
            b3 = MmgHelper.CreateFilledBmp(18, 18, MmgColor.GetDarkRed());

            i1 = GetBasicMenuItem2(null, name1, id1, type1, b1);
            i2 = GetBasicMenuItem2(null, name2, id2, type2, b2);
            i3 = GetBasicMenuItem2(null, name3, id3, type3, b3);

            Assert.AreEqual(true, i1.GetEventPress().GetMessage().Equals(name1));
            Assert.AreEqual(true, i1.GetEventPress().GetEventId() == id1);
            Assert.AreEqual(true, i1.GetEventPress().GetEventType() == type1);

            Assert.AreEqual(true, i1.GetNormal().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetNormal().Equals(b1));

            Assert.AreEqual(true, i1.GetSelected().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetSelected().Equals(b1));

            Assert.AreEqual(true, i1.GetInactive().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetInactive().Equals(b1));

            Assert.AreEqual(true, i1.GetState() == MmgMenuItem.STATE_NORMAL);
            Assert.AreEqual(true, i1.GetMmgColor() == null);

            i1.SetHeight(64);
            i1.SetWidth(64);
            i1.SetSound(s1);

            Assert.AreEqual(i1.GetHeight(), 64);
            Assert.AreEqual(i1.GetWidth(), 64);
            Assert.AreEqual(true, i1.GetSound().ApiEquals(s1));
            Assert.AreEqual(true, i1.GetSound().Equals(s1));

            i1.SetX(24);
            i1.SetY(32);

            Assert.AreEqual(i1.GetX(), 24);
            Assert.AreEqual(i1.GetY(), 32);

            i2 = i1.CloneTyped();

            Assert.AreEqual(true, i1.ApiEquals(i1));
            Assert.AreEqual(true, i1.ApiEquals(i2));
            Assert.AreEqual(true, i2.ApiEquals(i1));
            Assert.AreEqual(true, i2.ApiEquals(i1));
            Assert.AreEqual(false, i3.ApiEquals(i1));
            Assert.AreEqual(false, i1.ApiEquals(i3));
        }

        [TestMethod]
        public void test3()
        {
            String name1 = "Test Name 1";
            String name2 = "Test Name 2";
            String name3 = "Test Name 3";
            int id1 = 255;
            int type1 = 256;
            int id2 = 127;
            int type2 = 128;
            int id3 = 124;
            int type3 = 125;
            MmgBmp b1, b2, b3 = null;
            MmgMenuItem i1, i2, i3 = null;
            MmgSound s1, s2 = null;

            s1 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");
            s2 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump2.wav");

            b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
            b2 = MmgHelper.CreateFilledBmp(12, 12, MmgColor.GetCharcoal());
            b3 = MmgHelper.CreateFilledBmp(18, 18, MmgColor.GetDarkRed());

            i1 = GetBasicMenuItem3(null, name1, id1, type1, b1);
            i2 = GetBasicMenuItem3(null, name2, id2, type2, b2);
            i3 = GetBasicMenuItem3(null, name3, id3, type3, b3);

            Assert.AreEqual(true, i1.GetEventPress().GetMessage().Equals(name1));
            Assert.AreEqual(true, i1.GetEventPress().GetEventId() == id1);
            Assert.AreEqual(true, i1.GetEventPress().GetEventType() == type1);

            Assert.AreEqual(true, i1.GetNormal().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetNormal().Equals(b1));

            Assert.AreEqual(true, i1.GetSelected().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetSelected().Equals(b1));

            Assert.AreEqual(true, i1.GetInactive().ApiEquals(b1));
            Assert.AreEqual(true, i1.GetInactive().Equals(b1));

            Assert.AreEqual(true, i1.GetState() == MmgMenuItem.STATE_NORMAL);
            Assert.AreEqual(true, i1.GetMmgColor() == null);

            i1.SetHeight(64);
            i1.SetWidth(64);
            i1.SetSound(s1);

            Assert.AreEqual(i1.GetHeight(), 64);
            Assert.AreEqual(i1.GetWidth(), 64);
            Assert.AreEqual(true, i1.GetSound().ApiEquals(s1));
            Assert.AreEqual(true, i1.GetSound().Equals(s1));

            i1.SetX(24);
            i1.SetY(32);

            Assert.AreEqual(i1.GetX(), 24);
            Assert.AreEqual(i1.GetY(), 32);

            i2 = i1.CloneTyped();

            Assert.AreEqual(true, i1.ApiEquals(i1));
            Assert.AreEqual(true, i1.ApiEquals(i2));
            Assert.AreEqual(true, i2.ApiEquals(i1));
            Assert.AreEqual(true, i2.ApiEquals(i1));
            Assert.AreEqual(false, i3.ApiEquals(i1));
            Assert.AreEqual(false, i1.ApiEquals(i3));
        }
    }
}