using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that provides help with MmgBmp scaling.
    /// Created by Middlemind Games 10/12/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public class MmgBmpScaler
    {
        /// <summary>
        /// A static class method that scales an MmgBmp object to the size of the game screen.
        /// </summary>
        /// <param name="subj">The MmgBmp object to scale to the size of the screen.</param>
        /// <param name="alpha">A bool flag indicating if transparency should be taken into consideration when creating new images.</param>
        /// <returns>A new MmgBmp object instance scaled to the size of the screen.</returns>
        public static MmgBmp ScaleMmgBmpToGameScreen(MmgBmp subj, bool alpha)
        {
            int w = subj.GetWidth();
            int h = subj.GetHeight();
            int nw = MmgScreenData.GetGameWidth();
            int nh = MmgScreenData.GetGameHeight();
            Texture2D img = subj.GetImage();

            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D bg = new RenderTarget2D(gd, nw, nh);

            g.GraphicsDevice.SetRenderTarget(bg);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(img, new Rectangle(0, 0, nw, nh), new Rectangle(0, 0, w, h), Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            return new MmgBmp(bg);
        }

        /// <summary>
        /// A static class method that scales an MmgBmp object to the specified size.
        /// </summary>
        /// <param name="subj">The MmgBmp object to scale to the specified size.</param>
        /// <param name="newSize">The size to scale the MmgBmp object to, specified by an MmgVector2 object instance.</param>
        /// <param name="alpha">A bool flag indicating if transparency should be taken into consideration when creating new images.</param>
        /// <returns>A new MmgBmp object instance scaled to the size of the screen.</returns>
        public static MmgBmp ScaleMmgBmp(MmgBmp subj, MmgVector2 newSize, bool alpha)
        {
            int w = subj.GetWidth();
            int h = subj.GetHeight();
            int nw = newSize.GetX();
            int nh = newSize.GetY();
            Texture2D img = subj.GetImage();

            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D bg = new RenderTarget2D(gd, nw, nh);

            g.GraphicsDevice.SetRenderTarget(bg);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(img, new Rectangle(0, 0, nw, nh), new Rectangle(0, 0, w, h), Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            return new MmgBmp(bg);
        }

        /// <summary>
        /// A static class method that scales an MmgBmp object to the screen's X scaling.
        /// </summary>
        /// <param name="subj">The MmgBmp object to scale to the specified size.</param>
        /// <param name="useScreenDataScaleX">The scaling size of the screen in the X direction.</param>
        /// <param name="alpha">A bool flag indicating if transparency should be taken into consideration when creating new images.</param>
        /// <returns>A new MmgBmp object instance scaled to the size of the screen's X coordinate scale.</returns>
        public static MmgBmp ScaleMmgBmp(MmgBmp subj, bool useScreenDataScaleX, bool alpha)
        {
            int w = subj.GetWidth();
            int h = subj.GetHeight();
            int nw = 0;
            int nh = 0;

            if (useScreenDataScaleX)
            {
                nw = (int)(w * MmgScreenData.GetScaleX());
                nh = (int)(h * MmgScreenData.GetScaleX());
            }
            else
            {
                nw = (int)(w * MmgScreenData.GetScaleY());
                nh = (int)(h * MmgScreenData.GetScaleY());
            }

            Texture2D img = subj.GetImage();
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D bg = new RenderTarget2D(gd, nw, nh);

            g.GraphicsDevice.SetRenderTarget(bg);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(img, new Rectangle(0, 0, nw, nh), new Rectangle(0, 0, w, h), Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            return new MmgBmp(bg);
        }

        /// <summary>
        /// A static class method that scales an MmgBmp object to the provided scale value.
        /// </summary>
        /// <param name="subj">The MmgBmp object to scale to the specified size.</param>
        /// <param name="scale">The value to scale the MmgBmp to.</param>
        /// <param name="alpha">A bool flag indicating if transparency should be taken into consideration when creating new images.</param>
        /// <returns>A new MmgBmp object instance scaled to the size of the provided scale value.</returns>
        public static MmgBmp ScaleMmgBmp(MmgBmp subj, double scale, bool alpha)
        {
            int w = subj.GetWidth();
            int h = subj.GetHeight();
            int nw = (int)(w * scale);
            int nh = (int)(h * scale);
            Texture2D img = subj.GetImage();

            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D bg = new RenderTarget2D(gd, nw, nh);

            g.GraphicsDevice.SetRenderTarget(bg);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(img, new Rectangle(0, 0, nw, nh), new Rectangle(0, 0, w, h), Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            return new MmgBmp(bg);
        }

        /// <summary>
        /// A static class method that creates a new rotated image from a subject image and returns in.
        /// </summary>
        /// <param name="subj">The MmgBmp object to rotate to the specified angle.</param>
        /// <param name="angle">The angle to rotate the image to.</param>
        /// <param name="alpha">A bool flag indicating if transparency should be taken into consideration when creating new images.</param>
        /// <returns>A new MmgBmp rotated to the specified angle.</returns>
        public static MmgBmp RotateMmgBmp(MmgBmp subj, int angle, bool alpha)
        {
            int w = subj.GetWidth();
            int h = subj.GetHeight();
            Texture2D img = subj.GetImage();

            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D bg = new RenderTarget2D(gd, w, h);

            g.GraphicsDevice.SetRenderTarget(bg);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(img, new Rectangle(0, 0, w, h), new Rectangle(0, 0, w, h), Color.White, (float)MmgHelper.ConvertToRadians(angle), new Vector2(w/2, h/2), SpriteEffects.None, 0);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            MmgBmp r = new MmgBmp(bg);
            r.SetScaling(MmgVector2.GetUnitVec());
            r.SetPosition(MmgVector2.GetOriginVec());
            r.SetOrigin(MmgVector2.GetOriginVec());
            r.SetMmgColor(null);
            return r;
        }
    }
}