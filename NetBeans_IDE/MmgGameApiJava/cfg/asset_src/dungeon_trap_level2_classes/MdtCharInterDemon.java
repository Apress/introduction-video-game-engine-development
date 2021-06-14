package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;

/**
 * A class that represents an enemy demon.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtCharInterDemon extends MdtCharInter {
    
    /**
     * MdtEnemyDemon constructor that allows you to specify the sprite animation frames for this character, for all directions.
     * 
     * @param Subj              The subject of the object instance.
     * @param FrameFrontS       The front start frame.
     * @param FrameFrontE       The front end frame.
     * @param FrameBackS        The back start frame.
     * @param FrameBackE        The back end frame.
     * @param FrameLeftS        The left start frame.
     * @param FrameLeftE        The left end frame.
     * @param FrameRightS       The right start frame.
     * @param FrameRightE       The right end frame.
     * @param Screen            The game screen this character is on.
     */
    public MdtCharInterDemon(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen) {
        super(Subj, FrameFrontS, FrameFrontE, FrameBackS, FrameBackE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, Screen, MdtObjType.ENEMY, MdtObjSubType.ENEMY_DEMON);
        SetPlayerType(MdtPlayerType.ENEMY);
        SetHealthMax(2);
        SetHealthCurrent(2);
        weaponCurrent.SetPlayer(GetPlayerType());
        SetMotor(MdtEnemyMotorType.NONE);
        SetSpeed(ScreenGame.GetSpeedPerFrame(40));
    }
}