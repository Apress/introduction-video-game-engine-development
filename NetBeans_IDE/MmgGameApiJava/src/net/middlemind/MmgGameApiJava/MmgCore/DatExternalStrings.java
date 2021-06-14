package net.middlemind.MmgGameApiJava.MmgCore;

import java.util.Hashtable;

/**
 * DatExternalStrings is a class used to hold static references to strings configured in the class and referenced via a Hashtable.
 * Created by Middlemind Games 02/25/2020
 * 
 * @author Victor G. Brusca
 */
public class DatExternalStrings {
    
    /**
     * The EXT static class field holds references to all the strings loaded by the LOAD_EXT_STRINGS static lass method. 
     * The class is designed to support multiple languages through the use of a language code but is not configured to do by default.
     */
    public static Hashtable<Integer, String> EXT = new Hashtable<Integer, String>();
    
    public static int EXT_TALK_TREEFOLK_NO_CONVO = 0;
    public static int EXT_TALK_TREEFOLK_CONVO = 1;
    public static int EXT_TALK_PIGGY_NO_CONVO = 2;
    public static int EXT_TALK_PIGGY_CONVO = 3;
    public static int EXT_TALK_NOBODY_HERE = 4;
    public static int EXT_TALK_NOTHING_TO_SAY = 5;
    public static int EXT_TALK_SQUARE_BUSH_ALIVE = 6;
    public static int EXT_TALK_SQUARE_BUSH_DEAD = 7;
    public static int EXT_TALK_SQUARE_BUSH_SNOWY_2_ALIVE = 8;
    public static int EXT_TALK_SQUARE_BUSH_SNOWY_1_ALIVE = 9;    
    public static int EXT_TALK_IRRITATION_1 = 10;
    public static int EXT_TALK_IRRITATION_2 = 11;
    public static int EXT_TALK_IRRITATION_3 = 12;  
    public static int EXT_INVESTIGATE_TREEFOLK = 13;
    public static int EXT_INVESTIGATE_PIGGY = 14;
    public static int EXT_INVESTIGATE_NPC_FREAK = 15;
    public static int EXT_INVESTIGATE_SQUARE_BUSH_ALIVE = 16;
    public static int EXT_INVESTIGATE_SQUARE_BUSH_DEAD = 17;
    public static int EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_2_ALIVE = 18;
    public static int EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_2_DEAD = 19;
    public static int EXT_INVESTIGATE_YOU_FOUND_SOMETHING = 20;
    public static int EXT_TALK_YOU_FOUND_SOMETHING = 21;
    public static int EXT_INVESTIGATE_NOTHING_TO_INVESTIGATE = 22;
    public static int EXT_INVESTIGATE_IRRITATION_1 = 23;
    public static int EXT_INVESTIGATE_IRRITATION_2 = 24;
    public static int EXT_INVESTIGATE_IRRITATION_3 = 25;
    public static int EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_1_ALIVE = 26;
    public static int EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_1_DEAD = 27;    
    public static int EXT_SEARCH_IRRITATION_1 = 28;
    public static int EXT_SEARCH_IRRITATION_2 = 29;
    public static int EXT_SEARCH_IRRITATION_3 = 30;
    public static int EXT_SEARCH_MESSAGE = 31;    
    
    /**
     * The DEFAULT_LANGUAGE static class string can be used to load strings of a different language
     * in the static class method, LOAD_EXT_STRINGS.
     */
    public static String DEFAULT_LANGUAGE = "en";
    
    /**
     * The LOAD_EXT_STRINGS static class method is used to load strings by static ID into the EXT Hashtable.
     * This form of the method takes no arguments and calls the LOAD_EXT_STRINGS static class method that takes
     * a language code.
     */
    public static void LOAD_EXT_STRINGS() {
        LOAD_EXT_STRINGS(DEFAULT_LANGUAGE);
    }
    
