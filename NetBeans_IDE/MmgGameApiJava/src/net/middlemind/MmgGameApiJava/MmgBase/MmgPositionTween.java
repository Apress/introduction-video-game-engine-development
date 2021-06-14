package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that provides tween support to an underlying MmgObj instance.
 * Created by Middlemind Games 12/01/2016
 * 
 * @author Victor G. Brusca
 */
public class MmgPositionTween extends MmgObj {
    
    /**
     * The event id for a position tween finish event. 
     */
    public static int MMG_POSITION_TWEEN_REACH_FINISH = 0;
    
    /**
     * The event id for a position tween start event.
     */
    public static int MMG_POSITION_TWEEN_REACH_START = 1;
    
    /**
     * The event type for a position tween finish event.
     */
    public static int MMG_POSITION_TWEEN_REACH_FINISH_TYPE = 0;
    
    /**
     * The event type for a position tween start event.
     */
    public static int MMG_POSITION_TWEEN_REACH_START_TYPE = 1;
    
    /**
     * The subject of this position tween.
     */
    private MmgObj subj;

    /**
     * A boolean indicating the tween is at the start position.
     */
    private boolean atStart;
    
    /**
     * A boolean indicating the tween is at the finish position.
     */
    private boolean atFinish;
    
    /**
     * An MmgVector2 that holds the distance to move in X, Y values.
     */
    private MmgVector2 pixelDistToMove;
    
    /**
     * A float indicating the time in milliseconds to move the specified distance.
     */
    private float msTimeToMove;
    
    /**
     * The pixels per millisecond to move in the X direction.
     */
    private float pixelsPerMsToMoveX;
    
    /**
     * The pixels per millisecond to move in the Y direction.
     */
    private float pixelsPerMsToMoveY;
    
    /**
     * An MmgVector2 that holds the start position.
     */
    private MmgVector2 startPosition;
    
    /**
     * An MmgVector2 that holds the finish position.
     */
    private MmgVector2 finishPosition;
    
    /**
     * A boolean indicating the direction to move, start to finish or finish to start.
     */
    private boolean dirStartToFinish;
    
    /**
     * A boolean indicating if the object is moving.
     */
    private boolean moving;
    
    /**
     * A long value that that indicates when the movement began.
     */
    private long msStartMove;
    
    /**
     * A temporary class field used to calculate a new MmgVector2 with position information.
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
     * An event template for the reach finish event.
     */
    private MmgEvent reachFinish = new MmgEvent(null, "reach_finish", MmgPositionTween.MMG_POSITION_TWEEN_REACH_FINISH, MmgPositionTween.MMG_POSITION_TWEEN_REACH_FINISH_TYPE, null, null);
    
    /**
     * An event template for the reach start event.
     */
    private MmgEvent reachStart = new MmgEvent(null, "reach_start", MmgPositionTween.MMG_POSITION_TWEEN_REACH_START, MmgPositionTween.MMG_POSITION_TWEEN_REACH_START_TYPE, null, null);
    
    /**
     * A private boolean flag for the MmgUpdate method indicating if any work was done.
     */
    private boolean lret;
    
    /**
     * A basic constructor for the MmgPositionTween object.
     * 
     * @param subj              The MmgObj that is the subject of the tween.
     * @param msTimeToMove      The number of milliseconds to move the object.
     * @param startPos          The start position of the tween.
     * @param finishPos         The finish position of the tween.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgPositionTween(MmgObj subj, float msTimeToMove, MmgVector2 startPos, MmgVector2 finishPos) {
        super();
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
    
    /**
     * A constructor that is based on the an instance of the MmgPositionTween object.
     * 
     * @param obj       An MmgPositionTween object used to create an new instance of the MmgPositionTween class.
     */
    public MmgPositionTween(MmgPositionTween obj) {   
        super();
        if(obj.GetSubj() == null) {
            SetSubj(obj.GetSubj());
        } else {
            SetSubj(obj.GetSubj().Clone());
        }
        
        SetAtStart(obj.GetAtStart());
        SetAtFinish(obj.GetAtFinish());
        
        if(obj.GetPixelDistToMove() == null) {
            SetPixelDistToMove(obj.GetPixelDistToMove());
        } else {
            SetPixelDistToMove(obj.GetPixelDistToMove().Clone());
        }
        
        SetMsTimeToMove(obj.GetMsTimeToMove());
        SetPixelsPerMsToMoveX(obj.GetPixelsPerMsToMoveX());
        SetPixelsPerMsToMoveY(obj.GetPixelsPerMsToMoveY());
        
        if(obj.GetStartPosition() == null) {
            SetStartPosition(obj.GetStartPosition());
        } else {
            SetStartPosition(obj.GetStartPosition().Clone());            
        }
        
        if(obj.GetFinishPosition() == null) {
            SetFinishPosition(obj.GetFinishPosition());
        } else {
            SetFinishPosition(obj.GetFinishPosition().Clone());            
        }    
        
        SetDirStartToFinish(obj.GetDirStartToFinish());
        SetMoving(obj.GetMoving());
        SetMsStartMove(obj.GetMsStartMove());
        SetOnReachStart(obj.GetOnReachStart());
        SetOnReachFinish(obj.GetOnReachFinish());
    }
        
