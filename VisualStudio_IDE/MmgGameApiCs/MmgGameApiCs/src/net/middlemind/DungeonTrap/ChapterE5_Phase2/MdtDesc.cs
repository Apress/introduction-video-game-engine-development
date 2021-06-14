using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase2
{
    /// <summary>
    /// The interface for the MdtObj class.
    /// Should be the super class of all Mmg Dungeon Trap game classes.
    /// 
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public interface MdtDesc
    {
        /// <summary>
        /// Gets the type of this MdtObj instance.
        /// </summary>
        /// <returns>The type of this MdtObj instance.</returns>
        public MdtObjType GetMdtType();

        /// <summary>
        /// Sets the type of this MdtObj instance.
        /// </summary>
        /// <param name="obj">The type of this MdtObj instance.</param>
        public void SetMdtType(MdtObjType obj);

        /// <summary>
        /// Gets the sub type of the MdtObj instance.
        /// </summary>
        /// <returns>The sub type of the MdtObj instance.</returns>
        public MdtObjSubType GetMdtSubType();

        /// <summary>
        /// Sets the sub type of the MdtObj instance.
        /// </summary>
        /// <param name="obj">The sub type of the MdtObj instance.</param>
        public void SetMdtSubType(MdtObjSubType obj);

        /// <summary>
        /// Gets a rectangle representation of this MdtObj object instance.
        /// </summary>
        /// <returns>A rectangle representation of this MdtObj object instance.</returns>
        public MmgRect GetRect();
    }
}