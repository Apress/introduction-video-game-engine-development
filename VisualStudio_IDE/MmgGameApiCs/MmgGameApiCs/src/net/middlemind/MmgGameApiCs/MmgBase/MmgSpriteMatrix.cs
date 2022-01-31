using System;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that splits a source image into frames, sprite animation frames, based on the provided dimension of each frame.
    /// Created by Middlemind Games 08/14/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgSpriteMatrix
    {
        /// <summary>
        /// The source image to split into frames.
        /// </summary>
        private MmgBmp src;

        /// <summary>
        /// The frames extracted from the source image.
        /// </summary>
        private MmgBmp[] frames;

        /// <summary>
        /// The width of a frame from the source image.
        /// </summary>
        private int width;

        /// <summary>
        /// The height of a frame from the source image.
        /// </summary>
        private int height;

        /// <summary>
        /// The number of rows in the sprite matrix.
        /// </summary>
        private int rowCount;

        /// <summary>
        /// The number of columns in the sprite matrix.
        /// </summary>
        private int colCount;

        /// <summary>
        /// A constructor that takes a sprite frame source image and splits it into frames based on the image dimensions and the provided frame dimensions.
        /// </summary>
        /// <param name="Src">The source image to split into frames.</param>
        /// <param name="Width">The width of a frame from the source image.</param>
        /// <param name="Height">The height of a frame from the source image.</param>
        /// <param name="RowCnt"></param>
        /// <param name="ColCnt"></param>
        public MmgSpriteMatrix(MmgBmp Src, int Width, int Height, int RowCnt, int ColCnt)
        {
            src = Src;
            width = Width;
            height = Height;
            rowCount = RowCnt;
            colCount = ColCnt;
            Prep();
        }

        /// <summary>
        /// A specialized constructor that takes an MmgSpriteSheet instance as an argument.
        /// </summary>
        /// <param name="obj">The MmgSpriteSheet object to use as the basis for a new object.</param>
        public MmgSpriteMatrix(MmgSpriteMatrix obj)
        {
            if (obj.GetSrc() == null)
            {
                SetSrc(obj.GetSrc());
            }
            else
            {
                SetSrc(obj.GetSrc().CloneTyped());
            }

            if (obj.GetFrames() == null)
            {
                SetFrames(obj.GetFrames());
            }
            else
            {
                int len = obj.GetFrameCount();
                frames = new MmgBmp[len];
                for (int i = 0; i < len; i++)
                {
                    if (obj.GetFrames()[i] != null)
                    {
                        frames[i] = obj.GetFrames()[i].CloneTyped();
                    }
                    else
                    {
                        frames[i] = null;
                    }
                }
            }

            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());
            SetRowCount(obj.GetRowCount());
            SetColCount(obj.GetColCount());
        }

        /// <summary>
        /// Returns a cloned instance of this object.
        /// </summary>
        /// <returns>A cloned instance of this object.</returns>
        public virtual MmgSpriteMatrix CloneTyped()
        {
            return new MmgSpriteMatrix(this);
        }

        /// <summary>
        /// This method prepares the individual frames by copying them out into individual images.
        /// </summary>
        public virtual void Prep()
        {
            int frameCount = rowCount * colCount;
            int posX = 0;
            int posY = 0;
            MmgDrawableBmpSet bmpSet = null;
            frames = new MmgBmp[frameCount];

            for (int i = 0; i < frameCount; i++)
            {
                bmpSet = MmgHelper.CreateDrawableBmpSet(width, height, true);
                bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(bmpSet.buffImg);
                bmpSet.p.GetGraphics().Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                bmpSet.p.GetGraphics().GraphicsDevice.Clear(MmgColor.GetTransparent().GetColor());
                bmpSet.p.DrawBmp(src, new MmgRect(posX, posY, posY + height, posX + width), new MmgRect(0, 0, height, width));
                bmpSet.p.GetGraphics().End();
                bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(null);

                frames[i] = bmpSet.img;

                if (posX + width >= src.GetWidth())
                {
                    posX = 0;
                    if (posY + height >= src.GetHeight())
                    {
                        break;
                    }
                    else
                    {
                        posY += height;
                    }
                }
                else
                {
                    posX += width;
                }
            }
        }

        /// <summary>
        /// Gets the row count of the sprite matrix.
        /// </summary>
        /// <returns>The row count of the sprite matrix.</returns>
        public virtual int GetRowCount()
        {
            return rowCount;
        }

        /// <summary>
        /// Sets the row count of the sprite matrix.
        /// </summary>
        /// <param name="i">The row count of the sprite matrix.</param>
        public virtual void SetRowCount(int i)
        {
            rowCount = i;
        }

        /// <summary>
        /// Gets the col count of the sprite matrix.
        /// </summary>
        /// <returns>The col count of the sprite matrix.</returns>
        public virtual int GetColCount()
        {
            return colCount;
        }

        /// <summary>
        /// Sets the col count of the sprite matrix.
        /// </summary>
        /// <param name="i">The col count of the sprite matrix.</param>
        public virtual void SetColCount(int i)
        {
            colCount = i;
        }

        /// <summary>
        /// Returns the number of frames in the sprite sheet.
        /// </summary>
        /// <returns>The number of frames in the sprite sheet.</returns>
        public virtual int GetFrameCount()
        {
            return frames.Length;
        }

        /// <summary>
        /// Returns the source image used as the basis for copying out sprite animation frames.
        /// </summary>
        /// <returns>The source image the sprite animation frames are based off of.</returns>
        public virtual MmgBmp GetSrc()
        {
            return src;
        }

        /// <summary>
        /// Sets the source image used as the basis for copying out sprite animation frames.
        /// </summary>
        /// <param name="b">The source image the sprite animation frames are based off of.</param>
        public virtual void SetSrc(MmgBmp b)
        {
            src = b;
        }

        /// <summary>
        /// Returns the array of sprite animation frames.
        /// </summary>
        /// <returns>The array of sprite animation frames.</returns>
        public virtual MmgBmp[] GetFrames()
        {
            return frames;
        }

        /// <summary>
        /// Sets the array of sprite animation frames.
        /// </summary>
        /// <param name="f">The array of sprite animation frames.</param>
        public virtual void SetFrames(MmgBmp[] f)
        {
            frames = f;
        }

        /// <summary>
        /// Gets the width of a sprite animation frame.
        /// </summary>
        /// <returns>The width of a sprite animation frame.</returns>
        public virtual int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Sets the width of a sprite animation frame.
        /// </summary>
        /// <param name="w">The width of a sprite animation frame.</param>
        public virtual void SetWidth(int w)
        {
            width = w;
        }

        /// <summary>
        /// Gets the height of a sprite animation frame.
        /// </summary>
        /// <returns>The height of a sprite animation frame.</returns>
        public virtual int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Sets the height of a sprite animation frame.
        /// </summary>
        /// <param name="h">The height of a sprite animation frame.</param>
        public virtual void SetHeight(int h)
        {
            height = h;
        }

        /// <summary>
        /// Gets the MmgBmp frame at the given index.
        /// </summary>
        /// <param name="i">The index of the frame at the given index.</param>
        /// <returns>The MmgBmp of the frame at the given index.</returns>
        public virtual MmgBmp GetFrame(int i)
        {
            return frames[i];
        }

        /// <summary>
        /// Sets the MmgBmp frame at the given index.
        /// </summary>
        /// <param name="b">The MmgBmp of the frame at the given index.</param>
        /// <param name="i">The index of the frame at the given index.</param>
        public void SetFrame(MmgBmp b, int i)
        {
            frames[i] = b;
        }

        /// <summary>
        /// A method that checks the equality of this MmgSpriteSheet object and the given argument.
        /// </summary>
        /// <param name="obj">The MmgSpriteSheet object to compare this object to.</param>
        /// <returns>Returns true if the two objects are equal and false otherwise.</returns>
        public virtual bool ApiEquals(MmgSpriteMatrix obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = true;
            if (
                ((obj.GetSrc() == null && GetSrc() == null) || (obj.GetSrc() != null && GetSrc() != null && obj.GetSrc().ApiEquals(GetSrc())))
                && GetWidth() == obj.GetWidth()
                && GetHeight() == obj.GetHeight()
                && GetRowCount() == obj.GetRowCount()
                && GetColCount() == obj.GetColCount()
            )
            {
                int len1 = obj.GetFrameCount();
                int len2 = GetFrameCount();
                if (len1 == len2)
                {
                    MmgObj m1;
                    MmgObj m2;
                    for (int i = 0; i < len1; i++)
                    {
                        m1 = obj.GetFrame(i);
                        m2 = GetFrame(i);
                        if (
                            !((m1 == null && m2 == null) || (m1 != null && m2 != null && m1.ApiEquals(m2)))
                        )
                        {
                            ret = false;
                            break;
                        }
                    }
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }

            return ret;
        }
    }
}