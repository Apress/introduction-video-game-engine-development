package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents a game item of the type bomb.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItem extends MdtBase {

    /**
     * The sprite animation that is the subject for this object class.
     */
    public MmgObj subj = null;
        
    /**
     * An internal variable used in private class methods.
     */
    private boolean lret = false;    
    
    /**
     * The points given to the player for interacting with this item.
     */
    public MdtPointsType points = MdtPointsType.PTS_100;
    
    /**
     * A boolean indicating if this item can vanish after a few seconds.
     */
    public boolean canVanish = true;
    
    /**
     * A long that tracks how long the current item has been visible if it can vanish.
     */
    public long displayTime = 0;
    
    /**
     * A long that tracks the total amount of time this item can be displayed before vanishing.
     */
    public long displayTimeTotal = 3000;
    
    /**
     * A reference to the game's main screen.
     */
    public ScreenGame screen = null;
    
    /**
     * A basic constructor that takes no arguments.
     */
    public MdtItem() {
        
    }
    
    /**
     * A constructor that allows you to specify values for pertinent class fields.
     * 
     * @param Subj          The MmgObj to use as the subject for this class.
     * @param ObjType       The type of item this class represents.
     * @param ObjSubType    The sub-type of item this class represents.
     * @param Points        The amount of points this item is worth.
     */
    public MdtItem(MmgObj Subj, MdtObjType ObjType, MdtObjSubType ObjSubType, MdtPointsType Points) {        
        SetSubj(Subj);
        SetMdtType(ObjType);
        SetMdtSubType(ObjSubType);
        SetPoints(Points);
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());
        SetDisplayTimeTotal((MmgHelper.GetRandomIntRange(3, 8) * 1000));
    }

    /**
     * Gets the game screen this character belongs to.
     * 
     * @return      The game screen this character belongs to. 
     */
    public ScreenGame GetScreen() {
        return screen;
    }

    /**
     * Sets the game screen this character belongs to.
     * 
     * @param o     The game screen this character belongs to. 
     */
    public void SetScreen(ScreenGame o) {
        screen = o;
    }    

    /**
     * Gets a boolean that indicates if the current item can vanish.
     * 
     * @return      A boolean indicating if this item can vanish.
     */
    public boolean GetCanVanish() {
        return canVanish;
    }

    /**
     * Sets a boolean that indicates if the current item can vanish.
     * 
     * @param b     A boolean indicating if this item can vanish.     
     */
    public void SetCanVanish(boolean b) {
        canVanish = b;
    }

    /**
     * Gets a value indicating the current display time for this item that can vanish.
     * 
     * @return      The current display time for this item if it can vanish.
     */
    public long GetDisplayTime() {
        return displayTime;
    }

    /**
     * Sets a value indicating the current display time for this item that can vanish.
     * 
     * @param l     The current display time for this item if it can vanish.
     */
    public void SetDisplayTime(long l) {
        displayTime = l;
    }

    /**
     * Gets a value indicating the total display time for this item that can vanish.
     * 
     * @return      The total display time for this item if it can vanish. 
     */
    public long GetDisplayTimeTotal() {
        return displayTimeTotal;
    }

    /**
     * Sets  a value indicating the total display time for this item that can vanish.
     * 
     * @param l     The total display time for this item if it can vanish.
     */
    public void SetDisplayTimeTotal(long l) {
        displayTimeTotal = l;
    }
    
    /**
     * Sets the points given to a player for interacting with this item.
     * 
     * @param i     The points given to a player for interacting with this item. 
     */
    public void SetPoints(MdtPointsType i) {
        points = i;
    }
    
    /**
     * Gets the points given to a player for interacting with this item.
     * 
     * @return      The points given to a player for interacting with this item. 
     */
    public MdtPointsType GetPoints() {
        return points;
    }
    
    /**
     * Gets the subject of the object.
     * 
     * @return      The subject of the object.
     */
    public MmgObj GetSubj() {
        return subj;
    }

    /**
     * Sets the subject of the object.
     * 
     * @param Subj      The subject of the object. 
     */
    public void SetSubj(MmgObj Subj) {
        subj = Subj;
    }
    
    /**
     * Sets the position of the object.
     * 
     * @param v     The position of the object.
     */
    @Override
    public void SetPosition(MmgVector2 v) {
        super.SetPosition(v);
        subj.SetPosition(v);
    }
    
    /**
     * Sets the position of the object.
     * 
     * @param x     The X coordinate of the object.
     * @param y     The Y coordinate of the object.
     */
    @Override
    public void SetPosition(int x, int y) {
        super.SetPosition(x, y);
        subj.SetPosition(x, y);
    }
    
    /**
     * Sets the X coordinate of the object.
     * 
     * @param i     The X coordinate of the object.
     */
    @Override
    public void SetX(int i) {
        super.SetX(i);
        subj.SetX(i);
    }
    
    /**
     * Sets the Y coordinate of the object.
     * 
     * @param i     The Y coordinate of the object. 
     */
    @Override
    public void SetY(int i) {
        super.SetY(i);
        subj.SetY(i);
    }    
    
    /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick            The update tick number. 
     * @param currentTimeMs         The current time in the game in milliseconds.
     * @param msSinceLastFrame      The number of milliseconds between the last frame and this frame.
     * @return                      A boolean indicating if any work was done this game frame.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = false;
        if (isVisible == true) {
            subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);            
            if(screen != null && canVanish) {
                displayTime += msSinceLastFrame;
                if(displayTime >= displayTimeTotal) {
                    screen.RemoveObj(this);
                }
            }            
            lret = true;
        }
        return lret;
    }
    
    /**
     * Base draw method, handles drawing this class.
     *
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            subj.MmgDraw(p);
        }
    }    
}