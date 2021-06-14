using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase3_CompleteGame
{
    /// <summary>
    /// A class that represents a UI element, the health bar.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/22/2020
    /// </summary>
    public class MdtUiPoints : MdtBase
    {
        /// <summary>
        /// The subject of this UI element.
        /// </summary>
        public MmgBmp subj = null;

        /// <summary>
        /// A bool flag indicating if the associated UI points are done displaying.
        /// </summary>
        public bool isFinished = false;

        /// <summary>
        /// A private variable used in internal methods.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// The current time this object has spent floating.
        /// </summary>
        public long floatTiming = 0;

        /// <summary>
        /// The total time this object can spend floating.
        /// </summary>
        public long floatTimingTotal = 500;

        /// <summary>
        /// The game screen this MdtChar belongs to.
        /// </summary>
        public ScreenGame screen = null;

        /// <summary>
        /// The player that triggered this UI object.
        /// </summary>
        public MdtPlayerType player;

        /// <summary>
        /// A base constructor that takes no arguments and loads object resources automatically.
        /// </summary>
        /// <param name="Subj">The subject image for this UI health bar.</param>
        /// <param name="Player">The player type this UI health bar is associated with.</param>
        /// <param name="Screen">The ScreenGame object this health bar belongs to.</param>
        /// <param name="StartPosition">The start position of the UI points object.</param>
        public MdtUiPoints(MmgBmp Subj, MdtPlayerType Player, ScreenGame Screen, MmgVector2 StartPosition)
        {
            SetSubj(Subj);
            SetMdtType(MdtObjType.UI);
            SetMdtSubType(MdtObjSubType.UI_POINTS);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
            SetScreen(Screen);
            SetPosition(StartPosition);
        }

        /// <summary>
        /// A constructor that allows you to specify the subject of the object.
        /// </summary>
        /// <param name="Subj">The subject of the object.</param>
        public MdtUiPoints(MmgBmp Subj)
        {
            SetSubj(Subj);
            SetMdtType(MdtObjType.UI);
            SetMdtSubType(MdtObjSubType.UI_POINTS);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
        }

        /// <summary>
        /// Gets the player that triggered this UI object.
        /// </summary>
        /// <returns>The player that triggered this UI object.</returns>
        public MdtPlayerType GetPlayer()
        {
            return player;
        }

        /// <summary>
        /// Sets the player that triggered this UI object.
        /// </summary>
        /// <param name="p">The player that triggered this UI object.</param>
        public void SetPlayer(MdtPlayerType p)
        {
            player = p;
        }

        /// <summary>
        /// Gets the game screen this character belongs to.
        /// </summary>
        /// <returns>The game screen this character belongs to.</returns>
        public ScreenGame GetScreen()
        {
            return screen;
        }

        /// <summary>
        /// Sets the game screen this character belongs to.
        /// </summary>
        /// <param name="o">The game screen this character belongs to.</param>
        public void SetScreen(ScreenGame o)
        {
            screen = o;
        }

        /// <summary>
        /// Gets the subject of the object.
        /// </summary>
        /// <returns>The subject of the object.</returns>
        public MmgBmp GetSubj()
        {
            return subj;
        }

        /// <summary>
        /// Sets the subject of the object.
        /// </summary>
        /// <param name="Subj">The subject of the object. </param>
        public void SetSubj(MmgBmp Subj)
        {
            subj = Subj;
        }

        /// <summary>
        /// Gets a bool indicating if this object is done displaying.
        /// </summary>
        /// <returns>A bool indicating if this object is done displaying.</returns>
        public bool GetIsFinished()
        {
            return isFinished;
        }

        /// <summary>
        /// Sets a bool indicating if this object is done displaying.
        /// </summary>
        /// <param name="b">A bool indicating if this object is done displaying.</param>
        public void SetIsFinished(bool b)
        {
            isFinished = b;
        }

        /// <summary>
        /// Gets the time this object has spent floating.
        /// </summary>
        /// <returns>The time this object has spent floating.</returns>
        public long GetFloatTiming()
        {
            return floatTiming;
        }

        /// <summary>
        /// Sets the time this object has spent floating.
        /// </summary>
        /// <param name="f">The time this object has spent floating.</param>
        public void SetFloatTiming(long f)
        {
            floatTiming = f;
        }

        /// <summary>
        /// Gets the total time this object can spend floating.
        /// </summary>
        /// <returns>The total time this object can spend floating.</returns>
        public long GetFloatTimingTotal()
        {
            return floatTimingTotal;
        }

        /// <summary>
        /// Sets the total time this object can spend floating.
        /// </summary>
        /// <param name="f">The total time this object can spend floating.</param>
        public void SetFloatTimingTotal(long f)
        {
            floatTimingTotal = f;
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
        /// <param name="updateTick">The update tick number. </param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;
            if (isVisible == true)
            {
                subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);

                floatTiming += msSinceLastFrame;
                if (floatTiming >= floatTimingTotal)
                {
                    SetIsVisible(false);
                    SetIsFinished(true);
                    screen.RemoveObj(this);
                }
                else
                {
                    SetY(GetY() - MmgHelper.ScaleValue(3));
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