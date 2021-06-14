package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * The GamePadRunner class is a threaded class that is used to connect to a USB GamePad via JInput and determine the state of each
 * of the target buttons at interval.
 * Created by Middlemind Games 01/05/2020
 * 
 * @author Victor G. Brusca
 */
public class GamePadHubRunner implements Runnable {
    
    /**
     * A reference to the GpioHub to the GpioHubRunner will monitor.
     */
    public GamePadHub gamePadHub;
    
    /**
     * The interval in ms that the GpioHubRunner will update the state of the GPIO pins.
     */
    public long pollingIntervalMs = 10;
    
    /**
     * A class field used to mark the start time of a polling interval.
     */
    public long start;
    
    /**
     * A class field used to mark the stop time of a polling interval.
     */
    public long stop;
    
    /**
     * A class field used to mark a time difference for measuring polling intervals.
     */
    public long diff;
    
    /**
     * A class field used to control if the GpioHubRunner is running.
     */
    public boolean running = false;
    
    /**
     * An instance of a class that implements that GamePadSimple interface, used to call dpad, A, B, event
     * methods.
     */
    public GamePadSimple gamePad;
    
    /**
     * The main GpioHubRunner constructor that sets the class up for polling the GpioHub for GPIO pin states and determines
     * the GamePadSimple interface for calling button event methods.
     * 
     * @param hub               A method argument that sets the GpioHub of GPIO pins to monitor.
     * @param intervalMs        A time interval in ms to update the state of the GpioHub's GPIO pins.
     * @param gamePadSimple     A class that implements the GamePadSimple interface used for calling button event callback methods.
     */
    public GamePadHubRunner(GamePadHub hub, long intervalMs, GamePadSimple gamePadSimple) {
        gamePadHub = hub;
        pollingIntervalMs = intervalMs;
        gamePad = gamePadSimple;
        running = true;
        
        if(gamePadHub == null) {
            System.err.println("GamePadHub: GamePadHub is null! Turning off GamePadHubRunner.");
            running = false;            
        }
        
        if(gamePadHub != null && gamePadHub.IsPrepped() == false) {
            System.err.println("GamePadHub: GamePadHub has not had its pins prepped! Turning off GamePadHubRunner.");
            running = false;
        }
        
        if(gamePad == null) {
            System.err.println("GamePadHub: GamePad is null! Turning off GamePadHubRunner.");
        }
    }

    /**
     * A method that returns the polling interval in ms that the GpioHubRunner uses to monitor GPIO pins.
     * 
     * @return      Returns a long value that represents the number of ms of the polling interval.
     */
    public long GetPollingIntervalMs() {
        return pollingIntervalMs;
    }

    /**
     * A method that sets the current polling interval in ms that the GpioHubRUnner uses to monitor GPIO pins.
     * 
     * @param intervalMs        A method argument that sets the polling interval that the GpioHubRunner uses to monitor GPIO pins.
     */
    public void SetPollingIntervalMs(long intervalMs) {
        pollingIntervalMs = intervalMs;
    }

    /**
     * A method that returns the current execution control variable value.
     * 
     * @return      Returns a boolean indicating if the thread is currently running or not.
     */
    public boolean IsRunning() {
        return running;
    }

    /**
     * A method that sets the current execution control variable value.
     * 
     * @param b     A method argument that sets the value of the thread execution control variable.
     */
    public void SetRunning(boolean b) {
        running = b;
    }

    /**
     * The PollGpio method is used to update the GPIO pin state and call event handler methods from the GamePadSimple interface. 
     * The last step in the process is to call the CleanUp method of the GpioHub class.
     */
    @SuppressWarnings("CallToPrintStackTrace")
    public void PollGamePad() {
        if(gamePadHub != null && gamePadHub.IsPrepped() && gamePadHub.IsEnabled()) {

            try {
                gamePadHub.GetState();
            } catch (Exception e) {
                MmgHelper.wrErr(e);
                running = false;
            }
            
            //down, up, left, right
            //check dpad pressed state
            if(gamePadHub.GetDownPressed()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadPress(gamePadHub.gamePadDown);
                }
            }
            
            if(gamePadHub.GetUpPressed()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadPress(gamePadHub.gamePadUp);                    
                }
            }
            
            if(gamePadHub.GetLeftPressed()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadPress(gamePadHub.gamePadLeft);                    
                }
            }
            
            if(gamePadHub.GetRightPressed()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadPress(gamePadHub.gamePadRight);                    
                }
            }

            //check dpad released state
            if(gamePadHub.GetDownReleased()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadRelease(gamePadHub.gamePadDown);
                }
            }
            
            if(gamePadHub.GetUpReleased()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadRelease(gamePadHub.gamePadUp);                    
                }
            }
            
            if(gamePadHub.GetLeftReleased()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadRelease(gamePadHub.gamePadLeft);                    
                }
            }
            
            if(gamePadHub.GetRightReleased()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadRelease(gamePadHub.gamePadRight);                    
                }
            }            
            
            //check dpad clicked state
            if(gamePadHub.GetDownClicked()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadClick(gamePadHub.gamePadDown);
                }
            }
            
            if(gamePadHub.GetUpClicked()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadClick(gamePadHub.gamePadUp);                    
                }
            }
            
            if(gamePadHub.GetLeftClicked()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadClick(gamePadHub.gamePadLeft);                    
                }
            }
            
            if(gamePadHub.GetRightClicked()) {
                if(gamePad != null) {
                    gamePad.ProcessDpadClick(gamePadHub.gamePadRight);                    
                }
            }            
            
            //a, b
            //check a,b pressed state
            if(gamePadHub.GetAPressed()) {
                if(gamePad != null) {
                    gamePad.ProcessAPress(gamePadHub.gamePadSrc);
                }
            }
            
            if(gamePadHub.GetBPressed()) {
                if(gamePad != null) {
                    gamePad.ProcessBPress(gamePadHub.gamePadSrc);
                }
            }

            //check a,b released state            
            if(gamePadHub.GetAReleased()) {
                if(gamePad != null) {
                    gamePad.ProcessARelease(gamePadHub.gamePadSrc);
                }
            }
            
            if(gamePadHub.GetBReleased()) {
                if(gamePad != null) {
                    gamePad.ProcessBRelease(gamePadHub.gamePadSrc);
                }
            }            
            
            //check a,b clicked state            
            if(gamePadHub.GetAClicked()) {
                if(gamePad != null) {
                    gamePad.ProcessAClick(gamePadHub.gamePadSrc);
                }
            }
            
            if(gamePadHub.GetBClicked()) {
                if(gamePad != null) {
                    gamePad.ProcessBClick(gamePadHub.gamePadSrc);
                }
            }
            
            gamePadHub.CleanUp();
        }        
    }
    
    /**
     * The run method of the Runnable interface. Called when a new thread is created and started.
     */
    @Override
    @SuppressWarnings({"CallToPrintStackTrace", "SleepWhileInLoop"})
    public void run() {
        try {
            Thread.sleep(1000);
        } catch(Exception e) {
            MmgHelper.wrErr(e);
        }
        
        while(running == true) {
            start = System.currentTimeMillis();
            PollGamePad();
            stop = System.currentTimeMillis();
            
            diff = stop - start;                    //Total time in ms to get gpio data
            diff = pollingIntervalMs - diff;        //Difference in actual time and polling time
            
            if(diff > 0) {
                try {
                    Thread.sleep(diff);
                } catch (InterruptedException ex) {
                    MmgHelper.wrErr(ex);
                }
            }
        }
    }    
}