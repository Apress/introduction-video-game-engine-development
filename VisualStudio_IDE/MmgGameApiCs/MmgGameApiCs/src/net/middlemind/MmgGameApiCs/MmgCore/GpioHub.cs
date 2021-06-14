using System;
using System.IO;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgCore.GpioPin;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The GpioHub class is used to provide access to up to 6 GPIO pins, most likely on a Linux system.
    /// The class tracks the state of the pins to provide press, release, click information on the GPIO pins.
    /// Created by Middlemind Games 01/05/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class GpioHub
    {
        /// <summary>
        /// A static integer that determines the length of the GPIO input array, used to speed up loops that check the GPIO input pins. 
        /// </summary>
        public static int LEN = 6;

        /// <summary>
        /// A static integer for tracking the UP button GPIO pin in the array of pins. 
        /// </summary>
        public static int UP = 0;

        /// <summary>
        /// A static integer for tracking the DOWN button GPIO pin in the array of pins. 
        /// </summary>
        public static int DOWN = 1;

        /// <summary>
        /// A static integer for tracking the LEFT button GPIO pin in the array of pins. 
        /// </summary>
        public static int LEFT = 2;

        /// <summary>
        /// A static integer for tracking the RIGHT button GPIO pin in the array of pins. 
        /// </summary>
        public static int RIGHT = 3;

        /// <summary>
        /// A static integer for tracking the A button GPIO pin in the array of pins. 
        /// </summary>
        public static int A = 4;

        /// <summary>
        /// A static integer for tracking the B button GPIO pin in the array of pins. 
        /// </summary>
        public static int B = 5;

        /// <summary>
        /// A quick lookup of the integer value of ASCII character 0. 
        /// When checking sys/class/gpio value files.
        /// </summary>
        public static int char0toInt = 48;

        /// <summary>
        /// A quick lookup of the integer value of ASCII character 1. 
        // When checking sys/class/gpio value files.
        /// </summary>
        public static int char1toInt = 49;

        /// <summary>
        /// An array of GpioPin instances used to indicate dpad, A button, and B button input.
        /// </summary>
        public GpioPin[] buttons = null;

        /// <summary>
        /// An instance of the Runtime Java class that provides access to the environment the Java application is running on.
        /// In the GpioHub class this class field allows access to system calls to monitor GPIO pins.
        /// </summary>
        public Runtime runTime = null;

        /// <summary>
        /// A temporary integer value used to store the results from a sys/class/gpio  value file read.
        /// </summary>
        public int tmp;

        /// <summary>
        /// A bool that indicates if the GpioHub has been properly prepared.
        /// </summary>
        public bool prepped = false;

        /// <summary>
        /// A bool that indicates if GPIO input is enabled.
        /// </summary>
        public bool gpioEnabled = false;

        /// <summary>
        /// A private loop counting class field.
        /// </summary>
        private int i;

        /// <summary>
        /// A private loop counting class field.
        /// </summary>
        private int j;

        /// <summary>
        /// A private loop counting class field.
        /// </summary>
        private int k;

        /// <summary>
        /// A private temporary class field for gamepad input.
        /// </summary>
        private GpioPin btn1;

        /// <summary>
        /// A private temporary class field for gamepad input.
        /// </summary>
        private GpioPin btn2;

        /// <summary>
        /// A private temporary class field for gamepad input.
        /// </summary>
        private GpioPin btn3;

        /// <summary>
        /// A default constructor for the GpioHub class that checks to see if GPIO is supported on the system.
        /// Creates a default array of 6 GpioPin instances using values from the GameSettings class to set the GPIO pin numbers
        /// and the events that should be tracked.
        /// </summary>
        public GpioHub()
        {
            try
            {
                DirectoryInfo f = new DirectoryInfo("/sys/class/gpio");
                if (!f.Exists)
                {
                    MmgHelper.wr("GpioHub: GPIO directory, /sys/class/gpio/, does not exist. Disabling class functionality.");
                    gpioEnabled = false;
                }
                else
                {
                    MmgHelper.wr("GpioHub: GPIO directory, /sys/class/gpio/, exists! Enabling class functionality.");
                    gpioEnabled = true;
                }

            }
            catch (Exception e)
            {
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

        /// <summary>
        /// A constructor for the GpioHub that takes an array of GpioPin instances which is used to set the buttons class field.
        /// </summary>
        /// <param name="Buttons">An array of 6 GpioPin instances used to set the buttons class field.</param>
        public GpioHub(GpioPin[] Buttons)
        {
            try
            {
                DirectoryInfo f = new DirectoryInfo("/sys/class/gpio");
                if (!f.Exists)
                {
                    MmgHelper.wr("GPIO directory, /sys/class/gpio/, does not exist. Disabling class functionality.");
                    gpioEnabled = false;
                }
                else
                {
                    MmgHelper.wr("GPIO directory, /sys/class/gpio/, exists! Enabling class functionality.");
                    gpioEnabled = true;
                }

            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            buttons = Buttons;
            runTime = Runtime.getRuntime();

            Prep();
        }

        /// <summary>
        /// A method used to determine if GPIO is enabled on the current environment.
        /// </summary>
        /// <returns>A bool flag indicating if GPIO is enabled on the current environment.</returns>
        public virtual bool IsEnabled()
        {
            return gpioEnabled;
        }

        /// <summary>
        /// A method used to set the bool flag to determine if the GPIO is enabled on the current environment.
        /// </summary>
        /// <param name="b">A bool argument used to set if GPIO is enabled on the current environment.</param>
        public virtual void SetEnabled(bool b)
        {
            gpioEnabled = b;
        }

        /// <summary>
        /// A method that returns the current array of GpioPin instances.
        /// </summary>
        /// <returns>An array of GpioPin instances used by the GpioHub for state monitoring.</returns>
        public virtual GpioPin[] GetButtons()
        {
            return buttons;
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the given array index, i, is enabled.
        /// </summary>
        /// <param name="i">An argument indicating which array index, GpioPin, to verify is enabled.</param>
        /// <returns>A bool indicating if the GpioPin at the given index is enabled.</returns>
        public virtual bool ButtonEnabled(int i)
        {
            if (buttons != null && i >= 0 && i < buttons.Length && buttons[i] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the DOWN index position
        /// of the buttons array is pressed.
        /// </summary>
        /// <returns>A bool indicating if the DOWN GpioPin is pressed or not.</returns>
        public virtual bool GetDownPressed()
        {
            if (ButtonEnabled(DOWN) && buttons[DOWN].checkPressed == true)
            {
                return buttons[DOWN].pressed;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the DOWN index position
        /// of the buttons array is released.
        /// </summary>
        /// <returns>A bool indicating if the DOWN GpioPin is released or not.</returns>
        public virtual bool GetDownReleased()
        {
            if (ButtonEnabled(DOWN) && buttons[DOWN].checkReleased == true)
            {
                return buttons[DOWN].released;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the DOWN index position
        /// of the buttons array has been clicked.
        /// </summary>
        /// <returns>A bool indicating if the DOWN GpioPin has been clicked or not.</returns>
        public virtual bool GetDownClicked()
        {
            if (ButtonEnabled(DOWN) && buttons[DOWN].checkClicked == true)
            {
                return buttons[DOWN].clicked;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the UP index position
        /// of the buttons array is pressed.
        /// </summary>
        /// <returns>A bool indicating if the UP GpioPin is pressed or not.</returns>
        public virtual bool GetUpPressed()
        {
            if (ButtonEnabled(UP) && buttons[UP].checkPressed == true)
            {
                return buttons[UP].pressed;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the UP index position
        /// of the buttons array is released.
        /// </summary>
        /// <returns>A bool indicating if the UP GpioPin is released or not.</returns>
        public virtual bool GetUpReleased()
        {
            if (ButtonEnabled(UP) && buttons[UP].checkReleased == true)
            {
                return buttons[UP].released;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the UP index position
        /// of the buttons array has been clicked.
        /// </summary>
        /// <returns>A bool indicating if the UP GpioPin has been clicked or not.</returns>
        public virtual bool GetUpClicked()
        {
            if (ButtonEnabled(UP) && buttons[UP].checkClicked == true)
            {
                return buttons[UP].clicked;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the LEFT index position
        /// of the buttons array is pressed.
        /// </summary>
        /// <returns>A bool indicating if the LEFT GpioPin is pressed or not.</returns>
        public virtual bool GetLeftPressed()
        {
            if (ButtonEnabled(LEFT) && buttons[LEFT].checkPressed == true)
            {
                return buttons[LEFT].pressed;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the LEFT index position
        /// of the buttons array is released.
        /// </summary>
        /// <returns>A bool indicating if the LEFT GpioPin is released or not.</returns>
        public virtual bool GetLeftReleased()
        {
            if (ButtonEnabled(LEFT) && buttons[LEFT].checkReleased == true)
            {
                return buttons[LEFT].released;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the LEFT index position
        /// of the buttons array has been clicked.
        /// </summary>
        /// <returns>A bool indicating if the LEFT GpioPin has been clicked or not.</returns>
        public virtual bool GetLeftClicked()
        {
            if (ButtonEnabled(LEFT) && buttons[LEFT].checkClicked == true)
            {
                return buttons[LEFT].clicked;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the RIGHT index position
        /// of the buttons array is pressed.
        /// </summary>
        /// <returns>A bool indicating if the RIGHT GpioPin is pressed or not.</returns>
        public virtual bool GetRightPressed()
        {
            if (ButtonEnabled(RIGHT) && buttons[RIGHT].checkPressed == true)
            {
                return buttons[RIGHT].pressed;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the RIGHT index position
        /// of the buttons array is released.
        /// </summary>
        /// <returns>A bool indicating if the RIGHT GpioPin is released or not.</returns>
        public virtual bool GetRightReleased()
        {
            if (ButtonEnabled(RIGHT) && buttons[RIGHT].checkReleased == true)
            {
                return buttons[RIGHT].released;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the RIGHT index position
        /// of the buttons array has been clicked.
        /// </summary>
        /// <returns>A bool indicating if the RIGHT GpioPin has been clicked or not.</returns>
        public virtual bool GetRightClicked()
        {
            if (ButtonEnabled(RIGHT) && buttons[RIGHT].checkClicked == true)
            {
                return buttons[RIGHT].clicked;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the A index position
        /// of the buttons array is pressed.
        /// </summary>
        /// <returns>A bool indicating if the A GpioPin is pressed or not.</returns>
        public virtual bool GetAPressed()
        {
            if (ButtonEnabled(A) && buttons[A].checkPressed == true)
            {
                return buttons[A].pressed;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the A index position
        /// of the buttons array is released.
        /// </summary>
        /// <returns>A bool indicating if the A GpioPin is released or not.</returns>
        public virtual bool GetAReleased()
        {
            if (ButtonEnabled(A) && buttons[A].checkReleased == true)
            {
                return buttons[A].released;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the A index position
        /// of the buttons array has been clicked.
        /// </summary>
        /// <returns>A bool indicating if the A GpioPin has been clicked or not.</returns>
        public virtual bool GetAClicked()
        {
            if (ButtonEnabled(A) && buttons[A].checkClicked == true)
            {
                return buttons[A].clicked;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the B index position
        /// of the buttons array is pressed.
        /// </summary>
        /// <returns>A bool indicating if the B GpioPin is pressed or not.</returns>
        public virtual bool GetBPressed()
        {
            if (ButtonEnabled(B) && buttons[B].checkPressed == true)
            {
                return buttons[B].pressed;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the B index position
        /// of the buttons array is released.
        /// </summary>
        /// <returns>A bool indicating if the B GpioPin is released or not.</returns>
        public virtual bool GetBReleased()
        {
            if (ButtonEnabled(B) && buttons[B].checkReleased == true)
            {
                return buttons[B].released;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method that returns a bool flag indicating if the GpioPin at the B index position
        /// of the buttons array has been clicked.
        /// </summary>
        /// <returns>A bool indicating if the B GpioPin has been clicked or not.</returns>
        public virtual bool GetBClicked()
        {
            if (ButtonEnabled(B) && buttons[B].checkClicked == true)
            {
                return buttons[B].clicked;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A method to set the pin state of a GPIO pin.
        /// </summary>
        /// <param name="pinIdx">An argument indicating which GPIO pin to set.</param>
        /// <param name="high">An argument indicating what state to set the GPIO pin, high or low.</param>
        public virtual void SetGpioPin(int pinIdx, bool high)
        {
            if (buttons != null && (pinIdx >= 0 || pinIdx < buttons.Length))
            {
                buttons[pinIdx].pinHigh = high;
                if (buttons[pinIdx].pinHigh == true)
                {
                    runTime.exec("echo 1 > /sys/class/gpio/gpio" + buttons[pinIdx].pinNum + "/value");
                }
                else
                {
                    runTime.exec("echo 0 > /sys/class/gpio/gpio" + buttons[pinIdx].pinNum + "/value");
                }
            }
        }

        /// <summary>
        /// An initialization method to prepare the GPIO pins by setting them to unexport, then setting them to export
        /// followed by setting the pin's current state.
        /// </summary>
        private void Prep()
        {
            try
            {
                prepped = false;
                if (runTime != null && buttons != null)
                {
                    for (i = 0; i < LEN; i++)
                    {
                        btn1 = buttons[i];
                        runTime.exec("echo " + btn1.pinNum + " > /sys/class/gpio/unexport");
                        runTime.exec("echo " + btn1.pinNum + " > /sys/class/gpio/export");
                        if (btn1.pinIn == false)
                        {
                            runTime.exec("echo out > /sys/class/gpio/gpio" + btn1.pinNum + "/direction");
                            if (btn1.pinHigh == true)
                            {
                                runTime.exec("echo 1 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");
                            }
                            else
                            {
                                runTime.exec("echo 0 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");
                            }
                        }
                        else
                        {
                            if (btn1.pinHigh == true)
                            {
                                runTime.exec("echo 1 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");
                            }
                            else
                            {
                                runTime.exec("echo 0 > /sys/class/gpio/gpio" + btn1.pinNum + "/value");
                            }
                            runTime.exec("echo in > /sys/class/gpio/gpio" + btn1.pinNum + "/direction");
                        }
                    }
                    prepped = true;

                }
            }
            catch (Exception e)
            {
                prepped = false;
                MmgHelper.wrErr(e);

            }
        }

        /// <summary>
        /// A method that returns the prepped state of the GPIO pins, buttons array.
        /// </summary>
        /// <returns>A bool value indicating that the GPIO pins have been prepped.</returns>
        public virtual bool IsPrepped()
        {
            return prepped;
        }

        /// <summary>
        /// A method that cleans up all the pins so that their state can be used to determine if a press, release, or click
        /// has happened for a given GPIO pin.
        /// </summary>
        public virtual void CleanUp()
        {
            for (j = 0; j < LEN; j++)
            {
                btn2 = buttons[j];
                btn2.pressed = false;
                btn2.clicked = false;
                btn2.released = false;
            }
        }

        /// <summary>
        /// A method to determine the state of the GPIO pins. 
        /// The methods scans all the GPIO pins in the buttons array to determine the state of each button.
        /// </summary>
        public virtual void GetState()
        {
            if (gpioEnabled == true)
            {
                try
                {
                    for (k = 0; k < LEN; k++)
                    {
                        btn3 = buttons[k];
                        tmp = runTime.exec("cat /sys/class/gpio/gpio" + btn3.pinNum + "/value"); //.getInputStream().read();

                        if (tmp == char0toInt)
                        {
                            btn3.stateTmp = false;
                        }
                        else
                        {
                            btn3.stateTmp = true;
                        }

                        btn3.statePrev = btn3.stateCurrent;
                        btn3.stateCurrent = btn3.stateTmp;

                        if (btn3.stateCurrent == false && btn3.statePrev == true)
                        {
                            btn3.released = true;
                            btn3.clicked = true;
                            btn3.pressed = false;

                        }
                        else if (btn3.stateCurrent == true && btn3.statePrev == false)
                        {
                            btn3.released = false;
                            btn3.clicked = false;
                            btn3.pressed = true;

                        }
                    }

                }
                catch (Exception e)
                {
                    gpioEnabled = false;
                    throw (e);
                }
            }
        }
    }
}