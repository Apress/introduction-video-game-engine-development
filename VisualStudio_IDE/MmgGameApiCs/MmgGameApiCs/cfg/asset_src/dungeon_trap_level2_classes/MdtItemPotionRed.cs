using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace game.jam.DungeonTrap
{
    /// <summary>
    /// A class that represents a red potion.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtItemPotionRed : MdtItemPotion
    {
        /// <summary>
        /// A basic constructor for the red potion class.
        /// </summary>
        public MdtItemPotionRed()
            : base(MmgHelper.GetBasicCachedBmp("potion_red_lg.png"), MdtItemPotionType.RED, MdtPointsType.PTS_100)
        {
        }

        /// <summary>
        /// A constructor for the red potion class that let's you specify the subject as an argument.
        /// </summary>
        /// <param name="Subj">The subject of the class.</param>
        public MdtItemPotionRed(MmgBmp Subj)
            : base(Subj, MdtItemPotionType.RED, MdtPointsType.PTS_100)
        {
        }
    }
}