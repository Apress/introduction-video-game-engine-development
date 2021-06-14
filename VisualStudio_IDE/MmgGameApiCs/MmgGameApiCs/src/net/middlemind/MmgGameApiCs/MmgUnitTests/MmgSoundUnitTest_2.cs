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
    public class MmgSoundUnitTest_2
    {
        public MmgSoundUnitTest_2()
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
            MmgSound s1, s2, s3;

            s1 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");
            s3 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump2.wav");

            Assert.AreEqual(MmgSound.MMG_SOUND_GLOBAL_VOLUME, 0.64999f, 0.001);
            //Assert.AreEqual(-24.0866f, s1.GetCurrentVolume(), 0.001);
            Assert.AreEqual(0.64999f, s1.GetCurrentVolume(), 0.001);
            Assert.AreEqual(s1.GetCurrentRate(), 1.0f, 0.001);

            s2 = s1.Clone();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s2));
            Assert.AreEqual(false, s1.ApiEquals(s3));
            Assert.AreEqual(false, s3.ApiEquals(s1));

            Assert.AreEqual(1.0f, s1.GetCurrentRate(), 0.001);
            //Assert.AreEqual(-24.0866f, s1.GetCurrentVolume(), 0.001);
            Assert.AreEqual(0.64999f, s1.GetCurrentVolume(), 0.001);

            Assert.AreEqual(true, s1.GetSound().Equals(s2.GetSound()));
            Assert.AreEqual(true, s1.GetSound().Equals(s1.GetSound()));
            Assert.AreEqual(false, s1.GetSound().Equals(s3.GetSound()));

            String idStr = "MmgSound: " + s1.GetIdStr() + " Clip Length MS: " + (s1.GetSound().Duration.TotalMilliseconds);
            Assert.AreEqual(true, idStr.Equals(s1.ApiToString()));
            Assert.AreEqual(false, idStr.Equals(s2.ApiToString()));
            Assert.AreEqual(false, idStr.Equals(s3.ApiToString()));
        }

        [TestMethod]
        public void test2()
        {
            MmgSound s1, s2, s3, s4;

            s1 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");
            s3 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump2.wav");
            s4 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");

            s1 = new MmgSound(s4);

            Assert.AreEqual(MmgSound.MMG_SOUND_GLOBAL_VOLUME, 0.64999f, 0.001);
            //Assert.AreEqual(-24.0866f, s1.GetCurrentVolume(), 0.001);
            Assert.AreEqual(0.64999f, s1.GetCurrentVolume(), 0.001);
            Assert.AreEqual(s1.GetCurrentRate(), 1.0f, 0.001);

            s2 = s1.Clone();

            Assert.AreEqual(true, s1.ApiEquals(s1));
            Assert.AreEqual(true, s1.ApiEquals(s2));
            Assert.AreEqual(true, s2.ApiEquals(s2));
            Assert.AreEqual(false, s1.ApiEquals(s3));
            Assert.AreEqual(false, s3.ApiEquals(s1));

            Assert.AreEqual(1.0f, s1.GetCurrentRate(), 0.001);
            //Assert.AreEqual(-24.0866f, s1.GetCurrentVolume(), 0.001);
            Assert.AreEqual(0.64999f, s1.GetCurrentVolume(), 0.001);

            Assert.AreEqual(true, s1.GetSound().Equals(s2.GetSound()));
            Assert.AreEqual(true, s1.GetSound().Equals(s1.GetSound()));
            Assert.AreEqual(false, s1.GetSound().Equals(s3.GetSound()));

            string idStr = "MmgSound: " + s1.GetIdStr() + " Clip Length MS: " + (s1.GetSound().Duration.TotalMilliseconds);

            Assert.AreEqual(true, idStr.Equals(s1.ApiToString()));
            Assert.AreEqual(false, idStr.Equals(s2.ApiToString()));
            Assert.AreEqual(false, idStr.Equals(s3.ApiToString()));
        }
    }
}