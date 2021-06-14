using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that represents a two dimensional integer vector.
    /// Created by Middlemind Games 01/06/2005
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgVector2Int : MmgVector2
    {
        /// <summary>
        /// The vector data.
        /// </summary>
        private int[] vec;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgVector2Int()
        {
            vec = new int[] { 0, 0 };
        }

        /// <summary>
        /// Constructor for this class sets its values based on the attributes of the
        /// given argument.
        /// </summary>
        /// <param name="v">The MmgVector2 to base this class off of.</param>
        public MmgVector2Int(MmgVector2Int v)
        {
            vec = new int[] { v.GetX(), v.GetY() };
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="v">The X, Y value of the vector.</param>
        public MmgVector2Int(int[] v)
        {
            vec = v;
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2Int(int x, int y)
        {
            vec = new int[] { x, y };
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2Int(int x)
        {
            vec = new int[] { x, x };
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="v">The X, Y value of the vector.</param>
        public MmgVector2Int(double[] v)
        {
            vec = new int[] { (int)v[0], (int)v[1] };
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2Int(double x, double y)
        {
            vec = new int[] { (int)x, (int)y };
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2Int(double x)
        {
            vec = new int[] { (int)x, (int)x };
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2Int(float x, float y)
        {
            vec = new int[] { (int)x, (int)y };
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2Int(float x)
        {
            vec = new int[] { (int)x, (int)x };
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public virtual new MmgVector2Int Clone()
        {
            return new MmgVector2Int(vec[0], vec[1]);
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public override void SetX(double x)
        {
            vec[0] = (int)x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public override void SetY(double y)
        {
            vec[1] = (int)y;
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public override void SetX(float x)
        {
            vec[0] = (int)x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public override void SetY(float y)
        {
            vec[1] = (int)y;
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public override void SetX(int x)
        {
            vec[0] = x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public override void SetY(int y)
        {
            vec[1] = y;
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public override int GetX()
        {
            return vec[0];
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public override int GetY()
        {
            return vec[1];
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public override double GetXDouble()
        {
            return (double)vec[0];
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public override double GetYDouble()
        {
            return (double)vec[1];
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public override float GetXFloat()
        {
            return (float)vec[0];
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public override float GetYFloat()
        {
            return (float)vec[1];
        }

        /// <summary>
        /// Gets the vector values.
        /// </summary>
        /// <returns>The vector values.</returns>
        public virtual int[] GetVectorInt()
        {
            return new int[] { GetX(), GetY() };
        }

        /// <summary>
        /// Sets the vector values.
        /// </summary>
        /// <param name="v">The vector values.</param>
        public virtual void SetVectorInt(int[] v)
        {
            SetX(v[0]);
            SetY(v[1]);
        }

        /// <summary>
        /// Sets the vector values from a double array.
        /// </summary>
        /// <param name="d">An array of vector coordinates.</param>
        public override void SetVector(double[] d)
        {
            SetX((int)d[0]);
            SetY((int)d[0]);
        }

        /// <summary>
        /// Gets the vector values as a double array.
        /// </summary>
        /// <returns>An array of vector coordinates.</returns>
        public override double[] GetVector()
        {
            return new double[] { GetXDouble(), GetYDouble() };
        }

        /// <summary>
        /// Clones this object to a float based vector.
        /// </summary>
        /// <returns>A float based clone.</returns>
        public virtual new MmgVector2Int CloneFloat()
        {
            return new MmgVector2Int(GetXFloat(), GetYFloat());
        }

        /// <summary>
        /// Clones this object to a double based vector.
        /// </summary>
        /// <returns>A double based clone.</returns>
        public virtual new MmgVector2Int CloneDouble()
        {
            return new MmgVector2Int(GetXDouble(), GetYDouble());
        }

        /// <summary>
        /// Clones this object to an integer based vector.
        /// </summary>
        /// <returns>An integer based clone.</returns>
        public virtual new MmgVector2Int CloneInt()
        {
            return new MmgVector2Int(GetX(), GetY());
        }

        /// <summary>
        /// Returns a new copy of the origin vector, (0, 0).
        /// </summary>
        /// <returns>The origin vector.</returns>
        public new static MmgVector2Int GetOriginVec()
        {
            return new MmgVector2Int(0, 0);
        }

        /// <summary>
        /// Returns a new copy of the unit vector, (1, 1).
        /// </summary>
        /// <returns>The unit vector.</returns>
        public new static MmgVector2Int GetUnitVec()
        {
            return new MmgVector2Int(1, 1);
        }

        /// <summary>
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public override string ApiToString()
        {
            return "MmgVector2Int: X: " + GetXDouble() + " Y:" + GetYDouble();
        }

        /// <summary>
        /// A method that tests equality with another MmgVector2 object by comparing the coordinates.
        /// </summary>
        /// <param name="obj">An MmgVector2 object to compare for equality.</param>
        /// <returns>A boolean indicating if this object is equal to the comparison object.</returns>
        public override bool ApiEquals(MmgVector2 obj)
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
            if (obj.GetXDouble() == GetXDouble()
                && obj.GetYDouble() == GetYDouble()
            )
            {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// A method that tests equality with another MmgVector2 object by comparing the coordinates.
        /// </summary>
        /// <param name="obj">An MmgVector2 object to compare for equality.</param>
        /// <returns>A boolean indicating if this object is equal to the comparison object.</returns>
        public virtual bool ApiEquals(MmgVector2Int obj)
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