    /**
     * The LOAD_EXT_STRINGS static class method is used to load strings by static ID into the EXT Hashtable.
     * This form of the static class method takes a language code argument that can be used to load string of
     * different languages.
     * 
     * @param langCode      A string argument the defines a language code that can be used to load different strings based on the language code.
     */
    public static void LOAD_EXT_STRINGS(String langCode) {
        //Called when loading bar complete generic event is processed
        if (EXT.contains(EXT_TALK_NOBODY_HERE) == false) {
            EXT.put(EXT_TALK_NOBODY_HERE, "There's nobody here to talk to.");
        }
        
        if (EXT.contains(EXT_TALK_TREEFOLK_NO_CONVO) == false) {
            EXT.put(EXT_TALK_TREEFOLK_NO_CONVO, "Hello... hello tree. I can hear you, speak up, speak louder... I can... I can almost hear you. Not so much really. I was just kidding, this is a tree afterall.");
        }
        
        if (EXT.contains(EXT_TALK_TREEFOLK_CONVO) == false) {
            EXT.put(EXT_TALK_TREEFOLK_CONVO, "Wow, we're really going to do this are we? We're going to talk to a tree, ok. Let's get this over with.");
        }
        
        if (EXT.contains(EXT_TALK_PIGGY_NO_CONVO) == false) {
            EXT.put(EXT_TALK_PIGGY_NO_CONVO, "Oink, oink, oink, squeeeeaaallllll. Oinky oink oink. Hi little piggy. Who's a good piggy? who's a good piggy? I mean um... ughhh... golly I hope nobody was around to hear that.");
        }
        
        if (EXT.contains(EXT_TALK_PIGGY_CONVO) == false) {
            EXT.put(EXT_TALK_PIGGY_CONVO, "Well I haven't really been in control of my self these days now have I? Here we go...");
        }
        
        if (EXT.contains(EXT_TALK_NOTHING_TO_SAY) == false) {
            EXT.put(EXT_TALK_NOTHING_TO_SAY, "This person has nothing to say to you.");
        }

        if (EXT.contains(EXT_TALK_SQUARE_BUSH_ALIVE) == false) {
            EXT.put(EXT_TALK_SQUARE_BUSH_ALIVE, "Like I can't really be trying to talk to this bush. You feelin ok?");
        }
        
        if (EXT.contains(EXT_TALK_SQUARE_BUSH_DEAD) == false) {
            EXT.put(EXT_TALK_SQUARE_BUSH_DEAD, "I don't... I don't know what to say. This is awkward.");
        }    
        
        if (EXT.contains(EXT_TALK_SQUARE_BUSH_SNOWY_2_ALIVE) == false) {
            EXT.put(EXT_TALK_SQUARE_BUSH_SNOWY_2_ALIVE, "Hello little snowy bush. How are you today?");
        }
        
        if (EXT.contains(EXT_TALK_SQUARE_BUSH_SNOWY_1_ALIVE) == false) {
            EXT.put(EXT_TALK_SQUARE_BUSH_SNOWY_1_ALIVE, "My snowy bush is a little rusty but I'll give it a shot. I'm just kidding I don't speak plant.");
        }

        if (EXT.contains(EXT_TALK_IRRITATION_1) == false) {
            EXT.put(EXT_TALK_IRRITATION_1, "Are we really gonna try talking to this thing again?");
        }

        if (EXT.contains(EXT_TALK_IRRITATION_2) == false) {
            EXT.put(EXT_TALK_IRRITATION_2, "Um... seriously?");
        }

        if (EXT.contains(EXT_TALK_IRRITATION_3) == false) {
            EXT.put(EXT_TALK_IRRITATION_3, "I don't even know what to say at this point.");
        }
        
        if (EXT.contains(EXT_INVESTIGATE_TREEFOLK) == false) {
            EXT.put(EXT_INVESTIGATE_TREEFOLK, "Hmmmmm, after much consideration and deliberation I have decided that this is a tree. Funny, I could have sworn I heard someone chuckle.");
        }

        if (EXT.contains(EXT_INVESTIGATE_PIGGY) == false) {
            EXT.put(EXT_INVESTIGATE_PIGGY, "After some amount of investigation, some awful smells, and what was overall a fairly embarrassing occurance, I've concluded that this is a pig.");
        }

        if (EXT.contains(EXT_INVESTIGATE_NPC_FREAK) == false) {
            EXT.put(EXT_INVESTIGATE_NPC_FREAK, "You try to investigate the person in front of you but they start screaming \"Stranger Danger!\", so you stop. Maybe you should try talking to them first.");
        }

        if (EXT.contains(EXT_INVESTIGATE_SQUARE_BUSH_ALIVE) == false) {
            EXT.put(EXT_INVESTIGATE_SQUARE_BUSH_ALIVE, "Ok, soooo, that's a bush.");
        }

        if (EXT.contains(EXT_INVESTIGATE_SQUARE_BUSH_DEAD) == false) {
            EXT.put(EXT_INVESTIGATE_SQUARE_BUSH_DEAD, "Man somebody should've watered this thing. Oh, I mean, that's a dead bush.");
        } 
        
        if (EXT.contains(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_2_ALIVE) == false) {
            EXT.put(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_2_ALIVE, "A snowy little bush. Ugh, this lemon flavored snow tastes terrible.");
        }
        
        if (EXT.contains(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_2_DEAD) == false) {
            EXT.put(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_2_DEAD, "Your typical garden variety 8-bit square bush with a litte snow on top.");
        }  
        
        if (EXT.contains(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_1_ALIVE) == false) {
            EXT.put(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_1_ALIVE, "A very rare bush that is able to produce snow for a hat. Wait nevermind.");
        }
        
        if (EXT.contains(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_1_DEAD) == false) {
            EXT.put(EXT_INVESTIGATE_SQUARE_BUSH_SNOWY_1_DEAD, "You guessed it, it's a dead bush.");
        }        
                
        if (EXT.contains(EXT_INVESTIGATE_YOU_FOUND_SOMETHING) == false) {
            EXT.put(EXT_INVESTIGATE_YOU_FOUND_SOMETHING, "Looks like you found something. Congrats! Image Idx: ");
        }

        if (EXT.contains(EXT_TALK_YOU_FOUND_SOMETHING) == false) {
            EXT.put(EXT_TALK_YOU_FOUND_SOMETHING, "Looks like you are talking to something. Congrats! Image Idx: ");
        }

        if(EXT.contains(EXT_INVESTIGATE_NOTHING_TO_INVESTIGATE) == false) {
            EXT.put(EXT_INVESTIGATE_NOTHING_TO_INVESTIGATE, "There's nothing here to investigate.");
        }
        
        if(EXT.contains(EXT_INVESTIGATE_IRRITATION_1) == false) {
            EXT.put(EXT_INVESTIGATE_IRRITATION_1, "Ok, wait, so now you want me to investigate here? Jk.");
        }
        
        if(EXT.contains(EXT_INVESTIGATE_IRRITATION_2) == false) {
            EXT.put(EXT_INVESTIGATE_IRRITATION_2, "AOL keyword redundant am I right? What you mean what's an AOL keyword?");
        }

        if(EXT.contains(EXT_INVESTIGATE_IRRITATION_3) == false) {
            EXT.put(EXT_INVESTIGATE_IRRITATION_3, "If I have to investigate this thing one more time, why I'm gonna just... just... wall I can't think of something right now. But when I do...");
        }

        if(EXT.contains(EXT_SEARCH_IRRITATION_1) == false) {
            EXT.put(EXT_SEARCH_IRRITATION_1, "Surprise, surprise, and here I thought you were going to do something different. Shoulda known.");
        }

        if(EXT.contains(EXT_SEARCH_IRRITATION_2) == false) {
            EXT.put(EXT_SEARCH_IRRITATION_2, "I mean like how many times are we gonna go through this same thing expecting a different result.");
        }

        if(EXT.contains(EXT_SEARCH_IRRITATION_3) == false) {
            EXT.put(EXT_SEARCH_IRRITATION_3, "Look it's not you, it's me, ok. I'm the one who just can't take searching anymore.");
        }

        if(EXT.contains(EXT_SEARCH_MESSAGE) == false) {
            EXT.put(EXT_SEARCH_MESSAGE, "After searching you find...");
        }        
    }
}