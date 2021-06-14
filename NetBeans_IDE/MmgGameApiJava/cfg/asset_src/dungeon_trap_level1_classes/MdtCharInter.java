package game.jam.DungeonTrap;

import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgDir;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteSheet;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;
import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameType;

/**
 * A class that represents an enemy character base.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtCharInter extends MdtChar {
    
    /**
     * A value indicating what type of player this is, player1 or player2.
     */
    public MdtPlayerType playerType = MdtPlayerType.NONE;    
    
    /**
     * An MmgSprite that represents the break animation for this object.
     */
    public MmgSprite subjBreaks = null;
    
    /**
     * A boolean flag indicating that the enemy has been broken.
     */
    public boolean isBroken = false;    
    
    /**
     * The player that broke the current enemy.
     */
    public MdtPlayerType brokenBy;
        
    /**
     * A boolean indicating if this player is being bounced by a colliding object.
     */
    public boolean isBouncing = false;
    
    /**
     * The original starting direction of the bounce.
     */
    public int bounceDirOrig = 0;
    
    /**
     * The direction to move this player on the X axis in response to the bounce.
     */
    public int bounceDirX = 0;
    
    /**
     * The direction to move this player on the Y axis in response to the bounce.
     */
    public int bounceDirY = 0;
    
    /**
     * The current duration of the bounce, if active, in milliseconds.
     */
    public long bouncingCurrentMs;
    
    /**
     * The total amount of time in milliseconds that the player will bounce.
     */
    public long bouncingLengthMs = 175;
    
    /**
     * The motor type to use for the given character.
     */
    public MdtEnemyMotorType motor = MdtEnemyMotorType.NONE;
    
    /**
     * The time in milliseconds that the current player has been moving in AI mode.
     */
    private long motorMoveMs = 0;
    
    /**
     * The total time in milliseconds that the current player will move in AI mode.
     */
    private long motorMoveLengthMs = 350;
    
    /**
     * The player that this character is targeting for attack.
     */
    private MdtPlayerType targetPlayer = MdtPlayerType.NONE;
    
    /**
     * MdtEnemyDemon constructor that allows you to specify the sprite animation frames for this character, for all directions.
     * 
     * @param Subj              The subject of the object instance.
     * @param FrameFrontS       The front start frame.
     * @param FrameFrontE       The front end frame.
     * @param FrameBackS        The back start frame.
     * @param FrameBackE        The back end frame.
     * @param FrameLeftS        The left start frame.
     * @param FrameLeftE        The left end frame.
     * @param FrameRightS       The right start frame.
     * @param FrameRightE       The right end frame.
     * @param Screen            The game screen this character is on.
     * @param ObjType           The type of this object.
     * @param ObjSubType        The sub-type of this object.
     */
    public MdtCharInter(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen, MdtObjType ObjType, MdtObjSubType ObjSubType) {
        super(Subj, FrameFrontS, FrameFrontE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, FrameBackS, FrameBackE, Screen, ObjType, ObjSubType);
        
        MmgBmp src = MmgHelper.GetBasicCachedBmp("explosion_anim_spritesheet_lg.png");
        MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);        
        subjBreaks = new MmgSprite(ssSrc.GetFrames());
        subjBreaks.SetMsPerFrame(50);
                
        weapons = new Hashtable();
        weapons.put("sword", new MdtWeaponSword(this, MdtWeaponType.SWORD, MdtPlayerType.ENEMY));
        weapons.put("axe", new MdtWeaponAxe(this, MdtWeaponType.AXE, MdtPlayerType.ENEMY));
        weapons.put("spear", new MdtWeaponSpear(this, MdtWeaponType.SPEAR, MdtPlayerType.ENEMY));

        weaponCurrent = weapons.get("spear");
        weaponCurrent.SetHolder(this);
        weaponCurrent.active = true;
    }

    /**
     * A method that causes this player to bounce using directions calculated from the initial collision.
     * 
     * @param collPos       The position of the colliding object that causes the bounce.
     * @param halfWidth     A half width size of the game object that caused the bounce.
     * @param halfHeight    A half height size of the game object that caused the bounce.
     * @param bounceDir     The direction the colliding object was moving in.
     * @param BounceBy      The player type that caused the bounce.
     */
    public void Bounce(MmgVector2 collPos, int halfWidth, int halfHeight, int bounceDir, MdtPlayerType BounceBy) {
        bounceDirOrig = bounceDir;
        isMoving = false;
        
        bouncingCurrentMs = 0;
        isBouncing = true;

        if(bounceDir == MmgDir.DIR_LEFT || bounceDir == MmgDir.DIR_RIGHT) {
            if(collPos.GetY() + halfHeight >= GetY() + GetHeight()/2) {
                bounceDirX = bounceDir;
                bounceDirY = MmgDir.DIR_BACK;
            } else {
                bounceDirX = bounceDir;
                bounceDirY = MmgDir.DIR_FRONT;                
            }
        } else if(bounceDir == MmgDir.DIR_FRONT || bounceDir == MmgDir.DIR_BACK) {
            if(collPos.GetX() + halfWidth >= GetX() + GetWidth()/2) {
                bounceDirX = MmgDir.DIR_LEFT;
                bounceDirY = bounceDir;
            } else {
                bounceDirX = MmgDir.DIR_RIGHT;
                bounceDirY = bounceDir;                
            }            
        }
        
        if(playerType == MdtPlayerType.ENEMY) {
            TakeDamage(1, BounceBy);
        } 
    }

    /**
     * Gets the enemy character's motor type.
     * 
     * @return      The enemy character's motor type. 
     */
    public MdtEnemyMotorType GetMotor() {
        return motor;
    }

    /**
     * Sets the enemy character's motor type.
     * 
     * @param m     The enemy character's motor type.
     */
    public void SetMotor(MdtEnemyMotorType m) {
        motor = m;
    }
     
    /**
     * Gets the type of this player.
     * 
     * @return      The type of this player. 
     */
    public MdtPlayerType GetPlayerType() {
        return playerType;
    }

    /**
     * Sets the type of this player.
     * 
     * @param p     The type of this player. 
     */
    public void SetPlayerType(MdtPlayerType p) {
        playerType = p;
    }    
    
    /**
     * Gets an MmgSprite that is used to show the character has been broken.
     * 
     * @return      An MmgSprite that is used to show the character has been broken.
     */
    public MmgSprite GetSubjBreaks() {
        return subjBreaks;
    }

    /**
     * Sets an MmgSprite that is used to show the character has been broken.
     * 
     * @param s    An MmgSprite that is used to show the character has been broken.
     */
    public void SetSubjBreaks(MmgSprite s) {
        subjBreaks = s;
    }

    /**
     * Gets a boolean indicating if the character is broken.
     * 
     * @return      A boolean indicating if the character is broken.
     */
    public boolean GetIsBroken() {
        return isBroken;
    }

    /**
     * Sets a boolean indicating if the character is broken.
     * 
     * @param b     A boolean indicating if the character is broken. 
     */
    public void SetIsBroken(boolean b) {
        isBroken = b;
    }    

    /**
     * Gets the player that broke this character.
     * 
     * @return      The player that broke this character.
     */
    public MdtPlayerType GetBrokenBy() {
        return brokenBy;
    }

    /**
     * Sets the player that broke this character.
     * 
     * @param p     The player that broke this character.
     */
    public void SetBrokenBy(MdtPlayerType p) {
        brokenBy = p;
    }
    
    /**
     * Gets a boolean indicating if this character is being bounced.
     * 
     * @return      A boolean indicating if this character is being bounced. 
     */
    public boolean GetIsBouncing() {
        return isBouncing;
    }

    /**
     * Sets a boolean indicating if this character is being bounced.
     * 
     * @param b      A boolean indicating if this character is being bounced. 
     */
    public void SetIsBouncing(boolean b) {
        isBouncing = b;
    }

    /**
     * Gets the current time in milliseconds of the current bounce duration.
     * 
     * @return      The current time in milliseconds of the current bounce duration.
     */
    public long GetBouncingCurrentMs() {
        return bouncingCurrentMs;
    }

    /**
     * Sets the current time in milliseconds of the current bounce duration.
     * 
     * @param l     The current time in milliseconds of the current bounce duration. 
     */
    public void SetBouncingCurrentMs(long l) {
        bouncingCurrentMs = l;
    }

    /**
     * Gets the total amount of time in milliseconds that a bounce persists.
     * 
     * @return      The total amount of time in milliseconds that a bounce persists.
     */
    public long GetBouncingLengthMs() {
        return bouncingLengthMs;
    }

    /**
     * Sets the total amount of time in milliseconds that a bounce persists.
     * 
     * @param l     The total amount of time in milliseconds that a bounce persists.
     */
    public void SetBouncingLengthMs(long l) {
        bouncingLengthMs = l;
    }
    
    /**
     * Sets the current character's direction without resetting the current directory.
     * 
     * @param d     The direction in which to set the current character. 
     */
    public void SetDirSafe(int d) {
        if(GetDir() != d) {
            SetDir(d);
        }
    }
    
    /**
     * Sets the current direction of the character.
     * 
     * @param d     The direction code.
     */
    @Override
    public void SetDir(int d) {
        if(d == MmgDir.DIR_FRONT) {
            subj.SetFrameStart(frameFrontStart);
            subj.SetFrameStop(frameFrontStop);
            subj.SetFrameIdx(frameFrontStart);            
        } else if(d == MmgDir.DIR_BACK) {
            subj.SetFrameStart(frameBackStart);
            subj.SetFrameStop(frameBackStop);
            subj.SetFrameIdx(frameBackStart);
        } else if(d == MmgDir.DIR_LEFT) {
            subj.SetFrameStart(frameLeftStart);
            subj.SetFrameStop(frameLeftStop);
            subj.SetFrameIdx(frameLeftStart);
        } else if(d == MmgDir.DIR_RIGHT) {
            subj.SetFrameStart(frameRightStart);
            subj.SetFrameStop(frameRightStop);
            subj.SetFrameIdx(frameRightStart);            
        }
        dir = d;        
    }
   
    /**
     * Sets the position of the character.
     * 
     * @param v     The position to set.
     */
    @Override
    public void SetPosition(MmgVector2 v) {
        super.SetPosition(v);
        subj.SetPosition(v);
        subjBreaks.SetPosition(v.GetX() + (subj.GetWidth() - subjBreaks.GetWidth())/2, v.GetY() + (subj.GetHeight() - subjBreaks.GetHeight())/2);        
    }
    
    /**
     * Sets the position of the character.
     * 
     * @param x     The X coordinate to set.
     * @param y     The Y coordinate to set.
     */
    @Override
    public void SetPosition(int x, int y) {
        super.SetPosition(x, y);
        subj.SetPosition(x, y);
        subjBreaks.SetPosition(x + (subj.GetWidth() - subjBreaks.GetWidth())/2, y + (subj.GetHeight() - subjBreaks.GetHeight())/2);        
    }
    
    /**
     * Sets the X coordinate position of the character.
     * 
     * @param i     The X coordinate to set.
     */
    @Override
    public void SetX(int i) {
        super.SetX(i);
        subj.SetX(i);
        subjBreaks.SetX(i + (subj.GetWidth() - subjBreaks.GetWidth())/2);
    }
    
    /**
     * Sets the Y coordinate position of the character.
     * 
     * @param i     The Y coordinate to set. 
     */
    @Override
    public void SetY(int i) {
        super.SetY(i);
        subj.SetY(i);
        subjBreaks.SetY(i + (subj.GetHeight() - subjBreaks.GetHeight())/2);
    }    
    
    /**
     * Marks this character as receiving damage from the specified character in the specified amount.
     * 
     * @param i     The amount of damage to apply to this character.
     * @param p     The player who applied the damage to this character.
     */
    @Override
    public void TakeDamage(int i, MdtPlayerType p) {
        super.TakeDamage(i, p);
        SetBrokenBy(p);
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
                    if(GetPlayerType() == MdtPlayerType.ENEMY && GetRand().nextInt(11) % 2 == 0) {
                        screen.UpdateGenerateMdtItem(GetX(), GetY());
                    }
                    screen.UpdateRemoveObj(this, brokenBy);
                }                                                
            } else {
                if(healthCurrent <= 0) {
                    isBroken = true;
                }

                subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame); 

                if(!isAttacking) {
                    if(isBouncing) {
                        bouncingCurrentMs += msSinceLastFrame;
                        if(bouncingCurrentMs <= bouncingLengthMs) {
                            current = new MmgRect(subj.GetX(), subj.GetY(), subj.GetY() + subj.GetHeight(), subj.GetX() + subj.GetWidth());                    
                            if(speed < 0) { 
                                speed *= -1;
                            }

                            int nX = 0;
                            int nY = 0;

                            if(bounceDirX == MmgDir.DIR_LEFT) {
                                nX = (speed * -2);                        
                            } else if(bounceDirX == MmgDir.DIR_RIGHT) {
                                nX = (speed * 2);                        
                            }

                            if(bounceDirY == MmgDir.DIR_BACK) {
                                nY = (speed * -2);
                            } else if(bounceDirY == MmgDir.DIR_FRONT) {
                                nY = (speed * 2);
                            }

                            if(bounceDirY == MmgDir.DIR_BACK) {
                                if(subj.GetY() - (speed * 2) >= ScreenGame.BOARD_TOP) {
                                    current.ShiftRect(nX, nY);
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {
                                        SetY(current.GetTop());
                                    } else if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.OBJECT) {
                                        //stop
                                    } else {
                                        SetY(current.GetTop());
                                    }
                                } else {
                                    SetY(ScreenGame.BOARD_TOP);
                                }
                            } else if(bounceDirY == MmgDir.DIR_FRONT) {
                                if(subj.GetY() + subj.GetHeight() + (speed * 2) <= ScreenGame.BOARD_BOTTOM) {
                                    current.ShiftRect(nX, nY);
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {
                                        SetY(current.GetTop());
                                    } else if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.OBJECT) {
                                        //stop
                                    } else {
                                        SetY(current.GetTop());
                                    }
                                } else {
                                    SetY(ScreenGame.BOARD_BOTTOM - subj.GetHeight());
                                }
                            }

                            if(bounceDirX == MmgDir.DIR_LEFT) {
                                if(subj.GetX() - (speed * 2) >= ScreenGame.BOARD_LEFT) {
                                    current.ShiftRect(nX, nY);
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {
                                        SetX(current.GetLeft());
                                    } else if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.OBJECT) {
                                        //stop
                                    } else {
                                        SetX(current.GetLeft());
                                    }
                                } else {
                                    SetX(ScreenGame.BOARD_LEFT);
                                }                        
                            } else if(bounceDirX == MmgDir.DIR_RIGHT) {
                                if(subj.GetX() + subj.GetWidth() + (speed * 2) <= ScreenGame.BOARD_RIGHT) {
                                    current.ShiftRect(nX, nY);
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {
                                        SetX(current.GetLeft());
                                    } else if(coll.GetMdtType() == MdtObjType.PLAYER) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.ENEMY) {
                                        ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth()/2, GetHeight()/2, bounceDirOrig, playerType);
                                    } else if(coll.GetMdtType() == MdtObjType.OBJECT) {
                                        //stop
                                    } else {
                                        SetX(current.GetLeft());
                                    }
                                } else {
                                    SetX(ScreenGame.BOARD_RIGHT - subj.GetWidth());
                                }    
                            }
                        } else {
                            isBouncing = false;
                            bouncingCurrentMs = 0;
                        }
                    }

                    if(motor != MdtEnemyMotorType.NONE && playerType == MdtPlayerType.ENEMY) {
                        MmgVector2 mPos = null;
                        if(targetPlayer == MdtPlayerType.NONE) {
                            if(screen.GetGameType() == GameType.GAME_TWO_PLAYER && !screen.GetPlayer2Broken()) {
                                int t = GetRand().nextInt(11);
                                if(t % 2 == 0) {
                                    targetPlayer = MdtPlayerType.PLAYER_1;
                                } else {
                                    targetPlayer = MdtPlayerType.PLAYER_2;
                                }
                            } else {
                                targetPlayer = MdtPlayerType.PLAYER_1;
                            }
                        }
    
                        if(screen.GetGameType() == GameType.GAME_ONE_PLAYER) {
                            mPos = screen.GetPlayer1Pos();
                        } else if(screen.GetGameType() == GameType.GAME_TWO_PLAYER) {
                            if(targetPlayer == MdtPlayerType.PLAYER_1 && !screen.GetPlayer1Broken()) {
                                mPos = screen.GetPlayer1Pos();
                            } else if(targetPlayer == MdtPlayerType.PLAYER_2 && !screen.GetPlayer2Broken()) {
                                mPos = screen.GetPlayer2Pos();
                            }
                        }                        
                        
                        if(mPos != null) {
                            motorMoveMs += msSinceLastFrame;
                            if(motorMoveMs >= motorMoveLengthMs) {
                                int t = GetRand().nextInt(11);
                                if(t % 3 == 0) {
                                    isMoving = true;
                                } else {
                                    isMoving = false;
                                }
                                motorMoveMs = 0;
                            }
                            
                            if(motor == MdtEnemyMotorType.MOVE_X_THEN_Y) {
                                if(GetX() + GetWidth()/2 < mPos.GetX()) {
                                    SetDirSafe(MmgDir.DIR_RIGHT);
                                } else if(GetX() > mPos.GetX() + GetWidth()/2) {
                                    SetDirSafe(MmgDir.DIR_LEFT);                                                                    
                                } else if(GetY() + GetHeight()/2 < mPos.GetY()) {
                                    SetDirSafe(MmgDir.DIR_FRONT);                                
                                } else {
                                    SetDirSafe(MmgDir.DIR_BACK); 
                                }                                
                            } else if(motor == MdtEnemyMotorType.MOVE_Y_THEN_X) {
                                if(GetY() + GetHeight()/2 < mPos.GetY()) {                            
                                    SetDirSafe(MmgDir.DIR_FRONT);
                                } else if(GetY() > mPos.GetY() + GetHeight()/2) {
                                    SetDirSafe(MmgDir.DIR_BACK);                                     
                                } else if(GetX() + GetWidth()/2 < mPos.GetX()) {
                                    SetDirSafe(MmgDir.DIR_RIGHT);
                                } else {
                                    SetDirSafe(MmgDir.DIR_LEFT);
                                }      
                            }
                        } else {
                            isMoving = false;
                        }
                    }
                    
                    if(dir != MmgDir.DIR_NONE) {
                        current = new MmgRect(subj.GetX(), subj.GetY(), subj.GetY() + subj.GetHeight(), subj.GetX() + subj.GetWidth());                    
                        if(speed < 0) { 
                            speed *= -1;
                        }

                        if(isMoving == true) {
                            if(dir == MmgDir.DIR_BACK) {
                                if(subj.GetY() - speed >= ScreenGame.BOARD_TOP) {
                                    current.ShiftRect(0, (speed * -1));
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {
                                        SetY(current.GetTop());
                                    } else {                                        
                                        screen.UpdateProcessCollision(this, coll);
                                        if(playerType == MdtPlayerType.ENEMY) {
                                            motorMoveMs = motorMoveLengthMs;
                                        }                                            
                                    }
                                } else {
                                    SetY(ScreenGame.BOARD_TOP);
                                }
                            } else if(dir == MmgDir.DIR_FRONT) {
                                if(subj.GetY() + subj.GetHeight() + speed <= ScreenGame.BOARD_BOTTOM) {
                                    current.ShiftRect(0, (speed * 1));
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {
                                        SetY(current.GetTop());
                                    } else {
                                        screen.UpdateProcessCollision(this, coll);
                                        if(playerType == MdtPlayerType.ENEMY) {
                                            motorMoveMs = motorMoveLengthMs;
                                        }
                                    }
                                } else {
                                    SetY(ScreenGame.BOARD_BOTTOM - subj.GetHeight());
                                }
                            } else if(dir == MmgDir.DIR_LEFT) {
                                if(subj.GetX() - speed >= ScreenGame.BOARD_LEFT) {
                                    current.ShiftRect((speed * -1), 0);
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {
                                        SetX(current.GetLeft());
                                    } else {
                                        screen.UpdateProcessCollision(this, coll);
                                        if(playerType == MdtPlayerType.ENEMY) {
                                            motorMoveMs = motorMoveLengthMs;
                                        }
                                    }
                                } else {
                                    SetX(ScreenGame.BOARD_LEFT);
                                }                        
                            } else if(dir == MmgDir.DIR_RIGHT) {
                                if(subj.GetX() + subj.GetWidth() + speed <= ScreenGame.BOARD_RIGHT) {
                                    current.ShiftRect((speed * 1), 0);
                                    coll = screen.CanMove(current, this);
                                    if(coll == null) {                                
                                        SetX(current.GetLeft());
                                    } else {
                                        screen.UpdateProcessCollision(this, coll);
                                        if(playerType == MdtPlayerType.ENEMY) {
                                            motorMoveMs = motorMoveLengthMs;
                                        }
                                    }
                                } else {
                                    SetX(ScreenGame.BOARD_RIGHT - subj.GetWidth());
                                }
                            }
                        }
                    }
                } else {
                    if(weaponCurrent.attackType == MdtWeaponAttackType.THROWING) {                
                        if(weaponCurrent.screen == null) {
                            weaponCurrent.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                        }

                        if(weaponCurrent.throwingTimeMsCurrent >= weaponCurrent.throwingCoolDown) {
                            isAttacking = false;
                        }
                    } else if(weaponCurrent.attackType == MdtWeaponAttackType.STABBING) {                      
                        if(weaponCurrent.screen == null) {
                            weaponCurrent.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                        }

                        if(weaponCurrent.animTimeMsCurrent > (weaponCurrent.animTimeMsTotal + weaponCurrent.stabbingCoolDown)) {
                            isAttacking = false;
                        }
                    }
                    
                    current = weaponCurrent.GetWeaponRect();
                    if(current != null) {
                        coll = screen.CanMove(current, weaponCurrent);
                        if(coll != null) {
                            screen.UpdateProcessWeaponCollision(coll, this, current);
                        }
                    }                    
                }
            }
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
                if(isAttacking) {
                    if(dir == MmgDir.DIR_BACK) {
                        weaponCurrent.MmgDraw(p);
                        subj.MmgDraw(p);
                    } else if(dir == MmgDir.DIR_FRONT) {
                        subj.MmgDraw(p);
                        weaponCurrent.MmgDraw(p);
                    } else if(dir == MmgDir.DIR_LEFT) {
                        weaponCurrent.MmgDraw(p);
                        subj.MmgDraw(p);
                    } else if(dir == MmgDir.DIR_RIGHT) {
                        weaponCurrent.MmgDraw(p);
                        subj.MmgDraw(p);                    
                    }
                } else {            
                    subj.MmgDraw(p);
                }
            }
        }
    }
}