package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that provides tween support to an underlying MmgObj instance. 
 * Created by Middlemind Games 12/01/2016
 *
 * @author Victor G. Brusca
 */
public class MmgSizeTween extends MmgObj {

    /**
     * An event id indicating the MmgSizeTween has reached the finish.
     */
    public static int MMG_SIZE_TWEEN_REACH_FINISH = 0;
    
    /**
     * An event id indicating the MmgSizeTween has reached the start.
     */
    public static int MMG_SIZE_TWEEN_REACH_START = 1;
    
    /**
     * An event type id for the MmgSizeTween finish event.
     */
    public static int MMG_SIZE_TWEEN_REACH_FINISH_TYPE = 0;
    
    /**
     * An event type if for the MmgSizeTween start event.
     */
    public static int MMG_SIZE_TWEEN_REACH_START_TYPE = 1;
    
    /**
     * The subject of this size tween.
     */
    private MmgObj subj;
    
    /**
     * A copy of the subj MmgObj in its original state to prevent resizing a resized image.
     */
    private MmgObj subjOrig;
    
    /**
     * A boolean indicating the tween is at the start position.
     */
    private boolean atStart;
    
    /**
     * A boolean indicating the tween is at the finish position.
     */
    private boolean atFinish;
    
    /**
     * An MmgVector2 that holds the size to change in X, Y values.
     */
    private MmgVector2 pixelSizeToChange;
    
    /**
     * A float indicating the milliseconds allowed to scale to the specified size.
     */
    private float msSizeToChange;
    
    /**
     * The pixels per millisecond to scale on the X axis.
     */
    private float pixelsPerMsToChangeX;
    
    /**
     * The pixels per millisecond to scale on the Y axis.
     */
    private float pixelsPerMsToChangeY;
    
    /**
     * An MmgVector2 that holds the start size.
     */
    private MmgVector2 startSize;
    
    /**
     * An MmgVector2 that holds the finish size.
     */
    private MmgVector2 finishSize;
    
    /**
     * A boolean indicating the direction to scale, start to finish or finish to start.
     */
    private boolean dirStartToFinish;
    
    /**
     * A boolean indicating if the object is changing.
     */
    private boolean changing;
    
    /**
     * A long value that determines how long to wait before scaling.
     */
    private long msStartChange;
    
    /**
     * A temporary class field used to calculate a new MmgVector2 with scaling information.
     */
    private MmgVector2 tmpV;
    
    /**
     * An event handler for the reach finish event.
     */
    private MmgEventHandler onReachFinish;
    
    /**
     * An event handler for the reach start event.
     */
    private MmgEventHandler onReachStart;
        
    /**
     * An event handler to resize the MmgObj subject to the specified size.
     */
    private MmgScaleHandler onSubjScale;
    
    /**
     * An event template for the reach finish event.
     */
    private MmgEvent reachFinish = new MmgEvent(null, "reach_finish", MmgSizeTween.MMG_SIZE_TWEEN_REACH_FINISH, MmgSizeTween.MMG_SIZE_TWEEN_REACH_FINISH_TYPE, null, null);
    
    /**
     * An event template for the reach start event.
     */
    private MmgEvent reachStart = new MmgEvent(null, "reach_start", MmgSizeTween.MMG_SIZE_TWEEN_REACH_START, MmgSizeTween.MMG_SIZE_TWEEN_REACH_START_TYPE, null, null);

    /**
     * A private boolean flag for the MmgUpdate method indicating if any work was done.
     */
    private boolean lret;    
    
