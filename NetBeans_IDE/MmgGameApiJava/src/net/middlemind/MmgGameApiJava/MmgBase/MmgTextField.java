package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * A class used to display a text field for getting text values from the the user.
 * Created by Middlemind Games 04/9/2020
 * 
 * @author Victor G. Brusca
 */
public class MmgTextField extends MmgObj {
    
    /**
     * The MmgBmp object to use with the Mmg9Slice object as the background for this text field.
     */
    private MmgBmp bgroundSrc;
    
    /**
     * The object to use as the background for this text field.
     */
    private Mmg9Slice bground;
    
    /**
     * The MmgFont object to use for rendering text on this text field.
     */
    private MmgFont font;
    
    /**
     * The maximum length of text to allow.
     */
    private int maxLength;
    
    /**
     * A boolean flag indicating if the maximum length check is on.
     */
    private boolean maxLengthOn;
    
    /**
     * The String that holds the actual text for this text field.
     */
    private String textFieldString = "";
    
    /**
     * The number of characters to display in this text field, should be adjusted based on the text field's width.
     */
    private int displayChars;
        
    /**
     * An integer value indicating how tall the font is, not currently used in display calculations.
     */
    private int fontHeight;
    
    /**
     * An integer value used in slight positioning of the font text.
     */
    private int padding;
    
    /**
     * A private class field used to track the cursor blink start.
     */
    private long cursorBlinkStart;
    
    /**
     * A boolean flag indicating if the cursor is currently on.
     */
    private boolean cursorBlinkOn;
    
    /**
     * A private temporary value used in timing calculations.
     */
    private long tmpL;
    
    /**
     * A boolean flag indicating if this object needs to do any work in the MmgUpdate method.
     */
    private boolean isDirty;
        
    /**
     * An MmgEvent to fire when the max length error has occurred, needs to have its event handler set.
     */
    private MmgEvent errorMaxLength = new MmgEvent(null, "error_max_length", MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_TYPE, null, null);
    
    /**
     * A static class field that control how the background MmgBmp is sliced using the 9 slice technique.
     */
    public static int TEXT_FIELD_9_SLICE_OFFSET = MmgHelper.ScaleValue(16);
    
    /**
     * A static field that determines what character is used for the cursor.
     */
    public static String TEXT_FIELD_CURSOR = "_";
    
    /**
     * A static field that determines how quickly the cursor blinks.
     */
    public static long TEXT_FIELD_CURSOR_BLINK_RATE_MS = 350l;
        
    /**
     * A static integer used as the max length error event id.
     */
    public static int TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID = 1;
    
    /**
     * A static integer used as the max length error event type.
     */
    public static int TEXT_FIELD_MAX_LENGTH_ERROR_TYPE = 0;    
    
    /**
     * A static integer used to determine the max number or characters before a max length error event is fired.
     */
    public static int DEFAULT_MAX_LENGTH = 20;
    
    /**
     * The default constructor that sets all the basic needs for this class to display properly.
     * 
     * @param BgroundSrc        The MmgBmp object to use as the source image to be 9 sliced and resized as the background image.
     * @param Font              The MmgFont object used to render the text.
     * @param Width             The width of this object and the width used to resize the BgroundSrc MmgObj.
     * @param Height            The height of this object and the height used to resize the BgroundSrc MmgObj.
     * @param Padding           The padding value to use in slight font positioning calculations.
     * @param DisplayChars      The number of characters to display in one visible string.
     */
    public MmgTextField(MmgBmp BgroundSrc, MmgFont Font, int Width, int Height, int Padding, int DisplayChars) {
        super();
        bgroundSrc = BgroundSrc;
        font = Font;
        padding = Padding;
        displayChars = DisplayChars;
        SetWidth(Width);
        SetHeight(Height);
        SetMaxLength(DEFAULT_MAX_LENGTH);
        font.SetText("");
        Prep();
    }

