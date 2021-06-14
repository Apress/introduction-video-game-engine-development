package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents a UI element, the health bar.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/22/2020
 */
public class MdtUiPoints extends MdtBase {

    /**
     * The subject of this UI element.
     */
    public MmgBmp subj = null;
    
    /**
     * A boolean flag indicating if the associated UI points are done displaying.
     */
    public boolean isFinished = false;
        
    /**
     * A private variable used in internal methods.
     */
    private boolean lret = false;    
    
    /**
     * The current time this object has spent floating.
     */
    public long floatTiming = 0;
    
    /**
     * The total time this object can spend floating.
     */
    public long floatTimingTotal = 500;

    /**
     * The game screen this MdtChar belongs to.
     */
    public ScreenGame screen = null;
        
    /**
     * The player that triggered this UI object.
     */
    public MdtPlayerType player;
    
    /**
     * A base constructor that takes no arguments and loads object resources automatically.
     */
    public MdtUiPoints(MmgBmp Subj, MdtPlayerType Player, ScreenGame Screen, MmgVector2 StartPosition) {
        SetSubj(Subj);
        SetMdtType(MdtObjType.UI);
        SetMdtSubType(MdtObjSubType.UI_POINTS);
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());
        SetScreen(Screen);
        SetPosition(StartPosition);
    }

    /**
     * A constructor that allows you to specify the subject of the object.
     * 
     * @param Subj      The subject of the object.
     */
    public MdtUiPoints(MmgBmp Subj) {
        SetSubj(Subj);
        SetMdtType(MdtObjType.UI);
        SetMdtSubType(MdtObjSubType.UI_POINTS);
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());        
    }    
    
    
    /**
     * Gets the player that triggered this UI object.
     * 
     * @return      The player that triggered this UI object. 
     */
    public MdtPlayerType GetPlayer() {
        return player;
    }

    /**
     * Sets the player that triggered this UI object.
     * 
     * @param p     The player that triggered this UI object. 
     */
    public void SetPlayer(MdtPlayerType p) {
        player = p;
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
     * Gets the subject of the object.
     * 
     * @return      The subject of the object.
     */
    public MmgBmp GetSubj() {
        return subj;
    }

    /**
     * Sets the subject of the object.
     * 
     * @param Subj      The subject of the object. 
     */
    public void SetSubj(MmgBmp Subj) {
        subj = Subj;
    }

    /**
     * Gets a boolean indicating if this object is done displaying.
     * 
     * @return      A boolean indicating if this object is done displaying. 
     */
    public boolean GetIsFinished() {
        return isFinished;
    }

    /**
     * Sets a boolean indicating if this object is done displaying.
     * 
     * @param b     A boolean indicating if this object is done displaying. 
     */
    public void SetIsFinished(boolean b) {
        isFinished = b;
    }

    /**
     * Gets the time this object has spent floating.
     * 
     * @return      The time this object has spent floating.
     */
    public long GetFloatTiming() {
        return floatTiming;
    }

    /**
     * Sets the time this object has spent floating.
     * 
     * @param f     The time this object has spent floating. 
     */
    public void SetFloatTiming(long f) {
        floatTiming = f;
    }

    /**
     * Gets the total time this object can spend floating.
     * 
     * @return      The total time this object can spend floating.
     */
    public long GetFloatTimingTotal() {
        return floatTimingTotal;
    }

    /**
     * Sets the total time this object can spend floating.
     * 
     * @param f     The total time this object can spend floating. 
     */
    public void SetFloatTimingTotal(long f) {
        floatTimingTotal = f;
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
            
            floatTiming += msSinceLastFrame;
            if(floatTiming >= floatTimingTotal) {
                SetIsVisible(false);
                SetIsFinished(true);  
                screen.RemoveObj(this);
            } else {
                SetY(GetY() - MmgHelper.ScaleValue(3));
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