    /**
     * A basic constructor for the MmgSizeTween object.
     * 
     * @param subj                  The MmgObj that is the subject of the tween.
     * @param msTimeToChange        The number of milliseconds to scale the object.
     * @param startSize             The start size of the tween.
     * @param finishSize            The finish size of the tween.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSizeTween(MmgObj subj, float msTimeToChange, MmgVector2 startSize, MmgVector2 finishSize) {
        super();
        SetSubj(subj);
        SetSubjOrig(subj);
        SetPixelSizeToChange(new MmgVector2((finishSize.GetX() - startSize.GetX()), (finishSize.GetY() - startSize.GetY())));
        SetMsTimeToChange(msTimeToChange);
        SetPixelsPerMsToChangeX((GetPixelSizeToChange().GetX() / (float) msTimeToChange));
        SetPixelsPerMsToChangeY((GetPixelSizeToChange().GetY() / (float) msTimeToChange));
        SetStartSize(startSize);
        SetFinishSize(finishSize);
        SetWidth(startSize.GetX());
        SetHeight(startSize.GetY());
        SetDirStartToFinish(true);
        SetAtStart(true);
        SetAtFinish(false);
        SetChanging(false);
    }

    /**
     * A constructor that is based on the an instance of the MmgSizeTween object.
     * 
     * @param obj       An MmgSizeTween object used to create an new instance of the MmgSizeTween class.
     */
    public MmgSizeTween(MmgSizeTween obj) {        
        super();
        if(obj.GetSubj() == null) {
            SetSubj(obj.GetSubj());
        } else {
            SetSubj(obj.GetSubj().Clone());
        }
        
        if(obj.GetSubjOrig() == null) {
            SetSubjOrig(obj.GetSubjOrig());
        } else {
            SetSubjOrig(obj.GetSubjOrig().Clone());
        }        
        
        SetAtStart(obj.GetAtStart());
        SetAtFinish(obj.GetAtFinish());
        
        if(obj.GetPixelSizeToChange() == null) {
            SetPixelSizeToChange(obj.GetPixelSizeToChange());
        } else {
            SetPixelSizeToChange(obj.GetPixelSizeToChange().Clone());
        }
        
        SetMsTimeToChange(obj.GetMsTimeToChange());
        SetPixelsPerMsToChangeX(obj.GetPixelsPerMsToChangeX());
        SetPixelsPerMsToChangeY(obj.GetPixelsPerMsToChangeY());
        
        if(obj.GetStartSize() == null) {
            SetStartSize(obj.GetStartSize());
        } else {
            SetStartSize(obj.GetStartSize().Clone());            
        }
        
        if(obj.GetFinishSize() == null) {
            SetFinishSize(obj.GetFinishSize());
        } else {
            SetFinishSize(obj.GetFinishSize().Clone());            
        }    
        
        SetDirStartToFinish(obj.GetDirStartToFinish());
        SetChanging(obj.GetChanging());
        SetMsStartChange(obj.GetMsStartChange());
        SetOnReachStart(obj.GetOnReachStart());
        SetOnReachFinish(obj.GetOnReachFinish());        
    }    
    
    /**
     * Gets the finish event id.
     * 
     * @return      The finish event id.
     */
    public int GetFinishEventId() {
        return reachFinish.GetEventId();
    }
    
    /**
     * Sets the finish event id.
     * 
     * @param i     The finish event id.
     */
    public void SetFinishEventId(int i) {
        if (reachFinish != null) {
            reachFinish.SetEventId(i);
        }
    }

    /**
     * Sets the start event id.
     * 
     * @param i     The start event id.
     */
    public void SetStartEventId(int i) {
        if (reachStart != null) {
            reachStart.SetEventId(i);
        }
    }

    /**
     * Gets the finish event id.
     * 
     * @return      The finish event id.
     */
    public int GetStartEventId() {
        return reachStart.GetEventId();
    }
    
    /**
     * Sets the resizing handler.
     * 
     * @param o     The resizing handler.
     */
    public void SetOnSubjScale(MmgScaleHandler o) {
        onSubjScale = o;
    }
    
    /**
     * Gets the resizing handler.
     * 
     * @return      The resizing handler. 
     */
    public MmgScaleHandler GetOnSubjScale() {
        return onSubjScale;
    }
    
    /**
     * Gets the original subject.
     * 
     * @return      The original subject.
     */
    public MmgObj GetSubjOrig() {
        return subjOrig;
    }
    
    /**
     * Sets the original subject.
     * 
     * @param o     The original subject.
     */
    public void SetSubjOrig(MmgObj o) {
        subjOrig = o;
    }
    
    /**
     * Gets the on reach finish event handler.
     * 
     * @return      The on reach finish event handler.
     */
    public MmgEventHandler GetOnReachFinish() {
        return onReachFinish;
    }