    /**
     * Sets the finish event id.
     * 
     * @param i     The finish event id.
     */
    public void SetFinishEventId(int i) {
        reachFinish.SetEventId(i);
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
     * Sets the start event id.
     * 
     * @param i     The start event id.
     */
    public void SetStartEventId(int i) {
        reachStart.SetEventId(i);
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
     * Gets the milliseconds to wait before starting the movement.
     * 
     * @return      The milliseconds to wait before starting the movement.
     */
    public long GetMsStartMove() {
        return msStartMove;
    }

    /**
     * Sets the milliseconds to wait before starting the movement.
     * 
     * @param l     The milliseconds to wait before starting the movement.
     */
    public void SetMsStartMove(long l) {
        msStartMove = l;
    }
    
    /**
     * Gets the pixels per millisecond to move on the X axis.
     * 
     * @return      The pixels per millisecond to move on the X axis.
     */
    public float GetPixelsPerMsToMoveX() {
        return pixelsPerMsToMoveX;
    }
    
    /**
     * Sets the pixels per millisecond to move on the X axis.
     * 
     * @param i     The pixels per millisecond to move on the X axis.
     */
    public void SetPixelsPerMsToMoveX(float i) {
        pixelsPerMsToMoveX = i;
    }
    
    /**
     * Gets the pixels per millisecond to move on the Y axis.
     * 
     * @return      The pixels per millisecond to move on the Y axis.
     */
    public float GetPixelsPerMsToMoveY() {
        return pixelsPerMsToMoveY;
    }
    
    /**
     * Sets the pixels per millisecond to move on the Y axis.
     * 
     * @param i     The pixels per millisecond to move on the Y axis.
     */
    public void SetPixelsPerMsToMoveY(float i) {
        pixelsPerMsToMoveY = i;
    }
    
    /**
     * Gets a boolean indicating if the subject is moving.
     * 
     * @return      A boolean indicating if the subject is moving.
     */
    public boolean GetMoving() {
        return moving;
    }
    
    /**
     * Sets a boolean indicating if the subject is moving.
     * 
     * @param b     A boolean indicating if the subject is moving.
     */
    public void SetMoving(boolean b) {
        moving = b;
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
     * Gets the start position of the movement tween.
     * 
     * @return      The start position of the movement tween.
     */
    public MmgVector2 GetStartPosition() {
        return startPosition;
    }
    
    /**
     * Sets the start position of the movement tween.
     * 
     * @param v     The start position of the movement tween.
     */
    public void SetStartPosition(MmgVector2 v) {
        startPosition = v;
    }
    
    /**
     * Gets the finish position of the movement tween.
     * 
     * @return      The finish position of the movement tween.
     */
    public MmgVector2 GetFinishPosition() {
        return finishPosition;
    }
    
    /**
     * Sets the finish position of the movement tween.
     * 
     * @param v     The finish position of the movement tween.
     */
    public void SetFinishPosition(MmgVector2 v) {
        finishPosition = v;
    }
    
    /**
     * Gets the pixel distance to move on the X and Y axis.
     * 
     * @return      The pixel distance to move on the X and Y axis.
     */
    public MmgVector2 GetPixelDistToMove() {
        return pixelDistToMove;
    }

    /**
     * Sets the pixel distance to move on the X and Y axis.
     * 
     * @param v     The pixel distance to move on the X and Y axis.
     */
    public void SetPixelDistToMove(MmgVector2 v) {
        pixelDistToMove = v;
    }

    /**
     * Gets the millisecond time to complete the movement.
     * 
     * @return      The millisecond time to complete the movement.
     */
    public float GetMsTimeToMove() {
        return msTimeToMove;
    }

    /**
     * Sets the millisecond time to complete the movement.
     * 
     * @param i     The millisecond time to complete the movement.
     */
    public void SetMsTimeToMove(float i) {
        msTimeToMove = i;
    }
    
    /**
     * Sets a boolean indicating that the tween is at the start position.
     * 
     * @param b     A boolean indicating that the tween is at the start position.
     */
    public void SetAtStart(boolean b) {
        atStart = b;
    }
    
    /**
     * Gets a boolean indicating that the tween is at the start position.
     * 
     * @return      A boolean indicating that the tween is at the start position.
     */
    public boolean GetAtStart() {
        return atStart;
    }
    
    /**
     * Sets a boolean indicating that the tween is at the finish position.
     * 
     * @param b     A boolean indicating that the tween is at the finish position.
     */    
    public void SetAtFinish(boolean b) {
        atFinish = b;
    }
    
    /**
     * Gets a boolean indicating that the tween is at the finish position.
     * 
     * @return      A boolean indicating that the tween is at the finish position.
     */    
    public boolean GetAtFinish() {
        return atFinish;
    }
    
    /**
     * Sets the subject of the movement tween.
     * 
     * @param b     The subject of the movement tween.
     */
    public void SetSubj(MmgObj b) {
        subj = b;
        SetHeight(subj.GetHeight());
        SetWidth(subj.GetWidth());
    }
    
    /**
     * Gets the subject of the movement tween.
     * 
     * @return      The subject of the movement tween.
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
        return (MmgObj) new MmgPositionTween(this);
    }
    
    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override
    public MmgPositionTween CloneTyped() {
        return new MmgPositionTween(this);
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
            if(moving == true) {
                if(dirStartToFinish == true) {
                    //moving start to finish
                    if((currentTimeMs - msStartMove) >= msTimeToMove) {
                        SetAtFinish(true);
                        SetAtStart(false);
                        SetMoving(false);
                        SetPosition(finishPosition);
                        if(onReachFinish != null) {
                            onReachFinish.MmgHandleEvent(reachFinish);
                        }
                        lret = true;
                    }else{
                        tmpV = new MmgVector2(startPosition.GetX() + (pixelsPerMsToMoveX * (currentTimeMs - msStartMove)), startPosition.GetY() + (pixelsPerMsToMoveY * (currentTimeMs - msStartMove)));
                        SetPosition(tmpV);
                        SetAtStart(false);
                        SetAtFinish(false);
                        lret = true;
                    }
                    
                }else {
                    //moving finish to start
                    if((currentTimeMs - msStartMove) >= msTimeToMove) {
                        SetAtFinish(false);
                        SetAtStart(true);
                        SetMoving(false);
                        SetPosition(startPosition);
                        if(onReachStart != null) {
                            onReachStart.MmgHandleEvent(reachStart);
                        }
                        lret = true;
                    }else{
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
     * Gets the height of this object.
     * 
     * @return      The height of this object.
     */
    @Override
    public int GetHeight() {
        return subj.GetHeight();
    }
    
    /**
     * Sets the height of this object.
     * 
     * @param h     The height of this object.
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
        super.SetPosition(v);
        subj.SetPosition(v);
    }

    /**
     * Gets the X coordinate of the subject.
     * 
     * @return      The X coordinate of the subject.
     */
    @Override
    public int GetX() {
        return subj.GetX();
    }

    /**
     * Sets the X coordinate of the subject.
     * 
     * @param i     The X coordinate of the subject. 
     */
    @Override
    public void SetX(int i) {
        super.SetX(i);
        subj.SetX(i);
    }

    /**
     * Gets the Y coordinate of the subject.
     * 
     * @return      The Y coordinate of the subject.
     */    
    @Override
    public int GetY() {
        return subj.GetY();
    }

    /**
     * Sets the y coordinate of the subject.
     * 
     * @param i     The Y coordinate of the subject. 
     */    
    @Override
    public void SetY(int i) {
        super.SetY(i);
        subj.SetY(i);
    }
    
    /**
     * A method used to check the equality of this MmgPositionTween when compared to another MmgPositionTween.
     * Compares object fields to determine equality.
     * 
     * @param obj   The MmgPositionTween object to compare to.
     * @return      A boolean indicating if the two objects are equal or not.
     */
    public boolean ApiEquals(MmgPositionTween obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        /*
        if(!(super.Equals((MmgObj)obj))) {
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
        
        if(!(((obj.GetFinishPosition() == null && GetFinishPosition() == null) || (obj.GetFinishPosition() != null && GetFinishPosition() != null && obj.GetFinishPosition().Equals(GetFinishPosition()))))) {
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
        
        if(!(((obj.GetPixelDistToMove() == null && GetPixelDistToMove() == null) || (obj.GetPixelDistToMove() != null && GetPixelDistToMove() != null && obj.GetPixelDistToMove().Equals(GetPixelDistToMove()))))) {
            MmgHelper.wr("MmgPositionTween: PixelsDistToMove not equals!");            
        }
        
        if(!(((obj.GetPosition() == null && GetPosition() == null) || (obj.GetPosition() != null && GetPosition() != null && obj.GetPosition().Equals(GetPosition()))))) {
            MmgHelper.wr("MmgPositionTween: Position not equals!");
        }
        
        if(!(((obj.GetStartPosition() == null && GetStartPosition() == null) || (obj.GetStartPosition() != null && GetStartPosition() != null && obj.GetStartPosition().Equals(GetStartPosition()))))) {
            MmgHelper.wr("MmgPositionTween: StartPosition not equals!");
        }

        if(!(((obj.GetSubj() == null && GetSubj() == null) || (obj.GetSubj() != null && GetSubj() != null && obj.GetSubj().Equals(GetSubj()))))) {
            MmgHelper.wr("MmgPositionTween: Subj not equals!");            
        }
        
        if(!(obj.GetWidth() == GetWidth())) {
            MmgHelper.wr("MmgPositionTween: Width not equals!");
        }        
        */

        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
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
        ) {
            ret = true;
        }

        return ret;
    }
}