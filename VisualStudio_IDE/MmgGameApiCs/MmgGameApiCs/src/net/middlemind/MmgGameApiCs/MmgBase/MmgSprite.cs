using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that represents a sprite image.
    /// Created by Middlemind Games 06/01/2005
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgSprite : MmgObj
    {
        /// <summary>
        /// The event type for sprite frame changes.
        /// </summary>
        public static int MMG_SPRITE_FRAME_CHANGE_TYPE = 0;

        /// <summary>
        /// The event id for sprite frame changes.
        /// </summary>
        public static int MMG_SPRITE_FRAME_CHANGE = 0;

        /// <summary>
        /// The origin of the sprite image.
        /// </summary>
        private MmgVector2 origin;

        /// <summary>
        /// The scaling of the sprite image.
        /// </summary>
        private MmgVector2 scaling;

        /// <summary>
        /// The source drawing rectangle.
        /// </summary>
        private MmgRect srcRect;

        /// <summary>
        /// The destination drawing rectangle.
        /// </summary>
        private MmgRect dstRect;

        /// <summary>
        /// The bitmaps to use to draw the sprite's frames.
        /// </summary>
        private MmgBmp[] b;

        /// <summary>
        /// The rotation to apply to the sprite.
        /// </summary>
        private float rotation;

        /// <summary>
        /// The frame start.
        /// </summary>
        private int frameStart;

        /// <summary>
        /// The frame stop.
        /// </summary>
        private int frameStop;

        /// <summary>
        /// The time of the current frame.
        /// </summary>
        private long frameTime = -1;

        /// <summary>
        /// The time of the previous frame.
        /// </summary>
        private long prevFrameTime = -1;

        /// <summary>
        /// The frame index.
        /// </summary>
        private int frameIdx;

        /// <summary>
        /// The milliseconds per frame.
        /// </summary>
        private long msPerFrame;

        /// <summary>
        /// A static field that controls the default milliseconds per frame change.
        /// </summary>
        public static int DEFAULT_MS_PER_FRAME = 100;

        /// <summary>
        /// A bool indicating that only simple rendering should be done, no rotation or other image modifications.
        /// </summary>
        private bool simpleRendering;

        /// <summary>
        /// An event handler to use for frame change events.
        /// </summary>
        private MmgEventHandler onFrameChange;

        /// <summary>
        /// A bool indicating if this sprite is based only on a timer for frame changes.
        /// </summary>
        private bool timerOnly;

        /// <summary>
        /// An MmgEvent to use for frame change event calls.
        /// </summary>
        private MmgEvent frameChange = new MmgEvent(null, "frame_changed", MmgSprite.MMG_SPRITE_FRAME_CHANGE, MmgSprite.MMG_SPRITE_FRAME_CHANGE_TYPE, null, null);

        /// <summary>
        /// A private bool used in the MmgUpdate method called during the update process.
        /// </summary>
        private bool lret;

        /// <summary>
        /// Constructor that sets the MmgBmp array, the source rectangle, the destination rectangle,
        /// the origin, the scaling vector, and the rotation.
        /// </summary>
        /// <param name="t">The MmgBmp frames.</param>
        /// <param name="Src">The source drawing rectangle.</param>
        /// <param name="Dst">The destination drawing rectangle.</param>
        /// <param name="Origin">The drawing origin of the sprite.</param>
        /// <param name="Scaling">The scaling of the sprite.</param>
        /// <param name="Rotation">The rotation of the sprite</param>
        public MmgSprite(MmgBmp[] t, MmgRect Src, MmgRect Dst, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) : base()
        {
            frameTime = -1;
            prevFrameTime = -1;
            SetRotation(Rotation);
            SetOrigin(Origin);
            SetScaling(Scaling);
            SetSrcRect(Src);
            SetDstRect(Dst);
            SetBmpArray(t);
            SetPosition(MmgVector2.GetOriginVec());
            SetIsVisible(true);
            SetSimpleRendering(true);
            SetMsPerFrame(DEFAULT_MS_PER_FRAME);
        }

        /// <summary>
        /// Constructor that sets the MmgBmp frames, the position, the origin, the scaling vector, and the rotation.
        /// </summary>
        /// <param name="t">The MmgBmp frames of the object.</param>
        /// <param name="Position">The position vector of the object.</param>
        /// <param name="Origin">The origin of the object.</param>
        /// <param name="Scaling">The scaling of the object.</param>
        /// <param name="Rotation">The rotation of the object.</param>
        public MmgSprite(MmgBmp[] t, MmgVector2 Position, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) : base()
        {
            frameTime = -1;
            prevFrameTime = -1;
            SetRotation(Rotation);
            SetOrigin(Origin);
            SetScaling(Scaling);
            SetBmpArray(t);
            MmgRect r = new MmgRect(Position, t[0].GetWidth(), t[0].GetHeight());
            SetSrcRect(r);
            SetDstRect(null);
            SetPosition(Position);
            SetIsVisible(true);
            SetSimpleRendering(true);
            SetMsPerFrame(DEFAULT_MS_PER_FRAME);
        }

        /// <summary>
        /// Constructor that sets the value of the sprite frames based on an array of MmgBmp instances and a position to use for drawing.
        /// </summary>
        /// <param name="t">An array of MmgBmp instances to use as the frames for this class.</param>
        /// <param name="Position">An MmgVector2 class instance to use the position information for this class.</param>
        public MmgSprite(MmgBmp[] t, MmgVector2 Position) : base()
        {
            frameTime = -1;
            prevFrameTime = -1;
            SetRotation(0);
            SetOrigin(MmgVector2.GetOriginVec());
            SetScaling(MmgVector2.GetUnitVec());
            SetSrcRect(null);
            SetDstRect(null);
            SetBmpArray(t);
            SetPosition(Position);
            SetIsVisible(true);
            SetSimpleRendering(true);
            SetMsPerFrame(DEFAULT_MS_PER_FRAME);
        }

        /// <summary>
        /// Constructor that sets the value of the sprite frames based on an array of MmgBmp instances.
        /// </summary>
        /// <param name="t">An array of MmgBmp instances to use as the frames for this class.</param>
        public MmgSprite(MmgBmp[] t) : base()
        {
            frameTime = -1;
            prevFrameTime = -1;
            SetRotation(0);
            SetOrigin(MmgVector2.GetOriginVec());
            SetScaling(MmgVector2.GetUnitVec());
            SetSrcRect(null);
            SetDstRect(null);
            SetBmpArray(t);
            SetPosition(MmgVector2.GetOriginVec());
            SetIsVisible(true);
            SetSimpleRendering(true);
            SetMsPerFrame(DEFAULT_MS_PER_FRAME);
        }

        /// <summary>
        /// Constructor that sets the value of the class attributes based on the attributes of the given argument.
        /// </summary>
        /// <param name="obj">The MmgSprite object to base our class off of.</param>
        public MmgSprite(MmgSprite obj) : base()
        {
            SetFrameTime(obj.GetFrameTime());
            SetPrevFrameTime(obj.GetPrevFrameTime());
            SetRotation(obj.GetRotation());

            if (obj.GetOrigin() == null)
            {
                SetOrigin(obj.GetOrigin());
            }
            else
            {
                SetOrigin(obj.GetOrigin().Clone());
            }

            if (obj.GetScaling() == null)
            {
                SetScaling(obj.GetScaling());
            }
            else
            {
                SetScaling(obj.GetScaling().Clone());
            }

            if (obj.GetSrcRect() == null)
            {
                SetSrcRect(obj.GetSrcRect());
            }
            else
            {
                SetSrcRect(obj.GetSrcRect().Clone());
            }

            if (obj.GetDstRect() == null)
            {
                SetDstRect(obj.GetDstRect());
            }
            else
            {
                SetDstRect(obj.GetDstRect().Clone());
            }

            MmgBmp[] a = obj.GetBmpArray();
            int len = a.Length;
            MmgBmp[] b = new MmgBmp[len];
            for (int i = 0; i < len; i++)
            {
                b[i] = a[i].CloneTyped();
            }
            SetBmpArray(b);

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            SetFrameIdx(obj.GetFrameIdx());
            SetFrameStart(obj.GetFrameStart());
            SetFrameStop(obj.GetFrameStop());
            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());
            SetIsVisible(obj.GetIsVisible());
            SetSimpleRendering(obj.GetSimpleRendering());
            SetMsPerFrame(obj.GetMsPerFrame());
        }

        /// <summary>
        /// Gets the current frame time.
        /// </summary>
        /// <returns>The current frame time.</returns>
        public virtual long GetFrameTime()
        {
            return frameTime;
        }

        /// <summary>
        /// Sets the current frame time.
        /// </summary>
        /// <param name="l">The current frame time.</param>
        public virtual void SetFrameTime(long l)
        {
            frameTime = l;
        }

        /// <summary>
        /// Gets the previous frame time.
        /// </summary>
        /// <returns>The previous frame time.</returns>
        public virtual long GetPrevFrameTime()
        {
            return prevFrameTime;
        }

        /// <summary>
        /// Sets the previous frame time.
        /// </summary>
        /// <param name="l">The previous frame time.</param>
        public virtual void SetPrevFrameTime(long l)
        {
            prevFrameTime = l;
        }

        /// <summary>
        /// Sets the event id to use when the frame change event is fired.
        /// </summary>
        /// <param name="i">The event id to use when the frame change event is called.</param>
        public virtual void SetFrameChangeEventId(int i)
        {
            if (frameChange != null)
            {
                frameChange.SetEventId(i);
            }
        }

        /// <summary>
        /// Gets the event handler to use when the sprite frame changes.
        /// </summary>
        /// <returns>The event handler to use when the frame changes.</returns>
        public virtual MmgEventHandler GetOnFrameChange()
        {
            return onFrameChange;
        }

        /// <summary>
        /// Sets the event handler to use when the sprite frame changes.
        /// </summary>
        /// <param name="e">The event handler to use when the frame changes.</param>
        public virtual void SetOnFrameChange(MmgEventHandler e)
        {
            onFrameChange = e;
        }

        /// <summary>
        /// Gets a bool indicating if this class uses simple rendering, no rotation or advanced
        /// adjustment of the MmgBmp frames.
        /// </summary>
        /// <returns>A bool indicating if this class should use simple rendering.</returns>
        public virtual bool GetSimpleRendering()
        {
            return simpleRendering;
        }

        /// <summary>
        /// Sets a bool indicating if this class uses simple rendering, no rotation or advanced adjustment of the MmgBmp frames.
        /// </summary>
        /// <param name="s">A bool indicating if this class should use simple rendering.</param>
        public virtual void SetSimpleRendering(bool s)
        {
            simpleRendering = s;
        }

        /// <summary>
        /// Gets if this MmgSprite is timer only.
        /// </summary>
        /// <returns>A bool indicating if this class is timer only.</returns>
        public virtual bool GetTimerOnly()
        {
            return timerOnly;
        }

        /// <summary>
        /// Sets if the MmgSprite is timer only.
        /// </summary>
        /// <param name="b">A bool value to use to set if it's timer only.</param>
        public virtual void SetTimerOnly(bool b)
        {
            timerOnly = b;
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgSprite(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgSprite CloneTyped()
        {
            return new MmgSprite(this);
        }

        /// <summary>
        /// Gets the current frame of this MmgSprite object.
        /// </summary>
        /// <returns>The MmgBmp of the current frame.</returns>
        public virtual MmgBmp GetCurrentFrame()
        {
            return b[frameIdx];
        }

        /// <summary>
        /// Sets the current frame of this MmgSrpite object.
        /// </summary>
        /// <param name="bmp">The MmgBmp to set the current frame.</param>
        public virtual void SetCurrentFrame(MmgBmp bmp)
        {
            b[frameIdx] = bmp;
        }

        /// <summary>
        /// Gets the MmgBmp frames of this class.
        /// </summary>
        /// <returns>The MmgBmp frames of this class.</returns>
        public virtual MmgBmp[] GetBmpArray()
        {
            return b;
        }

        /// <summary>
        /// Sets the MmgBmp frames of this class.
        /// </summary>
        /// <param name="d">The MmgBmp frames of this class.</param>
        public virtual void SetBmpArray(MmgBmp[] d)
        {
            b = d;
            if (b != null && b.Length >= 1)
            {
                SetWidth(b[0].GetWidth());
                SetHeight(b[0].GetHeight());
                frameStart = 0;
                frameStop = b.Length - 1;
                frameIdx = 0;
            }
        }

        /// <summary>
        /// Gets the drawing source rectangle.
        /// </summary>
        /// <returns>The drawing source rectangle.</returns>
        public virtual MmgRect GetSrcRect()
        {
            return srcRect;
        }

        /// <summary>
        /// Sets the drawing source rectangle.
        /// </summary>
        /// <param name="r">The drawing source rectangle.</param>
        public virtual void SetSrcRect(MmgRect r)
        {
            srcRect = r;
        }

        /// <summary>
        /// Gets the drawing destination rectangle.
        /// </summary>
        /// <returns>The drawing destination rectangle.</returns>
        public virtual MmgRect GetDstRect()
        {
            return dstRect;
        }

        /// <summary>
        /// Sets the drawing destination rectangle.
        /// </summary>
        /// <param name="r">The drawing destination rectangle.</param>
        public virtual void SetDstRect(MmgRect r)
        {
            dstRect = r;
        }

        /// <summary>
        /// Gets the rotation of the sprite.
        /// </summary>
        /// <returns>The rotation of the sprite.</returns>
        public virtual float GetRotation()
        {
            return rotation;
        }

        /// <summary>
        /// Sets the rotation of the sprite.
        /// </summary>
        /// <param name="r">The rotation of the sprite.</param>
        public virtual void SetRotation(float r)
        {
            rotation = r;
        }

        /// <summary>
        /// Gets the drawing origin vector.
        /// </summary>
        /// <returns>The drawing origin vector.</returns>
        public virtual MmgVector2 GetOrigin()
        {
            return origin;
        }

        /// <summary>
        /// Sets the drawing origin vector.
        /// </summary>
        /// <param name="v">The drawing origin vector.</param>
        public virtual void SetOrigin(MmgVector2 v)
        {
            origin = v;
        }

        /// <summary>
        /// Gets the drawing scaling vector.
        /// </summary>
        /// <returns>The drawing scaling vector.</returns>
        public virtual MmgVector2 GetScaling()
        {
            return scaling;
        }

        /// <summary>
        /// Sets the drawing scaling vector.
        /// </summary>
        /// <param name="v">The drawing scaling vector.</param>
        public virtual void SetScaling(MmgVector2 v)
        {
            scaling = v;
        }

        /// <summary>
        /// Gets the frame index.
        /// </summary>
        /// <returns>The frame index.</returns>
        public virtual int GetFrameIdx()
        {
            return frameIdx;
        }

        /// <summary>
        /// Sets the frame index.
        /// </summary>
        /// <param name="f">The frame index.</param>
        public virtual void SetFrameIdx(int f)
        {
            frameIdx = f;
        }

        /// <summary>
        /// Checks to see if the sprite frame is null.
        /// </summary>
        /// <param name="i">The index of the frame to check.</param>
        /// <returns>A bool indicating if the frame is null.</returns>
        public virtual bool IsFrameNull(int i)
        {
            if (i >= 0 && i < b.Length)
            {
                if (b != null && b[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the frame start index.
        /// </summary>
        /// <returns>The frame start index.</returns>
        public virtual int GetFrameStart()
        {
            return frameStart;
        }

        /// <summary>
        /// Sets the frame start index.
        /// </summary>
        /// <param name="f">The frame start index.</param>
        public virtual void SetFrameStart(int f)
        {
            frameStart = f;
        }

        /// <summary>
        /// Gets the frame stop index.
        /// </summary>
        /// <returns>The frame stop index.</returns>
        public virtual int GetFrameStop()
        {
            return frameStop;
        }

        /// <summary>
        /// Sets the frame stop index.
        /// </summary>
        /// <param name="f">The frame stop index.</param>
        public virtual void SetFrameStop(int f)
        {
            frameStop = f;
        }

        /// <summary>
        /// Gets the milliseconds per frame.
        /// </summary>
        /// <returns>The milliseconds per frame.</returns>
        public virtual long GetMsPerFrame()
        {
            return msPerFrame;
        }

        /// <summary>
        /// Sets the milliseconds per frame.
        /// </summary>
        /// <param name="f">The milliseconds per frame.</param>
        public virtual void SetMsPerFrame(long f)
        {
            msPerFrame = f;
        }

        /// <summary>
        /// Draw this object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (b[frameIdx] != null)
                {
                    if (simpleRendering == true)
                    {
                        p.DrawBmp(b[frameIdx], GetPosition());
                    }
                    else
                    {
                        if (srcRect == null || dstRect == null)
                        {
                            if (origin == null)
                            {
                                if (rotation == 0.0)
                                {
                                    p.DrawBmp(b[frameIdx], GetPosition());
                                }
                                else
                                {
                                    p.DrawBmp(b[frameIdx], GetPosition(), GetRotation());
                                }
                            }
                            else
                            {
                                p.DrawBmp(b[frameIdx], GetPosition(), GetOrigin(), GetRotation());
                            }
                        }
                        else
                        {
                            if (origin == null)
                            {
                                if (scaling == null)
                                {
                                    p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), MmgVector2.GetUnitVec(), MmgVector2.GetOriginVec(), GetRotation());
                                }
                                else
                                {
                                    p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), GetScaling(), MmgVector2.GetOriginVec(), GetRotation());
                                }
                            }
                            else
                            {
                                if (scaling == null)
                                {
                                    p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), MmgVector2.GetUnitVec(), GetOrigin(), GetRotation());
                                }
                                else
                                {
                                    p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), GetScaling(), GetOrigin(), GetRotation());
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Update the current sprite animation frame index.
        /// </summary>
        /// <param name="updateTick">The index of the MmgUpdate call.</param>
        /// <param name="currentTimeMs">The current time in milliseconds of the MmgUpdate call.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds since the last MmgUpdate call.</param>
        /// <returns>A bool flag indicating if any work was done.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (isVisible == true)
            {
                prevFrameTime = frameTime;
                frameTime += msSinceLastFrame;
                if (frameTime >= msPerFrame || prevFrameTime == -1)
                {
                    if (onFrameChange != null)
                    {
                        onFrameChange.MmgHandleEvent(frameChange);
                    }

                    if (timerOnly == false)
                    {
                        frameIdx++;
                        if (frameIdx > frameStop)
                        {
                            frameIdx = frameStart;
                        }
                        frameTime = 0;

                    }
                    else
                    {
                        frameTime = 0;

                    }

                    lret = true;
                }
            }

            return lret;
        }

        /// <summary>
        /// A method used to check the equality of this MmgSprite when compared to another MmgSprite.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgSprite object to compare to.</param>
        /// <returns>A bool indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgSprite obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && obj.GetSimpleRendering() == GetSimpleRendering()
                && obj.GetTimerOnly() == GetTimerOnly()
                && ((obj.GetDstRect() == null && GetDstRect() == null) || (obj.GetDstRect() != null && GetDstRect() != null && obj.GetDstRect().ApiEquals(GetDstRect())))
                && obj.GetFrameStart() == GetFrameStart()
                && obj.GetFrameStop() == GetFrameStop()
                && obj.GetFrameTime() == GetFrameTime()
                && obj.GetMsPerFrame() == GetMsPerFrame()
                && ((obj.GetOrigin() == null && GetOrigin() == null) || (obj.GetOrigin() != null && GetOrigin() != null && obj.GetOrigin().ApiEquals(GetOrigin())))
                && obj.GetRotation() == GetRotation()
                && ((obj.GetScaling() == null && GetScaling() == null) || (obj.GetScaling() != null && GetScaling() != null && obj.GetScaling().ApiEquals(GetScaling())))
                && ((obj.GetSrcRect() == null && GetSrcRect() == null) || (obj.GetSrcRect() != null && GetSrcRect() != null && obj.GetSrcRect().ApiEquals(GetSrcRect())))
            )
            {
                ret = true;
                if (obj.GetBmpArray() == null && GetBmpArray() == null)
                {
                    ret = true;
                }
                else if (obj.GetBmpArray() != null && GetBmpArray() != null)
                {
                    int len1 = obj.GetBmpArray().Length;
                    int len2 = GetBmpArray().Length;

                    if (len1 != len2)
                    {
                        ret = false;
                    }
                    else
                    {
                        for (int i = 0; i < len1; i++)
                        {
                            if (!((obj.GetBmpArray()[i] == null && GetBmpArray()[i] == null) || (obj.GetBmpArray()[i] != null && GetBmpArray()[i] != null && obj.GetBmpArray()[i].ApiEquals(GetBmpArray()[i]))))
                            {
                                ret = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ret = false;
                }
            }
            return ret;
        }
    }
}