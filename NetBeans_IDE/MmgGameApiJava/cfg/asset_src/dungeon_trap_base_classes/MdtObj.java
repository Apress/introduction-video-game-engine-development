package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents a game object.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtObj extends MdtBase {

    /**
     * The subject of the class.
     */
    public MmgObj subj = null;
        
    /**
     * A private variable used in internal methods.
     */
    private boolean lret = false;
    
    /**
     * A generic constructor for this class.
     */
    public MdtObj() {
        
    }    
    
    /**
     * A complex constructor that takes arguments for configuring pertinent class fields.
     * 
     * @param Subj          The subject of this object.
     * @param ObjType       The type of this object.
     * @param ObjSubType    The sub-type of this object.
     */
    public MdtObj(MmgObj Subj, MdtObjType ObjType, MdtObjSubType ObjSubType) {
        SetSubj(Subj);
        SetMdtType(ObjType);
        SetMdtSubType(ObjSubType);
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());        
    }
 
    /**
     * Gets the subject of the class.
     * 
     * @return      The subject of the class.
     */
    public MmgObj GetSubj() {
        return subj;
    }

    /**
     * Sets the subject of the class.
     * 
     * @param Subj  The subject of the class.
     */
    public void SetSubj(MmgObj Subj) {
        subj = Subj;
    }
    
    /**
     * Sets the position of the object.
     * 
     * @param v         The position of the object. 
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
     * Sets the X coordinate of the object's position.
     * 
     * @param i     The X coordinate of the object. 
     */
    @Override
    public void SetX(int i) {
        super.SetX(i);
        subj.SetX(i);
    }
    
    /**
     * Sets the Y coordinate of the object's position.
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