using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase1
{
    /// <summary>
    /// A class that represents the super class of all character weapons.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/22/2020
    /// </summary>
    public class MdtWeapon : MdtBase
    {
        /// <summary>
        /// The front subject of this weapon.
        /// </summary>
        public MmgBmp subjFront = null;

        /// <summary>
        /// The back subject of this weapon.
        /// </summary>
        public MmgBmp subjBack = null;

        /// <summary>
        /// The left subject of this weapon.
        /// </summary>
        public MmgBmp subjLeft = null;

        /// <summary>
        /// The right subject of this weapon.
        /// </summary>
        public MmgBmp subjRight = null;

        /// <summary>
        /// The character that is the owner of the weapon.
        /// </summary>
        public MdtChar holder = null;

        /// <summary>
        /// A bool indicating if this weapon is active or not.
        /// </summary>
        public bool active = false;

        /// <summary>
        /// An internal variable used in private class methods.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// The type of weapon this class represents.
        /// </summary>
        public MdtWeaponType weaponType = MdtWeaponType.NONE;

        /// <summary>
        /// The weapon animation current time in milliseconds.
        /// </summary>
        public long animTimeMsCurrent = 0;

        /// <summary>
        /// The weapon animation total time in milliseconds.
        /// </summary>
        public long animTimeMsTotal = 500;

        /// <summary>
        /// The weapon animation percent complete.
        /// </summary>
        public double animPrctComplete = 0.0d;

        /// <summary>
        /// The damage this weapon does.
        /// </summary>
        public int damage = 1;

        /// <summary>
        /// An MmgRect representing the weapon's source bounds.
        /// </summary>
        private MmgRect src = null;

        /// <summary>
        /// An MmgRect representing the weapon's destination bounds.
        /// </summary>
        private MmgRect dst = null;

        /// <summary>
        /// The throwing speed of this weapon if the weapon is configured to be throw-able.
        /// </summary>
        public int throwingSpeed = ScreenGame.GetSpeedPerFrame(120);

        /// <summary>
        /// The throwing speed skew.
        /// </summary>
        public int throwingSpeedSkew = ScreenGame.GetSpeedPerFrame(40);

        /// <summary>
        /// The throwing animation start frame.
        /// </summary>
        public int throwingFrame = 0;

        /// <summary>
        /// The throwing animation direction.
        /// </summary>
        public int throwingDir = 0;

        /// <summary>
        /// The throwing animation cool down time in milliseconds.
        /// </summary>
        public long throwingCoolDown = 500;

        /// <summary>
        /// The throwing animation current time in milliseconds.
        /// </summary>
        public long throwingTimeMsCurrent = 0;

        /// <summary>
        /// The throwing animation's rotation time in milliseconds.
        /// </summary>
        public long throwingTimeMsRotation = 200;

        /// <summary>
        /// The stabbing animation cool down time in milliseconds.
        /// </summary>
        public long stabbingCoolDown = 150;

        /// <summary>
        /// The screen this weapon belongs to.
        /// </summary>
        public ScreenGame screen = null;

        /// <summary>
        /// A variable used in class methods.
        /// </summary>
        private int tmpI = 0;

        /// <summary>
        /// A rectangle representing the current bounds of the weapon.
        /// </summary>
        public MmgRect current = null;

        /// <summary>
        /// The player that this weapon belongs to.
        /// </summary>
        public MdtPlayerType player;

        /// <summary>
        /// An MdtBase object instance used in determining collisions.
        /// </summary>
        public MdtBase coll = null;

        /// <summary>
        /// The attack type of this weapon.
        /// </summary>
        public MdtWeaponAttackType attackType = MdtWeaponAttackType.NONE;

        /// <summary>
        /// The throwing path this weapon uses.
        /// </summary>
        public MdtWeaponPathType throwingPath = MdtWeaponPathType.NONE;

        /// <summary>
        /// A random number generator used in class methods.
        /// </summary>
        private Random rand = null;

        /// <summary>
        /// A constructor that lets you specify the holder of the weapon and the weapon type.
        /// </summary>
        /// <param name="Holder">The character that is holding the weapon.</param>
        /// <param name="WeaponType">The type of weapon.</param>
        /// <param name="Player">The character type that is holding the weapon.</param>
        public MdtWeapon(MdtChar Holder, MdtWeaponType WeaponType, MdtPlayerType Player) : base()
        {
            SetMdtType(MdtObjType.WEAPON);
            SetPlayer(Player);
            SetHolder(Holder);
            SetWeaponType(WeaponType);
            SetAttackType(MdtWeaponAttackType.STABBING);
            SetRand(new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
        }

        /// <summary>
        /// A constructor that lets you specify the holder of the weapon, the weapon type, and the attack type.
        /// </summary>
        /// <param name="Holder">The character that is holding the weapon.</param>
        /// <param name="WeaponType">The type of weapon.</param>
        /// <param name="AttackType">The attack type of the weapon.</param>
        /// <param name="Player">The character type that is holding the weapon.</param>
        public MdtWeapon(MdtChar Holder, MdtWeaponType WeaponType, MdtWeaponAttackType AttackType, MdtPlayerType Player) : base()
        {
            SetMdtType(MdtObjType.WEAPON);
            SetPlayer(Player);
            SetHolder(Holder);
            SetWeaponType(WeaponType);
            SetAttackType(AttackType);
            SetRand(new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
        }

        /// <summary>
        /// Gets the player that holds this weapon.
        /// </summary>
        /// <returns>The player that holds this weapon.</returns>
        public virtual MdtPlayerType GetPlayer()
        {
            return player;
        }

        /// <summary>
        /// Sets the player that holds this weapon.
        /// </summary>
        /// <param name="p">The player that holds this weapon.</param>
        public virtual void SetPlayer(MdtPlayerType p)
        {
            player = p;
        }

        /// <summary>
        /// Gets the random number generator used by this class.
        /// </summary>
        /// <returns>The random number generator used by this class.</returns>
        public virtual Random GetRand()
        {
            return rand;
        }

        /// <summary>
        /// Sets the random number generator used by this class.
        /// </summary>
        /// <param name="r">The random number generator used by this class.</param>
        public virtual void SetRand(Random r)
        {
            rand = r;
        }

        /// <summary>
        /// Gets the front facing subject for this weapon.
        /// </summary>
        /// <returns>The front facing subject for this weapon.</returns>
        public virtual MmgBmp GetSubjFront()
        {
            return subjFront;
        }

        /// <summary>
        /// Sets the front facing subject for this weapon.
        /// </summary>
        /// <param name="SubjFront">The front facing subject for this weapon.</param>
        public virtual void SetSubjFront(MmgBmp SubjFront)
        {
            subjFront = SubjFront;
        }

        /// <summary>
        /// Gets the back facing subject for this weapon.
        /// </summary>
        /// <returns>The back facing subject for this weapon.</returns>
        public virtual MmgBmp GetSubjBack()
        {
            return subjBack;
        }

        /// <summary>
        /// Sets the back facing subject for this weapon.
        /// </summary>
        /// <param name="SubjBack">The back facing subject for this weapon.</param>
        public virtual void SetSubjBack(MmgBmp SubjBack)
        {
            subjBack = SubjBack;
        }

        /// <summary>
        /// Gets the left facing subject for this weapon.
        /// </summary>
        /// <returns>The left facing subject for this weapon.</returns>
        public virtual MmgBmp GetSubjLeft()
        {
            return subjLeft;
        }

        /// <summary>
        /// Sets the left facing subject for this weapon.
        /// </summary>
        /// <param name="SubjLeft">The left facing subject for this weapon.</param>
        public virtual void SetSubjLeft(MmgBmp SubjLeft)
        {
            subjLeft = SubjLeft;
        }

        /// <summary>
        /// Gets the right facing subject for this weapon.
        /// </summary>
        /// <returns>The right facing subject for this weapon.</returns>
        public virtual MmgBmp GetSubjRight()
        {
            return subjRight;
        }

        /// <summary>
        /// Sets the right facing subject for this weapon.
        /// </summary>
        /// <param name="SubjRight">The right facing subject for this weapon.</param>
        public virtual void SetSubjRight(MmgBmp SubjRight)
        {
            subjRight = SubjRight;
        }

        /// <summary>
        /// Gets the owner of this weapon.
        /// </summary>
        /// <returns>The owner of this weapon.</returns>
        public virtual MdtChar GetHolder()
        {
            return holder;
        }

        /// <summary>
        /// Sets the owner of this weapon.
        /// </summary>
        /// <param name="Holder">The holder of this weapon.</param>
        public virtual void SetHolder(MdtChar Holder)
        {
            holder = Holder;
        }

        /// <summary>
        /// Gets a bool indicating if the weapon is active.
        /// </summary>
        /// <returns>A bool indicating if the weapon is active.</returns>
        public virtual bool GetIsActive()
        {
            return active;
        }

        /// <summary>
        /// Sets a bool indicating if the weapon is active.
        /// </summary>
        /// <param name="b">A bool indicating if the weapon is active.</param>
        public virtual void SetIsActive(bool b)
        {
            active = b;
        }

        /// <summary>
        /// Gets the type of this weapon.
        /// </summary>
        /// <returns>The type of this weapon.</returns>
        public virtual MdtWeaponType GetWeaponType()
        {
            return weaponType;
        }

        /// <summary>
        /// Sets the type of this weapon.
        /// </summary>
        /// <param name="WeaponType">The type of this weapon.</param>
        public virtual void SetWeaponType(MdtWeaponType WeaponType)
        {
            weaponType = WeaponType;
        }

        /// <summary>
        /// Gets the current animation time in milliseconds.
        /// </summary>
        /// <returns>The current animation time in milliseconds.</returns>
        public virtual long GetAnimTimeMsCurrent()
        {
            return animTimeMsCurrent;
        }

        /// <summary>
        /// Sets the current animation time in milliseconds.
        /// </summary>
        /// <param name="h">The current animation time in milliseconds.</param>
        public virtual void SetAnimTimeMsCurrent(long h)
        {
            animTimeMsCurrent = h;
        }

        /// <summary>
        /// Gets the total animation time in milliseconds.
        /// </summary>
        /// <returns>The total animation time in milliseconds.</returns>
        public virtual long GetAnimTimeMsTotal()
        {
            return animTimeMsTotal;
        }

        /// <summary>
        /// Sets the total animation time in milliseconds.
        /// </summary>
        /// <param name="h">The total animation time in milliseconds.</param>
        public virtual void SetAnimTimeMsTotal(long h)
        {
            animTimeMsTotal = h;
        }

        /// <summary>
        /// Gets the percentage of animation complete.
        /// </summary>
        /// <returns>The percentage of animation complete.</returns>
        public virtual double GetAnimPrctComplete()
        {
            return animPrctComplete;
        }

        /// <summary>
        /// Sets the percentage of animation complete.
        /// </summary>
        /// <param name="d">The percentage of animation complete.</param>
        public virtual void SetAnimPrctComplete(double d)
        {
            animPrctComplete = d;
        }

        /// <summary>
        /// Gets the weapon damage.
        /// </summary>
        /// <returns>The weapon damage.</returns>
        public virtual int GetDamage()
        {
            return damage;
        }

        /// <summary>
        /// Sets the weapon damage.
        /// </summary>
        /// <param name="d">The weapon damage.</param>
        public virtual void SetDamage(int d)
        {
            damage = d;
        }

        /// <summary>
        /// Gets the source rectangle.
        /// </summary>
        /// <returns>The source rectangle.</returns>
        public virtual MmgRect GetSrc()
        {
            return src;
        }

        /// <summary>
        /// Sets the source rectangle.
        /// </summary>
        /// <param name="Src">The source rectangle.</param>
        public virtual void SetSrc(MmgRect Src)
        {
            src = Src;
        }

        /// <summary>
        /// Gets the destination rectangle.
        /// </summary>
        /// <returns>The destination rectangle.</returns>
        public virtual MmgRect GetDst()
        {
            return dst;
        }

        /// <summary>
        /// Sets the destination rectangle.
        /// </summary>
        /// <param name="Dst">The destination rectangle.</param>
        public virtual void SetDst(MmgRect Dst)
        {
            dst = Dst;
        }

        /// <summary>
        /// Gets the attack type of the weapon.
        /// </summary>
        /// <returns>The attack type of the weapon.</returns>
        public virtual MdtWeaponAttackType GetAttackType()
        {
            return attackType;
        }

        /// <summary>
        /// Sets the attack type of the weapon.
        /// </summary>
        /// <param name="AttackType">The attack type of the weapon.</param>
        public virtual void SetAttackType(MdtWeaponAttackType AttackType)
        {
            attackType = AttackType;
        }

        /// <summary>
        /// Gets the throwing path of this weapon if it's a throwing weapon.
        /// </summary>
        /// <returns>The throwing path of the weapon.</returns>
        public virtual MdtWeaponPathType GetThrowingPath()
        {
            return throwingPath;
        }

        /// <summary>
        /// Sets the throwing path of this weapon if it's a throwing weapon.
        /// </summary>
        /// <param name="ThrowingPath">The throwing path of the weapon.</param>
        public virtual void SetThrowingPath(MdtWeaponPathType ThrowingPath)
        {
            throwingPath = ThrowingPath;
        }

        /// <summary>
        /// Gets the throwing speed of the weapon.
        /// </summary>
        /// <returns>The throwing speed of the weapon.</returns>
        public virtual int GetThrowingSpeed()
        {
            return throwingSpeed;
        }

        /// <summary>
        /// Sets the throwing speed of the weapon.
        /// </summary>
        /// <param name="h">The throwing speed of the weapon.</param>
        public virtual void SetThrowingSpeed(int h)
        {
            throwingSpeed = h;
        }

        /// <summary>
        /// Gets the skew of the throwing speed.
        /// </summary>
        /// <returns>The skew of the throwing speed.</returns>
        public virtual int GetThrowingSpeedSkew()
        {
            return throwingSpeedSkew;
        }

        /// <summary>
        /// Sets the skew of the throwing speed.
        /// </summary>
        /// <param name="h">The skew of the throwing speed.</param>
        public virtual void SetThrowingSpeedSkew(int h)
        {
            throwingSpeedSkew = h;
        }

        /// <summary>
        /// Gets the frame of the throwing animation.
        /// </summary>
        /// <returns>The frame of the throwing animation.</returns>
        public virtual int GetThrowingFrame()
        {
            return throwingFrame;
        }

        /// <summary>
        /// Sets the frame of the throwing animation.
        /// </summary>
        /// <param name="h">The frame of the throwing animation.</param>
        public virtual void SetThrowingFrame(int h)
        {
            throwingFrame = h;
        }

        /// <summary>
        /// Gets the direction the weapon is thrown in.
        /// </summary>
        /// <returns>The direction the weapon is thrown in.</returns>
        public virtual int GetThrowingDir()
        {
            return throwingDir;
        }

        /// <summary>
        /// Sets the direction the weapon is thrown in.
        /// </summary>
        /// <param name="h">The direction the weapon is thrown in.</param>
        public virtual void SetThrowingDir(int h)
        {
            throwingDir = h;
        }

        /// <summary>
        /// Gets the stabbing animation cool down period.
        /// </summary>
        /// <returns>The stabbing animation cool down period.</returns>
        public virtual long GetStabbingCoolDown()
        {
            return stabbingCoolDown;
        }

        /// <summary>
        /// Sets the stabbing animation cool down period.
        /// </summary>
        /// <param name="h">The stabbing animation cool down period.</param>
        public virtual void SetStabbingCoolDown(long h)
        {
            stabbingCoolDown = h;
        }

        /// <summary>
        /// Gets the throwing animation cool down period.
        /// </summary>
        /// <returns>The throwing animation cool down period.</returns>
        public virtual long GetThrowingCoolDown()
        {
            return throwingCoolDown;
        }

        /// <summary>
        /// Sets the throwing animation cool down period.
        /// </summary>
        /// <param name="h">The throwing animation cool down period.</param>
        public virtual void SetThrowingCoolDown(long h)
        {
            throwingCoolDown = h;
        }

        /// <summary>
        /// Gets the current time of the throwing animation.
        /// </summary>
        /// <returns>The current time of the throwing animation.</returns>
        public virtual long GetThrowingTimeMsCurrent()
        {
            return throwingTimeMsCurrent;
        }

        /// <summary>
        /// Sets the current time of the throwing animation.
        /// </summary>
        /// <param name="h">The current time of the throwing animation.</param>
        public virtual void SetThrowingTimeMsCurrent(long h)
        {
            throwingTimeMsCurrent = h;
        }

        /// <summary>
        /// Gets the throwing animation rotation time in millisecond.
        /// </summary>
        /// <returns>The throwing animation time in milliseconds.</returns>
        public virtual long GetThrowingTimeMsRotation()
        {
            return throwingTimeMsRotation;
        }

        /// <summary>
        /// Sets the throwing animation rotation time in millisecond.
        /// </summary>
        /// <param name="h">The throwing animation time in milliseconds.</param>
        public virtual void SetThrowingTimeMsRotation(long h)
        {
            throwingTimeMsRotation = h;
        }

        /// <summary>
        /// Gets the current screen this object is on.
        /// </summary>
        /// <returns>The current screen this object is on.</returns>
        public virtual ScreenGame GetScreen()
        {
            return screen;
        }

        /// <summary>
        /// Sets the current screen this object is on.
        /// </summary>
        /// <param name="Screen">The current screen this object is on.</param>
        public virtual void SetScreen(ScreenGame Screen)
        {
            screen = Screen;
        }

        /// <summary>
        /// Gets the current collision rectangle.
        /// </summary>
        /// <returns>The current collision rectangle.</returns>
        public virtual MmgRect GetCurrent()
        {
            return current;
        }

        /// <summary>
        /// Sets the current collision rectangle.
        /// </summary>
        /// <param name="Current">The current collision rectangle.</param>
        public virtual void SetCurrent(MmgRect Current)
        {
            current = Current;
        }

        /// <summary>
        /// Creates a clone of this object instance.
        /// </summary>
        /// <returns>A new instance of this class.</returns>
        public new MdtWeapon Clone()
        {
            MdtWeapon ret = new MdtWeapon(holder, weaponType, player);
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

            if (GetSubjBack() == null)
            {
                ret.SetSubjBack(GetSubjBack());
            }
            else
            {
                ret.SetSubjBack(GetSubjBack().CloneTyped());
            }

            if (GetSubjFront() == null)
            {
                ret.SetSubjFront(GetSubjFront());
            }
            else
            {
                ret.SetSubjFront(GetSubjFront().CloneTyped());
            }

            if (GetSubjLeft() == null)
            {
                ret.SetSubjLeft(GetSubjLeft());
            }
            else
            {
                ret.SetSubjLeft(GetSubjLeft().CloneTyped());
            }

            if (GetSubjRight() == null)
            {
                ret.SetSubjRight(GetSubjRight());
            }
            else
            {
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

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;
            if (isVisible == true && active == true)
            {
                animTimeMsCurrent += msSinceLastFrame;

                if (attackType == MdtWeaponAttackType.THROWING)
                {
                    if (current == null)
                    {
                        current = new MmgRect(holder.GetX() + holder.GetWidth() / 2 - GetWidth() / 2, holder.GetY() + holder.GetHeight() / 2 - GetHeight() / 2, holder.GetY() + holder.GetHeight() / 2 + GetHeight() / 2, holder.GetX() + holder.GetWidth() / 2 + GetWidth() / 2);
                        throwingFrame = 0;
                    }

                    if (throwingSpeed < 0)
                    {
                        throwingSpeed *= -1;
                    }

                    throwingTimeMsCurrent += msSinceLastFrame;

                    if (throwingPath == MdtWeaponPathType.NONE)
                    {
                        tmpI = rand.Next(11);
                        throwingDir = holder.dir;
                        if (tmpI % 2 == 0)
                        {
                            throwingPath = MdtWeaponPathType.PATH_1;
                        }
                        else if (tmpI % 3 == 0)
                        {
                            throwingPath = MdtWeaponPathType.PATH_2;
                        }
                        else
                        {
                            throwingPath = MdtWeaponPathType.PATH_3;
                        }
                    }
                    else
                    {
                        if (throwingDir == MmgDir.DIR_BACK)
                        {
                            if (throwingPath == MdtWeaponPathType.PATH_1)
                            {
                                current.ShiftRect((throwingSpeedSkew * -1), (throwingSpeed * -1));
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_2)
                            {
                                current.ShiftRect(0, (throwingSpeed * -1));
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_3)
                            {
                                current.ShiftRect((throwingSpeedSkew * 1), (throwingSpeed * -1));
                            }
                        }
                        else if (throwingDir == MmgDir.DIR_FRONT)
                        {
                            if (throwingPath == MdtWeaponPathType.PATH_1)
                            {
                                current.ShiftRect((throwingSpeedSkew * -1), (throwingSpeed * 1));
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_2)
                            {
                                current.ShiftRect(0, (throwingSpeed * 1));
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_3)
                            {
                                current.ShiftRect((throwingSpeedSkew * 1), (throwingSpeed * 1));
                            }
                        }
                        else if (throwingDir == MmgDir.DIR_LEFT)
                        {
                            if (throwingPath == MdtWeaponPathType.PATH_1)
                            {
                                current.ShiftRect((throwingSpeed * -1), (throwingSpeedSkew * 1));
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_2)
                            {
                                current.ShiftRect((throwingSpeed * -1), 0);
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_3)
                            {
                                current.ShiftRect((throwingSpeed * -1), (throwingSpeedSkew * -1));
                            }
                        }
                        else if (throwingDir == MmgDir.DIR_RIGHT)
                        {
                            if (throwingPath == MdtWeaponPathType.PATH_1)
                            {
                                current.ShiftRect((throwingSpeed * 1), (throwingSpeedSkew * 1));
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_2)
                            {
                                current.ShiftRect((throwingSpeed * 1), 0);
                            }
                            else if (throwingPath == MdtWeaponPathType.PATH_3)
                            {
                                current.ShiftRect((throwingSpeed * 1), (throwingSpeedSkew * -1));
                            }
                        }

                        if (animTimeMsCurrent > throwingTimeMsRotation)
                        {
                            animTimeMsCurrent = 0;
                            throwingFrame++;
                            if (throwingFrame > 3)
                            {
                                throwingFrame = 0;
                            }
                        }

                        SetPosition(current.GetLeft(), current.GetTop());
                        coll = screen.CanMove(current, this);
                        if (coll != null)
                        {
                            if (coll.GetMdtType() == MdtObjType.ENEMY)
                            {
                                if (screen != null)
                                {
                                    screen.UpdateProcessWeaponCollision(coll, this, current);
                                    screen.UpdateRemoveObj(this, GetPlayer());
                                }
                            }
                        }

                        if (
                            GetX() < ScreenGame.BOARD_LEFT
                            || GetX() + GetWidth() > ScreenGame.BOARD_RIGHT
                            || GetY() < ScreenGame.BOARD_TOP
                            || GetY() + GetHeight() > ScreenGame.BOARD_BOTTOM
                        )
                        {
                            if (screen != null)
                            {
                                screen.UpdateRemoveObj(this, GetPlayer());
                            }
                        }
                    }
                }

                animPrctComplete = (double)animTimeMsCurrent / (double)animTimeMsTotal;
                if (animPrctComplete > 1.0d)
                {
                    animPrctComplete = 1.0d;
                }

                lret = true;
            }
            return lret;
        }

        /// <summary>
        /// An MmgRect instance that represents the visible portion of the weapon.
        /// </summary>
        /// <returns>An MmgRect instance that represents the visible portion of the weapon.</returns>
        public virtual MmgRect GetWeaponRect()
        {
            if (attackType == MdtWeaponAttackType.STABBING)
            {
                if (holder.dir == MmgDir.DIR_BACK)
                {
                    src = new MmgRect(0, 0, (int)(subjBack.GetHeight() * animPrctComplete), subjBack.GetWidth());
                    dst = new MmgRect((holder.GetX() + MmgHelper.ScaleValue(8) + holder.GetWidth() / 2 - src.GetWidth() / 2)
                            , (holder.GetY() + MmgHelper.ScaleValue(8) - src.GetHeight())
                            , (holder.GetY() + MmgHelper.ScaleValue(8))
                            , (holder.GetX() + MmgHelper.ScaleValue(8) + holder.GetWidth() / 2 + src.GetWidth() / 2)
                            );
                }
                else if (holder.dir == MmgDir.DIR_FRONT)
                {
                    src = new MmgRect(0, subjFront.GetHeight() - (int)(subjFront.GetHeight() * animPrctComplete), subjFront.GetHeight(), subjFront.GetWidth());
                    dst = new MmgRect((holder.GetX() - MmgHelper.ScaleValue(8) + holder.GetWidth() / 2 - src.GetWidth() / 2)
                            , (holder.GetY() - MmgHelper.ScaleValue(12) + holder.GetHeight())
                            , (holder.GetY() - MmgHelper.ScaleValue(12) + holder.GetHeight() + src.GetHeight())
                            , (holder.GetX() - MmgHelper.ScaleValue(8) + holder.GetWidth() / 2 + src.GetWidth() / 2)
                            );
                }
                else if (holder.dir == MmgDir.DIR_LEFT)
                {
                    src = new MmgRect(0, 0, subjLeft.GetHeight(), (int)(subjLeft.GetWidth() * animPrctComplete));
                    dst = new MmgRect((holder.GetX() + MmgHelper.ScaleValue(8) - src.GetWidth())
                            , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight() / 2 - src.GetHeight() / 2)
                            , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight() / 2 + src.GetHeight() / 2)
                            , (holder.GetX() + MmgHelper.ScaleValue(8))
                            );
                }
                else if (holder.dir == MmgDir.DIR_RIGHT)
                {
                    src = new MmgRect(subjRight.GetWidth() - (int)(subjRight.GetWidth() * animPrctComplete), 0, subjRight.GetHeight(), subjRight.GetWidth());
                    dst = new MmgRect((holder.GetX() + holder.GetWidth() - MmgHelper.ScaleValue(8))
                            , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight() / 2 - src.GetHeight() / 2)
                            , (holder.GetY() + MmgHelper.ScaleValue(8) + holder.GetHeight() / 2 + src.GetHeight() / 2)
                            , (holder.GetX() + holder.GetWidth() - MmgHelper.ScaleValue(8) + src.GetWidth())
                            );
                }
            }
            else if (attackType == MdtWeaponAttackType.THROWING && weaponType == MdtWeaponType.AXE)
            {
                if (throwingFrame == 0)
                {
                    dst = new MmgRect(subjBack.GetX(), subjBack.GetY(), subjBack.GetY() + subjBack.GetHeight(), subjBack.GetX() + subjBack.GetWidth());
                }
                else if (throwingFrame == 1)
                {
                    dst = new MmgRect(subjFront.GetX(), subjFront.GetY(), subjFront.GetY() + subjFront.GetHeight(), subjFront.GetX() + subjFront.GetWidth());
                }
                else if (throwingFrame == 2)
                {
                    dst = new MmgRect(subjLeft.GetX(), subjLeft.GetY(), subjLeft.GetY() + subjLeft.GetHeight(), subjLeft.GetX() + subjLeft.GetWidth());
                }
                else if (throwingFrame == 3)
                {
                    dst = new MmgRect(subjRight.GetX(), subjRight.GetY(), subjRight.GetY() + subjRight.GetHeight(), subjRight.GetX() + subjRight.GetWidth());
                }
            }
            return dst;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true && active == true)
            {
                GetWeaponRect();
                if (attackType == MdtWeaponAttackType.STABBING)
                {
                    if (holder.dir == MmgDir.DIR_BACK)
                    {
                        p.DrawBmp(subjBack, src, dst);
                    }
                    else if (holder.dir == MmgDir.DIR_FRONT)
                    {
                        p.DrawBmp(subjFront, src, dst);
                    }
                    else if (holder.dir == MmgDir.DIR_LEFT)
                    {
                        p.DrawBmp(subjLeft, src, dst);
                    }
                    else if (holder.dir == MmgDir.DIR_RIGHT)
                    {
                        p.DrawBmp(subjRight, src, dst);
                    }
                }
                else if (attackType == MdtWeaponAttackType.THROWING && weaponType == MdtWeaponType.AXE)
                {
                    if (throwingFrame == 0)
                    {
                        p.DrawBmp(subjBack);
                    }
                    else if (throwingFrame == 1)
                    {
                        p.DrawBmp(subjFront);
                    }
                    else if (throwingFrame == 2)
                    {
                        p.DrawBmp(subjLeft);
                    }
                    else if (throwingFrame == 3)
                    {
                        p.DrawBmp(subjRight);
                    }
                }
            }
        }
    }
}