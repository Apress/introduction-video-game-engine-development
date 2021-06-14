using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that represents a pulse or changing value.
    /// Created by Middlemind Games 06/01/2005
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgPulse
    {
        /// <summary>
        /// If the pulse if growing 1 or shrinking -1.
        /// </summary>
        private int direction; //growing or shrinking, 1 or -1

        /// <summary>
        /// How much time until the direction is flipped.
        /// </summary>
        private long timeFlip; //how much time until the direction is flipped

        /// <summary>
        /// How much total time in the oscillation.
        /// </summary>
        private long timeTotal; //how much total time in the oscillation

        /// <summary>
        /// The start time for the oscillation.
        /// </summary>
        private long timeStart;

        /// <summary>
        /// Total change that must occur.
        /// </summary>
        private double change;

        /// <summary>
        /// Total change that must occur per millisecond.
        /// </summary>
        private double changePerMs;

        /// <summary>
        /// Time difference.
        /// </summary>
        private long timeDiff;

        /// <summary>
        /// Scaling baseline values.
        /// </summary>
        private MmgVector2 baseLineScaling;

        /// <summary>
        /// Adjusted scaling values.
        /// </summary>
        private MmgVector2 adjScaling;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private double tmpX;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private double tmpY;

        /// <summary>
        /// Constructor that sets the start direction, the total milliseconds, the
        /// change, and a baseline scaling value.
        /// </summary>
        /// <param name="startDir">The oscillation start direction.</param>
        /// <param name="totalMs">The total milliseconds to use for the entire oscillation.</param>
        /// <param name="chng">The change to apply to the object.</param>
        /// <param name="blS">A baseline scaling value.</param>
        public MmgPulse(int startDir, long totalMs, double chng, MmgVector2 blS)
        {
            SetDirection(startDir);
            SetTimeTotal(totalMs);
            SetTimeFlip(totalMs / 2);
            SetTimeStart(0);
            SetChange(chng);
            SetBaseLineScaling(blS);
            SetAdjScaling(new MmgVector2(baseLineScaling.GetXDouble() + (baseLineScaling.GetXDouble() * change * direction), baseLineScaling.GetYDouble() + (baseLineScaling.GetYDouble() * change * direction)));
            SetChangePerMs((adjScaling.GetXDouble() - baseLineScaling.GetXDouble()) / timeFlip);
        }

        /// <summary>
        /// A specialized constructor that takes an MmgPulse object as an argument and creates a new unique MmgPulse object from it with no shared references.
        /// </summary>
        /// <param name="obj">The MmgPulse object to use in the creation of a new unique MmgPulse object.</param>
        public MmgPulse(MmgPulse obj)
        {
            SetDirection(obj.GetDirection());
            SetTimeTotal(obj.GetTimeTotal());
            SetTimeFlip(obj.GetTimeFlip());
            SetTimeStart(obj.GetTimeStart());
            SetChange(obj.GetChange());

            if (obj.GetBaseLineScaling() == null)
            {
                SetBaseLineScaling(obj.GetBaseLineScaling());
            }
            else
            {
                SetBaseLineScaling(obj.GetBaseLineScaling().Clone());
            }

            if (obj.GetAdjScaling() == null)
            {
                SetAdjScaling(obj.GetAdjScaling());
            }
            else
            {
                SetAdjScaling(obj.GetAdjScaling().Clone());
            }

            SetChangePerMs(obj.GetChangePerMs());
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual MmgPulse Clone()
        {
            return new MmgPulse(this);
        }

        /// <summary>
        /// Get the change per millisecond value.
        /// </summary>
        /// <returns>The change per millisecond value.</returns>
        public virtual double GetChangePerMs()
        {
            return changePerMs;
        }

        /// <summary>
        /// Set the change per millisecond value.
        /// </summary>
        /// <param name="d">The change per millisecond value.</param>
        public virtual void SetChangePerMs(double d)
        {
            changePerMs = d;
        }

        /// <summary>
        /// Get the base line MmgVector2 object for this animation.
        /// </summary>
        /// <returns>The base line MmgVector2 object that represents the base line for this animation.</returns>
        public virtual MmgVector2 GetBaseLineScaling()
        {
            return baseLineScaling;
        }

        /// <summary>
        /// Set the base line MmgVector2 object for this animation.
        /// </summary>
        /// <param name="v">The base line MmgVector2 object that represents the base line for this animation.</param>
        public virtual void SetBaseLineScaling(MmgVector2 v)
        {
            baseLineScaling = v;
        }

        /// <summary>
        /// Get the adjusted MmgVector2 object for this animation.
        /// </summary>
        /// <returns>The adjusted MmgVector2 object that represents the base line for this animation.</returns>
        public virtual MmgVector2 GetAdjScaling()
        {
            return adjScaling;
        }

        /// <summary>
        /// Set the adjusted MmgVector2 object for this animation.
        /// </summary>
        /// <param name="v">The adjusted MmgVector2 object that represents the base line for this animation.</param>
        public virtual void SetAdjScaling(MmgVector2 v)
        {
            adjScaling = v;
        }

        /// <summary>
        /// Gets the direction of the oscillation.
        /// </summary>
        /// <returns>The direction of the oscillation.</returns>
        public virtual int GetDirection()
        {
            return direction;
        }

        /// <summary>
        /// Sets the direction of the oscillation.
        /// </summary>
        /// <param name="d">The direction of the oscillation.</param>
        public virtual void SetDirection(int d)
        {
            direction = d;
        }

        /// <summary>
        /// Gets the oscillation time flip for this object.
        /// </summary>
        /// <returns>The oscillation time flip.</returns>
        public virtual long GetTimeFlip()
        {
            return timeFlip;
        }

        /// <summary>
        /// Sets the oscillation time flip for this object.
        /// </summary>
        /// <param name="l">The oscillation time flip.</param>
        public virtual void SetTimeFlip(long l)
        {
            timeFlip = l;
        }

        /// <summary>
        /// Gets the total oscillation time.
        /// </summary>
        /// <returns>The total oscillation time.</returns>
        public virtual long GetTimeTotal()
        {
            return timeTotal;
        }

        /// <summary>
        /// Sets the total oscillation time.
        /// </summary>
        /// <param name="l">The total oscillation time.</param>
        public virtual void SetTimeTotal(long l)
        {
            timeTotal = l;
        }

        /// <summary>
        /// Gets the oscillation start time.
        /// </summary>
        /// <returns>The oscillation start time.</returns>
        public virtual long GetTimeStart()
        {
            return timeStart;
        }

        /// <summary>
        /// Sets the oscillation start time.
        /// </summary>
        /// <param name="l">The oscillation start time.</param>
        public virtual void SetTimeStart(long l)
        {
            timeStart = l;
        }

        /// <summary>
        /// Gets the rate of change.
        /// </summary>
        /// <returns>The rate of change.</returns>
        public virtual double GetChange()
        {
            return change;
        }

        /// <summary>
        /// Sets the rate of change.
        /// </summary>
        /// <param name="c">The rate of change.</param>
        public virtual void SetChange(double c)
        {
            change = c;
        }

        /// <summary>
        /// Updates the current pulse state.
        /// </summary>
        /// <param name="v">The current object position.</param>
        public virtual void Update(MmgVector2 v)
        {
            if (timeStart == 0)
            {
                timeStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }

            timeDiff = (long)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - timeStart);
            tmpX = 0;
            tmpY = 0;

            if (direction == 1)
            {
                tmpX = baseLineScaling.GetXDouble() + ((double)changePerMs * (double)timeDiff);
                tmpY = baseLineScaling.GetYDouble() + ((double)changePerMs * (double)timeDiff);

            }
            else if (direction == -1)
            {
                tmpX = adjScaling.GetXDouble() - ((double)changePerMs * (double)timeDiff);
                tmpY = adjScaling.GetYDouble() - ((double)changePerMs * (double)timeDiff);
            }

            v.SetX(tmpX);
            v.SetY(tmpY);

            if (timeDiff >= timeFlip)
            {
                timeStart = 0;
                direction *= -1;
            }
        }

        /// <summary>
        /// Returns a string representation of this class.
        /// </summary>
        /// <returns>A string representation of this class.</returns>
        public virtual string ApiToString()
        {
            string ret = "";
            ret += "Direction: " + direction + System.Environment.NewLine;
            ret += "TimeTotal: " + timeTotal + System.Environment.NewLine;
            ret += "TimeFlip: " + timeFlip + System.Environment.NewLine;
            ret += "TimeStart: " + timeStart + System.Environment.NewLine;
            ret += "Change: " + change + System.Environment.NewLine;
            ret += "Change/MS: " + changePerMs + System.Environment.NewLine;
            ret += "MaxX: " + adjScaling.GetXDouble() + System.Environment.NewLine;
            ret += "MaxY: " + adjScaling.GetYDouble() + System.Environment.NewLine;
            ret += "BaseX: " + baseLineScaling.GetXDouble() + System.Environment.NewLine;
            ret += "BaseY: " + baseLineScaling.GetYDouble() + System.Environment.NewLine;
            return ret;
        }

        /// <summary>
        /// A method used to check the equality of this MmgPulse when compared to another MmgPulse.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgPulse object to compare too.</param>
        /// <returns>A boolean indicating equality.</returns>
        public virtual bool ApiEquals(MmgPulse obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;
            if (
                ((obj.GetAdjScaling() == null && GetAdjScaling() == null) || (obj.GetAdjScaling() != null && GetAdjScaling() != null && obj.GetAdjScaling().ApiEquals(GetAdjScaling())))
                && ((obj.GetBaseLineScaling() == null && GetBaseLineScaling() == null) || (obj.GetBaseLineScaling() != null && GetBaseLineScaling() != null && obj.GetBaseLineScaling().ApiEquals(GetBaseLineScaling())))
                && obj.GetChange() == GetChange()
                && obj.GetChangePerMs() == GetChangePerMs()
                && obj.GetDirection() == GetDirection()
                && obj.GetTimeFlip() == GetTimeFlip()
                && obj.GetTimeStart() == GetTimeStart()
                && obj.GetTimeTotal() == GetTimeTotal()
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}