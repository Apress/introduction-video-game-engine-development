package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteSheet;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents a treasure chest.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItemChest extends MdtItem {
    
    /**
     * The image used to show that the treasure chest is open.
     */
    public MmgBmp subjOpen = null;
    
    /**
     * A boolean flag indicating that the treasure chest is still closed.
     */
    public boolean isClosed = true;
 
    /**
     * A private variable used in internal methods.
     */
    private boolean lret = false;    
    
    /**
     * The object that is contained inside the chest.
     */
    public MdtBase treasureInside = null;
    
    /**
     * A basic constructor for the treasure chest class.
     */
    public MdtItemChest() {
        MmgBmp src = MmgHelper.GetBasicCachedBmp("chest_spritesheet_lg.png");
        MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);
        MmgSprite subj = new MmgSprite(ssSrc.GetFrames());
        subj.SetMsPerFrame(280);
        SetSubj(subj);
        SetMdtType(MdtObjType.ITEM);
        SetMdtSubType(MdtObjSubType.ITEM_CHEST);        
        SetSubjOpen(MmgHelper.GetBasicCachedBmp("chest_open_lg.png"));
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());
    }
    
    /**
     * A constructor for the treasure chest class that takes a subject and an open chest image as arguments.
     * 
     * @param Subj      The subject of this treasure chest class.
     * @param Open      The open image of this treasure chest class.
     */
    public MdtItemChest(MmgSprite Subj, MmgBmp Open) {
        super(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_CHEST, MdtPointsType.PTS_100);
        GetSubj().SetMsPerFrame(280);
        SetSubjOpen(Open);
    }    

    /**
     * Gets the object that is inside the treasure chest.
     * 
     * @return      The object that is inside the treasure chest.
     */
    public MdtBase GetTreasureInside() {
        return treasureInside;
    }

    /**
     * Sets the object that is inside the treasure chest.
     * 
     * @param obj       The object that is inside the treasure chest. 
     */
    public void SetTreasureInside(MdtBase obj) {
        treasureInside = obj;
    }
   
    /**
     * Gets the subject of this treasure chest class.
     * 
     * @return      The subject of this treasure chest class. 
     */
    @Override
    public MmgSprite GetSubj() {
        return (MmgSprite)subj;
    }

    /**
     * Gets the image used to display an open treasure chest.
     * 
     * @return      The image used to display an open treasure chest. 
     */
    public MmgBmp GetSubjOpen() {
        return subjOpen;
    }

    /**
     * Sets the image used to display an open treasure chest.
     * 
     * @param Open      The image used to display an open treasure chest. 
     */
    public void SetSubjOpen(MmgBmp Open) {
        subjOpen = Open;
    }

    /**
     * Gets a boolean flag indicating that the treasure chest is closed.
     * 
     * @return      A boolean flag indicating if the treasure chest is open or closed.
     */
    public boolean GetIsClosed() {
        return isClosed;
    }

    /**
     * Sets a boolean flag indicating that the treasure chest is closed.
     * 
     * @param b     A boolean flag indicating if the treasure chest is open or closed. 
     */
    public void SetIsClosed(boolean b) {
        isClosed = b;
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
        subjOpen.SetPosition(v);
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
        subjOpen.SetPosition(x, y);
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
        subjOpen.SetX(i);        
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
        subjOpen.SetY(i);
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
            if(isClosed) {
                subj.MmgDraw(p);
            } else {
                subjOpen.MmgDraw(p);
            }
        }
    }    
}