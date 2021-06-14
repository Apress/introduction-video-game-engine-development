using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE4
{
    /// <summary>
    /// A class that represents an enemy demon.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtCharInterDemon : MdtCharInter
    {
        /// <summary>
        /// MdtEnemyDemon constructor that allows you to specify the sprite animation frames for this character, for all directions.
        /// </summary>
        /// <param name="Subj">The subject of the object instance.</param>
        /// <param name="FrameFrontS">The front start frame.</param>
        /// <param name="FrameFrontE">The front end frame.</param>
        /// <param name="FrameBackS">The back start frame.</param>
        /// <param name="FrameBackE">The back end frame.</param>
        /// <param name="FrameLeftS">The left start frame.</param>
        /// <param name="FrameLeftE">The left end frame.</param>
        /// <param name="FrameRightS">The right start frame.</param>
        /// <param name="FrameRightE">The right end frame.</param>
        /// <param name="Screen">The game screen this character is on.</param>
        public MdtCharInterDemon(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen)
            : base(Subj, FrameFrontS, FrameFrontE, FrameBackS, FrameBackE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, Screen, MdtObjType.ENEMY, MdtObjSubType.ENEMY_DEMON)
        {
            SetPlayerType(MdtPlayerType.ENEMY);
            SetHealthMax(2);
            SetHealthCurrent(2);
            weaponCurrent.SetPlayer(GetPlayerType());
            SetMotor(MdtEnemyMotorType.NONE);
            SetSpeed(ScreenGame.GetSpeedPerFrame(40));
        }
    }
}