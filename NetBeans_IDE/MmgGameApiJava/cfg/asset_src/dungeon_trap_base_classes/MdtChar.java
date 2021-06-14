package game.jam.DungeonTrap;

import java.util.Hashtable;
import java.util.Random;
import net.middlemind.MmgGameApiJava.MmgBase.MmgDir;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;

/**
 * A class representing a character which extends the MdtBase class.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/24/220
 */
public class MdtChar extends MdtBase {
    
    /**
     * The sprite animation that is the subject for this character class.
     */
    public MmgSprite subj;
        
    /**
     * The current health of the character.
     */
    public int healthCurrent = 3;
    
    /**
     * The max health of the character.
     */
    public int healthMax = 3;
        
    /**
     * The type of character that last damaged this character.
     */
    public MdtPlayerType healthDamagedBy = MdtPlayerType.NONE;
        
    /**
     * A variable used in internal methods.
     */
    public boolean lret = false;
    
    /**
     * The speed per frame of the current character.
     */
    public int speed = ScreenGame.GetSpeedPerFrame(60);
    
    /**
     * The direction of the current character.
     */
    public int dir = MmgDir.DIR_NONE;    
    
    /**
     * An integer representing the starting frame of the front facing animation.
     */
    public int frameFrontStart = 0;
    
    /**
     * An integer representing the stopping frame of the front facing animation.
     */
    public int frameFrontStop = 0;
    
    /**
     * An integer representing the starting frame of the back facing animation.
     */
    public int frameBackStart = 0;
    
    /**
     * An integer representing the stopping frame of the back facing animation.
     */
    public int frameBackStop = 0;

    /**
     * An integer representing the starting frame of the left facing animation.
     */
    public int frameLeftStart = 0;
    
    /**
     * An integer representing the stopping frame of the left facing animation.
     */
    public int frameLeftStop = 0;    
    
    /**
     * An integer representing the starting frame of the right facing animation.
     */
    public int frameRightStart = 0;
    
    /**
     * An integer representing the stopping frame of the right facing animation.
     */
    public int frameRightStop = 0;    
        
    /**
     * A rectangle representing the current state of the character.
     */
    public MmgRect current = null;
    
    /**
     * A boolean indicating that the character is moving.
     */
    public boolean isMoving = false;
        
    /**
     * A boolean indicating that the character is attacking.
     */
    public boolean isAttacking = false;    
            
    /**
     * A private random number generator using by internal methods.
     */
    private Random rand = null;
    
    /**
     * The current weapon of this character.
     */
    public MdtWeapon weaponCurrent = null;
    
    /**
     * A list of available weapons for this character.
     */
    public Hashtable<String, MdtWeapon> weapons = null;
    
    /**
     * The game screen this MdtChar belongs to.
     */
    public ScreenGame screen = null;
    
    /**
     * An MdtBase object instance used in determining collisions.
     */
    public MdtBase coll = null;
    
    /**
     * A basic constructor that takes no arguments.
     */
    public MdtChar() {
        
    }
    
    /**
     * MdtChar constructor that allows you to specify the sprite animation frames for this character, for all directions.
     * 
     * @param Subj          The subject of the object instance.
     * @param fsFront       The front start frame.
     * @param feFront       The front end frame.
     * @param fsLeft        The left start frame.
     * @param feLeft        The left end frame.
     * @param fsRight       The right start frame.
     * @param feRight       The right end frame.
     * @param fsBack        The back start frame.
     * @param feBack        The back end frame.
     * @param Screen        The game screen this character is on.
     * @param ObjType       The MdtObjType of this character.
     * @param ObjSubType    The MdtObjSubType of this character.
     */
    public MdtChar(MmgSprite Subj, int fsFront, int feFront, int fsLeft, int feLeft, int fsRight, int feRight, int fsBack, int feBack, ScreenGame Screen, MdtObjType ObjType, MdtObjSubType ObjSubType) {
        SetSubj(Subj);
        
        SetFrameFrontStart(fsFront);
        SetFrameFrontStop(feFront);
        SetFrameLeftStart(fsLeft);
        SetFrameLeftStop(feLeft);
        SetFrameRightStart(fsRight);
        SetFrameRightStop(feRight);
        SetFrameBackStart(fsBack);
        SetFrameBackStop(feBack);
        
        SetRand(new Random(System.currentTimeMillis()));
        SetScreen(Screen);
        SetMdtType(ObjType);
        SetMdtSubType(ObjSubType);
        
        SetHeight(subj.GetHeight());
        SetWidth(subj.GetWidth());        
    }

