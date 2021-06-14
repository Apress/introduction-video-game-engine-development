using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.DungeonTrap.ChapterE4_DemoScreen
{
    /// <summary>
    /// A class that represents an enemy character base.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtCharInter : MdtChar
    {
        /// <summary>
        /// A value indicating what type of player this is, player1 or player2.
        /// </summary>
        public MdtPlayerType playerType = MdtPlayerType.NONE;

        /// <summary>
        /// An MmgSprite that represents the break animation for this object.
        /// </summary>
        public MmgSprite subjBreaks = null;

        /// <summary>
        /// A bool flag indicating that the enemy has been broken.
        /// </summary>
        public bool isBroken = false;

        /// <summary>
        /// The player that broke the current enemy.
        /// </summary>
        public MdtPlayerType brokenBy;

        /// <summary>
        /// A bool indicating if this player is being bounced by a colliding object.
        /// </summary>
        public bool isBouncing = false;

        /// <summary>
        /// The original starting direction of the bounce.
        /// </summary>
        public int bounceDirOrig = 0;

        /// <summary>
        /// The direction to move this player on the X axis in response to the bounce.
        /// </summary>
        public int bounceDirX = 0;

        /// <summary>
        /// The direction to move this player on the Y axis in response to the bounce.
        /// </summary>
        public int bounceDirY = 0;

        /// <summary>
        /// The current duration of the bounce, if active, in milliseconds. 
        /// </summary>
        public long bouncingCurrentMs;

        /// <summary>
        /// The total amount of time in milliseconds that the player will bounce.
        /// </summary>
        public long bouncingLengthMs = 175;

        /// <summary>
        /// The motor type to use for the given character.
        /// </summary>
        public MdtEnemyMotorType motor = MdtEnemyMotorType.NONE;

        /// <summary>
        /// The time in milliseconds that the current player has been moving in AI mode.
        /// </summary>
        private long motorMoveMs = 0;

        /// <summary>
        /// The total time in milliseconds that the current player will move in AI mode. 
        /// </summary>
        private long motorMoveLengthMs = 350;

        /// <summary>
        /// The player that this character is targeting for attack.
        /// </summary>
        private MdtPlayerType targetPlayer = MdtPlayerType.NONE;

        /// <summary>
        /// MdtEnemyDemon constructor that allows you to specify the sprite animation frames for this character, for all directions.
        /// </summary>
        /// <param name="Subj">The subject of the object instance.</param>
        /// <param name="FrameFrontS">The front start frame.</param>
        /// <param name="FrameFrontE">The front end frame.</param>
        /// <param name="FrameBackS">The back start frame.</param>
        /// <param name="FrameBackE">The back end frame.</param>
        /// <param name="FrameLeftS">The left start frame.</param>
        /// <param name="FrameLeftE">The left end frame.</param>
        /// <param name="FrameRightS">The right start frame.</param>
        /// <param name="FrameRightE">The right end frame.</param>
        /// <param name="Screen">The game screen this character is on.</param>
        /// <param name="ObjType">The type of this object.</param>
        /// <param name="ObjSubType">The sub-type of this object.</param>
        public MdtCharInter(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen, MdtObjType ObjType, MdtObjSubType ObjSubType)
            : base(Subj, FrameFrontS, FrameFrontE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, FrameBackS, FrameBackE, Screen, ObjType, ObjSubType)
        {
            MmgBmp src = MmgHelper.GetBasicCachedBmp("explosion_anim_spritesheet_lg.png");
            MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);
            subjBreaks = new MmgSprite(ssSrc.GetFrames());
            subjBreaks.SetMsPerFrame(50);

            weapons = new Dictionary<string, MdtWeapon>();
            weapons.Add("sword", new MdtWeaponSword(this, MdtWeaponType.SWORD, MdtPlayerType.ENEMY));
            weapons.Add("axe", new MdtWeaponAxe(this, MdtWeaponType.AXE, MdtPlayerType.ENEMY));
            weapons.Add("spear", new MdtWeaponSpear(this, MdtWeaponType.SPEAR, MdtPlayerType.ENEMY));

            weaponCurrent = weapons["spear"];
            weaponCurrent.SetHolder(this);
            weaponCurrent.active = true;
        }

        /// <summary>
        /// A method that causes this player to bounce using directions calculated from the initial collision.
        /// </summary>
        /// <param name="collPos">The position of the colliding object that causes the bounce.</param>
        /// <param name="halfWidth"></param>
        /// <param name="halfHeight"></param>
        /// <param name="bounceDir">The direction the colliding object was moving in.</param>
        /// <param name="BounceBy"></param>
        public virtual void Bounce(MmgVector2 collPos, int halfWidth, int halfHeight, int bounceDir, MdtPlayerType BounceBy)
        {
            bounceDirOrig = bounceDir;
            isMoving = false;

            bouncingCurrentMs = 0;
            isBouncing = true;

            if (bounceDir == MmgDir.DIR_LEFT || bounceDir == MmgDir.DIR_RIGHT)
            {
                if (collPos.GetY() + halfHeight >= GetY() + GetHeight() / 2)
                {
                    bounceDirX = bounceDir;
                    bounceDirY = MmgDir.DIR_BACK;
                }
                else
                {
                    bounceDirX = bounceDir;
                    bounceDirY = MmgDir.DIR_FRONT;
                }
            }
            else if (bounceDir == MmgDir.DIR_FRONT || bounceDir == MmgDir.DIR_BACK)
            {
                if (collPos.GetX() + halfWidth >= GetX() + GetWidth() / 2)
                {
                    bounceDirX = MmgDir.DIR_LEFT;
                    bounceDirY = bounceDir;
                }
                else
                {
                    bounceDirX = MmgDir.DIR_RIGHT;
                    bounceDirY = bounceDir;
                }
            }

            if (playerType == MdtPlayerType.ENEMY)
            {
                TakeDamage(1, BounceBy);
            }
        }

        /// <summary>
        /// Gets the enemy character's motor type.
        /// </summary>
        /// <returns>The enemy character's motor type.</returns>
        public virtual MdtEnemyMotorType GetMotor()
        {
            return motor;
        }

        /// <summary>
        /// Sets the enemy character's motor type.
        /// </summary>
        /// <param name="m">The enemy character's motor type.</param>
        public virtual void SetMotor(MdtEnemyMotorType m)
        {
            motor = m;
        }

        /// <summary>
        /// Gets the type of this player.
        /// </summary>
        /// <returns>The type of this player.</returns>
        public virtual MdtPlayerType GetPlayerType()
        {
            return playerType;
        }

        /// <summary>
        /// Sets the type of this player.
        /// </summary>
        /// <param name="p">The type of this player.</param>
        public virtual void SetPlayerType(MdtPlayerType p)
        {
            playerType = p;
        }

        /// <summary>
        /// Gets an MmgSprite that is used to show the character has been broken.
        /// </summary>
        /// <returns>An MmgSprite that is used to show the character has been broken.</returns>
        public virtual MmgSprite GetSubjBreaks()
        {
            return subjBreaks;
        }

        /// <summary>
        /// Sets an MmgSprite that is used to show the character has been broken.
        /// </summary>
        /// <param name="s">An MmgSprite that is used to show the character has been broken.</param>
        public virtual void SetSubjBreaks(MmgSprite s)
        {
            subjBreaks = s;
        }

        /// <summary>
        /// Gets a bool indicating if the character is broken.
        /// </summary>
        /// <returns>A bool indicating if the character is broken.</returns>
        public virtual bool GetIsBroken()
        {
            return isBroken;
        }

        /// <summary>
        /// Sets a bool indicating if the character is broken.
        /// </summary>
        /// <param name="b">A bool indicating if the character is broken.</param>
        public virtual void SetIsBroken(bool b)
        {
            isBroken = b;
        }

        /// <summary>
        /// Gets the player that broke this character.
        /// </summary>
        /// <returns>The player that broke this character.</returns>
        public virtual MdtPlayerType GetBrokenBy()
        {
            return brokenBy;
        }

        /// <summary>
        /// Sets the player that broke this character.
        /// </summary>
        /// <param name="p">The player that broke this character.</param>
        public virtual void SetBrokenBy(MdtPlayerType p)
        {
            brokenBy = p;
        }

        /// <summary>
        /// Gets a bool indicating if this character is being bounced.
        /// </summary>
        /// <returns>A bool indicating if this character is being bounced.</returns>
        public virtual bool GetIsBouncing()
        {
            return isBouncing;
        }

        /// <summary>
        /// Sets a bool indicating if this character is being bounced.
        /// </summary>
        /// <param name="b">A bool indicating if this character is being bounced.</param>
        public virtual void SetIsBouncing(bool b)
        {
            isBouncing = b;
        }

        /// <summary>
        /// Gets the current time in milliseconds of the current bounce duration.
        /// </summary>
        /// <returns>The current time in milliseconds of the current bounce duration.</returns>
        public virtual long GetBouncingCurrentMs()
        {
            return bouncingCurrentMs;
        }

        /// <summary>
        /// Sets the current time in milliseconds of the current bounce duration.
        /// </summary>
        /// <param name="l">The current time in milliseconds of the current bounce duration.</param>
        public virtual void SetBouncingCurrentMs(long l)
        {
            bouncingCurrentMs = l;
        }

        /// <summary>
        /// Gets the total amount of time in milliseconds that a bounce persists.
        /// </summary>
        /// <returns>The total amount of time in milliseconds that a bounce persists.</returns>
        public virtual long GetBouncingLengthMs()
        {
            return bouncingLengthMs;
        }

        /// <summary>
        /// Sets the total amount of time in milliseconds that a bounce persists.
        /// </summary>
        /// <param name="l">The total amount of time in milliseconds that a bounce persists.</param>
        public virtual void SetBouncingLengthMs(long l)
        {
            bouncingLengthMs = l;
        }

        /// <summary>
        /// Sets the current character's direction without resetting the current directory.
        /// </summary>
        /// <param name="d">The direction in which to set the current character.</param>
        public virtual void SetDirSafe(int d)
        {
            if (GetDir() != d)
            {
                SetDir(d);
            }
        }

        /// <summary>
        /// Sets the current direction of the character.
        /// </summary>
        /// <param name="d">The direction code.</param>
        public override void SetDir(int d)
        {
            if (d == MmgDir.DIR_FRONT)
            {
                subj.SetFrameStart(frameFrontStart);
                subj.SetFrameStop(frameFrontStop);
                subj.SetFrameIdx(frameFrontStart);
            }
            else if (d == MmgDir.DIR_BACK)
            {
                subj.SetFrameStart(frameBackStart);
                subj.SetFrameStop(frameBackStop);
                subj.SetFrameIdx(frameBackStart);
            }
            else if (d == MmgDir.DIR_LEFT)
            {
                subj.SetFrameStart(frameLeftStart);
                subj.SetFrameStop(frameLeftStop);
                subj.SetFrameIdx(frameLeftStart);
            }
            else if (d == MmgDir.DIR_RIGHT)
            {
                subj.SetFrameStart(frameRightStart);
                subj.SetFrameStop(frameRightStop);
                subj.SetFrameIdx(frameRightStart);
            }
            dir = d;
        }

        /// <summary>
        /// Sets the position of the character.
        /// </summary>
        /// <param name="v">The position to set.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subj.SetPosition(v);
            subjBreaks.SetPosition(v.GetX() + (subj.GetWidth() - subjBreaks.GetWidth()) / 2, v.GetY() + (subj.GetHeight() - subjBreaks.GetHeight()) / 2);
        }

        /// <summary>
        /// Sets the position of the character.
        /// </summary>
        /// <param name="x">The X coordinate to set.</param>
        /// <param name="y">The Y coordinate to set.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            subj.SetPosition(x, y);
            subjBreaks.SetPosition(x + (subj.GetWidth() - subjBreaks.GetWidth()) / 2, y + (subj.GetHeight() - subjBreaks.GetHeight()) / 2);
        }

        /// <summary>
        /// Sets the X coordinate position of the character.
        /// </summary>
        /// <param name="i">The X coordinate to set.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
            subjBreaks.SetX(i + (subj.GetWidth() - subjBreaks.GetWidth()) / 2);
        }

        /// <summary>
        /// Sets the Y coordinate position of the character.
        /// </summary>
        /// <param name="i">The Y coordinate to set.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subj.SetY(i);
            subjBreaks.SetY(i + (subj.GetHeight() - subjBreaks.GetHeight()) / 2);
        }

        /// <summary>
        /// Marks this character as receiving damage from the specified character in the specified amount.
        /// </summary>
        /// <param name="i">The amount of damage to apply to this character.</param>
        /// <param name="p">The player who applied the damage to this character.</param>
        public override void TakeDamage(int i, MdtPlayerType p)
        {
            base.TakeDamage(i, p);
            SetBrokenBy(p);
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
            if (isVisible == true)
            {
                if (isBroken)
                {
                    subjBreaks.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                    if (subjBreaks.GetFrameIdx() == subjBreaks.GetFrameStop())
                    {
                        if (GetPlayerType() == MdtPlayerType.ENEMY && GetRand().Next(11) % 2 == 0)
                        {
                            screen.UpdateGenerateItem(GetX(), GetY());
                        }
                        screen.UpdateRemoveObj(this, brokenBy);
                    }
                }
                else
                {
                    if (healthCurrent <= 0)
                    {
                        isBroken = true;
                    }

                    subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);

                    if (!isAttacking)
                    {
                        if (isBouncing)
                        {
                            bouncingCurrentMs += msSinceLastFrame;
                            if (bouncingCurrentMs <= bouncingLengthMs)
                            {
                                current = new MmgRect(subj.GetX(), subj.GetY(), subj.GetY() + subj.GetHeight(), subj.GetX() + subj.GetWidth());
                                if (speed < 0)
                                {
                                    speed *= -1;
                                }

                                int nX = 0;
                                int nY = 0;

                                if (bounceDirX == MmgDir.DIR_LEFT)
                                {
                                    nX = (speed * -2);
                                }
                                else if (bounceDirX == MmgDir.DIR_RIGHT)
                                {
                                    nX = (speed * 2);
                                }

                                if (bounceDirY == MmgDir.DIR_BACK)
                                {
                                    nY = (speed * -2);
                                }
                                else if (bounceDirY == MmgDir.DIR_FRONT)
                                {
                                    nY = (speed * 2);
                                }

                                if (bounceDirY == MmgDir.DIR_BACK)
                                {
                                    if (subj.GetY() - (speed * 2) >= ScreenGame.BOARD_TOP)
                                    {
                                        current.ShiftRect(nX, nY);
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetY(current.GetTop());
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            //stop
                                        }
                                        else
                                        {
                                            SetY(current.GetTop());
                                        }
                                    }
                                    else
                                    {
                                        SetY(ScreenGame.BOARD_TOP);
                                    }
                                }
                                else if (bounceDirY == MmgDir.DIR_FRONT)
                                {
                                    if (subj.GetY() + subj.GetHeight() + (speed * 2) <= ScreenGame.BOARD_BOTTOM)
                                    {
                                        current.ShiftRect(nX, nY);
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetY(current.GetTop());
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            //stop
                                        }
                                        else
                                        {
                                            SetY(current.GetTop());
                                        }
                                    }
                                    else
                                    {
                                        SetY(ScreenGame.BOARD_BOTTOM - subj.GetHeight());
                                    }
                                }

                                if (bounceDirX == MmgDir.DIR_LEFT)
                                {
                                    if (subj.GetX() - (speed * 2) >= ScreenGame.BOARD_LEFT)
                                    {
                                        current.ShiftRect(nX, nY);
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetX(current.GetLeft());
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            //stop
                                        }
                                        else
                                        {
                                            SetX(current.GetLeft());
                                        }
                                    }
                                    else
                                    {
                                        SetX(ScreenGame.BOARD_LEFT);
                                    }
                                }
                                else if (bounceDirX == MmgDir.DIR_RIGHT)
                                {
                                    if (subj.GetX() + subj.GetWidth() + (speed * 2) <= ScreenGame.BOARD_RIGHT)
                                    {
                                        current.ShiftRect(nX, nY);
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetX(current.GetLeft());
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.PLAYER)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.ENEMY)
                                        {
                                            ((MdtCharInter)coll).Bounce(GetPosition(), GetWidth() / 2, GetHeight() / 2, bounceDirOrig, playerType);
                                        }
                                        else if (coll.GetMdtType() == MdtObjType.OBJECT)
                                        {
                                            //stop
                                        }
                                        else
                                        {
                                            SetX(current.GetLeft());
                                        }
                                    }
                                    else
                                    {
                                        SetX(ScreenGame.BOARD_RIGHT - subj.GetWidth());
                                    }
                                }
                            }
                            else
                            {
                                isBouncing = false;
                                bouncingCurrentMs = 0;
                            }
                        }

                        if (motor != MdtEnemyMotorType.NONE && playerType == MdtPlayerType.ENEMY)
                        {
                            MmgVector2 mPos = null;
                            if (targetPlayer == MdtPlayerType.NONE)
                            {
                                if (screen.GetGameType() == GameType.GAME_TWO_PLAYER && !screen.GetPlayer2Broken())
                                {
                                    int t = GetRand().Next(11);
                                    if (t % 2 == 0)
                                    {
                                        targetPlayer = MdtPlayerType.PLAYER_1;
                                    }
                                    else
                                    {
                                        targetPlayer = MdtPlayerType.PLAYER_2;
                                    }
                                }
                                else
                                {
                                    targetPlayer = MdtPlayerType.PLAYER_1;
                                }
                            }

                            if (screen.GetGameType() == GameType.GAME_ONE_PLAYER)
                            {
                                mPos = screen.GetPlayer1Pos();
                            }
                            else if (screen.GetGameType() == GameType.GAME_TWO_PLAYER)
                            {
                                if (targetPlayer == MdtPlayerType.PLAYER_1 && !screen.GetPlayer1Broken())
                                {
                                    mPos = screen.GetPlayer1Pos();
                                }
                                else if (targetPlayer == MdtPlayerType.PLAYER_2 && !screen.GetPlayer2Broken())
                                {
                                    mPos = screen.GetPlayer2Pos();
                                }
                            }

                            if (mPos != null)
                            {
                                motorMoveMs += msSinceLastFrame;
                                if (motorMoveMs >= motorMoveLengthMs)
                                {
                                    int t = GetRand().Next(11);
                                    if (t % 3 == 0)
                                    {
                                        isMoving = true;
                                    }
                                    else
                                    {
                                        isMoving = false;
                                    }
                                    motorMoveMs = 0;
                                }

                                if (motor == MdtEnemyMotorType.MOVE_X_THEN_Y)
                                {
                                    if (GetX() + GetWidth() / 2 < mPos.GetX())
                                    {
                                        SetDirSafe(MmgDir.DIR_RIGHT);
                                    }
                                    else if (GetX() > mPos.GetX() + GetWidth() / 2)
                                    {
                                        SetDirSafe(MmgDir.DIR_LEFT);
                                    }
                                    else if (GetY() + GetHeight() / 2 < mPos.GetY())
                                    {
                                        SetDirSafe(MmgDir.DIR_FRONT);
                                    }
                                    else
                                    {
                                        SetDirSafe(MmgDir.DIR_BACK);
                                    }
                                }
                                else if (motor == MdtEnemyMotorType.MOVE_Y_THEN_X)
                                {
                                    if (GetY() + GetHeight() / 2 < mPos.GetY())
                                    {
                                        SetDirSafe(MmgDir.DIR_FRONT);
                                    }
                                    else if (GetY() > mPos.GetY() + GetHeight() / 2)
                                    {
                                        SetDirSafe(MmgDir.DIR_BACK);
                                    }
                                    else if (GetX() + GetWidth() / 2 < mPos.GetX())
                                    {
                                        SetDirSafe(MmgDir.DIR_RIGHT);
                                    }
                                    else
                                    {
                                        SetDirSafe(MmgDir.DIR_LEFT);
                                    }
                                }
                            }
                            else
                            {
                                isMoving = false;
                            }
                        }

                        if (dir != MmgDir.DIR_NONE)
                        {
                            current = new MmgRect(subj.GetX(), subj.GetY(), subj.GetY() + subj.GetHeight(), subj.GetX() + subj.GetWidth());
                            if (speed < 0)
                            {
                                speed *= -1;
                            }

                            if (isMoving == true)
                            {
                                if (dir == MmgDir.DIR_BACK)
                                {
                                    if (subj.GetY() - speed >= ScreenGame.BOARD_TOP)
                                    {
                                        current.ShiftRect(0, (speed * -1));
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetY(current.GetTop());
                                        }
                                        else
                                        {
                                            screen.UpdateProcessCollision(this, coll);
                                            if (playerType == MdtPlayerType.ENEMY)
                                            {
                                                motorMoveMs = motorMoveLengthMs;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SetY(ScreenGame.BOARD_TOP);
                                    }
                                }
                                else if (dir == MmgDir.DIR_FRONT)
                                {
                                    if (subj.GetY() + subj.GetHeight() + speed <= ScreenGame.BOARD_BOTTOM)
                                    {
                                        current.ShiftRect(0, (speed * 1));
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetY(current.GetTop());
                                        }
                                        else
                                        {
                                            screen.UpdateProcessCollision(this, coll);
                                            if (playerType == MdtPlayerType.ENEMY)
                                            {
                                                motorMoveMs = motorMoveLengthMs;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SetY(ScreenGame.BOARD_BOTTOM - subj.GetHeight());
                                    }
                                }
                                else if (dir == MmgDir.DIR_LEFT)
                                {
                                    if (subj.GetX() - speed >= ScreenGame.BOARD_LEFT)
                                    {
                                        current.ShiftRect((speed * -1), 0);
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetX(current.GetLeft());
                                        }
                                        else
                                        {
                                            screen.UpdateProcessCollision(this, coll);
                                            if (playerType == MdtPlayerType.ENEMY)
                                            {
                                                motorMoveMs = motorMoveLengthMs;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SetX(ScreenGame.BOARD_LEFT);
                                    }
                                }
                                else if (dir == MmgDir.DIR_RIGHT)
                                {
                                    if (subj.GetX() + subj.GetWidth() + speed <= ScreenGame.BOARD_RIGHT)
                                    {
                                        current.ShiftRect((speed * 1), 0);
                                        coll = screen.CanMove(current, this);
                                        if (coll == null)
                                        {
                                            SetX(current.GetLeft());
                                        }
                                        else
                                        {
                                            screen.UpdateProcessCollision(this, coll);
                                            if (playerType == MdtPlayerType.ENEMY)
                                            {
                                                motorMoveMs = motorMoveLengthMs;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SetX(ScreenGame.BOARD_RIGHT - subj.GetWidth());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (weaponCurrent.attackType == MdtWeaponAttackType.THROWING)
                        {
                            if (weaponCurrent.screen == null)
                            {
                                weaponCurrent.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                            }

                            if (weaponCurrent.throwingTimeMsCurrent >= weaponCurrent.throwingCoolDown)
                            {
                                isAttacking = false;
                            }
                        }
                        else if (weaponCurrent.attackType == MdtWeaponAttackType.STABBING)
                        {
                            if (weaponCurrent.screen == null)
                            {
                                weaponCurrent.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                            }

                            if (weaponCurrent.animTimeMsCurrent > (weaponCurrent.animTimeMsTotal + weaponCurrent.stabbingCoolDown))
                            {
                                isAttacking = false;
                            }
                        }

                        current = weaponCurrent.GetWeaponRect();
                        if (current != null)
                        {
                            coll = screen.CanMove(current, weaponCurrent);
                            if (coll != null)
                            {
                                screen.UpdateProcessWeaponCollision(coll, this, current);
                            }
                        }
                    }
                }
            }
            return lret;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (isBroken)
                {
                    subjBreaks.MmgDraw(p);
                }
                else
                {
                    if (isAttacking)
                    {
                        if (dir == MmgDir.DIR_BACK)
                        {
                            weaponCurrent.MmgDraw(p);
                            subj.MmgDraw(p);
                        }
                        else if (dir == MmgDir.DIR_FRONT)
                        {
                            subj.MmgDraw(p);
                            weaponCurrent.MmgDraw(p);
                        }
                        else if (dir == MmgDir.DIR_LEFT)
                        {
                            weaponCurrent.MmgDraw(p);
                            subj.MmgDraw(p);
                        }
                        else if (dir == MmgDir.DIR_RIGHT)
                        {
                            weaponCurrent.MmgDraw(p);
                            subj.MmgDraw(p);
                        }
                    }
                    else
                    {
                        subj.MmgDraw(p);
                    }
                }
            }
        }
    }
}