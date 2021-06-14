using System;
using System.Collections.Generic;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that contains a collection of MmgMenuItem objects.
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgMenuContainer : MmgObj
    {
        /// <summary>
        /// The ArrayList that holds the MmgMenuItem objects.
        /// </summary>
        private List<MmgMenuItem> container;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private MmgMenuItem[] a;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private int i;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private MmgMenuItem mo;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgMenuContainer() : base()
        {
            SetContainer(new List<MmgMenuItem>(50));
        }

        /// <summary>
        /// Constructor for this class that sets some default attributes to the same value as the attributes of the given object.
        /// </summary>
        /// <param name="obj">The object to use for default attribute values.</param>
        public MmgMenuContainer(MmgObj obj) : base(obj)
        {
            SetContainer(new List<MmgMenuItem>(50));
        }

        /// <summary>
        /// Constructor for this class that sets the MmgMenuItem ArrayList.
        /// </summary>
        /// <param name="objects">The ArrayList to use for the menu items.</param>
        public MmgMenuContainer(List<MmgMenuItem> objects) : base()
        {
            SetContainer(objects);
        }

        /// <summary>
        /// Constructor for this class that sets the attributes of this class to the values from the given argument.
        /// </summary>
        /// <param name="obj">The MmgMenuContainer class to use for attribute values.</param>
        public MmgMenuContainer(MmgMenuContainer obj) : base()
        {
            if (obj.GetContainer() == null)
            {
                SetContainer(obj.GetContainer());
            }
            else
            {
                a = new MmgMenuItem[obj.GetCount()];
                a = obj.GetContainer().ToArray();
                SetContainer(new List<MmgMenuItem>(a.Length));
                for (i = 0; i < a.Length; i++)
                {
                    Add(a[i].CloneTyped());
                }
            }

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
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgMenuContainer(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgMenuContainer CloneTyped()
        {
            return new MmgMenuContainer(this);
        }

        /// <summary>
        /// Adds a MmgMenuItem object to the menu item ArrayList.
        /// </summary>
        /// <param name="obj">The menu item to add.</param>
        public virtual void Add(MmgMenuItem obj)
        {
            container.Add(obj);
        }

        /// <summary>
        /// Removes an MmgMenuItem object from the menu item ArrayList.
        /// </summary>
        /// <param name="obj">The menu item object to remove.</param>
        public virtual void Remove(MmgMenuItem obj)
        {
            container.Remove(obj);
        }

        /// <summary>
        /// Gets the number of menu items in this container.
        /// </summary>
        /// <returns>The number of menu items in this container.</returns>
        public virtual int GetCount()
        {
            return container.Count;
        }

        /// <summary>
        /// Gets an array of MmgMenuItem objects stored by this container.
        /// </summary>
        /// <returns>The menu item objects stored by this container.</returns>
        public virtual MmgMenuItem[] GetArray()
        {
            return container.ToArray();
        }

        /// <summary>
        /// Clears all menu items from this menu item container.
        /// </summary>
        public virtual void Clear()
        {
            container.Clear();
        }

        /// <summary>
        /// Gets the ArrayList that contains all the MmgMenuItems.
        /// </summary>
        /// <returns>The menu items contained by this class.</returns>
        public virtual List<MmgMenuItem> GetContainer()
        {
            return container;
        }

        /// <summary>
        /// Sets the ArrayList that stores all the MmgMenuItems.
        /// </summary>
        /// <param name="aTmp">The menu items to hold.</param>
        public virtual void SetContainer(List<MmgMenuItem> aTmp)
        {
            container = aTmp;
        }

        /// <summary>
        /// Draws this object.
        /// </summary>
        /// <param name="p">An MmgPen object that draws this menu container.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (container != null)
                {
                    a = container.ToArray();
                    for (i = 0; i < a.Length; i++)
                    {
                        mo = a[i];
                        if (mo != null && mo.GetIsVisible() == true)
                        {
                            mo.MmgDraw(p);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A method that checks to see if this MmgMenuContainer is equal to the passed in MmgMenuContainer.
        /// </summary>
        /// <param name="obj">The MmgMenuContainer object instance to test for equality.</param>
        /// <returns>Returns true if both MmgMenuContainer objects are the same.</returns>
        public bool ApiEquals(MmgMenuContainer obj)
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
            if (base.ApiEquals((MmgObj)obj))
            {
                if (obj.container == null && container == null)
                {
                    ret = true;
                }
                else if (obj.container != null && container != null)
                {
                    int len1 = obj.GetCount();
                    int len2 = GetCount();
                    if (len1 == len2)
                    {
                        MmgObj m1;
                        MmgObj m2;

                        for (int i = 0; i < len1; i++)
                        {
                            m1 = obj.container[i];
                            m2 = container[i];
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
            }
            else
            {
                ret = false;
            }
            return ret;
        }
    }
}