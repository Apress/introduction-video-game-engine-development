package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteSheet;

/**
 * A class that represents a barrel.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtObjPushBarrel extends MdtObjPush {
       
    /**
     * A basic constructor for the barrel class.
     * 
     * @param Screen        The game's ScreenGame class.
     */
    public MdtObjPushBarrel(ScreenGame Screen) {
        SetSubj(MmgHelper.GetBasicCachedBmp("barrel_lg.png"));
        SetMdtType(MdtObjType.OBJECT);
        SetMdtSubType(MdtObjSubType.OBJECT_BARREL);
        SetScreen(Screen);        
        SetWidth(subj.GetWidth());
        SetHeight(subj.GetHeight());
        SetPushSpeed(ScreenGame.GetSpeedPerFrame(280));
        
        MmgBmp src = MmgHelper.GetBasicCachedBmp("explosion_anim_spritesheet_lg.png");
        MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);        
        subjBreaks = new MmgSprite(ssSrc.GetFrames());
        subjBreaks.SetMsPerFrame(50);        
    }
    
    /**
     * A constructor for the barrel class that let's you specify the subject.
     * 
     * @param Subj          The subject of the class. 
     * @param SubjBreaks    The subject break animation.
     * @param Screen        The game's ScreenGame class.
     */
    public MdtObjPushBarrel(MmgBmp Subj, MmgSprite SubjBreaks, ScreenGame Screen) {
        super(Subj, SubjBreaks, MdtObjType.OBJECT, MdtObjSubType.OBJECT_BARREL, Screen);
        SetPushSpeed(ScreenGame.GetSpeedPerFrame(280));
    }   
}