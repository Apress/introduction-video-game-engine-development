using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static net.middlemind.MmgGameApiCs.MmgBase.MmgFont;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class to control the background story of the game. 
    /// Renders the story in a box with a detected number of lines drawn.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgTextBlock : MmgObj
    {
        /// <summary>
        /// The array where each word is represented as a text object, MmgFont. 
        /// </summary>
        private List<MmgFont> txt;

        /// <summary>
        /// The font object, MmgFont, to use for rendering text.
        /// </summary>
        private SpriteFont paint;

        /// <summary>
        /// The color object, MmgColor, to use for rendering text.
        /// </summary>
        private MmgColor cl;

        /// <summary>
        /// The Y axis padding to use for rendering text.
        /// </summary>
        private int paddingY;

        /// <summary>
        /// The X axis padding to used for rendering text.
        /// </summary>
        private int paddingX;

        /// <summary>
        /// The line height to use for rendering text. 
        /// </summary>
        private int lineHeight;

        /// <summary>
        /// The height to use for rendering the background story.
        /// </summary>
        private int height;

        /// <summary>
        /// The width to use for rendering the background story.
        /// </summary>
        private int width;

        /// <summary>
        /// The number of pages found in parsing the background story.
        /// </summary>
        private int pages;

        /// <summary>
        /// The number of words found in parsing the background story. 
        /// </summary>
        private int words;

        /// <summary>
        /// The starting size of the line array.
        /// </summary>
        private int STARTING_LINE_COUNT = 20;

        /// <summary>
        /// The starting size of the text array.
        /// </summary>
        private int STARTING_TXT_COUNT = 100;

        /// <summary>
        /// A text object, MmgFont, representation of each display line on the current page.
        /// </summary>
        private List<MmgFont> lines;

        /// <summary>
        /// Rendering variable.
        /// </summary>
        private int dLen;

        /// <summary>
        /// Rendering variable.
        /// </summary>
        private int dI;

        /// <summary>
        /// Rendering variable.
        /// </summary>
        private MmgFont dTmp;

        /// <summary>
        /// The character encoding to use for setting a new line in the text block.
        /// </summary>
        public static String NEW_LINE = "[b]";

        /// <summary>
        /// A boolean flag that toggles drawing a bounding box around the text block to help with aligning the text block.
        /// </summary>
        public static bool SHOW_CONTROL_BGROUND_STORY_BOUNDING_BOX = false;

        /// <summary>
        /// A private variable used in the drawing routine.
        /// </summary>
        private Color c;

        /// <summary>
        /// Generic constructor. Sets the color and creates a clean lines, and text data object.
        /// </summary>
        public MmgTextBlock() : base()
        {
            SetPaddingX(MmgHelper.ScaleValue(4));
            SetPaddingY(MmgHelper.ScaleValue(4));
            SetLineHeight(MmgHelper.ScaleValue(16));
            SetHeight(MmgHelper.ScaleValue(100));
            SetWidth(MmgHelper.ScaleValue(100));
            lines = new List<MmgFont>(STARTING_LINE_COUNT);
            txt = new List<MmgFont>(STARTING_TXT_COUNT);
            SetColor(MmgColor.GetBlack());
        }

        /// <summary>
        /// A constructor that creates a new instance of this class from an existing one by cloning class fields.
        /// </summary>
        /// <param name="obj">A class instance used to create a new class instance.</param>
        public MmgTextBlock(MmgTextBlock obj) : base()
        {
            SetPaddingX(obj.GetPaddingX());
            SetPaddingY(obj.GetPaddingY());
            SetHeight(obj.GetHeight());
            SetWidth(obj.GetWidth());

            SetPages(obj.GetPages());
            SetLineHeight(obj.GetLineHeight());

            MmgFont tmpF = null;
            List<MmgFont> tmpL = null;
            if (obj.GetLines() == null)
            {
                SetLines(obj.GetLines());
            }
            else
            {
                tmpL = obj.GetLines();
                lines = new List<MmgFont>(STARTING_LINE_COUNT);
                for (int i = 0; i < obj.GetLines().Count; i++)
                {
                    tmpF = tmpL[i];
                    lines.Add(tmpF.CloneTyped());
                }
            }

            tmpF = null;
            tmpL = null;
            if (obj.GetTxt() == null)
            {
                SetTxt(obj.GetTxt());
            }
            else
            {
                tmpL = obj.GetTxt();
                txt = new List<MmgFont>(STARTING_TXT_COUNT);
                for (int i = 0; i < obj.GetTxt().Count; i++)
                {
                    tmpF = tmpL[i];
                    txt.Add(tmpF.CloneTyped());
                }
            }

            SetWordCount(obj.GetWordCount());
            SetSpriteFont(obj.GetSpriteFont());

            if (obj.GetColor() == null)
            {
                SetColor(obj.GetColor());
            }
            else
            {
                SetColor(obj.GetColor().Clone());
            }

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgTextBlock(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgTextBlock CloneTyped()
        {
            return new MmgTextBlock(this);
        }

        /// <summary>
        /// Gets the lines of text created when splitting the input text to fit the width and height of this object.
        /// </summary>
        /// <returns>The lines of this text block.</returns>
        public virtual List<MmgFont> GetLines()
        {
            return lines;
        }

        /// <summary>
        /// Sets the lines of text created when splitting the input text to fit the width and height of this object.
        /// </summary>
        /// <param name="a">The lines of this text block.</param>
        public virtual void SetLines(List<MmgFont> a)
        {
            lines = a;
        }

        /// <summary>
        /// Gets the lines of text displayed on this page of text.
        /// </summary>
        /// <returns>The lines of text displayed on this page of text.</returns>
        public virtual List<MmgFont> GetTxt()
        {
            return txt;
        }

        /// <summary>
        /// Sets the lines of text displayed on this page of text.
        /// </summary>
        /// <param name="a">The lines of text displayed on this page of text.</param>
        public virtual void SetTxt(List<MmgFont> a)
        {
            txt = a;
        }

        /// <summary>
        /// A method used to reset the lines split from the original text and the lines displayed on this page.
        /// </summary>
        public virtual void Reset()
        {
            lines = new List<MmgFont>(STARTING_LINE_COUNT);
            txt = new List<MmgFont>(STARTING_TXT_COUNT);
        }

        /// <summary>
        /// Gets the number of pages the story takes up. 
        /// The number of lines is determined after parsing the story text.
        /// </summary>
        /// <returns>The number of pages the story takes up.</returns>
        public virtual int GetPages()
        {
            return pages;
        }

        /// <summary>
        /// Sets the number of pages the story takes up. 
        /// This method should not be used with the default behavior.The number of lines is determined after
        /// parsing the story text.
        /// </summary>
        /// <param name="p">The number of pages in the story.</param>
        public virtual void SetPages(int p)
        {
            pages = p;
        }

        /// <summary>
        /// Gets the text object, MmgFont, at the given index of the array.
        /// </summary>
        /// <param name="i">The index of the entry in the text array.</param>
        /// <returns>Returns the text object, MmgFont, at the given index.</returns>
        public virtual MmgFont GetText(int i)
        {
            if (i < txt.Count)
            {
                return txt[i];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the text object, MmgFont, at the given index of the array.
        /// This method should not be used with the default behavior.
        /// </summary>
        /// <param name="i">The index of the entry to replace in the text array.</param>
        /// <param name="f">The text object, MmgFont, to set in the text array.</param>
        public virtual void SetText(int i, MmgFont f)
        {
            if (i < txt.Count)
            {
                txt.Insert(i, f);
            }
        }

        /// <summary>
        /// Gets the Font object used to render the background story.
        /// </summary>
        /// <returns>The font object used to render the story.</returns>
        public virtual SpriteFont GetSpriteFont()
        {
            return paint;
        }

        /// <summary>
        /// Sets the Font object used to render the background story.
        /// You may have to re-parse the story text if you change the font used to render it.
        /// </summary>
        /// <param name="p">Sets the Font object used to render the story.</param>
        public virtual void SetSpriteFont(SpriteFont p)
        {
            paint = p;
            int len = txt.Count;
            for (int i = 0; i < len; i++)
            {
                txt[i].SetFont(paint);
            }
        }

        /// <summary>
        /// Sets the color object, MmgColor, of the entire background story text.
        /// </summary>
        /// <param name="Cl">The color object, MmGColor, to apply to the story.</param>
        public virtual void SetColor(MmgColor Cl)
        {
            cl = Cl;
            int len = txt.Count;
            for (int i = 0; i < len; i++)
            {
                txt[i].SetMmgColor(cl);
            }
        }

        /// <summary>
        /// Gets the color object, MmgColor, of the background story.
        /// </summary>
        /// <returns>The MmgColor used when drawing text for this object.</returns>
        public virtual MmgColor GetColor()
        {
            return cl;
        }

        /// <summary>
        /// Gets the Y axis padding value.
        /// </summary>
        /// <returns>The Y axis padding value.</returns>
        public virtual int GetPaddingY()
        {
            return paddingY;
        }

        /// <summary>
        /// Sets the Y axis padding value.
        /// </summary>
        /// <param name="p">The Y axis padding value.</param>
        public virtual void SetPaddingY(int p)
        {
            paddingY = p;
        }

        /// <summary>
        /// Gets the X axis padding value.
        /// </summary>
        /// <returns>The X axis padding value.</returns>
        public virtual int GetPaddingX()
        {
            return paddingX;
        }

        /// <summary>
        /// Sets the X axis padding value.
        /// </summary>
        /// <param name="p">The X axis padding value.</param>
        public virtual void SetPaddingX(int p)
        {
            paddingX = p;
        }

        /// <summary>
        /// Gets the line height in pixels used in the display calculation of the
        /// background story.
        /// </summary>
        /// <returns>The line height in pixels.</returns>
        public virtual int GetLineHeight()
        {
            return lineHeight;
        }

        /// <summary>
        /// Sets the line height in pixels used in the display calculation of the
        /// background story.
        /// </summary>
        /// <param name="l">The line height in pixels.</param>
        public virtual void SetLineHeight(int l)
        {
            lineHeight = l;
        }

        /// <summary>
        /// Gets the height of the background story object.
        /// </summary>
        /// <returns>The height of the background story object.</returns>
        public override int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Sets the height of the background story object.
        /// You may have to re-parse the background story if you change the display dimensions.
        /// </summary>
        /// <param name="h">The height of the background story object.</param>
        public override void SetHeight(int h)
        {
            base.SetHeight(h);
            height = h;
        }

        /// <summary>
        /// Gets the width of the background story object.
        /// </summary>
        /// <returns>The width of the background story object.</returns>
        public override int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Sets the width of the background story object.
        /// You may have to re-parse the background story if you change the display dimensions.
        /// </summary>
        /// <param name="w">The width of the background story object.</param>
        public override void SetWidth(int w)
        {
            base.SetWidth(w);
            width = w;
        }

        /// <summary>
        /// Returns the number of lines that can be displayed in the background story box.
        /// </summary>
        /// <returns>The number of lines that can be displayed in the display box.</returns>
        public virtual int GetLinesInBox()
        {
            if (GetLineHeight() != 0)
            {
                return (GetHeight() / (GetLineHeight()));
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Prepares the lines that represent the display box with blank text objects, MmgFont.
        /// </summary>
        /// <param name="len">The number of line objects to prep for text display, usually is the number of line in a page.</param>
        public virtual void PrepLinesInBox(int len)
        {
            for (int i = 0; i < len; i++)
            {
                txt.Add(new MmgFont());
            }
        }

        /// <summary>
        /// Prepares the lines that represent the display box with blank text objects, MmgFont.
        /// </summary>
        public virtual void PrepLinesInBox()
        {
            int len = GetLinesInBox();
            for (int i = 0; i < len; i++)
            {
                txt.Add(new MmgFont());
            }
        }

        /// <summary>
        /// Sets the position of this object in its owner's display space.
        /// </summary>
        /// <param name="vec">A position coordinate, MmgVector2.</param>
        public override void SetPosition(MmgVector2 vec)
        {
            base.SetPosition(vec.Clone());
            int len = txt.Count;
            for (int i = 0; i < len; i++)
            {
                MmgFont tmp = txt[i];
                tmp.GetPosition().SetX(vec.GetX() + paddingX);
                tmp.GetPosition().SetY(vec.GetY() + (lineHeight / 2) + paddingY + (lineHeight * i));
                txt[i] = tmp;
            }
        }

        /// <summary>
        /// Sets the position of this object in its owner's display space.
        /// </summary>
        /// <param name="x">The X coordinate of the position.</param>
        /// <param name="y">The Y coordinate of the position.</param>
        public override void SetPosition(int x, int y)
        {
            SetPosition(new MmgVector2(x, y));
        }

        /// <summary>
        /// Sets the X coordinate of the MmgTextBlock object.
        /// </summary>
        /// <param name="i">The X coordinate of the position.</param>
        public override void SetX(int i)
        {
            SetPosition(new MmgVector2(i, GetY()));
        }

        /// <summary>
        /// Sets the Y coordinate of the MmgTextBlock object.
        /// </summary>
        /// <param name="i">The Y coordinate of the position.</param>
        public override void SetY(int i)
        {
            SetPosition(new MmgVector2(GetX(), i));
        }

        /// <summary>
        /// Gets the number of pages needed to display the background story text.
        /// </summary>
        /// <returns>The number of display pages.</returns>
        public virtual int GetPageCount()
        {
            return pages;
        }

        /// <summary>
        /// Gets the number of text lines that are displayed on each page.
        /// </summary>
        /// <returns>The number of lines that are displayed on each page.</returns>
        public virtual int GetLineCount()
        {
            return txt.Count;
        }

        /// <summary>
        /// Gets the number of used lines in the text block.
        /// </summary>
        /// <returns>The number of lines used in this text block.</returns>
        public virtual int GetUsedLineCount()
        {
            int ret = 0;
            int len = txt.Count;
            for (int i = 0; i < len; i++)
            {
                if (txt[i] != null && txt[i].GetText().Trim().Equals("") == false)
                {
                    ret++;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the number of words that are in the background story.
        /// </summary>
        /// <returns>The number of words in the background story.</returns>
        public virtual int GetWordCount()
        {
            return words;
        }

        /// <summary>
        /// Sets the number of words that are in the background story.
        /// This really should not need to be used as the text processing methods will set the value automatically.
        /// </summary>
        /// <param name="i">The number of words in the background story.</param>
        public virtual void SetWordCount(int i)
        {
            words = i;
        }

        /// <summary>
        /// Prepares the text for rendering for the given page index.
        /// </summary>
        /// <param name="page">The page index to render text for.</param>
        public virtual void PrepPage(int page)
        {
            int len = GetLineCount();

            if (page >= pages)
            {
                for (int i = 0; i < len; i++)
                {
                    txt[i].SetText("");
                }
            }
            else
            {
                if (lines != null)
                {
                    int i = 0;
                    MmgFont tmp = null;

                    for (int j = 0; j < len; j++)
                    {
                        i = (page * GetLineCount()) + j;
                        if (i >= 0 && i < lines.Count)
                        {
                            tmp = (MmgFont)lines[i];
                            if (tmp != null)
                            {
                                txt[j] = (MmgFont)tmp.Clone();
                            }
                            else
                            {
                                txt[j].SetText("");
                            }
                        }
                        else
                        {
                            txt[j].SetText("");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < len; i++)
                    {
                        txt[i].SetText("");
                    }
                }
            }
        }

        /// <summary>
        /// Parses and prepares the text for display in a paged view.
        /// </summary>
        /// <param name="text">The text to parse as the background story.</param>
        /// <param name="typeFace">The Font to use to render the text.</param>
        /// <param name="fontSize">The size of the font used to parse the text.</param>
        /// <param name="width">The width to use as the maximum width for one line.</param>
        public virtual void PrepTextSplit(string text, SpriteFont typeFace, int fontSize, int width, FontType fontType)
        {
            text = text.Replace(" " + MmgTextBlock.NEW_LINE, MmgTextBlock.NEW_LINE);
            text = text.Replace("  " + MmgTextBlock.NEW_LINE, MmgTextBlock.NEW_LINE);
            text = text.Replace(MmgTextBlock.NEW_LINE, " " + MmgTextBlock.NEW_LINE);
            String[] tokens = text.Split(" ");
            int tokenPos = 0;
            int prevTokenPos = 0;
            String str = "";
            String prevStr = "";
            MmgFont desc = null;
            bool added = false;
            lines = new List<MmgFont>(STARTING_LINE_COUNT);

            while (tokenPos < tokens.Length)
            {
                desc = null;
                desc = new MmgFont(typeFace, fontType);
                desc.SetFontSize(fontSize);
                desc.SetText("");
                str = "";
                prevStr = "";
                added = false;

                while (desc.GetWidth() < width && tokenPos < tokens.Length)
                {
                    if ((tokens[tokenPos] + "").Equals(MmgTextBlock.NEW_LINE) == true)
                    {
                        //consume and move to the next line
                        desc.SetText(str);
                        lines.Add(desc);
                        tokenPos++;
                        added = true;
                        break;
                    }
                    else
                    {
                        prevStr = str;
                        str += tokens[tokenPos] + " ";

                        prevTokenPos = tokenPos;
                        tokenPos += 1;
                        desc.SetText(str);

                        if (desc.GetWidth() > width)
                        {
                            tokenPos = prevTokenPos;
                            str = prevStr;
                            desc.SetText(str);
                            lines.Add(desc);
                            added = true;
                            break;
                        }
                    }
                }

                if (added == false)
                {
                    lines.Add(desc);
                }
            }

            pages = (lines.Count / GetLineCount());
            if (lines.Count % GetLineCount() != 0)
            {
                pages++;
            }
            words = tokens.Length;
        }

        /// <summary>
        /// Draws this object using the given pen, MmgPen.
        /// </summary>
        /// <param name="p">The pen to use to draw this object, MmgPen.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (MmgTextBlock.SHOW_CONTROL_BGROUND_STORY_BOUNDING_BOX == true)
                {
                    c = p.GetGraphicsColor();
                    p.SetGraphicsColor(Color.Red);
                    p.DrawRect(this);
                    p.SetGraphicsColor(c);
                }

                dLen = GetLineCount();
                for (dI = 0; dI < dLen; dI++)
                {
                    dTmp = txt[dI];
                    if (dTmp != null && dTmp.GetIsVisible() == true)
                    {
                        MmgHelper.wr("MmgTextBlock: MmgDraw: Text: " + dTmp.GetText() + ", " + dTmp.GetPosition().ApiToString());
                        p.DrawText(dTmp);
                    }
                }
            }
        }

        /// <summary>
        /// A method that checks the equality of this MmgTextBlock object and the given argument.
        /// </summary>
        /// <param name="obj">The MmgTextBlock object to compare this object to.</param>
        /// <returns>Returns true if the two objects are equal and false otherwise.</returns>
        public virtual bool ApiEquals(MmgTextBlock obj)
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
                MmgHelper.wr("MmgTextBlock: MmgObj is not equals!");
            }

            if(!(((obj.GetColor() == null && GetColor() == null) || (obj.GetColor() != null && GetColor() != null && obj.GetColor().equals(GetColor()))))) {
                MmgHelper.wr("MmgTextBlock: Color is not equals!");
            }

            if(!(obj.GetHeight() == GetHeight())) {
                MmgHelper.wr("MmgTextBlock: Height is not equals!");            
            }        

            if(!(obj.GetLineCount() == GetLineCount())) {
                MmgHelper.wr("MmgTextBlock: LineCount is not equals!");            
            }

            if(!(obj.GetLineHeight() == GetLineHeight())) {
                MmgHelper.wr("MmgTextBlock: LineHeight is not equals!");            
            }

            if(!(obj.GetLinesInBox() == GetLinesInBox())) {
                MmgHelper.wr("MmgTextBlock: LinesInBox is not equals!");            
            }

            if(!(obj.GetPaddingX() == GetPaddingX())) {
                MmgHelper.wr("MmgTextBlock: PaddingX is not equals!");            
            }

            if(!(obj.GetPaddingY() == GetPaddingY())) {
                MmgHelper.wr("MmgTextBlock: PaddingY is not equals!");            
            }        

            if(!(obj.GetPageCount() == GetPageCount())) {
                MmgHelper.wr("MmgTextBlock: PageCount is not equals!");
            }

            if(!(obj.GetPages() == GetPages())) {
                MmgHelper.wr("MmgTextBlock: Pages is not equals!");
            }

            if(!(((obj.GetSpriteFont() == null && GetSpriteFont() == null) || (obj.GetSpriteFont() != null && GetSpriteFont() != null && obj.GetSpriteFont().Equals(GetSpriteFont()))))) {
                MmgHelper.wr("MmgTextBlock: SpriteFont is not equals!");            
            }

            if(!(obj.GetUsedLineCount() == GetUsedLineCount())) {
                MmgHelper.wr("MmgTextBlock: UsedLineCount is not equals!"); 
            }

            if(!(obj.GetWidth() == GetWidth())) {
                MmgHelper.wr("MmgTextBlock: Width is not equals!"); 
            }

            if(!(obj.GetWordCount() == GetWordCount())) {
                MmgHelper.wr("MmgTextBlock: WordCount is not equals!"); 
            }
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && ((obj.GetColor() == null && GetColor() == null) || (obj.GetColor() != null && GetColor() != null && obj.GetColor().ApiEquals(GetColor())))
                && obj.GetHeight() == GetHeight()
                && obj.GetLineCount() == GetLineCount()
                && obj.GetLineHeight() == GetLineHeight()
                && obj.GetLinesInBox() == GetLinesInBox()
                && obj.GetPaddingX() == GetPaddingX()
                && obj.GetPaddingY() == GetPaddingY()
                && obj.GetPageCount() == GetPageCount()
                && obj.GetPages() == GetPages()
                && ((obj.GetSpriteFont() == null && GetSpriteFont() == null) || (obj.GetSpriteFont() != null && GetSpriteFont() != null && obj.GetSpriteFont().Equals(GetSpriteFont())))
                && obj.GetUsedLineCount() == GetUsedLineCount()
                && obj.GetWidth() == GetWidth()
                && obj.GetWordCount() == GetWordCount()
            )
            {
                ret = true;
                if (obj.GetLines() == null && GetLines() == null)
                {
                    ret = true;
                }
                else if (obj.GetLines() != null && GetLines() != null)
                {
                    int len1 = obj.GetLines().Count;
                    int len2 = GetLines().Count;
                    if (len1 != len2)
                    {
                        ret = false;
                    }
                    else
                    {
                        for (int i = 0; i < len1; i++)
                        {
                            if (!obj.GetLines()[i].ApiEquals(GetLines()[i]))
                            {
                                ret = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ret = false;
                }
            }
            return ret;
        }
    }
}