    /**
     * Sets the on reach finish event handler.
     * 
     * @param o     The on reach finish event handler. 
     */
    public void SetOnReachFinish(MmgEventHandler o) {
        onReachFinish = o;
    }

    /**
     * Gets the on reach start event handler.
     * 
     * @return      The on reach start event handler.
     */
    public MmgEventHandler GetOnReachStart() {
        return onReachStart;
    }

    /**
     * Sets the on reach start event handler.
     * 
     * @param o     The on reach start event handler.
     */
    public void SetOnReachStart(MmgEventHandler o) {
        onReachStart = o;
    }

    /**
     * Gets the milliseconds to wait before starting the scaling.
     * 
     * @return      The milliseconds to wait before starting the scaling.
     */
    public long GetMsStartChange() {
        return msStartChange;
    }

    /**
     * Sets the milliseconds to wait before starting the scaling.
     * 
     * @param l     The milliseconds to wait before starting the scaling.
     */
    public void SetMsStartChange(long l) {
        msStartChange = l;
    }

    /**
     * Gets the pixels per millisecond to scale on the X axis.
     * 
     * @return      The pixels per millisecond to scale on the X axis.
     */
    public float GetPixelsPerMsToChangeX() {
        return pixelsPerMsToChangeX;
    }

    /**
     * Sets the pixels per millisecond to scale on the X axis.
     * 
     * @param i     The pixels per millisecond to scale on the X axis.
     */
    public void SetPixelsPerMsToChangeX(float i) {
        pixelsPerMsToChangeX = i;
    }

    /**
     * Gets the pixels per millisecond to scale on the Y axis.
     * 
     * @return      The pixels per millisecond to scale on the Y axis.
     */
    public float GetPixelsPerMsToChangeY() {
        return pixelsPerMsToChangeY;
    }

    /**
     * Sets the pixels per millisecond to scale on the Y axis.
     * 
     * @param i     The pixels per millisecond to scale on the Y axis.
     */
    public void SetPixelsPerMsToChangeY(float i) {
        pixelsPerMsToChangeY = i;
    }

    /**
     * Gets a boolean indicating if the subject is scaling.
     * 
     * @return      A boolean indicating if the subject is scaling.
     */
    public boolean GetChanging() {
        return changing;
    }

    /**
     * Sets a boolean indicating if the subject is scaling.
     * 
     * @param b     A boolean indicating if the subject is scaling.
     */
    public void SetChanging(boolean b) {
        changing = b;
    }

    /**
     * Gets a boolean indicating the direction of the tween movement, start to finish or finish to start.
     * 
     * @return      A boolean indicating the direction of the tween movement.
     */
    public boolean GetDirStartToFinish() {
        return dirStartToFinish;
    }

    /**
     * Sets a boolean indicating the direction of the tween movement, start to finish or finish to start.
     * 
     * @param b     A boolean indicating the direction of the tween movement.
     */
    public void SetDirStartToFinish(boolean b) {
        dirStartToFinish = b;
    }

    /**
     * Gets the start size of the size tween.
     * 
     * @return      The start size of the size tween.
     */
    public MmgVector2 GetStartSize() {
        return startSize;
    }

    /**
     * Sets the start size of the size tween.
     * 
     * @param v     The start size of the size tween.
     */    
    public void SetStartSize(MmgVector2 v) {
        startSize = v;
    }

    /**
     * Gets the finish size of the size tween.
     * 
     * @return      The finish size of the size tween.
     */    
    public MmgVector2 GetFinishSize() {
        return finishSize;
    }

    /**
     * Sets the finish size of the size tween.
     * 
     * @param v     The finish size of the size tween.
     */    
    public void SetFinishSize(MmgVector2 v) {
        finishSize = v;
    }

    /**
     * Gets the pixel size to scale on the X and Y axis.
     * 
     * @return      The pixel size to scale on the X and Y axis.
     */    
    public MmgVector2 GetPixelSizeToChange() {
        return pixelSizeToChange;
    }

    /**
     * Sets the pixel size to scale on the X and Y axis.
     * 
     * @param v     The pixel size to scale on the X and Y axis.
     */    
    public void SetPixelSizeToChange(MmgVector2 v) {
        pixelSizeToChange = v;
    }

