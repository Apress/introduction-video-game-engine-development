using System;
using System.Threading;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The GamePadRunner class is a threaded class that is used to connect to a USB GamePad via JInput and determine the state of each
    /// of the target buttons at interval.
    /// Created by Middlemind Games 01/05/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class GamePadHubRunner
    {
        /// <summary>
        /// A reference to the GpioHub to the GpioHubRunner will monitor.
        /// </summary>
        public GamePadHub gamePadHub;

        /// <summary>
        /// The interval in ms that the GpioHubRunner will update the state of the GPIO pins.
        /// </summary>
        public long pollingIntervalMs = 10;

        /// <summary>
        /// A class field used to mark the start time of a polling interval.
        /// </summary>
        public long start;

        /// <summary>
        /// A class field used to mark the stop time of a polling interval.
        /// </summary>
        public long stop;

        /// <summary>
        /// A class field used to mark a time difference for measuring polling intervals.
        /// </summary>
        public long diff;

        /// <summary>
        /// A class field used to control if the GpioHubRunner is running. 
        /// </summary>
        public bool running = false;

        /// <summary>
        /// An instance of a class that implements that GamePadSimple interface, used to call dpad, A, B, event methods.
        /// </summary>
        public GamePadSimple gamePad;

        /// <summary>
        /// The main GpioHubRunner constructor that sets the class up for polling the GpioHub for GPIO pin states and determines
        /// the GamePadSimple interface for calling button event methods.
        /// </summary>
        /// <param name="hub">A method argument that sets the GpioHub of GPIO pins to monitor.</param>
        /// <param name="intervalMs">A time interval in ms to update the state of the GpioHub's GPIO pins.</param>
        /// <param name="gamePadSimple">A class that implements the GamePadSimple interface used for calling button event callback methods.</param>
        public GamePadHubRunner(GamePadHub hub, long intervalMs, GamePadSimple gamePadSimple)
        {
            gamePadHub = hub;
            pollingIntervalMs = intervalMs;
            gamePad = gamePadSimple;
            running = true;

            if (gamePadHub == null)
            {
                MmgHelper.wr("GamePadHub: GamePadHub is null! Turning off GamePadHubRunner.");
                running = false;
            }

            if (gamePadHub != null && gamePadHub.IsPrepped() == false)
            {
                MmgHelper.wr("GamePadHub: GamePadHub has not had its pins prepped! Turning off GamePadHubRunner.");
                running = false;
            }

            if (gamePad == null)
            {
                MmgHelper.wr("GamePadHub: GamePad is null! Turning off GamePadHubRunner.");
            }
        }

        /// <summary>
        /// A method that returns the polling interval in ms that the GpioHubRunner uses to monitor GPIO pins.
        /// </summary>
        /// <returns>Returns a long value that represents the number of ms of the polling interval.</returns>
        public virtual long GetPollingIntervalMs()
        {
            return pollingIntervalMs;
        }

        /// <summary>
        /// A method that sets the current polling interval in ms that the GpioHubRUnner uses to monitor GPIO pins.
        /// </summary>
        /// <param name="intervalMs">A method argument that sets the polling interval that the GpioHubRunner uses to monitor GPIO pins.</param>
        public virtual void SetPollingIntervalMs(long intervalMs)
        {
            pollingIntervalMs = intervalMs;
        }

        /// <summary>
        /// A method that returns the current execution control variable value.
        /// </summary>
        /// <returns>Returns a bool indicating if the thread is currently running or not.</returns>
        public virtual bool IsRunning()
        {
            return running;
        }

        /// <summary>
        /// A method that sets the current execution control variable value.
        /// </summary>
        /// <param name="b">A method argument that sets the value of the thread execution control variable.</param>
        public virtual void SetRunning(bool b)
        {
            running = b;
        }

        /// <summary>
        /// The PollGpio method is used to update the GPIO pin state and call event handler methods from the GamePadSimple interface. 
        /// The last step in the process is to call the CleanUp method of the GpioHub class.
        /// </summary>
        public virtual void PollGamePad()
        {
            if (gamePadHub != null && gamePadHub.IsPrepped() && gamePadHub.IsEnabled())
            {

                try
                {
                    gamePadHub.GetState();
                }
                catch (Exception e)
                {
                    MmgHelper.wr(e.ToString());
                    running = false;
                }

                //down, up, left, right
                //check dpad pressed state
                if (gamePadHub.GetDownPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(gamePadHub.gamePadDown);
                    }
                }

                if (gamePadHub.GetUpPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(gamePadHub.gamePadUp);
                    }
                }

                if (gamePadHub.GetLeftPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(gamePadHub.gamePadLeft);
                    }
                }

                if (gamePadHub.GetRightPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(gamePadHub.gamePadRight);
                    }
                }

                //check dpad released state
                if (gamePadHub.GetDownReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(gamePadHub.gamePadDown);
                    }
                }

                if (gamePadHub.GetUpReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(gamePadHub.gamePadUp);
                    }
                }

                if (gamePadHub.GetLeftReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(gamePadHub.gamePadLeft);
                    }
                }

                if (gamePadHub.GetRightReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(gamePadHub.gamePadRight);
                    }
                }

                //check dpad clicked state
                if (gamePadHub.GetDownClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(gamePadHub.gamePadDown);
                    }
                }

                if (gamePadHub.GetUpClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(gamePadHub.gamePadUp);
                    }
                }

                if (gamePadHub.GetLeftClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(gamePadHub.gamePadLeft);
                    }
                }

                if (gamePadHub.GetRightClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(gamePadHub.gamePadRight);
                    }
                }

                //a, b
                //check a,b pressed state
                if (gamePadHub.GetAPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessAPress(gamePadHub.gamePadSrc);
                    }
                }

                if (gamePadHub.GetBPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessBPress(gamePadHub.gamePadSrc);
                    }
                }

                //check a,b released state            
                if (gamePadHub.GetAReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessARelease(gamePadHub.gamePadSrc);
                    }
                }

                if (gamePadHub.GetBReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessBRelease(gamePadHub.gamePadSrc);
                    }
                }

                //check a,b clicked state            
                if (gamePadHub.GetAClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessAClick(gamePadHub.gamePadSrc);
                    }
                }

                if (gamePadHub.GetBClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessBClick(gamePadHub.gamePadSrc);
                    }
                }

                gamePadHub.CleanUp();
            }
        }

        /// <summary>
        /// The run method of the Runnable interface. Called when a new thread is created and started.
        /// </summary>
        public virtual void run()
        {
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            while (running == true)
            {
                start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                PollGamePad();
                stop = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                diff = stop - start;                    //Total time in ms to get gpio data
                diff = pollingIntervalMs - diff;        //Difference in actual time and polling time

                if (diff > 0)
                {
                    try
                    {
                        Thread.Sleep((int)diff);
                    }
                    catch (Exception ex)
                    {
                        MmgHelper.wr(ex.ToString());
                    }
                }
            }
        }
    }
}