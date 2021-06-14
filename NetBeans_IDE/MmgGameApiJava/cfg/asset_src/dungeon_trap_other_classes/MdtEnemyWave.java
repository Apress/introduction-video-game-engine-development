package game.jam.DungeonTrap;

import java.util.Random;

/**
 * A class used to represent a wave of enemies constituting one level in the game.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 01/21/2021
 */
public class MdtEnemyWave {
    
    /**
     * The total time in milliseconds that this wave is active.
     */
    public long timeTotalMs;
    
    /**
     * The start time in milliseconds when this wave began.
     */
    public long timeStartMs;
    
    /**
     * The current time in milliseconds of this wave.
     */
    public long timeCurrentMs;
    
    /**
     * The calculated interval in milliseconds between spawning new enemies.
     */
    public long intervalBetweenEnemiesMs;
        
    /**
     * The time interval used to track interval durations during this wave.
     */
    public long timeIntervalMs;    
    
    /**
     * The minimum number of objects to spawn on this level.
     */
    public int minObjCount;

    /**
     * The maximum number of objects to spawn on this level.
     */    
    public int maxObjCount;

    /**
     * The calculated, random range, number of actual objects that will appear on this level.
     */
    public int actObjCount;    
    
    /**
     * The minimum number of chests to spawn on this level.
     */
    public int minChestCount;

    /**
     * The maximum number of chests to spawn on this level.
     */
    public int maxChestCount;
    
    /**
     * The calculated, random range, number of actual chests that will appear on this level.
     */
    public int actChestCount;    
    
    /**
     *  The minimum number of enemies to spawn on this level at one time.
     */
    public int minAtOneTime;
    
    /**
     * The maximum number of enemies to spawn on this level at one time.
     */
    public int maxAtOneTime;
      
    /**
     * The calculated, random range, number of actual objects that will appear on this level.
     */
    public int actAtOneTime;    
    
    /**
     * The total number of enemies that will spawn on this level.
     */
    public int enemyCount;
    
    /**
     * 
     */
    public int actEnemyCount;
    
    /**
     * The index of this level in an array of level specifications.
     */
    public int idx;
    
    /**
     * The weapons that are allowed to drop on this level.
     */
    public MdtWeaponType[] activeWeapons;
    
    /**
     * The items that are allowed to drop on this level.
     */
    public MdtItemType[] activeItems;
    
    /**
     * The doors that are active as enemy spawn points on this level.
     */
    public MdtDoorType[] activeDoors;    
    
    /**
     * Internal random number generated used to calculated actual count values from a possible range.
     */
    private Random rand;
    
    /**
     * Generic constructor for a level description modeled as a wave of enemies with certain properties defined like available weapons, items, etc.
     */
    public MdtEnemyWave() {
        
    }
    
    /**
     * Simple constructor for a level description modeled as a wave of enemies with certain properties defined like available weapons, items, etc.
     * 
     * @param Idx       The index of this level description in an array of level descriptions.
     */
    public MdtEnemyWave(int Idx) {
        idx = Idx;
    }

