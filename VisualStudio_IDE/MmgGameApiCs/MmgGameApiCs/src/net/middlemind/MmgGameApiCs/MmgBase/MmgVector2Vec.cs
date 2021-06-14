using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    //NOTES: Monogame specific MmgVector2 class, carried over from a previous implementation in XNA.
    /// <summary>
    /// Class that represents a two dimensional vector.
    /// Created by Middlemind Games 01/06/2005
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgVector2Vec : MmgVector2
    {
        /// <summary>
        /// The vector data.
        /// </summary>
        private Vector2 vec = Vector2.Zero;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgVector2Vec()
        {
            vec = Vector2.Zero;
        }

        /// <summary>
        /// Constructor for this class sets its values based on the attributes of the
        /// given argument.
        /// </summary>
        /// <param name="v">The MmgVector2Vec to base this class off of.</param>
        public MmgVector2Vec(MmgVector2Vec v)
        {
            vec = new Vector2(v.GetXFloat(), v.GetYFloat());
        }

        /// <summary>
        /// Constructor that sets the value of the vector.
        /// </summary>
        /// <param name="v">The value of the vector.</param>
        public MmgVector2Vec(Vector2 v)
        {
            vec = v;
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2Vec(double x, double y)
        {
            vec = new Vector2((float)x, (float)y);
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2Vec(double x)
        {
            vec = new Vector2((float)x, (float)x);
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2Vec(float x, float y)
        {
            vec = new Vector2(x, y);
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2Vec(float x)
        {
            vec = new Vector2((float)x, (float)x);
        }

        /// <summary>
        /// Constructor that sets the X, Y value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        /// <param name="y">The Y value of the vector.</param>
        public MmgVector2Vec(int x, int y)
        {
            vec = new Vector2((float)x, (float)y);
        }

        /// <summary>
        /// Constructor that sets the X, Y value based on one argument.
        /// </summary>
        /// <param name="x">The X value used to set both the X, Y coordinate.</param>
        public MmgVector2Vec(int x)
        {
            vec = new Vector2((float)x, (float)x);
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public virtual new MmgVector2Vec Clone()
        {
            return new MmgVector2Vec(this);
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public override void SetX(double x)
        {
            vec.X = (float)x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public override void SetY(double y)
        {
            vec.Y = (float)y;
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public override void SetX(float x)
        {
            vec.X = x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public override void SetY(float y)
        {
            vec.Y = y;
        }

        /// <summary>
        /// Sets the X value of the vector.
        /// </summary>
        /// <param name="x">The X value of the vector.</param>
        public override void SetX(int x)
        {
            vec.X = (float)x;
        }

        /// <summary>
        /// Sets the Y value of the vector.
        /// </summary>
        /// <param name="y">The Y value of the vector.</param>
        public override void SetY(int y)
        {
            vec.Y = (float)y;
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public override int GetX()
        {
            return (int)vec.X;
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public override int GetY()
        {
            return (int)vec.Y;
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public override double GetXDouble()
        {
            return (double)vec.X;
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public override double GetYDouble()
        {
            return (double)vec.Y;
        }

        /// <summary>
        /// Gets the X value of the vector.
        /// </summary>
        /// <returns>The X value of the vector.</returns>
        public override float GetXFloat()
        {
            return (float)vec.X;
        }

        /// <summary>
        /// Gets the Y value of the vector.
        /// </summary>
        /// <returns>The Y value of the vector.</returns>
        public override float GetYFloat()
        {
            return (float)vec.Y;
        }

        //NOTE: Monogame specific implementation to prevent having to instantiate a new Vector2.
        /// <summary>
        /// Gets the position vector, Monogame Vector2 object.
        /// </summary>
        /// <returns>The position as a Vector2 object.</returns>
        public virtual Vector2 GetVector2()
        {
            return vec;
        }

        //NOTE: Monogame specific implementation to prevent having to instantiate a new Vector2.
        /// <summary>
        /// Sets the position vector, Monogame Vector2 object.
        /// </summary>
        /// <param name="Vec">The position as a Vector2 object.</param>
        public virtual void SetVector2(Vector2 Vec)
        {
            vec = Vec;
        }

        /// <summary>
        /// Gets the vector values.
        /// </summary>
        /// <returns>The vector values.</returns>
        public override double[] GetVector()
        {
            return new double[] {(double)vec.X, (double)vec.Y};
        }

        /// <summary>
        /// Sets the vector values.
        /// </summary>
        /// <param name="v">The vector values.</param>
        public override void SetVector(double[] v)
        {
            SetX(v[0]);
            SetY(v[1]);
        }

        /// <summary>
        /// Clones this object to a float based vector.
        /// </summary>
        /// <returns>A float based clone.</returns>
        public virtual new MmgVector2Vec CloneFloat()
        {
            return new MmgVector2Vec(GetXFloat(), GetYFloat());
        }

        /// <summary>
        /// Clones this object to a double based vector.
        /// </summary>
        /// <returns>A double based clone.</returns>
        public virtual new MmgVector2Vec CloneDouble()
        {
            return new MmgVector2Vec(GetXDouble(), GetYDouble());
        }

        /// <summary>
        /// Clones this object to an integer based vector.
        /// </summary>
        /// <returns>An integer based clone.</returns>
        public virtual new MmgVector2Vec CloneInt()
        {
            return new MmgVector2Vec(GetX(), GetY());
        }

        /// <summary>
        /// Returns a new copy of the origin vector, (0, 0).
        /// </summary>
        /// <returns>The origin vector.</returns>
        public new static MmgVector2Vec GetOriginVec()
        {
            return new MmgVector2Vec(0, 0);
        }

        /// <summary>
        /// Returns a new copy of the unit vector, (1, 1).
        /// </summary>
        /// <returns>The unit vector.</returns>
        public new static MmgVector2Vec GetUnitVec()
        {
            return new MmgVector2Vec(1, 1);
        }

        /// <summary>
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public override string ApiToString()
        {
            return "MmgVector2Vec: X: " + GetXDouble() + " Y: " + GetYDouble();
        }

        /// <summary>
        /// A method that tests equality with another MmgVector2 object by comparing the coordinates.
        /// </summary>
        /// <param name="obj">An MmgVector2 object to compare for equality.</param>
        /// <returns>A boolean indicating if this object is equal to the comparison object.</returns>
        public virtual bool ApiEquals(MmgVector2Vec obj)
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