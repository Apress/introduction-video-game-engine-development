package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class for handling some logging and other common methods. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgApiUtils {
    
    /**
     * Turns logging on or off for this utility class.
     */
    public static boolean LOGGING = true;

    /**
     * Centralized logging method for standard out logging.
     *
     * @param s     The string to be logged.
     */
    public static void wr(String s) {
        if (MmgApiUtils.LOGGING == true) {
            System.out.println(s);
        }
    }

    /**
     * Centralized logging method for standard error logging.
     *
     * @param e     The exception to be logged.
     */
    public static void wrErr(Exception e) {
        if (MmgApiUtils.LOGGING == true) {
            System.err.println(e.getMessage());
            StackTraceElement[] els = e.getStackTrace();
            int len = els.length;
            for (int i = 0; i < len; i++) {
                System.err.println(els[i].toString());
            }
        }
    }

    /**
     * Centralized logging method for standard err logging.
     *
     * @param s     The string to be logged.
     */
    public static void wrErr(String s) {
        if (MmgApiUtils.LOGGING == true) {
            System.err.println(s);
        }
    }
}