using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// The base drawable class of the MmgApi.
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgObj
    {
        /// <summary>
        /// The screen position to draw this object.
        /// </summary>
        public MmgVector2 pos;

        /// <summary>
        /// The width of this object.
        /// </summary>
        public int w;

        /// <summary>
        /// The height of this object.
        /// </summary>
        public int h;

        /// <summary>
        /// The visibility of this object.
        /// </summary>
        public bool isVisible;

        /// <summary>
        /// The color of this object.
        /// </summary>
        public MmgColor color;

        /// <summary>
        /// The version of this MmgApi. 
        /// </summary>
        private string version = "1.0.8";

        /// <summary>
        /// Flag indicating if this MmgObj has a parent container.
        /// </summary>
        public bool hasParent;

        /// <summary>
        /// Parent object if available.
        /// </summary>
        public MmgObj parent;

        /// <summary>
        /// The name of this MmgObj.
        /// </summary>
        public string name;

        /// <summary>
        /// The id of this MmgObj.
        /// </summary>
        public string mmgUid;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgObj()
        {
            pos = MmgVector2.GetOriginVec();
            w = 0;
            h = 0;
            isVisible = true;
            color = MmgColor.GetWhite();
            hasParent = false;
            parent = null;
            name = "";
            mmgUid = "";
        }

        /// <summary>
        /// Constructor with identification.
        /// </summary>
        /// <param name="n">Name of the MmgObj.</param>
        /// <param name="i">Id of the MmgObj.</param>
        public MmgObj(String n, String i)
        {
            pos = MmgVector2.GetOriginVec();
            w = 0;
            h = 0;
            isVisible = true;
            color = MmgColor.GetWhite();
            hasParent = false;
            parent = null;
            name = n;
            mmgUid = i;
        }

        /// <summary>
        /// Constructor for this class that sets the position, dimensions, visibility, and color of this object.
        /// </summary>
        /// <param name="X">The X coordinate of this object's position.</param>
        /// <param name="Y">The Y coordinate of this object's position.</param>
        /// <param name="W">The width of this object.</param>
        /// <param name="H">The height of this object.</param>
        /// <param name="isv">The visibility of this object.</param>
        /// <param name="c">The color of this object.</param>
        public MmgObj(int X, int Y, int W, int H, bool isv, MmgColor c)
        {
            pos = new MmgVector2(X, Y);
            w = W;
            h = H;
            isVisible = isv;
            color = c;
            hasParent = false;
            parent = null;
            name = "";
            mmgUid = "";
        }

        /// <summary>
        /// Constructor for this class that takes a width adn height as arguments.
        /// </summary>
        /// <param name="W">The width of the MmgObj.</param>
        /// <param name="H">The height of the MmgObj.</param>
        public MmgObj(int W, int H)
        {
            pos = MmgVector2.GetOriginVec();
            w = W;
            h = H;
            isVisible = true;
            color = null;
            hasParent = false;
            parent = null;
            name = "";
            mmgUid = "";
        }

        /// <summary>
        /// Constructor for this class that sets the position, dimensions, visibility, and color of this object.
        /// </summary>
        /// <param name="X">The X coordinate of this object's position.</param>
        /// <param name="Y">The Y coordinate of this object's position.</param>
        /// <param name="W">The width of this object.</param>
        /// <param name="H">The height of this object.</param>
        /// <param name="isv">The visibility of this object.</param>
        /// <param name="c">The color of this object.</param>
        /// <param name="n">The name you want to give this object.</param>
        /// <param name="i">The id you want to give this object.</param>
        public MmgObj(int X, int Y, int W, int H, bool isv, MmgColor c, string n, string i)
        {
            pos = new MmgVector2(X, Y);
            w = W;
            h = H;
            isVisible = isv;
            color = c;
            hasParent = false;
            parent = null;
            name = n;
            mmgUid = i;
        }

        /// <summary>
        /// Constructor for this class that sets the position, dimensions, visibility, and color of this object.
        /// </summary>
        /// <param name="v2">The position of this object.</param>
        /// <param name="W">The width of this object.</param>
        /// <param name="H">The height of this object.</param>
        /// <param name="isv">The visibility of this object.</param>
        /// <param name="c">The color of this object.</param>
        public MmgObj(MmgVector2 v2, int W, int H, bool isv, MmgColor c)
        {
            pos = v2;
            w = W;
            h = H;
            isVisible = isv;
            color = c;
            hasParent = false;
            parent = null;
            name = "";
            mmgUid = "";
        }

        /// <summary>
        /// Constructor for this class that sets the position, dimensions, visibility, and color of this object.
        /// </summary>
        /// <param name="v2">The position of this object.</param>
        /// <param name="W">The width of this object.</param>
        /// <param name="H">The height of this object.</param>
        /// <param name="isv">The visibility of this object.</param>
        /// <param name="c">The color of this object.</param>
        /// <param name="n">The name you want to give this object.</param>
        /// <param name="i">The id you want to give this object.</param>
        public MmgObj(MmgVector2 v2, int W, int H, bool isv, MmgColor c, string n, string i)
        {
            pos = v2;
            w = W;
            h = H;
            isVisible = isv;
            color = c;
            hasParent = false;
            parent = null;
            name = n;
            mmgUid = i;
        }

        /// <summary>
        /// Constructor for this object that sets all the attribute values to the values of the attributes
        /// of the given argument.
        /// </summary>
        /// <param name="obj">The object to use to set all local attributes.</param>
        public MmgObj(MmgObj obj)
        {
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
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetMmgColor() != null)
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor());
            }

            SetHasParent(obj.GetHasParent());
            SetParent(obj.GetParent());
            SetName(obj.GetName());
            SetId(obj.GetId());
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this object.</returns>
        public virtual MmgObj Clone()
        {
            return new MmgObj(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual MmgObj CloneTyped()
        {
            return new MmgObj(this);
        }

        /// <summary>
        /// Gets the API version number.
        /// </summary>
        /// <returns>The API version number.</returns>
        public virtual string GetVersion()
        {
            return version;
        }

        /// <summary>
        /// Base drawing class, does nothing.
        /// </summary>
        /// <param name="p">The MmgPen that would be used to draw this object.</param>
        public virtual void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {

            }
        }

        /// <summary>
        /// The MmgUpdate method that handles updating any object fields during the update calls.
        /// </summary>
        /// <param name="updateTick">The index of the update call.</param>
        /// <param name="currentTimeMs">The current time in milliseconds that the update was called.</param>
        /// <param name="msSinceLastFrame">The difference in milliseconds between this update call and the previous update call.</param>
        /// <returns>A boolean indicating if the update call was handled.</returns>
        public virtual bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            if (isVisible == true)
            {

            }
            return false;
        }

        /// <summary>
        /// Gets the visibility of this class.
        /// </summary>
        /// <returns>True if this class is visible, false otherwise.</returns>
        public virtual bool GetIsVisible()
        {
            return isVisible;
        }

        /// <summary>
        /// Sets the invisibility of this class.
        /// </summary>
        /// <param name="bl">True if this class is visible, false otherwise.</param>
        public virtual void SetIsVisible(bool bl)
        {
            isVisible = bl;
        }

        /// <summary>
        /// Gets the width of this object.
        /// </summary>
        /// <returns>The width of this object.</returns>
        public virtual int GetWidth()
        {
            return w;
        }

        /// <summary>
        /// Sets the width of this object.
        /// </summary>
        /// <param name="W">The width of this object.</param>
        public virtual void SetWidth(int W)
        {
            w = W;
        }

        /// <summary>
        /// Gets the height of this object.
        /// </summary>
        /// <returns>The height of this object.</returns>
        public virtual int GetHeight()
        {
            return h;
        }

        /// <summary>
        /// Sets the height of this object.
        /// </summary>
        /// <param name="H">The height of this object.</param>
        public virtual void SetHeight(int H)
        {
            h = H;
        }

        /// <summary>
        /// Sets the position of this object.
        /// </summary>
        /// <param name="v">The position of this object.</param>
        public virtual void SetPosition(MmgVector2 v)
        {
            pos = v;
        }

        /// <summary>
        /// Sets the position of this object using X, Y coordinates.
        /// </summary>
        /// <param name="x">The X coordinate to set this object position to.</param>
        /// <param name="y">The Y coordinate to set this object position to.</param>
        public virtual void SetPosition(int x, int y)
        {
            pos = new MmgVector2(x, y);
        }

        /// <summary>
        /// Gets the position of this object.
        /// </summary>
        /// <returns>The position of this object.</returns>
        public virtual MmgVector2 GetPosition()
        {
            return pos;
        }

        /// <summary>
        /// Gets the color of this object.
        /// </summary>
        /// <returns>The color of this object.</returns>
        public virtual MmgColor GetMmgColor()
        {
            return color;
        }

        /// <summary>
        /// Sets the color of this object.
        /// </summary>
        /// <param name="c">The color of this object.</param>
        public virtual void SetMmgColor(MmgColor c)
        {
            color = c;
        }

        /// <summary>
        /// Sets the X coordinate of this object.
        /// </summary>
        /// <param name="inX">The X coordinate of this object.</param>
        public virtual void SetX(int inX)
        {
            GetPosition().SetX(inX);
        }

        /// <summary>
        /// Gets the X coordinate of this object.
        /// </summary>
        /// <returns>The X coordinate of this object.</returns>
        public virtual int GetX()
        {
            return GetPosition().GetX();
        }

        /// <summary>
        /// Sets the Y coordinate of this object.
        /// </summary>
        /// <param name="inY">The Y coordinate of this object.</param>
        public virtual void SetY(int inY)
        {
            GetPosition().SetY(inY);
        }

        /// <summary>
        /// Gets the Y coordinate of this object.
        /// </summary>
        /// <returns>The Y coordinate of this object.</returns>
        public virtual int GetY()
        {
            return GetPosition().GetY();
        }

        /// <summary>
        /// Gets the name of this MmgObj class instance.
        /// </summary>
        /// <returns>The name of this MmgObj.</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// Sets the name of this MmgObj class instance.
        /// </summary>
        /// <param name="n">The name of this MmgObj.</param>
        public virtual void SetName(string n)
        {
            name = n;
        }

        /// <summary>
        /// Gets the id of this MmgObj.
        /// </summary>
        /// <returns>The id of this MmgObj.</returns>
        public virtual string GetId()
        {
            return mmgUid;
        }

        /// <summary>
        /// Sets the id of this MmgObj.
        /// </summary>
        /// <param name="i">The id of this MmgObj.</param>
        public virtual void SetId(string i)
        {
            mmgUid = i;
        }

        /// <summary>
        /// Sets that this MmgObj has a parent.
        /// </summary>
        /// <param name="b">A boolean indicating that this object has a parent.</param>
        public virtual void SetHasParent(bool b)
        {
            hasParent = b;
        }

        /// <summary>
        /// Sets the parent of this MmgObj.
        /// </summary>
        /// <param name="o">The parent of this MmgObj.</param>
        public virtual void SetParent(MmgObj o)
        {
            parent = o;
        }

        /// <summary>
        /// Gets a boolean indicating if this MmgObj has a parent.
        /// </summary>
        /// <returns>A boolean indicating if this class instance has a parent.</returns>
        public virtual bool GetHasParent()
        {
            return hasParent;
        }

        /// <summary>
        /// Gets an MmgRect representation of the current object.
        /// </summary>
        /// <returns>An MmgRect representation of the current object.</returns>
        public MmgRect GetCurrentRect()
        {
            return new MmgRect(GetX(), GetY(), GetY() + GetHeight(), GetX() + GetWidth());
        }

        /// <summary>
        /// Gets the parent of this MmgObj instance.
        /// </summary>
        /// <returns>The parent MmgObj of this class instance.</returns>
        public virtual MmgObj GetParent()
        {
            return parent;
        }

        /// <summary>
        /// A string representation of this class.
        /// </summary>
        /// <returns>A string representation of this class.</returns>
        public virtual string ApiToString()
        {
            return "MmgObj: Name: " + GetName() + " Id: " + GetId() + " - " + GetPosition().ApiToString() + " HasParent: " + GetHasParent() + " Width: " + w + " Height: " + h;
        }

        /// <summary>
        /// A class method that checks equality of this class with another MmgObj class by comparing
        /// some key class fields.
        /// </summary>
        /// <param name="obj">A MmgObj to compare this class to.</param>
        /// <returns>A boolean indicating if this class instance is equal to the comparison class instance.</returns>
        public virtual bool ApiEquals(MmgObj obj)
        {
            //MmgHelper.wr("MmgObj: ApiEquals:");
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            if(!(obj.GetHasParent() == GetHasParent())) { 
                MmgHelper.wr("MmgObj: HasParent NOT equal"); 
            }

            if(!(obj.GetHeight() == GetHeight())) { 
                MmgHelper.wr("MmgObj: Height NOT equal"); 
            }

            if(!(obj.GetWidth() == GetWidth())) { 
                MmgHelper.wr("MmgObj: Width NOT equal"); 
            }        

            if(!(((obj.GetMmgColor() == null && GetMmgColor() == null) || (obj.GetMmgColor() != null && GetMmgColor() != null && obj.GetMmgColor().ApiEquals(GetMmgColor()))))) { 
                MmgHelper.wr("MmgObj: MmgColor NOT equal"); 
            }

            if(!(((obj.GetName() == null && GetName() == null) || (obj.GetName() != null && GetName() != null && obj.GetName().Equals(GetName()))))) { 
                MmgHelper.wr("MmgObj: Name NOT equal"); 
            }

            MmgHelper.wr("MmgObj: Parent check...");
            if (!(((obj.GetParent() == null && GetParent() == null) || (obj.GetParent() != null && GetParent() != null && obj.GetParent().ApiEquals(GetParent()))))) { 
                MmgHelper.wr("MmgObj: Parent NOT equal"); 
            }

            MmgHelper.wr("MmgObj: Position check...");
            if (!(((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().ApiEquals(GetPosition()))))) { 
                MmgHelper.wr("MmgObj: Position NOT equal Obj: " + obj.ApiToString() + " this: " + ApiToString()); 
            }
            */

            bool ret = false;
            if (
                obj.GetHasParent() == GetHasParent()
                && obj.GetHeight() == GetHeight()
                && obj.GetWidth() == GetWidth()
                && ((obj.GetMmgColor() == null && GetMmgColor() == null) || (obj.GetMmgColor() != null && GetMmgColor() != null && obj.GetMmgColor().ApiEquals(GetMmgColor())))
                && ((obj.GetId() == null && GetId() == null) || (obj.GetId() != null && GetId() != null && obj.GetId().Equals(GetId())))
                && ((obj.GetName() == null && GetName() == null) || (obj.GetName() != null && GetName() != null && obj.GetName().Equals(GetName())))
                && ((obj.GetParent() == null && GetParent() == null) || (obj.GetParent() != null && GetParent() != null && obj.GetParent().ApiEquals(GetParent())))
                && ((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().ApiEquals(GetPosition())))
            )
            {
                ret = true;
            }

            return ret;
        }
    }
}