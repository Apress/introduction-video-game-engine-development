package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * A class that represents a sprite image.
 * Created by Middlemind Games 06/01/2005
 * 
 * @author Victor G. Brusca
 */
public class MmgSprite extends MmgObj {

    /**
     * The event type for sprite frame changes.
     */
    public static int MMG_SPRITE_FRAME_CHANGE_TYPE = 0;
    
    /**
     * The event id for sprite frame changes.
     */
    public static int MMG_SPRITE_FRAME_CHANGE = 0;
    
    /**
     * The origin of the sprite image.
     */
    private MmgVector2 origin;
    
    /**
     * The scaling of the sprite image.
     */
    private MmgVector2 scaling;
    
    /**
     * The source drawing rectangle.
     */
    private MmgRect srcRect;
    
    /**
     * The destination drawing rectangle.
     */
    private MmgRect dstRect;
    
    /**
     * The bitmaps to use to draw the sprite's frames.
     */
    private MmgBmp[] b;
    
    /**
     * The rotation to apply to the sprite.
     */
    private float rotation;
    
    /**
     * The frame start.
     */
    private int frameStart;
    
    /**
     * The frame stop.
     */
    private int frameStop;
    
    /**
     * The time of the current frame.
     */
    private long frameTime = -1;
    
    /**
     * The time of the previous frame.
     */
    private long prevFrameTime = -1;
    
    /**
     * The frame index.
     */
    private int frameIdx;
    
    /**
     * The milliseconds per frame.
     */
    private long msPerFrame;

    /**
     * A static field that controls the default milliseconds per frame change.
     */
    public static int DEFAULT_MS_PER_FRAME = 100;
        
    /**
     * A boolean indicating that only simple rendering should be done, no rotation or other image modifications.
     */
    private boolean simpleRendering;
    
    /**
     * An event handler to use for frame change events.
     */
    private MmgEventHandler onFrameChange;
    
    /**
     * A boolean indicating if this sprite is based only on a timer for frame changes.
     */
    private boolean timerOnly;
    
    /**
     * An MmgEvent to use for frame change event calls.
     */
    private MmgEvent frameChange = new MmgEvent(null, "frame_changed", MmgSprite.MMG_SPRITE_FRAME_CHANGE, MmgSprite.MMG_SPRITE_FRAME_CHANGE_TYPE, null, null);

    /**
     * A private boolean used in the MmgUpdate method called during the update process.
     */
    private boolean lret;
    
