package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * A helper class that provides logging functionality. 
 * This class is more geared towards Android logging. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgDebug {
    
    /**
     * Flag that turns logging on or off.
     */
    public static boolean DEBUGGING_ON = true;

    /**
     * The prefix to add to all logged lines.
     */
    public static String appName = "MmgApi.MmgDebug";

    /**
     * A static helper method for logging.
     *
     * @param s     The string to log.
     */
    public static void wr(String s) {
        if (DEBUGGING_ON == true) {
            MmgApiUtils.wr(appName + ": " + s);
        }
    }

    /**
     * A static helper method for logging.
     *
     * @param key   The key to use to log the line.
     * @param s     The line to log.
     */
    public static void wr(String key, String s) {
        if (DEBUGGING_ON == true) {
            MmgApiUtils.wr(key + ": " + s);
        }
    }

    /**
     * A static helper method for timestamped logging.
     *
     * @param s     The string to log.
     */
    public static void wrTs(String s) {
        if (DEBUGGING_ON == true) {
            MmgApiUtils.wr(appName + "[" + System.currentTimeMillis() + "]: " + s);
        }
    }
}