package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Color;

/**
 * A class that represents a menu item.
 * Created by Middlemind Games 08/29/2016
 * 
 * @author Victor G. Brusca
 */
public class MmgMenuItem extends MmgObj {
    
    /**
     * Used to represent a neutral menu item state.
     */
    public static int STATE_NONE = -1;
    
    /**
     * Used to represent a normal menu item state.
     */
    public static int STATE_NORMAL = 0;
    
    /**
     * Used to represent a selected menu item state.
     */
    public static int STATE_SELECTED = 1;
    
    /**
     * Used to represent an inactive menu item state.
     */
    public static int STATE_INACTIVE = 2;

    /**
     * The event to fir if the menu item has been pressed.
     */
    private MmgEvent eventPress;
    
    /**
     * The object to use if the menu item is normal.
     */
    private MmgObj normal;
    
    /**
     * The object to use if the menu item is selected.
     */
    private MmgObj selected;
    
    /**
     * The object to use if the menu item is inactive.
     */
    private MmgObj inactive;
    
    /**
     * The currently drawn object.
     */
    private MmgObj current;
    
    /**
     * A sound effect to play when the menu item is selected.
     */
    private MmgSound sound;
    
    /**
     * A class helper variable for tracking the current state.
     */
    private int state;

    /**
     * A class helper variable indicating if the state has been set for this class instance.
     */
    private boolean stateSet = false;
    
    /**
     * A static class field that is used to show a bounding box around the object.
     */
    public static boolean SHOW_MENU_ITEM_BOUNDING_BOX = false;
    
    /**
     * A helper variable used in the MmgDraw method.
     */
    private Color c;
    
    /**
     * Constructor for this class.
     */
    public MmgMenuItem() {
        super();
        SetEventPress(null);
        SetNormal(null);
        SetSelected(null);
        SetInactive(null);
        SetState(STATE_NONE);        
    }

    /**
     * Constructor for this class that sets the value of base attributes
     * from the given argument.
     * 
     * @param m     The MmgObj to use to set the attributes of this object. 
     */
    public MmgMenuItem(MmgObj m) {
    	super(m);
        eventPress = null;
        normal = null;
        selected = null;
        inactive = null;
        current = null;
        state = STATE_NONE;
    }
    