    /**
     * A constructor that creates a new instance of this class by cloning values from another clas instance.
     * 
     * @param obj       The class used to create a new MmgTextField from.
     */
    public MmgTextField(MmgTextField obj) {
        super();
        if(obj.GetBgroundSrc() == null) {
            SetBgroundSrc(obj.GetBgroundSrc());
        } else {
            SetBgroundSrc(obj.GetBgroundSrc().CloneTyped());
        }
        
        if(obj.GetFont() == null) {
            SetFont(obj.GetFont());
        } else {
            SetFont(obj.GetFont().CloneTyped());            
        }
        
        SetHeight(obj.GetHeight());
        SetWidth(obj.GetWidth());
        SetPadding(obj.GetPadding());
        SetDisplayChars(obj.GetDisplayChars());
        SetMaxLength(obj.GetMaxLength());
        SetMaxLengthOn(obj.GetMaxLengthOn());  
        
        Prep();
        
        if(obj.GetBground() == null) {
            SetBground(obj.GetBground());
        } else {
            SetBground(obj.GetBground().CloneTyped());
        }
        
        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            SetPosition(obj.GetPosition().Clone());
        }
        
        SetFontHeight(obj.GetFontHeight());
        SetTextFieldString(obj.GetTextFieldString());        
    }
    
    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class.
     */
    @Override    
    public MmgObj Clone() {
        return (MmgObj) new MmgTextField(this);
    }
    
    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override     
    public MmgTextField CloneTyped() {
        return new MmgTextField(this);
    }
    
    /**
     * A method that prepares the class for rendering to the screen.
     */
    public void Prep() {
        cursorBlinkStart = System.currentTimeMillis();
        fontHeight = font.GetHeight();
        textFieldString = "";
        bground = new Mmg9Slice(TEXT_FIELD_9_SLICE_OFFSET, bgroundSrc, GetWidth(), GetHeight());        
    }

    /**
     * Gets the max length error event.
     * 
     * @return      The max length error event.
     */
    public MmgEvent GetErrorMaxLength() {
        return errorMaxLength;
    }

    /**
     * Sets the max length error event.
     * 
     * @param e     The max length error event.
     */
    public void SetErrorMaxLength(MmgEvent e) {
        errorMaxLength = e;
    }
    
    /**
     * Gets the MmgObj used as the basis for the 9 sliced background image for this object.
     * 
     * @return      The MmgObj used as the basis for the 9 sliced background.
     */
    public MmgBmp GetBgroundSrc() {
        return bgroundSrc;
    }

    /**
     * Sets the MmgObj used as the basis for the 9 sliced background image for this object.
     * 
     * @param bg    The MmgObj used as the basis for the 9 sliced background.
     */
    public void SetBgroundSrc(MmgBmp bg) {
        bgroundSrc = bg;
    }

    /**
     * Gets the Mmg9Slice background object.
     * 
     * @return      The Mmg9Slice background object.
     */
    public Mmg9Slice GetBground() {
        return bground;
    }

    /**
     * Sets the Mmg9Slice background object.
     * 
     * @param bg    The Mmg9Slice background object.
     */
    public void SetBground(Mmg9Slice bg) {
        bground = bg;
    }

    /**
     * Get the MmgFont used to render text.
     * 
     * @return      The MmgFont used to render text.
     */
    public MmgFont GetFont() {
        return font;
    }

    /**
     * Sets the MmgFont used to render text.
     * 
     * @param f     The MmgFont used to render text.
     */
    public void SetFont(MmgFont f) {
        font = f;
    }

    /**
     * Gets the max length of characters allowed if the max length limitation is on.
     * 
     * @return      The max length of characters allowed if the max length limitation is on.
     */
    public int GetMaxLength() {
        return maxLength;
    }

    /**
     * Sets the max length of characters allowed if the max length limitation is on.
     * 
     * @param i     The max length of characters allowed if the max length limitation is on.
     */
    public void SetMaxLength(int i) {
        maxLength = i;
    }

    /**
     * Gets the boolean flag indicating if the max length limitation is on.
     * 
     * @return      A boolean flag indicating if the max length limitation is on.
     */
    public boolean GetMaxLengthOn() {
        return maxLengthOn;
    }

    /**
     * Sets the boolean flag indicating if the max length limitation is on.
     * 
     * @param b     A boolean flag indicating if the max length limitation is on.
     */
    public void SetMaxLengthOn(boolean b) {
        maxLengthOn = b;
    }

    /**
     * Gets the text field string stored by this object.
     * 
     * @return      The text field string stored by this object.
     */
    public String GetTextFieldString() {
        return textFieldString;
    }

    /**
     * Sets the text field string stored by this object.
     * 
     * @param str   The text field string stored by this object.
     */
    public void SetTextFieldString(String str) {
        textFieldString = str;
    }

    /**
     * Gets the maximum number of characters to display in the text field.
     * 
     * @return      The maximum number of characters to display in the text field.
     */
    public int GetDisplayChars() {
        return displayChars;
    }

    /**
     * Sets the maximum number of characters to display in the text field.
     * 
     * @param i     The maximum number of characters to display in the text field.
     */
    public void SetDisplayChars(int i) {
        displayChars = i;
    }
    
    /**
     * Gets the height of the MmgFont used to render text.
     * 
     * @return      The height of the MmgFont used to render text.
     */
    public int GetFontHeight() {
        return fontHeight;
    }

    /**
     * Sets the height of the MmgFont used to render text.
     * 
     * @param i     The height of the MmgFont used to render text.
     */
    public void SetFontHeight(int i) {
        fontHeight = i;
    }

    /**
     * Gets the padding used in positioning the MmgFont text in the text field.
     * 
     * @return      The padding used in positioning the MmgFont text in the text field.
     */
    public int GetPadding() {
        return padding;
    }

    /**
     * Sets the padding used in positioning the MmgFont text in the text field.
     * 
     * @param i     The padding used in positioning the MmgFont text in the text field.
     */
    public void SetPadding(int i) {
        padding = i;
    }

    /**
     * Gets a boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call.
     * 
     * @return      A boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call. 
     */
    public boolean GetIsDirty() {
        return isDirty;
    }

    /**
     * Sets a boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call.
     * 
     * @param b     A boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call.
     */
    public void SetIsDirty(boolean b) {
        isDirty = b;
    }
    
    /**
     * Sets the position of the text field and MmgFont text with slight adjustments to the font based on the value of the padding class field.
     * 
     * @param pos   The position of the text field.
     */
    @Override
    public void SetPosition(MmgVector2 pos) {
        super.SetPosition(pos);
        bground.SetPosition(new MmgVector2(pos.GetX(), pos.GetY()));
        font.SetPosition(new MmgVector2(pos.GetX() + padding, pos.GetY() + GetHeight() - padding));
    }
    
    /**
     * Sets the position of the text field and MmgFont text with slight adjustments to the font based on the value of the padding class field.
     * 
     * @param x     The X position to use when setting the position of the text field.
     * @param y     The Y position to use when setting the position of the text field.
     */
    @Override
    public void SetPosition(int x, int y) {
        super.SetPosition(x, y);
        bground.SetPosition(x, y);
        font.SetPosition(new MmgVector2(x + padding, y + GetHeight() - padding));
    }
      
    /**
     * A method for handling intake of characters to append to the text field string value.
     * 
     * @param c         A character to append to the text field string value.
     * @param code      A character code used to find non-ASCII characters if need be.
     * @return          A boolean flag indicating if any work was done.
     */
    public boolean ProcessKeyClick(char c, int code) {
        if(maxLengthOn) {
            if(textFieldString.length() + 1 >= maxLength) {
                if(errorMaxLength != null) {
                    errorMaxLength.Fire();
                }
                return true;
            }
        }
        
        textFieldString += c;
        isDirty = true;        
        return true;
    }    
    
    /**
     * A method for handling the deletion of characters from the text field.
     */
    public void DeleteChar() {
        if(textFieldString.length() > 0) {
            textFieldString = textFieldString.substring(0, textFieldString.length() - 1);
        }
        isDirty = true;
    }
    
    /**
     * Sets the X position of the text field.
     * 
     * @param x    The X position to use when setting the position of the text field. 
     */
    @Override
    public void SetX(int x) {
        super.SetX(x);
        bground.SetX(x);
        font.SetX(x + padding);
    }
    
    /**
     * Sets the Y position of the text field.
     * 
     * @param y     The Y position to use when setting the position of the text field. 
     */
    @Override
    public void SetY(int y) {
        super.SetY(y);
        bground.SetY(y);
        font.SetY(y + GetHeight() - padding);
    }    
    
    /**
     * The MmgUpdate method that handles updating any object fields during the update calls.
     * 
     * @param updateTick            The index of the update call.
     * @param currentTimeMs         The current time in milliseconds that the update was called.
     * @param msSinceLastFrame      The difference in milliseconds between this update call and the previous update call.
     * @return                      A boolean indicating if the update call was handled.
     */
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        if(isVisible == true) {            
            tmpL = System.currentTimeMillis();
            if(tmpL - cursorBlinkStart >= MmgTextField.TEXT_FIELD_CURSOR_BLINK_RATE_MS) {
                isDirty = true;
                cursorBlinkOn = !cursorBlinkOn;
                cursorBlinkStart = tmpL;
            }
            
            if(isDirty) {
                if(textFieldString.length() > displayChars) {
                    font.SetText(textFieldString.substring(textFieldString.length() - displayChars));
                } else {
                    font.SetText(textFieldString); 
                }

                if(cursorBlinkOn) {
                    font.SetText(font.GetText() + TEXT_FIELD_CURSOR);
                }                
                
                isDirty = false;
            }
            
            return true;
        }
        
        return false;
    }
    
    /**
     * The base drawing method for this object.
     *
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            bground.MmgDraw(p);
            font.MmgDraw(p);
        }
    }

    /**
     * Sets the event handler for events.
     * 
     * @param h     The event handler for events. 
     */
    public void SetEventHandler(MmgEventHandler h) {
        errorMaxLength.SetTargetEventHandler(h);
    }
    
    /**
     * A method used to check the equality of this MmgTextField when compared to another MmgTextField.
     * Compares object fields to determine equality.
     * 
     * @param obj     The MmgTextField object to compare to.
     * @return      A boolean indicating if the two objects are equal or not.
     */   
    public boolean ApiEquals(MmgTextField obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        /*
        if(!(super.Equals((MmgObj)obj))) {
            MmgHelper.wr("MmgTextField MmgObj not equals!");
        }
        
        if(!(((obj.GetBground() == null && GetBground() == null) || (obj.GetBground() != null && GetBground() != null && obj.GetBground().Equals(GetBground()))))) {
            MmgHelper.wr("MmgTextField Bground not equals!");
        }        
        
        if(!(((obj.GetBgroundSrc() == null && GetBgroundSrc() == null) || (obj.GetBgroundSrc() != null && GetBgroundSrc() != null && obj.GetBgroundSrc().Equals(GetBgroundSrc()))))) {
            MmgHelper.wr("MmgTextField BgroundSrc not equals!");
        }        
        
        if(!(obj.GetDisplayChars() == GetDisplayChars())) {
            MmgHelper.wr("MmgTextField DisplayChars not equals!");
        }        

        if(!(obj.GetFontHeight() == GetFontHeight())) {
            MmgHelper.wr("MmgTextField FontHeight not equals!");
        }                
        
        if(!(obj.GetMaxLength() == GetMaxLength())) {
            MmgHelper.wr("MmgTextField MaxLength not equals!");
        }
        
        if(!(obj.GetMaxLengthOn() == GetMaxLengthOn())) {
            MmgHelper.wr("MmgTextField MaxLengthOn not equals!");
        }
        
        if(!(obj.GetPadding() == GetPadding())) {
            MmgHelper.wr("MmgTextField Padding not equals!");
        }
        
        if(!(((obj.GetTextFieldString() == null && GetTextFieldString() == null) || (obj.GetTextFieldString() != null && GetTextFieldString() != null && obj.GetTextFieldString().equals(GetTextFieldString()))))) {
            MmgHelper.wr("MmgTextField TextFieldString not equals! " + obj.GetTextFieldString() + ", " + GetTextFieldString());    
        }
        */
                
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
            && ((obj.GetBground() == null && GetBground() == null) || (obj.GetBground() != null && GetBground() != null && obj.GetBground().ApiEquals(GetBground())))
            && ((obj.GetBgroundSrc() == null && GetBgroundSrc() == null) || (obj.GetBgroundSrc() != null && GetBgroundSrc() != null && obj.GetBgroundSrc().ApiEquals(GetBgroundSrc())))
            && obj.GetDisplayChars() == GetDisplayChars()
            && ((obj.GetFont() == null && GetFont() == null) || (obj.GetFont() != null && GetFont() != null && obj.GetFont().ApiEquals(GetFont())))
            && obj.GetFontHeight() == GetFontHeight()
            && obj.GetMaxLength() == GetMaxLength()
            && obj.GetMaxLengthOn() == GetMaxLengthOn()
            && obj.GetPadding() == GetPadding()
            && ((obj.GetTextFieldString() == null && GetTextFieldString() == null) || (obj.GetTextFieldString() != null && GetTextFieldString() != null && obj.GetTextFieldString().equals(GetTextFieldString())))
        ) {
            ret = true;
        }
        return ret;        
    }
}