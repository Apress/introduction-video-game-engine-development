package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that represents a two dimensional vector.
 * Created by Middlemind Games 01/06/2005
 *
 * @author Victor G. Brusca
 */
public class MmgVector2 {

    /**
     * The vector data.
     */
    private double[] vec;

    /**
     * Constructor for this class.
     */
    public MmgVector2() {
        vec = new double[]{0, 0};
    }
    
    /**
     * Constructor for this class sets its values based on the attributes of the
     * given argument.
     *
     * @param v     The MmgVector2 to base this class off of.
     */
    public MmgVector2(MmgVector2 v) {
        vec = new double[] { v.GetXDouble(), v.GetYDouble() };
    }

    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param v     The X, Y value of the vector.
     */
    public MmgVector2(double[] v) {
        vec = v;
    }

    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2(double x, double y) {
        vec = new double[]{x, y};
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2(double x) {
        vec = new double[]{(double) x, (double) x};
    }    
    
    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2(float x, float y) {
        vec = new double[]{(double) x, (double) y};
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2(float x) {
        vec = new double[]{(double) x, (double) x};
    }    
    
    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2(int x, int y) {
        vec = new double[]{(double) x, (double) y};
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2(int x) {
        vec = new double[]{(double) x, (double) x};
    }
    
    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    public MmgVector2 Clone() {
        return new MmgVector2(vec[0], vec[1]);
    }
    
    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    public void SetX(double x) {
        vec[0] = x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    public void SetY(double y) {
        vec[1] = y;
    }

    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    public void SetX(float x) {
        vec[0] = (double) x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    public void SetY(float y) {
        vec[1] = (double) y;
    }

    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    public void SetX(int x) {
        vec[0] = (double) x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    public void SetY(int y) {
        vec[1] = (double) y;
    }

    /**
     * Gets the X value of the vector.
     *
     * @return      The X value of the vector.
     */
    public int GetX() {
        return (int) vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    public int GetY() {
        return (int) vec[1];
    }

    /**
     * Gets the X value of the vector.
     *
     * @return      The X value of the vector.
     */
    public double GetXDouble() {
        return vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    public double GetYDouble() {
        return vec[1];
    }

    /**
     * Gets the X value of the vector.
     *
     * @return      The X value of the vector.
     */
    public float GetXFloat() {
        return (float) vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    public float GetYFloat() {
        return (float) vec[1];
    }

    /**
     * Gets the vector values.
     *
     * @return      The vector values.
     */
    public double[] GetVector() {
        return vec;
    }

    /**
     * Sets the vector values.
     *
     * @param v     The vector values.
     */
    public void SetVector(double[] v) {
        vec = v;
    }

    /**
     * Clones this object to a float based vector.
     *
     * @return      A float based clone.
     */
    public MmgVector2 CloneFloat() {
        return new MmgVector2(GetXFloat(), GetYFloat());
    }

    /**
     * Clones this object to a double based vector.
     *
     * @return      A double based clone.
     */
    public MmgVector2 CloneDouble() {
        return new MmgVector2(GetXDouble(), GetYDouble());
    }

    /**
     * Clones this object to an integer based vector.
     *
     * @return      An integer based clone.
     */
    public MmgVector2 CloneInt() {
        return new MmgVector2(GetX(), GetY());
    }    
    
    /**
     * Returns a new copy of the origin vector, (0, 0).
     *
     * @return      The origin vector.
     */
    public static MmgVector2 GetOriginVec() {
        return new MmgVector2(0, 0);
    }

    /**
     * Returns a new copy of the unit vector, (1, 1).
     *
     * @return      The unit vector.
     */
    public static MmgVector2 GetUnitVec() {
        return new MmgVector2(1, 1);
    }

    /**
     * Returns a string representation of the vector.
     *
     * @return      A string representation of the vector.
     */
    public String ApiToString() {
        return "MmgVector2: X: " + GetXDouble() + " Y:" + GetYDouble();
    }

    /**
     * A method that tests equality with another MmgVector2 object by comparing the coordinates.
     * 
     * @param obj     An MmgVector2 object to compare for equality.
     * @return      A boolean indicating if this object is equal to the comparison object.
     */
    public boolean ApiEquals(MmgVector2 obj) {
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