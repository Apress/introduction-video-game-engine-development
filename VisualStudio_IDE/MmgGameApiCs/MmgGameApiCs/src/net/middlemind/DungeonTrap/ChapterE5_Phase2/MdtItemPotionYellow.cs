using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase2
{
    /// <summary>
    /// A class that represents a yellow potion.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtItemPotionYellow : MdtItemPotion
    {
        /// <summary>
        /// A basic constructor for the yellow potion class.
        /// </summary>
        public MdtItemPotionYellow()
            : base(MmgHelper.GetBasicCachedBmp("potion_yellow_lg.png"), MdtItemPotionType.YELLOW, MdtPointsType.PTS_100)
        {
        }

        /// <summary>
        /// A constructor for the yellow potion class that let's you specify the subject as an argument.
        /// </summary>
        /// <param name="Subj">The subject of the class.</param>
        public MdtItemPotionYellow(MmgBmp Subj)
            : base(Subj, MdtItemPotionType.YELLOW, MdtPointsType.PTS_100)
        {
        }
    }
}