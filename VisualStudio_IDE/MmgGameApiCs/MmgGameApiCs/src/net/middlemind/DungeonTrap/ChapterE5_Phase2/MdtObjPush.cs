using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase2
{
    /// <summary>
    /// A class that represents an MdtObj object that can be pushed..
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtObjPush : MdtObj
    {
        /// <summary>
        /// A bool indicating if the barrel should break on the first collision after being pushed.
        /// </summary>
        public bool breakOnFirst = true;

        /// <summary>
        /// An MmgSprite that represents the break animation for this object.
        /// </summary>
        public MmgSprite subjBreaks = null;

        /// <summary>
        /// A bool flag indicating that the barrel is broken.
        /// </summary>
        public bool isBroken = false;

        /// <summary>
        /// A private variable used in internal methods. 
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// A bool indicating that an object has been pushed.
        /// </summary>
        public bool isBeingPushed = false;

        /// <summary>
        /// An integer indicating the direction the object has been pushed in.
        /// </summary>
        public int pushDir = MmgDir.DIR_NONE;

        /// <summary>
        /// An integer representing the speed used to move a pushed object.
        /// </summary>
        public int pushSpeed = ScreenGame.GetSpeedPerFrame(280);

        /// <summary>
        /// A value indicating which player pushed the object.
        /// </summary>
        public MdtPlayerType pushedBy;

        /// <summary>
        /// A rectangle representing the current size and position of this object.
        /// </summary>
        public MmgRect current = null;

        /// <summary>
        /// The game screen this MdtChar belongs to.
        /// </summary>
        public ScreenGame screen = null;

        /// <summary>
        /// An MdtBase object instance used in determining collisions.
        /// </summary>
        public MdtBase coll = null;

        /// <summary>
        /// A basic class constructor that takes no arguments.
        /// </summary>
        public MdtObjPush()
        {

        }

        /// <summary>
        /// An advanced constructor for the MdtObjPush class that takes arguments for the values of pertinent class fields.
        /// </summary>
        /// <param name="Subj">An MmgBmp object instance used to display the current object.</param>
        /// <param name="SubjBreaks">An MmgSprite object instance used to display the current object's breaking animation.</param>
        /// <param name="ObjType">The object type of the current object.</param>
        /// <param name="ObjSubType">The object sub-type of the current object.</param>
        /// <param name="Screen">The game screen that this object belongs to.</param>
        public MdtObjPush(MmgBmp Subj, MmgSprite SubjBreaks, MdtObjType ObjType, MdtObjSubType ObjSubType, ScreenGame Screen)
            : base(Subj, ObjType, ObjSubType)
        {
            SetScreen(Screen);
            SetSubjBreaks(SubjBreaks);
        }

        /// <summary>
        /// Gets a bool indicating if this object should break on the first collision.
        /// </summary>
        /// <returns>A bool indicating if this object should break on the first collision.</returns>
        public virtual bool GetBreakOnFirst()
        {
            return breakOnFirst;
        }

        /// <summary>
        /// Sets a bool indicating if this object should break on the first collision.
        /// </summary>
        /// <param name="b">A bool indicating if this object should break on the first collision.</param>
        public virtual void SetBreakOnFirst(bool b)
        {
            breakOnFirst = b;
        }

        /// <summary>
        /// Gets an MdtPlayerType value indicating which player type pushed this object.
        /// </summary>
        /// <returns>An MdtPlayerType value indicating which player type pushed this object.</returns>
        public virtual MdtPlayerType GetPushedBy()
        {
            return pushedBy;
        }

        /// <summary>
        /// Sets an MdtPlayerType value indicating which player type pushed this object.
        /// </summary>
        /// <param name="p">An MdtPlayerType value indicating which player type pushed this object.</param>
        public virtual void SetPushedBy(MdtPlayerType p)
        {
            pushedBy = p;
        }

        /// <summary>
        /// Gets the game screen this object belongs to.
        /// </summary>
        /// <returns>The game screen this object belongs to.</returns>
        public virtual ScreenGame GetScreen()
        {
            return screen;
        }

        /// <summary>
        /// Sets the game screen this object belongs to.
        /// </summary>
        /// <param name="o">The game screen this object belongs to.</param>
        public virtual void SetScreen(ScreenGame o)
        {
            screen = o;
        }

        /// <summary>
        /// Gets the direction this object has been pushed in.
        /// </summary>
        /// <returns>The direction this object has been pushed in.</returns>
        public virtual int GetPushDir()
        {
            return pushDir;
        }

        /// <summary>
        /// Sets the direction this object has been pushed in.
        /// </summary>
        /// <param name="i">The direction this object has been pushed in.</param>
        public virtual void SetPushDir(int i)
        {
            pushDir = i;
        }

        /// <summary>
        /// Gets the speed this object moves when pushed.
        /// </summary>
        /// <returns>The speed this object moves when pushed.</returns>
        public virtual int GetPushSpeed()
        {
            return pushSpeed;
        }

        /// <summary>
        /// Sets the speed this object moves when pushed.
        /// </summary>
        /// <param name="i">The speed this object moves when pushed.</param>
        public virtual void SetPushSpeed(int i)
        {
            pushSpeed = i;
        }

        /// <summary>
        /// Gets a bool indicating if this object has been pushed.
        /// </summary>
        /// <returns>A bool indicating if this object has been pushed.</returns>
        public virtual bool GetIsBeingPushed()
        {
            return isBeingPushed;
        }

        /// <summary>
        /// Sets a bool indicating if this object has been pushed.
        /// </summary>
        /// <param name="b">A bool indicating if this object has been pushed.</param>
        public virtual void SetIsBeingPushed(bool b)
        {
            isBeingPushed = b;
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
        /// Gets an MmgSprite that is used to show the object has been broken.
        /// </summary>
        /// <returns>An MmgSprite that is used to show the object has been broken.</returns>
        public virtual MmgSprite GetSubjBreaks()
        {
            return subjBreaks;
        }

        /// <summary>
        /// Sets an MmgSprite that is used to show the object has been broken.
        /// </summary>
        /// <param name="s">An MmgSprite that is used to show the object has been broken.</param>
        public virtual void SetSubjBreaks(MmgSprite s)
        {
            subjBreaks = s;
        }

        /// <summary>
        /// Gets a bool indicating if the object is broken.
        /// </summary>
        /// <returns>A bool indicating if the object is broken.</returns>
        public virtual bool GetIsBroken()
        {
            return isBroken;
        }

        /// <summary>
        /// Sets a bool indicating if the object is broken.
        /// </summary>
        /// <param name="b">A bool indicating if the object is broken.</param>
        public virtual void SetIsBroken(bool b)
        {
            isBroken = b;
        }

        /// <summary>
        /// Sets the position of the object.
        /// </summary>
        /// <param name="v">The position of the object.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subj.SetPosition(v);
            subjBreaks.SetPosition(v.GetX() + (subj.GetWidth() - subjBreaks.GetWidth()) / 2, v.GetY() + (subj.GetHeight() - subjBreaks.GetHeight()) / 2);
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
            subjBreaks.SetPosition(x + (subj.GetWidth() - subjBreaks.GetWidth()) / 2, y + (subj.GetHeight() - subjBreaks.GetHeight()) / 2);
        }

        /// <summary>
        /// Sets the X coordinate of the object's position.
        /// </summary>
        /// <param name="i">The X coordinate of the object.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
            subjBreaks.SetX(i + (subj.GetWidth() - subjBreaks.GetWidth()) / 2);
        }

        /// <summary>
        /// Sets the Y coordinate of the object's position.
        /// </summary>
        /// <param name="i">The Y coordinate of the object.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subj.SetY(i);
            subjBreaks.SetY(i + (subj.GetHeight() - subjBreaks.GetHeight()) / 2);
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
                if (isBroken)
                {
                    subjBreaks.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                    if (subjBreaks.GetFrameIdx() == subjBreaks.GetFrameStop())
                    {
                        screen.UpdateRemoveObj(this, pushedBy);
                    }
                }
                else
                {
                    subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);

                    if (pushDir != MmgDir.DIR_NONE)
                    {
                        current = new MmgRect(subj.GetX(), subj.GetY(), subj.GetY() + subj.GetHeight(), subj.GetX() + subj.GetWidth());
                        if (pushSpeed < 0)
                        {
                            pushSpeed *= -1;
                        }

                        if (isBeingPushed == true)
                        {
                            if (pushDir == MmgDir.DIR_BACK)
                            {
                                if (subj.GetY() - pushSpeed >= ScreenGame.BOARD_TOP)
                                {
                                    current.ShiftRect(0, (pushSpeed * -1));
                                    coll = screen.CanMove(current, this);
                                    if (coll == null)
                                    {
                                        SetY(current.GetTop());
                                    }
                                    else
                                    {
                                        if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }

                                        if (coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            if (breakOnFirst)
                                            {
                                                isBeingPushed = false;
                                                pushDir = MmgDir.DIR_NONE;
                                                isBroken = true;
                                            }
                                            else
                                            {
                                                SetY(current.GetTop());
                                            }
                                        }
                                        else
                                        {
                                            SetY(current.GetTop());
                                        }
                                    }
                                }
                                else
                                {
                                    SetY(ScreenGame.BOARD_TOP);
                                    isBeingPushed = false;
                                    pushDir = MmgDir.DIR_NONE;
                                    isBroken = true;
                                }
                            }
                            else if (pushDir == MmgDir.DIR_FRONT)
                            {
                                if (subj.GetY() + subj.GetHeight() + pushSpeed <= ScreenGame.BOARD_BOTTOM)
                                {
                                    current.ShiftRect(0, (pushSpeed * 1));
                                    coll = screen.CanMove(current, this);
                                    if (coll == null)
                                    {
                                        SetY(current.GetTop());
                                    }
                                    else
                                    {
                                        if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }

                                        if (coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            if (breakOnFirst)
                                            {
                                                isBeingPushed = false;
                                                pushDir = MmgDir.DIR_NONE;
                                                isBroken = true;
                                            }
                                            else
                                            {
                                                SetY(current.GetTop());
                                            }
                                        }
                                        else
                                        {
                                            SetY(current.GetTop());
                                        }
                                    }
                                }
                                else
                                {
                                    SetY(ScreenGame.BOARD_BOTTOM - subj.GetHeight());
                                    isBeingPushed = false;
                                    pushDir = MmgDir.DIR_NONE;
                                    isBroken = true;
                                }
                            }
                            else if (pushDir == MmgDir.DIR_LEFT)
                            {
                                if (subj.GetX() - pushSpeed >= ScreenGame.BOARD_LEFT)
                                {
                                    current.ShiftRect((pushSpeed * -1), 0);
                                    coll = screen.CanMove(current, this);
                                    if (coll == null)
                                    {
                                        SetX(current.GetLeft());
                                    }
                                    else
                                    {
                                        if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }

                                        if (coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            if (breakOnFirst)
                                            {
                                                isBeingPushed = false;
                                                pushDir = MmgDir.DIR_NONE;
                                                isBroken = true;
                                            }
                                            else
                                            {
                                                SetX(current.GetLeft());
                                            }
                                        }
                                        else
                                        {
                                            SetX(current.GetLeft());
                                        }
                                    }
                                }
                                else
                                {
                                    SetX(ScreenGame.BOARD_LEFT);
                                    isBeingPushed = false;
                                    pushDir = MmgDir.DIR_NONE;
                                    isBroken = true;
                                }
                            }
                            else if (pushDir == MmgDir.DIR_RIGHT)
                            {
                                if (subj.GetX() + subj.GetWidth() + pushSpeed <= ScreenGame.BOARD_RIGHT)
                                {
                                    current.ShiftRect((pushSpeed * 1), 0);
                                    coll = screen.CanMove(current, this);
                                    if (coll == null)
                                    {
                                        SetX(current.GetLeft());
                                    }
                                    else
                                    {
                                        if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth() / 2, GetHeight() / 2, pushDir, pushedBy);
                                        }

                                        if (coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            if (breakOnFirst)
                                            {
                                                isBeingPushed = false;
                                                pushDir = MmgDir.DIR_NONE;
                                                isBroken = true;
                                            }
                                            else
                                            {
                                                SetX(current.GetLeft());
                                            }
                                        }
                                        else
                                        {
                                            SetX(current.GetLeft());
                                        }
                                    }
                                }
                                else
                                {
                                    SetX(ScreenGame.BOARD_RIGHT - subj.GetWidth());
                                    isBeingPushed = false;
                                    pushDir = MmgDir.DIR_NONE;
                                    isBroken = true;
                                }
                            }
                        }
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
                if (isBroken)
                {
                    subjBreaks.MmgDraw(p);
                }
                else
                {
                    subj.MmgDraw(p);
                }
            }
        }
    }
}