package net.middlemind.DungeonTrap.ChapterE3;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;

/**
 * A game screen object, ScreenGame, that extends the MmgGameScreen base
 * class. This class is for testing new UI widgets, etc.
 *
 * @author Victor G. Brusca
 * 03/15/2020
 */
public class ScreenGame {
 
    public static int GAME_TOP = MmgScreenData.GetGameTop();
    public static int BOARD_TOP = GAME_TOP + MmgHelper.ScaleValue(106);    
    public static int GAME_BOTTOM = MmgScreenData.GetGameBottom();
    public static int BOARD_BOTTOM = GAME_BOTTOM - MmgHelper.ScaleValue(56);    
    public static int GAME_LEFT = MmgScreenData.GetGameLeft();
    public static int BOARD_LEFT = GAME_LEFT + MmgHelper.ScaleValue(20);
    public static int GAME_RIGHT = MmgScreenData.GetGameRight();
    public static int BOARD_RIGHT = GAME_RIGHT - MmgHelper.ScaleValue(132);    
    public static int GAME_WIDTH = GAME_RIGHT - GAME_LEFT;   
    public static int BOARD_WIDTH = BOARD_RIGHT - BOARD_LEFT;
    public static int GAME_HEIGHT = GAME_BOTTOM - GAME_TOP;
    public static int BOARD_HEIGHT = BOARD_BOTTOM - BOARD_TOP;     
    
    public static int GetSpeedPerFrame(int speed) {
        return (int)(speed/(DungeonTrap.FPS - 4));        
    }
    
    public void RemoveObj(MmgObj obj) {
    }
    
    public void UpdateRemoveObj(MdtBase obj, MdtPlayerType p) {
    }
    
    public MdtBase CanMove(MmgRect r, MdtBase iO) {
        return null;
    }
    
    public void UpdateProcessCollision(MdtBase o1, MdtBase o2) {
    }
    
    public void UpdateProcessWeaponCollision(MdtBase o1, MdtBase o2, MmgRect weapon) {
    }
    
    public void UpdateClearPlayerMod(MdtPlayerType p) {
    }
}