package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgCore.GpioPin.GpioButton;
import java.io.File;
import java.io.IOException;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * The GpioHub class is used to provide access to up to 6 GPIO pins, most likely on a Linux system.
 * The class tracks the state of the pins to provide press, release, click information on the GPIO pins.
 * Created by Middlemind Games 01/05/2020
 * 
 * @author Victor G. Brusca
 */
public class GpioHub {
    
    /**
     * A static integer that determines the length of the GPIO input array, used to speed up loops that check the GPIO input pins.
     */
    public static int LEN = 6;    
    
    /**
     * A static integer for tracking the UP button GPIO pin in the array of pins.
     */
    public static int UP = 0;
    
    /**
     * A static integer for tracking the DOWN button GPIO pin in the array of pins.
     */
    public static int DOWN = 1;
    
    /**
     * A static integer for tracking the LEFT button GPIO pin in the array of pins.
     */
    public static int LEFT = 2;
    
    /**
     * A static integer for tracking the RIGHT button GPIO pin in the array of pins.
     */
    public static int RIGHT = 3;
    
    /**
     * A static integer for tracking the A button GPIO pin in the array of pins.
     */
    public static int A = 4;
    
    /**
     * A static integer for tracking the B button GPIO pin in the array of pins.
     */
    public static int B = 5;
    
    /**
     * A quick lookup of the integer value of ASCII character 0. 
     * When checking sys/class/gpio value files.
     */
    public static int char0toInt = 48;
    
    /**
     * A quick lookup of the integer value of ASCII character 1. 
     * When checking sys/class/gpio value files.
     */    
    public static int char1toInt = 49;
    
    /**
     * An array of GpioPin instances used to indicate dpad, A button, and B button input.
     */
    public GpioPin[] buttons = null;
    
    /**
     * An instance of the Runtime Java class that provides access to the environment the Java application is running on.
     * In the GpioHub class this class field allows access to system calls to monitor GPIO pins.
     */
    public Runtime runTime = null;
    
    /**
     * A temporary integer value used to store the results from a sys/class/gpio  value file read.
     */
    public int tmp;
    
    /**
     * A boolean that indicates if the GpioHub has been properly prepared.
     */
    public boolean prepped = false;
    
    /**
     * A boolean that indicates if GPIO input is enabled.
     */
    public boolean gpioEnabled = false;

    /**
     * A private loop counting class field.
     */    
    private int i;
    
    /**
     * A private loop counting class field.
     */    
    private int j;  
    
    /**
     * A private loop counting class field.
     */    
    private int k;
    
    /**
     * A private temporary class field for gamepad input.
     */    
    private GpioPin btn1;
    
    /**
     * A private temporary class field for gamepad input.
     */    
    private GpioPin btn2;
    
    /**
     * A private temporary class field for gamepad input.
     */    
    private GpioPin btn3;    
    
    /**
     * A default constructor for the GpioHub class that checks to see if GPIO is supported on the system.
     * Creates a default array of 6 GpioPin instances using values from the GameSettings class to set the GPIO pin numbers
     * and the events that should be tracked.
     */
    public GpioHub() {
        try {
            File f = new File("/sys/class/gpio");
            if(!f.isDirectory() || !f.exists()) {
                MmgHelper.wr("GpioHub: GPIO directory, /sys/class/gpio/, does not exist. Disabling class functionality.");
                gpioEnabled = false;
            } else {
                MmgHelper.wr("GpioHub: GPIO directory, /sys/class/gpio/, exists! Enabling class functionality.");
                gpioEnabled = true;
            }
            
        }catch(Exception e) {
            MmgHelper.wrErr(e);
        }
               
        buttons = new GpioPin[6];
        buttons[0] = new GpioPin(GameSettings.GPIO_PIN_BTN_UP, true, false, GpioButton.BtnUp, GameSettings.BTN_UP_CHECK_PRESS, GameSettings.BTN_UP_CHECK_RELEASE, GameSettings.BTN_UP_CHECK_CLICK);
        buttons[1] = new GpioPin(GameSettings.GPIO_PIN_BTN_DOWN, true, false, GpioButton.BtnDown, GameSettings.BTN_DOWN_CHECK_PRESS, GameSettings.BTN_DOWN_CHECK_RELEASE, GameSettings.BTN_DOWN_CHECK_CLICK);
        buttons[2] = new GpioPin(GameSettings.GPIO_PIN_BTN_LEFT, true, false, GpioButton.BtnLeft, GameSettings.BTN_LEFT_CHECK_PRESS, GameSettings.BTN_LEFT_CHECK_RELEASE, GameSettings.BTN_LEFT_CHECK_CLICK);
        buttons[3] = new GpioPin(GameSettings.GPIO_PIN_BTN_RIGHT, true, false, GpioButton.BtnRight, GameSettings.BTN_RIGHT_CHECK_PRESS, GameSettings.BTN_RIGHT_CHECK_RELEASE, GameSettings.BTN_RIGHT_CHECK_CLICK);
        buttons[4] = new GpioPin(GameSettings.GPIO_PIN_BTN_A, true, false, GpioButton.BtnA, GameSettings.BTN_A_CHECK_PRESS, GameSettings.BTN_A_CHECK_RELEASE, GameSettings.BTN_A_CHECK_CLICK);
        buttons[5] = new GpioPin(GameSettings.GPIO_PIN_BTN_B, true, false, GpioButton.BtnB, GameSettings.BTN_B_CHECK_PRESS, GameSettings.BTN_B_CHECK_RELEASE, GameSettings.BTN_B_CHECK_CLICK);
        runTime = Runtime.getRuntime();
        
        Prep();        
    }

