using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that creates a loading bar object.
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgLoadingBar : MmgObj
    {
        /// <summary>
        /// The bitmap image of the back of the loading bar.
        /// </summary>
        private MmgBmp loadingBarBack;

        /// <summary>
        /// The bitmap image of the front of the loading bar. 
        /// </summary>
        private MmgBmp loadingBarFront;

        /// <summary>
        /// The X padding to use when drawing the loading bar front. 
        /// </summary>
        private int xPadding;

        /// <summary>
        /// The Y padding to use when drawing the loading bar front.
        /// </summary>
        private int yPadding;

        /// <summary>
        /// The fill amount of the loading bar.
        /// </summary>
        private float fillAmt;

        /// <summary>
        /// The fill height of the loading bar.
        /// </summary>
        private int fillHeight;

        /// <summary>
        /// The fill width of the loading bar.
        /// </summary>
        private int fillWidth;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgLoadingBar() : base()
        {
            SetLoadingBarBack(null);
            SetLoadingBarFront(null);
            SetPaddingX(0);
            SetPaddingY(0);
            SetFillHeight(MmgHelper.ScaleValue(10));
            SetFillWidth(MmgHelper.ScaleValue(100));
        }

        /// <summary>
        /// Constructor for this loading bar that sets all the class attributes based on the given argument.
        /// </summary>
        /// <param name="obj">The class to use to set all the attributes of this class.</param>
        public MmgLoadingBar(MmgLoadingBar obj) : base()
        {
            if (obj.GetLoadingBarBack() != null)
            {
                SetLoadingBarBack((MmgBmp)obj.GetLoadingBarBack().Clone());
            }
            else
            {
                SetLoadingBarBack(obj.GetLoadingBarBack());
            }

            if (obj.GetLoadingBarFront() != null)
            {
                SetLoadingBarFront((MmgBmp)obj.GetLoadingBarFront().Clone());
            }
            else
            {
                SetLoadingBarFront(obj.GetLoadingBarFront());
            }

            SetPaddingX(obj.GetPaddingX());
            SetPaddingY(obj.GetPaddingY());

            if (obj.GetPosition() != null)
            {
                SetPosition(obj.GetPosition().Clone());
            }
            else
            {
                SetPosition(obj.GetPosition());
            }

            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());
            SetFillHeight(obj.GetFillHeight());
            SetFillWidth(obj.GetFillWidth());

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }
        }

        /// <summary>
        /// Constructor that sets the front and back loading bar images.
        /// </summary>
        /// <param name="LoadingBarBack">The back loading bar image.</param>
        /// <param name="LoadingBarFront">The front loading bar image.</param>
        public MmgLoadingBar(MmgBmp LoadingBarBack, MmgBmp LoadingBarFront) : base()
        {
            SetLoadingBarBack(LoadingBarBack);
            SetLoadingBarFront(LoadingBarFront);
            SetPaddingX(0);
            SetPaddingY(0);
            SetPosition(new MmgVector2(0, 0));

            if (loadingBarFront != null)
            {
                SetWidth(loadingBarFront.GetWidth());
                SetHeight(loadingBarFront.GetHeight());
            }
            else
            {
                SetWidth(MmgHelper.ScaleValue(100));
                SetHeight(MmgHelper.ScaleValue(50));
            }

            SetFillHeight(GetHeight());
            SetFillWidth(GetWidth());
            SetIsVisible(true);
            SetMmgColor(MmgColor.GetWhite());
        }

        /// <summary>
        /// Sets the padding X value.
        /// </summary>
        /// <param name="px">The padding X value.</param>
        public virtual void SetPaddingX(int px)
        {
            xPadding = px;
        }

        /// <summary>
        /// Gets the padding X value.
        /// </summary>
        /// <returns>The padding X value.</returns>
        public virtual int GetPaddingX()
        {
            return xPadding;
        }

        /// <summary>
        /// Sets the padding Y value.
        /// </summary>
        /// <param name="py">The padding Y value.</param>
        public virtual void SetPaddingY(int py)
        {
            yPadding = py;
        }

        /// <summary>
        /// Gets the padding Y value.
        /// </summary>
        /// <returns>The padding Y value.</returns>
        public virtual int GetPaddingY()
        {
            return yPadding;
        }

        /// <summary>
        /// Gets the fill height of the loading bar.
        /// </summary>
        /// <returns>The fill height of the loading bar.</returns>
        public virtual int GetFillHeight()
        {
            return fillHeight;
        }

        /// <summary>
        /// Sets the fill height of the loading bar.
        /// </summary>
        /// <param name="h">The fill height of the loading bar.</param>
        public virtual void SetFillHeight(int h)
        {
            fillHeight = h;
        }

        /// <summary>
        /// Gets the fill width of the loading bar.
        /// </summary>
        /// <returns>The fill width of the loading bar.</returns>
        public virtual int GetFillWidth()
        {
            return fillWidth;
        }

        /// <summary>
        /// The position to use to draw this object.
        /// </summary>
        /// <param name="pos">The position to this object to.</param>
        public override void SetPosition(MmgVector2 pos)
        {
            base.SetPosition(pos);
            loadingBarFront.SetPosition(pos);
            loadingBarBack.SetPosition(pos);
        }

        /// <summary>
        /// Sets the position of this object and resets the label, value pair positioning.
        /// </summary>
        /// <param name="x">The X coordinate to set in the position.</param>
        /// <param name="y">The Y coordinate to set in the position.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            loadingBarFront.SetPosition(x, y);
            loadingBarBack.SetPosition(x, y);
        }

        /// <summary>
        /// The X coordinate to use to draw this object.
        /// </summary>
        /// <param name="inX">The X coordinate to use to draw this object.</param>
        public override void SetX(int inX)
        {
            base.SetX(inX);
            loadingBarFront.SetX(inX);
            loadingBarBack.SetX(inX);
        }

        /// <summary>
        /// The Y coordinate to use to draw this object.
        /// </summary>
        /// <param name="inY">The Y coordinate to use to draw this object.</param>
        public override void SetY(int inY)
        {
            base.SetY(inY);
            loadingBarFront.SetY(inY);
            loadingBarBack.SetY(inY);
        }

        /// <summary>
        /// Sets the fill width of the loading bar.
        /// </summary>
        /// <param name="w">The fill width of the loading bar.</param>
        public virtual void SetFillWidth(int w)
        {
            fillWidth = w;
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgLoadingBar(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgLoadingBar CloneTyped()
        {
            return new MmgLoadingBar(this);
        }

        /// <summary>
        /// Gets the loading bar back image.
        /// </summary>
        /// <returns>The loading bar back image.</returns>
        public virtual MmgBmp GetLoadingBarBack()
        {
            return loadingBarBack;
        }

        /// <summary>
        /// Sets the loading bar back image.
        /// </summary>
        /// <param name="b">The loading bar back image.</param>
        public virtual void SetLoadingBarBack(MmgBmp b)
        {
            loadingBarBack = b;
            if (loadingBarBack != null)
            {
                loadingBarBack.SetScaling(null);
            }
        }

        /// <summary>
        /// Gets the loading bar front image.
        /// </summary>
        /// <returns>The loading bar front image.</returns>
        public virtual MmgBmp GetLoadingBarFront()
        {
            return loadingBarFront;
        }

        /// <summary>
        /// Sets the loading bar front image.
        /// </summary>
        /// <param name="f">The loading bar front image.</param>
        public virtual void SetLoadingBarFront(MmgBmp f)
        {
            loadingBarFront = f;
        }

        /// <summary>
        /// Sets the loading bar fill amount, 0.0 - 1.0.
        /// </summary>
        /// <param name="f">The decimal fill amount.</param>
        public virtual void SetFillAmt(float f)
        {
            fillAmt = f;
        }

        /// <summary>
        /// Gets the loading bar fill amount.
        /// </summary>
        /// <returns>The decimal fill amount.</returns>
        public virtual float GetFillAmt()
        {
            return fillAmt;
        }

        /// <summary>
        /// Draws the current object using the MmgPen object.
        /// </summary>
        /// <param name="p">The MmgPen object that draws this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (loadingBarBack != null)
                {
                    loadingBarBack.SetSrcRect(new MmgRect(MmgVector2.GetOriginVec(), loadingBarBack.GetWidth(), loadingBarBack.GetHeight()));
                    loadingBarBack.SetDstRect(new MmgRect(new MmgVector2(GetPosition().GetX() + GetPaddingX(), GetPosition().GetY() + GetPaddingY()), (int)((float)(GetFillWidth() - GetPaddingX()) * fillAmt), GetFillHeight() - GetPaddingY()));
                    loadingBarBack.MmgDraw(p);
                }

                if (loadingBarFront != null)
                {
                    loadingBarFront.MmgDraw(p);
                }
            }
        }

        /// <summary>
        /// A class method that tests for equality based on the font and text of the comparison object.
        /// </summary>
        /// <param name="obj">The MmgFont object to compare.</param>
        /// <returns>A boolean indicating if the object instance is equal to the argument object instance.</returns>
        public virtual bool ApiEquals(MmgLoadingBar obj)
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
                MmgHelper.wr("mmg loading bar: mmgobj is not equals!");
            }

            if(!(obj.GetFillHeight() == GetFillHeight())) {
                MmgHelper.wr("mmg loading bar: fill height is not equals!");
            }

            if(!(obj.GetFillWidth() == GetFillWidth())) {
                MmgHelper.wr("mmg loading bar: fill width is not equals!");            
            }

            if(!(((obj.GetLoadingBarBack() == null && GetLoadingBarBack() == null) || (obj.GetLoadingBarBack() != null && GetLoadingBarBack() != null && obj.GetLoadingBarBack().equals(GetLoadingBarBack()))))) {
                MmgHelper.wr("mmg loading bar: loading bar back is not equals!");                        
            }

            if(!(((obj.GetLoadingBarFront() == null && GetLoadingBarFront() == null) || (obj.GetLoadingBarFront() != null && GetLoadingBarFront() != null && obj.GetLoadingBarFront().equals(GetLoadingBarFront()))))) {
                MmgHelper.wr("mmg loading bar: loading bar front is not equals!");                        
            }        
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && obj.GetFillHeight() == GetFillHeight()
                && obj.GetFillWidth() == GetFillWidth()
                && ((obj.GetLoadingBarBack() == null && GetLoadingBarBack() == null) || (obj.GetLoadingBarBack() != null && GetLoadingBarBack() != null && obj.GetLoadingBarBack().ApiEquals(GetLoadingBarBack())))
                && ((obj.GetLoadingBarFront() == null && GetLoadingBarFront() == null) || (obj.GetLoadingBarFront() != null && GetLoadingBarFront() != null && obj.GetLoadingBarFront().ApiEquals(GetLoadingBarFront())))
                && obj.GetPaddingX() == GetPaddingX()
                && obj.GetPaddingY() == GetPaddingY()
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}