using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace game.jam.DungeonTrap
{
    /// <summary>
    /// A class that represents a game item of the type bomb.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtItemBomb : MdtItem
    {
        /// <summary>
        /// A base constructor that takes no arguments and loads object resources automatically.
        /// </summary>
        public MdtItemBomb()
        {
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

        /// <summary>
        /// A constructor that allows you to specify the subject of the object.
        /// </summary>
        /// <param name="Subj">The subject of the object.</param>
        public MdtItemBomb(MmgSprite Subj)
        : base(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_BOMB, MdtPointsType.PTS_250)
        {
            GetSubj().SetMsPerFrame(280);
        }

        /// <summary>
        /// Gets the subject of the object.
        /// </summary>
        /// <returns>The subject of the object.</returns>
        public new MmgSprite GetSubj()
        {
            return (MmgSprite)subj;
        }
    }
}