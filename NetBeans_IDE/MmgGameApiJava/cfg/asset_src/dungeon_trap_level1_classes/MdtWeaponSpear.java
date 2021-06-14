package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * A class that represents a weapon of type spear.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtWeaponSpear extends MdtWeapon {

    /**
     * A basic constructor that allows you to set the weapon holder and weapon type via constructor arguments.
     * 
     * @param Holder        The holder of the weapon.
     * @param WeaponType    The type of weapon held.
     * @param Player        The type of player that is holding the weapon.
     */
    public MdtWeaponSpear(MdtChar Holder, MdtWeaponType WeaponType, MdtPlayerType Player) {
        super(Holder, WeaponType, Player);
        subjFront = MmgHelper.GetBasicCachedBmp("weapon_spear_dir_front.png");
        subjFront = MmgBmpScaler.ScaleMmgBmp(subjFront, 2.0f, true);
        
        subjBack = MmgHelper.GetBasicCachedBmp("weapon_spear_dir_back.png");        
        subjBack = MmgBmpScaler.ScaleMmgBmp(subjBack, 2.0f, true);
        
        subjLeft = MmgHelper.GetBasicCachedBmp("weapon_spear_dir_left.png");
        subjLeft = MmgBmpScaler.ScaleMmgBmp(subjLeft, 2.0f, true);
        
        subjRight = MmgHelper.GetBasicCachedBmp("weapon_spear_dir_right.png");
        subjRight = MmgBmpScaler.ScaleMmgBmp(subjRight, 2.0f, true);
        
        SetMdtType(MdtObjType.WEAPON);
        SetMdtSubType(MdtObjSubType.WEAPON_SPEAR);
        SetAttackType(MdtWeaponAttackType.STABBING);
        SetWidth(subjBack.GetHeight());
        SetHeight(subjBack.GetHeight());
        SetDamage(1);
        SetAnimTimeMsTotal(250);
    }
    
    /**
     * Creates a clone of this object instance.
     * 
     * @return  A new instance of this class.
     */
    @Override
    public MdtWeaponSpear Clone() {
        MdtWeaponSpear ret = new MdtWeaponSpear(holder, weaponType, player);
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
}