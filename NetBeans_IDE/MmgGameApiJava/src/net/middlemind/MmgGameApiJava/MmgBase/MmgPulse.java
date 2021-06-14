package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that represents a pulse or changing value.
 * Created by Middlemind Games 06/01/2005
 *
 * @author Victor G. Brusca
 */
public class MmgPulse {

    /**
     * If the pulse if growing 1 or shrinking -1.
     */
    private int direction; //growing or shrinking, 1 or -1

    /**
     * How much time until the direction is flipped.
     */
    private long timeFlip; //how much time until the direction is flipped

    /**
     * How much total time in the oscillation.
     */
    private long timeTotal; //how much total time in the oscillation

    /**
     * The start time for the oscillation.
     */
    private long timeStart;

    /**
     * Total change that must occur.
     */
    private double change;

    /**
     * Total change that must occur per millisecond.
     */
    private double changePerMs;

    /**
     * Time difference.
     */
    private long timeDiff;

    /**
     * Scaling baseline values.
     */
    private MmgVector2 baseLineScaling;

    /**
     * Adjusted scaling values.
     */
    private MmgVector2 adjScaling;

    /**
     * A class helper variable.
     */
    private double tmpX;

    /**
     * A class helper variable.
     */
    private double tmpY;

    /**
     * Constructor that sets the start direction, the total milliseconds, the
     * change, and a baseline scaling value.
     *
     * @param startDir      The oscillation start direction.
     * @param totalMs       The total milliseconds to use for the entire oscillation.
     * @param chng          The change to apply to the object.
     * @param blS           A baseline scaling value.
     */
    public MmgPulse(int startDir, long totalMs, double chng, MmgVector2 blS) {
        SetDirection(startDir);
        SetTimeTotal(totalMs);
        SetTimeFlip(totalMs / 2);
        SetTimeStart(0);
        SetChange(chng);
        SetBaseLineScaling(blS);
        SetAdjScaling(new MmgVector2(baseLineScaling.GetXDouble() + (baseLineScaling.GetXDouble() * change * direction), baseLineScaling.GetYDouble() + (baseLineScaling.GetYDouble() * change * direction)));
        SetChangePerMs((adjScaling.GetXDouble() - baseLineScaling.GetXDouble()) / timeFlip);
    }

    /**
     * A specialized constructor that takes an MmgPulse object as an argument and creates a new unique MmgPulse object from it with no shared references.
     * 
     * @param obj       The MmgPulse object to use in the creation of a new unique MmgPulse object.
     */
    public MmgPulse(MmgPulse obj) {
        SetDirection(obj.GetDirection());
        SetTimeTotal(obj.GetTimeTotal());
        SetTimeFlip(obj.GetTimeFlip());
        SetTimeStart(obj.GetTimeStart());
        SetChange(obj.GetChange());
        
        if(obj.GetBaseLineScaling() == null) {
            SetBaseLineScaling(obj.GetBaseLineScaling());
        } else {
            SetBaseLineScaling(obj.GetBaseLineScaling().Clone());
        }        
        
        if(obj.GetAdjScaling() == null) {
            SetAdjScaling(obj.GetAdjScaling());
        } else {
            SetAdjScaling(obj.GetAdjScaling().Clone());
        }
                
        SetChangePerMs(obj.GetChangePerMs());
    }
    
    /**
     * Creates a typed clone of this class.
     *
     * @return      A typed clone of this class.
     */    
    public MmgPulse Clone() {
        return new MmgPulse(this);
    }
    
    /**
     * Get the change per millisecond value.
     * 
     * @return      The change per millisecond value.
     */
    public double GetChangePerMs() {
        return changePerMs;
    }

    /**
     * Set the change per millisecond value.
     * 
     * @param d     The change per millisecond value.
     */
    public void SetChangePerMs(double d) {
        changePerMs = d;
    }

    /**
     * Get the base line MmgVector2 object for this animation.
     * 
     * @return      The base line MmgVector2 object that represents the base line for this animation.
     * 
     */
    public MmgVector2 GetBaseLineScaling() {
        return baseLineScaling;
    }

    /**
     * Set the base line MmgVector2 object for this animation.
     * 
     * @param v     The base line MmgVector2 object that represents the base line for this animation.
     */
    public void SetBaseLineScaling(MmgVector2 v) {
        baseLineScaling = v;
    }

    /**
     * Get the adjusted MmgVector2 object for this animation.
     * 
     * @return      The adjusted MmgVector2 object that represents the base line for this animation.
     */
    public MmgVector2 GetAdjScaling() {
        return adjScaling;
    }

    /**
     * Set the adjusted MmgVector2 object for this animation.
     * 
     * @param v     The adjusted MmgVector2 object that represents the base line for this animation.
     */
    public void SetAdjScaling(MmgVector2 v) {
        adjScaling = v;
    }

