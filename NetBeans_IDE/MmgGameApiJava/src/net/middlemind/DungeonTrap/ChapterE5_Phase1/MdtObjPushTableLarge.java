package net.middlemind.DungeonTrap.ChapterE5_Phase1;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteSheet;

/**
 * A class that represents a large table.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtObjPushTableLarge extends MdtObjPush {

    /**
     * A basic constructor for the large table class.
     * 
     * @param Screen        The game's ScreenGame class.
     */
    public MdtObjPushTableLarge(ScreenGame Screen) {
        SetSubj(MmgHelper.GetBasicCachedBmp("table_2_lg.png"));
        SetMdtType(MdtObjType.OBJECT);
        SetMdtSubType(MdtObjSubType.OBJECT_TABLE_1);
        SetScreen(Screen);        
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());
        SetPushSpeed(ScreenGame.GetSpeedPerFrame(250));
        
        MmgBmp src = MmgHelper.GetBasicCachedBmp("explosion_anim_spritesheet_lg.png");
        MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);        
        subjBreaks = new MmgSprite(ssSrc.GetFrames());
        subjBreaks.SetMsPerFrame(50);        
    }
    
    /**
     * A constructor for the large table class that let's you specify the subject.
     * 
     * @param Subj          The subject of the class. 
     * @param SubjBreaks    The subject break animation.
     * @param Screen        The game's ScreenGame class.  
     */
    public MdtObjPushTableLarge(MmgBmp Subj, MmgSprite SubjBreaks, ScreenGame Screen) {
        super(Subj, SubjBreaks, MdtObjType.OBJECT, MdtObjSubType.OBJECT_TABLE_1, Screen);
        SetPushSpeed(ScreenGame.GetSpeedPerFrame(250));
    }
}