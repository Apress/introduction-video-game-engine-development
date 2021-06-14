using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A helper class that provides logging functionality. 
    /// This class is more geared towards Android logging.
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgDebug
    {
        /// <summary>
        /// Flag that turns logging on or off.
        /// </summary>
        public static bool DEBUGGING_ON = true;

        /// <summary>
        /// The prefix to add to all logged lines.
        /// </summary>
        public static string appName = "MmgApi.MmgDebug";

        /// <summary>
        /// A static helper method for logging.
        /// </summary>
        /// <param name="s">The string to log.</param>
        public static void wr(string s)
        {
            if (DEBUGGING_ON == true)
            {
                MmgApiUtils.wr(appName + ": " + s);
            }
        }

        /// <summary>
        /// A static helper method for logging.
        /// </summary>
        /// <param name="key">The key to use to log the line.</param>
        /// <param name="s">The line to log.</param>
        public static void wr(string key, string s)
        {
            if (DEBUGGING_ON == true)
            {
                MmgApiUtils.wr(key + ": " + s);
            }
        }

        /// <summary>
        /// A static helper method for timestamped logging.
        /// </summary>
        /// <param name="s">The string to log.</param>
        public static void wrTs(String s)
        {
            if (DEBUGGING_ON == true)
            {
                MmgApiUtils.wr(appName + " [" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "]: " + s);
            }
        }
    }
}