    /**
     * A constructor for the GpioHub that takes an array of GpioPin instances which is used to set the buttons class field.
     * 
     * @param Buttons       An array of 6 GpioPin instances used to set the buttons class field.
     */
    public GpioHub(GpioPin[] Buttons) {
       try {
            File f = new File("/sys/class/gpio");
            if(!f.isDirectory() || !f.exists()) {
                MmgHelper.wr("GPIO directory, /sys/class/gpio/, does not exist. Disabling class functionality.");
                gpioEnabled = false;
            } else {
                MmgHelper.wr("GPIO directory, /sys/class/gpio/, exists! Enabling class functionality.");
                gpioEnabled = true;
            }
            
        }catch(Exception e) {
            MmgHelper.wrErr(e);
        }        
        
        buttons = Buttons;
        runTime = Runtime.getRuntime(); 
        
        Prep();
    }

    /**
     * A method used to determine if GPIO is enabled on the current environment.
     * 
     * @return      A boolean flag indicating if GPIO is enabled on the current environment.
     */
    public boolean IsEnabled() {
        return gpioEnabled;
    }

    /**
     * A method used to set the boolean flag to determine if the GPIO is enabled on the current environment.
     * 
     * @param b     A boolean argument used to set if GPIO is enabled on the current environment.
     */
    public void SetEnabled(boolean b) {
        gpioEnabled = b;
    }
    
