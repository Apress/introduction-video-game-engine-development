using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePadInput;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    //XNA: Monogame: Needs to be reviewed.
    /// <summary>
    /// The GamePadHub class is used to provide access to up to 6 buttons from a USB game pad.
    /// Created by Middlemind Games 01/05/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class GamePadHub
    {
        /// <summary>
        /// A static integer for describing the default length of gamepad input. 
        /// </summary>
        public static int LEN = 6;

        /// <summary>
        /// A static integer for tracking the UP button on the gamepad. 
        /// </summary>
        public static int UP = 0;

        /// <summary>
        /// A static integer for tracking the DOWN button on the gamepad.
        /// </summary>
        public static int DOWN = 1;

        /// <summary>
        /// A static integer for tracking the LEFT button on the gamepad. 
        /// </summary>
        public static int LEFT = 2;

        /// <summary>
        /// A static integer for tracking the RIGHT button on the gamepad.
        /// </summary>
        public static int RIGHT = 3;

        /// <summary>
        /// A static integer for tracking the A button on the gamepad. 
        /// </summary>
        public static int A = 4;

        /// <summary>
        /// A static integer for tracking the B button on the gamepad.
        /// </summary>
        public static int B = 5;

        /// <summary>
        /// An array of GamePadInput instances used to indicate dpad, A button, and B button input. 
        /// </summary>
        public GamePadInput[] buttons = null;

        /// <summary>
        /// A bool that indicates if the GpioHub has been properly prepared.
        /// </summary>
        public bool prepped = false;

        /// <summary>
        /// A bool that indicates if GPIO input is enabled.
        /// </summary>
        public bool gamePadEnabled = false;

        //NOTE: Not supported in a Monogame implementation, input checking is explicit.
        /// <summary>
        /// A JInput controller to read gamepad data from.
        /// </summary>
        public GamePadState gamePad;

        /// <summary>
        /// An array of components supported by this gamepad.
        /// </summary>
        public Buttons[] components = null;

        /// <summary>
        /// An integer representing the index of the gampepad on the host operating system.
        /// </summary>
        public int gamePadIdx = 0;

        /// <summary>
        /// The gamepad source id from the GamSettings class to send along with input events.
        /// </summary>
        public int gamePadSrc = GameSettings.SRC_GAMEPAD_1;

        /// <summary>
        /// The gamepad code for dpad up input events.
        /// </summary>
        public int gamePadUp = GameSettings.UP_GAMEPAD_1;

        /// <summary>
        /// The gamepad code for dpad down input events.
        /// </summary>
        public int gamePadDown = GameSettings.DOWN_GAMEPAD_1;

        /// <summary>
        /// The gamepad code for dpad left input events.
        /// </summary>
        public int gamePadLeft = GameSettings.LEFT_GAMEPAD_1;

        /// <summary>
        /// The gamepad code for dpad right input events.
        /// </summary>
        public int gamePadRight = GameSettings.RIGHT_GAMEPAD_1;

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
        private GamePadInput btn1;

        /// <summary>
        /// A private temporary class field for gamepad input. 
        /// </summary>
        private GamePadInput btn2;

        /// <summary>
        /// A private temporary class field for gamepad input. 
        /// </summary>
        private GamePadInput btn3;

        /// <summary>
        /// A private array of controller found on the operating system. 
        /// </summary>
        //private Controller[] ca;

        /// <summary>
        /// A private bool flag for input processing. 
        /// </summary>
        private bool btmp;

        //NOTE:
        /// <summary>
        /// TODO:
        /// </summary>
        public static bool CHECK_BUTTON_INDEXES = false;

        /// <summary>
        /// A default constructor for the GpioHub class that checks to see if GPIO is supported on the system.
        /// Creates a default array of 6 GpioPin instances using values from the GameSettings class to set the GPIO pin numbers
        /// and the events that should be tracked.
        /// </summary>
        /// <param name="GamePadIndex">The index of the gamepad on the OS.</param>
        public GamePadHub(int GamePadIndex)
        {
            gamePadIdx = GamePadIndex;
            gamePad = GamePad.GetState(Pad2Player(gamePadIdx));

            gamePadSrc = GameSettings.SRC_GAMEPAD_1;
            gamePadUp = GameSettings.UP_GAMEPAD_1;
            gamePadDown = GameSettings.DOWN_GAMEPAD_1;
            gamePadLeft = GameSettings.LEFT_GAMEPAD_1;
            gamePadRight = GameSettings.RIGHT_GAMEPAD_1;

            buttons = new GamePadInput[6];
            buttons[0] = new GamePadInput(GameSettings.GAMEPAD_1_UP_INDEX, GameSettings.GAMEPAD_1_UP_VALUE_ON, GameSettings.GAMEPAD_1_UP_VALUE_OFF, GamePadButton.BtnUp, GameSettings.GAMEPAD_1_UP_CHECK_PRESS, GameSettings.GAMEPAD_1_UP_CHECK_RELEASE, GameSettings.GAMEPAD_1_UP_CHECK_CLICK);
            buttons[1] = new GamePadInput(GameSettings.GAMEPAD_1_DOWN_INDEX, GameSettings.GAMEPAD_1_DOWN_VALUE_ON, GameSettings.GAMEPAD_1_DOWN_VALUE_OFF, GamePadButton.BtnDown, GameSettings.GAMEPAD_1_DOWN_CHECK_PRESS, GameSettings.GAMEPAD_1_DOWN_CHECK_RELEASE, GameSettings.GAMEPAD_1_DOWN_CHECK_CLICK);
            buttons[2] = new GamePadInput(GameSettings.GAMEPAD_1_LEFT_INDEX, GameSettings.GAMEPAD_1_LEFT_VALUE_ON, GameSettings.GAMEPAD_1_LEFT_VALUE_OFF, GamePadButton.BtnLeft, GameSettings.GAMEPAD_1_LEFT_CHECK_PRESS, GameSettings.GAMEPAD_1_LEFT_CHECK_RELEASE, GameSettings.GAMEPAD_1_LEFT_CHECK_CLICK);
            buttons[3] = new GamePadInput(GameSettings.GAMEPAD_1_RIGHT_INDEX, GameSettings.GAMEPAD_1_RIGHT_VALUE_ON, GameSettings.GAMEPAD_1_RIGHT_VALUE_OFF, GamePadButton.BtnRight, GameSettings.GAMEPAD_1_RIGHT_CHECK_PRESS, GameSettings.GAMEPAD_1_RIGHT_CHECK_RELEASE, GameSettings.GAMEPAD_1_RIGHT_CHECK_CLICK);
            buttons[4] = new GamePadInput(GameSettings.GAMEPAD_1_A_INDEX, GameSettings.GAMEPAD_1_A_VALUE_ON, GameSettings.GAMEPAD_1_A_VALUE_OFF, GamePadButton.BtnA, GameSettings.GAMEPAD_1_A_CHECK_PRESS, GameSettings.GAMEPAD_1_A_CHECK_RELEASE, GameSettings.GAMEPAD_1_A_CHECK_CLICK);
            buttons[5] = new GamePadInput(GameSettings.GAMEPAD_1_B_INDEX, GameSettings.GAMEPAD_1_B_VALUE_ON, GameSettings.GAMEPAD_1_B_VALUE_OFF, GamePadButton.BtnB, GameSettings.GAMEPAD_1_B_CHECK_PRESS, GameSettings.GAMEPAD_1_B_CHECK_RELEASE, GameSettings.GAMEPAD_1_B_CHECK_CLICK);

            AddListener();
            Prep();
        }

        /// <summary>
        /// A default constructor for the GpioHub class that checks to see if GPIO is supported on the system.
        /// Creates a default array of 6 GpioPin instances using values from the GameSettings class to set the GPIO pin numbers
        /// and the events that should be tracked.This constructor takes into account which player the gamepad input is for.
        /// </summary>
        /// <param name="player1">The player, 1 or 2, this GamePadHub is processing input for.</param>
        /// <param name="GamePadIndex">The index of the gamepad on the OS.</param>
        public GamePadHub(bool player1, int GamePadIndex)
        {
            gamePadIdx = GamePadIndex;
            gamePad = GamePad.GetState(Pad2Player(gamePadIdx));
            buttons = new GamePadInput[6];

            if (player1)
            {
                gamePadSrc = GameSettings.SRC_GAMEPAD_1;
                gamePadUp = GameSettings.UP_GAMEPAD_1;
                gamePadDown = GameSettings.DOWN_GAMEPAD_1;
                gamePadLeft = GameSettings.LEFT_GAMEPAD_1;
                gamePadRight = GameSettings.RIGHT_GAMEPAD_1;

                buttons[0] = new GamePadInput(GameSettings.GAMEPAD_1_UP_INDEX, GameSettings.GAMEPAD_1_UP_VALUE_ON, GameSettings.GAMEPAD_1_UP_VALUE_OFF, GamePadButton.BtnUp, GameSettings.GAMEPAD_1_UP_CHECK_PRESS, GameSettings.GAMEPAD_1_UP_CHECK_RELEASE, GameSettings.GAMEPAD_1_UP_CHECK_CLICK);
                buttons[1] = new GamePadInput(GameSettings.GAMEPAD_1_DOWN_INDEX, GameSettings.GAMEPAD_1_DOWN_VALUE_ON, GameSettings.GAMEPAD_1_DOWN_VALUE_OFF, GamePadButton.BtnDown, GameSettings.GAMEPAD_1_DOWN_CHECK_PRESS, GameSettings.GAMEPAD_1_DOWN_CHECK_RELEASE, GameSettings.GAMEPAD_1_DOWN_CHECK_CLICK);
                buttons[2] = new GamePadInput(GameSettings.GAMEPAD_1_LEFT_INDEX, GameSettings.GAMEPAD_1_LEFT_VALUE_ON, GameSettings.GAMEPAD_1_LEFT_VALUE_OFF, GamePadButton.BtnLeft, GameSettings.GAMEPAD_1_LEFT_CHECK_PRESS, GameSettings.GAMEPAD_1_LEFT_CHECK_RELEASE, GameSettings.GAMEPAD_1_LEFT_CHECK_CLICK);
                buttons[3] = new GamePadInput(GameSettings.GAMEPAD_1_RIGHT_INDEX, GameSettings.GAMEPAD_1_RIGHT_VALUE_ON, GameSettings.GAMEPAD_1_RIGHT_VALUE_OFF, GamePadButton.BtnRight, GameSettings.GAMEPAD_1_RIGHT_CHECK_PRESS, GameSettings.GAMEPAD_1_RIGHT_CHECK_RELEASE, GameSettings.GAMEPAD_1_RIGHT_CHECK_CLICK);
                buttons[4] = new GamePadInput(GameSettings.GAMEPAD_1_A_INDEX, GameSettings.GAMEPAD_1_A_VALUE_ON, GameSettings.GAMEPAD_1_A_VALUE_OFF, GamePadButton.BtnA, GameSettings.GAMEPAD_1_A_CHECK_PRESS, GameSettings.GAMEPAD_1_A_CHECK_RELEASE, GameSettings.GAMEPAD_1_A_CHECK_CLICK);
                buttons[5] = new GamePadInput(GameSettings.GAMEPAD_1_B_INDEX, GameSettings.GAMEPAD_1_B_VALUE_ON, GameSettings.GAMEPAD_1_B_VALUE_OFF, GamePadButton.BtnB, GameSettings.GAMEPAD_1_B_CHECK_PRESS, GameSettings.GAMEPAD_1_B_CHECK_RELEASE, GameSettings.GAMEPAD_1_B_CHECK_CLICK);

            }
            else
            {
                gamePadSrc = GameSettings.SRC_GAMEPAD_2;
                gamePadUp = GameSettings.UP_GAMEPAD_2;
                gamePadDown = GameSettings.DOWN_GAMEPAD_2;
                gamePadLeft = GameSettings.LEFT_GAMEPAD_2;
                gamePadRight = GameSettings.RIGHT_GAMEPAD_2;

                buttons[0] = new GamePadInput(GameSettings.GAMEPAD_2_UP_INDEX, GameSettings.GAMEPAD_2_UP_VALUE_ON, GameSettings.GAMEPAD_2_UP_VALUE_OFF, GamePadButton.BtnUp, GameSettings.GAMEPAD_2_UP_CHECK_PRESS, GameSettings.GAMEPAD_2_UP_CHECK_RELEASE, GameSettings.GAMEPAD_2_UP_CHECK_CLICK);
                buttons[1] = new GamePadInput(GameSettings.GAMEPAD_2_DOWN_INDEX, GameSettings.GAMEPAD_2_DOWN_VALUE_ON, GameSettings.GAMEPAD_2_DOWN_VALUE_OFF, GamePadButton.BtnDown, GameSettings.GAMEPAD_2_DOWN_CHECK_PRESS, GameSettings.GAMEPAD_2_DOWN_CHECK_RELEASE, GameSettings.GAMEPAD_2_DOWN_CHECK_CLICK);
                buttons[2] = new GamePadInput(GameSettings.GAMEPAD_2_LEFT_INDEX, GameSettings.GAMEPAD_2_LEFT_VALUE_ON, GameSettings.GAMEPAD_2_LEFT_VALUE_OFF, GamePadButton.BtnLeft, GameSettings.GAMEPAD_2_LEFT_CHECK_PRESS, GameSettings.GAMEPAD_2_LEFT_CHECK_RELEASE, GameSettings.GAMEPAD_2_LEFT_CHECK_CLICK);
                buttons[3] = new GamePadInput(GameSettings.GAMEPAD_2_RIGHT_INDEX, GameSettings.GAMEPAD_2_RIGHT_VALUE_ON, GameSettings.GAMEPAD_2_RIGHT_VALUE_OFF, GamePadButton.BtnRight, GameSettings.GAMEPAD_2_RIGHT_CHECK_PRESS, GameSettings.GAMEPAD_2_RIGHT_CHECK_RELEASE, GameSettings.GAMEPAD_2_RIGHT_CHECK_CLICK);
                buttons[4] = new GamePadInput(GameSettings.GAMEPAD_2_A_INDEX, GameSettings.GAMEPAD_2_A_VALUE_ON, GameSettings.GAMEPAD_2_A_VALUE_OFF, GamePadButton.BtnA, GameSettings.GAMEPAD_2_A_CHECK_PRESS, GameSettings.GAMEPAD_2_A_CHECK_RELEASE, GameSettings.GAMEPAD_2_A_CHECK_CLICK);
                buttons[5] = new GamePadInput(GameSettings.GAMEPAD_2_B_INDEX, GameSettings.GAMEPAD_2_B_VALUE_ON, GameSettings.GAMEPAD_2_B_VALUE_OFF, GamePadButton.BtnB, GameSettings.GAMEPAD_2_B_CHECK_PRESS, GameSettings.GAMEPAD_2_B_CHECK_RELEASE, GameSettings.GAMEPAD_2_B_CHECK_CLICK);

            }

            AddListener();
            Prep();
        }

        /// <summary>
        /// A constructor for the GpioHub that takes an array of GpioPin instances which is used to set the buttons class field.
        /// </summary>
        /// <param name="Buttons">An array of 6 GpioPin instances used to set the buttons class field.</param>
        /// <param name="GamePad">TODO: Add comment</param>
        public GamePadHub(GamePadInput[] Buttons, int GamePadIdx, GamePadState GamePad)
        {
            gamePadIdx = GamePadIdx;
            gamePad = GamePad;
            buttons = Buttons;

            AddListener();
            Prep();
        }

        //NOTE: Monogame specific addition to convert game pad integer indexes to player enumerations.
        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="gamePadIdx"></param>
        /// <returns></returns>
        public virtual PlayerIndex Pad2Player(int gamePadIdx)
        {
            if(gamePadIdx == 0)
            {
                return PlayerIndex.One;
            }
            else if(gamePadIdx == 1)
            {
                return PlayerIndex.Two;
            }
            else if(gamePadIdx == 2)
            {
                return PlayerIndex.Three;
            }
            else if(gamePadIdx == 3)
            {
                return PlayerIndex.Four;
            }
            else
            {
                return PlayerIndex.One;
            }
        }

        //NOTE: Monogame specific addition to convert 
        /// <summary>
        /// TODO:
        /// </summary>
        /// <returns></returns>
        public virtual bool IsConnected()
        {
            gamePad = GamePad.GetState(Pad2Player(gamePadIdx));
            return gamePad.IsConnected;
        }

        /// <summary>
        /// An event listener for determining if a gamepad has been disconnected or reconnected. 
        /// </summary>
        private void AddListener()
        {
            if(IsConnected())
            {
                gamePadEnabled = true;
            }
            else
            {
                gamePadEnabled = false;
                Prep();
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <returns></returns>
        public virtual Buttons[] GetComponents()
        {
            gamePad = GamePad.GetState(Pad2Player(gamePadIdx));
            Buttons[] c = new Buttons[6];
            c[0] = Buttons.DPadUp;
            c[1] = Buttons.DPadDown;
            c[2] = Buttons.DPadLeft;
            c[3] = Buttons.DPadRight;
            c[4] = Buttons.A;
            c[5] = Buttons.B;
            return c;
        }

        /// <summary>
        /// A preparation method that sets up all the button mappings using the input indexes set in the class fields.
        /// </summary>
        private void Prep()
        {
            try
            {
                prepped = false;
                if (gamePad == null)
                {
                    MmgHelper.wr("GamePadHub: Gamepad is null, disabling gamepad.");
                    gamePadEnabled = false;

                }
                else
                {
                    components = GetComponents();
                    if (components == null)
                    {
                        MmgHelper.wr("GamePadHub: Gamepad components is null, disabling gamepad.");
                        gamePadEnabled = false;

                    }
                    else
                    {
                        if (CHECK_BUTTON_INDEXES)
                        {
                            for (i = 0; i < LEN; i++)
                            {
                                btn1 = buttons[i];
                                if (btn1.btnIdx < 0 || btn1.btnIdx >= components.Length)
                                {
                                    MmgHelper.wr("GamePadHub: Gamepad button is out of the component range, " + btn1.btnIdx + ", disabling gamepad.");
                                    gamePadEnabled = false;
                                }
                            }
                        }
                        gamePadEnabled = true;

                    }
                }
                prepped = true;
                MmgHelper.wr("Gamepad hub prep is complete. State: Prepped: " + prepped + " Enabled: " + gamePadEnabled + "");

            }
            catch (Exception e)
            {
                prepped = true;
                MmgHelper.wr(e.ToString());

            }
        }

        /// <summary>
        /// A method used to determine if GPIO is enabled on the current environment.
        /// </summary>
        /// <returns>A bool flag indicating if GPIO is enabled on the current environment.</returns>
        public virtual bool IsEnabled()
        {
            return gamePadEnabled;
        }

        /// <summary>
        /// A method used to set the bool flag to determine if the GPIO is enabled on the current environment.
        /// </summary>
        /// <param name="b">A bool argument used to set if GPIO is enabled on the current environment.</param>
        public virtual void SetEnabled(bool b)
        {
            gamePadEnabled = b;
        }

        /// <summary>
        /// A method that returns the current array of GpioPin instances.
        /// </summary>
        /// <returns>An array of GpioPin instances used by the GpioHub for state monitoring.</returns>
        public virtual GamePadInput[] GetButtons()
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
        /// A method to determine the state of the GPIO pins. The methods scans all the GPIO pins in the buttons
        /// array to determine the state of each button.
        /// </summary>
        public virtual void GetState()
        {
            if (gamePadEnabled == true)
            {
                if(IsConnected())
                {
                    if (components == null)
                    {
                        components = GetComponents();
                    }

                    for (k = 0; k < LEN; k++)
                    {
                        btn3 = buttons[k];
                        if (gamePad.IsButtonDown(components[btn3.btnIdx]))
                        {
                            btn3.stateTmp = true;

                        }
                        else
                        {
                            btn3.stateTmp = false;

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
                else
                {
                    gamePadEnabled = false;
                    throw new Exception("GamePadHub: Gamepad poll failed!");

                }
            }
        }
    }
}