using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that wraps the lower level color object. 
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgColor
    {
        /// <summary>
        /// The color of this object.
        /// </summary>
        private Color c;

        /// <summary>
        /// Constructor of this object.
        /// </summary>
        public MmgColor()
        {
            c = Color.White;
        }

        /// <summary>
        /// Constructor that sets its properties from an input MmgColor object.
        /// </summary>
        /// <param name="obj">Input MmgColor object.</param>
        public MmgColor(MmgColor obj)
        {
            SetColor(obj.GetColor());
        }

        /// <summary>
        /// Constructor that sets the color to the given argument.
        /// </summary>
        /// <param name="C">The color to set the object.</param>
        public MmgColor(Color C)
        {
            c = C;
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual MmgColor Clone()
        {
            return new MmgColor(this);
        }

        /// <summary>
        /// Static helper method returns white.
        /// </summary>
        /// <returns>The color white.</returns>
        public static MmgColor GetWhite()
        {
            return new MmgColor(Color.White);
        }

        /// <summary>
        /// Static helper method returns black.
        /// </summary>
        /// <returns>The color black.</returns>
        public static MmgColor GetBlack()
        {
            return new MmgColor(Color.Black);
        }

        /// <summary>
        /// Static helper method returns red.
        /// </summary>
        /// <returns>The color red.</returns>
        public static MmgColor GetRed()
        {
            return new MmgColor(Color.Red);
        }

        /// <summary>
        /// Static helper method returns blue.
        /// </summary>
        /// <returns>The color blue.</returns>
        public static MmgColor GetBlue()
        {
            return new MmgColor(Color.Blue);
        }

        /// <summary>
        /// Static helper method returns green.
        /// </summary>
        /// <returns>The color green.</returns>
        public static MmgColor GetGreen()
        {
            return new MmgColor(Color.Green);
        }

        /// <summary>
        /// Static helper method returns cyan.
        /// </summary>
        /// <returns>The color cyan.</returns>
        public static MmgColor GetCyan()
        {
            return new MmgColor(Color.Cyan);
        }

        /// <summary>
        /// Static helper method returns gray.
        /// </summary>
        /// <returns>The color gray.</returns>
        public static MmgColor GetGray()
        {
            return new MmgColor(Color.Gray);
        }

        /// <summary>
        /// Static helper method returns dark gray.
        /// </summary>
        /// <returns>The color dark gray.</returns>
        public static MmgColor GetDarkGray()
        {
            return new MmgColor(Color.DarkGray);
        }

        /// <summary>
        /// Static helper method returns light gray.
        /// </summary>
        /// <returns>The color light gray.</returns>
        public static MmgColor GetLightGray()
        {
            return new MmgColor(Color.LightGray);
        }

        /// <summary>
        /// Static helper method returns magenta.
        /// </summary>
        /// <returns>The color magenta.</returns>
        public static MmgColor GetMagenta()
        {
            return new MmgColor(Color.Magenta);
        }

        /// <summary>
        /// Static helper method returns orange.
        /// </summary>
        /// <returns>The color orange.</returns>
        public static MmgColor GetOrange()
        {
            return new MmgColor(Color.Orange);
        }

        /// <summary>
        /// Static helper method returns pink.
        /// </summary>
        /// <returns>The color pink.</returns>
        public static MmgColor GetPink()
        {
            return new MmgColor(Color.Pink);
        }

        /// <summary>
        /// Static helper method returns yellow.
        /// </summary>
        /// <returns>The color yellow.</returns>
        public static MmgColor GetYellow()
        {
            return new MmgColor(Color.Yellow);
        }

        /// <summary>
        /// Static helper method returns lime green.
        /// </summary>
        /// <returns>The color lime green.</returns>
        public static MmgColor GetLimeGreen()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#DAF7A6");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns yellow orange.
        /// </summary>
        /// <returns>The color yellow orange.</returns>
        public static MmgColor GetYellowOrange()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#FFC300");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns red orange.
        /// </summary>
        /// <returns>The color red orange.</returns>
        public static MmgColor GetRedOrange()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#FF5733");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns purple red.
        /// </summary>
        /// <returns>The color purple red.</returns>
        public static MmgColor GetPurpleRed()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#C70039");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns dark red.
        /// </summary>
        /// <returns>The color dark red.</returns>
        public static MmgColor GetDarkRed()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#900C3F");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns dark blue.
        /// </summary>
        /// <returns>The color dark blue.</returns>
        public static MmgColor GetDarkBlue()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#0000A0");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns light blue.
        /// </summary>
        /// <returns>The color light blue.</returns>
        public static MmgColor GetLightBlue()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#ADD8E6");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns olive.
        /// </summary>
        /// <returns>The color olive.</returns>
        public static MmgColor GetOlive()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#808000");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns brown.
        /// </summary>
        /// <returns>The color brown.</returns>
        public static MmgColor GetBrown()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#A52A2A");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns maroon.
        /// </summary>
        /// <returns>The color maroon.</returns>
        public static MmgColor GetMaroon()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#800000");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns gun metal gray.
        /// </summary>
        /// <returns>The color gun metal gray.</returns>
        public static MmgColor GetGunMetalGray()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#2C3539");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns night.
        /// </summary>
        /// <returns>The color night.</returns>
        public static MmgColor GetNight()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#0C090A");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns midnight.
        /// </summary>
        /// <returns>The color midnight.</returns>
        public static MmgColor GetMidnight()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#2B1B17");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns charcoal.
        /// </summary>
        /// <returns>The color charcoal.</returns>
        public static MmgColor GetCharcoal()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#34282C");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns dark slate gray.
        /// </summary>
        /// <returns>The color dark slate gray.</returns>
        public static MmgColor GetDarkSlateGray()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#25383C");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns oil.
        /// </summary>
        /// <returns>The color oil.</returns>
        public static MmgColor GetOil()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#3B3131");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns calm blue.
        /// </summary>
        /// <returns>The color calm blue.</returns>
        public static MmgColor GetCalmBlue()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#3B8EFF");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns black cat.
        /// </summary>
        /// <returns>The color black cat.</returns>
        public static MmgColor GetBlackCat()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#413839");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns iridium.
        /// </summary>
        /// <returns>The color iridium.</returns>
        public static MmgColor GetIridium()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#3D3C3A");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns gray wolf.
        /// </summary>
        /// <returns>The color gray wolf.</returns>
        public static MmgColor GetGrayWolf()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#504A4B");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns gray dolphin.
        /// </summary>
        /// <returns>The color gray dolphin.</returns>
        public static MmgColor GetGrayDolphin()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#5C5858");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns carbon gray.
        /// </summary>
        /// <returns>The color carbon gray.</returns>
        public static MmgColor GetCarbonGray()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#625D5D");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns battleship gray.
        /// </summary>
        /// <returns>The color battleship gray.</returns>
        public static MmgColor GetBattleshipGray()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#848482");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns gray cloud.
        /// </summary>
        /// <returns>The color gray cloud.</returns>
        public static MmgColor GetGrayCloud()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#B6B6B4");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns gray goose.
        /// </summary>
        /// <returns>The color gray goose.</returns>
        public static MmgColor GetGrayGoose()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#D1D0CE");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns platinum.
        /// </summary>
        /// <returns>The color platinum.</returns>
        public static MmgColor GetPlatinum()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns metallic silver.
        /// </summary>
        /// <returns>The color metallic silver.</returns>
        public static MmgColor GetMetallicSilver()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#BCC6CC");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns blue gray.
        /// </summary>
        /// <returns>The color blue gray.</returns>
        public static MmgColor GetBlueGray()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#98AFC7");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns slate blue.
        /// </summary>
        /// <returns>The color slate blue.</returns>
        public static MmgColor GetSlateBlue()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#737CA1");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        //steel blue: #4863A0
        //navy blue: #000080
        //blue whale: #342D7E
        //sapphire blue: #2554C7
        //blue orcid: #1F45FC
        //blue lotus: #6960EC
        //crystal blue: #5CB3FF
        //power blue: #C6DEFF
        //blue green: #7BCCB5
        //teal: #008080
        //sea green: #4E8975
        //camouflage green: #78866B
        //dark forest green: #254117
        //clover green: #3EA055
        //zombie green: #54C571
        //mint green: #98FF98
        //harvest gold: #EDE275
        //corn yellow: #FFF380
        //blonde: #FBF6D9
        //tan brown: #ECE5B6
        //peach: #FFE5B4
        //mustard: #FFDB58
        //bright gold: #FDD017
        //cantaloupe: #FFA62F
        //deep peach: #FFCBA4
        //sand: #C2B280
        //brass: #B5A642
        //bronze: #CD7F32
        //copper: #B87333
        //wood: #966F33
        //mocha: #493D26
        //coffee: #6F4E37
        //sepia: #7F462C
        //pumpkin: #F87217
        //mango: #FF8040
        //dark orange: #F88017
        //tangerine: #E78A61
        //light coral: #E77471
        //scarlet: #FF2400
        //lava red: #E42217
        //grape fruit: #DC381F
        //cherry red: #C24641
        //cranberry: #9F000F
        //burgundy: #8C001A
        //chestnut: #954535
        //maroon: #810541
        //plum: #7D0552
        //puce: #7F5A58
        //rose: #E8ADAA
        //rose gold: #ECC5C0
        //light pink: #FAAFBA
        //flamingo pink: #F9A7B0
        //hot pink: #F660AB
        //magenta: #FF00FF
        //purple iris: #571B7E
        //purple haze: #4E387E
        //grape: #5E5A80
        //dark violet: #842DCE
        //lavender blue: #E3E4FA

        /// <summary>
        /// Static helper method that decodes an HTML color.
        /// </summary>
        /// <param name="htmlColor">The HTML color to decode.</param>
        /// <returns>A new MmgColor object with the HTML color.</returns>
        public static MmgColor GetDecodedColor(String htmlColor)
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(htmlColor);
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method that returns a transparent color.
        /// </summary>
        /// <returns>A new MmgColor object that has transparent color.</returns>
        public static MmgColor GetTransparent()
        {
            return new MmgColor(Microsoft.Xna.Framework.Color.Transparent);
        }

        /// <summary>
        /// Returns the color of this MmgColor object.
        /// </summary>
        /// <returns>The color of this object.</returns>
        public virtual Color GetColor()
        {
            return c;
        }

        /// <summary>
        /// Sets the color of this MmgColor object.
        /// </summary>
        /// <param name="C">The color of this object.</param>
        public virtual void SetColor(Color C)
        {
            c = C;
        }

        /// <summary>
        /// Gets a string representation of the current MmgColor object.
        /// </summary>
        /// <returns>A string representation of the MmgColor object.</returns>
        public virtual string ApiToString()
        {
            return "MmgColor: R: " + GetColor().R + " G: " + GetColor().G + " B: " + GetColor().B + " A: " + GetColor().A;
        }

        /// <summary>
        /// A method that checks to see if this MmgColor is equal to the passed in MmgColor.
        /// </summary>
        /// <param name="obj">The MmgColor object instance to test for equality.</param>
        /// <returns>Returns true if both MmgColor objects have the same color.</returns>
        public virtual bool ApiEquals(MmgColor obj)
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
            if (
                ((obj.GetColor() == null && GetColor() == null) || (obj.GetColor() != null && GetColor() != null && obj.GetColor().Equals(GetColor())))
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}