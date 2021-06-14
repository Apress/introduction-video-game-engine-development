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
    public class MmgSizeTween : MmgObj
    {
        /// <summary>
        /// An event id indicating the MmgSizeTween has reached the finish.
        /// </summary>
        public static int MMG_SIZE_TWEEN_REACH_FINISH = 0;

        /// <summary>
        /// An event id indicating the MmgSizeTween has reached the start.
        /// </summary>
        public static int MMG_SIZE_TWEEN_REACH_START = 1;

        /// <summary>
        /// An event type id for the MmgSizeTween finish event.
        /// </summary>
        public static int MMG_SIZE_TWEEN_REACH_FINISH_TYPE = 0;

        /// <summary>
        /// An event type if for the MmgSizeTween start event. 
        /// </summary>
        public static int MMG_SIZE_TWEEN_REACH_START_TYPE = 1;

        /// <summary>
        /// The subject of this size tween.
        /// </summary>
        private MmgObj subj;

        /// <summary>
        /// A copy of the subj MmgObj in its original state to prevent resizing a resized image.
        /// </summary>
        private MmgObj subjOrig;

        /// <summary>
        /// A boolean indicating the tween is at the start position.
        /// </summary>
        private bool atStart;

        /// <summary>
        /// A boolean indicating the tween is at the finish position.
        /// </summary>
        private bool atFinish;

        /// <summary>
        /// An MmgVector2 that holds the size to change in X, Y values.
        /// </summary>
        private MmgVector2 pixelSizeToChange;

        /// <summary>
        /// A float indicating the milliseconds allowed to scale to the specified size.
        /// </summary>
        private float msSizeToChange;

        /// <summary>
        /// The pixels per millisecond to scale on the X axis.
        /// </summary>
        private float pixelsPerMsToChangeX;

        /// <summary>
        /// The pixels per millisecond to scale on the Y axis.
        /// </summary>
        private float pixelsPerMsToChangeY;

        /// <summary>
        /// An MmgVector2 that holds the start size.
        /// </summary>
        private MmgVector2 startSize;

        /// <summary>
        /// An MmgVector2 that holds the finish size.
        /// </summary>
        private MmgVector2 finishSize;

        /// <summary>
        /// A boolean indicating the direction to scale, start to finish or finish to start.
        /// </summary>
        private bool dirStartToFinish;

        /// <summary>
        /// A boolean indicating if the object is changing.
        /// </summary>
        private bool changing;

        /// <summary>
        /// A long value that determines how long to wait before scaling.
        /// </summary>
        private long msStartChange;

        /// <summary>
        /// A temporary class field used to calculate a new MmgVector2 with scaling information.
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
        /// An event handler to resize the MmgObj subject to the specified size.
        /// </summary>
        private MmgScaleHandler onSubjScale;

        /// <summary>
        /// An event template for the reach finish event.
        /// </summary>
        private MmgEvent reachFinish = new MmgEvent(null, "reach_finish", MmgSizeTween.MMG_SIZE_TWEEN_REACH_FINISH, MmgSizeTween.MMG_SIZE_TWEEN_REACH_FINISH_TYPE, null, null);

        /// <summary>
        /// An event template for the reach start event.
        /// </summary>
        private MmgEvent reachStart = new MmgEvent(null, "reach_start", MmgSizeTween.MMG_SIZE_TWEEN_REACH_START, MmgSizeTween.MMG_SIZE_TWEEN_REACH_START_TYPE, null, null);

        /// <summary>
        /// A private boolean flag for the MmgUpdate method indicating if any work was done.
        /// </summary>
        private bool lret;

        /// <summary>
        /// A basic constructor for the MmgSizeTween object.
        /// </summary>
        /// <param name="subj">The MmgObj that is the subject of the tween.</param>
        /// <param name="msTimeToChange">The number of milliseconds to scale the object.</param>
        /// <param name="startSize">The start size of the tween.</param>
        /// <param name="finishSize">The finish size of the tween.</param>
        public MmgSizeTween(MmgObj subj, float msTimeToChange, MmgVector2 startSize, MmgVector2 finishSize) : base()
        {
            SetSubj(subj);
            SetSubjOrig(subj);
            SetPixelSizeToChange(new MmgVector2((finishSize.GetX() - startSize.GetX()), (finishSize.GetY() - startSize.GetY())));
            SetMsTimeToChange(msTimeToChange);
            SetPixelsPerMsToChangeX((GetPixelSizeToChange().GetX() / (float)msTimeToChange));
            SetPixelsPerMsToChangeY((GetPixelSizeToChange().GetY() / (float)msTimeToChange));
            SetStartSize(startSize);
            SetFinishSize(finishSize);
            SetWidth(startSize.GetX());
            SetHeight(startSize.GetY());
            SetDirStartToFinish(true);
            SetAtStart(true);
            SetAtFinish(false);
            SetChanging(false);
        }

        /// <summary>
        /// A constructor that is based on the an instance of the MmgSizeTween object.
        /// </summary>
        /// <param name="obj">An MmgSizeTween object used to create an new instance of the MmgSizeTween class.</param>
        public MmgSizeTween(MmgSizeTween obj) : base()
        {
            if (obj.GetSubj() == null)
            {
                SetSubj(obj.GetSubj());
            }
            else
            {
                SetSubj(obj.GetSubj().Clone());
            }

            if (obj.GetSubjOrig() == null)
            {
                SetSubjOrig(obj.GetSubjOrig());
            }
            else
            {
                SetSubjOrig(obj.GetSubjOrig().Clone());
            }

            SetAtStart(obj.GetAtStart());
            SetAtFinish(obj.GetAtFinish());

            if (obj.GetPixelSizeToChange() == null)
            {
                SetPixelSizeToChange(obj.GetPixelSizeToChange());
            }
            else
            {
                SetPixelSizeToChange(obj.GetPixelSizeToChange().Clone());
            }

            SetMsTimeToChange(obj.GetMsTimeToChange());
            SetPixelsPerMsToChangeX(obj.GetPixelsPerMsToChangeX());
            SetPixelsPerMsToChangeY(obj.GetPixelsPerMsToChangeY());

            if (obj.GetStartSize() == null)
            {
                SetStartSize(obj.GetStartSize());
            }
            else
            {
                SetStartSize(obj.GetStartSize().Clone());
            }

            if (obj.GetFinishSize() == null)
            {
                SetFinishSize(obj.GetFinishSize());
            }
            else
            {
                SetFinishSize(obj.GetFinishSize().Clone());
            }

            SetDirStartToFinish(obj.GetDirStartToFinish());
            SetChanging(obj.GetChanging());
            SetMsStartChange(obj.GetMsStartChange());
            SetOnReachStart(obj.GetOnReachStart());
            SetOnReachFinish(obj.GetOnReachFinish());
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
        /// Sets the finish event id.
        /// </summary>
        /// <param name="i">The finish event id.</param>
        public virtual void SetFinishEventId(int i)
        {
            if (reachFinish != null)
            {
                reachFinish.SetEventId(i);
            }
        }

        /// <summary>
        /// Sets the start event id.
        /// </summary>
        /// <param name="i">The start event id.</param>
        public virtual void SetStartEventId(int i)
        {
            if (reachStart != null)
            {
                reachStart.SetEventId(i);
            }
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
        /// Sets the resizing handler.
        /// </summary>
        /// <param name="o">The resizing handler.</param>
        public virtual void SetOnSubjScale(MmgScaleHandler o)
        {
            onSubjScale = o;
        }

        /// <summary>
        /// Gets the resizing handler.
        /// </summary>
        /// <returns>The resizing handler.</returns>
        public virtual MmgScaleHandler GetOnSubjScale()
        {
            return onSubjScale;
        }

        /// <summary>
        /// Gets the original subject.
        /// </summary>
        /// <returns>The original subject.</returns>
        public virtual MmgObj GetSubjOrig()
        {
            return subjOrig;
        }

        /// <summary>
        /// Sets the original subject.
        /// </summary>
        /// <param name="o">The original subject.</param>
        public virtual void SetSubjOrig(MmgObj o)
        {
            subjOrig = o;
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
        /// Gets the milliseconds to wait before starting the scaling.
        /// </summary>
        /// <returns>The milliseconds to wait before starting the scaling.</returns>
        public virtual long GetMsStartChange()
        {
            return msStartChange;
        }

        /// <summary>
        /// Sets the milliseconds to wait before starting the scaling.
        /// </summary>
        /// <param name="l">The milliseconds to wait before starting the scaling.</param>
        public virtual void SetMsStartChange(long l)
        {
            msStartChange = l;
        }

        /// <summary>
        /// Gets the pixels per millisecond to scale on the X axis.
        /// </summary>
        /// <returns>The pixels per millisecond to scale on the X axis.</returns>
        public virtual float GetPixelsPerMsToChangeX()
        {
            return pixelsPerMsToChangeX;
        }

        /// <summary>
        /// Sets the pixels per millisecond to scale on the X axis.
        /// </summary>
        /// <param name="i">The pixels per millisecond to scale on the X axis.</param>
        public virtual void SetPixelsPerMsToChangeX(float i)
        {
            pixelsPerMsToChangeX = i;
        }

        /// <summary>
        /// Gets the pixels per millisecond to scale on the Y axis.
        /// </summary>
        /// <returns>The pixels per millisecond to scale on the Y axis.</returns>
        public virtual float GetPixelsPerMsToChangeY()
        {
            return pixelsPerMsToChangeY;
        }

        /// <summary>
        /// Sets the pixels per millisecond to scale on the Y axis.
        /// </summary>
        /// <param name="i">The pixels per millisecond to scale on the Y axis.</param>
        public virtual void SetPixelsPerMsToChangeY(float i)
        {
            pixelsPerMsToChangeY = i;
        }

        /// <summary>
        /// Gets a boolean indicating if the subject is scaling.
        /// </summary>
        /// <returns>A boolean indicating if the subject is scaling.</returns>
        public virtual bool GetChanging()
        {
            return changing;
        }

        /// <summary>
        /// Sets a boolean indicating if the subject is scaling.
        /// </summary>
        /// <param name="b">A boolean indicating if the subject is scaling.</param>
        public virtual void SetChanging(bool b)
        {
            changing = b;
        }

        /// <summary>
        /// Gets a boolean indicating the direction of the tween movement, start to finish or finish to start.
        /// </summary>
        /// <returns>A boolean indicating the direction of the tween movement.</returns>
        public virtual bool GetDirStartToFinish()
        {
            return dirStartToFinish;
        }

        /// <summary>
        /// Sets a boolean indicating the direction of the tween movement, start to finish or finish to start.
        /// </summary>
        /// <param name="b">A boolean indicating the direction of the tween movement.</param>
        public virtual void SetDirStartToFinish(bool b)
        {
            dirStartToFinish = b;
        }

        /// <summary>
        /// Gets the start size of the size tween.
        /// </summary>
        /// <returns>The start size of the size tween.</returns>
        public virtual MmgVector2 GetStartSize()
        {
            return startSize;
        }

        /// <summary>
        /// Sets the start size of the size tween.
        /// </summary>
        /// <param name="v">The start size of the size tween.</param>
        public virtual void SetStartSize(MmgVector2 v)
        {
            startSize = v;
        }

        /// <summary>
        /// Gets the finish size of the size tween.
        /// </summary>
        /// <returns>The finish size of the size tween.</returns>
        public virtual MmgVector2 GetFinishSize()
        {
            return finishSize;
        }

        /// <summary>
        /// Sets the finish size of the size tween.
        /// </summary>
        /// <param name="v">The finish size of the size tween.</param>
        public virtual void SetFinishSize(MmgVector2 v)
        {
            finishSize = v;
        }

        /// <summary>
        /// Gets the pixel size to scale on the X and Y axis.
        /// </summary>
        /// <returns>The pixel size to scale on the X and Y axis.</returns>
        public virtual MmgVector2 GetPixelSizeToChange()
        {
            return pixelSizeToChange;
        }

        /// <summary>
        /// Sets the pixel size to scale on the X and Y axis.
        /// </summary>
        /// <param name="v">The pixel size to scale on the X and Y axis.</param>
        public virtual void SetPixelSizeToChange(MmgVector2 v)
        {
            pixelSizeToChange = v;
        }

        /// <summary>
        /// Gets the millisecond time to complete the scaling.
        /// </summary>
        /// <returns>The millisecond time to complete the scaling.</returns>
        public virtual float GetMsTimeToChange()
        {
            return msSizeToChange;
        }

        /// <summary>
        /// Sets the millisecond time to complete the scaling.
        /// </summary>
        /// <param name="i">The millisecond time to complete the scaling.</param>
        public virtual void SetMsTimeToChange(float i)
        {
            msSizeToChange = i;
        }

        /// <summary>
        /// Sets a boolean indicating that the tween is at the start size.
        /// </summary>
        /// <param name="b">A boolean indicating that the tween is at the start size.</param>
        public virtual void SetAtStart(bool b)
        {
            atStart = b;
        }

        /// <summary>
        /// Gets a boolean indicating that the tween is at the start size.
        /// </summary>
        /// <returns>A boolean indicating that the tween is at the start size.</returns>
        public virtual bool GetAtStart()
        {
            return atStart;
        }

        /// <summary>
        /// Sets a boolean indicating that the tween is at the finish size.
        /// </summary>
        /// <param name="b">A boolean indicating that the tween is at the finish size.</param>
        public virtual void SetAtFinish(bool b)
        {
            atFinish = b;
        }

        /// <summary>
        /// Gets a boolean indicating that the tween is at the finish size.
        /// </summary>
        /// <returns>A boolean indicating that the tween is at the finish size.</returns>
        public virtual bool GetAtFinish()
        {
            return atFinish;
        }

        /// <summary>
        /// Sets the subject of the size tween.
        /// </summary>
        /// <param name="b">The subject of the size tween.</param>
        public virtual void SetSubj(MmgObj b)
        {
            subj = b;
        }

        /// <summary>
        /// Gets the subject of the size tween.
        /// </summary>
        /// <returns>The subject of the size tween.</returns>
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
            return (MmgObj)new MmgSizeTween(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgSizeTween CloneTyped()
        {
            return new MmgSizeTween(this);
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
        /// <param name="updateTick">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A boolean indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (isVisible == true)
            {
                if (GetChanging() == true)
                {
                    if (GetDirStartToFinish() == true)
                    {
                        //changing start to finish
                        if ((currentTimeMs - msStartChange) >= msSizeToChange)
                        {
                            SetAtFinish(true);
                            SetAtStart(false);
                            SetChanging(false);
                            SetWidth(finishSize.GetX());
                            SetHeight(finishSize.GetY());

                            if (onSubjScale != null)
                            {
                                onSubjScale.MmgHandleScale(finishSize, subjOrig);
                            }

                            if (onReachFinish != null)
                            {
                                onReachFinish.MmgHandleEvent(reachFinish);
                            }

                            lret = true;
                        }
                        else
                        {
                            tmpV = new MmgVector2(startSize.GetX() + (pixelsPerMsToChangeX * (currentTimeMs - msStartChange)), startSize.GetY() + (pixelsPerMsToChangeY * (currentTimeMs - msStartChange)));
                            SetWidth(tmpV.GetX());
                            SetHeight(tmpV.GetY());

                            if (onSubjScale != null)
                            {
                                onSubjScale.MmgHandleScale(tmpV, subjOrig);
                            }

                            lret = true;
                        }

                    }
                    else
                    {
                        //changing finish to start
                        if ((currentTimeMs - msStartChange) >= msSizeToChange)
                        {
                            SetAtFinish(false);
                            SetAtStart(true);
                            SetChanging(false);
                            SetWidth(startSize.GetX());
                            SetHeight(startSize.GetY());

                            if (onSubjScale != null)
                            {
                                onSubjScale.MmgHandleScale(startSize, subjOrig);
                            }

                            if (onReachStart != null)
                            {
                                onReachStart.MmgHandleEvent(reachStart);
                            }

                            lret = true;
                        }
                        else
                        {
                            tmpV = new MmgVector2(finishSize.GetX() - (pixelsPerMsToChangeX * (currentTimeMs - msStartChange)), finishSize.GetY() - (pixelsPerMsToChangeY * (currentTimeMs - msStartChange)));
                            SetWidth(tmpV.GetX());
                            SetHeight(tmpV.GetY());

                            if (onSubjScale != null)
                            {
                                onSubjScale.MmgHandleScale(tmpV, subjOrig);
                            }

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
        /// Gets the height of the subject.
        /// </summary>
        /// <returns>The height of the subject.</returns>
        public override int GetHeight()
        {
            return subj.GetHeight();
        }

        /// <summary>
        /// Sets the height of the subject.
        /// </summary>
        /// <param name="h">The height of the subject.</param>
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
            subj.SetPosition(v);
        }

        /// <summary>
        /// Sets the size of the subject.
        /// </summary>
        /// <param name="v">The desired size of the subject represented as an MmgVector2.</param>
        public virtual void SetSize(MmgVector2 v)
        {
            subj.SetWidth(v.GetX());
            subj.SetHeight(v.GetY());
        }

        /// <summary>
        /// A method used to check the equality of this MmgPositionTween when compared to another MmgPositionTween.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgPositionTween object to compare to.</param>
        /// <returns>A boolean indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgSizeTween obj)
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
                MmgHelper.wr("MmgSizeTween: MmgObj not equals!");
            }

            if(!(GetAtStart() == obj.GetAtStart())) {
                MmgHelper.wr("MmgSizeTween: AtStart not equals!");
            }        

            if(!(GetAtFinish() == obj.GetAtFinish())) {
                MmgHelper.wr("MmgSizeTween: AtFinish not equals!");
            }        

            if(!(GetDirStartToFinish() == obj.GetDirStartToFinish())) {
                MmgHelper.wr("MmgSizeTween: DirStartToFinish not equals!");
            }

            if(!(((obj.GetFinishSize() == null && GetFinishSize() == null) || (obj.GetFinishSize() != null && GetFinishSize() != null && obj.GetFinishSize().equals(GetFinishSize()))))) {
                MmgHelper.wr("MmgSizeTween: FinishSize not equals!");
            }

            if(!(obj.GetHeight() == GetHeight())) {
                MmgHelper.wr("MmgSizeTween: Height not equals!");
            }

            if(!(obj.GetChanging() == GetChanging())) {
                MmgHelper.wr("MmgSizeTween: Moving not equals!");
            }

            if(!(obj.GetMsStartChange() == GetMsStartChange())) {
                MmgHelper.wr("MmgSizeTween: MsStartMove not equals!");
            }

            if(!(obj.GetMsTimeToChange() == GetMsTimeToChange())) {
                MmgHelper.wr("MmgSizeTween: MsTimeToMove not equals!");
            }

            if(!(obj.GetPixelsPerMsToChangeX() == GetPixelsPerMsToChangeX())) {
                MmgHelper.wr("MmgSizeTween: PixelsPerMsToMoveX not equals!");
            }

            if(!(obj.GetPixelsPerMsToChangeY() == GetPixelsPerMsToChangeY())) {
                MmgHelper.wr("MmgSizeTween: PixelsPerMsToMoveY not equals!");
            }        

            if(!(((obj.GetPixelSizeToChange() == null && GetPixelSizeToChange() == null) || (obj.GetPixelSizeToChange() != null && GetPixelSizeToChange() != null && obj.GetPixelSizeToChange().equals(GetPixelSizeToChange()))))) {
                MmgHelper.wr("MmgSizeTween: PixelsDistToMove not equals!");            
            }

            if(!(((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().equals(GetPosition()))))) {
                MmgHelper.wr("MmgSizeTween: Position not equals!");
            }

            if(!(((obj.GetStartSize() == null && GetStartSize() == null) || (obj.GetStartSize() != null && GetStartSize() != null && obj.GetStartSize().equals(GetStartSize()))))) {
                MmgHelper.wr("MmgSizeTween: StartPosition not equals!");
            }

            if(!(((obj.GetSubj() == null && GetSubj() == null) || (obj.GetSubj() != null && GetSubj() != null && obj.GetSubj().equals(GetSubj()))))) {
                MmgHelper.wr("MmgSizeTween: Subj not equals!");            
            }

            if(!(obj.GetWidth() == GetWidth())) {
                MmgHelper.wr("MmgSizeTween: Width not equals!");
            }        
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && GetAtStart() == obj.GetAtStart()
                && GetAtFinish() == obj.GetAtFinish()
                && GetDirStartToFinish() == obj.GetDirStartToFinish()
                && ((obj.GetFinishSize() == null && GetFinishSize() == null) || (obj.GetFinishSize() != null && GetFinishSize() != null && obj.GetFinishSize().ApiEquals(GetFinishSize())))
                && obj.GetHeight() == GetHeight()
                && obj.GetChanging() == GetChanging()
                && obj.GetMsStartChange() == GetMsStartChange()
                && obj.GetMsTimeToChange() == GetMsTimeToChange()
                && ((obj.GetPixelSizeToChange() == null && GetPixelSizeToChange() == null) || (obj.GetPixelSizeToChange() != null && GetPixelSizeToChange() != null && obj.GetPixelSizeToChange().ApiEquals(GetPixelSizeToChange())))
                && obj.GetPixelsPerMsToChangeX() == GetPixelsPerMsToChangeX()
                && obj.GetPixelsPerMsToChangeY() == GetPixelsPerMsToChangeY()
                && ((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().ApiEquals(GetPosition())))
                && ((obj.GetStartSize() == null && GetStartSize() == null) || (obj.GetStartSize() != null && GetStartSize() != null && obj.GetStartSize().ApiEquals(GetStartSize())))
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