    /**
     * Gets the direction of the oscillation.
     *
     * @return      The direction of the oscillation.
     */
    public int GetDirection() {
        return direction;
    }

    /**
     * Sets the direction of the oscillation.
     *
     * @param d     The direction of the oscillation.
     */
    public void SetDirection(int d) {
        direction = d;
    }

    /**
     * Gets the oscillation time flip for this object.
     *
     * @return      The oscillation time flip.
     */
    public long GetTimeFlip() {
        return timeFlip;
    }

    /**
     * Sets the oscillation time flip for this object.
     *
     * @param l     The oscillation time flip.
     */
    public void SetTimeFlip(long l) {
        timeFlip = l;
    }

    /**
     * Gets the total oscillation time.
     *
     * @return      The total oscillation time.
     */
    public long GetTimeTotal() {
        return timeTotal;
    }

    /**
     * Sets the total oscillation time.
     *
     * @param l     The total oscillation time.
     */
    public void SetTimeTotal(long l) {
        timeTotal = l;
    }

    /**
     * Gets the oscillation start time.
     *
     * @return      The oscillation start time.
     */
    public long GetTimeStart() {
        return timeStart;
    }

    /**
     * Sets the oscillation start time.
     *
     * @param l     The oscillation start time.
     */
    public void SetTimeStart(long l) {
        timeStart = l;
    }

    /**
     * Gets the rate of change.
     *
     * @return      The rate of change.
     */
    public double GetChange() {
        return change;
    }

    /**
     * Sets the rate of change.
     *
     * @param c     The rate of change.
     */
    public void SetChange(double c) {
        change = c;
    }

    /**
     * Updates the current pulse state.
     *
     * @param v     The current object position.
     */
    public void Update(MmgVector2 v) {
        if (timeStart == 0) {
            timeStart = System.currentTimeMillis();
        }

        timeDiff = (long) (System.currentTimeMillis() - timeStart);
        tmpX = 0;
        tmpY = 0;

        if (direction == 1) {
            tmpX = baseLineScaling.GetXDouble() + ((double) changePerMs * (double) timeDiff);
            tmpY = baseLineScaling.GetYDouble() + ((double) changePerMs * (double) timeDiff);

        } else if (direction == -1) {
            tmpX = adjScaling.GetXDouble() - ((double) changePerMs * (double) timeDiff);
            tmpY = adjScaling.GetYDouble() - ((double) changePerMs * (double) timeDiff);
        }

        v.SetX(tmpX);
        v.SetY(tmpY);

        if (timeDiff >= timeFlip) {
            timeStart = 0;
            direction *= -1;
        }
    }
    
    /**
     * Returns a string representation of this class.
     * 
     * @return      A string representation of this class.
     */
    public String ApiToString() {
        String ret = "";
        ret += "Direction: " + direction + System.lineSeparator();
        ret += "TimeTotal: " + timeTotal + System.lineSeparator();
        ret += "TimeFlip: " + timeFlip + System.lineSeparator();
        ret += "TimeStart: " + timeStart + System.lineSeparator();
        ret += "Change: " + change + System.lineSeparator();
        ret += "Change/MS: " + changePerMs + System.lineSeparator();
        ret += "MaxX: " + adjScaling.GetXDouble() + System.lineSeparator();
        ret += "MaxY: " + adjScaling.GetYDouble() + System.lineSeparator();
        ret += "BaseX: " + baseLineScaling.GetXDouble() + System.lineSeparator();
        ret += "BaseY: " + baseLineScaling.GetYDouble() + System.lineSeparator();
        return ret;
    }
    
    /**
     * A method used to check the equality of this MmgPulse when compared to another MmgPulse.
     * Compares object fields to determine equality.
     * 
     * @param p     The MmgPulse object to compare too.
     * @return      A boolean indicating equality.
     */
    public boolean ApiEquals(MmgPulse obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        boolean ret = false;
        if(
            ((obj.GetAdjScaling() == null && GetAdjScaling() == null) || (obj.GetAdjScaling() != null && GetAdjScaling() != null && obj.GetAdjScaling().ApiEquals(GetAdjScaling())))
            && ((obj.GetBaseLineScaling() == null && GetBaseLineScaling() == null) || (obj.GetBaseLineScaling() != null && GetBaseLineScaling() != null && obj.GetBaseLineScaling().ApiEquals(GetBaseLineScaling())))
            && obj.GetChange() == GetChange()
            && obj.GetChangePerMs() == GetChangePerMs()
            && obj.GetDirection() == GetDirection()
            && obj.GetTimeFlip() == GetTimeFlip()
            && obj.GetTimeStart() == GetTimeStart()
            && obj.GetTimeTotal() == GetTimeTotal()                
        ) {
            ret = true;
        }
        return ret;
    }
}