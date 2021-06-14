using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class for handling some logging and other common methods. 
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgApiUtils
    {
        /// <summary>
        /// Turns logging on or off for this utility class.
        /// </summary>
        public static bool LOGGING = true;

        /// <summary>
        /// Centralized logging method for standard out logging.
        /// </summary>
        /// <param name="s">The string to be logged.</param>
        public static void wr(string s)
        {
            if (MmgApiUtils.LOGGING == true)
            {
                System.Diagnostics.Debug.WriteLine(s);
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Centralized logging method for standard error logging.
        /// </summary>
        /// <param name="e">The exception to be logged.</param>
        public static void wrErr(Exception e)
        {
            if (MmgApiUtils.LOGGING == true)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                Console.WriteLine(e.Message);

                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Centralized logging method for standard err logging.
        /// </summary>
        /// <param name="s">The string to be logged.</param>
        public static void wrErr(string s)
        {
            if (MmgApiUtils.LOGGING == true)
            {
                System.Diagnostics.Debug.WriteLine(s);
                Console.WriteLine(s);
            }
        }
    }
}