    /**
     * Constructor that sets the MmgBmp array, the source rectangle, the destination rectangle,
     * the origin, the scaling vector, and the rotation.
     * 
     * @param t             The MmgBmp frames.
     * @param Src           The source drawing rectangle.
     * @param Dst           The destination drawing rectangle.
     * @param Origin        The drawing origin of the sprite.
     * @param Scaling       The scaling of the sprite.
     * @param Rotation      The rotation of the sprite
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSprite(MmgBmp[] t, MmgRect Src, MmgRect Dst, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) {
        super();
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

    /**
     * Constructor that sets the MmgBmp frames, the position, the origin, the scaling vector, and the rotation.
     * 
     * @param t             The MmgBmp frames of the object.
     * @param Position      The position vector of the object.
     * @param Origin        The origin of the object.
     * @param Scaling       The scaling of the object.
     * @param Rotation      The rotation of the object.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSprite(MmgBmp[] t, MmgVector2 Position, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) {
        super();
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

    /**
     * Constructor that sets the value of the sprite frames based on an array of MmgBmp instances and a position to use for drawing.
     * 
     * @param t             An array of MmgBmp instances to use as the frames for this class.
     * @param Position      An MmgVector2 class instance to use the position information for this class.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSprite(MmgBmp[] t, MmgVector2 Position) {
        super();
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
    
    /**
     * Constructor that sets the value of the sprite frames based on an array of MmgBmp instances.
     * 
     * @param t         An array of MmgBmp instances to use as the frames for this class.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSprite(MmgBmp[] t) {
        super();
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
    
    /**
     * Constructor that sets the value of the class attributes based on the attributes
     * of the given argument.
     * 
     * @param obj       The MmgSprite object to base our class off of.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSprite(MmgSprite obj) {
        super();
        SetFrameTime(obj.GetFrameTime());
        SetPrevFrameTime(obj.GetPrevFrameTime());
        SetRotation(obj.GetRotation());

        if (obj.GetOrigin() == null) {
            SetOrigin(obj.GetOrigin());
        } else {
            SetOrigin(obj.GetOrigin().Clone());
        }

        if (obj.GetScaling() == null) {
            SetScaling(obj.GetScaling());
        } else {
            SetScaling(obj.GetScaling().Clone());
        }

        if (obj.GetSrcRect() == null) {
            SetSrcRect(obj.GetSrcRect());
        } else {
            SetSrcRect(obj.GetSrcRect().Clone());
        }

        if (obj.GetDstRect() == null) {
            SetDstRect(obj.GetDstRect());
        } else {
            SetDstRect(obj.GetDstRect().Clone());
        }

        MmgBmp[] a = obj.GetBmpArray();
        int len = a.length;        
        MmgBmp[] b = new MmgBmp[len];
        for(int i = 0; i < len; i ++) {
            b[i] = a[i].CloneTyped();
        }
        SetBmpArray(b);

        if (obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
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

    /**
     * Gets the current frame time.
     * 
     * @return      The current frame time.
     */
    public long GetFrameTime() {
        return frameTime;
    }

    /**
     * Sets the current frame time.
     * 
     * @param l     The current frame time.
     */
    public void SetFrameTime(long l) {
        frameTime = l;
    }

    /**
     * Gets the previous frame time.
     * 
     * @return      The previous frame time.
     */
    public long GetPrevFrameTime() {
        return prevFrameTime;
    }

    /**
     * Sets the previous frame time.
     * 
     * @param l     The previous frame time.
     */
    public void SetPrevFrameTime(long l) {
        prevFrameTime = l;
    }
    
    /**
     * Sets the event id to use when the frame change event is fired.
     * 
     * @param i     The event id to use when the frame change event is called.
     */
    public void SetFrameChangeEventId(int i) {
        if(frameChange != null) {
            frameChange.SetEventId(i);
        }
    }
    
    /**
     * Gets the event handler to use when the sprite frame changes.
     * 
     * @return      The event handler to use when the frame changes.
     */
    public MmgEventHandler GetOnFrameChange() {
        return onFrameChange;
    }

    /**
     * Sets the event handler to use when the sprite frame changes.
     * 
     * @param e     The event handler to use when the frame changes.
     */
    public void SetOnFrameChange(MmgEventHandler e) {
        onFrameChange = e;
    }

    /**
     * Gets a boolean indicating if this class uses simple rendering, no rotation or advanced
     * adjustment of the MmgBmp frames.
     * 
     * @return      A boolean indicating if this class should use simple rendering.
     */
    public boolean GetSimpleRendering() {
        return simpleRendering;
    }

    /**
     * Sets a boolean indicating if this class uses simple rendering, no rotation or advanced
     * adjustment of the MmgBmp frames.
     * 
     * @param s     A boolean indicating if this class should use simple rendering.
     */
    public void SetSimpleRendering(boolean s) {
        simpleRendering = s;
    }

    /**
     * Gets if this MmgSprite is timer only.
     * 
     * @return      A boolean indicating if this class is timer only.
     */
    public boolean GetTimerOnly() {
        return timerOnly;
    }

