using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that provides 9 slice bitmap scaling support. 
    /// Created by Middlemind Games 12/01/2016
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class Mmg9Slice : MmgObj
    {
        /// <summary>
        /// The offset to use when slicing the source image.
        /// </summary>
        private int offset;

        /// <summary>
        /// The source image to slice and expand onto the destination image. 
        /// </summary>
        private MmgBmp src;

        /// <summary>
        /// The destination image the receives the split and expanded source image.
        /// </summary>
        private MmgBmp dest;

        /// <summary>
        /// Default constructor that takes a source MmgBmp to slice an offset and dimensions for the expanded source bitmap.
        /// </summary>
        /// <param name="Offset">The offset to use when slicing the source MmgBmp object.</param>
        /// <param name="Src">The source MmgBmp object that will be sliced and expanded.</param>
        /// <param name="w">The desired width of the resulting expanded source MmgBmp object.</param>
        /// <param name="h">The desired height of the resulting expanded source MmgBmp object.</param>
        public Mmg9Slice(int Offset, MmgBmp Src, int w, int h) : base()
        {
            SetOffset(Offset);
            SetSrc(Src);
            SetWidth(w);
            SetHeight(h);
            DrawDest();
            SetPosition(MmgVector2.GetOriginVec());
            SetIsVisible(true);
        }

        /// <summary>
        /// Mmg9Slice constructor that is similar to the default constructor except it also takes position information used to position the resulting images.
        /// </summary>
        /// <param name="Offset">The offset to use when slicing the source MmgBmp object.</param>
        /// <param name="Src">The source MmgBmp object that will be sliced and expanded.</param>
        /// <param name="w">The desired width of the resulting expanded source MmgBmp object.</param>
        /// <param name="h">The desired height of the resulting expanded source MmgBmp object.</param>
        /// <param name="Pos">The desired position to set for the expanded MmgBmp object.</param>
        public Mmg9Slice(int Offset, MmgBmp Src, int w, int h, MmgVector2 Pos) : base()
        {
            SetOffset(Offset);
            SetSrc(Src);
            SetWidth(w);
            SetHeight(h);
            DrawDest();
            SetPosition(Pos);
            SetIsVisible(true);
        }

        /// <summary>
        /// Mmg9Slice that creates a clean instance from an existing Mmg9Slice object.
        /// </summary>
        /// <param name="obj">The Mmg9Slice object to create a clean instance from.</param>
        public Mmg9Slice(Mmg9Slice obj) : base()
        {
            SetOffset(obj.GetOffset());

            if (obj.GetSrc() == null)
            {
                SetSrc(obj.GetSrc());
            }
            else
            {
                SetSrc(obj.GetSrc().CloneTyped());
            }

            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());

            DrawDest();

            if (obj.GetDest() == null)
            {
                SetDest(obj.GetDest());
            }
            else
            {
                SetDest(obj.GetDest().CloneTyped());
            }

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            SetIsVisible(obj.GetIsVisible());
        }

        /// <summary>
        /// Sets the offset used when slicing up the source MmgBmp object.
        /// DrawDest must be called again to redo any slicing that was done by the constructor.
        /// </summary>
        /// <param name="i">The offset to use in the 9 slice process.</param>
        public virtual void SetOffset(int i)
        {
            offset = i;
        }

        /// <summary>
        /// The offset used in the 9 slice process.
        /// </summary>
        /// <returns>The offset used in the 9 slice process.</returns>
        public virtual int GetOffset()
        {
            return offset;
        }

        /// <summary>
        /// The source MmgBmp object used in the 9 slice process and expanded on to the destination MmgBmp.
        /// The DrawDest method must be called again to redo any slicing that was done by the constructor.
        /// </summary>
        /// <param name="b">The MmgBmp to use as the source object in the 9 slice process.</param>
        public virtual void SetSrc(MmgBmp b)
        {
            src = b;
        }

        /// <summary>
        /// The source MmgBmp object used in the 9 slice process.
        /// </summary>
        /// <returns>The source MmgBmp object used in the 9 slice process.</returns>
        public virtual MmgBmp GetSrc()
        {
            return src;
        }

        /// <summary>
        /// Sets the destination MmgBmp object. This object is normally created by the constructor
        /// but you can override that image and set it directly.Position information may need to
        /// be updated if you are setting this directly.
        /// </summary>
        /// <param name="b">The MmgBmp object to use as the 9 slice destination, i.e. resulting drawable object.</param>
        public virtual void SetDest(MmgBmp b)
        {
            dest = b;
        }

        /// <summary>
        /// Returns the destination object created from slicing the source MmgBmp object and expanding it onto the destination object.
        /// </summary>
        /// <returns>The MmgBmp object used as the 9 slice destination, i.e. resulting drawable object.</returns>
        public virtual MmgBmp GetDest()
        {
            return dest;
        }

        /// <summary>
        /// Slices the source MmgBmp object and expands it onto the desired sized destination MmgBmp object.
        /// </summary>
        public virtual void DrawDest()
        {
            int fs = offset;
            MmgBmp b = GetSrc();
            Texture2D img = b.GetImage();
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D bg = new RenderTarget2D(gd, GetWidth(), GetHeight());
            g.GraphicsDevice.SetRenderTarget(bg);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            //TOP
            //draw top left
            g.Draw(img, new Rectangle(0, 0, fs, fs), new Rectangle(0, 0, fs, fs), Color.White);

            //draw scaled top center
            g.Draw(img, new Rectangle(fs, 0, GetWidth() - fs - fs, fs), new Rectangle(fs, 0, b.GetWidth() - fs - fs, fs), Color.White);

            //draw top right
            g.Draw(img, new Rectangle(GetWidth() - fs, 0, fs, fs), new Rectangle(b.GetWidth() - fs, 0, fs, fs), Color.White);

            //MIDDLE
            //draw middle left
            g.Draw(img, new Rectangle(0, fs, fs, GetHeight() - fs - fs), new Rectangle(0, fs, fs, b.GetHeight() - fs - fs), Color.White);

            //draw middle center
            g.Draw(img, new Rectangle(fs, fs, GetWidth() - fs - fs, GetHeight() - fs - fs), new Rectangle(fs, fs, b.GetWidth() - fs - fs, b.GetHeight() - fs - fs), Color.White);

            //draw middle right
            g.Draw(img, new Rectangle(GetWidth() - fs, fs, fs, GetHeight() - fs - fs), new Rectangle(b.GetWidth() - fs, fs, fs, b.GetHeight() - fs - fs), Color.White);

            //BOTTOM
            //draw bottom left
            g.Draw(img, new Rectangle(0, GetHeight() - fs, fs, fs), new Rectangle(0, b.GetHeight() - fs, fs, fs), Color.White);

            //draw scaled bottom center
            g.Draw(img, new Rectangle(fs, GetHeight() - fs, GetWidth() - fs - fs, fs), new Rectangle(fs, b.GetHeight() - fs, b.GetWidth() - fs - fs, fs), Color.White);

            //draw bottom right
            g.Draw(img, new Rectangle(GetWidth() - fs, GetHeight() - fs, fs, fs), new Rectangle(b.GetWidth() - fs, b.GetHeight() - fs, fs, fs), Color.White);

            g.End();
            g.GraphicsDevice.SetRenderTarget(null);
            dest = new MmgBmp(bg);
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new Mmg9Slice(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new Mmg9Slice CloneTyped()
        {
            return new Mmg9Slice(this);
        }

        /// <summary>
        /// Gets the MmgColor of the destination object.
        /// </summary>
        /// <returns>The MmgColor of the destination object.</returns>
        public override MmgColor GetMmgColor()
        {
            return dest.GetMmgColor();
        }

        /// <summary>
        /// Sets the MmgColor of the destination object.
        /// </summary>
        /// <param name="c">The MmgColor of the destination object.</param>
        public override void SetMmgColor(MmgColor c)
        {
            dest.SetMmgColor(c);
        }

        /// <summary>
        /// The base drawing method for this object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                p.DrawBmp(dest, GetPosition());
            }
        }

        /// <summary>
        /// Tests if this object is equal to another Mmg9Slice object.
        /// </summary>
        /// <param name="obj">An Mmg9Slice object instance to compare to.</param>
        /// <returns>Returns true if the objects are considered equal and false otherwise.</returns>
        public virtual bool ApiEquals(Mmg9Slice obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            if(!(base.equals((MmgObj)obj))) {
                MmgHelper.wr("Mmg9Slice MmgObj is not equals!");
            }

            if(!(GetOffset() == obj.GetOffset())) {
                MmgHelper.wr("Mmg9Slice Offset is not equals!");            
            }

            if(!(((obj.GetSrc() == null && GetSrc() == null) || (obj.GetSrc() != null && GetSrc() != null && obj.GetSrc().equals(GetSrc()))))) {
                MmgHelper.wr("Mmg9Slice Src is not equals!");                        
            }

            if(!(((obj.GetDest() == null && GetDest() == null) || (obj.GetDest() != null && GetDest() != null && obj.GetDest().equals(GetDest()))))) {
                MmgHelper.wr("Mmg9Slice Dst is not equals!");                                    
            }
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && GetOffset() == obj.GetOffset()
                && ((obj.GetSrc() == null && GetSrc() == null) || (obj.GetSrc() != null && GetSrc() != null && obj.GetSrc().ApiEquals(GetSrc())))
                && ((obj.GetDest() == null && GetDest() == null) || (obj.GetDest() != null && GetDest() != null && obj.GetDest().ApiEquals(GetDest())))
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}