package game.jam.DungeonTrap;

import java.util.Random;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgDir;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;

/**
 * A class that represents the super class of all character weapons.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/22/2020
 */
public class MdtWeapon extends MdtBase {

    /**
     * The front subject of this weapon.
     */
    public MmgBmp subjFront = null;
    
    /**
     * The back subject of this weapon.
     */
    public MmgBmp subjBack = null;    
    
    /**
     * The left subject of this weapon.
     */
    public MmgBmp subjLeft = null;    
    
    /**
     * The right subject of this weapon.
     */
    public MmgBmp subjRight = null;
    
    /**
     * The character that is the owner of the weapon.
     */
    public MdtChar holder = null;
    
    /**
     * A boolean indicating if this weapon is active or not.
     */
    public boolean active = false;

    /**
     * An internal variable used in private class methods.
     */
    private boolean lret = false;
    
    /**
     * The type of weapon this class represents.
     */
    public MdtWeaponType weaponType = MdtWeaponType.NONE;
    
    /**
     * The weapon animation current time in milliseconds.
     */
    public long animTimeMsCurrent = 0;
    
    /**
     * The weapon animation total time in milliseconds.
     */
    public long animTimeMsTotal = 500;
    
    /**
     * The weapon animation percent complete.
     */
    public double animPrctComplete = 0.0d;
    
    /**
     * The damage this weapon does.
     */
    public int damage = 1;
    
    /**
     * An MmgRect representing the weapon's source bounds.
     */
    private MmgRect src = null;
    
    /**
     * An MmgRect representing the weapon's destination bounds.
     */
    private MmgRect dst = null;
        
    /**
     * The throwing speed of this weapon if the weapon is configured to be throw-able.
     */
    public int throwingSpeed = ScreenGame.GetSpeedPerFrame(120);
    
    /**
     * The throwing speed skew.
     */
    public int throwingSpeedSkew = ScreenGame.GetSpeedPerFrame(40);    
    
    /**
     * The throwing animation start frame.
     */
    public int throwingFrame = 0;
    
    /**
     * The throwing animation direction.
     */
    public int throwingDir = 0;
        
    /**
     * The throwing animation cool down time in milliseconds.
     */
    public long throwingCoolDown = 500;
    
    /**
     * The throwing animation current time in milliseconds.
     */
    public long throwingTimeMsCurrent = 0;
    
    /**
     * The throwing animation's rotation time in milliseconds.
     */
    public long throwingTimeMsRotation = 200;
    
    /**
     * The stabbing animation cool down time in milliseconds.
     */
    public long stabbingCoolDown = 150;    
    
    /**
     * The screen this weapon belongs to.
     */
    public ScreenGame screen = null;
        
    /**
     * A variable used in class methods.
     */
    private int tmpI = 0;
    
    /**
     * A rectangle representing the current bounds of the weapon.
     */
    public MmgRect current = null;
    
    /**
     * The player that this weapon belongs to.
     */
    public MdtPlayerType player;
    
    /**
     * An MdtBase object instance used in determining collisions.
     */
    public MdtBase coll = null;
    
    /**
     * The attack type of this weapon.
     */
    public MdtWeaponAttackType attackType = MdtWeaponAttackType.NONE;
    
    /**
     * The throwing path this weapon uses.
     */
    public MdtWeaponPathType throwingPath = MdtWeaponPathType.NONE;
    
    /**
     * A random number generator used in class methods.
     */
    private Random rand = null;    
    
    /**
     * A constructor that lets you specify the holder of the weapon and the weapon type.
     * 
     * @param Holder        The character that is holding the weapon.
     * @param WeaponType    The type of weapon.
     * @param Player        The character type that is holding the weapon.
     */
    public MdtWeapon(MdtChar Holder, MdtWeaponType WeaponType, MdtPlayerType Player) {
        super();
        SetMdtType(MdtObjType.WEAPON);
        SetPlayer(Player);
        SetHolder(Holder);
        SetWeaponType(WeaponType);
        SetAttackType(MdtWeaponAttackType.STABBING);
        SetRand(new Random(System.currentTimeMillis()));
    }
    
