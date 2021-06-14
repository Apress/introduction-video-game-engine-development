package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgDir;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents an MdtObj object that can be pushed..
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtObjPush extends MdtObj {

    /**
     * A boolean indicating if the barrel should break on the first collision after being pushed.
     */
    public boolean breakOnFirst = true;    
        
    /**
     * An MmgSprite that represents the break animation for this object.
     */
    public MmgSprite subjBreaks = null;
    
    /**
     * A boolean flag indicating that the barrel is broken.
     */
    public boolean isBroken = false;
    
    /**
     * A private variable used in internal methods.
     */
    private boolean lret = false;    
    
    /**
     * A boolean indicating that an object has been pushed.
     */
    public boolean isBeingPushed = false;
    
    /**
     * An integer indicating the direction the object has been pushed in.
     */
    public int pushDir = MmgDir.DIR_NONE;
    
    /**
     * An integer representing the speed used to move a pushed object.
     */
    public int pushSpeed = ScreenGame.GetSpeedPerFrame(280);
    
    /**
     * A value indicating which player pushed the object.
     */
    public MdtPlayerType pushedBy;    
    
    /**
     * A rectangle representing the current size and position of this object.
     */
    public MmgRect current = null;
    
    /**
     * The game screen this MdtChar belongs to.
     */
    public ScreenGame screen = null;
    
    /**
     * An MdtBase object instance used in determining collisions.
     */
    public MdtBase coll = null;    
    
    /**
     * A basic class constructor that takes no arguments.
     */
    public MdtObjPush() {
        
    }
    
    /**
     * An advanced constructor for the MdtObjPush class that takes arguments for the values of pertinent class fields.
     * 
     * @param Subj          An MmgBmp object instance used to display the current object.
     * @param SubjBreaks    An MmgSprite object instance used to display the current object's breaking animation.
     * @param ObjType       The object type of the current object.
     * @param ObjSubType    The object sub-type of the current object.
     * @param Screen        The game screen that this object belongs to.
     */
    public MdtObjPush(MmgBmp Subj, MmgSprite SubjBreaks, MdtObjType ObjType, MdtObjSubType ObjSubType, ScreenGame Screen) {
        super(Subj, ObjType, ObjSubType);
        SetScreen(Screen);
        SetSubjBreaks(SubjBreaks);
    }

    /**
     * Gets a boolean indicating if this object should break on the first collision.
     * 
     * @return      A boolean indicating if this object should break on the first collision. 
     */
    public boolean GetBreakOnFirst() {
        return breakOnFirst;
    }

    /**
     * Sets a boolean indicating if this object should break on the first collision.
     * 
     * @param b     A boolean indicating if this object should break on the first collision. 
     */
    public void SetBreakOnFirst(boolean b) {
        breakOnFirst = b;
    }

    /**
     * Gets an MdtPlayerType value indicating which player type pushed this object.
     * 
     * @return      An MdtPlayerType value indicating which player type pushed this object.
     */
    public MdtPlayerType GetPushedBy() {
        return pushedBy;
    }

    /**
     * Sets an MdtPlayerType value indicating which player type pushed this object.
     * 
     * @param p     An MdtPlayerType value indicating which player type pushed this object.
     */
    public void SetPushedBy(MdtPlayerType p) {
        pushedBy = p;
    }

    /**
     * Gets the game screen this object belongs to.
     * 
     * @return      The game screen this object belongs to. 
     */
    public ScreenGame GetScreen() {
        return screen;
    }

    /**
     * Sets the game screen this object belongs to.
     * 
     * @param o     The game screen this object belongs to. 
     */
    public void SetScreen(ScreenGame o) {
        screen = o;
    }    
    
    /**
     * Gets the direction this object has been pushed in.
     * 
     * @return      The direction this object has been pushed in.
     */
    public int GetPushDir() {
        return pushDir;
    }

    /**
     * Sets the direction this object has been pushed in.
     * 
     * @param i       The direction this object has been pushed in.
     */
    public void SetPushDir(int i) {
        pushDir = i;
    }

    /**
     * Gets the speed this object moves when pushed.
     * 
     * @return      The speed this object moves when pushed.
     */
    public int GetPushSpeed() {
        return pushSpeed;
    }

    /**
     * Sets the speed this object moves when pushed.
     * 
     * @param i     The speed this object moves when pushed.
     */
    public void SetPushSpeed(int i) {
        pushSpeed = i;
    }
    
    /**
     * Gets a boolean indicating if this object has been pushed.
     * 
     * @return      A boolean indicating if this object has been pushed.
     */
    public boolean GetIsBeingPushed() {
        return isBeingPushed;
    }

    /**
     * Sets a boolean indicating if this object has been pushed.
     * 
     * @param b      A boolean indicating if this object has been pushed. 
     */
    public void SetIsBeingPushed(boolean b) {
        isBeingPushed = b;
    }
    
    /**
     * Gets the subject of the class.
     * 
     * @return      The subject of the class.
     */
    @Override
    public MmgBmp GetSubj() {
        return (MmgBmp)subj;
    }

    /**
     * Gets an MmgSprite that is used to show the object has been broken.
     * 
     * @return      An MmgSprite that is used to show the object has been broken.
     */
    public MmgSprite GetSubjBreaks() {
        return subjBreaks;
    }

    /**
     * Sets an MmgSprite that is used to show the object has been broken.
     * 
     * @param s    An MmgSprite that is used to show the object has been broken.
     */
    public void SetSubjBreaks(MmgSprite s) {
        subjBreaks = s;
    }

    /**
     * Gets a boolean indicating if the object is broken.
     * 
     * @return      A boolean indicating if the object is broken.
     */
    public boolean GetIsBroken() {
        return isBroken;
    }

    /**
     * Sets a boolean indicating if the object is broken.
     * 
     * @param b     A boolean indicating if the object is broken. 
     */
    public void SetIsBroken(boolean b) {
        isBroken = b;
    }
        
    /**
     * Sets the position of the object.
     * 
     * @param v         The position of the object. 
     */
    @Override
    public void SetPosition(MmgVector2 v) {
        super.SetPosition(v);
        subj.SetPosition(v);
        subjBreaks.SetPosition(v.GetX() + (subj.GetWidth() - subjBreaks.GetWidth())/2, v.GetY() + (subj.GetHeight() - subjBreaks.GetHeight())/2);
    }
    
    /**
     * Sets the position of the object.
     * 
     * @param x     The X coordinate of the object.
     * @param y     The Y coordinate of the object.
     */
    @Override
    public void SetPosition(int x, int y) {
        super.SetPosition(x, y);
        subj.SetPosition(x, y);
        subjBreaks.SetPosition(x + (subj.GetWidth() - subjBreaks.GetWidth())/2, y + (subj.GetHeight() - subjBreaks.GetHeight())/2);
    }
    
    /**
     * Sets the X coordinate of the object's position.
     * 
     * @param i     The X coordinate of the object. 
     */
    @Override
    public void SetX(int i) {
        super.SetX(i);
        subj.SetX(i);
        subjBreaks.SetX(i + (subj.GetWidth() - subjBreaks.GetWidth())/2);
    }
    
    /**
     * Sets the Y coordinate of the object's position.
     * 
     * @param i      The Y coordinate of the object.
     */
    @Override
    public void SetY(int i) {
        super.SetY(i);
        subj.SetY(i);
        subjBreaks.SetY(i + (subj.GetHeight() - subjBreaks.GetHeight())/2);
    }       
   
    /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick           The update tick number. 
     * @param currentTimeMs         The current time in the game in milliseconds.
     * @param msSinceLastFrame      The number of milliseconds between the last frame and this frame.
     * @return                      A boolean indicating if any work was done this game frame.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = false;
        if (isVisible == true) {            
            if(isBroken) {
                subjBreaks.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                if(subjBreaks.GetFrameIdx() == subjBreaks.GetFrameStop()) {
                    screen.UpdateRemoveObj(this, pushedBy);
                }                                                
            } else {
                subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                
                if(pushDir != MmgDir.DIR_NONE) {
                    current = new MmgRect(subj.GetX(), subj.GetY(), subj.GetY() + subj.GetHeight(), subj.GetX() + subj.GetWidth());                    
                    if(pushSpeed < 0) { 
                        pushSpeed *= -1;
                    }

                    if(isBeingPushed == true) {
                        if(pushDir == MmgDir.DIR_BACK) {
                            if(subj.GetY() - pushSpeed >= ScreenGame.BOARD_TOP) {
                                current.ShiftRect(0, (pushSpeed * -1));
                                coll = screen.CanMove(current, this);
                                if(coll == null) {
                                    SetY(current.GetTop());
                                } else {
                                    if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);                                        
                                    }
                                    
                                    if(coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT) {                                        
                                        if(breakOnFirst) {
                                            isBeingPushed = false;
                                            pushDir = MmgDir.DIR_NONE;
                                            isBroken = true;
                                        } else {
                                            SetY(current.GetTop());
                                        }
                                    } else {
                                        SetY(current.GetTop());
                                    }
                                }
                            } else {
                                SetY(ScreenGame.BOARD_TOP);
                                isBeingPushed = false;
                                pushDir = MmgDir.DIR_NONE;
                                isBroken = true;                               
                            }
                        } else if(pushDir == MmgDir.DIR_FRONT) {
                            if(subj.GetY() + subj.GetHeight() + pushSpeed <= ScreenGame.BOARD_BOTTOM) {
                                current.ShiftRect(0, (pushSpeed * 1));
                                coll = screen.CanMove(current, this);
                                if(coll == null) {
                                    SetY(current.GetTop());
                                } else {
                                    if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);                                        
                                    }
                                    
                                    if(coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT) {                                        
                                        if(breakOnFirst) {
                                            isBeingPushed = false;
                                            pushDir = MmgDir.DIR_NONE;
                                            isBroken = true;
                                        } else {
                                            SetY(current.GetTop());
                                        }
                                    } else {
                                        SetY(current.GetTop());
                                    }
                                }
                            } else {
                                SetY(ScreenGame.BOARD_BOTTOM - subj.GetHeight());
                                isBeingPushed = false;
                                pushDir = MmgDir.DIR_NONE;
                                isBroken = true;                                
                            }
                        } else if(pushDir == MmgDir.DIR_LEFT) {
                            if(subj.GetX() - pushSpeed >= ScreenGame.BOARD_LEFT) {
                                current.ShiftRect((pushSpeed * -1), 0);
                                coll = screen.CanMove(current, this);
                                if(coll == null) {
                                    SetX(current.GetLeft());
                                } else {
                                    if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);                                        
                                    }
                                    
                                    if(coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT) {
                                        if(breakOnFirst) {
                                            isBeingPushed = false;
                                            pushDir = MmgDir.DIR_NONE;                                            
                                            isBroken = true;
                                        } else {
                                            SetX(current.GetLeft()); 
                                        }
                                    } else {
                                        SetX(current.GetLeft());
                                    }
                                }
                            } else {
                                SetX(ScreenGame.BOARD_LEFT);
                                isBeingPushed = false;
                                pushDir = MmgDir.DIR_NONE;
                                isBroken = true;
                            }                        
                        } else if(pushDir == MmgDir.DIR_RIGHT) {
                            if(subj.GetX() + subj.GetWidth() + pushSpeed <= ScreenGame.BOARD_RIGHT) {
                                current.ShiftRect((pushSpeed * 1), 0);
                                coll = screen.CanMove(current, this);
                                if(coll == null) {                                
                                    SetX(current.GetLeft());
                                } else {
                                    if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition().Clone(), GetWidth()/2, GetHeight()/2, pushDir, pushedBy);                                        
                                    }
                                    
                                    if(coll.GetMdtType() == MdtObjType.ENEMY || coll.GetMdtType() == MdtObjType.PLAYER || coll.GetMdtType() == MdtObjType.OBJECT) {
                                        if(breakOnFirst) {
                                            isBeingPushed = false;
                                            pushDir = MmgDir.DIR_NONE;                                            
                                            isBroken = true;
                                        } else {
                                            SetX(current.GetLeft()); 
                                        }
                                    } else {
                                        SetX(current.GetLeft());
                                    }
                                }
                            } else {
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
        
    /**
     * Base draw method, handles drawing this class.
     *
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            if(isBroken) {
                subjBreaks.MmgDraw(p);
            } else {
                subj.MmgDraw(p);
            }
        }
    }    
}