package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that creates a loading bar object.
 * Created by Middlemind Games 08/29/2016
 * 
 * @author Victor G. Brusca
 */
public class MmgLoadingBar extends MmgObj {
    
    /**
     * The bitmap image of the back of the loading bar.
     */
    private MmgBmp loadingBarBack;
    
    /**
     * The bitmap image of the front of the loading bar.
     */
    private MmgBmp loadingBarFront;
    
    /**
     * The X padding to use when drawing the loading bar front.
     */
    private int xPadding;
    
    /**
     * The Y padding to use when drawing the loading bar front.
     */
    private int yPadding;
    
    /**
     * The fill amount of the loading bar.
     */
    private float fillAmt;
    
    /**
     * The fill height of the loading bar.
     */
    private int fillHeight;
    
    /**
     * The fill width of the loading bar. 
     */
    private int fillWidth;

    /**
     * Constructor for this class.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgLoadingBar() {
        super();
        SetLoadingBarBack(null);
        SetLoadingBarFront(null);
        SetPaddingX(0);
        SetPaddingY(0);
        SetFillHeight(MmgHelper.ScaleValue(10));
        SetFillWidth(MmgHelper.ScaleValue(100));
    }

    /**
     * Constructor for this loading bar that sets all the class attributes based
     * on the given argument.
     * 
     * @param obj       The class to use to set all the attributes of this class.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgLoadingBar(MmgLoadingBar obj) {
        super();
        if (obj.GetLoadingBarBack() != null) {
            SetLoadingBarBack((MmgBmp) obj.GetLoadingBarBack().Clone());
        } else {
            SetLoadingBarBack(obj.GetLoadingBarBack());
        }

        if (obj.GetLoadingBarFront() != null) {
            SetLoadingBarFront((MmgBmp) obj.GetLoadingBarFront().Clone());
        } else {
            SetLoadingBarFront(obj.GetLoadingBarFront());
        }

        SetPaddingX(obj.GetPaddingX());
        SetPaddingY(obj.GetPaddingY());

        if (obj.GetPosition() != null) {
            SetPosition(obj.GetPosition().Clone());
        } else {
            SetPosition(obj.GetPosition());
        }

        SetWidth(obj.GetWidth());
        SetHeight(obj.GetHeight());
        SetFillHeight(obj.GetFillHeight());
        SetFillWidth(obj.GetFillWidth());
        
        if(obj.GetMmgColor() == null) {
            SetMmgColor(obj.GetMmgColor());
        } else {
            SetMmgColor(obj.GetMmgColor().Clone());
        }       
    }

    /**
     * Constructor that sets the front and back loading bar images.
     * 
     * @param LoadingBarBack        The back loading bar image.
     * @param LoadingBarFront       The front loading bar image.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgLoadingBar(MmgBmp LoadingBarBack, MmgBmp LoadingBarFront) {
        super();
        SetLoadingBarBack(LoadingBarBack);
        SetLoadingBarFront(LoadingBarFront);
        SetPaddingX(0);
        SetPaddingY(0);
        SetPosition(new MmgVector2(0, 0));

        if (loadingBarFront != null) {
            SetWidth(loadingBarFront.GetWidth());
            SetHeight(loadingBarFront.GetHeight());
        } else {
            SetWidth(MmgHelper.ScaleValue(100));
            SetHeight(MmgHelper.ScaleValue(50));
        }

        SetFillHeight(GetHeight());
        SetFillWidth(GetWidth());
        SetIsVisible(true);
        SetMmgColor(MmgColor.GetWhite());
    }

    /**
     * Sets the padding X value.
     * 
     * @param px    The padding X value. 
     */
    public void SetPaddingX(int px) {
        xPadding = px;
    }

    /**
     * Gets the padding X value.
     * 
     * @return      The padding X value. 
     */
    public int GetPaddingX() {
        return xPadding;
    }

    /**
     * Sets the padding Y value.
     * 
     * @param py    The padding Y value. 
     */
    public void SetPaddingY(int py) {
        yPadding = py;
    }

    /**
     * Gets the padding Y value.
     * 
     * @return      The padding Y value. 
     */
    public int GetPaddingY() {
        return yPadding;
    }

    /**
     * Gets the fill height of the loading bar.
     * 
     * @return      The fill height of the loading bar. 
     */
    public int GetFillHeight() {
        return fillHeight;
    }

    /**
     * Sets the fill height of the loading bar.
     * 
     * @param h     The fill height of the loading bar.
     */
    public void SetFillHeight(int h) {
        fillHeight = h;
    }

    /**
     * Gets the fill width of the loading bar.
     * 
     * @return      The fill width of the loading bar. 
     */
    public int GetFillWidth() {
        return fillWidth;
    }

    /**
     * The position to use to draw this object.
     * 
     * @param pos       The position to this object to.
     */
    @Override
    public void SetPosition(MmgVector2 pos) {
        super.SetPosition(pos);
        loadingBarFront.SetPosition(pos);
        loadingBarBack.SetPosition(pos);
    }
    
    /**
     * Sets the position of this object and resets the label, value pair positioning.
     * 
     * @param x     The X coordinate to set in the position.
     * @param y     The Y coordinate to set in the position.
     */
    @Override
    public void SetPosition(int x, int y) {
        super.SetPosition(x, y);
        loadingBarFront.SetPosition(x, y);
        loadingBarBack.SetPosition(x, y);
    }    
    