    /**
     * A constructor that lets you specify the holder of the weapon, the weapon type, and the attack type.
     * 
     * @param Holder        The character that is holding the weapon.
     * @param WeaponType    The type of weapon.
     * @param AttackType    The attack type of the weapon.
     * @param Player        The character type that is holding the weapon.
     */
    public MdtWeapon(MdtChar Holder, MdtWeaponType WeaponType, MdtWeaponAttackType AttackType, MdtPlayerType Player) {
        super();
        SetMdtType(MdtObjType.WEAPON);
        SetPlayer(Player);
        SetHolder(Holder);
        SetWeaponType(WeaponType);
        SetAttackType(AttackType);
        SetRand(new Random(System.currentTimeMillis()));
    }    

    /**
     * Gets the player that holds this weapon.
     * 
     * @return      The player that holds this weapon.
     */
    public MdtPlayerType GetPlayer() {
        return player;
    }

    /**
     * Sets the player that holds this weapon.
     * 
     * @param p     The player that holds this weapon. 
     */
    public void SetPlayer(MdtPlayerType p) {
        player = p;
    }

    /**
     * Gets the random number generator used by this class.
     * 
     * @return      The random number generator used by this class.
     */
    public Random GetRand() {
        return rand;
    }
    
    /**
     * Sets the random number generator used by this class.
     * 
     * @param r     The random number generator used by this class. 
     */
    public void SetRand(Random r) {
        rand = r;
    }    
    
    /**
     * Gets the front facing subject for this weapon.
     * 
     * @return      The front facing subject for this weapon. 
     */
    public MmgBmp GetSubjFront() {
        return subjFront;
    }

    /**
     * Sets the front facing subject for this weapon.
     * 
     * @param SubjFront     The front facing subject for this weapon.
     */
    public void SetSubjFront(MmgBmp SubjFront) {
        subjFront = SubjFront;
    }

    /**
     * Gets the back facing subject for this weapon.
     * 
     * @return      The back facing subject for this weapon.
     */
    public MmgBmp GetSubjBack() {
        return subjBack;
    }

    /**
     * Sets the back facing subject for this weapon.
     * 
     * @param SubjBack      The back facing subject for this weapon.
     */
    public void SetSubjBack(MmgBmp SubjBack) {
        subjBack = SubjBack;
    }

    /**
     * Gets the left facing subject for this weapon.
     * 
     * @return      The left facing subject for this weapon.
     */
    public MmgBmp GetSubjLeft() {
        return subjLeft;
    }

    /**
     * Sets the left facing subject for this weapon.
     * 
     * @param SubjLeft      The left facing subject for this weapon.
     */
    public void SetSubjLeft(MmgBmp SubjLeft) {
        subjLeft = SubjLeft;
    }

    /**
     * Gets the right facing subject for this weapon.
     * 
     * @return      The right facing subject for this weapon. 
     */
    public MmgBmp GetSubjRight() {
        return subjRight;
    }

    /**
     * Sets the right facing subject for this weapon.
     * 
     * @param SubjRight     The right facing subject for this weapon.
     */
    public void SetSubjRight(MmgBmp SubjRight) {
        subjRight = SubjRight;
    }

    /**
     * Gets the owner of this weapon.
     * 
     * @return      The owner of this weapon.
     */
    public MdtChar GetHolder() {
        return holder;
    }

    /**
     * Sets the owner of this weapon.
     * 
     * @param Holder     The holder of this weapon.
     */
    public void SetHolder(MdtChar Holder) {
        holder = Holder;
    }

    /**
     * Gets a boolean indicating if the weapon is active.
     * 
     * @return      A boolean indicating if the weapon is active.
     */
    public boolean GetIsActive() {
        return active;
    }

    /**
     * Sets a boolean indicating if the weapon is active.
     * 
     * @param b     A boolean indicating if the weapon is active.
     */
    public void SetIsActive(boolean b) {
        active = b;
    }

    /**
     * Gets the type of this weapon.
     * 
     * @return      The type of this weapon.
     */
    public MdtWeaponType GetWeaponType() {
        return weaponType;
    }

