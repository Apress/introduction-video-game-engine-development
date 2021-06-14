using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase3_CompleteGame
{
    /// <summary>
    /// A class that represents a game item of the type bomb.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtItem : MdtBase
    {
        /// <summary>
        /// The sprite animation that is the subject for this object class.
        /// </summary>
        public MmgObj subj = null;

        /// <summary>
        /// An internal variable used in private class methods.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// The points given to the player for interacting with this item. 
        /// </summary>
        public MdtPointsType points = MdtPointsType.PTS_100;

        /// <summary>
        /// A bool indicating if this item can vanish after a few seconds.
        /// </summary>
        public bool canVanish = true;

        /// <summary>
        /// A long that tracks how long the current item has been visible if it can vanish. 
        /// </summary>
        public long displayTime = 0;

        /// <summary>
        /// A long that tracks the total amount of time this item can be displayed before vanishing.
        /// </summary>
        public long displayTimeTotal = 3000;

        /// <summary>
        /// A reference to the game's main screen.
        /// </summary>
        public ScreenGame screen = null;

        /// <summary>
        /// A basic constructor that takes no arguments.
        /// </summary>
        public MdtItem()
        {

        }

        /// <summary>
        /// A constructor that allows you to specify values for pertinent class fields.
        /// </summary>
        /// <param name="Subj">The MmgObj to use as the subject for this class.</param>
        /// <param name="ObjType">The type of item this class represents.</param>
        /// <param name="ObjSubType">The sub-type of item this class represents.</param>
        /// <param name="Points">The amount of points this item is worth.</param>
        public MdtItem(MmgObj Subj, MdtObjType ObjType, MdtObjSubType ObjSubType, MdtPointsType Points)
        {
            SetSubj(Subj);
            SetMdtType(ObjType);
            SetMdtSubType(ObjSubType);
            SetPoints(Points);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
            SetDisplayTimeTotal((MmgHelper.GetRandomIntRange(3, 8) * 1000));
        }

        /// <summary>
        /// Gets the game screen this character belongs to.
        /// </summary>
        /// <returns>The game screen this character belongs to.</returns>
        public virtual ScreenGame GetScreen()
        {
            return screen;
        }

        /// <summary>
        /// Sets the game screen this character belongs to.
        /// </summary>
        /// <param name="o">The game screen this character belongs to.</param>
        public virtual void SetScreen(ScreenGame o)
        {
            screen = o;
        }

        /// <summary>
        /// Gets a bool that indicates if the current item can vanish.
        /// </summary>
        /// <returns>A bool indicating if this item can vanish.</returns>
        public virtual bool GetCanVanish()
        {
            return canVanish;
        }

        /// <summary>
        /// Sets a bool that indicates if the current item can vanish.
        /// </summary>
        /// <param name="b">A bool indicating if this item can vanish.</param>
        public virtual void SetCanVanish(bool b)
        {
            canVanish = b;
        }

        /// <summary>
        /// Gets a value indicating the current display time for this item that can vanish.
        /// </summary>
        /// <returns>The current display time for this item if it can vanish.</returns>
        public virtual long GetDisplayTime()
        {
            return displayTime;
        }

        /// <summary>
        /// Sets a value indicating the current display time for this item that can vanish.
        /// </summary>
        /// <param name="l">The current display time for this item if it can vanish.</param>
        public virtual void SetDisplayTime(long l)
        {
            displayTime = l;
        }

        /// <summary>
        /// Gets a value indicating the total display time for this item that can vanish.
        /// </summary>
        /// <returns>The total display time for this item if it can vanish.</returns>
        public virtual long GetDisplayTimeTotal()
        {
            return displayTimeTotal;
        }

        /// <summary>
        /// Sets  a value indicating the total display time for this item that can vanish.
        /// </summary>
        /// <param name="l">The total display time for this item if it can vanish.</param>
        public virtual void SetDisplayTimeTotal(long l)
        {
            displayTimeTotal = l;
        }

        /// <summary>
        /// Sets the points given to a player for interacting with this item.
        /// </summary>
        /// <param name="i">The points given to a player for interacting with this item.</param>
        public virtual void SetPoints(MdtPointsType i)
        {
            points = i;
        }

        /// <summary>
        /// Gets the points given to a player for interacting with this item.
        /// </summary>
        /// <returns>The points given to a player for interacting with this item.</returns>
        public virtual MdtPointsType GetPoints()
        {
            return points;
        }

        /// <summary>
        /// Gets the subject of the object.
        /// </summary>
        /// <returns>The subject of the object.</returns>
        public virtual MmgObj GetSubj()
        {
            return subj;
        }

        /// <summary>
        /// Sets the subject of the object.
        /// </summary>
        /// <param name="Subj">The subject of the object.</param>
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
        /// Sets the X coordinate of the object.
        /// </summary>
        /// <param name="i">The X coordinate of the object.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
        }

        /// <summary>
        /// Sets the Y coordinate of the object.
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
                if (screen != null && canVanish)
                {
                    displayTime += msSinceLastFrame;
                    if (displayTime >= displayTimeTotal)
                    {
                        screen.RemoveObj(this);
                    }
                }
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