    /**
     * A method that applies the specified amount of damage to this character.
     * 
     * @param i     The amount of damage to apply to this character.
     * @param p     The player who dealt the damage.
     */
    public void TakeDamage(int i, MdtPlayerType p) {
        SetHealthDamagedBy(p);
        healthCurrent -= i;
        if(healthCurrent < 0) {
            healthCurrent = 0;
        }
    }    
    
    /**
     * Sets the current health to the maximum health.
     */
    public void SetHealthToMax() {
        healthCurrent = healthMax;
    }    

    /**
     * Gets the MdtPlayerType that last damaged this character.
     * 
     * @return      The player type that last damaged this character.
     */
    public MdtPlayerType GetHealthDamagedBy() {
        return healthDamagedBy;
    }

    /**
     * Sets the MdtPlayerType that last damaged this character.
     * 
     * @param p     The player type that last damaged this character. 
     */
    public void SetHealthDamagedBy(MdtPlayerType p) {
        healthDamagedBy = p;
    }
    
    /**
     * Gets the subject of the character.
     * 
     * @return  The subject of the character.
     */
    public MmgSprite GetSubj() {
        return subj;
    }

    /**
     * Sets the subject of the character.
     * 
     * @param Subj  The subject of the character. 
     */
    public void SetSubj(MmgSprite Subj) {
        subj = Subj;
    }

    /**
     * Gets the health of the character.
     * 
     * @return  The health of the character.
     */
    public int GetHealthCurrent() {
        return healthCurrent;
    }

    /**
     * Sets the health of the character.
     * 
     * @param curr  The health of the character. 
     */
    public void SetHealthCurrent(int curr) {
        healthCurrent = curr;
    }

    /**
     * Gets the maximum health of the character.
     * 
     * @return  The maximum health of the character.
     */
    public int GetHealthMax() {
        return healthMax;
    }

    /**
     * Sets the maximum health of the character.
     * 
     * @param hMax The maximum health of the character.
     */
    public void SetHealthMax(int hMax) {
        healthMax = hMax;
    }

    /**
     * Gets the front direction start frame.
     * 
     * @return      The front direction start frame.
     */
    public int GetFrameFrontStart() {
        return frameFrontStart;
    }

    /**
     * Sets the front direction start frame.
     * 
     * @param frame     The front direction start frame. 
     */
    public void SetFrameFrontStart(int frame) {
        frameFrontStart = frame;
    }

    /**
     * Gets the front direction stop frame.
     * 
     * @return      The front direction stop frame.
     */
    public int GetFrameFrontStop() {
        return frameFrontStop;
    }

    /**
     * Sets the front direction stop frame.
     * 
     * @param frame     The front direction stop frame. 
     */
    public void SetFrameFrontStop(int frame) {
        frameFrontStop = frame;
    }

    /**
     * Gets the back direction start frame.
     * 
     * @return      The back direction start frame.
     */
    public int GetFrameBackStart() {
        return frameBackStart;
    }

    /**
     * Sets the back direction start frame.
     * 
     * @param frame     The back direction start frame. 
     */
    public void SetFrameBackStart(int frame) {
        frameBackStart = frame;
    }

    /**
     * Gets the back direction stop frame.
     * 
     * @return      The back direction stop frame.
     */
    public int GetFrameBackStop() {
        return frameBackStop;
    }

    /**
     * Sets the back direction stop frame.
     * 
     * @param frame     The back direction stop frame.
     */
    public void SetFrameBackStop(int frame) {
        frameBackStop = frame;
    }

    /**
     * Gets the left direction start frame.
     * 
     * @return      The left direction start frame. 
     */
    public int GetFrameLeftStart() {
        return frameLeftStart;
    }

    /**
     * Sets the left direction start frame.
     * 
     * @param frame     The left direction start frame.
     */
    public void SetFrameLeftStart(int frame) {
        frameLeftStart = frame;
    }

    /**
     * Gets the left direction stop frame.
     * 
     * @return      The left direction stop frame.
     */
    public int GetFrameLeftStop() {
        return frameLeftStop;
    }

