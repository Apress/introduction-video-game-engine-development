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
    public class ScreenTestMmgScreenData : MmgGameScreen, GenericEventHandler, MmgEventHandler
    {
        /// <summary>
        /// The game state this screen has.
        /// </summary>
        protected readonly GameStates gameState;

        /// <summary>
        /// Event handler for firing generic events. Events would fire when the
        /// screen has non UI actions to broadcast.
        /// </summary>
        protected GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen. Usually a JPanel instance that
        /// holds a reference to this game screen object.
        /// </summary>
        protected readonly GamePanel owner;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's default height.
        /// </summary>
        private MmgFont defaultHeightLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's default width.
        /// </summary>
        private MmgFont defaultWidthLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's game height.
        /// </summary>
        private MmgFont gameHeightLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's game width.
        /// </summary>
        private MmgFont gameWidthLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's left coordinate.
        /// </summary>
        private MmgFont gameLeftLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's top coordinate.
        /// </summary>
        private MmgFont gameTopLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's screen height.
        /// </summary>
        private MmgFont screenHeightLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's screen width.
        /// </summary>
        private MmgFont screenWidthLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's X scale value.
        /// </summary>
        private MmgFont scaleXLabel;

        /// <summary>
        /// An MmgFont class instance used to display the MmgScreenData's Y scale value.
        /// </summary>
        private MmgFont scaleYLabel;

        /// <summary>
        /// An MmgFont class instance used as the title for the test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// A bool flag indicating if there is work to do in the next MmgUpdate call.
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// A private bool flag used in the MmgUpdate method during the update process.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenTestMmgScreenData(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgScreenData.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgScreenData.SetGenericEventHandler");
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
            MmgHelper.wr("ScreenTestMmgScreenData.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Screen Data (1 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            int yDiff = MmgHelper.ScaleValue(40);
            int yStrt = GetY() + MmgHelper.ScaleValue(140);
            int xLeft = MmgHelper.ScaleValue(200);
            int i = 0;

            defaultHeightLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            defaultHeightLabel.SetText("DefaultHeight: " + MmgScreenData.DEFAULT_HEIGHT);
            defaultHeightLabel.SetX(xLeft);
            defaultHeightLabel.SetY(yStrt + (yDiff * i));
            AddObj(defaultHeightLabel);
            i++;

            defaultWidthLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            defaultWidthLabel.SetText("DefaultWidth: " + MmgScreenData.DEFAULT_WIDTH);
            defaultWidthLabel.SetX(xLeft);
            defaultWidthLabel.SetY(yStrt + (yDiff * i));
            AddObj(defaultWidthLabel);
            i++;

            gameHeightLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            gameHeightLabel.SetText("GameHeight: " + MmgScreenData.GetGameHeight());
            gameHeightLabel.SetX(xLeft);
            gameHeightLabel.SetY(yStrt + (yDiff * i));
            AddObj(gameHeightLabel);
            i++;

            gameWidthLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            gameWidthLabel.SetText("GameWidth: " + MmgScreenData.GetGameWidth());
            gameWidthLabel.SetX(xLeft);
            gameWidthLabel.SetY(yStrt + (yDiff * i));
            AddObj(gameWidthLabel);
            i++;

            gameLeftLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            gameLeftLabel.SetText("GameLeft: " + MmgScreenData.GetGameLeft());
            gameLeftLabel.SetX(xLeft);
            gameLeftLabel.SetY(yStrt + (yDiff * i));
            AddObj(gameLeftLabel);
            i++;

            xLeft = GetWidth() / 2 + MmgHelper.ScaleValue(70);
            i = 0;

            gameTopLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            gameTopLabel.SetText("GameTop: " + MmgScreenData.GetGameTop());
            gameTopLabel.SetX(xLeft);
            gameTopLabel.SetY(yStrt + (yDiff * i));
            AddObj(gameTopLabel);
            i++;

            screenHeightLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            screenHeightLabel.SetText("ScreenHeight: " + MmgScreenData.GetScreenHeight());
            screenHeightLabel.SetX(xLeft);
            screenHeightLabel.SetY(yStrt + (yDiff * i));
            AddObj(screenHeightLabel);
            i++;

            screenWidthLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            screenWidthLabel.SetText("ScreenWidth: " + MmgScreenData.GetScreenWidth());
            screenWidthLabel.SetX(xLeft);
            screenWidthLabel.SetY(yStrt + (yDiff * i));
            AddObj(screenWidthLabel);
            i++;

            scaleXLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            scaleXLabel.SetText("ScaleX: " + String.Format("{0:0.0}", MmgScreenData.GetScaleX()));
            scaleXLabel.SetX(xLeft);
            scaleXLabel.SetY(yStrt + (yDiff * i));
            AddObj(scaleXLabel);
            i++;

            scaleYLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            scaleYLabel.SetText("ScaleY: " + String.Format("{0:0.0}", MmgScreenData.GetScaleY()));
            scaleYLabel.SetX(xLeft);
            scaleYLabel.SetY(yStrt + (yDiff * i));
            AddObj(scaleYLabel);
            i++;

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
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_02);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_26);

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
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessDpadClick: " + dir);
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
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgScreenData.ProcessKeyClick");
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
            defaultHeightLabel = null;
            defaultWidthLabel = null;
            gameHeightLabel = null;
            gameLeftLabel = null;
            gameTopLabel = null;
            gameWidthLabel = null;

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
        /// The main drawing routine.
        /// </summary>
        /// <param name="p">An MmgPen object to use for drawing this game screen.</param>
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
            MmgHelper.wr("ScreenTestMmgScreenData.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgScreenData.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}