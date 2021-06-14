using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE4
{
    /// <summary>
    /// A class that represents a weapon of type axe.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtWeaponAxe : MdtWeapon
    {
        /// <summary>
        /// A basic constructor that allows you to set the weapon holder and weapon type via constructor arguments.
        /// </summary>
        /// <param name="Holder">The holder of the weapon.</param>
        /// <param name="WeaponType">The type of weapon held.</param>
        /// <param name="Player">The type of the character holding the weapon.</param>
        public MdtWeaponAxe(MdtChar Holder, MdtWeaponType WeaponType, MdtPlayerType Player)
        : base(Holder, WeaponType, Player)
        {
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

        /// <summary>
        /// Creates a clone of this object instance.
        /// </summary>
        /// <returns>A new instance of this class.</returns>
        public new MdtWeaponAxe Clone()
        {
            MdtWeaponAxe ret = new MdtWeaponAxe(holder, weaponType, player);
            ret.SetAnimPrctComplete(GetAnimPrctComplete());
            ret.SetIsActive(GetIsActive());
            ret.SetAnimTimeMsCurrent(GetAnimTimeMsCurrent());
            ret.SetAnimTimeMsTotal(GetAnimTimeMsTotal());
            ret.SetAttackType(GetAttackType());

            if (GetMmgColor() == null)
            {
                ret.SetMmgColor(GetMmgColor());
            }
            else
            {
                ret.SetMmgColor(GetMmgColor().Clone());
            }

            if (GetCurrent() == null)
            {
                ret.SetCurrent(GetCurrent());
            }
            else
            {
                ret.SetCurrent(GetCurrent().Clone());
            }

            ret.SetDamage(GetDamage());
            ret.SetHeight(GetHeight());
            ret.SetHasParent(GetHasParent());
            ret.SetIsVisible(GetIsVisible());
            ret.SetId(GetId());
            ret.SetHolder(GetHolder());
            ret.SetParent(GetParent());

            if (GetPosition() == null)
            {
                ret.SetPosition(GetPosition());
            }
            else
            {
                ret.SetPosition(GetPosition().Clone());
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

        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        /// <returns>The X coordinate.</returns>
        public override int GetX()
        {
            if (throwingFrame == 0)
            {
                return subjBack.GetX();
            }
            else if (throwingFrame == 1)
            {
                return subjFront.GetX();
            }
            else if (throwingFrame == 2)
            {
                return subjLeft.GetX();
            }
            else
            {
                return subjRight.GetX();
            }
        }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        /// <returns>The Y coordinate.</returns>
        public override int GetY()
        {
            if (throwingFrame == 0)
            {
                return subjBack.GetY();
            }
            else if (throwingFrame == 1)
            {
                return subjFront.GetY();
            }
            else if (throwingFrame == 2)
            {
                return subjLeft.GetY();
            }
            else
            {
                return subjRight.GetY();
            }
        }

        /// <summary>
        /// Sets the position of the character.
        /// </summary>
        /// <param name="v">The position to set.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subjBack.SetPosition(v);
            subjFront.SetPosition(v);
            subjLeft.SetPosition(v);
            subjRight.SetPosition(v);
        }

        /// <summary>
        /// Sets the position of the character.
        /// </summary>
        /// <param name="x">The X coordinate to set.</param>
        /// <param name="y">The Y coordinate to set.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            subjBack.SetPosition(x, y);
            subjFront.SetPosition(x, y);
            subjLeft.SetPosition(x, y);
            subjRight.SetPosition(x, y);
        }

        /// <summary>
        /// Sets the X coordinate position of the character.
        /// </summary>
        /// <param name="i">The X coordinate to set.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subjBack.SetX(i);
            subjFront.SetX(i);
            subjLeft.SetX(i);
            subjRight.SetX(i);
        }

        /// <summary>
        /// Sets the Y coordinate position of the character.
        /// </summary>
        /// <param name="i">The Y coordinate to set.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subjBack.SetY(i);
            subjFront.SetY(i);
            subjLeft.SetY(i);
            subjRight.SetY(i);
        }
    }
}