    /**
     * Sets the left direction stop frame.
     * 
     * @param frame     The left direction stop frame. 
     */
    public void SetFrameLeftStop(int frame) {
        frameLeftStop = frame;
    }

    /**
     * Gets the right direction start frame.
     * 
     * @return      The right direction start frame.
     */
    public int GetFrameRightStart() {
        return frameRightStart;
    }

    /**
     * Sets the right direction start frame.
     * 
     * @param frame     The right direction start frame. 
     */
    public void SetFrameRightStart(int frame) {
        frameRightStart = frame;
    }

    /**
     * Gets the right direction stop frame.
     * 
     * @return      The right direction stop frame.
     */
    public int GetFrameRightStop() {
        return frameRightStop;
    }

    /**
     * Sets the right direction stop frame.
     * 
     * @param frameRightStop        The right direction stop frame.
     */
    public void SetFrameRightStop(int frame) {
        frameRightStop = frame;
    }

    /**
     * Gets the character speed.
     * 
     * @return      The character speed. 
     */
    public int GetSpeed() {
        return speed;
    }

    /**
     * Sets the character speed.
     * 
     * @param s     The character speed. 
     */
    public void SetSpeed(int s) {
        speed = s;
    }

    /**
     * Gets the character direction.
     * 
     * @return      The character direction. 
     */
    public int GetDir() {
        return dir;
    }

    /**
     * Sets the character direction.
     * 
     * @param dir       The character direction. 
     */
    public void SetDir(int Dir) {
        dir = Dir;
    }

    /**
     * Gets the current collision rectangle for this character.
     * 
     * @return      The current collision rectangle for this character. 
     */
    public MmgRect GetCurrentCollRect() {
        return current;
    }

    /**
     * Sets the current collision rectangle for this character.
     * 
     * @param current       The current collision rectangle for this character. 
     */
    public void SetCurrentCollRect(MmgRect curr) {
        current = curr;
    }

    /**
     * Gets a boolean indicating the character is moving.
     * 
     * @return      A boolean indicating the character is moving. 
     */
    public boolean GetIsMoving() {
        return isMoving;
    }

    /**
     * Sets a boolean indicating the character is moving.
     * 
     * @param b     A boolean indicating the character is moving.  
     */
    public void SetIsMoving(boolean b) {
        isMoving = b;
    }

    /**
     * Gets a boolean indicating the character is attacking.
     * 
     * @return      A boolean indicating the character is attacking.
     */
    public boolean GetIsAttacking() {
        return isAttacking;
    }

    /**
     * Sets a boolean indicating the character is attacking.
     * 
     * @param b       A boolean indicating the character is attacking. 
     */
    public void SetIsAttacking(boolean b) {
        isAttacking = b;
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
     * Gets the character's current weapon if available.
     * 
     * @return      The character's current weapon. 
     */
    public MdtWeapon GetWeaponCurrent() {
        return weaponCurrent;
    }

    /**
     * Sets the character's current weapon if available.
     * 
     * @param weapon    The character's current weapon. 
     */
    public void SetWeaponCurrent(MdtWeapon weapon) {
        weaponCurrent = weapon;
    }

    /**
     * Gets the character's set of weapons.
     * 
     * @return      The character's set of weapons.
     */
    public Hashtable<String, MdtWeapon> GetWeapons() {
        return weapons;
    }

    /**
     * Sets the character's set of weapons.
     * 
     * @param wps       The character's set of weapons. 
     */
    public void SetWeapons(Hashtable<String, MdtWeapon> wps) {
        weapons = wps;
    }

    /**
     * Gets the game screen this character belongs to.
     * 
     * @return      The game screen this character belongs to. 
     */
    public ScreenGame GetScreen() {
        return screen;
    }

    /**
     * Sets the game screen this character belongs to.
     * 
     * @param o     The game screen this character belongs to. 
     */
    public void SetScreen(ScreenGame o) {
        screen = o;
    }

    /**
     * Gets the current object this character is colliding with.
     * 
     * @return      The current object this character is colliding with. 
     */
    public MdtBase GetCurrentColl() {
        return coll;
    }

    /**
     * Sets the current object this character is colliding with.
     * 
     * @param c     The current object this character is colliding with. 
     */
    public void SetCurrentColl(MdtBase c) {
        coll = c;
    }
}