using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that represents a two dimensional vector.
    /// Created by Middlemind Games 01/06/2005
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgVector2
    {
        /// <summary>
        /// The vector data.
        /// </summary>
        private double[] vec;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgVector2()
        {
            vec = new double[] { 0, 0 };
        }

        /// <summary>
        /// Constructor for this class sets its values based on the attributes of the
        /// given argument.
        /// </summary>
        /// <param name="v">The MmgVector2 to base this class off of.</param>
        public MmgVector2(MmgVector2 v)
        {
            vec = new double[] { v.GetXDouble(), v.GetYDouble() };
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="v">The X, Y value of the vector.</param>
        public MmgVector2(double[] v)
        {
            vec = v;
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2(double x, double y)
        {
            vec = new double[] { x, y };
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2(double x)
        {
            vec = new double[] { (double)x, (double)x };
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2(float x, float y)
        {
            vec = new double[] { (double)x, (double)y };
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2(float x)
        {
            vec = new double[] { (double)x, (double)x };
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2(int x, int y)
        {
            vec = new double[] { (double)x, (double)y };
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2(int x)
        {
            vec = new double[] { (double)x, (double)x };
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public virtual MmgVector2 Clone()
        {
            if (this is MmgVector2Int)
            {
                return ((MmgVector2Int)this).Clone();
            }
            else
            {
                return new MmgVector2(vec[0], vec[1]);
            }
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public virtual void SetX(double x)
        {
            vec[0] = x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public virtual void SetY(double y)
        {
            vec[1] = y;
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public virtual void SetX(float x)
        {
            vec[0] = (double)x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public virtual void SetY(float y)
        {
            vec[1] = (double)y;
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public virtual void SetX(int x)
        {
            vec[0] = (double)x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public virtual void SetY(int y)
        {
            vec[1] = (double)y;
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public virtual int GetX()
        {
            return (int)vec[0];
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public virtual int GetY()
        {
            return (int)vec[1];
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public virtual double GetXDouble()
        {
            return vec[0];
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public virtual double GetYDouble()
        {
            return vec[1];
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public virtual float GetXFloat()
        {
            return (float)vec[0];
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public virtual float GetYFloat()
        {
            return (float)vec[1];
        }

        /// <summary>
        /// Gets the vector values.
        /// </summary>
        /// <returns>The vector values.</returns>
        public virtual double[] GetVector()
        {
            return vec;
        }

        /// <summary>
        /// Sets the vector values.
        /// </summary>
        /// <param name="v">The vector values.</param>
        public virtual void SetVector(double[] v)
        {
            vec = v;
        }

        /// <summary>
        /// Clones this object to a float based vector.
        /// </summary>
        /// <returns>A float based clone.</returns>
        public virtual MmgVector2 CloneFloat()
        {
            return new MmgVector2(GetXFloat(), GetYFloat());
        }

        /// <summary>
        /// Clones this object to a double based vector.
        /// </summary>
        /// <returns>A double based clone.</returns>
        public virtual MmgVector2 CloneDouble()
        {
            return new MmgVector2(GetXDouble(), GetYDouble());
        }

        /// <summary>
        /// Clones this object to an integer based vector.
        /// </summary>
        /// <returns>An integer based clone.</returns>
        public virtual MmgVector2 CloneInt()
        {
            return new MmgVector2(GetX(), GetY());
        }

        /// <summary>
        /// Returns a new copy of the origin vector, (0, 0).
        /// </summary>
        /// <returns>The origin vector.</returns>
        public static MmgVector2 GetOriginVec()
        {
            return new MmgVector2(0, 0);
        }

        /// <summary>
        /// Returns a new copy of the unit vector, (1, 1).
        /// </summary>
        /// <returns>The unit vector.</returns>
        public static MmgVector2 GetUnitVec()
        {
            return new MmgVector2(1, 1);
        }

        /// <summary>
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public virtual string ApiToString()
        {
            if (this is MmgVector2Int)
            {
                return ((MmgVector2Int)this).ApiToString();
            }
            else
            {
                return "MmgVector2: X: " + GetXDouble() + " Y:" + GetYDouble();
            }
        }

        /// <summary>
        /// A method that tests equality with another MmgVector2 object by comparing the coordinates.
        /// </summary>
        /// <param name="obj">An MmgVector2 object to compare for equality.</param>
        /// <returns>A boolean indicating if this object is equal to the comparison object.</returns>
        public virtual bool ApiEquals(MmgVector2 obj)
        {
            if (this is MmgVector2Int)
            {
                if (obj is MmgVector2Int)
                {
                    return ((MmgVector2Int)this).ApiEquals((MmgVector2Int)obj);
                }
                else
                {
                    return ((MmgVector2Int)this).ApiEquals(obj);
                }
            }

            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;

            //MmgHelper.wr("MmgVector2: ApiEquals: Obj: " + obj.GetXDouble() + ", " + obj.GetYDouble());
            //MmgHelper.wr("MmgVector2: ApiEquals: this: " + GetXDouble() + ", " + GetYDouble());
            if (obj.GetXDouble() == GetXDouble()
                && obj.GetYDouble() == GetYDouble()
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}