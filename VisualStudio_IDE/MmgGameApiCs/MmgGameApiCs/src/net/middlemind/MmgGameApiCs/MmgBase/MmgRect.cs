using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A rectangle class that wraps the lower level rectangle class. 
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgRect
    {
        /// <summary>
        /// The lower level rectangle class.
        /// </summary>
        private Rectangle rect;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgRect()
        {
            rect = new Rectangle(0, 0, 1, 1);
        }

        /// <summary>
        /// Constructor for this class that is created from an existing MmgRect class.
        /// </summary>
        /// <param name="obj">The MmgRect to use as a basis for this class.</param>
        public MmgRect(MmgRect obj)
        {
            rect = new Rectangle(obj.GetLeft(), obj.GetTop(), obj.GetWidth(), obj.GetHeight());
        }

        /// <summary>
        /// Constructor for this class that sets the position and size of the rectangle.
        /// </summary>
        /// <param name="left">The left X coordinate of the rectangle.</param>
        /// <param name="top">The top Y coordinate of the rectangle.</param>
        /// <param name="bottom">The bottom Y coordinate of the rectangle.</param>
        /// <param name="right">The right X coordinate of the rectangle.</param>
        public MmgRect(int left, int top, int bottom, int right)
        {
            rect = new Rectangle(left, top, (right - left), (bottom - top));
        }

        /// <summary>
        /// Constructor for this class that sets the position and dimensions of this rectangle.
        /// </summary>
        /// <param name="v">The position of the rectangle.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public MmgRect(MmgVector2 v, int w, int h)
        {
            rect = new Rectangle(v.GetX(), v.GetY(), w, h);
        }

        /// <summary>
        /// Shift this rectangle by the given amounts.
        /// </summary>
        /// <param name="shiftLeftRight">The number of pixels to shift the rectangle in the left, right direction.</param>
        /// <param name="shiftUpDown">The number of pixels to shift the rectangle i the up, down direction.</param>
        public virtual void ShiftRect(int shiftLeftRight, int shiftUpDown)
        {
            rect = new Rectangle(rect.X + shiftLeftRight, rect.Y + shiftUpDown, rect.Width, rect.Height);
        }

        /// <summary>
        /// Return a shifted rectangle by the given amounts.
        /// </summary>
        /// <param name="shiftLeftRight">The number of pixels to shift the rectangle in the left, right direction.</param>
        /// <param name="shiftUpDown">The number of pixels to shift the rectangle i the up, down direction.</param>
        /// <returns>A new rectangle shifted in the X, Y directions by the specified amount.</returns>
        public virtual MmgRect ToShiftedRect(int shiftLeftRight, int shiftUpDown)
        {
            return new MmgRect(rect.X + shiftLeftRight, rect.Y + shiftUpDown, rect.X + shiftLeftRight + rect.Width, rect.Y + shiftUpDown + rect.Height);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual MmgRect Clone()
        {
            return new MmgRect(this);
        }

        /// <summary>
        /// Creates a unit rectangle with with and height of 1.
        /// </summary>
        /// <returns>A new rectangle with width and height of 1.</returns>
        public static MmgRect GetUnitRect()
        {
            return new MmgRect(0, 0, 1, 1);
        }

        /// <summary>
        /// Gets the X coordinate left.
        /// </summary>
        /// <returns>The X coordinate left.</returns>
        public virtual int GetLeft()
        {
            return rect.X;
        }

        /// <summary>
        /// Gets the Y coordinate top.
        /// </summary>
        /// <returns>The Y coordinate top.</returns>
        public virtual int GetTop()
        {
            return rect.Y;
        }

        /// <summary>
        /// Gets the X coordinate right.
        /// </summary>
        /// <returns>The X coordinate right.</returns>
        public virtual int GetRight()
        {
            return (rect.X + rect.Width);
        }

        /// <summary>
        /// Gets the Y coordinate bottom.
        /// </summary>
        /// <returns>The Y coordinate bottom.</returns>
        public virtual int GetBottom()
        {
            return (rect.Y + rect.Height);
        }

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        /// <returns>The width of the rectangle.</returns>
        public virtual int GetWidth()
        {
            return rect.Width;
        }

        /// <summary>
        /// Sets the width of the rectangle.
        /// </summary>
        /// <param name="w">The width of the rectangle.</param>
        public virtual void SetWidth(int w)
        {
            rect.Width = w;
        }

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        /// <returns>The height of the rectangle.</returns>
        public virtual int GetHeight()
        {
            return rect.Height;
        }

        /// <summary>
        /// Sets the height of the rectangle.
        /// </summary>
        /// <param name="h">The height of the rectangle.</param>
        public virtual void SetHeight(int h)
        {
            rect.Height = h;
        }

        /// <summary>
        /// Gets the underlying rectangle object.
        /// </summary>
        /// <returns>The underlying rectangle object.</returns>
        public virtual Rectangle GetRect()
        {
            return rect;
        }

        /// <summary>
        /// Sets the underlying rectangle object.
        /// </summary>
        /// <param name="r">The underlying rectangle object.</param>
        public virtual void SetRect(Rectangle r)
        {
            rect = r;
        }

        /// <summary>
        /// Gets the difference in X coordinates between the this MmgRect and the provided MmgRect.
        /// </summary>
        /// <param name="inRect">The MmgRect to compare with to calculate the X difference.</param>
        /// <param name="direction">The direction to compare the X difference in left or right.</param>
        /// <param name="opposite">A boolean indicating to calculate the X difference in the opposite direction.</param>
        /// <param name="left2right">A boolean indicating if the calculation should be left to right.</param>
        /// <returns>The X difference between the two MmgRect instances.</returns>
        public virtual int GetDiffX(MmgRect inRect, int direction, bool opposite, bool left2right)
        {
            if (MmgDir.DIR_LEFT == direction && opposite == false && left2right == true)
            {
                return (GetLeft() - inRect.GetRight());

            }
            else if (MmgDir.DIR_LEFT == direction && opposite == false && left2right == false)
            {
                return (GetLeft() - inRect.GetLeft());

            }
            else if (MmgDir.DIR_LEFT == direction && opposite == true && left2right == true)
            {
                return (inRect.GetLeft() - GetRight());

            }
            else if (MmgDir.DIR_LEFT == direction && opposite == true && left2right == false)
            {
                return (inRect.GetLeft() - GetLeft());

            }
            else if (MmgDir.DIR_RIGHT == direction && opposite == false && left2right == true)
            {
                return (GetRight() - inRect.GetLeft());

            }
            else if (MmgDir.DIR_RIGHT == direction && opposite == false && left2right == false)
            {
                return (GetRight() - inRect.GetRight());

            }
            else if (MmgDir.DIR_RIGHT == direction && opposite == true && left2right == true)
            {
                return (inRect.GetRight() - GetLeft());

            }
            else if (MmgDir.DIR_RIGHT == direction && opposite == true && left2right == false)
            {
                return (inRect.GetRight() - GetRight());

            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the difference in X coordinates between the this MmgRect and the provided X coordinate.
        /// </summary>
        /// <param name="x">The X coordinate to compare with to calculate the X difference.</param>
        /// <param name="direction">The direction to compare the X difference in left or right.</param>
        /// <param name="opposite">A boolean indicating to calculate the X difference in the opposite direction.</param>
        /// <returns>The X difference between the two coordinate values.</returns>
        public virtual int GetDiffX(int x, int direction, bool opposite)
        {
            if (MmgDir.DIR_LEFT == direction && opposite == false)
            {
                return (GetLeft() - x);

            }
            else if (MmgDir.DIR_LEFT == direction && opposite == true)
            {
                return (x - GetLeft());

            }
            else if (MmgDir.DIR_RIGHT == direction && opposite == false)
            {
                return (GetRight() - x);

            }
            else if (MmgDir.DIR_RIGHT == direction && opposite == true)
            {
                return (x - GetRight());

            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the difference in Y coordinates between the this MmgRect and the provided MmgRect.
        /// </summary>
        /// <param name="inRect">The MmgRect to compare with to calculate the Y difference.</param>
        /// <param name="direction">The direction to compare the Y difference in up or down.</param>
        /// <param name="opposite">A boolean indicating to calculate the Y difference in the opposite direction.</param>
        /// <param name="left2right">A boolean indicating if the calculation should be top to bottom.</param>
        /// <returns>The Y difference between the two MmgRect instances.</returns>
        public virtual int GetDiffY(MmgRect inRect, int direction, bool opposite, bool left2right)
        {
            if (MmgDir.DIR_TOP == direction && opposite == false && left2right == true)
            {
                return (GetTop() - inRect.GetBottom());

            }
            else if (MmgDir.DIR_TOP == direction && opposite == false && left2right == false)
            {
                return (GetTop() - inRect.GetTop());

            }
            else if (MmgDir.DIR_TOP == direction && opposite == true && left2right == true)
            {
                return (inRect.GetTop() - GetBottom());

            }
            else if (MmgDir.DIR_TOP == direction && opposite == true && left2right == false)
            {
                return (inRect.GetTop() - GetTop());

            }
            else if (MmgDir.DIR_BOTTOM == direction && opposite == false && left2right == true)
            {
                return (GetBottom() - inRect.GetTop());

            }
            else if (MmgDir.DIR_BOTTOM == direction && opposite == false && left2right == false)
            {
                return (GetBottom() - inRect.GetBottom());

            }
            else if (MmgDir.DIR_BOTTOM == direction && opposite == true && left2right == true)
            {
                return (inRect.GetBottom() - GetTop());

            }
            else if (MmgDir.DIR_BOTTOM == direction && opposite == true && left2right == false)
            {
                return (inRect.GetBottom() - GetBottom());

            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the difference in Y coordinates between the this MmgRect and the provided Y coordinate.
        /// </summary>
        /// <param name="y">The Y coordinate to compare with to calculate the Y difference.</param>
        /// <param name="direction">The direction to compare the X difference in up or down.</param>
        /// <param name="opposite">A boolean indicating to calculate the Y difference in the opposite direction.</param>
        /// <returns>The Y difference between the two coordinate values.</returns>
        public virtual int GetDiffY(int y, int direction, bool opposite)
        {
            if (MmgDir.DIR_TOP == direction && opposite == false)
            {
                return (GetTop() - y);

            }
            else if (MmgDir.DIR_TOP == direction && opposite == true)
            {
                return (y - GetTop());

            }
            else if (MmgDir.DIR_BOTTOM == direction && opposite == false)
            {
                return (GetBottom() - y);

            }
            else if (MmgDir.DIR_BOTTOM == direction && opposite == true)
            {
                return (y - GetBottom());

            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the position of the rectangle.
        /// </summary>
        /// <returns>The position of the rectangle.</returns>
        public virtual MmgVector2 GetPosition()
        {
            return new MmgVector2(GetLeft(), GetTop());
        }

        /// <summary>
        /// Sets the position of the rectangle.
        /// </summary>
        /// <param name="v">The position of the rectangle.</param>
        public virtual void SetPosition(MmgVector2 v)
        {
            rect.Location = new Point(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Sets the position of the rectangle.
        /// </summary>
        /// <param name="x">The position of the rectangle on the X axis.</param>
        /// <param name="y">The position of the rectangle on the Y axis.</param>
        public virtual void SetPosition(int x, int y)
        {
            rect.Location = new Point(x, y);
        }

        /// <summary>
        /// A string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public virtual string ApiToString()
        {
            return "MmgRect: L: " + rect.Left + " R: " + rect.Right + " T: " + rect.Top + " B: " + rect.Bottom + ", W: " + GetWidth() + " H: " + GetHeight();
        }

        /// <summary>
        /// A method that test equality between two rectangles based on the coordinate of the left, right, top, bottom.
        /// </summary>
        /// <param name="obj">A MmgRect to compare with this class instance.</param>
        /// <returns>A boolean indicating if the two class instances are equal.</returns>
        public virtual bool ApiEquals(MmgRect obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;
            if (GetLeft() == obj.GetLeft() && GetRight() == obj.GetRight() && GetTop() == obj.GetTop() && GetBottom() == obj.GetBottom())
            {
                ret = true;
            }
            return ret;
        }
    }
}