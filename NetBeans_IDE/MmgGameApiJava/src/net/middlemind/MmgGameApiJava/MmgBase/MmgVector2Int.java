package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that represents a two dimensional integer vector.
 * Created by Middlemind Games 01/06/2005
 *
 * @author Victor G. Brusca
 */
public class MmgVector2Int extends MmgVector2 {

    /**
     * The vector data.
     */
    private int[] vec;

    /**
     * Constructor for this class.
     */
    public MmgVector2Int() {
        vec = new int[]{0, 0};
    }
    
    /**
     * Constructor for this class sets its values based on the attributes of the
     * given argument.
     *
     * @param v     The MmgVector2Int to base this class off of.
     */
    public MmgVector2Int(MmgVector2Int v) {
        vec = new int[] { v.GetX(), v.GetY() };
    }

    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param v     The X, Y value of the vector.
     */
    public MmgVector2Int(int[] v) {
        vec = v;
    }

    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2Int(int x, int y) {
        vec = new int[]{x, y};
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2Int(int x) {
        vec = new int[]{x, x};
    }    
    
    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param v     The X, Y value of the vector.
     */
    public MmgVector2Int(double[] v) {
        vec = new int[]{(int)v[0], (int)v[1]};
    }

    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2Int(double x, double y) {
        vec = new int[]{(int)x, (int)y};
    }

    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2Int(double x) {
        vec = new int[]{(int) x, (int) x};
    }    
    
    /**
     * Constructor that sets the X, Y value of the vector.
     *
     * @param x     The X value of the vector.
     * @param y     The Y value of the vector.
     */
    public MmgVector2Int(float x, float y) {
        vec = new int[]{(int) x, (int) y};
    }
    
    /**
     * Constructor that sets the X, Y value based on one argument.
     * 
     * @param x     The X value used to set both the X, Y coordinate.
     */
    public MmgVector2Int(float x) {
        vec = new int[]{(int) x, (int) x};
    }    
    
    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    public MmgVector2Int Clone() {
        return new MmgVector2Int(vec[0], vec[1]);
    }
    
    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    @Override
    public void SetX(double x) {
        vec[0] = (int)x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    @Override
    public void SetY(double y) {
        vec[1] = (int)y;
    }

    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    @Override
    public void SetX(float x) {
        vec[0] = (int) x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    @Override
    public void SetY(float y) {
        vec[1] = (int) y;
    }

    /**
     * Sets the X value of the vector.
     *
     * @param x     The X value of the vector.
     */
    @Override
    public void SetX(int x) {
        vec[0] = x;
    }

    /**
     * Sets the Y value of the vector.
     *
     * @param y     The Y value of the vector.
     */
    @Override
    public void SetY(int y) {
        vec[1] = y;
    }

    /**
     * Gets the X value of the vector.
     *
     * @return      The X value of the vector.
     */
    @Override
    public int GetX() {
        return vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    @Override
    public int GetY() {
        return vec[1];
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
        return (float) vec[0];
    }

    /**
     * Gets the Y value of the vector.
     *
     * @return      The Y value of the vector.
     */
    @Override
    public float GetYFloat() {
        return (float) vec[1];
    }

    /**
     * Gets the vector values.
     *
     * @return      The vector values.
     */
    public int[] GetVectorInt() {
        return new int[] {GetX(), GetY()};
    }

    /**
     * Sets the vector values.
     *
     * @param v     The vector values.
     */
    public void SetVectorInt(int[] v) {
        SetX(v[0]);
        SetY(v[1]);
    }
    
    /**
     * Sets the vector values from a double array.
     * 
     * @param d     An array of vector coordinates.
     */
    @Override
    public void SetVector(double[] d) {
        SetX((int)d[0]);
        SetY((int)d[0]);        
    }
    
    /**
     * Gets the vector values as a double array.
     * 
     * @return      An array of vector coordinates.
     */
    @Override
    public double[] GetVector() {
        return new double[] { GetXDouble(), GetYDouble() };
    }
    
    /**
     * Clones this object to a float based vector.
     *
     * @return      A float based clone.
     */
    @Override
    public MmgVector2Int CloneFloat() {
        return new MmgVector2Int(GetXFloat(), GetYFloat());
    }

    /**
     * Clones this object to a double based vector.
     *
     * @return      A double based clone.
     */
    @Override
    public MmgVector2Int CloneDouble() {
        return new MmgVector2Int(GetXDouble(), GetYDouble());
    }

    /**
     * Clones this object to an integer based vector.
     *
     * @return      An integer based clone.
     */
    @Override
    public MmgVector2Int CloneInt() {
        return new MmgVector2Int(GetX(), GetY());
    }    
    
    /**
     * Returns a new copy of the origin vector, (0, 0).
     *
     * @return      The origin vector.
     */
    public static MmgVector2Int GetOriginVec() {
        return new MmgVector2Int(0, 0);
    }

    /**
     * Returns a new copy of the unit vector, (1, 1).
     *
     * @return      The unit vector.
     */
    public static MmgVector2Int GetUnitVec() {
        return new MmgVector2Int(1, 1);
    }

    /**
     * Returns a string representation of the vector.
     *
     * @return      A string representation of the vector.
     */
    @Override
    public String ApiToString() {
        return "MmgVector2Int: X: " + GetXDouble() + " Y:" + GetYDouble();
    }

    /**
     * A method that tests equality with another MmgVector2 object by comparing the coordinates.
     * 
     * @param obj     An MmgVector2 object to compare for equality.
     * @return      A boolean indicating if this object is equal to the comparison object.
     */
    @Override
    public boolean ApiEquals(MmgVector2 obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }

        boolean ret = false;
        if (obj.GetX() == GetX() 
            && obj.GetY() == GetY()
        ) {
            ret = true;
        }
        return ret;
    }    
    
    /**
     * A method that tests equality with another MmgVector2 object by comparing the coordinates.
     * 
     * @param obj     An MmgVector2 object to compare for equality.
     * @return      A boolean indicating if this object is equal to the comparison object.
     */
    public boolean ApiEquals(MmgVector2Int obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }

        boolean ret = false;
        if (obj.GetX() == GetX() 
            && obj.GetY() == GetY()
        ) {
            ret = true;
        }
        return ret;
    }
}