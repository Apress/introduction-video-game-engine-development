package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteSheet;

/**
 * A class that represents a game item of the type bomb.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItemBomb extends MdtItem {
    
    /**
     * A base constructor that takes no arguments and loads object resources automatically.
     */
    public MdtItemBomb() {
        MmgBmp src = MmgHelper.GetBasicCachedBmp("bomb_anim_spritesheet_lg.png");
        MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);
        MmgSprite subj = new MmgSprite(ssSrc.GetFrames());
        subj.SetMsPerFrame(280);
        SetSubj(subj);
        SetMdtType(MdtObjType.ITEM);
        SetMdtSubType(MdtObjSubType.ITEM_BOMB);
        SetPoints(MdtPointsType.PTS_250);
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());
    }
    
    /**
     * A constructor that allows you to specify the subject of the object.
     * 
     * @param Subj      The subject of the object.
     */
    public MdtItemBomb(MmgSprite Subj) {
        super(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_BOMB, MdtPointsType.PTS_250);
        GetSubj().SetMsPerFrame(280);
    }
    
    /**
     * Gets the subject of the object.
     * 
     * @return      The subject of the object.
     */
    @Override
    public MmgSprite GetSubj() {
        return (MmgSprite)subj;
    }
}