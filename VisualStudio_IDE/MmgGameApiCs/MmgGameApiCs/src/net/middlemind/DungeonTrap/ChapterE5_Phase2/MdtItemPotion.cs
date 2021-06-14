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
    public class MdtItemPotion : MdtItem
    {
        /// <summary>
        /// The type of potion this class represents.
        /// </summary>
        public MdtItemPotionType potionType = MdtItemPotionType.NONE;

        /// <summary>
        /// A basic constructor for the yellow potion class.
        /// </summary>
        /// <param name="Subj">The subject to use for this potion.</param>
        /// <param name="PotionType">The potion type to use for this item.</param>
        /// <param name="Points">The points type to use for this potion.</param>
        public MdtItemPotion(MmgBmp Subj, MdtItemPotionType PotionType, MdtPointsType Points)
            : base(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_POTION, Points)
        {
            SetPotionType(PotionType);
        }

        /// <summary>
        /// Gets the subject of the class.
        /// </summary>
        /// <returns>The subject of the class.</returns>
        public new MmgBmp GetSubj()
        {
            return (MmgBmp)subj;
        }

        /// <summary>
        /// Gets the potion type of this object.
        /// </summary>
        /// <returns>The potion type of this object.</returns>
        public virtual MdtItemPotionType GetPotionType()
        {
            return potionType;
        }

        /// <summary>
        /// Sets the potion type of this object.
        /// </summary>
        /// <param name="PotionType">The potion type of this object.</param>
        public void SetPotionType(MdtItemPotionType PotionType)
        {
            potionType = PotionType;
        }
    }
}