    /**
     * Gets the millisecond time to complete the scaling.
     * 
     * @return      The millisecond time to complete the scaling.
     */    
    public float GetMsTimeToChange() {
        return msSizeToChange;
    }

    /**
     * Sets the millisecond time to complete the scaling.
     * 
     * @param i     The millisecond time to complete the scaling.
     */    
    public void SetMsTimeToChange(float i) {
        msSizeToChange = i;
    }

    /**
     * Sets a boolean indicating that the tween is at the start size.
     * 
     * @param b     A boolean indicating that the tween is at the start size.
     */    
    public void SetAtStart(boolean b) {
        atStart = b;
    }

    /**
     * Gets a boolean indicating that the tween is at the start size.
     * 
     * @return      A boolean indicating that the tween is at the start size.
     */    
    public boolean GetAtStart() {
        return atStart;
    }

    /**
     * Sets a boolean indicating that the tween is at the finish size.
     * 
     * @param b     A boolean indicating that the tween is at the finish size.
     */     
    public void SetAtFinish(boolean b) {
        atFinish = b;
    }

    /**
     * Gets a boolean indicating that the tween is at the finish size.
     * 
     * @return      A boolean indicating that the tween is at the finish size.
     */     
    public boolean GetAtFinish() {
        return atFinish;
    }

    /**
     * Sets the subject of the size tween.
     * 
     * @param b     The subject of the size tween.
     */    
    public void SetSubj(MmgObj b) {
        subj = b;
    }