    /**
     * Sets the type of this weapon.
     * 
     * @param WeaponType    The type of this weapon.
     */
    public void SetWeaponType(MdtWeaponType WeaponType) {
        weaponType = WeaponType;
    }

    /**
     * Gets the current animation time in milliseconds.
     * 
     * @return      The current animation time in milliseconds.
     */
    public long GetAnimTimeMsCurrent() {
        return animTimeMsCurrent;
    }

    /**
     * Sets the current animation time in milliseconds.
     * 
     * @param h     The current animation time in milliseconds.
     */
    public void SetAnimTimeMsCurrent(long h) {
        animTimeMsCurrent = h;
    }

    /**
     * Gets the total animation time in milliseconds.
     * 
     * @return      The total animation time in milliseconds.
     */
    public long GetAnimTimeMsTotal() {
        return animTimeMsTotal;
    }

    /**
     * Sets the total animation time in milliseconds.
     * 
     * @param h     The total animation time in milliseconds.
     */
    public void SetAnimTimeMsTotal(long h) {
        animTimeMsTotal = h;
    }

    /**
     * Gets the percentage of animation complete.
     * 
     * @return      The percentage of animation complete.
     */
    public double GetAnimPrctComplete() {
        return animPrctComplete;
    }

    /**
     * Sets the percentage of animation complete.
     * 
     * @param d     The percentage of animation complete.
     */
    public void SetAnimPrctComplete(double d) {
        animPrctComplete = d;
    }

    /**
     * Gets the weapon damage.
     * 
     * @return      The weapon damage.
     */
    public int GetDamage() {
        return damage;
    }

    /**
     * Sets the weapon damage.
     * 
     * @param d     The weapon damage.
     */
    public void SetDamage(int d) {
        damage = d;
    }

    /**
     * Gets the source rectangle.
     * 
     * @return      The source rectangle. 
     */
    public MmgRect GetSrc() {
        return src;
    }

    /**
     * Sets the source rectangle.
     * 
     * @param Src   The source rectangle. 
     */
    public void SetSrc(MmgRect Src) {
        src = Src;
    }

    /**
     * Gets the destination rectangle.
     * 
     * @return      The destination rectangle.
     */
    public MmgRect GetDst() {
        return dst;
    }

    /**
     * Sets the destination rectangle.
     * 
     * @param Dst   The destination rectangle. 
     */
    public void SetDst(MmgRect Dst) {
        dst = Dst;
    }

    /**
     * Gets the attack type of the weapon.
     * 
     * @return      The attack type of the weapon.
     */
    public MdtWeaponAttackType GetAttackType() {
        return attackType;
    }

    /**
     * Sets the attack type of the weapon.
     * 
     * @param AttackType    The attack type of the weapon. 
     */
    public void SetAttackType(MdtWeaponAttackType AttackType) {
        attackType = AttackType;
    }

    /**
     * Gets the throwing path of this weapon if it's a throwing weapon.
     * 
     * @return      The throwing path of the weapon.
     */
    public MdtWeaponPathType GetThrowingPath() {
        return throwingPath;
    }

    /**
     * Sets the throwing path of this weapon if it's a throwing weapon.
     * 
     * @param ThrowingPath      The throwing path of the weapon.
     */
    public void SetThrowingPath(MdtWeaponPathType ThrowingPath) {
        throwingPath = ThrowingPath;
    }

    /**
     * Gets the throwing speed of the weapon.
     * 
     * @return      The throwing speed of the weapon.
     */
    public int GetThrowingSpeed() {
        return throwingSpeed;
    }

    /**
     * Sets the throwing speed of the weapon.
     * 
     * @param h     The throwing speed of the weapon.
     */
    public void SetThrowingSpeed(int h) {
        throwingSpeed = h;
    }

    /**
     * Gets the skew of the throwing speed.
     * 
     * @return      The skew of the throwing speed.
     */
    public int GetThrowingSpeedSkew() {
        return throwingSpeedSkew;
    }