    /**
     * Constructor for this class that sets the value of certain attributes based
     * on the value of attributes in the given argument.
     * 
     * @param obj     An MmgMenuItem object to get attribute values from. 
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgMenuItem(MmgMenuItem obj) {
        super();
        SetEventPress(obj.GetEventPress());
        
        if(obj.GetNormal() == null) {
            SetNormal(obj.GetNormal());
        } else {
            SetNormal(obj.GetNormal().Clone());
        }
        
        if(obj.GetSelected() == null) {
            SetSelected(obj.GetSelected());
        } else {
            SetSelected(obj.GetSelected().Clone());
        }
        
        if(obj.GetInactive() == null) {
            SetInactive(obj.GetInactive());
        } else {
            SetInactive(obj.GetInactive().Clone());            
        }
        
        SetState(obj.GetState());
        
        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            SetPosition(obj.GetPosition().Clone());
        }
        
        SetWidth(obj.GetWidth());
        SetHeight(obj.GetHeight());
        SetIsVisible(obj.GetIsVisible());
        
        if(obj.GetMmgColor() != null) {
            SetMmgColor(obj.GetMmgColor().Clone());
        }else{
            SetMmgColor(obj.GetMmgColor());
        }
        
        if(obj.GetSound() != null) {
            SetSound(obj.GetSound().Clone());
        }else {
            SetSound(obj.GetSound());
        }
    }

    /**
     * A constructor for this class that sets the event, the appearance objects and the state
     * of the menu item.
     * 
     * @param me            The event to fire if the menu item is pressed. 
     * @param Normal        The object to show if the menu item has a normal state.
     * @param Selected      The object to show if the menu item has a selected state.
     * @param Inactive      The object to show if the menu item has an inactive state.
     * @param State         The current state of the menu item object.
     */
    public MmgMenuItem(MmgEvent me, MmgObj Normal, MmgObj Selected, MmgObj Inactive, int State) {
    	super();
        SetEventPress(me);
        SetNormal(Normal);
        SetSelected(Selected);
        SetInactive(Inactive);
        SetState(State);
    }

    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class. 
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgMenuItem(this);
    }
    
    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class. 
     */
    @Override
    public MmgMenuItem CloneTyped() {
        return new MmgMenuItem(this);
    }

    /**
     * Gets the current menu sound object.
     * 
     * @return      An MmgSound object used in menu item selection.
     */
    public MmgSound GetSound() {
        return sound;
    }

    /**
     * Sets the current menu sound object.
     * 
     * @param Sound     An MmgSound object used in menu item selection.
     */
    public void SetSound(MmgSound Sound) {
        sound = Sound;
    }    
    
    /**
     * Gets the press event for this menu item.
     * 
     * @return      The press event for this menu item. 
     */
    public MmgEvent GetEventPress() {
        return eventPress;
    }

    /**
     * Sets the press event for this menu item.
     * 
     * @param e     The press event for this menu item.
     */
    public void SetEventPress(MmgEvent e) {
        eventPress = e;
    }

    /**
     * Gets the object to draw in the normal state.
     * 
     * @return      The normal state object. 
     */
    public MmgObj GetNormal() {
        return normal;
    }

    /**
     * Sets the object to draw in the normal state.
     * 
     * @param m     The normal state object. 
     */
    public void SetNormal(MmgObj m) {
        normal = m;
    }

    /**
     * Gets the object to draw in the selected state.
     * 
     * @return      The selected state object.
     */
    public MmgObj GetSelected() {
        return selected;
    }

    /**
     * Sets the object to draw in the selected state.
     * 
     * @param m     The selected state object.
     */
    public void SetSelected(MmgObj m) {
        selected = m;
    }

    /**
     * Gets the activity flag for this menu item.
     * 
     * @return      True if the object is active, false otherwise. 
     */
    public MmgObj GetInactive() {
        return inactive;
    }

    /**
     * Sets the activity flag for this menu item.
     * 
     * @param m     True if the object is active, false otherwise.
     */
    public void SetInactive(MmgObj m) {
        inactive = m;
    }

    /**
     * Sets the current state of the menu item.
     * 
     * @param i     The current state of the menu item. 
     */
    public void SetState(int i) {
        if(state != i) {
            if (i == STATE_NORMAL) {
                current = normal;
            } else if (i == STATE_SELECTED) {
                current = selected;                
                if(sound != null) {
                    sound.Play();
                }
            } else if (i == STATE_INACTIVE) {
                current = inactive;                
            } else {
                current = normal;
            }

            stateSet = true;
            if(current != null) {
                super.SetWidth(current.GetWidth());
                super.SetHeight(current.GetHeight());            
            } else {
                super.SetWidth(0);
                super.SetHeight(0);
            }
            state = i;
        }
        
        if(!stateSet) {
            stateSet = true;
            current = normal;
            if(current != null) {
                super.SetWidth(current.GetWidth());
                super.SetHeight(current.GetHeight());            
            } else {
                super.SetWidth(0);
                super.SetHeight(0);
            }
        }
    }

    /**
     * Gets the current state of the menu item.
     * 
     * @return      The current state of the menu item. 
     */
    public int GetState() {
        return state;
    }

    /**
     * The base drawing method for this object.
     * 
     * @param p     The MmgPen object used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            if (MmgMenuItem.SHOW_MENU_ITEM_BOUNDING_BOX == true) {                
                c = p.GetGraphicsColor();
                p.SetGraphicsColor(Color.RED);
                p.DrawRect(this);
                p.SetGraphicsColor(c);                
            }            
            
            current.SetPosition(GetPosition());
            current.SetMmgColor(GetMmgColor());
            current.MmgDraw(p);
        }
    }
    
    /**
     * A method that checks to see if this MmgMenuContainer is equal to the passed in MmgMenuContainer.
     * 
     * @param c     The MmgMenuContainer object instance to test for equality.
     * @return      Returns true if both MmgMenuContainer objects are the same.
     */
     public boolean ApiEquals(MmgMenuItem obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
                 
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
            && obj.GetHeight() == GetHeight()
            && ((obj.GetInactive() == null && GetInactive() == null) || (obj.GetInactive() != null && GetInactive() != null && obj.GetInactive().ApiEquals(GetInactive())))
            && ((obj.GetNormal() == null && GetNormal() == null) || (obj.GetNormal() != null && GetNormal() != null && obj.GetNormal().ApiEquals(GetNormal())))
            && ((obj.GetSelected() == null && GetSelected() == null) || (obj.GetSelected() != null && GetSelected() != null && obj.GetSelected().ApiEquals(GetSelected())))
            && ((obj.GetSound() == null && GetSound() == null) || (obj.GetSound() != null && GetSound() != null && obj.GetSound().ApiEquals(GetSound())))
            && obj.GetState() == GetState()
            && obj.GetWidth() == GetWidth()
        ) {
            ret = true;
        }
        return ret;
    }
}