    /**
     * A complex constructor that allows you to set most of the class fields from constructor arguments.
     * 
     * @param Idx               The index of this level description in an array of level descriptions.
     * @param TimeTotalMs       The total amount of time in milliseconds that this level lasts.
     * @param TimeStartMs       The time in milliseconds when this level started.
     * @param TimeCurrentMs     The current time in milliseconds that this level has progressed to.
     * @param Interval          The interval in milliseconds in between spawning new enemies.
     * @param MinAtOneTime      The minimum number of enemies to spawn at one time.
     * @param MaxAtOneTime      The maximum number of enemies to spawn at one time.
     * @param EnemyCount        The total number of enemies that spawn on this level.
     * @param Weapons           The types of weapons available as drops found on this level.
     * @param Items             The types of items available as drops found on this level.
     * @param Doors             The doors available for enemies to spawn in front of on this level.
     * @param MinObj            The minimum number of objects spawned at the start of this level.
     * @param MaxObj            The maximum number of objects spawned at the start of this level.
     * @param MinChest          The minimum number of chests spawned at the start of this level.
     * @param MaxChest          The maximum number of chests spawned at the start of this level.
     */
    public MdtEnemyWave(int Idx, long TimeTotalMs, long TimeStartMs, long TimeCurrentMs, long Interval, int MinAtOneTime, int MaxAtOneTime, int EnemyCount, MdtWeaponType[] Weapons, MdtItemType[] Items, MdtDoorType[] Doors, int MinObj, int MaxObj, int MinChest, int MaxChest) {
        rand = new Random(System.currentTimeMillis());
        
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
    
    /**
     * Returns a new random number in the specified range with inclusive lower bound and exclusive upper bound.
     * 
     * @param min       The inclusive lower bound of the range.
     * @param max       The exclusive upper bound of the range.
     * @return          A random number in the specified range with inclusive lower bound and exclusive upper bound.
     */
    private int GetRandomRange(int min, int max) {
        return rand.nextInt(max - min) + min;        
    }
    
    /**
     * A string representation of this level.
     * 
     * @return  A string representation of this level.
     */
    @Override
    public String toString() {
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

    /**
     * Gets the actual number of enemies that can spawn at one time on this level.
     * 
     * @return      The actual number of enemies that can spawn at one time on this level.
     */
    public int GetActAtOneTime() {
        return actAtOneTime;
    }

    /**
     * Sets the actual number of enemies that can spawn at one time on this level.
     * 
     * @param i     The actual number of enemies that can spawn at one time on this level.
     */
    public void SetActAtOneTime(int i) {
        actAtOneTime = i;
    }

    /**
     * Gets the actual number of chests that can spawn at one time on this level.
     * 
     * @return      The actual number of chests that can spawn at one time on this level.
     */
    public int GetActChestCount() {
        return actChestCount;
    }

    /**
     * Sets the actual number of chests that can spawn at one time on this level.
     * 
     * @param i     The actual number of chests that can spawn at one time on this level. 
     */
    public void SetActChestCount(int i) {
        actChestCount = i;
    }

    /**
     * Gets the actual number of objects that can spawn at one time on this level.
     * 
     * @return      The actual number of objects that can spawn at one time on this level.
     */
    public int GetActObjCount() {
        return actObjCount;
    }

    /**
     * Sets the actual number of objects that can spawn at one time on this level.
     * 
     * @param i     The actual number of objects that can spawn at one time on this level. 
     */
    public void SetActObjCount(int i) {
        actObjCount = i;
    }

    /**
     * Gets the minimum number of objects that can spawn at one time on this level.
     * 
     * @return      The minimum number of objects that can spawn at one time on this level. 
     */
    public int GetMinObjCount() {
        return minObjCount;
    }

    /**
     * Sets the minimum number of objects that can spawn at one time on this level.
     * 
     * @param i    The minimum number of objects that can spawn at one time on this level.  
     */
    public void SetMinObjCount(int i) {
        minObjCount = i;
    }

    /**
     * Gets the maximum number of objects that can spawn at one time on this level.
     * 
     * @return      The maximum number of objects that can spawn at one time on this level. 
     */
    public int GetMaxObjCount() {
        return maxObjCount;
    }

    /**
     * Sets the maximum number of objects that can spawn at one time on this level.
     * 
     * @param i    The maximum number of objects that can spawn at one time on this level.  
     */
    public void SetMaxObjCount(int i) {
        maxObjCount = i;
    }

    /**
     * Gets the minimum number of chests that can spawn at one time on this level.
     * 
     * @return      The minimum number of chests that can spawn at one time on this level. 
     */
    public int GetMinChestCount() {
        return minChestCount;
    }

    /**
     * Sets the minimum number of chests that can spawn at one time on this level.
     * 
     * @param i    The minimum number of chests that can spawn at one time on this level.  
     */
    public void SetMinChestCount(int i) {
        minChestCount = i;
    }

    /**
     * Gets the maximum number of chests that can spawn at one time on this level.
     * 
     * @return      The maximum number of chests that can spawn at one time on this level. 
     */
    public int GetMaxChestCount() {
        return maxChestCount;
    }

    /**
     * Sets the maximum number of chests that can spawn at one time on this level.
     * 
     * @param i    The maximum number of chests that can spawn at one time on this level.  
     */
    public void SetMaxChestCount(int i) {
        maxChestCount = i;
    }
    
    /**
     * Gets the total time in milliseconds that this level will run.
     * 
     * @return      The total number in milliseconds that this level will run.
     */
    public long GetTimeTotalMs() {
        return timeTotalMs;
    }

    /**
     * Sets the total time in milliseconds that this level will run.
     * 
     * @return      The total number in milliseconds that this level will run.
     */
    public void SetTimeTotalMs(long l) {
        timeTotalMs = l;
    }

    /**
     * Gets the time that this level started in milliseconds.
     * 
     * @return       The time that this level started in milliseconds.
     */
    public long GetTimeStartMs() {
        return timeStartMs;
    }

    /**
     * Sets the time that this level started in milliseconds.
     * 
     * @param l     The time that this level started in milliseconds.
     */
    public void SetTimeStartMs(long l) {
        timeStartMs = l;
    }

    /**
     * Gets the time that this level started in milliseconds.
     * 
     * @return      The time that this level started in milliseconds. 
     */
    public long GetTimeCurrentMs() {
        return timeCurrentMs;
    }

    /**
     * Sets the current time in milliseconds that this level has been active.
     * 
     * @param l     The time that this level has been active in milliseconds.
     */
    public void SetTimeCurrentMs(long l) {
        timeCurrentMs = l;
    }

    /**
     * Gets the current time in milliseconds that this level has been active.
     * 
     * @return      The time that this level has been active in milliseconds. 
     */
    public long GetIntervalBetweenEnemiesMs() {
        return intervalBetweenEnemiesMs;
    }

    /**
     * Sets the interval in milliseconds in between spawning new enemies.
     * 
     * @param l     The interval in milliseconds in between spawning new enemies.
     */
    public void SetIntervalBetweenEnemiesMs(long l) {
        intervalBetweenEnemiesMs = l;
    }

    /**
     * Gets the interval in milliseconds in between spawning new enemies.
     * 
     * @return      The interval in milliseconds in between spawning new enemies. 
     */
    public MdtDoorType[] GetActiveDoors() {
        return activeDoors;
    }

    /**
     * Sets the doors that this level uses to spawn new enemies by.
     * 
     * @param Doors     The doors that this level uses to spawn new enemies by. 
     */
    public void SetActiveDoors(MdtDoorType[] Doors) {
        activeDoors = Doors;
    }

    /**
     * Gets the doors that this level uses to spawn new enemies by.
     * 
     * @return      The doors that this level uses to spawn new enemies by.
     */
    public int GetMinAtOneTime() {
        return minAtOneTime;
    }

    /**
     * Sets the minimum number of enemies that can spawn at one time.
     * 
     * @param i     The minimum number of enemies that can spawn at one time. 
     */
    public void SetMinAtOneTime(int i) {
        minAtOneTime = i;
    }

    /**
     * Gets the minimum number of enemies that can spawn at one time.
     * 
     * @return      The minimum number of enemies that can spawn at one time.
     */
    public int GetMaxAtOneTime() {
        return maxAtOneTime;
    }

    /**
     * Sets the maximum number of enemies that can spawn at one time.
     * 
     * @param i     The maximum number of enemies that can spawn at one time. 
     */
    public void SetMaxAtOneTime(int i) {
        maxAtOneTime = i;
    }

    /**
     * Gets the maximum number of enemies that can spawn at one time.
     * 
     * @return      The maximum number of enemies that can spawn at one time. 
     */
    public MdtWeaponType[] GetActiveWeapons() {
        return activeWeapons;
    }

    /**
     * Sets the weapon types that can be dropped by enemies on this level.
     * 
     * @param Weapons       The weapon types that can be dropped by enemies on this level. 
     */
    public void SetActiveWeapons(MdtWeaponType[] Weapons) {
        activeWeapons = Weapons;
    }

    /**
     * Gets the weapon types that can be dropped by enemies on this level.
     * 
     * @return      The weapon types that can be dropped by enemies on this level. 
     */
    public MdtItemType[] GetActiveItems() {
        return activeItems;
    }

    /**
     * Sets the item types that can be dropped by enemies on this level.
     * 
     * @param Items     The item types that can be dropped by enemies on this level. 
     */
    public void SetActiveItems(MdtItemType[] Items) {
        activeItems = Items;
    }

    /**
     * Gets the total number of enemies that are spawned on this level.
     * 
     * @return      The total number of enemies that are spawned on this level.      
     */
    public int GetEnemyCount() {
        return enemyCount;
    }

    /**
     * Sets the total number of enemies that are spawned on this level.
     * 
     * @param Count     The total number of enemies that are spawned on this level. 
     */
    public void SetEnemyCount(int Count) {
        enemyCount = Count;
    }

    /**
     * Gets the index of this level descriptor in an array of level descriptors.
     * 
     * @return      The index of this level descriptor in an array of level descriptors. 
     */
    public int GetIdx() {
        return idx;
    }

    /**
     * Sets the index of this level descriptor in an array of level descriptors.
     * 
     * @param i     The index of this level descriptor in an array of level descriptors.
     */
    public void SetIdx(int i) {
        idx = i;
    }

    /**
     * Gets the current interval time for the given wave.
     * 
     * @return      The current interval time for the given wave. 
     */
    public long GetTimeIntervalMs() {
        return timeIntervalMs;
    }

    /**
     * Sets the current interval time for the given wave.
     * 
     * @param l     The current interval time for the given wave. 
     */
    public void SetTimeIntervalMs(long l) {
        timeIntervalMs = l;
    }   
}