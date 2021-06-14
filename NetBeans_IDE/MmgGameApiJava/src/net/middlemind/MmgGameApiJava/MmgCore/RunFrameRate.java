package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * The frame rate worker thread, runs the main loop while tracking frame rate information. 
 * Created by Middlemind Games 08/01/2015
 *
 * @author Victor G. Brusca
 */
public class RunFrameRate implements Runnable {

    /**
     * The MainFrame that houses the game, connection between JFrame, JPanel and the game.
     */
    public final MainFrame mf;

    /**
     * Target frames per second.
     */
    public final long tFps;

    /**
     * Target frame time.
     */
    public final long tFrameTime;

    /**
     * Actual frames per second. 
     * The actual frames the game might run at if it wasn't controlled.
     */
    public long aFps;
    
    /**
     * Real frames per second. 
     * The controlled frames per second.
     */
    public long rFps;

    /**
     * Last frame stop time.
     */
    public long frameStart;

    /**
     * Last frame start time.
     */
    public long frameStop;

    /**
     * Frame time.
     */
    public long frameTime;

    /**
     * Frame time difference from actual time to target time. 
     * Used to sleep the few milliseconds between the target time and the actual time if the
     * actual time is less than the target time.
     */
    public long frameTimeDiff;

    /**
     * Pauses the current render loop.
     */
    public static boolean PAUSE = false;

    /**
     * Exits the current render loop.
     */
    public static boolean RUNNING = true;

    /**
     * Constructor, sets the MainFrame, JFrame, and the target frames per second.
     *
     * @param Mf        The MainFrame, JFrame for this game.
     * @param Fps       The target frames per second to use for the main loop.
     */
    public RunFrameRate(MainFrame Mf, long Fps) {
        mf = Mf;
        tFps = Fps;
        tFrameTime = (1000 / tFps);
        MmgHelper.wr("RunFrameRate: Target Frame Rate: " + tFps);
        MmgHelper.wr("RunFrameRate: Target Frame Time: " + tFrameTime);
    }

    /**
     * Pauses the main loop.
     */
    public static void Pause() {
        PAUSE = true;
    }

    /**
     * Gets the pause status of the main loop.
     *
     * @return      The pause status of the main loop.
     */
    public static boolean IsPaused() {
        return PAUSE;
    }

    /**
     * UnPauses the main loop.
     */
    public static void UnPause() {
        PAUSE = false;
    }

    /**
     * Stops the main loop from running.
     */
    public static void StopRunning() {
        RUNNING = false;
    }

    /**
     * Gets the running status of the main loop.
     *
     * @return      True if running, false otherwise.
     */
    public static boolean IsRunning() {
        return RUNNING;
    }

    /**
     * Starts running the main loop but only if run is called again. 
     * Once the main loop exits the run method returns.
     */
    public static void StartRunning() {
        RUNNING = true;
    }

    /**
     * Gets the actual frame rate of the game.
     *
     * @return      The game's frame rate.
     */
    public long GetActualFrameRate() {
        return aFps;
    }

    /**
     * Gets the target frame rate of the game.
     *
     * @return      The game's target frame rate.
     */
    public long GetTargetFrameRate() {
        return tFps;
    }

    /**
     * The main drawing loop of the game.
     */
    @Override
    @SuppressWarnings("SleepWhileInLoop")
    public void run() {
        while (RunFrameRate.RUNNING == true) {
            frameStart = System.currentTimeMillis();

            if (RunFrameRate.PAUSE == false) {
                mf.Redraw();
            }

            frameStop = System.currentTimeMillis();
            frameTime = (frameStop - frameStart) + 1;
            aFps = (1000 / frameTime);

            frameTimeDiff = tFrameTime - frameTime;
            if (frameTimeDiff > 0) {
                try {
                    Thread.sleep((int) frameTimeDiff);
                } catch (Exception e) {
                    MmgHelper.wrErr(e);
                }
            }

            frameStop = System.currentTimeMillis();
            frameTime = (frameStop - frameStart) + 1;
            rFps = (1000 / frameTime);
            mf.SetFrameRate(aFps, rFps);
        }
    }
}