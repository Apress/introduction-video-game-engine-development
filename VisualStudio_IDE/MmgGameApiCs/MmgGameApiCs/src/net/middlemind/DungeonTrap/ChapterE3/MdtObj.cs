using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE3
{
    /// <summary>
    /// A class that represents a game object.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtObj : MdtBase
    {
        /// <summary>
        /// The subject of the class.
        /// </summary>
        public MmgObj subj = null;

        /// <summary>
        /// A private variable used in internal methods.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// A generic constructor for this class.
        /// </summary>
        public MdtObj()
        {

        }

        /// <summary>
        /// A complex constructor that takes arguments for configuring pertinent class fields.
        /// </summary>
        /// <param name="Subj">The subject of this object.</param>
        /// <param name="ObjType">The type of this object.</param>
        /// <param name="ObjSubType">The sub-type of this object.</param>
        public MdtObj(MmgObj Subj, MdtObjType ObjType, MdtObjSubType ObjSubType)
        {
            SetSubj(Subj);
            SetMdtType(ObjType);
            SetMdtSubType(ObjSubType);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
        }

        /// <summary>
        /// Gets the subject of the class.
        /// </summary>
        /// <returns>The subject of the class.</returns>
        public virtual MmgObj GetSubj()
        {
            return subj;
        }

        /// <summary>
        /// Sets the subject of the class.
        /// </summary>
        /// <param name="Subj">The subject of the class.</param>
        public virtual void SetSubj(MmgObj Subj)
        {
            subj = Subj;
        }

        /// <summary>
        /// Sets the position of the object.
        /// </summary>
        /// <param name="v">The position of the object.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subj.SetPosition(v);
        }

        /// <summary>
        /// Sets the position of the object.
        /// </summary>
        /// <param name="x">The X coordinate of the object.</param>
        /// <param name="y">The Y coordinate of the object.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            subj.SetPosition(x, y);
        }

        /// <summary>
        /// Sets the X coordinate of the object's position.
        /// </summary>
        /// <param name="i">The X coordinate of the object.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
        }

        /// <summary>
        /// Sets the Y coordinate of the object's position.
        /// </summary>
        /// <param name="i">The Y coordinate of the object.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subj.SetY(i);
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;
            if (isVisible == true)
            {
                subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                lret = true;
            }
            return lret;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                subj.MmgDraw(p);
            }
        }
    }
}