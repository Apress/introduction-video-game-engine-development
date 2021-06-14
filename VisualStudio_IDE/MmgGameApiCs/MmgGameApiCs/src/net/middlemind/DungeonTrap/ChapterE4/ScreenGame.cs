using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.DungeonTrap.ChapterE4
{
    /// <summary>
    /// A game screen object, ScreenGame, that extends the MmgGameScreen base
    /// class. This class is for testing new UI widgets, etc.
    ///
    /// @author Victor G.Brusca
    /// 03/15/2020
    /// </summary>
    public class ScreenGame
    {
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

        public static int GetSpeedPerFrame(int speed)
        {
            return (int)(speed / (DungeonTrap.FPS - 4));
        }

        public void RemoveObj(MmgObj obj)
        {
        }

        public void UpdateRemoveObj(MdtBase obj, MdtPlayerType p)
        {
        }

        public MdtBase CanMove(MmgRect r, MdtBase iO)
        {
            return null;
        }

        public void UpdateProcessCollision(MdtBase o1, MdtBase o2)
        {
        }

        public void UpdateProcessWeaponCollision(MdtBase o1, MdtBase o2, MmgRect weapon)
        {
        }

        public void UpdateClearPlayerMod(MdtPlayerType p)
        {
        }

        public MdtBase UpdateGenerateItem(int x, int y)
        {
            return null;
        }

        public GameType GetGameType()
        {
            return GameType.GAME_TWO_PLAYER;
        }

        public MmgVector2 GetPlayer1Pos()
        {
            return null;
        }

        public bool GetPlayer1Broken()
        {
            return false;
        }

        public MmgVector2 GetPlayer2Pos()
        {
            return null;
        }

        public bool GetPlayer2Broken()
        {
            return false;
        }
    }
}