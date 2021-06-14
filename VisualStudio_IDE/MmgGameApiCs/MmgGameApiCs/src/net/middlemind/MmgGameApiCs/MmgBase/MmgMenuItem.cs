using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that represents a menu item.
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgMenuItem : MmgObj
    {
        /// <summary>
        /// Used to represent a neutral menu item state.
        /// </summary>
        public static int STATE_NONE = -1;

        /// <summary>
        /// Used to represent a normal menu item state.
        /// </summary>
        public static int STATE_NORMAL = 0;

        /// <summary>
        /// Used to represent a selected menu item state.
        /// </summary>
        public static int STATE_SELECTED = 1;

        /// <summary>
        /// Used to represent an inactive menu item state.
        /// </summary>
        public static int STATE_INACTIVE = 2;

        /// <summary>
        /// The event to fir if the menu item has been pressed.
        /// </summary>
        private MmgEvent eventPress;

        /// <summary>
        /// The object to use if the menu item is normal.
        /// </summary>
        private MmgObj normal;

        /// <summary>
        /// The object to use if the menu item is selected. 
        /// </summary>
        private MmgObj selected;

        /// <summary>
        /// The object to use if the menu item is inactive.
        /// </summary>
        private MmgObj inactive;

        /// <summary>
        /// The currently drawn object.
        /// </summary>
        private MmgObj current;

        /// <summary>
        /// A sound effect to play when the menu item is selected.
        /// </summary>
        private MmgSound sound;

        /// <summary>
        /// A class helper variable for tracking the current state.
        /// </summary>
        private int state;

        /// <summary>
        /// A class helper variable indicating if the state has been set for this class instance.
        /// </summary>
        private bool stateSet = false;

        /// <summary>
        /// A static class field that is used to show a bounding box around the object.
        /// </summary>
        public static bool SHOW_MENU_ITEM_BOUNDING_BOX = false;

        /// <summary>
        /// A helper variable used in the MmgDraw method.
        /// </summary>
        private Color c;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgMenuItem() : base()
        {
            SetEventPress(null);
            SetNormal(null);
            SetSelected(null);
            SetInactive(null);
            SetState(STATE_NONE);
        }

        /// <summary>
        /// Constructor for this class that sets the value of base attributes from the given argument.
        /// </summary>
        /// <param name="m">The MmgObj to use to set the attributes of this object. </param>
        public MmgMenuItem(MmgObj m) : base(m)
        {
            eventPress = null;
            normal = null;
            selected = null;
            inactive = null;
            current = null;
            state = STATE_NONE;
        }

        /// <summary>
        /// Constructor for this class that sets the value of certain attributes based on the value of attributes in the given argument.
        /// </summary>
        /// <param name="obj">An MmgMenuItem object to get attribute values from.</param>
        public MmgMenuItem(MmgMenuItem obj) : base()
        {
            SetEventPress(obj.GetEventPress());

            if (obj.GetNormal() == null)
            {
                SetNormal(obj.GetNormal());
            }
            else
            {
                SetNormal(obj.GetNormal().Clone());
            }

            if (obj.GetSelected() == null)
            {
                SetSelected(obj.GetSelected());
            }
            else
            {
                SetSelected(obj.GetSelected().Clone());
            }

            if (obj.GetInactive() == null)
            {
                SetInactive(obj.GetInactive());
            }
            else
            {
                SetInactive(obj.GetInactive().Clone());
            }

            SetState(obj.GetState());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
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

            if (obj.GetSound() != null)
            {
                SetSound(obj.GetSound().Clone());
            }
            else
            {
                SetSound(obj.GetSound());
            }
        }

        /// <summary>
        /// A constructor for this class that sets the event, the appearance objects and the state of the menu item.
        /// </summary>
        /// <param name="me">The event to fire if the menu item is pressed.</param>
        /// <param name="Normal">The object to show if the menu item has a normal state.</param>
        /// <param name="Selected">The object to show if the menu item has a selected state.</param>
        /// <param name="Inactive">The object to show if the menu item has an inactive state.</param>
        /// <param name="State">The current state of the menu item object.</param>
        public MmgMenuItem(MmgEvent me, MmgObj Normal, MmgObj Selected, MmgObj Inactive, int State) : base()
        {
            SetEventPress(me);
            SetNormal(Normal);
            SetSelected(Selected);
            SetInactive(Inactive);
            SetState(State);
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgMenuItem(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgMenuItem CloneTyped()
        {
            return new MmgMenuItem(this);
        }

        /// <summary>
        /// Gets the current menu sound object.
        /// </summary>
        /// <returns>An MmgSound object used in menu item selection.</returns>
        public virtual MmgSound GetSound()
        {
            return sound;
        }

        /// <summary>
        /// Sets the current menu sound object.
        /// </summary>
        /// <param name="Sound">An MmgSound object used in menu item selection.</param>
        public virtual void SetSound(MmgSound Sound)
        {
            sound = Sound;
        }

        /// <summary>
        /// Gets the press event for this menu item.
        /// </summary>
        /// <returns>The press event for this menu item.</returns>
        public virtual MmgEvent GetEventPress()
        {
            return eventPress;
        }

        /// <summary>
        /// Sets the press event for this menu item.
        /// </summary>
        /// <param name="e">The press event for this menu item.</param>
        public virtual void SetEventPress(MmgEvent e)
        {
            eventPress = e;
        }

        /// <summary>
        /// Gets the object to draw in the normal state.
        /// </summary>
        /// <returns>The normal state object.</returns>
        public virtual MmgObj GetNormal()
        {
            return normal;
        }

        /// <summary>
        /// Sets the object to draw in the normal state.
        /// </summary>
        /// <param name="m">The normal state object.</param>
        public virtual void SetNormal(MmgObj m)
        {
            normal = m;
        }

        /// <summary>
        /// Gets the object to draw in the selected state.
        /// </summary>
        /// <returns>The selected state object.</returns>
        public virtual MmgObj GetSelected()
        {
            return selected;
        }

        /// <summary>
        /// Sets the object to draw in the selected state.
        /// </summary>
        /// <param name="m">The selected state object.</param>
        public virtual void SetSelected(MmgObj m)
        {
            selected = m;
        }

        /// <summary>
        /// Gets the activity flag for this menu item.
        /// </summary>
        /// <returns>True if the object is active, false otherwise.</returns>
        public virtual MmgObj GetInactive()
        {
            return inactive;
        }

        /// <summary>
        /// Sets the activity flag for this menu item.
        /// </summary>
        /// <param name="m">True if the object is active, false otherwise.</param>
        public virtual void SetInactive(MmgObj m)
        {
            inactive = m;
        }

        /// <summary>
        /// Sets the current state of the menu item.
        /// </summary>
        /// <param name="i">The current state of the menu item.</param>
        public virtual void SetState(int i)
        {
            if (state != i)
            {
                if (i == STATE_NORMAL)
                {
                    current = normal;
                }
                else if (i == STATE_SELECTED)
                {
                    current = selected;
                    if (sound != null)
                    {
                        sound.Play();
                    }
                }
                else if (i == STATE_INACTIVE)
                {
                    current = inactive;
                }
                else
                {
                    current = normal;
                }

                stateSet = true;
                if (current != null)
                {
                    base.SetWidth(current.GetWidth());
                    base.SetHeight(current.GetHeight());
                }
                else
                {
                    base.SetWidth(0);
                    base.SetHeight(0);
                }
                state = i;
            }

            if (!stateSet)
            {
                stateSet = true;
                current = normal;
                if (current != null)
                {
                    base.SetWidth(current.GetWidth());
                    base.SetHeight(current.GetHeight());
                }
                else
                {
                    base.SetWidth(0);
                    base.SetHeight(0);
                }
            }
        }

        /// <summary>
        /// Gets the current state of the menu item.
        /// </summary>
        /// <returns>The current state of the menu item.</returns>
        public virtual int GetState()
        {
            return state;
        }

        /// <summary>
        /// The base drawing method for this object.
        /// </summary>
        /// <param name="p">The MmgPen object used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (MmgMenuItem.SHOW_MENU_ITEM_BOUNDING_BOX == true)
                {
                    c = p.GetGraphicsColor();
                    p.SetGraphicsColor(Color.Red);
                    p.DrawRect(this);
                    p.SetGraphicsColor(c);
                }

                current.SetPosition(GetPosition());
                current.SetMmgColor(GetMmgColor());
                current.MmgDraw(p);
            }
        }

        /// <summary>
        /// A method that checks to see if this MmgMenuContainer is equal to the passed in MmgMenuContainer.
        /// </summary>
        /// <param name="obj">The MmgMenuContainer object instance to test for equality.</param>
        /// <returns>Returns true if both MmgMenuContainer objects are the same.</returns>
        public virtual bool ApiEquals(MmgMenuItem obj)
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
            if (
                base.ApiEquals((MmgObj)obj)
                && obj.GetHeight() == GetHeight()
                && ((obj.GetInactive() == null && GetInactive() == null) || (obj.GetInactive() != null && GetInactive() != null && obj.GetInactive().ApiEquals(GetInactive())))
                && ((obj.GetNormal() == null && GetNormal() == null) || (obj.GetNormal() != null && GetNormal() != null && obj.GetNormal().ApiEquals(GetNormal())))
                && ((obj.GetSelected() == null && GetSelected() == null) || (obj.GetSelected() != null && GetSelected() != null && obj.GetSelected().ApiEquals(GetSelected())))
                && ((obj.GetSound() == null && GetSound() == null) || (obj.GetSound() != null && GetSound() != null && obj.GetSound().ApiEquals(GetSound())))
                && obj.GetState() == GetState()
                && obj.GetWidth() == GetWidth()
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}