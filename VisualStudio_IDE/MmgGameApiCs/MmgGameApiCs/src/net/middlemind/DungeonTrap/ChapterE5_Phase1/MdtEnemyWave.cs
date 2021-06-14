using System;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase1
{
    /// <summary>
    /// A class used to represent a wave of enemies constituting one level in the game.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 01/21/2021
    /// </summary>
    public class MdtEnemyWave
    {
        /// <summary>
        /// The total time in milliseconds that this wave is active.
        /// </summary>
        public long timeTotalMs;

        /// <summary>
        /// The start time in milliseconds when this wave began.
        /// </summary>
        public long timeStartMs;

        /// <summary>
        /// The current time in milliseconds of this wave.
        /// </summary>
        public long timeCurrentMs;

        /// <summary>
        /// The calculated interval in milliseconds between spawning new enemies.
        /// </summary>
        public long intervalBetweenEnemiesMs;

        /// <summary>
        /// The time interval used to track interval durations during this wave.
        /// </summary>
        public long timeIntervalMs;

        /// <summary>
        /// The minimum number of objects to spawn on this level.
        /// </summary>
        public int minObjCount;

        /// <summary>
        /// The maximum number of objects to spawn on this level.
        /// </summary>
        public int maxObjCount;

        /// <summary>
        /// The calculated, random range, number of actual objects that will appear on this level.
        /// </summary>
        public int actObjCount;

        /// <summary>
        /// The minimum number of chests to spawn on this level.
        /// </summary>
        public int minChestCount;

        /// <summary>
        /// The maximum number of chests to spawn on this level.
        /// </summary>
        public int maxChestCount;

        /// <summary>
        /// The calculated, random range, number of actual chests that will appear on this level.
        /// </summary>
        public int actChestCount;

        /// <summary>
        /// The minimum number of enemies to spawn on this level at one time.
        /// </summary>
        public int minAtOneTime;

        /// <summary>
        /// The maximum number of enemies to spawn on this level at one time.
        /// </summary>
        public int maxAtOneTime;

        /// <summary>
        /// The calculated, random range, number of actual objects that will appear on this level.
        /// </summary>
        public int actAtOneTime;

        /// <summary>
        /// The total number of enemies that will spawn on this level.
        /// </summary>
        public int enemyCount;

        /// <summary>
        /// The actual count of enemies to use.
        /// </summary>
        public int actEnemyCount;

        /// <summary>
        /// The index of this level in an array of level specifications.
        /// </summary>
        public int idx;

        /// <summary>
        /// The weapons that are allowed to drop on this level.
        /// </summary>
        public MdtWeaponType[] activeWeapons;

        /// <summary>
        /// The items that are allowed to drop on this level.
        /// </summary>
        public MdtItemType[] activeItems;

        /// <summary>
        /// The doors that are active as enemy spawn points on this level.
        /// </summary>
        public MdtDoorType[] activeDoors;

        /// <summary>
        /// Internal random number generated used to calculated actual count values from a possible range.
        /// </summary>
        private Random rand;

        /// <summary>
        /// Generic constructor for a level description modeled as a wave of enemies with certain properties defined like available weapons, items, etc.
        /// </summary>
        public MdtEnemyWave()
        {

        }

        /// <summary>
        /// Simple constructor for a level description modeled as a wave of enemies with certain properties defined like available weapons, items, etc.
        /// </summary>
        /// <param name="Idx">The index of this level description in an array of level descriptions.</param>
        public MdtEnemyWave(int Idx)
        {
            idx = Idx;
        }

        /// <summary>
        /// A complex constructor that allows you to set most of the class fields from constructor arguments.
        /// </summary>
        /// <param name="Idx">The index of this level description in an array of level descriptions.</param>
        /// <param name="TimeTotalMs">The total amount of time in milliseconds that this level lasts.</param>
        /// <param name="TimeStartMs">The time in milliseconds when this level started.</param>
        /// <param name="TimeCurrentMs">The current time in milliseconds that this level has progressed to.</param>
        /// <param name="Interval">The interval in milliseconds in between spawning new enemies.</param>
        /// <param name="MinAtOneTime">The minimum number of enemies to spawn at one time.</param>
        /// <param name="MaxAtOneTime">The maximum number of enemies to spawn at one time.</param>
        /// <param name="EnemyCount">The total number of enemies that spawn on this level.</param>
        /// <param name="Weapons">The types of weapons available as drops found on this level.</param>
        /// <param name="Items">The types of items available as drops found on this level.</param>
        /// <param name="Doors">The doors available for enemies to spawn in front of on this level.</param>
        /// <param name="MinObj">The minimum number of objects spawned at the start of this level.</param>
        /// <param name="MaxObj">The maximum number of objects spawned at the start of this level.</param>
        /// <param name="MinChest">The minimum number of chests spawned at the start of this level.</param>
        /// <param name="MaxChest">The maximum number of chests spawned at the start of this level.</param>
        public MdtEnemyWave(int Idx, long TimeTotalMs, long TimeStartMs, long TimeCurrentMs, long Interval, int MinAtOneTime, int MaxAtOneTime, int EnemyCount, MdtWeaponType[] Weapons, MdtItemType[] Items, MdtDoorType[] Doors, int MinObj, int MaxObj, int MinChest, int MaxChest)
        {
            rand = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            idx = Idx;
            timeTotalMs = TimeTotalMs;
            timeStartMs = TimeStartMs;
            timeCurrentMs = TimeCurrentMs;
            intervalBetweenEnemiesMs = Interval;

            minAtOneTime = MinAtOneTime;
            maxAtOneTime = MaxAtOneTime;
            actAtOneTime = GetRandomRange(minAtOneTime, maxAtOneTime);

            enemyCount = EnemyCount;
            activeWeapons = Weapons;
            activeItems = Items;
            activeDoors = Doors;

            minObjCount = MinObj;
            maxObjCount = MaxObj;
            actObjCount = GetRandomRange(minObjCount, maxObjCount);

            minChestCount = MinChest;
            maxChestCount = MaxChest;
            actChestCount = GetRandomRange(minChestCount, maxChestCount);
        }

        /// <summary>
        /// Returns a new random number in the specified range with inclusive lower bound and exclusive upper bound.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the range.</param>
        /// <param name="max">The exclusive upper bound of the range.</param>
        /// <returns>A random number in the specified range with inclusive lower bound and exclusive upper bound.</returns>
        private int GetRandomRange(int min, int max)
        {
            return rand.Next(max - min) + min;
        }

        /// <summary>
        /// A string representation of this level.
        /// </summary>
        /// <returns>A string representation of this level.</returns>
        public virtual string toString()
        {
            String ret = "";
            ret += "===== Enemy Wave (" + idx + ") =====\n";
            ret += "TimeTotalMs: " + timeTotalMs + "\n";
            ret += "IntervalBetweenEnemies: " + intervalBetweenEnemiesMs + "\n";
            ret += "MinAtOneTime: " + minAtOneTime + "\n";
            ret += "MaxAtOneTime: " + maxAtOneTime + "\n";
            ret += "ActAtOneTime: " + actAtOneTime + "\n";
            ret += "EnemyCount: " + enemyCount + "\n";
            ret += "MinObjCount: " + minObjCount + "\n";
            ret += "MaxObjCount: " + maxObjCount + "\n";
            ret += "ActObjCount: " + actObjCount + "\n";
            ret += "MinChestCount: " + minChestCount + "\n";
            ret += "MaxChestCount: " + maxChestCount + "\n";
            ret += "ActChestCount: " + actChestCount + "\n";
            return ret;
        }

        /// <summary>
        /// Gets the actual number of enemies that can spawn at one time on this level.
        /// </summary>
        /// <returns>The actual number of enemies that can spawn at one time on this level.</returns>
        public virtual int GetActAtOneTime()
        {
            return actAtOneTime;
        }

        /// <summary>
        /// Sets the actual number of enemies that can spawn at one time on this level.
        /// </summary>
        /// <param name="i">The actual number of enemies that can spawn at one time on this level.</param>
        public virtual void SetActAtOneTime(int i)
        {
            actAtOneTime = i;
        }

        /// <summary>
        /// Gets the actual number of chests that can spawn at one time on this level.
        /// </summary>
        /// <returns>The actual number of chests that can spawn at one time on this level.</returns>
        public virtual int GetActChestCount()
        {
            return actChestCount;
        }

        /// <summary>
        /// Sets the actual number of chests that can spawn at one time on this level.
        /// </summary>
        /// <param name="i">The actual number of chests that can spawn at one time on this level.</param>
        public virtual void SetActChestCount(int i)
        {
            actChestCount = i;
        }

        /// <summary>
        /// Gets the actual number of objects that can spawn at one time on this level.
        /// </summary>
        /// <returns>The actual number of objects that can spawn at one time on this level.</returns>
        public virtual int GetActObjCount()
        {
            return actObjCount;
        }

        /// <summary>
        /// Sets the actual number of objects that can spawn at one time on this level.
        /// </summary>
        /// <param name="i">The actual number of objects that can spawn at one time on this level.</param>
        public virtual void SetActObjCount(int i)
        {
            actObjCount = i;
        }

        /// <summary>
        /// Gets the minimum number of objects that can spawn at one time on this level.
        /// </summary>
        /// <returns>The minimum number of objects that can spawn at one time on this level.</returns>
        public virtual int GetMinObjCount()
        {
            return minObjCount;
        }

        /// <summary>
        /// Sets the minimum number of objects that can spawn at one time on this level.
        /// </summary>
        /// <param name="i">The minimum number of objects that can spawn at one time on this level.</param>
        public virtual void SetMinObjCount(int i)
        {
            minObjCount = i;
        }

        /// <summary>
        /// Gets the maximum number of objects that can spawn at one time on this level.
        /// </summary>
        /// <returns>The maximum number of objects that can spawn at one time on this level.</returns>
        public virtual int GetMaxObjCount()
        {
            return maxObjCount;
        }

        /// <summary>
        /// Sets the maximum number of objects that can spawn at one time on this level.
        /// </summary>
        /// <param name="i">The maximum number of objects that can spawn at one time on this level.</param>
        public virtual void SetMaxObjCount(int i)
        {
            maxObjCount = i;
        }

        /// <summary>
        /// Gets the minimum number of chests that can spawn at one time on this level.
        /// </summary>
        /// <returns>The minimum number of chests that can spawn at one time on this level.</returns>
        public virtual int GetMinChestCount()
        {
            return minChestCount;
        }

        /// <summary>
        /// Sets the minimum number of chests that can spawn at one time on this level.
        /// </summary>
        /// <param name="i">The minimum number of chests that can spawn at one time on this level.</param>
        public virtual void SetMinChestCount(int i)
        {
            minChestCount = i;
        }

        /// <summary>
        /// Gets the maximum number of chests that can spawn at one time on this level.
        /// </summary>
        /// <returns>The maximum number of chests that can spawn at one time on this level.</returns>
        public virtual int GetMaxChestCount()
        {
            return maxChestCount;
        }

        /// <summary>
        /// Sets the maximum number of chests that can spawn at one time on this level.
        /// </summary>
        /// <param name="i">The maximum number of chests that can spawn at one time on this level.</param>
        public virtual void SetMaxChestCount(int i)
        {
            maxChestCount = i;
        }

        /// <summary>
        /// Gets the total time in milliseconds that this level will run.
        /// </summary>
        /// <returns>The total number in milliseconds that this level will run.</returns>
        public virtual long GetTimeTotalMs()
        {
            return timeTotalMs;
        }

        /// <summary>
        /// Sets the total time in milliseconds that this level will run.
        /// </summary>
        /// <param name="l">The total number in milliseconds that this level will run.</param>
        public virtual void SetTimeTotalMs(long l)
        {
            timeTotalMs = l;
        }

        /// <summary>
        /// Gets the time that this level started in milliseconds.
        /// </summary>
        /// <returns>The time that this level started in milliseconds.</returns>
        public virtual long GetTimeStartMs()
        {
            return timeStartMs;
        }

        /// <summary>
        /// Sets the time that this level started in milliseconds.
        /// </summary>
        /// <param name="l">The time that this level started in milliseconds.</param>
        public virtual void SetTimeStartMs(long l)
        {
            timeStartMs = l;
        }

        /// <summary>
        /// Gets the time that this level started in milliseconds.
        /// </summary>
        /// <returns>The time that this level started in milliseconds.</returns>
        public virtual long GetTimeCurrentMs()
        {
            return timeCurrentMs;
        }

        /// <summary>
        /// Sets the current time in milliseconds that this level has been active.
        /// </summary>
        /// <param name="l">The time that this level has been active in milliseconds.</param>
        public virtual void SetTimeCurrentMs(long l)
        {
            timeCurrentMs = l;
        }

        /// <summary>
        /// Gets the current time in milliseconds that this level has been active.
        /// </summary>
        /// <returns>The time that this level has been active in milliseconds.</returns>
        public virtual long GetIntervalBetweenEnemiesMs()
        {
            return intervalBetweenEnemiesMs;
        }

        /// <summary>
        /// Sets the interval in milliseconds in between spawning new enemies.
        /// </summary>
        /// <param name="l">The interval in milliseconds in between spawning new enemies.</param>
        public virtual void SetIntervalBetweenEnemiesMs(long l)
        {
            intervalBetweenEnemiesMs = l;
        }

        /// <summary>
        /// Gets the interval in milliseconds in between spawning new enemies.
        /// </summary>
        /// <returns>The interval in milliseconds in between spawning new enemies.</returns>
        public virtual MdtDoorType[] GetActiveDoors()
        {
            return activeDoors;
        }

        /// <summary>
        /// Sets the doors that this level uses to spawn new enemies by.
        /// </summary>
        /// <param name="Doors">The doors that this level uses to spawn new enemies by.</param>
        public virtual void SetActiveDoors(MdtDoorType[] Doors)
        {
            activeDoors = Doors;
        }

        /// <summary>
        /// Gets the doors that this level uses to spawn new enemies by.
        /// </summary>
        /// <returns>The doors that this level uses to spawn new enemies by.</returns>
        public virtual int GetMinAtOneTime()
        {
            return minAtOneTime;
        }

        /// <summary>
        /// Sets the minimum number of enemies that can spawn at one time.
        /// </summary>
        /// <param name="i">The minimum number of enemies that can spawn at one time.</param>
        public virtual void SetMinAtOneTime(int i)
        {
            minAtOneTime = i;
        }

        /// <summary>
        /// Gets the minimum number of enemies that can spawn at one time.
        /// </summary>
        /// <returns>The minimum number of enemies that can spawn at one time.</returns>
        public virtual int GetMaxAtOneTime()
        {
            return maxAtOneTime;
        }

        /// <summary>
        /// Sets the maximum number of enemies that can spawn at one time.
        /// </summary>
        /// <param name="i">The maximum number of enemies that can spawn at one time.</param>
        public virtual void SetMaxAtOneTime(int i)
        {
            maxAtOneTime = i;
        }

        /// <summary>
        /// Gets the maximum number of enemies that can spawn at one time.
        /// </summary>
        /// <returns>The maximum number of enemies that can spawn at one time.</returns>
        public virtual MdtWeaponType[] GetActiveWeapons()
        {
            return activeWeapons;
        }

        /// <summary>
        /// Sets the weapon types that can be dropped by enemies on this level.
        /// </summary>
        /// <param name="Weapons">The weapon types that can be dropped by enemies on this level.</param>
        public virtual void SetActiveWeapons(MdtWeaponType[] Weapons)
        {
            activeWeapons = Weapons;
        }

        /// <summary>
        /// Gets the weapon types that can be dropped by enemies on this level.
        /// </summary>
        /// <returns>The weapon types that can be dropped by enemies on this level.</returns>
        public virtual MdtItemType[] GetActiveItems()
        {
            return activeItems;
        }

        /// <summary>
        /// Sets the item types that can be dropped by enemies on this level.
        /// </summary>
        /// <param name="Items">The item types that can be dropped by enemies on this level.</param>
        public virtual void SetActiveItems(MdtItemType[] Items)
        {
            activeItems = Items;
        }

        /// <summary>
        /// Gets the total number of enemies that are spawned on this level.
        /// </summary>
        /// <returns>The total number of enemies that are spawned on this level.</returns>
        public virtual int GetEnemyCount()
        {
            return enemyCount;
        }

        /// <summary>
        /// Sets the total number of enemies that are spawned on this level.
        /// </summary>
        /// <param name="Count">The total number of enemies that are spawned on this level.</param>
        public virtual void SetEnemyCount(int Count)
        {
            enemyCount = Count;
        }

        /// <summary>
        /// Gets the index of this level descriptor in an array of level descriptors.
        /// </summary>
        /// <returns>The index of this level descriptor in an array of level descriptors.</returns>
        public virtual int GetIdx()
        {
            return idx;
        }

        /// <summary>
        /// Sets the index of this level descriptor in an array of level descriptors.
        /// </summary>
        /// <param name="i">The index of this level descriptor in an array of level descriptors.</param>
        public virtual void SetIdx(int i)
        {
            idx = i;
        }

        /// <summary>
        /// Gets the current interval time for the given wave.
        /// </summary>
        /// <returns>The current interval time for the given wave.</returns>
        public virtual long GetTimeIntervalMs()
        {
            return timeIntervalMs;
        }

        /// <summary>
        /// Sets the current interval time for the given wave.
        /// </summary>
        /// <param name="l">The current interval time for the given wave.</param>
        public virtual void SetTimeIntervalMs(long l)
        {
            timeIntervalMs = l;
        }
    }
}