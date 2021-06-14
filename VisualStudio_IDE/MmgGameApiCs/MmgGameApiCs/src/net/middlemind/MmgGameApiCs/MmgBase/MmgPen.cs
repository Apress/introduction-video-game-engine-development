using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Main drawing class, wraps lower level drawing classes.
    /// Created by Middlemind Games
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgPen
    {
        //NOTE: Added to the Monogame version to help make font handling similar to the Java version.
        /// <summary>
        /// A boolean flag that indicates if the font position should be run through a normalization method.
        /// </summary>
        public static bool FONT_NORMALIZE_POSITION = true;

        //NOTE: Added to the Monogame version to help make font handling similar to the Java version.
        /// <summary>
        /// An integer value representing the default font vertical adjustment value.
        /// </summary>
        public static int FONT_VERT_POS_ADJ = 6;

        /// <summary>
        /// The lower level drawing class. 
        /// </summary>
        private SpriteBatch pen;

        /// <summary>
        /// A value to use as an empty color since we cannot assign null to Color fields.
        /// </summary>
        public static Color EMPTY_COLOR = new Color(255, 0, 255);

        /// <summary>
        /// The color to use when drawing.
        /// </summary>
        private Color color = MmgPen.EMPTY_COLOR;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private Texture2D tmpImg;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private string tmpIdStr;

        /// <summary>
        /// Determines if the bitmap cache is on.
        /// </summary>
        private bool cacheOn;

        /// <summary>
        /// Determines if advanced render hints is turned on.
        /// </summary>
        public static bool ADV_RENDER_HINTS = true;

        /// <summary>
        /// A static class field that holds a reference to a transparent Color class instance.
        /// </summary>
        public static Color TRANSPARENT = new Color(0f, 0f, 0f, 1f);

        //NOTE: The Monogame version of the API uses a SpriteBatch to process 2D drawing requests.
        //The SpriteBatch has access to a GraphicsDevice which can select the render target.
        //In this way you can mimic the use of a Graphics2D object and a BufferedImage that the Java API uses.
        /// <summary>
        /// An image surface, Texture2D surface that can be the target of a SpriteBatch's drawing operations.
        /// </summary>
        private RenderTarget2D renderTarget;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgPen()
        {
            cacheOn = false;
        }

        /// <summary>
        /// Constructor that sets the local Graphics reference.
        /// </summary>
        /// <param name="p">The Graphics reference to use for drawing.</param>
        public MmgPen(SpriteBatch p)
        {
            pen = p;
            cacheOn = false;
        }

        //NOTE: This constructor may not function the same as the Java API because the render target is central to the SpriteBatch.
        /// <summary>
        /// Constructor that sets the local graphics reference from the Texture2D argument.
        /// </summary>
        /// <param name="img">The Texture2D from which the graphics context is used to create this MmgPen.</param>
        public MmgPen(Texture2D img)
        {
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            renderTarget = (RenderTarget2D)img;
            g.GraphicsDevice.SetRenderTarget(renderTarget);
            pen = g;
            cacheOn = false;
        }

        /// <summary>
        /// Constructor that sets the local Graphics reference and the color
        /// of the pen.
        /// </summary>
        /// <param name="p">The Graphics reference to use for drawing.</param>
        /// <param name="c">The color to use for drawing.</param>
        public MmgPen(SpriteBatch p, Color c)
        {
            pen = p;
            color = c;
            cacheOn = false;
        }

        /// <summary>
        /// Sets the bitmap drawing cache.
        /// </summary>
        /// <param name="b">True if the bitmap drawing cache is on, false otherwise.</param>
        public virtual void SetCacheOn(bool b)
        {
            cacheOn = b;
        }

        /// <summary>
        /// Gets the bitmap drawing cache.
        /// </summary>
        /// <returns>True if the bitmap drawing cache is on, false otherwise.</returns>
        public virtual bool GetCacheOn()
        {
            return cacheOn;
        }

        /// <summary>
        /// Drawing method to use for drawing text to the screen.
        /// </summary>
        /// <param name="f">The MmgFont object to draw.</param>
        public virtual void DrawText(MmgFont f)
        {
            if (FONT_NORMALIZE_POSITION)
            {
                pen.DrawString(f.GetFont(), f.GetText(), new Vector2(MmgHelper.NormalizeFontPositionX(f.GetX(), f), MmgHelper.NormalizeFontPositionY(f.GetY(), f)), f.GetMmgColor().GetColor());
            }
            else
            {
                pen.DrawString(f.GetFont(), f.GetText(), new Vector2(f.GetX(), f.GetY() - f.GetHeight() + FONT_VERT_POS_ADJ), f.GetMmgColor().GetColor());
            }
        }

        /// <summary>
        /// Drawing method to use for drawing text to the screen at the specified position.
        /// </summary>
        /// <param name="f">The MmgFont object to draw.</param>
        /// <param name="x">The x position to draw the object.</param>
        /// <param name="y">The y position to draw the object.</param>
        public virtual void DrawText(MmgFont f, int x, int y)
        {            
            if (FONT_NORMALIZE_POSITION)
            {
                pen.DrawString(f.GetFont(), f.GetText(), new Vector2(MmgHelper.NormalizeFontPositionX(x, f), MmgHelper.NormalizeFontPositionY(y, f)), f.GetMmgColor().GetColor());
            }
            else
            {
                y -= f.GetHeight() + FONT_VERT_POS_ADJ;
                pen.DrawString(f.GetFont(), f.GetText(), new Vector2(x, y), f.GetMmgColor().GetColor());
            }
        }

        /// <summary>
        /// Drawing method to use for drawing text to the screen at the specified position.
        /// </summary>
        /// <param name="f">The MmgFont object to draw.</param>
        /// <param name="pos">The position to draw the object.</param>
        public virtual void DrawText(MmgFont f, MmgVector2 pos)
        {
            if (FONT_NORMALIZE_POSITION)
            {
                pen.DrawString(f.GetFont(), f.GetText(), new Vector2(MmgHelper.NormalizeFontPositionX(pos.GetX(), f), MmgHelper.NormalizeFontPositionY(pos.GetY(), f)), f.GetMmgColor().GetColor());
            }
            else
            {
                pen.DrawString(f.GetFont(), f.GetText(), new Vector2(pos.GetX(), pos.GetY() - f.GetHeight() + FONT_VERT_POS_ADJ), f.GetMmgColor().GetColor());
            }
        }

        /// <summary>
        /// Rotate the given image by the given degrees.
        /// </summary>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        /// <param name="img">The image to rotate.</param>
        /// <param name="angle">The angle to rotate the image.</param>
        /// <param name="originX">The origin X to use in rotation.</param>
        /// <param name="originY">The origin Y to use in rotation.</param>
        /// <returns>A newly rotated image.</returns>
        public virtual Texture2D RotateImage(int width, int height, Texture2D img, int angle, int originX, int originY)
        {
            return MmgPen.RotateImageStatic(width, height, img, angle, originX, originY);
        }

        /// <summary>
        /// Rotate the given image by the given degrees.
        /// </summary>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        /// <param name="img">The image to rotate.</param>
        /// <param name="angle">The angle to rotate the image.</param>
        /// <param name="originX">The origin X to use in rotation.</param>
        /// <param name="originY">The origin Y to use in rotation.</param>
        /// <returns>A newly rotated image.</returns>
        public static Texture2D RotateImageStatic(int width, int height, Texture2D img, int angle, int originX, int originY)
        {
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D bg = new RenderTarget2D(gd, width, height);

            g.GraphicsDevice.SetRenderTarget(bg);

            if (originX == -1 || originY == -1)
            {
                originX = (width / 2);
                originY = (height / 2);
            }

            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(img, new Rectangle(0, 0, img.Width, img.Height), new Rectangle(0, 0, width, height), Color.White, MmgHelper.ConvertToRadians(angle), new Vector2(originX, originY), SpriteEffects.None, 0.0f);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            return (Texture2D)bg;
        }

        /// <summary>
        /// Scale the given image by the given scale factor.
        /// </summary>
        /// <param name="img">The image to scale.</param>
        /// <param name="scaleX">The scale factor in the X axis direction.</param>
        /// <param name="scaleY">The scale factor in the Y axis direction.</param>
        /// <returns>A scaled image.</returns>
        public virtual Texture2D ScaleImage(Texture2D img, double scaleX, double scaleY)
        {
            return MmgPen.ScaleImageStatic(img, scaleX, scaleY);
        }

        /// <summary>
        /// Scale the given image by the given scale factor.
        /// </summary>
        /// <param name="img">The image to scale.</param>
        /// <param name="scale">The scale factor in the X, Y axis directions.</param>
        /// <returns>A scaled image.</returns>
        public static Texture2D ScaleImageStatic(Texture2D img, MmgVector2 scale)
        {
            return MmgPen.ScaleImageStatic(img, scale.GetXDouble(), scale.GetYDouble());
        }

        /// <summary>
        /// Static scale method, scales the given image by the given X,Y axis directions.
        /// </summary>
        /// <param name="img">The image to scale.</param>
        /// <param name="scaleX">The scale factor in the X axis direction.</param>
        /// <param name="scaleY">The scale factor in the Y axis direction.</param>
        /// <returns>A scaled image.</returns>
        public static Texture2D ScaleImageStatic(Texture2D img, double scaleX, double scaleY)
        {
            int w = (int)(img.Width * scaleX);
            int h = (int)(img.Height * scaleY);
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D rImage = new RenderTarget2D(gd, w, h);

            g.GraphicsDevice.SetRenderTarget(rImage);
            g.GraphicsDevice.Clear(Color.Transparent);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(img, new Rectangle(0, 0, w, h), new Rectangle(0, 0, img.Width, img.Height), Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            return (Texture2D)rImage;
        }

        /// <summary>
        /// Creates an Texture2D that is filled with the specified color.
        /// </summary>
        /// <param name="w">The width of the image to create.</param>
        /// <param name="h">The height of the image to create.</param>
        /// <param name="c">The color to use for filling the image.</param>
        /// <returns>A colored image with the width and height specified and filled with the specified color.</returns>
        public static Texture2D CreateColorTile(int w, int h, MmgColor c)
        {
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            Texture2D rImage = new Texture2D(gd, w, h);
            Color[] pixels = new Color[w * h];
            rImage.GetData<Color>(pixels);

            for(int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = c.GetColor();
            }

            rImage.SetData<Color>(pixels);
            return rImage;
        }

        /// <summary>
        /// Sets the advanced render hints flags in the current Graphics context.
        /// </summary>
        public virtual void SetAdvRenderHints()
        {
            if (MmgPen.ADV_RENDER_HINTS == true)
            {
                //ADV_RENDER_HINTS does nothing in this port of the API.
                //MmgHelper.wr("ADV_RENDER_HINTS does nothing in this port.");
            }
            else
            {
                MmgHelper.wr("ADV_RENDER_HINTS is set to false.");
            }
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="idStr">The id in string form of the image to draw.</param>
        /// <param name="position">The position to draw the image.</param>
        public virtual void DrawBmpBasic(string idStr, MmgVector2 position)
        {
            tmpImg = MmgMediaTracker.GetBmpValue(idStr);
            if (tmpImg != null)
            {
                DrawBmp(tmpImg, position.GetX(), position.GetY());
            }
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="img">The image to be drawn.</param>
        /// <param name="x">The X axis offset to draw the image at.</param>
        /// <param name="y">The Y axis offset to draw the image at.</param>
        public virtual void DrawBmp(Texture2D img, int x, int y)
        {
            pen.Draw(img, new Vector2(x, y), Color.White);
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        public virtual void DrawBmpBasic(MmgBmp b)
        {
            DrawBmp(b, b.GetPosition());
        }

        /// <summary>
        /// Drawing method for drawing a bitmap from the central cache.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        public virtual void DrawBmpFromCache(MmgBmp b)
        {
            DrawBmpBasic(b.GetBmpIdStr(), b.GetPosition());
        }

        /// <summary>
        /// A method to check if the specified Color is considered to be the empty color.
        /// </summary>
        /// <param name="c">The Color with which to check equivalence to the empty color.</param>
        /// <returns>A boolean indicating if the provided Color is empty or not.</returns>
        public bool IsEmptyColor(Color c)
        {
            if(c.R == 255 && c.G == 0 && c.B == 255)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        /// <param name="position">The position to draw the object at.</param>
        public virtual void DrawBmp(MmgBmp b, MmgVector2 position)
        {
            if (IsEmptyColor(color) == false)
            {
                if (position is MmgVector2Vec)
                {
                    pen.Draw(b.GetTexture2D(), ((MmgVector2Vec)position).GetVector2(), color);
                }
                else
                {
                    pen.Draw(b.GetTexture2D(), new Vector2(position.GetX(), position.GetY()), color);
                }
            }
            else if (b.GetMmgColor() != null)
            {
                pen.Draw(b.GetTexture2D(), new Vector2(position.GetX(), position.GetY()), b.GetMmgColor().GetColor());
            }
            else
            {
                pen.Draw(b.GetTexture2D(), new Vector2(position.GetX(), position.GetY()), Color.White);
            }
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        /// <param name="x">The X coordinate to draw the image to.</param>
        /// <param name="y">The Y coordinate to draw the image to.</param>
        public virtual void DrawBmp(MmgBmp b, int x, int y)
        {
            if (IsEmptyColor(color) == false)
            {
                pen.Draw(b.GetTexture2D(), new Vector2(x, y), color);
            }
            else if (b.GetMmgColor() != null)
            {
                pen.Draw(b.GetTexture2D(), new Vector2(x, y), b.GetMmgColor().GetColor());
            }
            else
            {
                pen.Draw(b.GetTexture2D(), new Vector2(x, y), Color.White);
            }
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        /// <param name="position">The position to draw the object at.</param>
        /// <param name="rotation">The rotation to apply to the object.</param>
        public virtual void DrawBmp(MmgBmp b, MmgVector2 position, float rotation)
        {
            DrawBmp(b, position, new MmgVector2(b.GetWidth() / 2, b.GetHeight() / 2), rotation);
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        /// <param name="position">The position to draw the object at.</param>
        /// <param name="origin">The origin to draw the object from.</param>
        /// <param name="rotation">The rotation to apply to the object.</param>
        public virtual void DrawBmp(MmgBmp b, MmgVector2 position, MmgVector2 origin, float rotation)
        {
            tmpIdStr = b.GetIdStr(rotation);

            if (rotation != 0)
            {
                if (cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true)
                {
                    tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
                }
                else
                {
                    tmpImg = RotateImage(b.GetWidth(), b.GetHeight(), b.GetTexture2D(), (int)rotation, origin.GetX(), origin.GetY());
                    if (cacheOn == true)
                    {
                        MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
                    }
                }
            }
            else
            {
                tmpImg = b.GetTexture2D();
            }

            if (IsEmptyColor(color) == false)
            {
                if (position is MmgVector2Vec)
                {
                    pen.Draw(tmpImg, ((MmgVector2Vec)position).GetVector2(), color);
                }
                else
                {
                    pen.Draw(tmpImg, new Vector2(position.GetX(), position.GetY()), color);
                }
            }
            else if (b.GetMmgColor() != null)
            {
                if (position is MmgVector2Vec)
                {
                    pen.Draw(tmpImg, ((MmgVector2Vec)position).GetVector2(), b.GetMmgColor().GetColor());
                }
                else
                {
                    pen.Draw(tmpImg, new Vector2(position.GetX(), position.GetY()), b.GetMmgColor().GetColor());
                }
            }
            else
            {
                if (position is MmgVector2Vec)
                {
                    pen.Draw(tmpImg, ((MmgVector2Vec)position).GetVector2(), Color.White);
                }
                else
                {
                    pen.Draw(tmpImg, new Vector2(position.GetX(), position.GetY()), Color.White);
                }
            }
        }

        /// <summary>
        /// Draw a bitmap image onto another bitmap image using source and destination rectangles.
        /// </summary>
        /// <param name="b">The MmgBmp object used to draw the source rectangle to the destination rectangle.</param>
        /// <param name="srcRect">The source rectangle to use.</param>
        /// <param name="dstRect">The destination rectangle to use.</param>
        public virtual void DrawBmp(MmgBmp b, MmgRect srcRect, MmgRect dstRect)
        {
            tmpIdStr = b.GetBmpIdStr();

            if (cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true)
            {
                tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
            }
            else
            {
                tmpImg = b.GetTexture2D();
            }

            if (srcRect != null && dstRect != null)
            {
                pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), Color.White);
            }
            else if (srcRect == null)
            {
                pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(0, 0, b.GetWidth(), b.GetHeight()), Color.White);
            }
            else if (dstRect == null)
            {
                pen.Draw(tmpImg, new Rectangle(0, 0, b.GetWidth(), b.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), Color.White);
            }
            else
            {
                pen.Draw(tmpImg, new Rectangle(0, 0, b.GetWidth(), b.GetHeight()), new Rectangle(0, 0, b.GetWidth(), b.GetHeight()), Color.White);
            }
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        /// <param name="position">The position to draw the object at.</param>
        /// <param name="srcRect">The source rectangle to draw the image from.</param>
        /// <param name="dstRect">The destination rectangle to draw the image to.</param>
        /// <param name="scaling">The scaling to apply to the image.</param>
        /// <param name="origin">The origin to use to draw the image.</param>
        /// <param name="rotation">The rotation to apply to the image.</param>
        public virtual void DrawBmp(MmgBmp b, MmgVector2 position, MmgRect srcRect, MmgRect dstRect, MmgVector2 scaling, MmgVector2 origin, float rotation)
        {
            if (rotation != 0 && scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0))
            {
                tmpIdStr = b.GetIdStr(rotation, scaling);
            }
            else if (rotation != 0)
            {
                tmpIdStr = b.GetIdStr(rotation);
            }
            else if (scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0))
            {
                tmpIdStr = b.GetIdStr(scaling);
            }
            else
            {
                tmpIdStr = b.GetBmpIdStr();
            }

            if (cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true)
            {
                tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
            }
            else if (rotation != 0 && scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0))
            {
                if (cacheOn == true && MmgMediaTracker.HasBmpKey(b.GetIdStr(rotation)) == true)
                {
                    tmpImg = MmgMediaTracker.GetBmpValue(b.GetIdStr(rotation));
                }
                else
                {
                    tmpImg = RotateImage(b.GetWidth(), b.GetHeight(), b.GetTexture2D(), (int)rotation, origin.GetX(), origin.GetY());
                    if (cacheOn == true)
                    {
                        MmgMediaTracker.CacheImage(b.GetIdStr(rotation), tmpImg);
                    }
                }

                tmpImg = this.ScaleImage(tmpImg, scaling.GetXDouble(), scaling.GetYDouble());
                if (cacheOn == true)
                {
                    MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
                }
            }
            else if (rotation != 0)
            {
                if (cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true)
                {
                    tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
                }
                else
                {
                    tmpImg = RotateImage(b.GetWidth(), b.GetHeight(), b.GetTexture2D(), (int)rotation, origin.GetX(), origin.GetY());
                    if (cacheOn == true)
                    {
                        MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
                    }
                }
            }
            else if (scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0))
            {
                if (cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true)
                {
                    tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
                }
                else
                {
                    tmpImg = ScaleImage(tmpImg, scaling.GetXDouble(), scaling.GetYDouble());
                    if (cacheOn == true)
                    {
                        MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
                    }
                }
            }
            else
            {
                tmpImg = b.GetTexture2D();
            }

            if (dstRect == null)
            {
                if (srcRect == null)
                {
                    if (IsEmptyColor(color) == false)
                    {
                        if (position is MmgVector2Vec)
                        {
                            pen.Draw(tmpImg, ((MmgVector2Vec)position).GetVector2(), color);
                        }
                        else
                        {
                            pen.Draw(tmpImg, new Vector2(position.GetX(), position.GetY()), color);
                        }
                    }
                    else if (b.GetMmgColor() != null)
                    {
                        if (position is MmgVector2Vec)
                        {
                            pen.Draw(tmpImg, ((MmgVector2Vec)position).GetVector2(), b.GetMmgColor().GetColor());
                        }
                        else
                        {
                            pen.Draw(tmpImg, new Vector2(position.GetX(), position.GetY()), b.GetMmgColor().GetColor());
                        }
                    }
                    else
                    {
                        if (position is MmgVector2Vec)
                        {
                            pen.Draw(tmpImg, ((MmgVector2Vec)position).GetVector2(), Color.White);
                        }
                        else
                        {
                            pen.Draw(tmpImg, new Vector2(position.GetX(), position.GetY()), Color.White);
                        }
                    }
                }
                else
                {
                    //src rect is not null
                    if (IsEmptyColor(color) == false)
                    {
                        pen.Draw(tmpImg, new Rectangle(position.GetX(), position.GetY(), srcRect.GetWidth(), srcRect.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), color);
                    }
                    else if (b.GetMmgColor() != null)
                    {
                        pen.Draw(tmpImg, new Rectangle(position.GetX(), position.GetY(), srcRect.GetWidth(), srcRect.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), b.GetMmgColor().GetColor());
                    }
                    else
                    {
                        pen.Draw(tmpImg, new Rectangle(position.GetX(), position.GetY(), srcRect.GetWidth(), srcRect.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), Color.White);
                    }
                }
            }
            else
            {
                if (srcRect == null)
                {
                    if (IsEmptyColor(color) == false)
                    {
                        pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(0, 0, b.GetWidth(), b.GetHeight()), color);
                    }
                    else if (b.GetMmgColor() != null)
                    {
                        pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(0, 0, b.GetWidth(), b.GetHeight()), b.GetMmgColor().GetColor());
                    }
                    else
                    {
                        pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(0, 0, b.GetWidth(), b.GetHeight()), Color.White);
                    }
                }
                else
                {
                    if (IsEmptyColor(color) == false)
                    {
                        pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), color);
                    }
                    else if (b.GetMmgColor() != null)
                    {
                        pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), b.GetMmgColor().GetColor());
                    }
                    else
                    {
                        pen.Draw(tmpImg, new Rectangle(dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetWidth(), dstRect.GetHeight()), new Rectangle(srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetWidth(), srcRect.GetHeight()), Color.White);
                    }
                }
            }
        }

        /// <summary>
        /// Drawing method for drawing bitmap images.
        /// </summary>
        /// <param name="b">The MmgBmp object to draw.</param>
        public virtual void DrawBmp(MmgBmp b)
        {
            DrawBmp(b, b.GetPosition(), b.GetSrcRect(), b.GetDstRect(), b.GetScaling(), b.GetOrigin(), b.GetRotation());
        }

        /// <summary>
        /// Drawing method for drawing rectangles.
        /// </summary>
        /// <param name="obj">The MmgObj to draw a rectangle for.</param>
        public virtual void DrawRect(MmgObj obj)
        {
            DrawRect(obj.GetPosition().GetX(), obj.GetPosition().GetY(), obj.GetWidth(), obj.GetHeight());
        }

        /// <summary>
        /// Drawing method for drawing rectangles.
        /// </summary>
        /// <param name="obj">The MmgObj to draw a rectangle for.</param>
        /// <param name="pos">The position to use when drawing the rectangle.</param>
        public virtual void DrawRect(MmgObj obj, MmgVector2 pos)
        {
            DrawRect(pos.GetX(), pos.GetY(), obj.GetWidth(), obj.GetHeight());
        }

        /// <summary>
        /// Drawing method for drawing rectangles.
        /// </summary>
        /// <param name="r">The MmgRect object to draw.</param>
        public virtual void DrawRect(MmgRect r)
        {
            DrawRect(r.GetLeft(), r.GetTop(), r.GetWidth(), r.GetHeight());
        }

        /// <summary>
        /// Drawing method for drawing rectangles.
        /// </summary>
        /// <param name="x">The X axis offset.</param>
        /// <param name="y">The Y axis offset.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public virtual void DrawRect(int x, int y, int w, int h)
        {
            int nw = 1;
            int nh = 1;
            RenderTarget2D img = new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, nw, nh);
            Color[] pixels = new Color[] { color };
            img.GetData<Color>(pixels);
            pixels[0] = color;
            img.SetData<Color>(pixels);

            //draw top line
            pen.Draw(img, new Rectangle(x, y, w, 1), new Rectangle(0, 0, nw, nh), Color.White);

            //draw bottom line
            pen.Draw(img, new Rectangle(x, y + h, w, 1), new Rectangle(0, 0, nw, nh), Color.White);

            //draw left line
            pen.Draw(img, new Rectangle(x, y, 1, h), new Rectangle(0, 0, nw, nh), Color.White);

            //draw right line
            pen.Draw(img, new Rectangle(x + w, y, 1, h), new Rectangle(0, 0, nw, nh), Color.White);
        }

        /// <summary>
        /// Gets the lower level drawing class.
        /// </summary>
        /// <returns>A Graphics object.</returns>
        public virtual SpriteBatch GetSpriteBatch()
        {
            return pen;
        }

        /// <summary>
        /// Sets the lower level drawing class.
        /// </summary>
        /// <param name="sp">A Graphic object.</param>
        public virtual void SetSpriteBatch(SpriteBatch sp)
        {
            pen = sp;
        }

        /// <summary>
        /// Sets the lower level drawing class.
        /// </summary>
        /// <param name="sp">A Graphic object.</param>
        public virtual void SetGraphics(SpriteBatch sp)
        {
            SetSpriteBatch(sp);
        }

        /// <summary>
        /// Gets the lower level drawing class.
        /// </summary>
        /// <returns>A Graphics object.</returns>
        public virtual SpriteBatch GetGraphics()
        {
            return GetSpriteBatch();
        }

        /// <summary>
        /// Sets the color of the drawing pen.
        /// </summary>
        /// <param name="c">The color to set the pen to.</param>
        public virtual void SetColor(Color c)
        {
            color = c;
        }

        /// <summary>
        /// Gets the color of the drawing pen.
        /// </summary>
        /// <returns>The color to set the pen to.</returns>
        public virtual Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// Sets the color of this object and the lower level Java pen.
        /// </summary>
        /// <param name="c">The color of the pen.</param>
        public virtual void SetGraphicsColor(Color c)
        {
            color = c;
        }

        /// <summary>
        /// Gets the color of the lower level Java pen.
        /// </summary>
        /// <returns>The color of the pen.</returns>
        public virtual Color GetGraphicsColor()
        {
            return color;
        }
    }
}