using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE4_DemoScreen
{
    /// <summary>
    /// A class that represents a purse full of coins.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtItemCoinBag : MdtItem
    {
        /// <summary>
        /// A basic constructor for the coin bag class.
        /// </summary>
        public MdtItemCoinBag()
            : base(MmgBmpScaler.ScaleMmgBmp(MmgHelper.GetBasicCachedBmp("bag_coins_lg.png"), 1.5d, true), MdtObjType.ITEM, MdtObjSubType.ITEM_COINS, MdtPointsType.PTS_1000)
        {
        }

        /// <summary>
        /// A constructor for the coin bag class that lets you specify the subject as an argument.
        /// </summary>
        /// <param name="Subj">The subject of the class.</param>
        public MdtItemCoinBag(MmgBmp Subj)
            : base(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_COINS, MdtPointsType.PTS_1000)
        {
        }
    }
}