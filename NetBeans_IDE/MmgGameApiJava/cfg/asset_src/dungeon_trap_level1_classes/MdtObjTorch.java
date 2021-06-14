package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteSheet;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents a game torch.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtObjTorch extends MdtObj {
    
    /**
     * An MmgBmp object to display when the torch is off.
     */
    public MmgBmp subjOff = null;
    
    /**
     * A boolean flag indicating if the torch is burning (on) or not (off).
     */
    public boolean isBurning = false;
    
    /**
     * A private variable used in internal methods.
     */
    private boolean lret = false;
    
    /**
     * A basic constructor for the large table class.
     */
    public MdtObjTorch() {
        MmgBmp src = MmgHelper.GetBasicCachedBmp("torch_spritesheet_lg.png");
        MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);
        MmgSprite subj = new MmgSprite(ssSrc.GetFrames());
        subj.SetMsPerFrame(280);
        SetSubj(subj);
        SetSubjOff(MmgHelper.GetBasicCachedBmp("torch_off.png"));        
        SetMdtType(MdtObjType.OBJECT);
        SetMdtSubType(MdtObjSubType.OBJECT_TORCH);
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());        
    }
 
    /**
     * A constructor for the torch class that let's you specify the subject and the torch off image.
     * 
     * @param Subj      The subject of the class. 
     * @param SubjOff   The torch off image.
     */
    public MdtObjTorch(MmgSprite Subj, MmgBmp SubjOff) {
        super(Subj, MdtObjType.OBJECT, MdtObjSubType.OBJECT_TORCH);
        GetSubj().SetMsPerFrame(280);
        SetSubjOff(SubjOff);
    }    

    /**
     * Gets the subject of the class.
     * 
     * @return      The subject of the class.
     */
    @Override
    public MmgSprite GetSubj() {
        return (MmgSprite)subj;
    }

    /**
     * Gets the torch off subject of the class.
     * 
     * @return      The torch off subject.
     */
    public MmgBmp GetSubjOff() {
        return subjOff;
    }

    /**
     * Sets the torch off subject of the class.
     * 
     * @param SubjOff   The torch off subject.
     */
    public void SetSubjOff(MmgBmp SubjOff) {
        subjOff = SubjOff;
    }

    /**
     * Gets a boolean flag indicating if the torch is burning (on) or not (off).
     * 
     * @return      A boolean flag indicating if the torch is on.
     */
    public boolean GetIsBurning() {
        return isBurning;
    }

    /**
     * Sets a boolean flag indicating if the torch is burning (on) or not (off).
     * 
     * @param b     A boolean flag indicating if the torch is on. 
     */
    public void SetIsBurning(boolean b) {
        isBurning = b;
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
        subjOff.SetPosition(v);
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
        subjOff.SetPosition(x, y);        
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
        subjOff.SetX(i);
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
        subjOff.SetY(i);        
    }       
   
    /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick           The update tick number. 
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
            if(isBurning) {
                subj.MmgDraw(p);
            } else {
                subjOff.MmgDraw(p);
            }
        }
    }
}