    /**
     * Sets the skew of the throwing speed.
     * 
     * @param h     The skew of the throwing speed.
     */
    public void SetThrowingSpeedSkew(int h) {
        throwingSpeedSkew = h;
    }

    /**
     * Gets the frame of the throwing animation.
     * 
     * @return      The frame of the throwing animation.
     */
    public int GetThrowingFrame() {
        return throwingFrame;
    }

    /**
     * Sets the frame of the throwing animation.
     * 
     * @param h     The frame of the throwing animation.
     */
    public void SetThrowingFrame(int h) {
        throwingFrame = h;
    }

    /**
     * Gets the direction the weapon is thrown in.
     * 
     * @return      The direction the weapon is thrown in.
     */
    public int GetThrowingDir() {
        return throwingDir;
    }

    /**
     * Sets the direction the weapon is thrown in.
     * 
     * @param h     The direction the weapon is thrown in.
     */
    public void SetThrowingDir(int h) {
        throwingDir = h;
    }

    /**
     * Gets the stabbing animation cool down period.
     * 
     * @return      The stabbing animation cool down period.
     */
    public long GetStabbingCoolDown() {
        return stabbingCoolDown;
    }

    /**
     * Sets the stabbing animation cool down period.
     * 
     * @param h     The stabbing animation cool down period.
     */
    public void SetStabbingCoolDown(long h) {
        stabbingCoolDown = h;
    }

    /**
     * Gets the throwing animation cool down period.
     * 
     * @return      The throwing animation cool down period.
     */
    public long GetThrowingCoolDown() {
        return throwingCoolDown;
    }

    /**
     * Sets the throwing animation cool down period.
     * 
     * @param h     The throwing animation cool down period.
     */
    public void SetThrowingCoolDown(long h) {
        throwingCoolDown = h;
    }

    /**
     * Gets the current time of the throwing animation.
     * 
     * @return      The current time of the throwing animation.
     */
    public long GetThrowingTimeMsCurrent() {
        return throwingTimeMsCurrent;
    }

    /**
     * Sets the current time of the throwing animation.
     * 
     * @param h     The current time of the throwing animation.
     */
    public void SetThrowingTimeMsCurrent(long h) {
        throwingTimeMsCurrent = h;
    }

    /**
     * Gets the throwing animation rotation time in millisecond. 
     * 
     * @return      The throwing animation time in milliseconds.
     */
    public long GetThrowingTimeMsRotation() {
        return throwingTimeMsRotation;
    }

    /**
     * Sets the throwing animation rotation time in millisecond.
     * 
     * @param h     The throwing animation time in milliseconds.
     */
    public void SetThrowingTimeMsRotation(long h) {
        throwingTimeMsRotation = h;
    }

    /**
     * Gets the current screen this object is on.
     * 
     * @return      The current screen this object is on. 
     */
    public ScreenGame GetScreen() {
        return screen;
    }

    /**
     * Sets the current screen this object is on.
     * 
     * @param Screen    The current screen this object is on. 
     */
    public void SetScreen(ScreenGame Screen) {
        screen = Screen;
    }

    /**
     * Gets the current collision rectangle.
     * 
     * @return      The current collision rectangle. 
     */
    public MmgRect GetCurrent() {
        return current;
    }

    /**
     * Sets the current collision rectangle.
     * 
     * @param Current   The current collision rectangle.
     */
    public void SetCurrent(MmgRect Current) {
        current = Current;
    }
    
