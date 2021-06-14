using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class used to display a text field for getting text values from the the user.
    /// Created by Middlemind Games 04/9/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgTextField : MmgObj
    {
        /// <summary>
        /// The MmgBmp object to use with the Mmg9Slice object as the background for this text field.
        /// </summary>
        private MmgBmp bgroundSrc;

        /// <summary>
        /// The object to use as the background for this text field.
        /// </summary>
        private Mmg9Slice bground;

        /// <summary>
        /// The MmgFont object to use for rendering text on this text field.
        /// </summary>
        private MmgFont font;

        /// <summary>
        /// The maximum length of text to allow.
        /// </summary>
        private int maxLength;

        /// <summary>
        /// A boolean flag indicating if the maximum length check is on.
        /// </summary>
        private bool maxLengthOn;

        /// <summary>
        /// The String that holds the actual text for this text field.
        /// </summary>
        private string textFieldString = "";

        /// <summary>
        /// The number of characters to display in this text field, should be adjusted based on the text field's width.
        /// </summary>
        private int displayChars;

        /// <summary>
        /// An integer value indicating how tall the font is, not currently used in display calculations.
        /// </summary>
        private int fontHeight;

        /// <summary>
        /// An integer value used in slight positioning of the font text.
        /// </summary>
        private int padding;

        /// <summary>
        /// A private class field used to track the cursor blink start.
        /// </summary>
        private long cursorBlinkStart;

        /// <summary>
        /// A boolean flag indicating if the cursor is currently on.
        /// </summary>
        private bool cursorBlinkOn;

        /// <summary>
        /// A private temporary value used in timing calculations.
        /// </summary>
        private long tmpL;

        /// <summary>
        /// A boolean flag indicating if this object needs to do any work in the MmgUpdate method.
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// An MmgEvent to fire when the max length error has occurred, needs to have its event handler set.
        /// </summary>
        private MmgEvent errorMaxLength = new MmgEvent(null, "error_max_length", MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_TYPE, null, null);

        /// <summary>
        /// A static class field that control how the background MmgBmp is sliced using the 9 slice technique.
        /// </summary>
        public static int TEXT_FIELD_9_SLICE_OFFSET = MmgHelper.ScaleValue(8);

        /// <summary>
        /// A static field that determines what character is used for the cursor.
        /// </summary>
        public static string TEXT_FIELD_CURSOR = "_";

        /// <summary>
        /// A static field that determines how quickly the cursor blinks.
        /// </summary>
        public static long TEXT_FIELD_CURSOR_BLINK_RATE_MS = 350L;

        /// <summary>
        /// A static integer used as the max length error event id.
        /// </summary>
        public static int TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID = 1;

        /// <summary>
        /// A static integer used as the max length error event type.
        /// </summary>
        public static int TEXT_FIELD_MAX_LENGTH_ERROR_TYPE = 0;

        /// <summary>
        /// A static integer used to determine the max number or characters before a max length error event is fired.
        /// </summary>
        public static int DEFAULT_MAX_LENGTH = 20;

        /// <summary>
        /// The default constructor that sets all the basic needs for this class to display properly.
        /// </summary>
        /// <param name="BgroundSrc">The MmgBmp object to use as the source image to be 9 sliced and resized as the background image.</param>
        /// <param name="Font">The MmgFont object used to render the text.</param>
        /// <param name="Width">The width of this object and the width used to resize the BgroundSrc MmgObj.</param>
        /// <param name="Height">The height of this object and the height used to resize the BgroundSrc MmgObj.</param>
        /// <param name="Padding">The padding value to use in slight font positioning calculations.</param>
        /// <param name="DisplayChars">The number of characters to display in one visible string.</param>
        public MmgTextField(MmgBmp BgroundSrc, MmgFont Font, int Width, int Height, int Padding, int DisplayChars) : base()
        {
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

        /// <summary>
        /// A constructor that creates a new instance of this class by cloning values from another clas instance.
        /// </summary>
        /// <param name="obj">The class used to create a new MmgTextField from.</param>
        public MmgTextField(MmgTextField obj) : base()
        {
            if (obj.GetBgroundSrc() == null)
            {
                SetBgroundSrc(obj.GetBgroundSrc());
            }
            else
            {
                SetBgroundSrc(obj.GetBgroundSrc().CloneTyped());
            }

            if (obj.GetFont() == null)
            {
                SetFont(obj.GetFont());
            }
            else
            {
                SetFont(obj.GetFont().CloneTyped());
            }

            SetHeight(obj.GetHeight());
            SetWidth(obj.GetWidth());
            SetPadding(obj.GetPadding());
            SetDisplayChars(obj.GetDisplayChars());
            SetMaxLength(obj.GetMaxLength());
            SetMaxLengthOn(obj.GetMaxLengthOn());

            Prep();

            if (obj.GetBground() == null)
            {
                SetBground(obj.GetBground());
            }
            else
            {
                SetBground(obj.GetBground().CloneTyped());
            }

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            SetFontHeight(obj.GetFontHeight());
            SetTextFieldString(obj.GetTextFieldString());
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgTextField(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgTextField CloneTyped()
        {
            return new MmgTextField(this);
        }

        /// <summary>
        /// A method that prepares the class for rendering to the screen.
        /// </summary>
        public virtual void Prep()
        {
            cursorBlinkStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            fontHeight = font.GetHeight();
            textFieldString = "";
            bground = new Mmg9Slice(TEXT_FIELD_9_SLICE_OFFSET, bgroundSrc, GetWidth(), GetHeight());
        }

        /// <summary>
        /// Gets the max length error event.
        /// </summary>
        /// <returns>The max length error event.</returns>
        public virtual MmgEvent GetErrorMaxLength()
        {
            return errorMaxLength;
        }

        /// <summary>
        /// Sets the max length error event.
        /// </summary>
        /// <param name="e">The max length error event.</param>
        public virtual void SetErrorMaxLength(MmgEvent e)
        {
            errorMaxLength = e;
        }

        /// <summary>
        /// Gets the MmgObj used as the basis for the 9 sliced background image for this object.
        /// </summary>
        /// <returns>The MmgObj used as the basis for the 9 sliced background.</returns>
        public virtual MmgBmp GetBgroundSrc()
        {
            return bgroundSrc;
        }

        /// <summary>
        /// Sets the MmgObj used as the basis for the 9 sliced background image for this object.
        /// </summary>
        /// <param name="bg">The MmgObj used as the basis for the 9 sliced background.</param>
        public virtual void SetBgroundSrc(MmgBmp bg)
        {
            bgroundSrc = bg;
        }

        /// <summary>
        /// Gets the Mmg9Slice background object.
        /// </summary>
        /// <returns>The Mmg9Slice background object.</returns>
        public virtual Mmg9Slice GetBground()
        {
            return bground;
        }

        /// <summary>
        /// Sets the Mmg9Slice background object.
        /// </summary>
        /// <param name="bg">The Mmg9Slice background object.</param>
        public virtual void SetBground(Mmg9Slice bg)
        {
            bground = bg;
        }

        /// <summary>
        /// Get the MmgFont used to render text.
        /// </summary>
        /// <returns>The MmgFont used to render text.</returns>
        public virtual MmgFont GetFont()
        {
            return font;
        }

        /// <summary>
        /// Sets the MmgFont used to render text.
        /// </summary>
        /// <param name="f">The MmgFont used to render text.</param>
        public virtual void SetFont(MmgFont f)
        {
            font = f;
        }

        /// <summary>
        /// Gets the max length of characters allowed if the max length limitation is on.
        /// </summary>
        /// <returns>The max length of characters allowed if the max length limitation is on.</returns>
        public virtual int GetMaxLength()
        {
            return maxLength;
        }

        /// <summary>
        /// Sets the max length of characters allowed if the max length limitation is on.
        /// </summary>
        /// <param name="i">The max length of characters allowed if the max length limitation is on.</param>
        public virtual void SetMaxLength(int i)
        {
            maxLength = i;
        }

        /// <summary>
        /// Gets the boolean flag indicating if the max length limitation is on.
        /// </summary>
        /// <returns>A boolean flag indicating if the max length limitation is on.</returns>
        public virtual bool GetMaxLengthOn()
        {
            return maxLengthOn;
        }

        /// <summary>
        /// Sets the boolean flag indicating if the max length limitation is on.
        /// </summary>
        /// <param name="b">A boolean flag indicating if the max length limitation is on.</param>
        public virtual void SetMaxLengthOn(bool b)
        {
            maxLengthOn = b;
        }

        /// <summary>
        /// Gets the text field string stored by this object.
        /// </summary>
        /// <returns>The text field string stored by this object.</returns>
        public virtual string GetTextFieldString()
        {
            return textFieldString;
        }

        /// <summary>
        /// Sets the text field string stored by this object.
        /// </summary>
        /// <param name="str">The text field string stored by this object.</param>
        public virtual void SetTextFieldString(string str)
        {
            textFieldString = str;
        }

        /// <summary>
        /// Gets the maximum number of characters to display in the text field.
        /// </summary>
        /// <returns>The maximum number of characters to display in the text field.</returns>
        public virtual int GetDisplayChars()
        {
            return displayChars;
        }

        /// <summary>
        /// Sets the maximum number of characters to display in the text field.
        /// </summary>
        /// <param name="i">The maximum number of characters to display in the text field.</param>
        public virtual void SetDisplayChars(int i)
        {
            displayChars = i;
        }

        /// <summary>
        /// Gets the height of the MmgFont used to render text.
        /// </summary>
        /// <returns>The height of the MmgFont used to render text.</returns>
        public virtual int GetFontHeight()
        {
            return fontHeight;
        }

        /// <summary>
        /// Sets the height of the MmgFont used to render text.
        /// </summary>
        /// <param name="i">The height of the MmgFont used to render text.</param>
        public virtual void SetFontHeight(int i)
        {
            fontHeight = i;
        }

        /// <summary>
        /// Gets the padding used in positioning the MmgFont text in the text field.
        /// </summary>
        /// <returns>The padding used in positioning the MmgFont text in the text field.</returns>
        public virtual int GetPadding()
        {
            return padding;
        }

        /// <summary>
        /// Sets the padding used in positioning the MmgFont text in the text field.
        /// </summary>
        /// <param name="i">The padding used in positioning the MmgFont text in the text field.</param>
        public virtual void SetPadding(int i)
        {
            padding = i;
        }

        /// <summary>
        /// Gets a boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call.
        /// </summary>
        /// <returns>A boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call.</returns>
        public virtual bool GetIsDirty()
        {
            return isDirty;
        }

        /// <summary>
        /// Sets a boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call.
        /// </summary>
        /// <param name="b">A boolean flag used to indicate that drawing needs to be done in the next MmgUpdate call.</param>
        public virtual void SetIsDirty(bool b)
        {
            isDirty = b;
        }

        /// <summary>
        /// Sets the position of the text field and MmgFont text with slight adjustments to the font based on the value of the padding class field.
        /// </summary>
        /// <param name="pos">The position of the text field.</param>
        public override void SetPosition(MmgVector2 pos)
        {
            base.SetPosition(pos);
            bground.SetPosition(new MmgVector2(pos.GetX(), pos.GetY()));
            font.SetPosition(new MmgVector2(pos.GetX() + padding, pos.GetY() + GetHeight() - padding));
        }

        /// <summary>
        /// Sets the position of the text field and MmgFont text with slight adjustments to the font based on the value of the padding class field.
        /// </summary>
        /// <param name="x">The X position to use when setting the position of the text field.</param>
        /// <param name="y">The Y position to use when setting the position of the text field.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            bground.SetPosition(x, y);
            if (MmgPen.FONT_NORMALIZE_POSITION)
            {
                font.SetPosition(new MmgVector2(MmgHelper.NormalizeFontPositionX(x + padding, font), MmgHelper.NormalizeFontPositionY(y + GetHeight() - padding, font)));
            }
            else
            {
                font.SetPosition(new MmgVector2(x + padding, y + GetHeight() - padding - MmgPen.FONT_VERT_POS_ADJ));
            }
        }

        /// <summary>
        /// A method for handling intake of characters to append to the text field string value.
        /// </summary>
        /// <param name="c">A character to append to the text field string value.</param>
        /// <param name="code">A character code used to find non-ASCII characters if need be.</param>
        /// <returns>A boolean flag indicating if any work was done.</returns>
        public virtual bool ProcessKeyClick(char c, int code)
        {
            if (maxLengthOn)
            {
                if (textFieldString.Length + 1 >= maxLength)
                {
                    if (errorMaxLength != null)
                    {
                        errorMaxLength.Fire();
                    }
                    return true;
                }
            }

            textFieldString += c;
            isDirty = true;
            return true;
        }

        /// <summary>
        /// A method for handling the deletion of characters from the text field.
        /// </summary>
        public virtual void DeleteChar()
        {
            if (textFieldString.Length > 0)
            {
                textFieldString = textFieldString.Substring(0, textFieldString.Length - 1);
            }
            isDirty = true;
        }

        /// <summary>
        /// Sets the X position of the text field.
        /// </summary>
        /// <param name="x">The X position to use when setting the position of the text field. </param>
        public override void SetX(int x)
        {
            base.SetX(x);
            bground.SetX(x);
            font.SetX(x + padding);
        }

        /// <summary>
        /// Sets the Y position of the text field.
        /// </summary>
        /// <param name="y">The Y position to use when setting the position of the text field.</param>
        public override void SetY(int y)
        {
            base.SetY(y);
            bground.SetY(y);
            font.SetY(y + GetHeight() - padding);
        }

        /// <summary>
        /// The MmgUpdate method that handles updating any object fields during the update calls.
        /// </summary>
        /// <param name="updateTick">The index of the update call.</param>
        /// <param name="currentTimeMs">The current time in milliseconds that the update was called.</param>
        /// <param name="msSinceLastFrame">The difference in milliseconds between this update call and the previous update call.</param>
        /// <returns>A boolean indicating if the update call was handled.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            if (isVisible == true)
            {
                tmpL = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                if (tmpL - cursorBlinkStart >= MmgTextField.TEXT_FIELD_CURSOR_BLINK_RATE_MS)
                {
                    isDirty = true;
                    cursorBlinkOn = !cursorBlinkOn;
                    cursorBlinkStart = tmpL;
                }

                if (isDirty)
                {
                    if (textFieldString.Length > displayChars)
                    {
                        font.SetText(textFieldString.Substring(textFieldString.Length - displayChars));
                    }
                    else
                    {
                        font.SetText(textFieldString);
                    }

                    if (cursorBlinkOn)
                    {
                        font.SetText(font.GetText() + TEXT_FIELD_CURSOR);
                    }

                    isDirty = false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// The base drawing method for this object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                bground.MmgDraw(p);
                font.MmgDraw(p);
            }
        }

        /// <summary>
        /// Sets the event handler for events.
        /// </summary>
        /// <param name="h">The event handler for events.</param>
        public virtual void SetEventHandler(MmgEventHandler h)
        {
            errorMaxLength.SetTargetEventHandler(h);
        }

        /// <summary>
        /// A method used to check the equality of this MmgTextField when compared to another MmgTextField.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgTextField object to compare to.</param>
        /// <returns>A boolean indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgTextField obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            if(!(base.equals((MmgObj)obj))) {
                MmgHelper.wr("MmgTextField MmgObj not equals!");
            }

            if(!(((obj.GetBground() == null && GetBground() == null) || (obj.GetBground() != null && GetBground() != null && obj.GetBground().equals(GetBground()))))) {
                MmgHelper.wr("MmgTextField Bground not equals!");
            }        

            if(!(((obj.GetBgroundSrc() == null && GetBgroundSrc() == null) || (obj.GetBgroundSrc() != null && GetBgroundSrc() != null && obj.GetBgroundSrc().equals(GetBgroundSrc()))))) {
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

            if(!(((obj.GetTextFieldString() == null && GetTextFieldString() == null) || (obj.GetTextFieldString() != null && GetTextFieldString() != null && obj.GetTextFieldString().Equals(GetTextFieldString()))))) {
                MmgHelper.wr("MmgTextField TextFieldString not equals! " + obj.GetTextFieldString() + ", " + GetTextFieldString());    
            }
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && ((obj.GetBground() == null && GetBground() == null) || (obj.GetBground() != null && GetBground() != null && obj.GetBground().ApiEquals(GetBground())))
                && ((obj.GetBgroundSrc() == null && GetBgroundSrc() == null) || (obj.GetBgroundSrc() != null && GetBgroundSrc() != null && obj.GetBgroundSrc().ApiEquals(GetBgroundSrc())))
                && obj.GetDisplayChars() == GetDisplayChars()
                && ((obj.GetFont() == null && GetFont() == null) || (obj.GetFont() != null && GetFont() != null && obj.GetFont().ApiEquals(GetFont())))
                && obj.GetFontHeight() == GetFontHeight()
                && obj.GetMaxLength() == GetMaxLength()
                && obj.GetMaxLengthOn() == GetMaxLengthOn()
                && obj.GetPadding() == GetPadding()
                && ((obj.GetTextFieldString() == null && GetTextFieldString() == null) || (obj.GetTextFieldString() != null && GetTextFieldString() != null && obj.GetTextFieldString().Equals(GetTextFieldString())))
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}