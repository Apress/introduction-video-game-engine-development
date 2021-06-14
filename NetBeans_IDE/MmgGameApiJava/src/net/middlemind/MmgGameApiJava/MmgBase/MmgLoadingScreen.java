package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that represents a game loading screen.
 * Created by Middlemind Games 08/29/2016
 * 
 * @author Victor G. Brusca
 */
public class MmgLoadingScreen extends MmgGameScreen {
    
    /**
     * A loading bar to use with this loading screen.
     */
    private MmgLoadingBar loadingBar;
    
    /**
     * A loading bar vertical offset value.
     */
    private float loadingBarOffsetBottom = 0.10f;

    /**
     * Constructor for this class.
     */
    public MmgLoadingScreen() {
        super();
    }    
    
    /**
     * Constructor for this class that sets the loading bar and the loading bar's
     * vertical offset.
     * 
     * @param LoadingBar    The loading bar to use.
     * @param lBarOff       The loading bar vertical offset.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgLoadingScreen(MmgLoadingBar LoadingBar, float lBarOff) {
        super();
        SetLoadingBar(LoadingBar, lBarOff);
    }

    /**
     * Constructor for this class that sets the value of local attributes based on the attributes
     * of the given argument.
     * 
     * @param obj   The MmgLoadingScreen to use to set local attributes.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgLoadingScreen(MmgLoadingScreen obj) {
        super();
        if(obj.GetLoadingBar() == null) {
            SetLoadingBar(obj.GetLoadingBar(), obj.GetLoadingBarOffsetBottom());
        } else {
            SetLoadingBar(obj.GetLoadingBar().CloneTyped(), obj.GetLoadingBarOffsetBottom());            
        }
                
        if(obj.GetBackground() == null) {
            SetBackground(obj.GetBackground());
        } else {
            SetBackground(obj.GetBackground().Clone());
        }
        
        if(obj.GetFooter() == null) {
            SetFooter(obj.GetFooter());            
        } else {
            SetFooter(obj.GetFooter().Clone());
        }
        
        SetHasParent(obj.GetHasParent());
                
        if(obj.GetHeader() == null) {
            SetHeader(obj.GetHeader());
        } else {
            SetHeader(obj.GetHeader().Clone());            
        }
        
        SetHeight(obj.GetHeight());
        SetIsVisible(obj.GetIsVisible());
        
        if(obj.GetLeftCursor() == null) {
            SetLeftCursor(obj.GetLeftCursor());
        } else {
            SetLeftCursor(obj.GetLeftCursor().Clone());
        }

        if(obj.GetMenu() == null) {
            SetMenu(obj.GetMenu());
        } else {
            SetMenu(obj.GetMenu().CloneTyped());
        }
        
        SetMenuCursorLeftOffsetX(obj.GetMenuCursorLeftOffsetX());
        SetMenuCursorLeftOffsetY(obj.GetMenuCursorLeftOffsetY());
        SetMenuCursorRightOffsetX(obj.GetMenuCursorRightOffsetX());
        SetMenuCursorRightOffsetY(obj.GetMenuCursorRightOffsetY());                
        SetMenuIdx(obj.GetMenuIdx());
        SetMenuOn(obj.GetMenuOn());
        SetMenuStart(obj.GetMenuStart());
        SetMenuStop(obj.GetMenuStop());
        
        if(obj.GetMessage() == null) {
            SetMessage(obj.GetMessage());
        } else {
            SetMessage(obj.GetMessage().Clone());
        }

        if(obj.GetMmgColor() == null) {
            SetMmgColor(obj.GetMmgColor());
        } else {
            SetMmgColor(obj.GetMmgColor().Clone());
        }
        
        SetName(obj.GetName());
        
        if(obj.GetObjects() == null) {
            SetObjects(obj.GetObjects());
        } else {
            SetObjects(obj.GetObjects().CloneTyped());
        }
        
        SetParent(obj.GetParent());
        
        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            SetPosition(obj.GetPosition().Clone());
        }
                        
        if(obj.GetRightCursor() == null) {
            SetRightCursor(obj.GetRightCursor());
        } else {
            SetRightCursor(obj.GetRightCursor().Clone());            
        }
            
        if(obj.GetLoadingBar() != null && obj.GetLoadingBar().GetLoadingBarBack() != null) {
            if(GetLoadingBar() != null && GetLoadingBar().GetLoadingBarBack() != null) {
                if(obj.GetLoadingBar().GetLoadingBarBack().GetPosition() != null) {
                    GetLoadingBar().GetLoadingBarBack().SetPosition(obj.GetLoadingBar().GetLoadingBarBack().GetPosition().Clone());
                }
            }
        }
        
        if(obj.GetLoadingBar() != null && obj.GetLoadingBar().GetLoadingBarFront() != null) {
            if(GetLoadingBar() != null && GetLoadingBar().GetLoadingBarFront() != null) {
                if(obj.GetLoadingBar().GetLoadingBarFront().GetPosition() != null) {
                    GetLoadingBar().GetLoadingBarFront().SetPosition(obj.GetLoadingBar().GetLoadingBarFront().GetPosition().Clone());
                }
            }
        }        
        
        SetWidth(obj.GetWidth());
    }
    
    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class. 
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgLoadingScreen(this);
    }

    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class. 
     */
    @Override
    public MmgLoadingScreen CloneTyped() {
        return new MmgLoadingScreen(this);
    }    
    
