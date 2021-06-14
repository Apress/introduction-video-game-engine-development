package game.jam.DungeonTrap;

import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A class that represents a game player character.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtCharInterPlayer extends MdtCharInter {

    /**
     * The modifier type of the current player.
     */
    public MdtPlayerModType mod = MdtPlayerModType.NONE;
 
    /**
     * The previous modifier type of the current player.
     */
    public MdtPlayerModType prevMod = MdtPlayerModType.NONE;    
    
    /**
     * A boolean indicating that the full health modifier is active.
     */
    public boolean hasFullHealth = false;
    
    /**
     * The duration of the full health modifier in milliseconds.
     */
    public long modTimingFullHealth = 0;
    
    /**
     * The total time the full health modifier is active in milliseconds.
     */
    public long modTimingFullHealthTotal = 3000;
    
    /**
     * A boolean indicating that the invincibility modifier is active.
     */
    public boolean hasInvincibility = false;
    
    /**
     * The invisibility mod's display time.
     */
    public long modTimingInv = 0;
    
    /**
     * The invisibility mod's total display time.
     */
    public long modTimingInvTotal = 10000;

    /**
     * A boolean indicating that the double points modifier is active.
     */
    public boolean hasDoublePoints = false;
    
    /**
     * The double points modifier's current display time in milliseconds.
     */
    public long modTimingDp = 0;
    
    /**
     * The double points modifier's total display time in milliseconds.
     */
    public long modTimingDpTotal = 15000;
        
    /**
     * A boolean indicating if this player is pushing an object.
     */
    public boolean isPushing = false;

    /**
     * A boolean indicating if this player has started pushing an object.
     */
    public boolean isPushStart = false;
    
    /**
     * The time in milliseconds when the player starting pushing an object.
     */
    public long pushingStartMs;

    /**
     * The current time in milliseconds that the player has been pushing an object.
     */
    public long pushingCurrentMs;

    /**
     * The total time in milliseconds that a player must push an object to move it.
     */
    public long pushingLengthMs = 150;
        
    /**
     * MdtPlayer constructor that allows you to specify the sprite animation frames for this character, for all directions.
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
     * @param Player            The player type of this player character.
     */
    public MdtCharInterPlayer(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen, MdtPlayerType Player) {        
        super(Subj, FrameFrontS, FrameFrontE, FrameBackS, FrameBackE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, Screen, MdtObjType.PLAYER, MdtObjSubType.PLAYER_1);
        SetPlayerType(Player);
        
        if(Player == MdtPlayerType.PLAYER_1) {
            SetMdtSubType(MdtObjSubType.PLAYER_1);
        } else {
            SetMdtSubType(MdtObjSubType.PLAYER_2);            
        }
        
        SetHealthMax(4);
        SetHealthCurrent(4);
    }
    
    /**
     * MdtPlayer constructor that allows you to specify the sprite animation frames for this character, for all directions.
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
     * @param Weapons           A data structure of weapons for this character.
     * @param WeaponKey         The key of the current weapon for this character.
     */
    public MdtCharInterPlayer(MmgSprite Subj, int FrameFrontS, int FrameFrontE, int FrameBackS, int FrameBackE, int FrameLeftS, int FrameLeftE, int FrameRightS, int FrameRightE, ScreenGame Screen, Hashtable<String, MdtWeapon> Weapons, String WeaponKey) {
        super(Subj, FrameFrontS, FrameFrontE, FrameBackS, FrameBackE, FrameLeftS, FrameLeftE, FrameRightS, FrameRightE, Screen, MdtObjType.PLAYER, MdtObjSubType.PLAYER_1);
        SetPlayerType(MdtPlayerType.PLAYER_1);        
        SetHealthMax(4);
        SetHealthCurrent(4);
        weaponCurrent.SetPlayer(GetPlayerType());
    }    

    /**
     * A method that causes this player to bounce using directions calculated from the initial collision.
     * 
     * @param collPos       The position of the colliding object that causes the bounce.
     * @param bounceDir     The direction the colliding object was moving in.
     */
    @Override
    public void Bounce(MmgVector2 collPos, int halfWidth, int halfHeight, int bounceDir, MdtPlayerType BounceBy) {
        super.Bounce(collPos, halfWidth, halfHeight, bounceDir, BounceBy);
        isPushStart = false;
        isPushing = false;
        pushingCurrentMs = 0;
    }
        
    /**
     * Get the previous player modification.
     * 
     * @return      The previous player modification.
     */
    public MdtPlayerModType GetPrevMod() {
        return prevMod;
    }

    /**
     * Set the previous player modification.
     * 
     * @param mod       The previous player modification. 
     */
    public void SetPrevMod(MdtPlayerModType mod) {
        prevMod = mod;        
        if(prevMod == MdtPlayerModType.DOUBLE_POINTS) {
            hasDoublePoints = false;
        } else if(prevMod == MdtPlayerModType.INVINCIBLE) {
            hasInvincibility = false;
        } else if(prevMod == MdtPlayerModType.FULL_HEALTH) {
            hasFullHealth = false;            
        }
    }
    
    /**
     * Gets a boolean indicating if the player has full health.
     * 
     * @return      A boolean indicating if the player has full health. 
     */
    public boolean GetHasFullHealth() {
        return hasFullHealth;
    }

    /**
     * Sets a boolean indicating if the player has full health.
     * 
     * @param b     A boolean indicating if the player has full health.  
     */
    public void SetHasFullHealth(boolean b) {
        hasFullHealth = b;
    }

    /**
     * Gets the current duration of time in milliseconds that the full health mod has been active.
     * 
     * @return      The current duration of time in milliseconds that the full health mod has been active. 
     */
    public long GetModTimingFullHealth() {
        return modTimingFullHealth;
    }

    /**
     * Sets the current duration of time in milliseconds that the full health mod has been active.
     * 
     * @param i     The current duration of time in milliseconds that the full health mod has been active. 
     */
    public void SetModTimingFullHealth(long i) {
        modTimingFullHealth = i;
    }

    /**
     * Gets the total amount of time in milliseconds that the full health mod is active.
     * 
     * @return      The total amount of time in milliseconds that the full health mod is active. 
     */
    public long GetModTimingFullHealthTotal() {
        return modTimingFullHealthTotal;
    }

    /**
     * Sets the total amount of time in milliseconds that the full health mod is active.
     * 
     * @param i     The total amount of time in milliseconds that the full health mod is active. 
     */
    public void SetModTimingFullHealthTotal(long i) {
        modTimingFullHealthTotal = i;
    }

    /**
     * Gets a boolean indicating this player has the invincibility mod active.
     * 
     * @return      A boolean indicating this player has the invincibility mod active. 
     */
    public boolean GetHasInvincibility() {
        return hasInvincibility;
    }

    /**
     * Sets a boolean indicating that this player has the invincibility mod active.
     * 
     * @param b     A boolean indicating this player has the invincibility mod active. 
     */
    public void SetHasInvincibility(boolean b) {
        hasInvincibility = b;
    }

    /**
     * Gets a boolean indicating that this player has the double points mod active.
     * 
     * @return      A boolean indicating that this player has the double points mod active.
     */
    public boolean GetHasDoublePoints() {
        return hasDoublePoints;
    }

    /**
     * Sets a boolean indicating that this player has the double points mod active.
     * 
     * @param b     A boolean indicating that this player has the double points mod active. 
     */
    public void SetHasDoublePoints(boolean b) {
        hasDoublePoints = b;
    }

    /**
     * Gets the current time duration in milliseconds that the double points mod has been active.
     * 
     * @return      The current time duration in milliseconds that the double points mod has been active. 
     */
    public long GetModTimingDp() {
        return modTimingDp;
    }

    /**
     * Sets the current time duration in milliseconds that the double points mod has been active.
     * 
     * @param i     The current time duration in milliseconds that the double points mod has been active. 
     */
    public void SetModTimingDp(long i) {
        modTimingDp = i;
    }

    /**
     * Gets the total time in milliseconds that the double points mod is active.
     * 
     * @return      The total time in milliseconds that the double points mod is active. 
     */
    public long GetModTimingDpTotal() {
        return modTimingDpTotal;
    }

    /**
     * Sets the total time in milliseconds that the double points mod is active.
     * 
     * @param i     The total time in milliseconds that the double points mod is active. 
     */
    public void SetModTimingDpTotal(long i) {
        modTimingDpTotal = i;
    }

    /**
     * Gets the time duration in milliseconds that the player has been in pushing start state.
     * 
     * @return      The time duration in milliseconds that the player has been in pushing start state. 
     */
    public long GetPushingStartMs() {
        return pushingStartMs;
    }

    /**
     * Sets the time duration in milliseconds that the player has been in pushing start state.
     * 
     * @param l     The time duration in milliseconds that the player has been in pushing start state. 
     */
    public void SetPushingStartMs(long l) {
        pushingStartMs = l;
    }

    /**
     * Gets the current time duration in milliseconds that the player has been in the pushing state.
     * 
     * @return      The current time duration in milliseconds that the player has been in the pushing state. 
     */
    public long GetPushingCurrentMs() {
        return pushingCurrentMs;
    }

    /**
     * Sets the current time duration in milliseconds that the player has been in the pushing state.
     * 
     * @param l         The current time duration in milliseconds that the player has been in the pushing state.
     */
    public void SetPushingCurrentMs(long l) {
        pushingCurrentMs = l;
    }

    /**
     * Gets the total time duration in milliseconds that the player can be in the pushing state.
     * 
     * @return      The total time duration in milliseconds that the player can be in the pushing state. 
     */
    public long GetPushingLengthMs() {
        return pushingLengthMs;
    }

    /**
     * Sets the total time duration in milliseconds that the player can be in the pushing state.
     * 
     * @param l     The total time duration in milliseconds that the player can be in the pushing state. 
     */
    public void SetPushingLengthMs(long l) {
        pushingLengthMs = l;
    }
    
    /**
     * Gets a boolean indicating that the player is pushing an object.
     * 
     * @return      A boolean indicating that the player is pushing an object. 
     */
    public boolean GetIsPushing() {
        return isPushing;
    }

    /**
     * Sets a boolean indicating that the player is pushing an object.
     * 
     * @param isPushing     A boolean indicating that the player is pushing an object. 
     */
    public void SetIsPushing(boolean b) {
        isPushing = b;
    }

    /**
     * Gets the player modifier type.
     * 
     * @return      The player modifier type.
     */
    public MdtPlayerModType GetMod() {
        return mod;
    }

    /**
     * Sets the player modifier type.
     * 
     * @param Mod   The player modifier type.
     */
    public void SetMod(MdtPlayerModType Mod) {        
        SetPrevMod(mod);
        mod = Mod;
    }

    /**
     * Gets the invisibility modifier's game time.
     * 
     * @return      The invisibility modifier's game time.
     */
    public long GetModTimingInv() {
        return modTimingInv;
    }

    /**
     * Sets the invisibility modifier's game time.
     * 
     * @param ModTimingInv       The invisibility modifier's game time.
     */
    public void SetModTimingInv(long i) {
        modTimingInv = i;
    }

    /**
     * Gets the invisibility modifier's total game time.
     * 
     * @return      The invisibility modifier's total game time.
     */
    public long GetModTimingInvTotal() {
        return modTimingInvTotal;
    }

    /**
     * Sets the invisibility modifier's total game time.
     * 
     * @param ModTimingInvTotal     The invisibility modifier's total game time.
     */
    public void SetModTimingInvTotal(long i) {
        modTimingInvTotal = i;
    }
        
    /**
     * Gets the attack type of the current weapon.
     * 
     * @return      The attack type of the current weapon. 
     */
    public MdtWeaponAttackType GetCurrentWeaponAttackType() {
        return weaponCurrent.attackType;
    }
    
    /**
     * Sets the attack type of the current weapon.
     * 
     * @return      The attack type of the current weapon.
     */
    public MdtWeaponType GetCurrentWeaponType() {
        return weaponCurrent.weaponType;
    }
    
    /**
     * Clears the invincibility effect from the given animation frames.
     * 
     * @param subj      The given animation frames.       
     */
    public void ClearInvincibilityEffect(MmgSprite subj) {
        MmgBmp[] bmps = subj.GetBmpArray();
        int len = bmps.length;
        for(int i = 0; i < len; i++) {
            bmps[i].SetMmgColor(null);
        }
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
        if (isVisible == true) {
            super.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
            if(!isBroken) {
                if(mod == MdtPlayerModType.INVINCIBLE) {
                    modTimingInv += msSinceLastFrame;
                    if(modTimingInv <= modTimingInvTotal) {
                        int r = GetRand().nextInt(11);
                        if(r % 3 == 0) {
                            subj.GetCurrentFrame().SetMmgColor(MmgColor.GetYellow());
                        } else if(r % 3 == 1) {
                            subj.GetCurrentFrame().SetMmgColor(MmgColor.GetWhite());                        
                        } else if(r % 3 == 2) {
                            subj.GetCurrentFrame().SetMmgColor(MmgColor.GetOrange());                        
                        } else {
                            subj.GetCurrentFrame().SetMmgColor(MmgColor.GetRedOrange());
                        }
                    } else {
                        modTimingInv = 0;
                        mod = MdtPlayerModType.NONE;
                        hasInvincibility = false;                    
                        screen.UpdateClearPlayerMod(playerType);
                        ClearInvincibilityEffect(subj);
                    }
                } else if(mod == MdtPlayerModType.FULL_HEALTH) {
                    modTimingFullHealth += msSinceLastFrame;
                    if(modTimingFullHealth <= modTimingFullHealthTotal) {
                        healthCurrent = healthMax;
                    } else {
                        modTimingFullHealth = 0;
                        mod = MdtPlayerModType.NONE;
                        hasFullHealth = false;
                        screen.UpdateClearPlayerMod(playerType);
                    }
                } else if(mod == MdtPlayerModType.DOUBLE_POINTS) {
                    modTimingDp += msSinceLastFrame;
                    if(modTimingDp > modTimingDpTotal) {
                        modTimingDp = 0;
                        mod = MdtPlayerModType.NONE;
                        hasDoublePoints = false;
                        screen.UpdateClearPlayerMod(playerType);
                    }
                }

                if(prevMod == MdtPlayerModType.INVINCIBLE && mod != MdtPlayerModType.INVINCIBLE) {
                    ClearInvincibilityEffect(subj);
                }
            }
        }
        return lret;
    }
}