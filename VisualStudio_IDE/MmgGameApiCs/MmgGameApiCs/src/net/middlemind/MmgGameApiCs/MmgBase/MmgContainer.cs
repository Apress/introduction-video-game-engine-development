using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that represents a container of MmgObj objects. 
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgContainer : MmgObj
    {
        /// <summary>
        /// The initial size of the collection object.
        /// </summary>
        public static int INITIAL_SIZE = 10;

        /// <summary>
        /// Private enumeration that lists the stamp, un-stamp actions that can be
        /// performed on a child.Stamping marks the child as being associated with the
        /// container.
        /// </summary>
        private enum ChildAction
        {
            STAMP,
            UNSTAMP
        }

        /// <summary>
        /// An enumeration that controls the render mode allowing you to either control the rendering via the isDirty flag or to render every game frame. 
        /// </summary>
        public enum RenderMode
        {
            RENDER_ALWAYS,
            RENDER_ONLY_WHEN_DIRTY
        }

        /// <summary>
        /// A private field that holds the current RenderMode value.
        /// </summary>
        private RenderMode mode = RenderMode.RENDER_ALWAYS;

        /// <summary>
        /// The List that holds the MmgObj objects.
        /// </summary>
        private List<MmgObj> container;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private object[] a;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private MmgObj mo;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private int i;

        /// <summary>
        /// A boolean flag that marks this object as dirty and allows the MmgUpdate call to be called on child objects. 
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// A private local variable used in the MmgUpdate method to flag if the update was handled this frame. 
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgContainer() : base()
        {
            SetContainer(new List<MmgObj>(INITIAL_SIZE));
            SetIsDirty(true);
        }

        /// <summary>
        /// Constructor that sets the base objects properties equal to the given
        /// arguments properties.
        /// </summary>
        /// <param name="obj">The object to get MmgObj properties from.</param>
        public MmgContainer(MmgObj obj) : base(obj)
        {
            SetContainer(new List<MmgObj>(INITIAL_SIZE));
            SetIsDirty(true);
        }

        /// <summary>
        /// Constructor that initializes an ArrayList of objects contained by this container object.
        /// </summary>
        /// <param name="objects">The objects to add to this container.</param>
        public MmgContainer(List<MmgObj> objects) : base()
        {
            SetContainer(objects);
            SetIsDirty(true);
        }

        /// <summary>
        /// Constructor that initializes this class based on the attributes of a given argument.
        /// </summary>
        /// <param name="obj">An MmgContainer class to use to set all the attributes of this class.</param>
        public MmgContainer(MmgContainer obj) : base()
        {
            List<MmgObj> tmp1 = obj.GetContainer();
            if (tmp1 != null)
            {
                int len = tmp1.Count;
                List<MmgObj> tmp2 = new List<MmgObj>(len);
                for (int j = 0; j < len; j++)
                {
                    tmp2.Add(tmp1[j].CloneTyped());
                }
                SetContainer(tmp2);
            }
            else
            {
                SetContainer(tmp1);
            }

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
            SetIsDirty(true);
            SetMode(obj.GetMode());
        }

        /// <summary>
        /// Gets the current render mode.
        /// </summary>
        /// <returns>The render mode.</returns>
        public virtual RenderMode GetMode()
        {
            return mode;
        }

        /// <summary>
        /// Sets the current render mode.
        /// </summary>
        /// <param name="m">The render mode.</param>
        public virtual void SetMode(RenderMode m)
        {
            mode = m;
        }

        /// <summary>
        /// A setter method that sets the isDirty flag.
        /// </summary>
        /// <param name="b">The boolean value to set the isDirty flag to.</param>
        public virtual void SetIsDirty(bool b)
        {
            isDirty = b;
        }

        /// <summary>
        /// A getter method that returns the state of the isDirty boolean.
        /// </summary>
        /// <returns>The boolean value of the isDirty flag.</returns>
        public virtual bool GetIsDirty()
        {
            return isDirty;
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgContainer(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgContainer CloneTyped()
        {
            return new MmgContainer(this);
        }

        /// <summary>
        /// Adds a new MmgObj to the container.
        /// </summary>
        /// <param name="obj">An MmgObj to add to the container.</param>
        public virtual void Add(MmgObj obj)
        {
            if (obj != null)
            {
                container.Add(obj);
                if (container.Contains(obj) == true)
                {
                    StampChild(obj);
                }
            }
        }

        /// <summary>
        /// Adds a new MmgObj to the container at the specified index.
        /// </summary>
        /// <param name="idx">The index to add the object at.</param>
        /// <param name="obj">The object to add.</param>
        public virtual void AddAt(int idx, MmgObj obj)
        {
            if (obj != null)
            {
                if (idx >= 0 && idx < container.Count)
                {
                    container[idx] = obj;
                }
                else
                {
                    container.Add(obj);
                }

                if (container.Contains(obj) == true)
                {
                    StampChild(obj);
                }
            }
        }

        /// <summary>
        /// Removes an MmgObj from the container.
        /// </summary>
        /// <param name="obj">An MmgObj to remove from the container.</param>
        public virtual void Remove(MmgObj obj)
        {
            if (obj != null)
            {
                if (container.Remove(obj) == true)
                {
                    UnstampChild(obj);
                }
            }
        }

        /// <summary>
        /// Removes an MmgObj from the container at the specified index.
        /// </summary>
        /// <param name="idx">The index to remove the object from.</param>
        /// <returns>The MmgObj to remove.</returns>
        public virtual MmgObj RemoveAt(int idx)
        {
            MmgObj obj = container[idx];
            container.RemoveAt(idx);
            if (container.Contains(obj) == false)
            {
                UnstampChild(obj);
            }
            return obj;
        }

        /// <summary>
        /// Gets the number of objects in the container.
        /// </summary>
        /// <returns>The number of objects in the container.</returns>
        public virtual int GetCount()
        {
            return container.Count;
        }

        /// <summary>
        /// Gets an array representation of the objects in the container.
        /// </summary>
        /// <returns></returns>
        public virtual MmgObj[] GetArray()
        {
            return container.ToArray();
        }

        /// <summary>
        /// Returns the MmgObj at the given index.
        /// </summary>
        /// <param name="idx">The index to get an MmgObj from.</param>
        /// <returns>The MmgObj at the specified index.</returns>
        public virtual MmgObj GetAt(int idx)
        {
            return container[idx];
        }

        /// <summary>
        /// Clears all objects from the container.
        /// </summary>
        public virtual void Clear()
        {
            UpdateAllChildren(ChildAction.UNSTAMP);
            container.Clear();
        }

        /// <summary>
        /// Resets the container object. 
        /// </summary>
        public virtual void Reset()
        {
            container = new List<MmgObj>(MmgContainer.INITIAL_SIZE);
        }

        /// <summary>
        /// Gets the ArrayList container that holds all child objects.
        /// </summary>
        /// <returns>The ArrayList container of this MmgContainer object.</returns>
        public virtual List<MmgObj> GetContainer()
        {
            return container;
        }

        /// <summary>
        /// Sets the ArrayList container that holds all the child objects.
        /// </summary>
        /// <param name="a">An ArrayList to set this container's contents from.</param>
        public virtual void SetContainer(List<MmgObj> aTmp)
        {
            if (aTmp != null)
            {
                container = aTmp;
                UpdateAllChildren(ChildAction.STAMP);
            }
            else
            {
                container = null;
            }
        }

        /// <summary>
        /// A method to update all children with the provided action.
        /// </summary>
        /// <param name="act">The action to perform on the child objects.</param>
        private void UpdateAllChildren(ChildAction act)
        {
            int len = GetCount();
            MmgObj obj;
            for (int j = 0; j < len; j++)
            {
                obj = container[j];
                if (obj != null)
                {
                    if (act == ChildAction.STAMP)
                    {
                        StampChild(obj);
                    }
                    else
                    {
                        UnstampChild(obj);
                    }
                }
            }
        }

        /// <summary>
        /// A method that stamps the child as belonging to the parent.
        /// </summary>
        /// <param name="obj">The child to perform the operation on.</param>
        private void StampChild(MmgObj obj)
        {
            if (obj != null)
            {
                obj.SetHasParent(true);
                obj.SetParent(this);
            }
        }

        /// <summary>
        /// A method that un-stamps the child, removing it from belonging to the parent.
        /// </summary>
        /// <param name="obj">The child to perform the operation on. </param>
        private void UnstampChild(MmgObj obj)
        {
            if (obj != null)
            {
                obj.SetHasParent(false);
                obj.SetParent(null);
            }
        }

        /// <summary>
        /// Returns the child at the given index.
        /// </summary>
        /// <param name="idx">The index of the child to get.</param>
        /// <returns>The child at the given index.</returns>
        public virtual MmgObj GetChildAt(int idx)
        {
            return container[idx];
        }

        /// <summary>
        /// Returns the relative position of the child at the given index.
        /// </summary>
        /// <param name="idx">The index of the child to get.</param>
        /// <returns>An MmgVector2 object with the relative position of the child.</returns>
        public virtual MmgVector2 GetChildPosRelative(int idx)
        {
            MmgObj obj = container[idx];
            MmgVector2 v1 = new MmgVector2();
            v1.SetX(obj.GetX() - this.GetX());
            v1.SetY(obj.GetY() - this.GetY());
            return v1;
        }

        /// <summary>
        /// Returns the absolute position of the child at the given index.
        /// </summary>
        /// <param name="idx">The index of the child to get.</param>
        /// <returns>An MmgVector2 object with the absolute position of the child.</returns>
        public virtual MmgVector2 GetChildPosAbsolute(int idx)
        {
            return container[idx].GetPosition();
        }

        /// <summary>
        /// The base drawing method used to render this object with an MmgPen.
        /// </summary>
        /// <param name="p">The MmgPen that will draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (container != null)
                {
                    a = container.ToArray();
                    for (i = 0; i < a.Length; i++)
                    {
                        mo = (MmgObj)a[i];
                        if (mo != null && mo.isVisible == true)
                        {
                            mo.MmgDraw(p);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTicks">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A boolean indicating if any work was done.</returns>
        public override bool MmgUpdate(int updateTicks, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (isVisible == true && isDirty == true)
            {
                if (mode == RenderMode.RENDER_ONLY_WHEN_DIRTY)
                {
                    isDirty = false;
                }

                if (container != null)
                {
                    a = container.ToArray();
                    for (i = 0; i < a.Length; i++)
                    {
                        mo = (MmgObj)a[i];
                        if (mo != null && mo.isVisible == true)
                        {
                            if (mo.MmgUpdate(updateTicks, currentTimeMs, msSinceLastFrame) == true)
                            {
                                lret = true;
                            }
                        }
                    }
                }
            }
            return lret;
        }

        /// <summary>
        /// A method that checks to see if this MmgContainer is equal to the passed in MmgContainer.
        /// </summary>
        /// <param name="obj">The MmgContainer object instance to test for equality.</param>
        /// <returns>Returns true if both MmgContainer objects are the same.</returns>
        public virtual bool ApiEquals(MmgContainer obj)
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
            return ret;
        }
    }
}