    /**
     * A method that returns the current array of GpioPin instances.
     * 
     * @return      An array of GpioPin instances used by the GpioHub for state monitoring.
     */
    public GpioPin[] GetButtons() {
        return buttons;
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the given array index, i, is enabled.
     * 
     * @param i     An argument indicating which array index, GpioPin, to verify is enabled.
     * @return      A boolean indicating if the GpioPin at the given index is enabled. 
     */
    public boolean ButtonEnabled(int i) {
        if(buttons != null && i >= 0 && i < buttons.length && buttons[i] != null) {
            return true;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the DOWN index position
     * of the buttons array is pressed.
     * 
     * @return      A boolean indicating if the DOWN GpioPin is pressed or not.
     */
    public boolean GetDownPressed() {
        if(ButtonEnabled(DOWN) && buttons[DOWN].checkPressed == true) {
            return buttons[DOWN].pressed;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the DOWN index position
     * of the buttons array is released.
     * 
     * @return      A boolean indicating if the DOWN GpioPin is released or not.
     */    
    public boolean GetDownReleased() {
        if(ButtonEnabled(DOWN) && buttons[DOWN].checkReleased == true) {
            return buttons[DOWN].released;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the DOWN index position
     * of the buttons array has been clicked.
     * 
     * @return      A boolean indicating if the DOWN GpioPin has been clicked or not.
     */    
    public boolean GetDownClicked() {
        if(ButtonEnabled(DOWN) && buttons[DOWN].checkClicked == true) {
            return buttons[DOWN].clicked;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the UP index position
     * of the buttons array is pressed.
     * 
     * @return      A boolean indicating if the UP GpioPin is pressed or not.
     */    
    public boolean GetUpPressed() {
        if(ButtonEnabled(UP) && buttons[UP].checkPressed == true) {
            return buttons[UP].pressed;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the UP index position
     * of the buttons array is released.
     * 
     * @return      A boolean indicating if the UP GpioPin is released or not.
     */        
    public boolean GetUpReleased() {
        if(ButtonEnabled(UP) && buttons[UP].checkReleased == true) {
            return buttons[UP].released;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the UP index position
     * of the buttons array has been clicked.
     * 
     * @return      A boolean indicating if the UP GpioPin has been clicked or not.
     */            
    public boolean GetUpClicked() {
        if(ButtonEnabled(UP) && buttons[UP].checkClicked == true) {
            return buttons[UP].clicked;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the LEFT index position
     * of the buttons array is pressed.
     * 
     * @return      A boolean indicating if the LEFT GpioPin is pressed or not.
     */
    public boolean GetLeftPressed() {
        if(ButtonEnabled(LEFT) && buttons[LEFT].checkPressed == true) {
            return buttons[LEFT].pressed;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the LEFT index position
     * of the buttons array is released.
     * 
     * @return      A boolean indicating if the LEFT GpioPin is released or not.
     */    
    public boolean GetLeftReleased() {
        if(ButtonEnabled(LEFT) && buttons[LEFT].checkReleased == true) {
            return buttons[LEFT].released;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the LEFT index position
     * of the buttons array has been clicked.
     * 
     * @return      A boolean indicating if the LEFT GpioPin has been clicked or not.
     */    
    public boolean GetLeftClicked() {
        if(ButtonEnabled(LEFT) && buttons[LEFT].checkClicked == true) {
            return buttons[LEFT].clicked;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the RIGHT index position
     * of the buttons array is pressed.
     * 
     * @return      A boolean indicating if the RIGHT GpioPin is pressed or not.
     */    
    public boolean GetRightPressed() {
        if(ButtonEnabled(RIGHT) && buttons[RIGHT].checkPressed == true) {
            return buttons[RIGHT].pressed;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the RIGHT index position
     * of the buttons array is released.
     * 
     * @return      A boolean indicating if the RIGHT GpioPin is released or not.
     */    
    public boolean GetRightReleased() {
        if(ButtonEnabled(RIGHT) && buttons[RIGHT].checkReleased == true) {
            return buttons[RIGHT].released;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the RIGHT index position
     * of the buttons array has been clicked.
     * 
     * @return      A boolean indicating if the RIGHT GpioPin has been clicked or not.
     */    
    public boolean GetRightClicked() {
        if(ButtonEnabled(RIGHT) && buttons[RIGHT].checkClicked == true) {
            return buttons[RIGHT].clicked;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the A index position
     * of the buttons array is pressed.
     * 
     * @return      A boolean indicating if the A GpioPin is pressed or not.
     */    
    public boolean GetAPressed() {
        if(ButtonEnabled(A) && buttons[A].checkPressed == true) {
            return buttons[A].pressed;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the A index position
     * of the buttons array is released.
     * 
     * @return      A boolean indicating if the A GpioPin is released or not.
     */      
    public boolean GetAReleased() {
        if(ButtonEnabled(A) && buttons[A].checkReleased == true) {
            return buttons[A].released;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the A index position
     * of the buttons array has been clicked.
     * 
     * @return      A boolean indicating if the A GpioPin has been clicked or not.
     */    
    public boolean GetAClicked() {
        if(ButtonEnabled(A) && buttons[A].checkClicked == true) {
            return buttons[A].clicked;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the B index position
     * of the buttons array is pressed.
     * 
     * @return      A boolean indicating if the B GpioPin is pressed or not.
     */     
    public boolean GetBPressed() {
        if(ButtonEnabled(B) && buttons[B].checkPressed == true) {
            return buttons[B].pressed;
        } else {
            return false;
        }
    }
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the B index position
     * of the buttons array is released.
     * 
     * @return      A boolean indicating if the B GpioPin is released or not.
     */    
    public boolean GetBReleased() {
        if(ButtonEnabled(B) && buttons[B].checkReleased == true) {
            return buttons[B].released;
        } else {
            return false;
        }
    }    
    
    /**
     * A method that returns a boolean flag indicating if the GpioPin at the B index position
     * of the buttons array has been clicked.
     * 
     * @return      A boolean indicating if the B GpioPin has been clicked or not.
     */     
    public boolean GetBClicked() {
        if(ButtonEnabled(B) && buttons[B].checkClicked == true) {
            return buttons[B].clicked;
        } else {
            return false;
        }
    }    
    
    /**
     * A method to set the pin state of a GPIO pin.
     * 
     * @param pinIdx        An argument indicating which GPIO pin to set.
     * @param high          An argument indicating what state to set the GPIO pin, high or low.
     * 
     * @throws IOException 
     */
    public void SetGpioPin(int pinIdx, boolean high) throws IOException {
        if(buttons != null && (pinIdx >= 0 || pinIdx < buttons.length)) {
            buttons[pinIdx].pinHigh = high;
            if(buttons[pinIdx].pinHigh == true) {
                runTime.exec("echo 1 > /sys/class/gpio/gpio" + buttons[pinIdx].pinNum + "/value");
            } else {
                runTime.exec("echo 0 > /sys/class/gpio/gpio" + buttons[pinIdx].pinNum + "/value");                        
            }
        }
    }
    
    /**
     * An initialization method to prepare the GPIO pins by setting them to unexport, then setting them to export
     * followed by setting the pin's current state.
     */
    private void Prep() {
        try {
            prepped = false;
            if(runTime != null && buttons != null) {
                for(i = 0; i < LEN; i++) {
                    btn1 = buttons[i];
                    runTime.exec("echo " + btn1.pinNum + " > /sys/class/gpio/unexport");
                    runTime.exec("echo " + btn1.pinNum + " > /sys/class/gpio/export");
                    if(btn1.pinIn == false) {
                        runTime.exec("echo out > /sys/class/gpio/gpio" + btn1.pinNum + "/direction");
                        if(btn1.pinHigh == true) {
                            runTime.exec("echo 1 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");
                        } else {
                            runTime.exec("echo 0 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");                        
                        }
                    } else {
                        if(btn1.pinHigh == true) {
                            runTime.exec("echo 1 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");
                        } else {
                            runTime.exec("echo 0 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");                        
                        }                    
                        runTime.exec("echo in > /sys/class/gpio/gpio" + btn1.pinNum + "/direction");                    
                    }
                }
                prepped = true;
                
            }
        }catch(Exception e) {
            prepped = false;
            MmgHelper.wrErr(e);
            
        }
    }

    /**
     * A method that returns the prepped state of the GPIO pins, buttons array.
     * 
     * @return      A boolean value indicating that the GPIO pins have been prepped.
     */
    public boolean IsPrepped() {
        return prepped;
    }
    
    /**
     * A method that cleans up all the pins so that their state can be used to determine if a press, release, or click
     * has happened for a given GPIO pin.
     */
    public void CleanUp() {
        for(j = 0; j < LEN; j++) {
            btn2 = buttons[j];
            btn2.pressed = false;
            btn2.clicked = false;
            btn2.released = false;
        }   
    }
    
    /**
     * A method to determine the state of the GPIO pins. 
     * The methods scans all the GPIO pins in the buttons array to determine the state of each button.
     * 
     * @throws IOException 
     */
    public void GetState() throws Exception {
        if(gpioEnabled == true) {
            try {
                for(k = 0; k < LEN; k++) {
                    btn3 = buttons[k];
                    tmp = runTime.exec("cat /sys/class/gpio/gpio" + btn3.pinNum + "/value").getInputStream().read();

                    if(tmp == char0toInt) {
                        btn3.stateTmp = false;
                    } else {
                        btn3.stateTmp = true;                
                    }

                    btn3.statePrev = btn3.stateCurrent;
                    btn3.stateCurrent = btn3.stateTmp;

                    if(btn3.stateCurrent == false && btn3.statePrev == true) {
                        btn3.released = true;
                        btn3.clicked = true;
                        btn3.pressed = false;

                    } else if(btn3.stateCurrent == true && btn3.statePrev == false) {
                        btn3.released = false;
                        btn3.clicked = false;
                        btn3.pressed = true;

                    }
                }
                
            } catch(Exception e) {
                gpioEnabled = false;
                throw(e);
            }
        }
    }
}