    /**
     * Creates a clone of this object instance.
     * 
     * @return  A new instance of this class.
     */
    @Override
    public MdtWeapon Clone() {
        MdtWeapon ret = new MdtWeapon(holder, weaponType, player);
        ret.SetAnimPrctComplete(GetAnimPrctComplete());
        ret.SetIsActive(GetIsActive());
        ret.SetAnimTimeMsCurrent(GetAnimTimeMsCurrent());
        ret.SetAnimTimeMsTotal(GetAnimTimeMsTotal());
        ret.SetAttackType(GetAttackType());
        
        if(GetMmgColor() == null) {
            ret.SetMmgColor(GetMmgColor());
        } else {
            ret.SetMmgColor(GetMmgColor().Clone());            
        }
        
        if(GetCurrent() == null) {
            ret.SetCurrent(GetCurrent()); 
        } else {
            ret.SetCurrent(GetCurrent().Clone());
        }
        
        ret.SetDamage(GetDamage());
        ret.SetHeight(GetHeight());
        ret.SetHasParent(GetHasParent());
        ret.SetIsVisible(GetIsVisible());
        ret.SetId(GetId());
        ret.SetHolder(GetHolder());
        ret.SetParent(GetParent());

        if(GetPosition() == null) {
            ret.SetPosition(GetPosition());
        } else {
            ret.SetPosition(GetPosition().Clone());
        }
        
        if(GetSubjBack() == null) {
            ret.SetSubjBack(GetSubjBack());
        } else {
            ret.SetSubjBack(GetSubjBack().CloneTyped());
        }

        if(GetSubjFront() == null) {
            ret.SetSubjFront(GetSubjFront());
        } else {
            ret.SetSubjFront(GetSubjFront().CloneTyped());
        }

        if(GetSubjLeft() == null) {
            ret.SetSubjLeft(GetSubjLeft());
        } else {
            ret.SetSubjLeft(GetSubjLeft().CloneTyped());
        }

        if(GetSubjRight() == null) {
            ret.SetSubjRight(GetSubjRight());
        } else {
            ret.SetSubjRight(GetSubjRight().CloneTyped());
        }        
        
        ret.SetThrowingDir(GetThrowingDir());
        ret.SetThrowingFrame(GetThrowingFrame());
        ret.SetThrowingPath(GetThrowingPath());
        ret.SetThrowingSpeed(GetThrowingSpeed());
        ret.SetThrowingSpeedSkew(GetThrowingSpeedSkew());
        ret.SetThrowingCoolDown(GetThrowingCoolDown());
        ret.SetThrowingTimeMsRotation(GetThrowingTimeMsRotation());
        ret.SetThrowingTimeMsCurrent(GetThrowingTimeMsCurrent());
        ret.SetScreen(GetScreen());
        ret.SetStabbingCoolDown(GetStabbingCoolDown());
        return ret;
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
        if (isVisible == true && active == true) {
            animTimeMsCurrent += msSinceLastFrame;
            
            if(attackType == MdtWeaponAttackType.THROWING) {
                if(current == null) {
                    current = new MmgRect(holder.GetX() + holder.GetWidth()/2 - GetWidth()/2, holder.GetY() + holder.GetHeight()/2 - GetHeight()/2, holder.GetY() + holder.GetHeight()/2 + GetHeight()/2, holder.GetX() + holder.GetWidth()/2 + GetWidth()/2);
                    throwingFrame = 0;
                }

                if(throwingSpeed < 0) {
                    throwingSpeed *= -1;
                }
                
                throwingTimeMsCurrent += msSinceLastFrame;
                
                if(throwingPath == MdtWeaponPathType.NONE) {
                    tmpI = rand.nextInt(11);
                    throwingDir = holder.dir;
                    if(tmpI % 2 == 0) {
                        throwingPath = MdtWeaponPathType.PATH_1;
                    } else if(tmpI % 3 == 0) {
                        throwingPath = MdtWeaponPathType.PATH_2;                        
                    } else {
                        throwingPath = MdtWeaponPathType.PATH_3;                        
                    }
                } else {
                    if(throwingDir == MmgDir.DIR_BACK) {
                        if(throwingPath == MdtWeaponPathType.PATH_1) {
                            current.ShiftRect((throwingSpeedSkew * -1), (throwingSpeed * -1));
                        } else if(throwingPath == MdtWeaponPathType.PATH_2) {
                            current.ShiftRect(0, (throwingSpeed * -1));
                        } else if(throwingPath == MdtWeaponPathType.PATH_3) {
                            current.ShiftRect((throwingSpeedSkew * 1), (throwingSpeed * -1));                            
                        }
                    } else if(throwingDir == MmgDir.DIR_FRONT) {
                        if(throwingPath == MdtWeaponPathType.PATH_1) {
                            current.ShiftRect((throwingSpeedSkew * -1), (throwingSpeed * 1));
                        } else if(throwingPath == MdtWeaponPathType.PATH_2) {
                            current.ShiftRect(0, (throwingSpeed * 1));
                        } else if(throwingPath == MdtWeaponPathType.PATH_3) {
                            current.ShiftRect((throwingSpeedSkew * 1), (throwingSpeed * 1));                            
                        }
                    } else if(throwingDir == MmgDir.DIR_LEFT) {
                        if(throwingPath == MdtWeaponPathType.PATH_1) {
                            current.ShiftRect((throwingSpeed * -1), (throwingSpeedSkew * 1));
                        } else if(throwingPath == MdtWeaponPathType.PATH_2) {
                            current.ShiftRect((throwingSpeed * -1), 0);
                        } else if(throwingPath == MdtWeaponPathType.PATH_3) {
                            current.ShiftRect((throwingSpeed * -1), (throwingSpeedSkew * -1));                            
                        }
                    } else if(throwingDir == MmgDir.DIR_RIGHT) {
                        if(throwingPath == MdtWeaponPathType.PATH_1) {
                            current.ShiftRect((throwingSpeed * 1), (throwingSpeedSkew * 1));
                        } else if(throwingPath == MdtWeaponPathType.PATH_2) {
                            current.ShiftRect((throwingSpeed * 1), 0);
                        } else if(throwingPath == MdtWeaponPathType.PATH_3) {
                            current.ShiftRect((throwingSpeed * 1), (throwingSpeedSkew * -1));                            
                        }                                                
                    }                    
                    
                    if(animTimeMsCurrent > throwingTimeMsRotation) {
                        animTimeMsCurrent = 0;
                        throwingFrame++;
                        if(throwingFrame > 3) {
                            throwingFrame = 0;
                        }
                    }

                    SetPosition(current.GetLeft(), current.GetTop());
                    coll = screen.CanMove(current, this);
                    if(coll != null) {
                        if(coll.GetMdtType() == MdtObjType.ENEMY) {
                            if(screen != null) {
                                screen.UpdateProcessWeaponCollision(coll, this, current);
                                screen.UpdateRemoveObj(this, GetPlayer());
                            }
                        }
                    }
                
                    if(
                        GetX() < ScreenGame.BOARD_LEFT
                        || GetX() + GetWidth() > ScreenGame.BOARD_RIGHT
                        || GetY() < ScreenGame.BOARD_TOP
                        || GetY() + GetHeight() > ScreenGame.BOARD_BOTTOM
                    ) {
                        if(screen != null) {
                            screen.UpdateRemoveObj(this, GetPlayer());
                        }
                    }
                }
            }
            
            animPrctComplete = (double)animTimeMsCurrent / (double)animTimeMsTotal;
            if(animPrctComplete > 1.0d) { 
                animPrctComplete = 1.0d;
            }
            
            lret = true;
        }
        return lret;
    }
        
