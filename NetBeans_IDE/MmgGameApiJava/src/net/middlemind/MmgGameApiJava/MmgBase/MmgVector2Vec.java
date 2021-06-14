package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that represents a two dimensional vector.
 * Created by Middlemind Games 01/06/2005
 *
 * @author Victor G. Brusca
 */
public class MmgVector2Vec extends MmgVector2 {

    /**
     * The vector data.
     */
    private float[] vec;

    /**
     * Constructor for this class.
     */
    public MmgVector2Vec() {
        vec = new float[]{0, 0};
    }
    
    /**
     * Constructor for this class sets its values based on the attributes of the
     * given argument.
     *
     * @param v     The MmgVector2 to base this class off of.
     */
    public MmgVector2Vec(MmgVector2Vec v) {
        vec = new float[] { (float)v.GetXDouble(), (float)v.GetYDouble() };
    }

    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param v     The X, Y value of the vector.
     */
    public MmgVector2Vec(float[] v) {
        vec = v;
    }

    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2Vec(double x, double y) {
        vec = new float[]{(float)x, (float)y};
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2Vec(double x) {
        vec = new float[]{(float) x, (float) x};
    }    
    
    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2Vec(float x, float y) {
        vec = new float[]{ x, y };
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2Vec(float x) {
        vec = new float[]{ x, x };
    }    
    
    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2Vec(int x, int y) {
        vec = new float[]{(float) x, (float) y};
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2Vec(int x) {
        vec = new float[]{(float) x, (float) x};
    }
    
    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    @Override
    public MmgVector2Vec Clone() {
        return new MmgVector2Vec(vec[0], vec[1]);
    }
    
    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    @Override
    public void SetX(double x) {
        vec[0] = (float)x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    @Override
    public void SetY(double y) {
        vec[1] = (float)y;
    }

    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    @Override
    public void SetX(float x) {
        vec[0] = x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    @Override
    public void SetY(float y) {
        vec[1] = y;
    }

    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    @Override
    public void SetX(int x) {
        vec[0] = (float) x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    @Override
    public void SetY(int y) {
        vec[1] = (float) y;
    }

    /**
     * Gets the X value of the vector.
     *
     * @return      The X value of the vector.
     */
    @Override
    public int GetX() {
        return (int) vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    @Override
    public int GetY() {
        return (int) vec[1];
    }

    /**
     * Gets the X value of the vector.
     *
     * @return      The X value of the vector.
     */
    @Override
    public double GetXDouble() {
        return (double)vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    @Override
    public double GetYDouble() {
        return (double)vec[1];
    }

    /**
     * Gets the X value of the vector.
     *
     * @return      The X value of the vector.
     */
    @Override
    public float GetXFloat() {
        return vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    @Override
    public float GetYFloat() {
        return vec[1];
    }

    /**
     * Gets the vector values.
     *
     * @return      The vector values.
     */
    @Override
    public double[] GetVector() {
        return new double[] { GetXDouble(), GetYDouble() };
    }

    /**
     * Sets the vector values.
     *
     * @param v     The vector values.
     */
    @Override
    public void SetVector(double[] v) {
        SetX(v[0]);
        SetY(v[1]);
    }

    /**
     * Clones this object to a float based vector.
     *
     * @return      A float based clone.
     */
    @Override
    public MmgVector2Vec CloneFloat() {
        return new MmgVector2Vec(GetXFloat(), GetYFloat());
    }

    /**
     * Clones this object to a double based vector.
     *
     * @return      A double based clone.
     */
    @Override
    public MmgVector2Vec CloneDouble() {
        return new MmgVector2Vec(GetXDouble(), GetYDouble());
    }

    /**
     * Clones this object to an integer based vector.
     *
     * @return      An integer based clone.
     */
    @Override
    public MmgVector2Vec CloneInt() {
        return new MmgVector2Vec(GetX(), GetY());
    }    
    
    /**
     * Returns a new copy of the origin vector, (0, 0).
     *
     * @return      The origin vector.
     */
    public static MmgVector2Vec GetOriginVec() {
        return new MmgVector2Vec(0, 0);
    }

    /**
     * Returns a new copy of the unit vector, (1, 1).
     *
     * @return      The unit vector.
     */
    public static MmgVector2Vec GetUnitVec() {
        return new MmgVector2Vec(1, 1);
    }

    /**
     * Returns a string representation of the vector.
     *
     * @return      A string representation of the vector.
     */
    @Override
    public String ApiToString() {
        return "MmgVectorVec: X: " + GetXDouble() + " Y:" + GetYDouble();
    }

    /**
     * A method that tests equality with another MmgVector2 object by comparing the coordinates.
     * 
     * @param obj     An MmgVector2 object to compare for equality.
     * @return      A boolean indicating if this object is equal to the comparison object.
     */
    public boolean ApiEquals(MmgVector2Vec obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }

        boolean ret = false;
        if (obj.GetXDouble() == GetXDouble() 
            && obj.GetYDouble() == GetYDouble()
        ) {
            ret = true;
        }
        return ret;
    }
}