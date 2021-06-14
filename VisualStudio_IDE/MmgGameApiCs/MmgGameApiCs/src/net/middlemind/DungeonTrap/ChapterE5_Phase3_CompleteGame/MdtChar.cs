using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase3_CompleteGame
{
    /// <summary>
    /// A class representing a character which extends the MdtBase class.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/24/220
    /// </summary>
    public class MdtChar : MdtBase
    {
        /// <summary>
        /// The sprite animation that is the subject for this character class. 
        /// </summary>
        public MmgSprite subj;

        /// <summary>
        /// The current health of the character.
        /// </summary>
        public int healthCurrent = 3;

        /// <summary>
        /// The max health of the character.
        /// </summary>
        public int healthMax = 3;

        /// <summary>
        /// The type of character that last damaged this character.
        /// </summary>
        public MdtPlayerType healthDamagedBy = MdtPlayerType.NONE;

        /// <summary>
        /// A variable used in internal methods.
        /// </summary>
        public bool lret = false;

        /// <summary>
        /// The speed per frame of the current character.
        /// </summary>
        public int speed = ScreenGame.GetSpeedPerFrame(60);

        /// <summary>
        /// The direction of the current character.
        /// </summary>
        public int dir = MmgDir.DIR_NONE;

        /// <summary>
        /// An integer representing the starting frame of the front facing animation.
        /// </summary>
        public int frameFrontStart = 0;

        /// <summary>
        /// An integer representing the stopping frame of the front facing animation. 
        /// </summary>
        public int frameFrontStop = 0;

        /// <summary>
        /// An integer representing the starting frame of the back facing animation.
        /// </summary>
        public int frameBackStart = 0;

        /// <summary>
        /// An integer representing the stopping frame of the back facing animation.
        /// </summary>
        public int frameBackStop = 0;

        /// <summary>
        /// An integer representing the starting frame of the left facing animation.
        /// </summary>
        public int frameLeftStart = 0;

        /// <summary>
        /// An integer representing the stopping frame of the left facing animation.
        /// </summary>
        public int frameLeftStop = 0;

        /// <summary>
        /// An integer representing the starting frame of the right facing animation.
        /// </summary>
        public int frameRightStart = 0;

        /// <summary>
        /// An integer representing the stopping frame of the right facing animation.
        /// </summary>
        public int frameRightStop = 0;

        /// <summary>
        /// A rectangle representing the current state of the character.
        /// </summary>
        public MmgRect current = null;

        /// <summary>
        /// A boolean indicating that the character is moving.
        /// </summary>
        public bool isMoving = false;

        /// <summary>
        /// A boolean indicating that the character is attacking.
        /// </summary>
        public bool isAttacking = false;

        /// <summary>
        /// A private random number generator using by internal methods.
        /// </summary>
        private Random rand = null;

        /// <summary>
        /// The current weapon of this character.
        /// </summary>
        public MdtWeapon weaponCurrent = null;

        /// <summary>
        /// A list of available weapons for this character.
        /// </summary>
        public Dictionary<string, MdtWeapon> weapons = null;

        /// <summary>
        /// The game screen this MdtChar belongs to.
        /// </summary>
        public ScreenGame screen = null;

        /// <summary>
        /// An MdtBase object instance used in determining collisions.
        /// </summary>
        public MdtBase coll = null;

        /// <summary>
        /// A basic constructor that takes no arguments.
        /// </summary>
        public MdtChar()
        {

        }

        /// <summary>
        /// MdtChar constructor that allows you to specify the sprite animation frames for this character, for all directions.
        /// </summary>
        /// <param name="Subj">The subject of the object instance.</param>
        /// <param name="fsFront">The front start frame.</param>
        /// <param name="feFront">The front end frame.</param>
        /// <param name="fsLeft">The left start frame.</param>
        /// <param name="feLeft">The left end frame.</param>
        /// <param name="fsRight">The right start frame.</param>
        /// <param name="feRight">The right end frame.</param>
        /// <param name="fsBack">The back start frame.</param>
        /// <param name="feBack">The back end frame.</param>
        /// <param name="Screen">The game screen this character is on.</param>
        /// <param name="ObjType">The MdtObjType of this character.</param>
        /// <param name="ObjSubType">The MdtObjSubType of this character.</param>
        public MdtChar(MmgSprite Subj, int fsFront, int feFront, int fsLeft, int feLeft, int fsRight, int feRight, int fsBack, int feBack, ScreenGame Screen, MdtObjType ObjType, MdtObjSubType ObjSubType)
        {
            SetSubj(Subj);

            SetFrameFrontStart(fsFront);
            SetFrameFrontStop(feFront);
            SetFrameLeftStart(fsLeft);
            SetFrameLeftStop(feLeft);
            SetFrameRightStart(fsRight);
            SetFrameRightStop(feRight);
            SetFrameBackStart(fsBack);
            SetFrameBackStop(feBack);

            SetRand(new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
            SetScreen(Screen);
            SetMdtType(ObjType);
            SetMdtSubType(ObjSubType);

            SetHeight(subj.GetHeight());
            SetWidth(subj.GetWidth());
        }

        /// <summary>
        /// A method that applies the specified amount of damage to this character.
        /// </summary>
        /// <param name="i">The amount of damage to apply to this character.</param>
        /// <param name="p">The player who dealt the damage.</param>
        public virtual void TakeDamage(int i, MdtPlayerType p)
        {
            SetHealthDamagedBy(p);
            healthCurrent -= i;
            if (healthCurrent < 0)
            {
                healthCurrent = 0;
            }
        }

        /// <summary>
        /// Sets the current health to the maximum health.
        /// </summary>
        public virtual void SetHealthToMax()
        {
            healthCurrent = healthMax;
        }

        /// <summary>
        /// Gets the MdtPlayerType that last damaged this character.
        /// </summary>
        /// <returns>The player type that last damaged this character.</returns>
        public virtual MdtPlayerType GetHealthDamagedBy()
        {
            return healthDamagedBy;
        }

        /// <summary>
        /// Sets the MdtPlayerType that last damaged this character.
        /// </summary>
        /// <param name="p">The player type that last damaged this character.</param>
        public virtual void SetHealthDamagedBy(MdtPlayerType p)
        {
            healthDamagedBy = p;
        }

        /// <summary>
        /// Gets the subject of the character.
        /// </summary>
        /// <returns>The subject of the character.</returns>
        public virtual MmgSprite GetSubj()
        {
            return subj;
        }

        /// <summary>
        /// Sets the subject of the character.
        /// </summary>
        /// <param name="Subj">The subject of the character.</param>
        public virtual void SetSubj(MmgSprite Subj)
        {
            subj = Subj;
        }

        /// <summary>
        /// Gets the health of the character.
        /// </summary>
        /// <returns>The health of the character.</returns>
        public virtual int GetHealthCurrent()
        {
            return healthCurrent;
        }

        /// <summary>
        /// Sets the health of the character.
        /// </summary>
        /// <param name="curr">The health of the character.</param>
        public virtual void SetHealthCurrent(int curr)
        {
            healthCurrent = curr;
        }

        /// <summary>
        /// Gets the maximum health of the character.
        /// </summary>
        /// <returns>The maximum health of the character.</returns>
        public virtual int GetHealthMax()
        {
            return healthMax;
        }

        /// <summary>
        /// Sets the maximum health of the character.
        /// </summary>
        /// <param name="hMax">The maximum health of the character.</param>
        public virtual void SetHealthMax(int hMax)
        {
            healthMax = hMax;
        }

        /// <summary>
        /// Gets the front direction start frame.
        /// </summary>
        /// <returns>The front direction start frame.</returns>
        public virtual int GetFrameFrontStart()
        {
            return frameFrontStart;
        }

        /// <summary>
        /// Sets the front direction start frame.
        /// </summary>
        /// <param name="frame">The front direction start frame.</param>
        public virtual void SetFrameFrontStart(int frame)
        {
            frameFrontStart = frame;
        }

        /// <summary>
        /// Gets the front direction stop frame.
        /// </summary>
        /// <returns>The front direction stop frame.</returns>
        public virtual int GetFrameFrontStop()
        {
            return frameFrontStop;
        }

        /// <summary>
        /// Sets the front direction stop frame.
        /// </summary>
        /// <param name="frame">The front direction stop frame.</param>
        public virtual void SetFrameFrontStop(int frame)
        {
            frameFrontStop = frame;
        }

        /// <summary>
        /// Gets the back direction start frame.
        /// </summary>
        /// <returns>The back direction start frame.</returns>
        public virtual int GetFrameBackStart()
        {
            return frameBackStart;
        }

        /// <summary>
        /// Sets the back direction start frame.
        /// </summary>
        /// <param name="frame">The back direction start frame. </param>
        public virtual void SetFrameBackStart(int frame)
        {
            frameBackStart = frame;
        }

        /// <summary>
        /// Gets the back direction stop frame.
        /// </summary>
        /// <returns>The back direction stop frame.</returns>
        public virtual int GetFrameBackStop()
        {
            return frameBackStop;
        }

        /// <summary>
        /// Sets the back direction stop frame.
        /// </summary>
        /// <param name="frame">The back direction stop frame.</param>
        public virtual void SetFrameBackStop(int frame)
        {
            frameBackStop = frame;
        }

        /// <summary>
        /// Gets the left direction start frame.
        /// </summary>
        /// <returns>The left direction start frame.</returns>
        public virtual int GetFrameLeftStart()
        {
            return frameLeftStart;
        }

        /// <summary>
        /// Sets the left direction start frame.
        /// </summary>
        /// <param name="frame">The left direction start frame.</param>
        public virtual void SetFrameLeftStart(int frame)
        {
            frameLeftStart = frame;
        }

        /// <summary>
        /// Gets the left direction stop frame.
        /// </summary>
        /// <returns>The left direction stop frame.</returns>
        public virtual int GetFrameLeftStop()
        {
            return frameLeftStop;
        }

        /// <summary>
        /// Sets the left direction stop frame.
        /// </summary>
        /// <param name="frame">The left direction stop frame.</param>
        public virtual void SetFrameLeftStop(int frame)
        {
            frameLeftStop = frame;
        }

        /// <summary>
        /// Gets the right direction start frame.
        /// </summary>
        /// <returns>The right direction start frame.</returns>
        public virtual int GetFrameRightStart()
        {
            return frameRightStart;
        }

        /// <summary>
        /// Sets the right direction start frame.
        /// </summary>
        /// <param name="frame">The right direction start frame.</param>
        public virtual void SetFrameRightStart(int frame)
        {
            frameRightStart = frame;
        }

        /// <summary>
        /// Gets the right direction stop frame.
        /// </summary>
        /// <returns>The right direction stop frame.</returns>
        public virtual int GetFrameRightStop()
        {
            return frameRightStop;
        }

        /// <summary>
        /// Sets the right direction stop frame.
        /// </summary>
        /// <param name="frame">The right direction stop frame.</param>
        public virtual void SetFrameRightStop(int frame)
        {
            frameRightStop = frame;
        }

        /// <summary>
        /// Gets the character speed.
        /// </summary>
        /// <returns>The character speed.</returns>
        public virtual int GetSpeed()
        {
            return speed;
        }

        /// <summary>
        /// Sets the character speed.
        /// </summary>
        /// <param name="s">The character speed.</param>
        public virtual void SetSpeed(int s)
        {
            speed = s;
        }

        /// <summary>
        /// Gets the character direction.
        /// </summary>
        /// <returns>The character direction.</returns>
        public virtual int GetDir()
        {
            return dir;
        }

        /// <summary>
        /// Sets the character direction.
        /// </summary>
        /// <param name="Dir">The character direction.</param>
        public virtual void SetDir(int Dir)
        {
            dir = Dir;
        }

        /// <summary>
        /// Gets the current collision rectangle for this character.
        /// </summary>
        /// <returns>The current collision rectangle for this character.</returns>
        public virtual MmgRect GetCurrentCollRect()
        {
            return current;
        }

        /// <summary>
        /// Sets the current collision rectangle for this character.
        /// </summary>
        /// <param name="curr">The current collision rectangle for this character.</param>
        public virtual void SetCurrentCollRect(MmgRect curr)
        {
            current = curr;
        }

        /// <summary>
        /// Gets a boolean indicating the character is moving.
        /// </summary>
        /// <returns>A boolean indicating the character is moving.</returns>
        public virtual bool GetIsMoving()
        {
            return isMoving;
        }

        /// <summary>
        /// Sets a boolean indicating the character is moving.
        /// </summary>
        /// <param name="b">A boolean indicating the character is moving.</param>
        public virtual void SetIsMoving(bool b)
        {
            isMoving = b;
        }

        /// <summary>
        /// Gets a boolean indicating the character is attacking.
        /// </summary>
        /// <returns>A boolean indicating the character is attacking.</returns>
        public virtual bool GetIsAttacking()
        {
            return isAttacking;
        }

        /// <summary>
        /// Sets a boolean indicating the character is attacking.
        /// </summary>
        /// <param name="b">A boolean indicating the character is attacking.</param>
        public virtual void SetIsAttacking(bool b)
        {
            isAttacking = b;
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
        /// Gets the character's current weapon if available.
        /// </summary>
        /// <returns>The character's current weapon.</returns>
        public virtual MdtWeapon GetWeaponCurrent()
        {
            return weaponCurrent;
        }

        /// <summary>
        /// Sets the character's current weapon if available.
        /// </summary>
        /// <param name="weapon">The character's current weapon.</param>
        public virtual void SetWeaponCurrent(MdtWeapon weapon)
        {
            weaponCurrent = weapon;
        }

        /// <summary>
        /// Gets the character's set of weapons.
        /// </summary>
        /// <returns>The character's set of weapons.</returns>
        public virtual Dictionary<string, MdtWeapon> GetWeapons()
        {
            return weapons;
        }

        /// <summary>
        /// Sets the character's set of weapons.
        /// </summary>
        /// <param name="wps">The character's set of weapons.</param>
        public virtual void SetWeapons(Dictionary<string, MdtWeapon> wps)
        {
            weapons = wps;
        }

        /// <summary>
        /// Gets the game screen this character belongs to.
        /// </summary>
        /// <returns>The game screen this character belongs to.</returns>
        public virtual ScreenGame GetScreen()
        {
            return screen;
        }

        /// <summary>
        /// Sets the game screen this character belongs to.
        /// </summary>
        /// <param name="o">The game screen this character belongs to.</param>
        public virtual void SetScreen(ScreenGame o)
        {
            screen = o;
        }

        /// <summary>
        /// Gets the current object this character is colliding with.
        /// </summary>
        /// <returns>The current object this character is colliding with.</returns>
        public virtual MdtBase GetCurrentColl()
        {
            return coll;
        }

        /// <summary>
        /// Sets the current object this character is colliding with.
        /// </summary>
        /// <param name="c">The current object this character is colliding with.</param>
        public virtual void SetCurrentColl(MdtBase c)
        {
            coll = c;
        }
    }
}