    /**
     * Sets if the MmgSprite is timer only.
     * 
     * @param b     A boolean value to use to set if it's timer only.
     */
    public void SetTimerOnly(boolean b) {
        timerOnly = b;
    }

    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgSprite(this);
    }

    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override
    public MmgSprite CloneTyped() {
        return new MmgSprite(this);
    }    
    
    /**
     * Gets the current frame of this MmgSprite object.
     * 
     * @return      The MmgBmp of the current frame.
     */
    public MmgBmp GetCurrentFrame() {
        return b[frameIdx];
    }
    
    /**
     * Sets the current frame of this MmgSrpite object.
     * 
     * @param bmp   The MmgBmp to set the current frame.
     */
    public void SetCurrentFrame(MmgBmp bmp) {
        b[frameIdx] = bmp;
    }
    
    /**
     * Gets the MmgBmp frames of this class.
     * 
     * @return      The MmgBmp frames of this class.
     */
    public MmgBmp[] GetBmpArray() {
        return b;
    }

    /**
     * Sets the MmgBmp frames of this class.
     * 
     * @param d      The MmgBmp frames of this class.
     */
    public void SetBmpArray(MmgBmp[] d) {
        b = d;
        if(b != null && b.length >= 1) {
            SetWidth(b[0].GetWidth());
            SetHeight(b[0].GetHeight());
            frameStart = 0;
            frameStop = b.length - 1;
            frameIdx = 0;
        }        
    }

    /**
     * Gets the drawing source rectangle.
     * 
     * @return      The drawing source rectangle.
     */
    public MmgRect GetSrcRect() {
        return srcRect;
    }

    /**
     * Sets the drawing source rectangle.
     * 
     * @param r     The drawing source rectangle.
     */
    public void SetSrcRect(MmgRect r) {
        srcRect = r;
    }

    /**
     * Gets the drawing destination rectangle.
     * 
     * @return      The drawing destination rectangle.
     */
    public MmgRect GetDstRect() {
        return dstRect;
    }

    /**
     * Sets the drawing destination rectangle.
     * 
     * @param r     The drawing destination rectangle.
     */
    public void SetDstRect(MmgRect r) {
        dstRect = r;
    }
    
    /**
     * Gets the rotation of the sprite.
     * 
     * @return      The rotation of the sprite.
     */
    public float GetRotation() {
        return rotation;
    }

    /**
     * Sets the rotation of the sprite.
     * 
     * @param r     The rotation of the sprite.
     */
    public void SetRotation(float r) {
        rotation = r;
    }

    /**
     * Gets the drawing origin vector.
     * 
     * @return      The drawing origin vector.
     */
    public MmgVector2 GetOrigin() {
        return origin;
    }

    /**
     * Sets the drawing origin vector.
     * 
     * @param v     The drawing origin vector.
     */
    public void SetOrigin(MmgVector2 v) {
        origin = v;
    }

    /**
     * Gets the drawing scaling vector.
     * 
     * @return      The drawing scaling vector.
     */
    public MmgVector2 GetScaling() {
        return scaling;
    }

    /**
     * Sets the drawing scaling vector.
     * 
     * @param v     The drawing scaling vector.
     */
    public void SetScaling(MmgVector2 v) {
        scaling = v;
    }

    /**
     * Gets the frame index.
     * 
     * @return      The frame index.
     */
    public int GetFrameIdx() {
        return frameIdx;
    }

    /**
     * Sets the frame index.
     * 
     * @param f     The frame index.
     */
    public void SetFrameIdx(int f) {
        frameIdx = f;
    }

    /**
     * Checks to see if the sprite frame is null.
     * 
     * @param i     The index of the frame to check.
     * @return      A boolean indicating if the frame is null.
     */
    public boolean IsFrameNull(int i) {
        if(i >= 0 && i < b.length) {
            if(b != null && b[i] != null) {
                return false;
            }
        }
        return true;
    }
    
    /**
     * Gets the frame start index.
     * 
     * @return      The frame start index.
     */
    public int GetFrameStart() {
        return frameStart;
    }
    
    /**
     * Sets the frame start index.
     * 
     * @param f     The frame start index.
     */
    public void SetFrameStart(int f) {
        frameStart = f;
    }
    
    /**
     * Gets the frame stop index.
     * 
     * @return      The frame stop index.
     */
    public int GetFrameStop() {
        return frameStop;
    }

    /**
     * Sets the frame stop index.
     * 
     * @param f     The frame stop index.
     */
    public void SetFrameStop(int f) {
        frameStop = f;
    }
    
    /**
     * Gets the milliseconds per frame.
     * 
     * @return      The milliseconds per frame.
     */
    public long GetMsPerFrame() {
        return msPerFrame;
    }

    /**
     * Sets the milliseconds per frame.
     * 
     * @param f     The milliseconds per frame.
     */
    public void SetMsPerFrame(long f) {
        msPerFrame = f;
    }

    /**
     * Draw this object.
     * 
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            if (b[frameIdx] != null) {
                if(simpleRendering == true) {
                    p.DrawBmp(b[frameIdx], GetPosition());
                } else {
                    if(srcRect == null || dstRect == null) {
                        if(origin == null) {
                            if(rotation == 0.0) {
                                p.DrawBmp(b[frameIdx], GetPosition());
                            } else {
                                p.DrawBmp(b[frameIdx], GetPosition(), GetRotation());
                            }
                        } else {
                            p.DrawBmp(b[frameIdx], GetPosition(), GetOrigin(), GetRotation());
                        }
                    } else{
                        if(origin == null) {
                            if(scaling == null) {
                                p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), MmgVector2.GetUnitVec(), MmgVector2.GetOriginVec(), GetRotation());
                            } else {
                                p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), GetScaling(), MmgVector2.GetOriginVec(), GetRotation());                                
                            }
                        } else {
                            if(scaling == null) {
                                p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), MmgVector2.GetUnitVec(), GetOrigin(), GetRotation());
                            } else {
                                p.DrawBmp(b[frameIdx], GetPosition(), GetSrcRect(), GetDstRect(), GetScaling(), GetOrigin(), GetRotation());                                
                            }
                        }
                    }
                }
            }
        }
    }

    /**
     * Update the current sprite animation frame index.
     * 
     * @param updateTick            The index of the MmgUpdate call.
     * @param currentTimeMs         The current time in milliseconds of the MmgUpdate call.
     * @param msSinceLastFrame      The number of milliseconds since the last MmgUpdate call.
     * @return                      A boolean flag indicating if any work was done.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = false;
        
        if (isVisible == true) {
            prevFrameTime = frameTime;
            frameTime += msSinceLastFrame;
            if(frameTime >= msPerFrame || prevFrameTime == -1) {
                if(onFrameChange != null) {
                    onFrameChange.MmgHandleEvent(frameChange);
                }

                if(timerOnly == false) {
                    frameIdx++;
                    if (frameIdx > frameStop) {
                        frameIdx = frameStart;
                    }
                    frameTime = 0;
                    
                }else{
                    frameTime = 0;
                    
                }
                
                lret = true;
            }
        }
        
        return lret;
    }
    
    /**
     * A method used to check the equality of this MmgSprite when compared to another MmgSprite.
     * Compares object fields to determine equality.
     * 
     * @param obj     The MmgSprite object to compare to.
     * @return      A boolean indicating if the two objects are equal or not.
     */    
    public boolean ApiEquals(MmgSprite obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)                
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
        ) {
            ret = true;            
            if(obj.GetBmpArray() == null && GetBmpArray() == null) {
                ret = true;
            } else if(obj.GetBmpArray() != null && GetBmpArray() != null) {
                int len1 = obj.GetBmpArray().length;
                int len2 = GetBmpArray().length;
                                
                if(len1 != len2) {
                    ret = false;
                } else {
                    for(int i = 0; i < len1; i++) {                        
                        if(!((obj.GetBmpArray()[i] == null && GetBmpArray()[i] == null) || (obj.GetBmpArray()[i] != null && GetBmpArray()[i] != null && obj.GetBmpArray()[i].ApiEquals(GetBmpArray()[i])))) {
                            ret = false;
                            break;
                        }
                    }
                }
            } else {
                ret = false;
            }
        }
        return ret;        
    }
}