    /**
     * An MmgRect instance that represents the visible portion of the weapon.
     * 
     * @return       An MmgRect instance that represents the visible portion of the weapon.
     */
    public MmgRect GetWeaponRect() {        
        if(attackType == MdtWeaponAttackType.STABBING) {
            if(holder.dir == MmgDir.DIR_BACK) {
                src = new MmgRect(0, 0, (int)(subjBack.GetHeight() * animPrctComplete), subjBack.GetWidth());                
                dst = new MmgRect((holder.GetX() + MmgHelper.ScaleValue(8) + holder.GetWidth()/2 - src.GetWidth()/2)
                        , (holder.GetY() + MmgHelper.ScaleValue(8) - src.GetHeight())
                        , (holder.GetY() + MmgHelper.ScaleValue(8))
                        , (holder.GetX() + MmgHelper.ScaleValue(8) + holder.GetWidth()/2 + src.GetWidth()/2)
                        );            
            } else if(holder.dir == MmgDir.DIR_FRONT) {
                src = new MmgRect(0, subjFront.GetHeight() - (int)(subjFront.GetHeight() * animPrctComplete), subjFront.GetHeight(), subjFront.GetWidth());                
                dst = new MmgRect((holder.GetX() - MmgHelper.ScaleValue(8) + holder.GetWidth()/2 - src.GetWidth()/2)
                        , (holder.GetY() - MmgHelper.ScaleValue(12) + holder.GetHeight())
                        , (holder.GetY() - MmgHelper.ScaleValue(12) + holder.GetHeight() + src.GetHeight())
                        , (holder.GetX() - MmgHelper.ScaleValue(8) + holder.GetWidth()/2 + src.GetWidth()/2)
                        );            
            } else if(holder.dir == MmgDir.DIR_LEFT) {
                src = new MmgRect(0, 0, subjLeft.GetHeight(), (int)(subjLeft.GetWidth() * animPrctComplete));                
                dst = new MmgRect((holder.GetX() + MmgHelper.ScaleValue(8) - src.GetWidth())
                        , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight()/2 - src.GetHeight()/2)
                        , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight()/2 + src.GetHeight()/2)
                        , (holder.GetX() + MmgHelper.ScaleValue(8))
                        );            
            } else if(holder.dir == MmgDir.DIR_RIGHT) {
                src = new MmgRect(subjRight.GetWidth() - (int)(subjRight.GetWidth() * animPrctComplete), 0, subjRight.GetHeight(), subjRight.GetWidth());                
                dst = new MmgRect((holder.GetX() + holder.GetWidth() - MmgHelper.ScaleValue(8))
                        , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight()/2 - src.GetHeight()/2)
                        , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight()/2 + src.GetHeight()/2)
                        , (holder.GetX() + holder.GetWidth() - MmgHelper.ScaleValue(8) + src.GetWidth())
                        );            
            }            
        } else if(attackType == MdtWeaponAttackType.THROWING && weaponType == MdtWeaponType.AXE) {
            if(throwingFrame == 0) {
                dst = new MmgRect(subjBack.GetX(), subjBack.GetY(), subjBack.GetY() + subjBack.GetHeight(), subjBack.GetX() + subjBack.GetWidth());
            } else if(throwingFrame == 1) {
                dst = new MmgRect(subjFront.GetX(), subjFront.GetY(), subjFront.GetY() + subjFront.GetHeight(), subjFront.GetX() + subjFront.GetWidth());                    
            } else if(throwingFrame == 2) {
                dst = new MmgRect(subjLeft.GetX(), subjLeft.GetY(), subjLeft.GetY() + subjLeft.GetHeight(), subjLeft.GetX() + subjLeft.GetWidth());                    
            } else if(throwingFrame == 3) {                     
                dst = new MmgRect(subjRight.GetX(), subjRight.GetY(), subjRight.GetY() + subjRight.GetHeight(), subjRight.GetX() + subjRight.GetWidth());
            }
        }
        return dst;
    }
    
    /**
     * Base draw method, handles drawing this class.
     *
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true && active == true) {
            GetWeaponRect();
            if(attackType == MdtWeaponAttackType.STABBING) {
                if(holder.dir == MmgDir.DIR_BACK) {
                    p.DrawBmp(subjBack, src, dst);
                } else if(holder.dir == MmgDir.DIR_FRONT) {
                    p.DrawBmp(subjFront, src, dst);
                } else if(holder.dir == MmgDir.DIR_LEFT) {
                    p.DrawBmp(subjLeft, src, dst);
                } else if(holder.dir == MmgDir.DIR_RIGHT) {
                    p.DrawBmp(subjRight, src, dst);
                }
            } else if(attackType == MdtWeaponAttackType.THROWING && weaponType == MdtWeaponType.AXE) {
                if(throwingFrame == 0) {
                    p.DrawBmp(subjBack);
                } else if(throwingFrame == 1) {
                    p.DrawBmp(subjFront);
                } else if(throwingFrame == 2) {
                    p.DrawBmp(subjLeft);
                } else if(throwingFrame == 3) {
                    p.DrawBmp(subjRight);
                }             
            }
        }
    }
}