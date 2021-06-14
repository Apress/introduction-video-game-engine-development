package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents a weapon of type axe.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtWeaponAxe extends MdtWeapon {

    /**
     * A basic constructor that allows you to set the weapon holder and weapon type via constructor arguments.
     * 
     * @param Holder        The holder of the weapon.
     * @param WeaponType    The type of weapon held.
     * @param Player        The type of the character holding the weapon.
     */
    public MdtWeaponAxe(MdtChar Holder, MdtWeaponType WeaponType, MdtPlayerType Player) {
        super(Holder, WeaponType, Player);
        subjFront = MmgHelper.GetBasicCachedBmp("weapon_axe_dir_front.png");
        subjFront = MmgBmpScaler.ScaleMmgBmp(subjFront, 2.0f, true);
        
        subjBack = MmgHelper.GetBasicCachedBmp("weapon_axe_dir_back.png");        
        subjBack = MmgBmpScaler.ScaleMmgBmp(subjBack, 2.0f, true);
        
        subjLeft = MmgHelper.GetBasicCachedBmp("weapon_axe_dir_left.png");
        subjLeft = MmgBmpScaler.ScaleMmgBmp(subjLeft, 2.0f, true);
        
        subjRight = MmgHelper.GetBasicCachedBmp("weapon_axe_dir_right.png");
        subjRight = MmgBmpScaler.ScaleMmgBmp(subjRight, 2.0f, true);
        
        SetMdtType(MdtObjType.WEAPON);
        SetMdtSubType(MdtObjSubType.WEAPON_AXE);
        SetAttackType(MdtWeaponAttackType.THROWING);
        SetWidth(subjBack.GetHeight());
        SetHeight(subjBack.GetHeight());
        SetDamage(1);
        SetAnimTimeMsTotal(300);
    }
    
    /**
     * Creates a clone of this object instance.
     * 
     * @return  A new instance of this class.
     */
    @Override
    public MdtWeaponAxe Clone() {
        MdtWeaponAxe ret = new MdtWeaponAxe(holder, weaponType, player);
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
        
        if(subjBack == null) {
            ret.subjBack = subjBack;
        } else {
            ret.subjBack = subjBack.CloneTyped();
        }

        if(subjFront == null) {
            ret.subjFront = subjFront;
        } else {
            ret.subjFront = subjFront.CloneTyped();
        }

        if(subjLeft == null) {
            ret.subjLeft = subjLeft;
        } else {
            ret.subjLeft = subjLeft.CloneTyped();
        }

        if(subjRight == null) {
            ret.subjRight = subjRight;
        } else {
            ret.subjRight = subjRight.CloneTyped();
        }        
        
        ret.throwingDir = throwingDir;
        ret.throwingFrame = throwingFrame;
        ret.throwingPath = throwingPath;
        ret.throwingSpeed = throwingSpeed;
        ret.throwingSpeedSkew = throwingSpeedSkew;
        ret.throwingCoolDown = throwingCoolDown;
        ret.throwingTimeMsRotation = throwingTimeMsRotation;
        ret.throwingTimeMsCurrent = throwingTimeMsCurrent;
        ret.screen = screen;
        ret.stabbingCoolDown = stabbingCoolDown;
        return ret;
    }
    
    /**
     * Gets the X coordinate.
     * 
     * @return      The X coordinate.
     */
    @Override
    public int GetX() {
        if(throwingFrame == 0) {
            return subjBack.GetX();
        } else if(throwingFrame == 1) {
            return subjFront.GetX();
        } else if(throwingFrame == 2) {
            return subjLeft.GetX();
        } else {
            return subjRight.GetX();                            
        }                          
    }
    
    /**
     * Gets the Y coordinate.
     * 
     * @return      The Y coordinate.
     */
    @Override
    public int GetY() {
        if(throwingFrame == 0) {
            return subjBack.GetY();
        } else if(throwingFrame == 1) {
            return subjFront.GetY();
        } else if(throwingFrame == 2) {
            return subjLeft.GetY();
        } else {
            return subjRight.GetY();                            
        }                            
    }  
    
    /**
     * Sets the position of the character.
     * 
     * @param v     The position to set.
     */
    @Override
    public void SetPosition(MmgVector2 v) {
        super.SetPosition(v);
        subjBack.SetPosition(v);
        subjFront.SetPosition(v);
        subjLeft.SetPosition(v);
        subjRight.SetPosition(v);
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
        subjBack.SetPosition(x, y);
        subjFront.SetPosition(x, y);
        subjLeft.SetPosition(x, y);
        subjRight.SetPosition(x, y);
    }    
    
    /**
     * Sets the X coordinate position of the character.
     * 
     * @param i     The X coordinate to set.
     */
    @Override
    public void SetX(int i) {
        super.SetX(i);
        subjBack.SetX(i);
        subjFront.SetX(i);
        subjLeft.SetX(i);
        subjRight.SetX(i);
    }
    
    /**
     * Sets the Y coordinate position of the character.
     * 
     * @param i     The Y coordinate to set. 
     */
    @Override
    public void SetY(int i) {
        super.SetY(i);
        subjBack.SetY(i);
        subjFront.SetY(i);
        subjLeft.SetY(i);
        subjRight.SetY(i);
    }      
}