using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that provides tween support to an underlying MmgObj instance.
    /// Created by Middlemind Games 12/01/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgPositionTween : MmgObj
    {
        /// <summary>
        /// The event id for a position tween finish event.
        /// </summary>
        public static int MMG_POSITION_TWEEN_REACH_FINISH = 0;

        /// <summary>
        /// The event id for a position tween start event.
        /// </summary>
        public static int MMG_POSITION_TWEEN_REACH_START = 1;

        /// <summary>
        /// The event type for a position tween finish event.
        /// </summary>
        public static int MMG_POSITION_TWEEN_REACH_FINISH_TYPE = 0;

        /// <summary>
        /// The event type for a position tween start event.
        /// </summary>
        public static int MMG_POSITION_TWEEN_REACH_START_TYPE = 1;

        /// <summary>
        /// The subject of this position tween.
        /// </summary>
        private MmgObj subj;

        /// <summary>
        /// A bool indicating the tween is at the start position.
        /// </summary>
        private bool atStart;

        /// <summary>
        /// A bool indicating the tween is at the finish position.
        /// </summary>
        private bool atFinish;

        /// <summary>
        /// An MmgVector2 that holds the distance to move in X, Y values.
        /// </summary>
        private MmgVector2 pixelDistToMove;

        /// <summary>
        /// A float indicating the time in milliseconds to move the specified distance.
        /// </summary>
        private float msTimeToMove;

        /// <summary>
        /// The pixels per millisecond to move in the X direction.
        /// </summary>
        private float pixelsPerMsToMoveX;

        /// <summary>
        /// The pixels per millisecond to move in the Y direction.
        /// </summary>
        private float pixelsPerMsToMoveY;

        /// <summary>
        /// An MmgVector2 that holds the start position.
        /// </summary>
        private MmgVector2 startPosition;

        /// <summary>
        /// An MmgVector2 that holds the finish position.
        /// </summary>
        private MmgVector2 finishPosition;

        /// <summary>
        /// A bool indicating the direction to move, start to finish or finish to start.
        /// </summary>
        private bool dirStartToFinish;

        /// <summary>
        /// A bool indicating if the object is moving.
        /// </summary>
        private bool moving;

        /// <summary>
        /// A long value that that indicates when the movement began.
        /// </summary>
        private long msStartMove;

        /// <summary>
        /// A temporary class field used to calculate a new MmgVector2 with position information.
        /// </summary>
        private MmgVector2 tmpV;

        /// <summary>
        /// An event handler for the reach finish event.
        /// </summary>
        private MmgEventHandler onReachFinish;

        /// <summary>
        /// An event handler for the reach start event.
        /// </summary>
        private MmgEventHandler onReachStart;

        /// <summary>
        /// An event template for the reach finish event.
        /// </summary>
        private MmgEvent reachFinish = new MmgEvent(null, "reach_finish", MmgPositionTween.MMG_POSITION_TWEEN_REACH_FINISH, MmgPositionTween.MMG_POSITION_TWEEN_REACH_FINISH_TYPE, null, null);

        /// <summary>
        /// An event template for the reach start event.
        /// </summary>
        private MmgEvent reachStart = new MmgEvent(null, "reach_start", MmgPositionTween.MMG_POSITION_TWEEN_REACH_START, MmgPositionTween.MMG_POSITION_TWEEN_REACH_START_TYPE, null, null);

        /// <summary>
        /// A private bool flag for the MmgUpdate method indicating if any work was done.
        /// </summary>
        private bool lret;

        /// <summary>
        /// A basic constructor for the MmgPositionTween object.
        /// </summary>
        /// <param name="subj">The MmgObj that is the subject of the tween.</param>
        /// <param name="msTimeToMove">The number of milliseconds to move the object.</param>
        /// <param name="startPos">The start position of the tween.</param>
        /// <param name="finishPos">The finish position of the tween.</param>
        public MmgPositionTween(MmgObj subj, float msTimeToMove, MmgVector2 startPos, MmgVector2 finishPos) : base()
        {
            SetSubj(subj);
            SetPixelDistToMove(new MmgVector2((finishPos.GetX() - startPos.GetX()), (finishPos.GetY() - startPos.GetY())));
            SetMsTimeToMove(msTimeToMove);
            SetPixelsPerMsToMoveX((GetPixelDistToMove().GetX() / (float)msTimeToMove));
            SetPixelsPerMsToMoveY((GetPixelDistToMove().GetY() / (float)msTimeToMove));
            SetStartPosition(startPos);
            SetFinishPosition(finishPos);
            SetPosition(startPos);
            SetDirStartToFinish(true);
            SetAtStart(true);
            SetAtFinish(false);
            SetMoving(false);
        }

        /// <summary>
        /// A constructor that is based on the an instance of the MmgPositionTween object.
        /// </summary>
        /// <param name="obj">An MmgPositionTween object used to create an new instance of the MmgPositionTween class.</param>
        public MmgPositionTween(MmgPositionTween obj) : base()
        {
            if (obj.GetSubj() == null)
            {
                SetSubj(obj.GetSubj());
            }
            else
            {
                SetSubj(obj.GetSubj().Clone());
            }

            SetAtStart(obj.GetAtStart());
            SetAtFinish(obj.GetAtFinish());

            if (obj.GetPixelDistToMove() == null)
            {
                SetPixelDistToMove(obj.GetPixelDistToMove());
            }
            else
            {
                SetPixelDistToMove(obj.GetPixelDistToMove().Clone());
            }

            SetMsTimeToMove(obj.GetMsTimeToMove());
            SetPixelsPerMsToMoveX(obj.GetPixelsPerMsToMoveX());
            SetPixelsPerMsToMoveY(obj.GetPixelsPerMsToMoveY());

            if (obj.GetStartPosition() == null)
            {
                SetStartPosition(obj.GetStartPosition());
            }
            else
            {
                SetStartPosition(obj.GetStartPosition().Clone());
            }

            if (obj.GetFinishPosition() == null)
            {
                SetFinishPosition(obj.GetFinishPosition());
            }
            else
            {
                SetFinishPosition(obj.GetFinishPosition().Clone());
            }

            SetDirStartToFinish(obj.GetDirStartToFinish());
            SetMoving(obj.GetMoving());
            SetMsStartMove(obj.GetMsStartMove());
            SetOnReachStart(obj.GetOnReachStart());
            SetOnReachFinish(obj.GetOnReachFinish());
        }

        /// <summary>
        /// Sets the finish event id.
        /// </summary>
        /// <param name="i">The finish event id.</param>
        public virtual void SetFinishEventId(int i)
        {
            reachFinish.SetEventId(i);
        }

        /// <summary>
        /// Gets the finish event id.
        /// </summary>
        /// <returns>The finish event id.</returns>
        public virtual int GetFinishEventId()
        {
            return reachFinish.GetEventId();
        }

        /// <summary>
        /// Sets the start event id.
        /// </summary>
        /// <param name="i">The start event id.</param>
        public virtual void SetStartEventId(int i)
        {
            reachStart.SetEventId(i);
        }

        /// <summary>
        /// Gets the finish event id.
        /// </summary>
        /// <returns>The finish event id.</returns>
        public virtual int GetStartEventId()
        {
            return reachStart.GetEventId();
        }

        /// <summary>
        /// Gets the on reach finish event handler.
        /// </summary>
        /// <returns>The on reach finish event handler.</returns>
        public virtual MmgEventHandler GetOnReachFinish()
        {
            return onReachFinish;
        }

        /// <summary>
        /// Sets the on reach finish event handler.
        /// </summary>
        /// <param name="o">The on reach finish event handler.</param>
        public virtual void SetOnReachFinish(MmgEventHandler o)
        {
            onReachFinish = o;
        }

        /// <summary>
        /// Gets the on reach start event handler.
        /// </summary>
        /// <returns>The on reach start event handler.</returns>
        public virtual MmgEventHandler GetOnReachStart()
        {
            return onReachStart;
        }

        /// <summary>
        /// Sets the on reach start event handler.
        /// </summary>
        /// <param name="o">The on reach start event handler.</param>
        public virtual void SetOnReachStart(MmgEventHandler o)
        {
            onReachStart = o;
        }

        /// <summary>
        /// Gets the milliseconds to wait before starting the movement.
        /// </summary>
        /// <returns>The milliseconds to wait before starting the movement.</returns>
        public virtual long GetMsStartMove()
        {
            return msStartMove;
        }

        /// <summary>
        /// Sets the milliseconds to wait before starting the movement.
        /// </summary>
        /// <param name="l">The milliseconds to wait before starting the movement.</param>
        public virtual void SetMsStartMove(long l)
        {
            msStartMove = l;
        }

        /// <summary>
        /// Gets the pixels per millisecond to move on the X axis.
        /// </summary>
        /// <returns>The pixels per millisecond to move on the X axis.</returns>
        public virtual float GetPixelsPerMsToMoveX()
        {
            return pixelsPerMsToMoveX;
        }

        /// <summary>
        /// Sets the pixels per millisecond to move on the X axis.
        /// </summary>
        /// <param name="i">The pixels per millisecond to move on the X axis.</param>
        public virtual void SetPixelsPerMsToMoveX(float i)
        {
            pixelsPerMsToMoveX = i;
        }

        /// <summary>
        /// Gets the pixels per millisecond to move on the Y axis.
        /// </summary>
        /// <returns>The pixels per millisecond to move on the Y axis.</returns>
        public virtual float GetPixelsPerMsToMoveY()
        {
            return pixelsPerMsToMoveY;
        }

        /// <summary>
        /// Sets the pixels per millisecond to move on the Y axis.
        /// </summary>
        /// <param name="i">The pixels per millisecond to move on the Y axis.</param>
        public virtual void SetPixelsPerMsToMoveY(float i)
        {
            pixelsPerMsToMoveY = i;
        }

        /// <summary>
        /// Gets a bool indicating if the subject is moving.
        /// </summary>
        /// <returns>A bool indicating if the subject is moving.</returns>
        public virtual bool GetMoving()
        {
            return moving;
        }

        /// <summary>
        /// Sets a bool indicating if the subject is moving.
        /// </summary>
        /// <param name="b">A bool indicating if the subject is moving.</param>
        public virtual void SetMoving(bool b)
        {
            moving = b;
        }

        /// <summary>
        /// Gets a bool indicating the direction of the tween movement, start to finish or finish to start.
        /// </summary>
        /// <returns>A bool indicating the direction of the tween movement.</returns>
        public virtual bool GetDirStartToFinish()
        {
            return dirStartToFinish;
        }

        /// <summary>
        /// Sets a bool indicating the direction of the tween movement, start to finish or finish to start.
        /// </summary>
        /// <param name="b">A bool indicating the direction of the tween movement.</param>
        public virtual void SetDirStartToFinish(bool b)
        {
            dirStartToFinish = b;
        }

        /// <summary>
        /// Gets the start position of the movement tween.
        /// </summary>
        /// <returns>The start position of the movement tween.</returns>
        public virtual MmgVector2 GetStartPosition()
        {
            return startPosition;
        }

        /// <summary>
        /// Sets the start position of the movement tween.
        /// </summary>
        /// <param name="v">The start position of the movement tween.</param>
        public virtual void SetStartPosition(MmgVector2 v)
        {
            startPosition = v;
        }

        /// <summary>
        /// Gets the finish position of the movement tween.
        /// </summary>
        /// <returns>The finish position of the movement tween.</returns>
        public virtual MmgVector2 GetFinishPosition()
        {
            return finishPosition;
        }

        /// <summary>
        /// Sets the finish position of the movement tween.
        /// </summary>
        /// <param name="v">The finish position of the movement tween.</param>
        public virtual void SetFinishPosition(MmgVector2 v)
        {
            finishPosition = v;
        }

        /// <summary>
        /// Gets the pixel distance to move on the X and Y axis.
        /// </summary>
        /// <returns>The pixel distance to move on the X and Y axis.</returns>
        public virtual MmgVector2 GetPixelDistToMove()
        {
            return pixelDistToMove;
        }

        /// <summary>
        /// Sets the pixel distance to move on the X and Y axis.
        /// </summary>
        /// <param name="v">The pixel distance to move on the X and Y axis.</param>
        public virtual void SetPixelDistToMove(MmgVector2 v)
        {
            pixelDistToMove = v;
        }

        /// <summary>
        /// Gets the millisecond time to complete the movement.
        /// </summary>
        /// <returns>The millisecond time to complete the movement.</returns>
        public virtual float GetMsTimeToMove()
        {
            return msTimeToMove;
        }

        /// <summary>
        /// Sets the millisecond time to complete the movement.
        /// </summary>
        /// <param name="i">The millisecond time to complete the movement.</param>
        public virtual void SetMsTimeToMove(float i)
        {
            msTimeToMove = i;
        }

        /// <summary>
        /// Sets a bool indicating that the tween is at the start position.
        /// </summary>
        /// <param name="b">A bool indicating that the tween is at the start position.</param>
        public virtual void SetAtStart(bool b)
        {
            atStart = b;
        }

        /// <summary>
        /// Gets a bool indicating that the tween is at the start position.
        /// </summary>
        /// <returns>A bool indicating that the tween is at the start position.</returns>
        public virtual bool GetAtStart()
        {
            return atStart;
        }

        /// <summary>
        /// Sets a bool indicating that the tween is at the finish position.
        /// </summary>
        /// <param name="b">A bool indicating that the tween is at the finish position.</param>
        public virtual void SetAtFinish(bool b)
        {
            atFinish = b;
        }

        /// <summary>
        /// Gets a bool indicating that the tween is at the finish position.
        /// </summary>
        /// <returns>A bool indicating that the tween is at the finish position.</returns>
        public virtual bool GetAtFinish()
        {
            return atFinish;
        }

        /// <summary>
        /// Sets the subject of the movement tween.
        /// </summary>
        /// <param name="b">The subject of the movement tween.</param>
        public virtual void SetSubj(MmgObj b)
        {
            subj = b;
            SetHeight(subj.GetHeight());
            SetWidth(subj.GetWidth());
        }

        /// <summary>
        /// Gets the subject of the movement tween.
        /// </summary>
        /// <returns>The subject of the movement tween.</returns>
        public virtual MmgObj GetSubj()
        {
            return subj;
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgPositionTween(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgPositionTween CloneTyped()
        {
            return new MmgPositionTween(this);
        }

        /// <summary>
        /// The base drawing method for the bitmap object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this bitmap.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                subj.MmgDraw(p);
            }
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
                if (moving == true)
                {
                    if (dirStartToFinish == true)
                    {
                        //moving start to finish
                        if ((currentTimeMs - msStartMove) >= msTimeToMove)
                        {
                            SetAtFinish(true);
                            SetAtStart(false);
                            SetMoving(false);
                            SetPosition(finishPosition);
                            if (onReachFinish != null)
                            {
                                onReachFinish.MmgHandleEvent(reachFinish);
                            }
                            lret = true;
                        }
                        else
                        {
                            tmpV = new MmgVector2(startPosition.GetX() + (pixelsPerMsToMoveX * (currentTimeMs - msStartMove)), startPosition.GetY() + (pixelsPerMsToMoveY * (currentTimeMs - msStartMove)));
                            SetPosition(tmpV);
                            SetAtStart(false);
                            SetAtFinish(false);
                            lret = true;
                        }

                    }
                    else
                    {
                        //moving finish to start
                        if ((currentTimeMs - msStartMove) >= msTimeToMove)
                        {
                            SetAtFinish(false);
                            SetAtStart(true);
                            SetMoving(false);
                            SetPosition(startPosition);
                            if (onReachStart != null)
                            {
                                onReachStart.MmgHandleEvent(reachStart);
                            }
                            lret = true;
                        }
                        else
                        {
                            tmpV = new MmgVector2(finishPosition.GetX() - (pixelsPerMsToMoveX * (currentTimeMs - msStartMove)), finishPosition.GetY() - (pixelsPerMsToMoveY * (currentTimeMs - msStartMove)));
                            SetPosition(tmpV);
                            SetAtStart(false);
                            SetAtFinish(false);
                            lret = true;
                        }
                    }
                }
            }

            return lret;
        }

        /// <summary>
        /// Gets the width of the subject.
        /// </summary>
        /// <returns>The width of the subject.</returns>
        public override int GetWidth()
        {
            return subj.GetWidth();
        }

        /// <summary>
        /// Sets the width of this subject.
        /// </summary>
        /// <param name="w">The width of the subject.</param>
        public override void SetWidth(int w)
        {
            base.SetWidth(w);
            subj.SetWidth(w);
        }

        /// <summary>
        /// Gets the height of this object.
        /// </summary>
        /// <returns>The height of this object.</returns>
        public override int GetHeight()
        {
            return subj.GetHeight();
        }

        /// <summary>
        /// Sets the height of this object.
        /// </summary>
        /// <param name="h">The height of this object.</param>
        public override void SetHeight(int h)
        {
            base.SetHeight(h);
            subj.SetHeight(h);
        }

        /// <summary>
        /// Gets the position of this object.
        /// </summary>
        /// <returns>The position of the subject.</returns>
        public override MmgVector2 GetPosition()
        {
            return subj.GetPosition();
        }

        /// <summary>
        /// Sets the position of this object's subject.
        /// </summary>
        /// <param name="x">The X coordinate of the subject's position.</param>
        /// <param name="y">The Y coordinate of the subject's position.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            subj.SetPosition(x, y);
        }

        /// <summary>
        /// Sets the position of this object's subject.
        /// </summary>
        /// <param name="v">The position of the subject.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subj.SetPosition(v);
        }

        /// <summary>
        /// Gets the X coordinate of the subject.
        /// </summary>
        /// <returns>The X coordinate of the subject.</returns>
        public override int GetX()
        {
            return subj.GetX();
        }

        /// <summary>
        /// Sets the X coordinate of the subject.
        /// </summary>
        /// <param name="i">The X coordinate of the subject. </param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
        }

        /// <summary>
        /// Gets the Y coordinate of the subject.
        /// </summary>
        /// <returns>The Y coordinate of the subject.</returns>
        public override int GetY()
        {
            return subj.GetY();
        }

        /// <summary>
        /// Sets the y coordinate of the subject.
        /// </summary>
        /// <param name="i">The Y coordinate of the subject.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subj.SetY(i);
        }

        /// <summary>
        /// A method used to check the equality of this MmgPositionTween when compared to another MmgPositionTween.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgPositionTween object to compare to.</param>
        /// <returns>A bool indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgPositionTween obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            if(!(base.equals((MmgObj)obj))) {
                MmgHelper.wr("MmgPositionTween: MmgObj not equals!");
            }

            if(!(GetAtStart() == obj.GetAtStart())) {
                MmgHelper.wr("MmgPositionTween: AtStart not equals!");
            }        

            if(!(GetAtFinish() == obj.GetAtFinish())) {
                MmgHelper.wr("MmgPositionTween: AtFinish not equals!");
            }        

            if(!(GetDirStartToFinish() == obj.GetDirStartToFinish())) {
                MmgHelper.wr("MmgPositionTween: DirStartToFinish not equals!");
            }

            if(!(((obj.GetFinishPosition() == null && GetFinishPosition() == null) || (obj.GetFinishPosition() != null && GetFinishPosition() != null && obj.GetFinishPosition().equals(GetFinishPosition()))))) {
                MmgHelper.wr("MmgPositionTween: FinishPosition not equals!");
            }

            if(!(obj.GetHeight() == GetHeight())) {
                MmgHelper.wr("MmgPositionTween: Height not equals!");
            }

            if(!(obj.GetMoving() == GetMoving())) {
                MmgHelper.wr("MmgPositionTween: Moving not equals!");
            }

            if(!(obj.GetMsStartMove() == GetMsStartMove())) {
                MmgHelper.wr("MmgPositionTween: MsStartMove not equals!");
            }

            if(!(obj.GetMsTimeToMove() == GetMsTimeToMove())) {
                MmgHelper.wr("MmgPositionTween: MsTimeToMove not equals!");
            }

            if(!(obj.GetPixelsPerMsToMoveX() == GetPixelsPerMsToMoveX())) {
                MmgHelper.wr("MmgPositionTween: PixelsPerMsToMoveX not equals!");
            }

            if(!(obj.GetPixelsPerMsToMoveY() == GetPixelsPerMsToMoveY())) {
                MmgHelper.wr("MmgPositionTween: PixelsPerMsToMoveY not equals!");
            }        

            if(!(((obj.GetPixelDistToMove() == null && GetPixelDistToMove() == null) || (obj.GetPixelDistToMove() != null && GetPixelDistToMove() != null && obj.GetPixelDistToMove().equals(GetPixelDistToMove()))))) {
                MmgHelper.wr("MmgPositionTween: PixelsDistToMove not equals!");            
            }

            if(!(((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().equals(GetPosition()))))) {
                MmgHelper.wr("MmgPositionTween: Position not equals!");
            }

            if(!(((obj.GetStartPosition() == null && GetStartPosition() == null) || (obj.GetStartPosition() != null && GetStartPosition() != null && obj.GetStartPosition().equals(GetStartPosition()))))) {
                MmgHelper.wr("MmgPositionTween: StartPosition not equals!");
            }

            if(!(((obj.GetSubj() == null && GetSubj() == null) || (obj.GetSubj() != null && GetSubj() != null && obj.GetSubj().equals(GetSubj()))))) {
                MmgHelper.wr("MmgPositionTween: Subj not equals!");            
            }

            if(!(obj.GetWidth() == GetWidth())) {
                MmgHelper.wr("MmgPositionTween: Width not equals!");
            }        
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && GetAtStart() == obj.GetAtStart()
                && GetAtFinish() == obj.GetAtFinish()
                && GetDirStartToFinish() == obj.GetDirStartToFinish()
                && ((obj.GetFinishPosition() == null && GetFinishPosition() == null) || (obj.GetFinishPosition() != null && GetFinishPosition() != null && obj.GetFinishPosition().ApiEquals(GetFinishPosition())))
                && obj.GetHeight() == GetHeight()
                && obj.GetMoving() == GetMoving()
                && obj.GetMsStartMove() == GetMsStartMove()
                && obj.GetMsTimeToMove() == GetMsTimeToMove()
                && ((obj.GetPixelDistToMove() == null && GetPixelDistToMove() == null) || (obj.GetPixelDistToMove() != null && GetPixelDistToMove() != null && obj.GetPixelDistToMove().ApiEquals(GetPixelDistToMove())))
                && obj.GetPixelsPerMsToMoveX() == GetPixelsPerMsToMoveX()
                && obj.GetPixelsPerMsToMoveY() == GetPixelsPerMsToMoveY()
                && ((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().ApiEquals(GetPosition())))
                && ((obj.GetStartPosition() == null && GetStartPosition() == null) || (obj.GetStartPosition() != null && GetStartPosition() != null && obj.GetStartPosition().ApiEquals(GetStartPosition())))
                && ((obj.GetSubj() == null && GetSubj() == null) || (obj.GetSubj() != null && GetSubj() != null && obj.GetSubj().ApiEquals(GetSubj())))
                && obj.GetWidth() == GetWidth()
            )
            {
                ret = true;
            }

            return ret;
        }
    }
}