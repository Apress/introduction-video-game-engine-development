using System;
using System.Threading;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The frame rate worker thread, runs the main loop while tracking frame rate information. 
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class RunFrameRate
    {
        /// <summary>
        /// The MainFrame that houses the game, connection between JFrame, JPanel and the game.
        /// </summary>
        public readonly MainFrame mf;

        /// <summary>
        /// Target frames per second.
        /// </summary>
        public readonly long tFps;

        /// <summary>
        /// Target frame time.
        /// </summary>
        public readonly long tFrameTime;

        /// <summary>
        /// Actual frames per second. 
        /// The actual frames the game might run at if it wasn't controlled.
        /// </summary>
        public long aFps;

        /// <summary>
        /// Real frames per second. 
        /// The controlled frames per second.
        /// </summary>
        public long rFps;

        /// <summary>
        /// Last frame stop time.
        /// </summary>
        public long frameStart;

        /// <summary>
        /// Last frame start time.
        /// </summary>
        public long frameStop;

        /// <summary>
        /// Frame time.
        /// </summary>
        public long frameTime;

        /// <summary>
        /// Frame time difference from actual time to target time. 
        /// Used to sleep the few milliseconds between the target time and the actual time if the
        /// actual time is less than the target time.
        /// </summary>
        public long frameTimeDiff;

        /// <summary>
        /// Pauses the current render loop.
        /// </summary>
        public static bool PAUSE = false;

        /// <summary>
        /// Exits the current render loop.
        /// </summary>
        public static bool RUNNING = true;

        /// <summary>
        /// Constructor, sets the MainFrame, JFrame, and the target frames per second.
        /// </summary>
        /// <param name="Mf">The MainFrame, JFrame for this game.</param>
        /// <param name="Fps">The target frames per second to use for the main loop.</param>
        public RunFrameRate(MainFrame Mf, long Fps)
        {
            mf = Mf;
            tFps = Fps;
            tFrameTime = (1000 / tFps);
            MmgHelper.wr("RunFrameRate: Target Frame Rate: " + tFps);
            MmgHelper.wr("RunFrameRate: Target Frame Time: " + tFrameTime);
        }

        /// <summary>
        /// Pauses the main loop.
        /// </summary>
        public static void Pause()
        {
            PAUSE = true;
        }

        /// <summary>
        /// Gets the pause status of the main loop.
        /// </summary>
        /// <returns>The pause status of the main loop.</returns>
        public static bool IsPaused()
        {
            return PAUSE;
        }

        /// <summary>
        /// UnPauses the main loop.
        /// </summary>
        public static void UnPause()
        {
            PAUSE = false;
        }

        /// <summary>
        /// Stops the main loop from running.
        /// </summary>
        public static void StopRunning()
        {
            RUNNING = false;
        }

        /// <summary>
        /// Gets the running status of the main loop.
        /// </summary>
        /// <returns>True if running, false otherwise.</returns>
        public static bool IsRunning()
        {
            return RUNNING;
        }

        /// <summary>
        /// Starts running the main loop but only if run is called again. 
        /// Once the main loop exits the run method returns.
        /// </summary>
        public static void StartRunning()
        {
            RUNNING = true;
        }

        /// <summary>
        /// Gets the actual frame rate of the game.
        /// </summary>
        /// <returns>The game's frame rate.</returns>
        public long GetActualFrameRate()
        {
            return aFps;
        }

        /// <summary>
        /// Gets the target frame rate of the game.
        /// </summary>
        /// <returns>The game's target frame rate.</returns>
        public long GetTargetFrameRate()
        {
            return tFps;
        }

        /// <summary>
        /// The main drawing loop of the game.
        /// </summary>
        public void run()
        {
            while (RunFrameRate.RUNNING == true)
            {
                frameStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                if (RunFrameRate.PAUSE == false)
                {
                    mf.Redraw();
                }

                frameStop = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                frameTime = (frameStop - frameStart) + 1;
                aFps = (1000 / frameTime);

                frameTimeDiff = tFrameTime - frameTime;
                if (frameTimeDiff > 0)
                {
                    try
                    {
                        Thread.Sleep((int)frameTimeDiff);
                    }
                    catch (Exception e)
                    {
                        MmgHelper.wrErr(e);
                    }
                }

                frameStop = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                frameTime = (frameStop - frameStart) + 1;
                rFps = (1000 / frameTime);
                mf.SetFrameRate(aFps, rFps);
            }
        }
    }
}