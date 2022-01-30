package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.*;

/**
 * Class that wraps the lower level color object. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgColor {
    
    /**
     * The color of this object.
     */
    private Color c;

    /**
     * Constructor of this object.
     */
    public MmgColor() {
        c = Color.WHITE;
    }

    /**
     * Constructor that sets its properties from an input MmgColor object.
     *
     * @param obj     Input MmgColor object.
     */
    public MmgColor(MmgColor obj) {
        SetColor(obj.GetColor());
    }

    /**
     * Constructor that sets the color to the given argument.
     *
     * @param C     The color to set the object.
     */
    public MmgColor(Color C) {
        c = C;
    }

    /**
     * Creates a typed clone of this class.
     *
     * @return      A typed clone of this class.
     */
    public MmgColor Clone() {
        return new MmgColor(this);
    }

    /**
     * Static helper method returns white.
     *
     * @return      The color white.
     */
    public static MmgColor GetWhite() {
        return new MmgColor(Color.WHITE);
    }

    /**
     * Static helper method returns black.
     *
     * @return      The color black.
     */
    public static MmgColor GetBlack() {
        return new MmgColor(Color.BLACK);
    }

    /**
     * Static helper method returns red.
     * 
     * @return      The color red.
     */
    public static MmgColor GetRed() {
        return new MmgColor(Color.RED);
    }
    
    /**
     * Static helper method returns blue.
     * 
     * @return      The color blue.
     */
    public static MmgColor GetBlue() {
        return new MmgColor(Color.BLUE);
    }
    
    /**
     * Static helper method returns green.
     * 
     * @return      The color green.
     */
    public static MmgColor GetGreen() {
        return new MmgColor(Color.GREEN);
    }
    
    /**
     * Static helper method returns cyan.
     * 
     * @return      The color cyan.
     */
    public static MmgColor GetCyan() {
        return new MmgColor(Color.CYAN);
    }
    
    /**
     * Static helper method returns gray.
     * 
     * @return      The color gray.
     */
    public static MmgColor GetGray() {
        return new MmgColor(Color.GRAY);
    }
    
    /**
     * Static helper method returns dark gray.
     * 
     * @return      The color dark gray.
     */
    public static MmgColor GetDarkGray() {
        return new MmgColor(Color.DARK_GRAY);
    }
    
    /**
     * Static helper method returns light gray.
     * 
     * @return      The color light gray.
     */
    public static MmgColor GetLightGray() {
        return new MmgColor(Color.LIGHT_GRAY);
    }
    
    /**
     * Static helper method returns magenta.
     * 
     * @return      The color magenta.
     */
    public static MmgColor GetMagenta() {
        return new MmgColor(Color.MAGENTA);
    }
    
    /**
     * Static helper method returns orange.
     * 
     * @return      The color orange.
     */
    public static MmgColor GetOrange() {
        return new MmgColor(Color.ORANGE);
    }
    
    /**
     * Static helper method returns pink.
     * 
     * @return      The color pink.
     */
    public static MmgColor GetPink() {
        return new MmgColor(Color.PINK);
    }
    
    /**
     * Static helper method returns yellow.
     * 
     * @return      The color yellow.
     */
    public static MmgColor GetYellow() {
        return new MmgColor(Color.YELLOW);
    }
     
    /**
     * Static helper method returns lime green.
     * 
     * @return      The color lime green.
     */
    public static MmgColor GetLimeGreen() {
        return new MmgColor(Color.decode("#DAF7A6"));
    }
    
    /**
     * Static helper method returns yellow orange.
     * 
     * @return      The color yellow orange.
     */
    public static MmgColor GetYellowOrange() {
        return new MmgColor(Color.decode("#FFC300"));
    }
    
    /**
     * Static helper method returns red orange.
     * 
     * @return      The color red orange.
     */
    public static MmgColor GetRedOrange() {
        return new MmgColor(Color.decode("#FF5733"));
    }
    
    /**
     * Static helper method returns purple red.
     * 
     * @return      The color purple red.
     */
    public static MmgColor GetPurpleRed() {
        return new MmgColor(Color.decode("#C70039"));
    }
    
    /**
     * Static helper method returns dark red.
     * 
     * @return      The color dark red.
     */
    public static MmgColor GetDarkRed() {
        return new MmgColor(Color.decode("#900C3F"));
    }
    
    /**
     * Static helper method returns dark blue.
     * 
     * @return      The color dark blue.
     */
    public static MmgColor GetDarkBlue() {
        return new MmgColor(Color.decode("#0000A0"));
    }
    
    /**
     * Static helper method returns light blue.
     * 
     * @return      The color light blue.
     */
    public static MmgColor GetLightBlue() {
        return new MmgColor(Color.decode("#ADD8E6"));
    }
    
    /**
     * Static helper method returns olive.
     * 
     * @return      The color olive.
     */
    public static MmgColor GetOlive() {
        return new MmgColor(Color.decode("#808000"));
    }
    
    /**
     * Static helper method returns brown.
     * 
     * @return      The color brown.
     */
    public static MmgColor GetBrown() {
        return new MmgColor(Color.decode("#A52A2A"));
    }
    
    /**
     * Static helper method returns maroon.
     * 
     * @return      The color maroon.
     */
    public static MmgColor GetMaroon() {
        return new MmgColor(Color.decode("#800000"));
    }
    
    /**
     * Static helper method returns gun metal gray.
     * 
     * @return      The color gun metal gray.
     */
    public static MmgColor GetGunMetalGray() {
        return new MmgColor(Color.decode("#2C3539"));
    }
    
    /**
     * Static helper method returns night.
     * 
     * @return      The color night.
     */
    public static MmgColor GetNight() {
        return new MmgColor(Color.decode("#0C090A"));
    }
    
    /**
     * Static helper method returns midnight.
     * 
     * @return      The color midnight.
     */
    public static MmgColor GetMidnight() {
        return new MmgColor(Color.decode("#2B1B17"));
    }
    
    /**
     * Static helper method returns charcoal.
     * 
     * @return      The color charcoal.
     */
    public static MmgColor GetCharcoal() {
        return new MmgColor(Color.decode("#34282C"));
    }
    
    /**
     * Static helper method returns dark slate gray.
     * 
     * @return      The color dark slate gray.
     */
    public static MmgColor GetDarkSlateGray() {
        return new MmgColor(Color.decode("#25383C"));
    }
    
    /**
     * Static helper method returns oil.
     * 
     * @return      The color oil.
     */
    public static MmgColor GetOil() {
        return new MmgColor(Color.decode("#3B3131"));
    }

    /**
     * Static helper method returns calm blue.
     * 
     * @return      The color calm blue.
     */
    public static MmgColor GetCalmBlue() {
        return new MmgColor(Color.decode("#3B8EFF"));
    }
    
    /**
     * Static helper method returns black cat.
     * 
     * @return      The color black cat.
     */
    public static MmgColor GetBlackCat() {
        return new MmgColor(Color.decode("#413839"));
    }
    
    /**
     * Static helper method returns iridium.
     * 
     * @return      The color iridium.
     */
    public static MmgColor GetIridium() {
        return new MmgColor(Color.decode("#3D3C3A"));
    }
    
    /**
     * Static helper method returns gray wolf.
     * 
     * @return      The color gray wolf.
     */
    public static MmgColor GetGrayWolf() {
        return new MmgColor(Color.decode("#504A4B"));
    }
    
    /**
     * Static helper method returns gray dolphin.
     * 
     * @return      The color gray dolphin.
     */
    public static MmgColor GetGrayDolphin() {
        return new MmgColor(Color.decode("#5C5858"));
    }
    
    /**
     * Static helper method returns carbon gray.
     * 
     * @return      The color carbon gray.
     */
    public static MmgColor GetCarbonGray() {
        return new MmgColor(Color.decode("#625D5D"));
    }

    /**
     * Static helper method returns battleship gray.
     * 
     * @return      The color battleship gray.
     */
    public static MmgColor GetBattleshipGray() {
        return new MmgColor(Color.decode("#848482"));
    }
    
    /**
     * Static helper method returns gray cloud.
     * 
     * @return      The color gray cloud.
     */
    public static MmgColor GetGrayCloud() {
        return new MmgColor(Color.decode("#B6B6B4"));
    }

    /**
     * Static helper method returns gray goose.
     * 
     * @return      The color gray goose.
     */
    public static MmgColor GetGrayGoose() {
        return new MmgColor(Color.decode("#D1D0CE"));
    }
    
    /**
     * Static helper method returns platinum.
     * 
     * @return      The color platinum.
     */
    public static MmgColor GetPlatinum() {
        return new MmgColor(Color.decode("#E5E4E2"));
    }
    
    /**
     * Static helper method returns metallic silver.
     * 
     * @return      The color metallic silver.
     */
    public static MmgColor GetMetallicSilver() {
        return new MmgColor(Color.decode("#BCC6CC"));
    }
    
    /**
     * Static helper method returns blue gray.
     * 
     * @return      The color blue gray.
     */
    public static MmgColor GetBlueGray() {
        return new MmgColor(Color.decode("#98AFC7"));
    }
    
    /**
     * Static helper method returns slate blue.
     * 
     * @return      The color slate blue.
     */
    public static MmgColor GetSlateBlue() {
        return new MmgColor(Color.decode("#737CA1"));
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
        
    /**
     * Static helper method that decodes an HTML color.
     * 
     * @param htmlColor     The HTML color to decode.
     * @return              A new MmgColor object with the HTML color.
     */
    public static MmgColor GetDecodedColor(String htmlColor) {
        return new MmgColor(Color.decode(htmlColor));
    }    
    
    /**
     * Static helper method that returns a transparent color.
     * 
     * @return      A new MmgColor object that has transparent color.
     */
    public static MmgColor GetTransparent() {
        return new MmgColor(new Color(0f, 0f, 0f, 0f));
    }    
    
    /**
     * Returns the color of this MmgColor object.
     *
     * @return          The color of this object.
     */
    public Color GetColor() {
        return c;
    }

    /**
     * Sets the color of this MmgColor object.
     *
     * @param C         The color of this object.
     */
    public void SetColor(Color C) {
        c = C;
    }
    
    /**
     * Gets a string representation of the current MmgColor object.
     * 
     * @return      A string representation of the MmgColor object.
     */
    public String ApiToString() {
        return "MmgColor: R: " + GetColor().getRed() + " G: " + GetColor().getGreen() + " B: " + GetColor().getBlue() + " A: " + GetColor().getAlpha();
    }
    
    /**
     * A method that checks to see if this MmgColor is equal to the passed in MmgColor.
     * 
     * @param obj     The MmgColor object instance to test for equality.
     * @return      Returns true if both MmgColor objects have the same color.
     */
    public boolean ApiEquals(MmgColor obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
                 
        boolean ret = false;
        if (
            ((obj.GetColor() == null && GetColor() == null) || (obj.GetColor() != null && GetColor() != null && obj.GetColor().equals(GetColor())))
        ) {
            ret = true;
        }
        return ret;
    }
}