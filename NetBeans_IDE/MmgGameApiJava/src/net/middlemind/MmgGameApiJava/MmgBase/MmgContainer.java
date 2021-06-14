package net.middlemind.MmgGameApiJava.MmgBase;

import java.util.*;

/**
 * Class that represents a container of MmgObj objects. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgContainer extends MmgObj {
    
    /**
     * The initial size of the collection object.
     */
    public static int INITIAL_SIZE = 10;
    
    /**
     * Private enumeration that lists the stamp, un-stamp actions that can be
     * performed on a child. Stamping marks the child as being associated with the
     * container.
     */
    public enum ChildAction {
        STAMP,
        UNSTAMP
    }

    /**
     * An enumeration that controls the render mode allowing you to either control the rendering via the isDirty flag or to render every game frame.
     */
    public enum RenderMode {
        RENDER_ALWAYS,
        RENDER_ONLY_WHEN_DIRTY
    }
    
    /**
     * A private field that holds the current RenderMode value.
     */
    private RenderMode mode = RenderMode.RENDER_ALWAYS;
    
    /**
     * The ArrayList that holds the MmgObj objects.
     */
    private ArrayList<MmgObj> container;

    /**
     * A class helper variable.
     */
    private Object[] a;

    /**
     * A class helper variable.
     */
    private MmgObj mo;

    /**
     * A class helper variable.
     */
    private int i;

    /**
     * A boolean flag that marks this object as dirty and allows the MmgUpdate call to 
     * be called on child objects.
     */
    private boolean isDirty;
    
    /**
     * A private local variable used in the MmgUpdate method to flag if the update was handled this frame.
     */
    private boolean lret = false;
    
    /**
     * Constructor for this class.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgContainer() {
        super();
        SetContainer(new ArrayList(INITIAL_SIZE));
        SetIsDirty(true);
    }

    /**
     * Constructor that sets the base objects properties equal to the given
     * arguments properties.
     *
     * @param obj       The object to get MmgObj properties from.
     */
    public MmgContainer(MmgObj obj) {
        super(obj);
        SetContainer(new ArrayList(INITIAL_SIZE));        
        SetIsDirty(true);        
    }    
    
    /**
     * Constructor that initializes an ArrayList of objects contained by this
     * container object.
     *
     * @param objects       The objects to add to this container.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgContainer(ArrayList<MmgObj> objects) {
        super();
        SetContainer(objects);
        SetIsDirty(true);        
    }

    /**
     * Constructor that initializes this class based on the attributes of a
     * given argument.
     *
     * @param obj          An MmgContainer class to use to set all the attributes of this class.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgContainer(MmgContainer obj) {
        super();
        ArrayList<MmgObj> tmp1 = obj.GetContainer();
        if (tmp1 != null) {
            int len = tmp1.size();
            ArrayList<MmgObj> tmp2 = new ArrayList(len);
            for (int j = 0; j < len; j++) {
                tmp2.add(j, tmp1.get(j).CloneTyped());
            }
            SetContainer(tmp2);
        } else {
            SetContainer(tmp1);
        }

        if (obj.GetPosition() != null) {
            SetPosition(obj.GetPosition().Clone());
        } else {
            SetPosition(obj.GetPosition());
        }

        SetWidth(obj.GetWidth());
        SetHeight(obj.GetHeight());
        SetIsVisible(obj.GetIsVisible());

        if (obj.GetMmgColor() != null) {
            SetMmgColor(obj.GetMmgColor().Clone());
        } else {
            SetMmgColor(obj.GetMmgColor());
        }
        SetIsDirty(true);
        SetMode(obj.GetMode());
    }

    /**
     * Gets the current render mode.
     * 
     * @return      The render mode.
     */
    public RenderMode GetMode() {
        return mode;
    }

    /**
     * Sets the current render mode.
     * 
     * @param m     The render mode.
     */
    public void SetMode(RenderMode m) {
        mode = m;
    }
    
    /**
     * A setter method that sets the isDirty flag.
     * 
     * @param b     The boolean value to set the isDirty flag to.
     */
    public void SetIsDirty(boolean b) {
        isDirty = b;
    }
    
    /**
     * A getter method that returns the state of the isDirty boolean.
     * 
     * @return      The boolean value of the isDirty flag.
     */
    public boolean GetIsDirty() {
        return isDirty;
    }
    
    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgContainer(this);
    }

    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override
    public MmgContainer CloneTyped() {
        return new MmgContainer(this);
    }
        
    /**
     * Adds a new MmgObj to the container.
     *
     * @param obj       An MmgObj to add to the container.
     */
    public void Add(MmgObj obj) {
        if (obj != null) {
            if (container.add(obj) == true) {
                StampChild(obj);
            }
        }
    }

    /**
     * Adds a new MmgObj to the container at the specified index.
     *
     * @param idx       The index to add the object at.
     * @param obj       The object to add.
     */
    public void AddAt(int idx, MmgObj obj) {
        if (obj != null) {
            if(idx >= 0 && idx < container.size()) {
                container.add(idx, obj);  
            }else {
                container.add(obj);
            }
            if(container.contains(obj) == true) {
                StampChild(obj);
            }
        }
    }

    /**
     * Removes an MmgObj from the container.
     *
     * @param obj       An MmgObj to remove from the container.
     */
    public void Remove(MmgObj obj) {
        if (obj != null) {
            if (container.remove(obj) == true) {
                UnstampChild(obj);
            }
        }
    }

    /**
     * Removes an MmgObj from the container at the specified index.
     *
     * @param idx       The index to remove the object from.
     * @return          The MmgObj to remove.
     */
    public MmgObj RemoveAt(int idx) {
        MmgObj obj = container.remove(idx);
        if (obj != null) {
            UnstampChild(obj);
        }
        return obj;
    }

    /**
     * Gets the number of objects in the container.
     *
     * @return          The number of objects in the container.
     */
    public int GetCount() {
        return container.size();
    }

    /**
     * Gets an array representation of the objects in the container.
     *
     * @return          An array of the objects in the container.
     */
    public MmgObj[] GetArray() {
        MmgObj[] ret = new MmgObj[container.size()];
        ret = container.toArray(ret);
        return ret;
    }

    /**
     * Returns the MmgObj at the given index.
     *
     * @param idx       The index to get an MmgObj from.
     * @return          The MmgObj at the specified index.
     */
    public MmgObj GetAt(int idx) {
        return container.get(idx);
    }

    /**
     * Clears all objects from the container.
     */
    public void Clear() {
        UpdateAllChildren(ChildAction.UNSTAMP);
        container.clear();
    }

    /**
     * Resets the container object.
     */
    public void Reset() {
        container = new ArrayList(MmgContainer.INITIAL_SIZE);
    }
    
    /**
     * Gets the ArrayList container that holds all child objects.
     *
     * @return          The ArrayList container of this MmgContainer object.
     */
    public ArrayList<MmgObj> GetContainer() {
        return container;
    }

    /**
     * Sets the ArrayList container that holds all the child objects.
     *
     * @param aTmp      An ArrayList to set this container's contents from.
     */
    public void SetContainer(ArrayList<MmgObj> aTmp) {
        if (aTmp != null) {
            container = aTmp;
            UpdateAllChildren(ChildAction.STAMP);
        } else {
            container = null;
        }
    }

    /**
     * A method to update all children with the provided action.
     * 
     * @param act       The action to perform on the child objects.
     */
    private void UpdateAllChildren(ChildAction act) {
        int len = GetCount();
        MmgObj obj;
        for (int j = 0; j < len; j++) {
            obj = container.get(j);
            if (obj != null) {
                if (act == ChildAction.STAMP) {
                    StampChild(obj);
                } else {
                    UnstampChild(obj);
                }
            }
        }
    }

    /**
     * A method that stamps the child as belonging to the parent.
     * 
     * @param obj       The child to perform the operation on.
     */
    private void StampChild(MmgObj obj) {
        if (obj != null) {
            obj.SetHasParent(true);
            obj.SetParent(this);
        }
    }

    /**
     * A method that un-stamps the child, removing it from belonging to the parent.
     * 
     * @param obj       The child to perform the operation on. 
     */
    private void UnstampChild(MmgObj obj) {
        if (obj != null) {
            obj.SetHasParent(false);
            obj.SetParent(null);
        }
    }

    /**
     * Returns the child at the given index.
     *
     * @param idx       The index of the child to get.
     * @return          The child at the given index.
     */
    public MmgObj GetChildAt(int idx) {
        return container.get(idx);
    }

    /**
     * Returns the relative position of the child at the given index.
     *
     * @param idx       The index of the child to get.
     * @return          An MmgVector2 object with the relative position of the child.
     */
    public MmgVector2 GetChildPosRelative(int idx) {
        MmgObj obj = container.get(idx);
        MmgVector2 v1 = new MmgVector2();
        v1.SetX(obj.GetX() - this.GetX());
        v1.SetY(obj.GetY() - this.GetY());
        return v1;
    }

    /**
     * Returns the absolute position of the child at the given index.
     *
     * @param idx       The index of the child to get.
     * @return          An MmgVector2 object with the absolute position of the child.
     */
    public MmgVector2 GetChildPosAbsolute(int idx) {
        return container.get(idx).GetPosition();
    }

    /**
     * The base drawing method used to render this object with an MmgPen.
     *
     * @param p         The MmgPen that will draw this object.
     * @see             MmgPen
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            if(container != null) {
                a = container.toArray();
                for (i = 0; i < a.length; i++) {
                    mo = (MmgObj) a[i];
                    if (mo != null && mo.isVisible == true) {
                        mo.MmgDraw(p);
                    }
                }
            }
        }
    }

    /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick            The update tick number. 
     * @param currentTimeMs         The current time in the game in milliseconds.
     * @param msSinceLastFrame      The number of milliseconds between the last frame and this frame.
     * @return                      A boolean indicating if any work was done.
     */
    @Override
    public boolean MmgUpdate(int updateTicks, long currentTimeMs, long msSinceLastFrame) {
        lret = false;

        if (isVisible == true && isDirty == true) {
            if(mode == RenderMode.RENDER_ONLY_WHEN_DIRTY) {
                isDirty = false;
            }
            
            if(container != null) {
                a = container.toArray();
                for (i = 0; i < a.length; i++) {
                    mo = (MmgObj) a[i];
                    if (mo != null && mo.isVisible == true) {
                        if (mo.MmgUpdate(updateTicks, currentTimeMs, msSinceLastFrame) == true) {
                            lret = true;
                        }
                    }
                }
            }
        }
        return lret;
    }
    
    /**
     * A method that checks to see if this MmgContainer is equal to the passed in MmgContainer.
     * 
     * @param c     The MmgContainer object instance to test for equality.
     * @return      Returns true if both MmgContainer objects are the same.
     */
    public boolean ApiEquals(MmgContainer obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
                  
        boolean ret = true;
        if(obj.container == null && container == null) {
            ret = true;
        } else if(obj.container != null && container != null) {
            int len1 = obj.GetCount();
            int len2 = GetCount();
            if(len1 == len2) {
                MmgObj m1;
                MmgObj m2;

                for(int i = 0; i < len1; i++) {
                    m1 = obj.container.get(i);
                    m2 = container.get(i);
                    if(
                        !((m1 == null && m2 == null) || (m1 != null && m2 != null && m1.ApiEquals(m2)))
                    ){
                        ret = false;
                        break;
                    }
                }
            } else {
                ret = false;
            }
        } else {
            ret = false;
        }
        return ret;
    }    
}