    /**
     * Gets the subject of the size tween.
     * 
     * @return      The subject of the size tween.
     */    
    public MmgObj GetSubj() {
        return subj;
    }

    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgSizeTween(this);
    }

    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override
    public MmgSizeTween CloneTyped() {
        return new MmgSizeTween(this);
    }    
    
    /**
     * The base drawing method for the bitmap object.
     *
     * @param p     The MmgPen used to draw this bitmap.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            subj.MmgDraw(p);
        }
    }

     /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick            The update tick number. 
     * @param currentTimeMs         The current time in the game in milliseconds.
     * @param msSinceLastFrame      The number of milliseconds between the last frame and this frame.
     * @return                      A boolean indicating if any work was done this game frame.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = false;

        if (isVisible == true) {
            if (GetChanging() == true) {
                if (GetDirStartToFinish() == true) {
                    //changing start to finish
                    if ((currentTimeMs - msStartChange) >= msSizeToChange) {
                        SetAtFinish(true);
                        SetAtStart(false);
                        SetChanging(false);
                        SetWidth(finishSize.GetX());
                        SetHeight(finishSize.GetY()); 
                        
                        if(onSubjScale != null) {
                            onSubjScale.MmgHandleScale(finishSize, subjOrig);
                        }
                        
                        if (onReachFinish != null) {
                            onReachFinish.MmgHandleEvent(reachFinish);
                        }
                        
                        lret = true;
                    } else {
                        tmpV = new MmgVector2(startSize.GetX() + (pixelsPerMsToChangeX * (currentTimeMs - msStartChange)), startSize.GetY() + (pixelsPerMsToChangeY * (currentTimeMs - msStartChange)));
                        SetWidth(tmpV.GetX());
                        SetHeight(tmpV.GetY());
                        
                        if(onSubjScale != null) {
                            onSubjScale.MmgHandleScale(tmpV, subjOrig);
                        }                        
                        
                        lret = true;
                    }

                } else {
                    //changing finish to start
                    if ((currentTimeMs - msStartChange) >= msSizeToChange) {
                        SetAtFinish(false);
                        SetAtStart(true);
                        SetChanging(false);
                        SetWidth(startSize.GetX());
                        SetHeight(startSize.GetY());
                        
                        if(onSubjScale != null) {
                            onSubjScale.MmgHandleScale(startSize, subjOrig);
                        }                         
                        
                        if (onReachStart != null) {
                            onReachStart.MmgHandleEvent(reachStart);
                        }
                        
                        lret = true;
                    } else {
                        tmpV = new MmgVector2(finishSize.GetX() - (pixelsPerMsToChangeX * (currentTimeMs - msStartChange)), finishSize.GetY() - (pixelsPerMsToChangeY * (currentTimeMs - msStartChange)));
                        SetWidth(tmpV.GetX());
                        SetHeight(tmpV.GetY());
                        
                        if(onSubjScale != null) {
                            onSubjScale.MmgHandleScale(tmpV, subjOrig);
                        }                                                
                        
                        lret = true;
                    }
                }
            }
        }

        return lret;
    }

    /**
     * Gets the width of the subject.
     * 
     * @return      The width of the subject.
     */    
    @Override
    public int GetWidth() {
        return subj.GetWidth();
    }

    /**
     * Sets the width of this subject.
     * 
     * @param w     The width of the subject.
     */    
    @Override
    public void SetWidth(int w) {
        super.SetWidth(w);
        subj.SetWidth(w);
    }

    /**
     * Gets the height of the subject.
     * 
     * @return      The height of the subject.
     */    
    @Override
    public int GetHeight() {
        return subj.GetHeight();
    }

    /**
     * Sets the height of the subject.
     * 
     * @param h     The height of the subject.
     */    
    @Override
    public void SetHeight(int h) {
        super.SetHeight(h);
        subj.SetHeight(h);
    }

    /**
     * Gets the position of this object.
     * 
     * @return      The position of the subject.
     */    
    @Override
    public MmgVector2 GetPosition() {
        return subj.GetPosition();
    }

    /**
     * Sets the position of this object's subject.
     * 
     * @param x     The X coordinate of the subject's position.
     * @param y     The Y coordinate of the subject's position.
     */
    @Override
    public void SetPosition(int x, int y) {
        super.SetPosition(x, y);
        subj.SetPosition(x, y);
    }    
    
    /**
     * Sets the position of this object's subject.
     * 
     * @param v     The position of the subject.
     */    
    @Override
    public void SetPosition(MmgVector2 v) {
        subj.SetPosition(v);
    }

    /**
     * Sets the size of the subject.
     * 
     * @param v     The desired size of the subject represented as an MmgVector2.
     */
    public void SetSize(MmgVector2 v) {
        subj.SetWidth(v.GetX());
        subj.SetHeight(v.GetY());
    }
    
    /**
     * A method used to check the equality of this MmgPositionTween when compared to another MmgPositionTween.
     * Compares object fields to determine equality.
     * 
     * @param obj     The MmgPositionTween object to compare to.
     * @return      A boolean indicating if the two objects are equal or not.
     */    
    public boolean ApiEquals(MmgSizeTween obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        /*
        if(!(super.Equals((MmgObj)obj))) {
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
        
        if(!(((obj.GetFinishSize() == null && GetFinishSize() == null) || (obj.GetFinishSize() != null && GetFinishSize() != null && obj.GetFinishSize().Equals(GetFinishSize()))))) {
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
        
        if(!(((obj.GetPixelSizeToChange() == null && GetPixelSizeToChange() == null) || (obj.GetPixelSizeToChange() != null && GetPixelSizeToChange() != null && obj.GetPixelSizeToChange().Equals(GetPixelSizeToChange()))))) {
            MmgHelper.wr("MmgSizeTween: PixelsDistToMove not equals!");            
        }
        
        if(!(((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().Equals(GetPosition()))))) {
            MmgHelper.wr("MmgSizeTween: Position not equals!");
        }
        
        if(!(((obj.GetStartSize() == null && GetStartSize() == null) || (obj.GetStartSize() != null && GetStartSize() != null && obj.GetStartSize().Equals(GetStartSize()))))) {
            MmgHelper.wr("MmgSizeTween: StartPosition not equals!");
        }

        if(!(((obj.GetSubj() == null && GetSubj() == null) || (obj.GetSubj() != null && GetSubj() != null && obj.GetSubj().Equals(GetSubj()))))) {
            MmgHelper.wr("MmgSizeTween: Subj not equals!");            
        }
        
        if(!(obj.GetWidth() == GetWidth())) {
            MmgHelper.wr("MmgSizeTween: Width not equals!");
        }        
        */
                
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
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
        ) {
            ret = true;
        }
        return ret;
    }
}