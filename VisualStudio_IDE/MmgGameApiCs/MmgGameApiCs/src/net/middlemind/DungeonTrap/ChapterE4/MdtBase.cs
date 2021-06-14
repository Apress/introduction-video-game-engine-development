using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE4
{
    /// <summary>
    /// An MdtBase object that extends the MmgObj class and implements the MdtDesc interface.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtBase : MmgObj, MdtDesc
    {
        /// <summary>
        /// The type of this MdtObj instance.
        /// </summary>
        private MdtObjType mdtType = MdtObjType.NONE;

        /// <summary>
        /// The sub type of this MdtObj instance.
        /// </summary>
        private MdtObjSubType mdtSubType = MdtObjSubType.NONE;

        /// <summary>
        /// A generic constructor that takes no arguments.
        /// </summary>
        public MdtBase()
        {

        }

        /// <summary>
        /// Gets the type of this MdtObj instance.
        /// </summary>
        /// <returns>The type of this MdtObj instance.</returns>
        public virtual MdtObjType GetMdtType()
        {
            return mdtType;
        }

        /// <summary>
        /// Sets the type of this MdtObj instance.
        /// </summary>
        /// <param name="obj">The type of this MdtObj instance. </param>
        public virtual void SetMdtType(MdtObjType obj)
        {
            mdtType = obj;
        }

        /// <summary>
        /// Gets the sub type of the MdtObj instance.
        /// </summary>
        /// <returns>The sub type of the MdtObj instance.</returns>
        public virtual MdtObjSubType GetMdtSubType()
        {
            return mdtSubType;
        }

        /// <summary>
        /// Sets the sub type of the MdtObj instance.
        /// </summary>
        /// <param name="obj">The sub type of the MdtObj instance.</param>
        public virtual void SetMdtSubType(MdtObjSubType obj)
        {
            mdtSubType = obj;
        }

        /// <summary>
        /// Gets a rectangle representation of this MdtObj object instance.
        /// </summary>
        /// <returns>A rectangle representation of this MdtObj object instance.</returns>
        public virtual MmgRect GetRect()
        {
            return new MmgRect(GetPosition(), GetWidth(), GetHeight());
        }
    }
}