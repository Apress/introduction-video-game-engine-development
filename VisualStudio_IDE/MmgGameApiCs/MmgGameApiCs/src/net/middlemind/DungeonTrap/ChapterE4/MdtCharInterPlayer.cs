using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE4
{
    /// <summary>
    /// A class that represents a game player character.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtCharInterPlayer : MdtCharInter
    {
        /// <summary>
        /// The modifier type of the current player.
        /// </summary>
        public MdtPlayerModType mod = MdtPlayerModType.NONE;

        /// <summary>
        /// The previous modifier type of the current player.
        /// </summary>
        public MdtPlayerModType prevMod = MdtPlayerModType.NONE;

        /// <summary>
        /// A bool indicating that the full health modifier is active.
        /// </summary>
        public bool hasFullHealth = false;

        /// <summary>
        /// The duration of the full health modifier in milliseconds.
        /// </summary>
        public long modTimingFullHealth = 0;

        /// <summary>
        /// The total time the full health modifier is active in milliseconds.
        /// </summary>
        public long modTimingFullHealthTotal = 3000;

        /// <summary>
        /// A bool indicating that the invincibility modifier is active.
        /// </summary>
        public bool hasInvincibility = false;

        /// <summary>
        /// The invisibility mod's display time.
        /// </summary>
        public long modTimingInv = 0;

        /// <summary>
        /// The invisibility mod's total display time.
        /// </summary>
        public long modTimingInvTotal = 10000;

        /// <summary>
        /// A bool indicating that the double points modifier is active.
        /// </summary>
        public bool hasDoublePoints = false;

        /// <summary>
        /// The double points modifier's current display time in milliseconds.
        /// </summary>
        public long modTimingDp = 0;

        /// <summary>
        /// The double points modifier's total display time in milliseconds.
        /// </summary>
        public long modTimingDpTotal = 15000;

        /// <summary>
        /// A bool indicating if this player is pushing an object.
        /// </summary>
        public bool isPushing = false;

        /// <summary>
        /// A bool indicating if this player has started pushing an object.
        /// </summary>
        public bool isPushStart = false;

        /// <summary>
        /// The time in milliseconds when the player starting pushing an object.
        /// </summary>
        public long pushingStartMs;

        /// <summary>
        /// The current time in milliseconds that the player has been pushing an object.
        /// </summary>
        public long pushingCurrentMs;

        /// <summary>
        /// The total time in milliseconds that a player must push an object to move it.
        /// </summary>
        public long pushingLengthMs = 150;

        /// <summary>
        /// MdtPlayer constructor that allows you to specify the sprite animation frames for this character, for all directions.
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
        /// <param name="Player">The player type of this player character.</param>
        public MdtCharInterPlayer(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen, MdtPlayerType Player)
            : base(Subj, FrameFrontS, FrameFrontE, FrameBackS, FrameBackE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, Screen, MdtObjType.PLAYER, MdtObjSubType.PLAYER_1)
        {
            SetPlayerType(Player);

            if (Player == MdtPlayerType.PLAYER_1)
            {
                SetMdtSubType(MdtObjSubType.PLAYER_1);
            }
            else
            {
                SetMdtSubType(MdtObjSubType.PLAYER_2);
            }

            SetHealthMax(4);
            SetHealthCurrent(4);
        }

        /// <summary>
        /// MdtPlayer constructor that allows you to specify the sprite animation frames for this character, for all directions.
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
        /// <param name="Weapons">A data structure of weapons for this character.</param>
        /// <param name="WeaponKey">The key of the current weapon for this character.</param>
        public MdtCharInterPlayer(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen, Dictionary<String, MdtWeapon> Weapons, String WeaponKey)
            : base(Subj, FrameFrontS, FrameFrontE, FrameBackS, FrameBackE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, Screen, MdtObjType.PLAYER, MdtObjSubType.PLAYER_1)
        {
            SetPlayerType(MdtPlayerType.PLAYER_1);
            SetHealthMax(4);
            SetHealthCurrent(4);
            weaponCurrent.SetPlayer(GetPlayerType());
        }

        /// <summary>
        /// A method that causes this player to bounce using directions calculated from the initial collision.
        /// </summary>
        /// <param name="collPos">The position of the colliding object that causes the bounce.</param>
        /// <param name="halfWidth"></param>
        /// <param name="halfHeight"></param>
        /// <param name="bounceDir">The direction the colliding object was moving in.</param>
        /// <param name="BounceBy"></param>
        public override void Bounce(MmgVector2 collPos, int halfWidth, int halfHeight, int bounceDir, MdtPlayerType BounceBy)
        {
            base.Bounce(collPos, halfWidth, halfHeight, bounceDir, BounceBy);
            isPushStart = false;
            isPushing = false;
            pushingCurrentMs = 0;
        }

        /// <summary>
        /// Get the previous player modification.
        /// </summary>
        /// <returns>The previous player modification.</returns>
        public virtual MdtPlayerModType GetPrevMod()
        {
            return prevMod;
        }

        /// <summary>
        /// Set the previous player modification.
        /// </summary>
        /// <param name="mod">The previous player modification.</param>
        public virtual void SetPrevMod(MdtPlayerModType mod)
        {
            prevMod = mod;
            if (prevMod == MdtPlayerModType.DOUBLE_POINTS)
            {
                hasDoublePoints = false;
            }
            else if (prevMod == MdtPlayerModType.INVINCIBLE)
            {
                hasInvincibility = false;
            }
            else if (prevMod == MdtPlayerModType.FULL_HEALTH)
            {
                hasFullHealth = false;
            }
        }

        /// <summary>
        /// Gets a bool indicating if the player has full health.
        /// </summary>
        /// <returns>A bool indicating if the player has full health.</returns>
        public virtual bool GetHasFullHealth()
        {
            return hasFullHealth;
        }

        /// <summary>
        /// Sets a bool indicating if the player has full health.
        /// </summary>
        /// <param name="b">A bool indicating if the player has full health.</param>
        public virtual void SetHasFullHealth(bool b)
        {
            hasFullHealth = b;
        }

        /// <summary>
        /// Gets the current duration of time in milliseconds that the full health mod has been active.
        /// </summary>
        /// <returns>The current duration of time in milliseconds that the full health mod has been active.</returns>
        public virtual long GetModTimingFullHealth()
        {
            return modTimingFullHealth;
        }

        /// <summary>
        /// Sets the current duration of time in milliseconds that the full health mod has been active.
        /// </summary>
        /// <param name="i">The current duration of time in milliseconds that the full health mod has been active.</param>
        public virtual void SetModTimingFullHealth(long i)
        {
            modTimingFullHealth = i;
        }

        /// <summary>
        /// Gets the total amount of time in milliseconds that the full health mod is active.
        /// </summary>
        /// <returns>The total amount of time in milliseconds that the full health mod is active.</returns>
        public virtual long GetModTimingFullHealthTotal()
        {
            return modTimingFullHealthTotal;
        }

        /// <summary>
        /// Sets the total amount of time in milliseconds that the full health mod is active.
        /// </summary>
        /// <param name="i">The total amount of time in milliseconds that the full health mod is active.</param>
        public virtual void SetModTimingFullHealthTotal(long i)
        {
            modTimingFullHealthTotal = i;
        }

        /// <summary>
        /// Gets a bool indicating this player has the invincibility mod active.
        /// </summary>
        /// <returns>A bool indicating this player has the invincibility mod active.</returns>
        public virtual bool GetHasInvincibility()
        {
            return hasInvincibility;
        }

        /// <summary>
        /// Sets a bool indicating that this player has the invincibility mod active.
        /// </summary>
        /// <param name="b">A bool indicating this player has the invincibility mod active.</param>
        public virtual void SetHasInvincibility(bool b)
        {
            hasInvincibility = b;
        }

        /// <summary>
        /// Gets a bool indicating that this player has the double points mod active.
        /// </summary>
        /// <returns>A bool indicating that this player has the double points mod active.</returns>
        public virtual bool GetHasDoublePoints()
        {
            return hasDoublePoints;
        }

        /// <summary>
        /// Sets a bool indicating that this player has the double points mod active.
        /// </summary>
        /// <param name="b">A bool indicating that this player has the double points mod active.</param>
        public virtual void SetHasDoublePoints(bool b)
        {
            hasDoublePoints = b;
        }

        /// <summary>
        /// Gets the current time duration in milliseconds that the double points mod has been active.
        /// </summary>
        /// <returns>The current time duration in milliseconds that the double points mod has been active.</returns>
        public virtual long GetModTimingDp()
        {
            return modTimingDp;
        }

        /// <summary>
        /// Sets the current time duration in milliseconds that the double points mod has been active.
        /// </summary>
        /// <param name="i">The current time duration in milliseconds that the double points mod has been active.</param>
        public virtual void SetModTimingDp(long i)
        {
            modTimingDp = i;
        }

        /// <summary>
        /// Gets the total time in milliseconds that the double points mod is active.
        /// </summary>
        /// <returns>The total time in milliseconds that the double points mod is active.</returns>
        public virtual long GetModTimingDpTotal()
        {
            return modTimingDpTotal;
        }

        /// <summary>
        /// Sets the total time in milliseconds that the double points mod is active.
        /// </summary>
        /// <param name="i">The total time in milliseconds that the double points mod is active.</param>
        public virtual void SetModTimingDpTotal(long i)
        {
            modTimingDpTotal = i;
        }

        /// <summary>
        /// Gets the time duration in milliseconds that the player has been in pushing start state.
        /// </summary>
        /// <returns>The time duration in milliseconds that the player has been in pushing start state.</returns>
        public virtual long GetPushingStartMs()
        {
            return pushingStartMs;
        }

        /// <summary>
        /// Sets the time duration in milliseconds that the player has been in pushing start state.
        /// </summary>
        /// <param name="l">The time duration in milliseconds that the player has been in pushing start state.</param>
        public virtual void SetPushingStartMs(long l)
        {
            pushingStartMs = l;
        }

        /// <summary>
        /// Gets the current time duration in milliseconds that the player has been in the pushing state.
        /// </summary>
        /// <returns>The current time duration in milliseconds that the player has been in the pushing state.</returns>
        public virtual long GetPushingCurrentMs()
        {
            return pushingCurrentMs;
        }

        /// <summary>
        /// Sets the current time duration in milliseconds that the player has been in the pushing state.
        /// </summary>
        /// <param name="l">The current time duration in milliseconds that the player has been in the pushing state.</param>
        public virtual void SetPushingCurrentMs(long l)
        {
            pushingCurrentMs = l;
        }

        /// <summary>
        /// Gets the total time duration in milliseconds that the player can be in the pushing state.
        /// </summary>
        /// <returns>The total time duration in milliseconds that the player can be in the pushing state.</returns>
        public virtual long GetPushingLengthMs()
        {
            return pushingLengthMs;
        }

        /// <summary>
        /// Sets the total time duration in milliseconds that the player can be in the pushing state.
        /// </summary>
        /// <param name="l">The total time duration in milliseconds that the player can be in the pushing state.</param>
        public virtual void SetPushingLengthMs(long l)
        {
            pushingLengthMs = l;
        }

        /// <summary>
        /// Gets a bool indicating that the player is pushing an object.
        /// </summary>
        /// <returns>A bool indicating that the player is pushing an object.</returns>
        public virtual bool GetIsPushing()
        {
            return isPushing;
        }

        /// <summary>
        /// Sets a bool indicating that the player is pushing an object.
        /// </summary>
        /// <param name="b">A bool indicating that the player is pushing an object.</param>
        public virtual void SetIsPushing(bool b)
        {
            isPushing = b;
        }

        /// <summary>
        /// Gets the player modifier type.
        /// </summary>
        /// <returns>The player modifier type.</returns>
        public virtual MdtPlayerModType GetMod()
        {
            return mod;
        }

        /// <summary>
        /// Sets the player modifier type.
        /// </summary>
        /// <param name="Mod">The player modifier type.</param>
        public virtual void SetMod(MdtPlayerModType Mod)
        {
            SetPrevMod(mod);
            mod = Mod;
        }

        /// <summary>
        /// Gets the invisibility modifier's game time.
        /// </summary>
        /// <returns>The invisibility modifier's game time.</returns>
        public virtual long GetModTimingInv()
        {
            return modTimingInv;
        }

        /// <summary>
        /// Sets the invisibility modifier's game time.
        /// </summary>
        /// <param name="i">The invisibility modifier's game time.</param>
        public virtual void SetModTimingInv(long i)
        {
            modTimingInv = i;
        }

        /// <summary>
        /// Gets the invisibility modifier's total game time.
        /// </summary>
        /// <returns>The invisibility modifier's totalgame time.</returns>
        public virtual long GetModTimingInvTotal()
        {
            return modTimingInvTotal;
        }

        /// <summary>
        /// Sets the invisibility modifier's total game time.
        /// </summary>
        /// <param name="i">The invisibility modifier's totalgame time.</param>
        public virtual void SetModTimingInvTotal(long i)
        {
            modTimingInvTotal = i;
        }

        /// <summary>
        /// Gets the attack type of the current weapon.
        /// </summary>
        /// <returns>The attack type of the current weapon.</returns>
        public virtual MdtWeaponAttackType GetCurrentWeaponAttackType()
        {
            return weaponCurrent.attackType;
        }

        /// <summary>
        /// Sets the attack type of the current weapon.
        /// </summary>
        /// <returns>The attack type of the current weapon.</returns>
        public virtual MdtWeaponType GetCurrentWeaponType()
        {
            return weaponCurrent.weaponType;
        }

        /// <summary>
        /// Clears the invincibility effect from the given animation frames.
        /// </summary>
        /// <param name="subj">The given animation frames.</param>
        public virtual void ClearInvincibilityEffect(MmgSprite subj)
        {
            MmgBmp[] bmps = subj.GetBmpArray();
            int len = bmps.Length;
            for (int i = 0; i < len; i++)
            {
                bmps[i].SetMmgColor(null);
            }
        }

        /// <summary>
        /// A method that causes this player to bounce using directions calculated from the initial collision.
        /// </summary>
        /// <param name="collPos">The position of the colliding object that causes the bounce.</param>
        /// <param name="halfWidth"></param>
        /// <param name="halfHeight"></param>
        /// <param name="bounceDir">The direction the colliding object was moving in.</param>
        /// <param name="BounceBy"></param>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;
            if (isVisible == true)
            {
                base.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                if (!isBroken)
                {
                    if (mod == MdtPlayerModType.INVINCIBLE)
                    {
                        modTimingInv += msSinceLastFrame;
                        if (modTimingInv <= modTimingInvTotal)
                        {
                            int r = GetRand().Next(11);
                            if (r % 3 == 0)
                            {
                                subj.GetCurrentFrame().SetMmgColor(MmgColor.GetYellow());
                            }
                            else if (r % 3 == 1)
                            {
                                subj.GetCurrentFrame().SetMmgColor(MmgColor.GetWhite());
                            }
                            else if (r % 3 == 2)
                            {
                                subj.GetCurrentFrame().SetMmgColor(MmgColor.GetOrange());
                            }
                            else
                            {
                                subj.GetCurrentFrame().SetMmgColor(MmgColor.GetRedOrange());
                            }
                        }
                        else
                        {
                            modTimingInv = 0;
                            mod = MdtPlayerModType.NONE;
                            hasInvincibility = false;
                            screen.UpdateClearPlayerMod(playerType);
                            ClearInvincibilityEffect(subj);
                        }
                    }
                    else if (mod == MdtPlayerModType.FULL_HEALTH)
                    {
                        modTimingFullHealth += msSinceLastFrame;
                        if (modTimingFullHealth <= modTimingFullHealthTotal)
                        {
                            healthCurrent = healthMax;
                        }
                        else
                        {
                            modTimingFullHealth = 0;
                            mod = MdtPlayerModType.NONE;
                            hasFullHealth = false;
                            screen.UpdateClearPlayerMod(playerType);
                        }
                    }
                    else if (mod == MdtPlayerModType.DOUBLE_POINTS)
                    {
                        modTimingDp += msSinceLastFrame;
                        if (modTimingDp > modTimingDpTotal)
                        {
                            modTimingDp = 0;
                            mod = MdtPlayerModType.NONE;
                            hasDoublePoints = false;
                            screen.UpdateClearPlayerMod(playerType);
                        }
                    }

                    if (prevMod == MdtPlayerModType.INVINCIBLE && mod != MdtPlayerModType.INVINCIBLE)
                    {
                        ClearInvincibilityEffect(subj);
                    }
                }
            }
            return lret;
        }
    }
}