package net.middlemind.MmgGameApiJava.MmgCore;

/**
 * The GpioPin class is used to map the state of Linux GPIO pins for use as a source of input.
 * Created by Middlemind Games 01/05/2020
 * 
 * @author Victor G. Brusca
 */
public class GamePadInput {
    
    /**
     * An enumeration used to indicate the button type mapped to this GpioPin.
     */
    public enum GamePadButton {
        BtnUp,
        BtnDown,
        BtnLeft,
        BtnRight,
        BtnA,
        BtnB
    };
    
    /**
     * The index of this GamePad button on the controller.
     */
    public int btnIdx;
    
    /**
     * The 0 or 1 state the pin should be set to when the GpioHub is prepped.
     */
    public float btnOn;
    
    /**
     * The in or out state the pin should be set to when the GpioHub is prepped.
     */
    public float btnOff;
    
    /**
     * The button type mapped to this GpioPin.
     */
    public GamePadButton button;
    
    /**
     * A class field that is used to temporarily hold the current state of a GPIO pin attribute.
     */
    public boolean stateTmp;
    
    /**
     * A class field that is used to hold the current state of a GPIO pin attribute.
     */
    public boolean stateCurrent;
    
    /**
     * A class field that is used to hold the previous state of a GPIO pin attribute.
     */
    public boolean statePrev;
    
    /**
     * A class field that holds the status of a GPIO pin attribute, pressed.
     */
    public boolean pressed;
    
    /**
     * A class field that holds the status of a GPIO pin attribute, released.
     */    
    public boolean released;
    
    /**
     * A class field that holds the status of a GPIO pin attribute, clicked.
     */    
    public boolean clicked;
    
    /**
     * A class field that determines if the GPIO pin attribute, pressed, should be checked.
     */
    public boolean checkPressed;
    
    /**
     * A class field that determines if the GPIO pin attribute, released, should be checked.
     */    
    public boolean checkReleased;
    
    /**
     * A class field that determines if the GPIO pin attribute, clicked, should be checked.
     */    
    public boolean checkClicked;    
        
    /**
     * The main GpioPin constructor that sets all class field values.
     * 
     * @param pinNumber         The GPIO pin number of the host computer system.
     * @param high              The default high/low, 0/1, state to set the GpioPin when prepped by the GpioHub.
     * @param in                The default in/out state to set the GpioPin when prepped by the GpioHub.
     * @param buttonType        The GpioButton type to assign to the GpioPin class instance.
     * @param chkPress          A boolean flag indicating if the press GpioPin state should be checked.
     * @param chkRelease        A boolean flag indicating if the release GpioPin state should be checked.
     * @param chkClick          A boolean flag indicating if the click GpioPin state should be checked.
     */
    public GamePadInput(int idx, float on, float off, GamePadButton buttonType, boolean chkPress, boolean chkRelease, boolean chkClick) {
        btnIdx = idx;
        btnOn = on;
        btnOff = off;
        button = buttonType;
        stateTmp = false;
        statePrev = false;
        stateCurrent = false;
        pressed = false;
        released = false;
        clicked = false;
        checkPressed = chkPress;
        checkReleased = chkRelease;
        checkClicked = chkClick;
    }
    
    /**
     * A GpioPin constructor that sets all class field values except pinHigh and pinIn. 
     * The pinHigh and pinIn field value are defaulted to false with this constructor.
     * 
     * @param pinNumber         The GPIO pin number of the host computer system.
     * @param buttonType        The GpioButton type to assign to the GpioPin class instance.
     * @param chkPress          A boolean flag indicating if the press GpioPin state should be checked.
     * @param chkRelease        A boolean flag indicating if the release GpioPin state should be checked.
     * @param chkClick          A boolean flag indicating if the click GpioPin state should be checked.
     */    
    public GamePadInput(int idx, GamePadButton buttonType, boolean chkPress, boolean chkRelease, boolean chkClick) {
        btnIdx = idx;
        btnOn = 1.00f;
        btnOff = 0.00f;
        button = buttonType;
        stateTmp = false;
        statePrev = false;
        stateCurrent = false;
        pressed = false;
        released = false;
        clicked = false;
        checkPressed = chkPress;
        checkReleased = chkRelease;
        checkClicked = chkClick;
    }    
}