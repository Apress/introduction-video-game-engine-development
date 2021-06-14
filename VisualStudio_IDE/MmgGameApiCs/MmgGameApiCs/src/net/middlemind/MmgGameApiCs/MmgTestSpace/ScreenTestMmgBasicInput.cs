using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen class that extends the MmgGameScreen base class.
    /// This class is for testing API classes.
    /// Created by Middlemind Games 02/25/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class ScreenTestMmgBasicInput : MmgGameScreen, GenericEventHandler, MmgEventHandler
    {
        /// <summary>
        /// The game state this screen has.
        /// </summary>
        protected readonly GameStates gameState;

        /// <summary>
        /// Event handler for firing generic events. 
        /// Events would fire when the screen has non UI actions to broadcast.
        /// </summary>
        protected GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen. 
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        protected readonly GamePanel owner;

        /// <summary>
        /// An MmgFont class instance for tracking A button press events.
        /// </summary>
        private MmgFont processABtnPress;

        /// <summary>
        /// An MmgFont class instance for tracking A button release events.
        /// </summary>
        private MmgFont processABtnRelease;

        /// <summary>
        /// An MmgFont class instance for tracking A button click events.
        /// </summary>
        private MmgFont processABtnClick;

        /// <summary>
        /// An MmgFont class instance for tracking A button press events.
        /// </summary>
        private MmgFont processBBtnPress;

        /// <summary>
        /// An MmgFont class instance for tracking A button release events.
        /// </summary>
        private MmgFont processBBtnRelease;

        /// <summary>
        /// An MmgFont class instance for tracking A button click events.
        /// </summary>
        private MmgFont processBBtnClick;

        /// <summary>
        /// An MmgFont class instance for tracking "Debug" events.
        /// </summary>
        private MmgFont processDebugClick;

        /// <summary>
        /// An MmgFont class instance for tracking Up button press events.
        /// </summary>
        private MmgFont processUpBtnPress;

        /// <summary>
        /// An MmgFont class instance for tracking Up button release events.
        /// </summary>
        private MmgFont processUpBtnRelease;

        /// <summary>
        /// An MmgFont class instance for tracking Up button click events.
        /// </summary>
        private MmgFont processUpBtnClick;

        /// <summary>
        /// An MmgFont class instance for tracking Down button press events.
        /// </summary>
        private MmgFont processDownBtnPress;

        /// <summary>
        /// An MmgFont class instance for tracking Down button release events.
        /// </summary>
        private MmgFont processDownBtnRelease;

        /// <summary>
        /// An MmgFont class instance for tracking Down button click events.
        /// </summary>
        private MmgFont processDownBtnClick;

        /// <summary>
        /// An MmgFont class instance for tracking Left button press events.
        /// </summary>
        private MmgFont processLeftBtnPress;

        /// <summary>
        /// An MmgFont class instance for tracking Left button release events.
        /// </summary>
        private MmgFont processLeftBtnRelease;

        /// <summary>
        /// An MmgFont class instance for tracking Left button click events.
        /// </summary>
        private MmgFont processLeftBtnClick;

        /// <summary>
        /// An MmgFont class instance for tracking Right button press events.
        /// </summary>
        private MmgFont processRightBtnPress;

        /// <summary>
        /// An MmgFont class instance for tracking Right button release events.
        /// </summary>
        private MmgFont processRightBtnRelease;

        /// <summary>
        /// An MmgFont class instance for tracking Right button click events.
        /// </summary>
        private MmgFont processRightBtnClick;

        /// <summary>
        /// An MmgFont class instance for tracking keyboard press events.
        /// </summary>
        private MmgFont processKeyPress;

        /// <summary>
        /// An MmgFont class instance for tracking keyboard release events.
        /// </summary>
        private MmgFont processKeyRelease;

        /// <summary>
        /// An MmgFont class instance for tracking keyboard click events.
        /// </summary>
        private MmgFont processKeyClick;

        /// <summary>
        /// An MmgFont class instance for tracking mouse press events.
        /// </summary>
        private MmgFont processMousePress;

        /// <summary>
        /// An MmgFont class instance for tracking mouse release events.
        /// </summary>
        private MmgFont processMouseRelease;

        /// <summary>
        /// An MmgFont class instance for tracking mouse click events.
        /// </summary>
        private MmgFont processMouseClick;

        /// <summary>
        /// An MmgFont class instance for tracking mouse move events.
        /// </summary>
        private MmgFont processMouseMove;

        /// <summary>
        /// A private temporary MmgFont class instance used internally. 
        /// </summary>
        private MmgFont instr;

        /// <summary>
        /// An MmgFont class instance used as the title for the test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// A private bool flag used to indicate work has to be done on the next MmgUpdate method call.
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// A private bool flag used in the MmgUpdate method to indicate that work has been done this MmgUpdate call.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenTestMmgBasicInput(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgBasicInput.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// Gets the GenericEventHandler this game screen uses to handle GenericEvents.
        /// </summary>
        /// <returns>The GenericEventHandler this screen uses to handle GenericEvents.</returns>
        public virtual GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public virtual void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Basic Input (9 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            int yDiff = MmgHelper.ScaleValue(25);
            int yStrt = GetY() + MmgHelper.ScaleValue(60);
            int xLeft = MmgHelper.ScaleValue(20);
            int i = 0;

            processABtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processABtnPress.SetText("ProcessABtnPress (A): ");
            processABtnPress.SetX(xLeft);
            processABtnPress.SetY(yStrt + (yDiff * i));
            AddObj(processABtnPress);
            i++;

            processABtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processABtnRelease.SetText("ProcessABtnRelease (A): ");
            processABtnRelease.SetX(xLeft);
            processABtnRelease.SetY(yStrt + (yDiff * i));
            AddObj(processABtnRelease);
            i++;

            processABtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processABtnClick.SetText("ProcessABtnClick (A): ");
            processABtnClick.SetX(xLeft);
            processABtnClick.SetY(yStrt + (yDiff * i));
            AddObj(processABtnClick);
            i++;

            processBBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processBBtnPress.SetText("ProcessBBtnPress (A): ");
            processBBtnPress.SetX(xLeft);
            processBBtnPress.SetY(yStrt + (yDiff * i));
            AddObj(processBBtnPress);
            i++;

            processBBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processBBtnRelease.SetText("ProcessBBtnRelease (A): ");
            processBBtnRelease.SetX(xLeft);
            processBBtnRelease.SetY(yStrt + (yDiff * i));
            AddObj(processBBtnRelease);
            i++;

            processBBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processBBtnClick.SetText("ProcessBBtnClick (B): ");
            processBBtnClick.SetX(xLeft);
            processBBtnClick.SetY(yStrt + (yDiff * i));
            AddObj(processBBtnClick);
            i++;

            processDebugClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processDebugClick.SetText("ProcessDebugClick (D): ");
            processDebugClick.SetX(xLeft);
            processDebugClick.SetY(yStrt + (yDiff * i));
            AddObj(processDebugClick);
            i++;

            processUpBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processUpBtnPress.SetText("ProcessUpBtnPress: ");
            processUpBtnPress.SetX(xLeft);
            processUpBtnPress.SetY(yStrt + (yDiff * i));
            AddObj(processUpBtnPress);
            i++;

            processUpBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processUpBtnRelease.SetText("ProcessUpBtnRelease: ");
            processUpBtnRelease.SetX(xLeft);
            processUpBtnRelease.SetY(yStrt + (yDiff * i));
            AddObj(processUpBtnRelease);
            i++;

            processUpBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processUpBtnClick.SetText("ProcessUpBtnClick: ");
            processUpBtnClick.SetX(xLeft);
            processUpBtnClick.SetY(yStrt + (yDiff * i));
            AddObj(processUpBtnClick);
            i++;

            processDownBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processDownBtnPress.SetText("ProcessDownBtnPress: ");
            processDownBtnPress.SetX(xLeft);
            processDownBtnPress.SetY(yStrt + (yDiff * i));
            AddObj(processDownBtnPress);
            i++;

            processDownBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processDownBtnRelease.SetText("ProcessDownBtnRelease: ");
            processDownBtnRelease.SetX(xLeft);
            processDownBtnRelease.SetY(yStrt + (yDiff * i));
            AddObj(processDownBtnRelease);
            i++;

            processDownBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processDownBtnClick.SetText("ProcessDownBtnClick: ");
            processDownBtnClick.SetX(xLeft);
            processDownBtnClick.SetY(yStrt + (yDiff * i));
            AddObj(processDownBtnClick);
            i++;

            xLeft = GetWidth() / 2 + MmgHelper.ScaleValue(50);
            i = 0;
            processLeftBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processLeftBtnPress.SetText("ProcessLeftBtnPress: ");
            processLeftBtnPress.SetX(xLeft);
            processLeftBtnPress.SetY(yStrt + (yDiff * i));
            AddObj(processLeftBtnPress);
            i++;

            processLeftBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processLeftBtnRelease.SetText("ProcessLeftBtnRelease: ");
            processLeftBtnRelease.SetX(xLeft);
            processLeftBtnRelease.SetY(yStrt + (yDiff * i));
            AddObj(processLeftBtnRelease);
            i++;

            processLeftBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processLeftBtnClick.SetText("ProcessLeftBtnClick: ");
            processLeftBtnClick.SetX(xLeft);
            processLeftBtnClick.SetY(yStrt + (yDiff * i));
            AddObj(processLeftBtnClick);
            i++;

            processRightBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processRightBtnPress.SetText("ProcessRightBtnPress: ");
            processRightBtnPress.SetX(xLeft);
            processRightBtnPress.SetY(yStrt + (yDiff * i));
            AddObj(processRightBtnPress);
            i++;

            processRightBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processRightBtnRelease.SetText("ProcessRightBtnRelease: ");
            processRightBtnRelease.SetX(xLeft);
            processRightBtnRelease.SetY(yStrt + (yDiff * i));
            AddObj(processRightBtnRelease);
            i++;

            processRightBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processRightBtnClick.SetText("ProcessRightBtnClick: ");
            processRightBtnClick.SetX(xLeft);
            processRightBtnClick.SetY(yStrt + (yDiff * i));
            AddObj(processRightBtnClick);
            i++;

            processKeyPress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processKeyPress.SetText("ProcessKeyPress: ");
            processKeyPress.SetX(xLeft);
            processKeyPress.SetY(yStrt + (yDiff * i));
            AddObj(processKeyPress);
            i++;

            processKeyRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processKeyRelease.SetText("ProcessKeyRelease: ");
            processKeyRelease.SetX(xLeft);
            processKeyRelease.SetY(yStrt + (yDiff * i));
            AddObj(processKeyRelease);
            i++;

            processKeyClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processKeyClick.SetText("ProcessKeyClick: ");
            processKeyClick.SetX(xLeft);
            processKeyClick.SetY(yStrt + (yDiff * i));
            AddObj(processKeyClick);
            i++;

            processMousePress = MmgFontData.CreateDefaultBoldMmgFontSm();
            processMousePress.SetText("ProcessMousePress: ");
            processMousePress.SetX(xLeft);
            processMousePress.SetY(yStrt + (yDiff * i));
            AddObj(processMousePress);
            i++;

            processMouseRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
            processMouseRelease.SetText("ProcessMouseRelease: ");
            processMouseRelease.SetX(xLeft);
            processMouseRelease.SetY(yStrt + (yDiff * i));
            AddObj(processMouseRelease);
            i++;

            processMouseClick = MmgFontData.CreateDefaultBoldMmgFontSm();
            processMouseClick.SetText("ProcessMouseClick: ");
            processMouseClick.SetX(xLeft);
            processMouseClick.SetY(yStrt + (yDiff * i));
            AddObj(processMouseClick);
            i++;

            processMouseMove = MmgFontData.CreateDefaultBoldMmgFontSm();
            processMouseMove.SetText("ProcessMouseMove: ");
            processMouseMove.SetX(xLeft);
            processMouseMove.SetY(yStrt + (yDiff * i));
            AddObj(processMouseMove);
            i++;

            instr = MmgFontData.CreateDefaultMmgFontSm();
            instr.SetText("Press 'L' to navigate left, press 'R' to navigate right.");
            MmgHelper.CenterHor(instr);
            instr.SetY(GetY() + GetHeight() - MmgHelper.ScaleValue(25));
            AddObj(instr);

            ready = true;
            pause = false;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMousePress(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenPress");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMousePress(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenPress");
            processMousePress.SetText("ProcessMousePress: X: " + x + " Y: " + y);
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenRelease");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenRelease");
            processMouseRelease.SetText("ProcessMouseRelease: X: " + x + " Y: " + y);
            return true;
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessMouseClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessMouseClick");
            processMouseClick.SetText("ProcessMouseClick: X: " + x + " Y: " + y);
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y coordinate that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseMove(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessMouseMove");
            processMouseMove.SetText("ProcessMouseMove: X: " + x + " Y: " + y);
            return true;
        }

        /// <summary>
        /// A method to handle A press events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAPress(int src)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessAPress");
            processABtnPress.SetText("ProcessABtnPress (A): " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            return true;
        }

        /// <summary>
        /// A method to handle A release events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessARelease(int src)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessARelease");
            processABtnRelease.SetText("ProcessABtnRelease (A): " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessAClick");
            processABtnClick.SetText("ProcessABtnClick (A): " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            return true;
        }

        /// <summary>
        /// A method to handle B press events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBPress(int src)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessBPress");
            processBBtnPress.SetText("ProcessBBtnPress (A): " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            return true;
        }

        /// <summary>
        /// A method to handle B release events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBRelease(int src)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessBRelease");
            processBBtnRelease.SetText("ProcessBBtnRelease (A): " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessBClick");
            processBBtnClick.SetText("ProcessBBtnClick (B): " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDebugClick");
            processDebugClick.SetText("ProcessDebugClick (D): " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDpadPress: " + dir);
            if (dir == GameSettings.UP_KEYBOARD)
            {
                processUpBtnPress.SetText("ProcessUpBtnPress: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.DOWN_KEYBOARD)
            {
                processDownBtnPress.SetText("ProcessDownBtnPress: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                processLeftBtnPress.SetText("ProcessLeftBtnPress: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                processRightBtnPress.SetText("ProcessRightBtnPress: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.UP_KEYBOARD)
            {
                processUpBtnRelease.SetText("ProcessUpBtnRelease: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.DOWN_KEYBOARD)
            {
                processDownBtnRelease.SetText("ProcessDownBtnRelease: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                processLeftBtnRelease.SetText("ProcessLeftBtnRelease: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                processRightBtnRelease.SetText("ProcessRightBtnRelease: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            return true;
        }

        /// <summary>
        /// A method to handle dpad click events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadClick(int dir)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDpadClick: " + dir);
            if (dir == GameSettings.UP_KEYBOARD)
            {
                processUpBtnClick.SetText("ProcessUpBtnClick: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.DOWN_KEYBOARD)
            {
                processDownBtnClick.SetText("ProcessDownBtnClick: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                processLeftBtnClick.SetText("ProcessLeftBtnClick: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                processRightBtnClick.SetText("ProcessRightBtnClick: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            return true;
        }

        /// <summary>
        /// A method to handle keyboard press events.
        /// </summary>
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessKeyPress(char c, int code)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessKeyPress: " + code);
            processKeyPress.SetText(("ProcessKeyPress: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
            return true;
        }

        /// <summary>
        /// A method to handle keyboard release events.
        /// </summary>
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessKeyRelease(char c, int code)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessKeyRelease: " + code);
            processKeyRelease.SetText(("ProcessKeyRelease: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
            if (c == 'l' || c == 'L')
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_08);
            }
            else if (c == 'r' || c == 'R')
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_10);
            }
            return true;
        }

        /// <summary>
        /// A method to handle keyboard click events.
        /// </summary>
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessKeyClick(char c, int code)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.ProcessKeyClick: " + code);
            processKeyClick.SetText(("ProcessKeyClick: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            title = null;
            processABtnClick = null;
            processBBtnClick = null;
            processDownBtnClick = null;
            processDownBtnPress = null;
            processDownBtnRelease = null;
            processKeyClick = null;
            processKeyPress = null;
            processKeyRelease = null;
            processLeftBtnClick = null;
            processLeftBtnPress = null;
            processLeftBtnRelease = null;
            processRightBtnClick = null;
            processRightBtnPress = null;
            processRightBtnRelease = null;
            processUpBtnClick = null;
            processUpBtnPress = null;
            processUpBtnRelease = null;

            ClearObjs();
            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// </summary>
        /// <returns>The game state of this game screen.</returns>
        public virtual GameStates GetGameState()
        {
            return gameState;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// The callback method to handle GenericEventMessage objects.
        /// </summary>
        /// <param name="obj">A GenericEventMessage object instance to process.</param>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgBasicInput.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}