    /**
     * The X coordinate to use to draw this object.
     * 
     * @param inX       The X coordinate to use to draw this object.
     */
    @Override
    public void SetX(int inX) {
        super.SetX(inX);
        loadingBarFront.SetX(inX);
        loadingBarBack.SetX(inX);
    }
    
    /**
     * The Y coordinate to use to draw this object.
     * 
     * @param inY       The Y coordinate to use to draw this object.
     */    
    @Override
    public void SetY(int inY) {
        super.SetY(inY);
        loadingBarFront.SetY(inY);
        loadingBarBack.SetY(inY);
    }        
    
    /**
     * Sets the fill width of the loading bar.
     * 
     * @param w     The fill width of the loading bar.
     */
    public void SetFillWidth(int w) {
        fillWidth = w;
    }

    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class. 
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgLoadingBar(this);
    }

    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class. 
     */
    @Override
    public MmgLoadingBar CloneTyped() {
        return new MmgLoadingBar(this);
    }    
    
    /**
     * Gets the loading bar back image.
     * 
     * @return      The loading bar back image.
     */
    public MmgBmp GetLoadingBarBack() {
        return loadingBarBack;
    }

    /**
     * Sets the loading bar back image.
     * 
     * @param b     The loading bar back image.
     */
    public void SetLoadingBarBack(MmgBmp b) {
        loadingBarBack = b;
        if(loadingBarBack != null) {
            loadingBarBack.SetScaling(null);
        }
    }

    /**
     * Gets the loading bar front image.
     * 
     * @return      The loading bar front image.
     */
    public MmgBmp GetLoadingBarFront() {
        return loadingBarFront;
    }

    /**
     * Sets the loading bar front image.
     * 
     * @param f     The loading bar front image.
     */
    public void SetLoadingBarFront(MmgBmp f) {
        loadingBarFront = f;
    }

    /**
     * Sets the loading bar fill amount, 0.0 - 1.0.
     * 
     * @param f     The decimal fill amount.
     */
    public void SetFillAmt(float f) {
        fillAmt = f;
    }

    /**
     * Gets the loading bar fill amount.
     * 
     * @return      The decimal fill amount.
     */
    public float GetFillAmt() {
        return fillAmt;
    }

    /**
     * Draws the current object using the MmgPen object.
     * 
     * @param p     The MmgPen object that draws this object. 
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if(isVisible == true) {
            if(loadingBarBack != null) {
                loadingBarBack.SetSrcRect(new MmgRect(MmgVector2.GetOriginVec(), loadingBarBack.GetWidth(), loadingBarBack.GetHeight()));
                loadingBarBack.SetDstRect(new MmgRect(new MmgVector2(GetPosition().GetX() + GetPaddingX(), GetPosition().GetY() + GetPaddingY()), (int) ((float) (GetFillWidth() - GetPaddingX()) * fillAmt), GetFillHeight() - GetPaddingY()));
                loadingBarBack.MmgDraw(p);
            }

            if(loadingBarFront != null) {
                loadingBarFront.MmgDraw(p);
            }
        }
    }
    
    /**
     * A class method that tests for equality based on the font and text of the
     * comparison object.
     * 
     * @param obj     The MmgFont object to compare.
     * @return      A boolean indicating if the object instance is equal to the argument object instance. 
     */
    public boolean ApiEquals(MmgLoadingBar obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        /*
        if(!(super.Equals((MmgObj)obj))) {
            MmgHelper.wr("mmg loading bar: mmgobj is not equals!");
        }
        
        if(!(obj.GetFillHeight() == GetFillHeight())) {
            MmgHelper.wr("mmg loading bar: fill height is not equals!");
        }
        
        if(!(obj.GetFillWidth() == GetFillWidth())) {
            MmgHelper.wr("mmg loading bar: fill width is not equals!");            
        }
        
        if(!(((obj.GetLoadingBarBack() == null && GetLoadingBarBack() == null) || (obj.GetLoadingBarBack() != null && GetLoadingBarBack() != null && obj.GetLoadingBarBack().Equals(GetLoadingBarBack()))))) {
            MmgHelper.wr("mmg loading bar: loading bar back is not equals!");                        
        }
        
        if(!(((obj.GetLoadingBarFront() == null && GetLoadingBarFront() == null) || (obj.GetLoadingBarFront() != null && GetLoadingBarFront() != null && obj.GetLoadingBarFront().Equals(GetLoadingBarFront()))))) {
            MmgHelper.wr("mmg loading bar: loading bar front is not equals!");                        
        }        
        */
        
        boolean ret = false;
        if (
            super.ApiEquals((MmgObj)obj) 
            && obj.GetFillHeight() == GetFillHeight()
            && obj.GetFillWidth() == GetFillWidth()
            && ((obj.GetLoadingBarBack() == null && GetLoadingBarBack() == null) || (obj.GetLoadingBarBack() != null && GetLoadingBarBack() != null && obj.GetLoadingBarBack().ApiEquals(GetLoadingBarBack()))) 
            && ((obj.GetLoadingBarFront() == null && GetLoadingBarFront() == null) || (obj.GetLoadingBarFront() != null && GetLoadingBarFront() != null && obj.GetLoadingBarFront().ApiEquals(GetLoadingBarFront())))
            && obj.GetPaddingX() == GetPaddingX()
            && obj.GetPaddingY() == GetPaddingY()
        ) {
            ret = true;
        }
        return ret;
    }    
}