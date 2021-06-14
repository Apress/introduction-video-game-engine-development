using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The GpioPin class is used to map the state of Linux GPIO pins for use as a source of input.
    /// Created by Middlemind Games 01/05/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class GpioPin
    {
        /// <summary>
        /// An enumeration used to indicate the button type mapped to this GpioPin.
        /// </summary>
        public enum GpioButton
        {
            BtnUp,
            BtnDown,
            BtnLeft,
            BtnRight,
            BtnA,
            BtnB
        };

        /// <summary>
        /// The pin number of this GpioPin on the host system.
        /// </summary>
        public int pinNum;

        /// <summary>
        /// The 0 or 1 state the pin should be set to when the GpioHub is prepped.
        /// </summary>
        public bool pinHigh;

        /// <summary>
        /// The in or out state the pin should be set to when the GpioHub is prepped.
        /// </summary>
        public bool pinIn;

        /// <summary>
        /// The button type mapped to this GpioPin.
        /// </summary>
        public GpioButton button;

        /// <summary>
        /// A class field that is used to temporarily hold the current state of a GPIO pin attribute.
        /// </summary>
        public bool stateTmp;

        /// <summary>
        /// A class field that is used to hold the current state of a GPIO pin attribute.
        /// </summary>
        public bool stateCurrent;

        /// <summary>
        /// A class field that is used to hold the previous state of a GPIO pin attribute.
        /// </summary>
        public bool statePrev;

        /// <summary>
        /// A class field that holds the status of a GPIO pin attribute, pressed.
        /// </summary>
        public bool pressed;

        /// <summary>
        /// A class field that holds the status of a GPIO pin attribute, released.
        /// </summary>
        public bool released;

        /// <summary>
        /// A class field that holds the status of a GPIO pin attribute, clicked.
        /// </summary>
        public bool clicked;

        /// <summary>
        /// A class field that determines if the GPIO pin attribute, pressed, should be checked.
        /// </summary>
        public bool checkPressed;

        /// <summary>
        /// A class field that determines if the GPIO pin attribute, released, should be checked.
        /// </summary>
        public bool checkReleased;

        /// <summary>
        /// A class field that determines if the GPIO pin attribute, clicked, should be checked.
        /// </summary>
        public bool checkClicked;

        /// <summary>
        /// The main GpioPin constructor that sets all class field values.
        /// </summary>
        /// <param name="pinNumber">The GPIO pin number of the host computer system.</param>
        /// <param name="high">The default high/low, 0/1, state to set the GpioPin when prepped by the GpioHub.</param>
        /// <param name="In">The default in/out state to set the GpioPin when prepped by the GpioHub.</param>
        /// <param name="buttonType">The GpioButton type to assign to the GpioPin class instance.</param>
        /// <param name="chkPress">A bool flag indicating if the press GpioPin state should be checked.</param>
        /// <param name="chkRelease">A bool flag indicating if the release GpioPin state should be checked.</param>
        /// <param name="chkClick">A bool flag indicating if the click GpioPin state should be checked.</param>
        public GpioPin(int pinNumber, bool high, bool In, GpioButton buttonType, bool chkPress, bool chkRelease, bool chkClick)
        {
            pinNum = pinNumber;
            pinHigh = high;
            pinIn = In;
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

        /// <summary>
        /// A GpioPin constructor that sets all class field values except pinHigh and pinIn. 
        /// The pinHigh and pinIn field value are defaulted to false with this constructor.
        /// </summary>
        /// <param name="pinNumber">The GPIO pin number of the host computer system.</param>
        /// <param name="buttonType">The GpioButton type to assign to the GpioPin class instance.</param>
        /// <param name="chkPress">A bool flag indicating if the press GpioPin state should be checked.</param>
        /// <param name="chkRelease">A bool flag indicating if the release GpioPin state should be checked.</param>
        /// <param name="chkClick">A bool flag indicating if the click GpioPin state should be checked.</param>
        public GpioPin(int pinNumber, GpioButton buttonType, bool chkPress, bool chkRelease, bool chkClick)
        {
            pinNum = pinNumber;
            pinHigh = false;
            pinIn = false;
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
}