using System;
using Microsoft.Xna.Framework.Graphics;
using static net.middlemind.MmgGameApiCs.MmgBase.MmgFont;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that helps with font information. 
    /// Created by Middlemind Games
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0054:Use compound assignment", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgFontData
    {
        /// <summary>
        /// The default font family.
        /// </summary>
        public static string DEFAULT_FONT_FAMILY = "Serif";

        /// <summary>
        /// The default font type.
        /// </summary>
        public static FontType DEFAULT_FONT_TYPE = FontType.NORMAL;

        /// <summary>
        /// Current font size.
        /// </summary>
        private static int fontSize = 18;

        /// <summary>
        /// The target pixel height of the font.
        /// </summary>
        private static int targetPixelHeight = 22;

        /// <summary>
        /// The target pixel height scaled.
        /// </summary>
        private static int targetPixelHeightScaled = 22;

        //NOTE: Added to the Monogame version to help make font handling similar to the Java version.
        //The Java API can resize fonts to mimic that behavior we have font sizes up to 50 loaded into the Monogame resource file.
        /// <summary>
        /// The maximum font size supported.
        /// </summary>
        public static int MAX_FONT_SIZE = 50;

        //NOTE: Added to the Monogame version to help make font handling similar to the Java version.
        /// <summary>
        /// The root of the Monogame resource key used to load normal fonts.
        /// </summary>
        public static string FONT_KEY_NORMAL = MmgFontData.DEFAULT_FONT_FAMILY + "FontNorm";

        //NOTE: Added to the Monogame version to help make font handling similar to the Java version.
        /// <summary>
        /// The root of the Monogame resource key used to load bold fonts.
        /// </summary>
        public static string FONT_KEY_BOLD = MmgFontData.DEFAULT_FONT_FAMILY + "FontBold";

        //NOTE: Added to the Monogame version to help make font handling similar to the Java version.
        /// <summary>
        /// The root of the Monogame resource key used to load italic fonts.
        /// </summary>
        public static string FONT_KEY_ITALIC = MmgFontData.DEFAULT_FONT_FAMILY + "FontItalic";

        /// <summary>
        /// The normal font to use.
        /// </summary>
        private static SpriteFont fontNorm;

        /// <summary>
        /// The bold font to use.
        /// </summary>
        private static SpriteFont fontBold;

        /// <summary>
        /// The italic font to use.
        /// </summary>
        private static SpriteFont fontItalic;

        /// <summary>
        /// An MmgFont class that wraps the normal font.
        /// </summary>
        private static MmgFont mmgFontNorm = new MmgFont(MmgFontData.fontNorm, MmgFontData.fontSize, FontType.NORMAL);

        /// <summary>
        /// An MmgFont class that wraps the bold font.
        /// </summary>
        private static MmgFont mmgFontBold = new MmgFont(MmgFontData.fontBold, MmgFontData.fontSize, FontType.BOLD);

        /// <summary>
        /// An MmgFont class that wraps the italic font.
        /// </summary>
        private static MmgFont mmgFontItalic = new MmgFont(MmgFontData.fontItalic, MmgFontData.fontSize, FontType.ITALIC);

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgFontData()
        {
            fontNorm = MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + fontSize);
            fontBold = MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + fontSize);
            fontItalic = MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + fontSize);
            MmgFontData.CalculateScale();
        }

        /// <summary>
        /// Calculates scale for the given target pixel height.
        /// </summary>
        public static void CalculateScale()
        {
            MmgFont fnt = new MmgFont(fontBold, FontType.BOLD);
            int fntSize = 12;
            int maxFntSize = MAX_FONT_SIZE;
            fnt.SetFontType(MmgFont.FontType.BOLD);
            fnt.SetFontSize(fntSize);
            fnt.SetText("Font Test");
            int max = 50;
            int count = 0;
            int target = MmgHelper.ScaleValue(targetPixelHeight);
            MmgFontData.targetPixelHeightScaled = target;

            if (fnt.GetHeight() < target)
            {
                while (fnt.GetHeight() < target)
                {
                    count++;
                    fntSize++;
                    fnt.SetFontSize(fntSize);
                    fnt.SetText("Font Test");

                    if (count >= max)
                    {
                        fntSize = 12;
                        break;
                    }
                }
            }
            else
            {
                while (fnt.GetHeight() > target)
                {
                    count++;
                    fntSize--;
                    fnt.SetFontSize(fntSize);
                    fnt.SetText("Font Test");

                    if (count >= max)
                    {
                        fntSize = 12;
                        break;
                    }
                }
            }

            if (fntSize % 2 != 0)
            {
                fntSize = (fntSize + 1);
            }

            fontSize = fntSize;

            if(fontSize > maxFntSize)
            {
                fontSize = maxFntSize;
            }

            fontNorm = MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + fontSize);
            fontBold = MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + fontSize);
            fontItalic = MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + fontSize);

            mmgFontNorm = new MmgFont(MmgFontData.fontNorm, fontSize, FontType.NORMAL);
            mmgFontBold = new MmgFont(MmgFontData.fontBold, fontSize, FontType.BOLD);
            mmgFontItalic = new MmgFont(MmgFontData.fontItalic, fontSize, FontType.ITALIC);
        }

        /// <summary>
        /// String representation of this font.
        /// </summary>
        /// <returns>Returns a string representation of the font data.</returns>
        public static string ApiToString()
        {
            string ret = "";
            ret += "MmgFontData: Font Size: " + MmgFontData.GetFontSize() + System.Environment.NewLine;
            ret += "MmgFontData: Target Pixel Height (Unscaled): " + MmgFontData.GetTargetPixelHeight() + System.Environment.NewLine;
            ret += "MmgFontData: Target Pixel Height (Scaled): " + MmgHelper.ScaleValue(MmgFontData.GetTargetPixelHeight()) + System.Environment.NewLine;
            return ret;
        }

        /// <summary>
        /// A static method that creates a default font.
        /// </summary>
        /// <param name="sz">The target font size to use with the default font.</param>
        /// <returns>A new Font instance that is of the default font family, default font type, and specified size.</returns>
        public static SpriteFont CreateDefaultFont(int sz)
        {
            if (sz > 0 && sz < MmgFontData.MAX_FONT_SIZE)
            {
                if (DEFAULT_FONT_TYPE == FontType.BOLD)
                {
                    //bold
                    return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + sz);
                }
                else if (DEFAULT_FONT_TYPE == FontType.ITALIC)
                {
                    //italic
                    return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + sz);
                }
                else
                {
                    //normal
                    return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + sz);
                }
            }
            else
            {
                MmgHelper.wr("MmgFont: Error size must be greater than 0 and less than " + MmgFontData.MAX_FONT_SIZE);
                if (DEFAULT_FONT_TYPE == FontType.BOLD)
                {
                    //bold
                    return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + fontSize);
                }
                else if (DEFAULT_FONT_TYPE == FontType.ITALIC)
                {
                    //italic
                    return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + fontSize);
                }
                else
                {
                    //normal
                    return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + fontSize);
                }
            }
        }

        /// <summary>
        /// A static method that creates a default normal font.
        /// </summary>
        /// <param name="sz">The target font size to use with the default normal font.</param>
        /// <returns>A new Font instance that is of the default font family, plain font type, and specified size.</returns>
        public static SpriteFont CreateDefaultNormalFont(int sz)
        {
            if (sz > 0 && sz < MmgFontData.MAX_FONT_SIZE)
            {
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + sz);
            }
            else
            {
                MmgHelper.wr("MmgFont: Error size must be greater than 0 and less than " + MmgFontData.MAX_FONT_SIZE);   
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + fontSize);
            }
        }

        /// <summary>
        /// A static method that creates a default bold font.
        /// </summary>
        /// <param name="sz">The target font size to use with the default bold font.</param>
        /// <returns>A new Font instance that is of the default font family, bold font type, and specified size.</returns>
        public static SpriteFont CreateDefaultBoldFont(int sz)
        {
            if (sz > 0 && sz < MmgFontData.MAX_FONT_SIZE)
            {
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + sz);
            }
            else
            {
                MmgHelper.wr("MmgFont: Error size must be greater than 0 and less than " + MmgFontData.MAX_FONT_SIZE);
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + fontSize);
            }
        }

        /// <summary>
        /// A static method that creates a default italic font.
        /// </summary>
        /// <param name="sz">The target font size to use with the default italic font.</param>
        /// <returns>A new Font instance that is of the default font family, italic font type, and specified size.</returns>
        public static SpriteFont CreateDefaultItalicFont(int sz)
        {
            if (sz > 0 && sz < MmgFontData.MAX_FONT_SIZE)
            {
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + sz);
            }
            else
            {
                MmgHelper.wr("MmgFont: Error size must be greater than 0 and less than " + MmgFontData.MAX_FONT_SIZE);
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + fontSize);
            }
        }

        /// <summary>
        /// A static method that creates a new default MmgFont instance.
        /// </summary>
        /// <param name="sz">The target font size to use with the default font.</param>
        /// <returns>A new MmgFont instance that is of the default font family, plain font type, and specified size.</returns>
        public static MmgFont CreateDefaultMmgFont(int sz)
        {
            return new MmgFont(MmgFontData.CreateDefaultFont(sz), sz, DEFAULT_FONT_TYPE);
        }

        /// <summary>
        /// A static method that creates a new default normal MmgFont instance.
        /// </summary>
        /// <param name="sz">The target font size to use with the default normal font.</param>
        /// <returns>A new MmgFont instance that is of the default font family, normal font, and specified size.</returns>
        public static MmgFont CreateDefaultNormalMmgFont(int sz)
        {
            return new MmgFont(MmgFontData.CreateDefaultNormalFont(sz), sz, FontType.NORMAL);
        }

        /// <summary>
        /// A static method that creates a new default bold MmgFont instance.
        /// </summary>
        /// <param name="sz">The target font size to use with the default bold font.</param>
        /// <returns>A new MmgFont instance that is of the default font family, bold font, and specified size.</returns>
        public static MmgFont CreateDefaultBoldMmgFont(int sz)
        {
            return new MmgFont(MmgFontData.CreateDefaultBoldFont(sz), sz, FontType.BOLD);
        }

        /// <summary>
        /// A static method that creates a new default italic MmgFont instance.
        /// </summary>
        /// <param name="sz">The target font size to use with the default italic font.</param>
        /// <returns>A new MmgFont instance that is of the default font family, italic font, and specified size.</returns>
        public static MmgFont CreateDefaultItalicMmgFont(int sz)
        {
            return new MmgFont(MmgFontData.CreateDefaultItalicFont(sz), sz, FontType.ITALIC);
        }

        /// <summary>
        /// A static method that creates a new default small font.
        /// </summary>
        /// <returns>A new MmgFont instance that is of the default font family, normal font, and a small font size.</returns>
        public static SpriteFont CreateDefaultFontSm()
        {
            if (DEFAULT_FONT_TYPE == FontType.BOLD)
            {
                //bold
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + (fontSize - 2));
            }
            else if (DEFAULT_FONT_TYPE == FontType.ITALIC)
            {
                //italic
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + (fontSize - 2));
            }
            else
            {
                //normal
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + (fontSize - 2));
            }
        }

        /// <summary>
        /// A static method that creates a new default small font.
        /// </summary>
        /// <returns>A new Font instance that is of the default font family, normal font, and a small font size.</returns>
        public static SpriteFont CreateDefaultNormalFontSm()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + (fontSize - 2));
        }

        /// <summary>
        /// A static method that creates a new default, bold, small font.
        /// </summary>
        /// <returns>A new MmgFont instance that is of the default font family, bold font, and a small font size.</returns>
        public static SpriteFont CreateDefaultBoldFontSm()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + (fontSize - 2));
        }

        /// <summary>
        /// A static method that creates a new default, italic, small font.
        /// </summary>
        /// <returns>A new Font instance that is of the default font family, italic font, and a small font size.</returns>
        public static SpriteFont CreateDefaultItalicFontSm()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + (fontSize - 2));
        }

        /// <summary>
        /// A static method that creates a new default, normal, extra small font.
        /// </summary>
        /// <returns>A new MmgFont instance that is of the default font family, normal font, and an extra small font size.</returns>
        public static SpriteFont CreateDefaultFontExtraSm()
        {
            if (DEFAULT_FONT_TYPE == FontType.BOLD)
            {
                //bold
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + (fontSize - 4));
            }
            else if (DEFAULT_FONT_TYPE == FontType.ITALIC)
            {
                //italic
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + (fontSize - 4));
            }
            else
            {
                //normal
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + (fontSize - 4));
            }
        }

        /// <summary>
        /// A static method that creates a new default, normal, extra small font.
        /// </summary>
        /// <returns>A new MmgFont instance that is of the default font family, normal font, and an extra small font size.</returns>
        public static SpriteFont CreateDefaultNormalFontExtraSm()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + (fontSize - 4));
        }

        /// <summary>
        /// A static method that creates a new default, bold, extra small font.
        /// </summary>
        /// <returns>A new Font instance that is of the default font family, bold font, and an extra small font size.</returns>
        public static SpriteFont CreateDefaultBoldFontExtraSm()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + (fontSize - 4));
        }

        /// <summary>
        /// A static method that creates a new default, italic, extra small font.
        /// </summary>
        /// <returns>A new Font instance that is of the default font family, italic font, and an extra small font size.</returns>
        public static SpriteFont CreateDefaultItalicFontExtraSm()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + (fontSize - 4));
        }

        /// <summary>
        /// A static method that creates a new default, normal, small font.
        /// </summary>
        /// <returns>A new MmgFont instance based on a Font from CreateDefaultFontSm.</returns>
        public static MmgFont CreateDefaultMmgFontSm()
        {
            return new MmgFont(MmgFontData.CreateDefaultFontSm(), (fontSize - 2), DEFAULT_FONT_TYPE);
        }

        /// <summary>
        /// A static method that creates a new default, normal, small font.
        /// </summary>
        /// <returns>A new MmgFont instance based on a Font from CreateDefaultNormalFontSm.</returns>
        public static MmgFont CreateDefaultNormalMmgFontSm()
        {
            return new MmgFont(MmgFontData.CreateDefaultNormalFontSm(), (fontSize - 2), FontType.NORMAL);
        }

        /// <summary>
        /// A static method that creates a new default, bold, small font.
        /// </summary>
        /// <returns>A new MmgFont instance based on a Font from CreateDefaultBoldFontSm.</returns>
        public static MmgFont CreateDefaultBoldMmgFontSm()
        {
            return new MmgFont(MmgFontData.CreateDefaultBoldFontSm(), (fontSize - 2), FontType.BOLD);
        }

        /// <summary>
        /// A static method that creates a new default, italic, small font.
        /// </summary>
        /// <returns>A new MmgFont instance based on a Font from CreateDefaultItalicFontSm.</returns>
        public static MmgFont CreateDefaultItalicMmgFontSm()
        {
            return new MmgFont(MmgFontData.CreateDefaultItalicFontSm(), (fontSize - 2), FontType.ITALIC);
        }

        /// <summary>
        /// A static method that creates a new default, normal, large font.
        /// </summary>
        /// <returns>A new Font instance based on the default font family, default font type, large font size.</returns>
        public static SpriteFont CreateDefaultFontLg()
        {
            if (DEFAULT_FONT_TYPE == FontType.BOLD)
            {
                //bold
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + (fontSize + 2));
            }
            else if (DEFAULT_FONT_TYPE == FontType.ITALIC)
            {
                //italic
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + (fontSize + 2));
            }
            else
            {
                //normal
                return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + (fontSize + 2));
            }
        }

        /// <summary>
        /// A static method that creates a new default, normal, large font.
        /// </summary>
        /// <returns>A new Font instance based on the default font family, normal font type, large font size.</returns>
        public static SpriteFont CreateDefaultNormalFontLg()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_NORMAL + (fontSize + 2));
        }

        /// <summary>
        /// A static method that creates a new default, bold, large font.
        /// </summary>
        /// <returns>A new Font instance based on the default font family, bold font type, large font size.</returns>
        public static SpriteFont CreateDefaultBoldFontLg()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_BOLD + (fontSize + 2));
        }

        /// <summary>
        /// A static method that creates a new default, italic, large font.
        /// </summary>
        /// <returns>A new Font instance based on the default font family, italic font type, large font size.</returns>
        public static SpriteFont CreateDefaultItalicFontLg()
        {
            return MmgScreenData.CONTENT_MANAGER.Load<SpriteFont>(FONT_KEY_ITALIC + (fontSize + 2));
        }

        /// <summary>
        /// A static method that creates a new default, normal, large font.
        /// </summary>
        /// <returns>A new MmgFont instance based on the default font family, default font type, large font size.</returns>
        public static MmgFont CreateDefaultMmgFontLg()
        {
            return new MmgFont(MmgFontData.CreateDefaultFontLg(), (fontSize + 2), DEFAULT_FONT_TYPE);
        }

        /// <summary>
        /// A static method that creates a new default, normal, large font.
        /// </summary>
        /// <returns>A new MmgFont instance based on the default font family, normal font type, large font size.</returns>
        public static MmgFont CreateDefaultNormalMmgFontLg()
        {
            return new MmgFont(MmgFontData.CreateDefaultNormalFontLg(), (fontSize + 2), FontType.NORMAL);
        }

        /// <summary>
        /// A static method that creates a new default, bold, large font.
        /// </summary>
        /// <returns>A new MmgFont instance based on the default font family, bold font type, large font size.</returns>
        public static MmgFont CreateDefaultBoldMmgFontLg()
        {
            return new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), (fontSize + 2), FontType.BOLD);
        }

        /// <summary>
        /// A static method that creates a new default, italic, large font.
        /// </summary>
        /// <returns>A new MmgFont instance based on the default font family, italic font type, large font size.</returns>
        public static MmgFont CreateDefaultItalicMmgFontLg()
        {
            return new MmgFont(MmgFontData.CreateDefaultItalicFontLg(), (fontSize + 2), FontType.ITALIC);
        }

        /// <summary>
        /// Gets the font size.
        /// </summary>
        /// <returns>The font size.</returns>
        public static int GetFontSize()
        {
            return fontSize;
        }

        /// <summary>
        /// Sets the font size.
        /// </summary>
        /// <param name="fontSize">The font size.</param>
        public static void SetFontSize(int fontSize)
        {
            MmgFontData.fontSize = fontSize;
        }

        /// <summary>
        /// Gets the target pixel height.
        /// </summary>
        /// <returns>The target pixel height.</returns>
        public static int GetTargetPixelHeight()
        {
            return targetPixelHeight;
        }

        /// <summary>
        /// Sets the target pixel height.
        /// </summary>
        /// <param name="targetPixelHeight">The target pixel height.</param>
        public static void SetTargetPixelHeight(int targetPixelHeight)
        {
            MmgFontData.targetPixelHeight = targetPixelHeight;
        }

        /// <summary>
        /// Gets the target pixel height scaled.
        /// </summary>
        /// <returns>The target height scaled.</returns>
        public static int GetTargetPixelHeightScaled()
        {
            return MmgFontData.targetPixelHeightScaled;
        }

        /// <summary>
        /// Sets the target pixel height scaled.
        /// </summary>
        /// <param name="t">The target height scaled.</param>
        public static void SetTargetPixelHeightScaled(int t)
        {
            MmgFontData.targetPixelHeightScaled = t;
        }

        /// <summary>
        /// Gets the normal font.
        /// </summary>
        /// <returns>The normal font.</returns>
        public static SpriteFont GetFontNorm()
        {
            return fontNorm;
        }

        /// <summary>
        /// Sets the normal font.
        /// </summary>
        /// <param name="tfNorm">The normal font.</param>
        public static void SetFontNorm(SpriteFont tfNorm)
        {
            MmgFontData.fontNorm = tfNorm;
        }

        /// <summary>
        /// Gets the bold font.
        /// </summary>
        /// <returns>The bold font.</returns>
        public static SpriteFont GetFontBold()
        {
            return fontBold;
        }

        /// <summary>
        /// Sets the bold font.
        /// </summary>
        /// <param name="tfBold">The bold font.</param>
        public static void SetFontBold(SpriteFont tfBold)
        {
            MmgFontData.fontBold = tfBold;
        }

        /// <summary>
        /// Gets the italic font.
        /// </summary>
        /// <returns>The italic font.</returns>
        public static SpriteFont GetFontItalic()
        {
            return fontItalic;
        }

        /// <summary>
        /// Sets the italic font.
        /// </summary>
        /// <param name="tfItac">The italic font.</param>
        public static void SetFontItalic(SpriteFont tfItac)
        {
            MmgFontData.fontItalic = tfItac;
        }

        /// <summary>
        /// Gets the MmgFont for normal text.
        /// </summary>
        /// <returns>The MmgFont for normal text.</returns>
        public static MmgFont GetMmgFontNorm()
        {
            return mmgFontNorm.CloneTyped();
        }

        /// <summary>
        /// Sets the MmgFont for normal text.
        /// </summary>
        /// <param name="mmgFontNorm">The MmgFont for normal text.</param>
        public static void SetMmgFontNorm(MmgFont mmgFontNorm)
        {
            MmgFontData.mmgFontNorm = mmgFontNorm;
        }

        /// <summary>
        /// Gets the MmgFont for bold text.
        /// </summary>
        /// <returns>The MmgFont for bold text.</returns>
        public static MmgFont GetMmgFontBold()
        {
            return mmgFontBold.CloneTyped();
        }

        /// <summary>
        /// Sets the MmgFont for bold text.
        /// </summary>
        /// <param name="mmgFontBold">The MmgFont for bold text.</param>
        public static void SetMmgFontBold(MmgFont mmgFontBold)
        {
            MmgFontData.mmgFontBold = mmgFontBold;
        }

        /// <summary>
        /// Gets the MmgFont for italic text.
        /// </summary>
        /// <returns>The MmgFont for italic text.</returns>
        public static MmgFont GetMmgFontItalic()
        {
            return mmgFontItalic.CloneTyped();
        }

        /// <summary>
        /// Sets the MmgFont for italic text.
        /// </summary>
        /// <param name="mmgFontItalic">The MmgFont to use for italic text.</param>
        public static void SetMmgFontItalic(MmgFont mmgFontItalic)
        {
            MmgFontData.mmgFontItalic = mmgFontItalic;
        }
    }
}