    /**
     * Gets the loading bar object of this class.
     * 
     * @return      A loading bar. 
     */
    public MmgLoadingBar GetLoadingBar() {
        return loadingBar;
    }

    /**
     * Get the loading bar's bottom offset.
     * 
     * @return      The loading bar's bottom offset. 
     */
    public float GetLoadingBarOffsetBottom() {
        return loadingBarOffsetBottom;
    }

    /**
     * Sets the loading bar and loading bar's bottom offset.
     * 
     * @param lb            The loading bar to use for this game screen.
     * @param lBarOff       The bottom offset to use for the loading bar.
     */
    public void SetLoadingBar(MmgLoadingBar lb, float lBarOff) {
        loadingBar = lb;
        loadingBarOffsetBottom = lBarOff;
        if(loadingBar != null) {
            MmgHelper.CenterHorAndBot(loadingBar);            
            loadingBar.GetPosition().SetY(GetPosition().GetY() + GetHeight() - loadingBar.GetHeight() - ((float) GetHeight() * (float) loadingBarOffsetBottom));
            loadingBar.GetLoadingBarBack().SetPosition(loadingBar.GetPosition());
            loadingBar.GetLoadingBarFront().SetPosition(loadingBar.GetPosition());
        }
    }

    /**
     * The base drawing class for this game screen.
     * 
     * @param p     The MmgPen object that is used to draw this screen. 
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if(isVisible == true && pause == false) {
            super.MmgDraw(p);
            
            if(loadingBar != null) {
                loadingBar.MmgDraw(p);
            }
        }
    }
    
    /**
     * Tests if this object is equal to another MmgLoadingScreen object.
     * 
     * @param obj   An MmgLoadingScreen object instance to compare to.
     * @return      Returns true if the objects are considered equal and false otherwise.
     */
    public boolean ApiEquals(MmgLoadingScreen obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
             
        /*
        if(!(super.Equals((MmgGameScreen)obj))) {
            MmgHelper.wr("MmgGameScreen is not equal!");
        }
        
        if(!(obj.GetLoadingBarOffsetBottom() == GetLoadingBarOffsetBottom())) {
            MmgHelper.wr("Offset Botton is not equal!");
        }
        
        if(!(((obj.GetLoadingBar() == null && GetLoadingBar() == null) || (obj.GetLoadingBar() != null && GetLoadingBar() != null && obj.GetLoadingBar().Equals(GetLoadingBar()))))) {
            MmgHelper.wr("loading bar is not equal!");
        }
        */
        
        boolean ret = false;
        if (
            super.ApiEquals((MmgGameScreen)obj)
            && obj.GetLoadingBarOffsetBottom() == GetLoadingBarOffsetBottom()
            && ((obj.GetLoadingBar() == null && GetLoadingBar() == null) || (obj.GetLoadingBar() != null && GetLoadingBar() != null && obj.GetLoadingBar().ApiEquals(GetLoadingBar()))) 
        ) {
            ret = true;
        }
        return ret;        
    }
}