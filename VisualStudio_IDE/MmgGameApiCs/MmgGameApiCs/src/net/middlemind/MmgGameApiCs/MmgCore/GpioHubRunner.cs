using System;
using System.Threading;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The GpioHubRunner class is a threaded class that is used to run a GpioHub and determine the state of each of the GPIO pins at interval.
    /// Created by Middlemind Games 01/05/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class GpioHubRunner
    {
        /// <summary>
        /// A reference to the GpioHub to the GpioHubRunner will monitor. 
        /// </summary>
        public GpioHub gpioHub;

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
        /// An instance of a class that implements that GamePadSimple interface, used to call dpad, A, B, event
        /// methods.
        /// </summary>
        public GamePadSimple gamePad;

        /// <summary>
        /// The main GpioHubRunner constructor that sets the class up for polling the GpioHub for GPIO pin states and determines
        /// the GamePadSimple interface for calling button event methods.
        /// </summary>
        /// <param name="hub">A method argument that sets the GpioHub of GPIO pins to monitor.</param>
        /// <param name="intervalMs">A time interval in ms to update the state of the GpioHub's GPIO pins.</param>
        /// <param name="gamePadSimple">A class that implements the GamePadSimple interface used for calling button event callback methods.</param>
        public GpioHubRunner(GpioHub hub, long intervalMs, GamePadSimple gamePadSimple)
        {
            gpioHub = hub;
            pollingIntervalMs = intervalMs;
            gamePad = gamePadSimple;
            running = true;

            if (gpioHub == null)
            {
                Console.WriteLine("GpioHub is null! Turning off GpioHubRunner.");
                running = false;
            }

            if (gpioHub != null && gpioHub.IsPrepped() == false)
            {
                Console.WriteLine("GpioHub has not had its pins prepped! Turning off GpioHubRunner.");
                running = false;
            }

            if (gamePad == null)
            {
                Console.WriteLine("GamePad is null! Turning off GpioHubRunner.");
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
        public virtual void PollGpio()
        {
            if (gpioHub != null && gpioHub.IsPrepped() && gpioHub.IsEnabled())
            {
                try
                {
                    gpioHub.GetState();
                }
                catch (Exception e)
                {
                    MmgHelper.wrErr(e);
                    running = false;
                }

                //down, up, left, right
                //check dpad pressed state
                if (gpioHub.GetDownPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(GameSettings.DOWN_GPIO);
                    }
                }

                if (gpioHub.GetUpPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(GameSettings.UP_GPIO);
                    }
                }

                if (gpioHub.GetLeftPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(GameSettings.LEFT_GPIO);
                    }
                }

                if (gpioHub.GetRightPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadPress(GameSettings.RIGHT_GPIO);
                    }
                }

                //check dpad released state
                if (gpioHub.GetDownReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(GameSettings.DOWN_GPIO);
                    }
                }

                if (gpioHub.GetUpReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(GameSettings.UP_GPIO);
                    }
                }

                if (gpioHub.GetLeftReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(GameSettings.LEFT_GPIO);
                    }
                }

                if (gpioHub.GetRightReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadRelease(GameSettings.RIGHT_GPIO);
                    }
                }

                //check dpad clicked state
                if (gpioHub.GetDownClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(GameSettings.DOWN_GPIO);
                    }
                }

                if (gpioHub.GetUpClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(GameSettings.UP_GPIO);
                    }
                }

                if (gpioHub.GetLeftClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(GameSettings.LEFT_GPIO);
                    }
                }

                if (gpioHub.GetRightClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessDpadClick(GameSettings.RIGHT_GPIO);
                    }
                }

                //a, b
                //check a,b pressed state
                if (gpioHub.GetAPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessAPress(GameSettings.SRC_GPIO);
                    }
                }

                if (gpioHub.GetBPressed())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessBPress(GameSettings.SRC_GPIO);
                    }
                }

                //check a,b released state            
                if (gpioHub.GetAReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessARelease(GameSettings.SRC_GPIO);
                    }
                }

                if (gpioHub.GetBReleased())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessBRelease(GameSettings.SRC_GPIO);
                    }
                }

                //check a,b clicked state            
                if (gpioHub.GetAClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessAClick(GameSettings.SRC_GPIO);
                    }
                }

                if (gpioHub.GetBClicked())
                {
                    if (gamePad != null)
                    {
                        gamePad.ProcessBClick(GameSettings.SRC_GPIO);
                    }
                }

                gpioHub.CleanUp();
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
                PollGpio();
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
                        MmgHelper.wrErr(ex);
                    }
                }
            }
        }
    }
}