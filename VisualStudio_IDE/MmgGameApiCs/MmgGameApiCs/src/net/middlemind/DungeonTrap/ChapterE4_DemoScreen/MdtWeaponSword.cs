using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE4_DemoScreen
{
    /// <summary>
    /// A class that represents a weapon of type sword.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtWeaponSword : MdtWeapon
    {
        /// <summary>
        /// A basic constructor that allows you to set the weapon holder and weapon type via constructor arguments.
        /// </summary>
        /// <param name="Holder">The holder of the weapon.</param>
        /// <param name="WeaponType">The type of weapon held.</param>
        /// <param name="Player">The type of player that is holding the weapon.</param>
        public MdtWeaponSword(MdtChar Holder, MdtWeaponType WeaponType, MdtPlayerType Player)
            : base(Holder, WeaponType, Player)
        {
            subjFront = MmgHelper.GetBasicCachedBmp("weapon_sword_dir_front.png");
            subjFront = MmgBmpScaler.ScaleMmgBmp(subjFront, 2.0f, true);

            subjBack = MmgHelper.GetBasicCachedBmp("weapon_sword_dir_back.png");
            subjBack = MmgBmpScaler.ScaleMmgBmp(subjBack, 2.0f, true);

            subjLeft = MmgHelper.GetBasicCachedBmp("weapon_sword_dir_left.png");
            subjLeft = MmgBmpScaler.ScaleMmgBmp(subjLeft, 2.0f, true);

            subjRight = MmgHelper.GetBasicCachedBmp("weapon_sword_dir_right.png");
            subjRight = MmgBmpScaler.ScaleMmgBmp(subjRight, 2.0f, true);

            SetMdtType(MdtObjType.WEAPON);
            SetMdtSubType(MdtObjSubType.WEAPON_SWORD);
            attackType = MdtWeaponAttackType.STABBING;
            SetWidth(subjBack.GetHeight());
            SetHeight(subjBack.GetHeight());
            SetDamage(1);
            SetAnimTimeMsTotal(200);
        }

        /// <summary>
        /// Creates a clone of this object instance.
        /// </summary>
        /// <returns>A new instance of this class.</returns>
        public new MdtWeaponSword Clone()
        {
            MdtWeaponSword ret = new MdtWeaponSword(holder, weaponType, player);
            ret.animPrctComplete = animPrctComplete;
            ret.active = active;
            ret.animTimeMsCurrent = animTimeMsCurrent;
            ret.animTimeMsTotal = animTimeMsTotal;
            ret.attackType = attackType;

            if (GetMmgColor() == null)
            {
                ret.SetMmgColor(GetMmgColor());
            }
            else
            {
                ret.SetMmgColor(GetMmgColor().Clone());
            }

            if (current == null)
            {
                ret.current = current;
            }
            else
            {
                ret.current = current.Clone();
            }

            ret.damage = damage;
            ret.SetHeight(GetHeight());
            ret.SetHasParent(GetHasParent());
            ret.SetIsVisible(GetIsVisible());
            ret.SetId(GetId());
            ret.holder = holder;
            ret.SetParent(GetParent());

            if (GetPosition() == null)
            {
                ret.pos = GetPosition();
            }
            else
            {
                ret.pos = GetPosition().Clone();
            }

            if (subjBack == null)
            {
                ret.subjBack = subjBack;
            }
            else
            {
                ret.subjBack = subjBack.CloneTyped();
            }

            if (subjFront == null)
            {
                ret.subjFront = subjFront;
            }
            else
            {
                ret.subjFront = subjFront.CloneTyped();
            }

            if (subjLeft == null)
            {
                ret.subjLeft = subjLeft;
            }
            else
            {
                ret.subjLeft = subjLeft.CloneTyped();
            }

            if (subjRight == null)
            {
                ret.subjRight = subjRight;
            }
            else
            {
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
}