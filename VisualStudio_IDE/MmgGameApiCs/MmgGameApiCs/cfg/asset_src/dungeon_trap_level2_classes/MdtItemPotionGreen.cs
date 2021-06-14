using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace game.jam.DungeonTrap
{
    /// <summary>
    /// A class that represents a green potion, full health.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtItemPotionGreen : MdtItemPotion
    {
        /// <summary>
        /// A basic constructor for the green potion class.
        /// </summary>
        public MdtItemPotionGreen()
            : base(MmgHelper.GetBasicCachedBmp("potion_green_lg.png"), MdtItemPotionType.GREEN, MdtPointsType.PTS_100)
        {
        }

        /// <summary>
        /// A constructor for the green potion class that let's you specify the subject as an argument.
        /// </summary>
        /// <param name="Subj">The subject of the class.</param>
        public MdtItemPotionGreen(MmgBmp Subj)
            : base(Subj, MdtItemPotionType.GREEN, MdtPointsType.PTS_100)
        {
        }
    }
}