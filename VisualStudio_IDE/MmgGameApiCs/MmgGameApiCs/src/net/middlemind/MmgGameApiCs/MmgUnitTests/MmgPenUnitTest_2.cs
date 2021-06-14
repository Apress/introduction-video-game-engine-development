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
    public class MmgPenUnitTest_2
    {
        public MmgPenUnitTest_2()
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
            MmgPen p1 = null;
            RenderTarget2D img = null;
            MmgBmp b1 = null;
            SpriteBatch g = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
            p1 = new MmgPen();
            p1.SetCacheOn(true);

            Assert.AreEqual(true, p1.GetCacheOn() == true);

            p1.SetCacheOn(false);

            Assert.AreEqual(true, p1.GetCacheOn() == false);

            p1.SetColor(Color.Red);

            Assert.AreEqual(true, p1.GetColor().Equals(Color.Red));
            Assert.AreEqual(true, p1.GetColor().Equals(Color.Red));

            img = new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, 64, 64);
            g = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);
            g.GraphicsDevice.SetRenderTarget(img);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(b1.GetImage(), Vector2.Zero, Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            p1.SetGraphics(g);
            p1.SetGraphicsColor(Color.Blue);
            Assert.AreEqual(true, p1.GetGraphics().Equals(g));
            Assert.AreEqual(true, p1.GetSpriteBatch().Equals(g));
            Assert.AreEqual(true, p1.GetGraphicsColor().Equals(Color.Blue));
        }

        [TestMethod]
        public void test2()
        {
            MmgPen p1 = null;
            RenderTarget2D img = null;
            MmgBmp b1 = null;
            SpriteBatch g = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");

            img = new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, 64, 64);
            g = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);
            g.GraphicsDevice.SetRenderTarget(img);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(b1.GetImage(), Vector2.Zero, Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            /*
            img = new BuffeRedImage(64, 64, BuffeRedImage.TYPE_INT_ARGB);
            g = img.createGraphics();
            g.drawImage(b1.GetImage(), 0, 0, null);
            g.dispose();
            */

            p1 = new MmgPen(g);
            p1.SetCacheOn(true);

            Assert.AreEqual(true, p1.GetCacheOn() == true);

            p1.SetCacheOn(false);

            Assert.AreEqual(true, p1.GetCacheOn() == false);

            p1.SetColor(Color.Red);

            Assert.AreEqual(true, p1.GetColor().Equals(Color.Red));

            img = new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, 64, 64);
            g = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);
            g.GraphicsDevice.SetRenderTarget(img);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(b1.GetImage(), Vector2.Zero, Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            /*
            img = new BuffeRedImage(64, 64, BuffeRedImage.TYPE_INT_ARGB);
            g = img.createGraphics();
            g.drawImage(b1.GetImage(), 0, 0, null);
            g.dispose();
            */

            p1.SetGraphics(g);
            p1.SetGraphicsColor(Color.Blue);
            Assert.AreEqual(true, p1.GetGraphics().Equals(g));
            Assert.AreEqual(true, p1.GetSpriteBatch().Equals(g));
            Assert.AreEqual(true, p1.GetGraphicsColor().Equals(Color.Blue));
        }

        [TestMethod]
        public void test3()
        {
            MmgPen p1 = null;
            RenderTarget2D img = null;
            MmgBmp b1 = null;
            SpriteBatch g = null;

            b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");

            img = new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, 64, 64);
            g = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);
            g.GraphicsDevice.SetRenderTarget(img);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(b1.GetImage(), Vector2.Zero, Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            /*
            img = new BuffeRedImage(64, 64, BuffeRedImage.TYPE_INT_ARGB);
            g = img.createGraphics();
            g.drawImage(b1.GetImage(), 0, 0, null);
            g.dispose();
            */

            p1 = new MmgPen(g, Color.Black);
            p1.SetCacheOn(true);

            Assert.AreEqual(true, p1.GetCacheOn() == true);

            p1.SetCacheOn(false);

            Assert.AreEqual(true, p1.GetCacheOn() == false);

            p1.SetColor(Color.Red);

            Assert.AreEqual(true, p1.GetColor().Equals(Color.Red));
            Assert.AreEqual(true, p1.GetColor().Equals(Color.Red));

            img = new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, 64, 64);
            g = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);
            g.GraphicsDevice.SetRenderTarget(img);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(b1.GetImage(), Vector2.Zero, Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            /*
            img = new BuffeRedImage(64, 64, BuffeRedImage.TYPE_INT_ARGB);
            g = img.createGraphics();
            g.drawImage(b1.GetImage(), 0, 0, null);
            g.dispose();
            */

            p1.SetGraphics(g);
            p1.SetGraphicsColor(Color.Blue);
            Assert.AreEqual(true, p1.GetGraphics().Equals(g));
            Assert.AreEqual(true, p1.GetSpriteBatch().Equals(g));
            Assert.AreEqual(true, p1.GetGraphicsColor().Equals(Color.Blue));
        }
    }
}