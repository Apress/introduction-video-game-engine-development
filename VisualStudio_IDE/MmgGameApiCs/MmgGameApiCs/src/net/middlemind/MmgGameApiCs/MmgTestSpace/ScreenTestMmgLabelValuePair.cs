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
    public class ScreenTestMmgLabelValuePair : MmgGameScreen, GenericEventHandler, MmgEventHandler
    {
        /// <summary>
        /// The game state this screen has.
        /// </summary>
        protected readonly GameStates gameState;

        /// <summary>
        /// Event handler for firing generic events.
        ///  Events would fire when the screen has non UI actions to broadcast.
        /// </summary>
        protected GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen.
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        protected readonly GamePanel owner;

        /// <summary>
        /// An MmgFont class instance that is used as the label font for an MmgLabelValuePair class instance. 
        /// </summary>
        private MmgFont labelFont;

        /// <summary>
        /// An MmgFont class instance that is used as the value font for an MmgLabelValuePair class instance. 
        /// </summary>
        private MmgFont valueFont;

        /// <summary>
        /// An MmgLabelValuePair class instance used as the first example.
        /// </summary>
        private MmgLabelValuePair lvPair1;

        /// <summary>
        /// An MmgLabelValuePair class instance used as the second example.
        /// </summary>
        private MmgLabelValuePair lvPair2;

        /// <summary>
        /// An MmgLabelValuePair class instance used as the third example.
        /// </summary>
        private MmgLabelValuePair lvPair3;

        /// <summary>
        /// An MmgFont class instance that is used as the title for this test game screen.
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
        public ScreenTestMmgLabelValuePair(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgLabelValuePair.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.SetGenericEventHandler");
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
            MmgHelper.wr("ScreenTestMmgLabelValuePair.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Label Value Pair (13 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            labelFont = MmgFontData.CreateDefaultBoldMmgFontLg();
            labelFont.SetMmgColor(MmgColor.GetGrayWolf());
            labelFont.SetText("Label1:");

            valueFont = MmgFontData.CreateDefaultBoldMmgFontSm();
            valueFont.SetMmgColor(MmgColor.GetBlueGray());
            valueFont.SetText("Value1");

            lvPair1 = new MmgLabelValuePair(labelFont, valueFont);
            MmgHelper.CenterHorAndVert(lvPair1);
            lvPair1.SetY(lvPair1.GetY() - MmgHelper.ScaleValue(30));
            AddObj(lvPair1);

            labelFont = labelFont.CloneTyped();
            labelFont.SetMmgColor(MmgColor.GetGrayWolf());
            labelFont.SetText("Label2:");

            valueFont = valueFont.CloneTyped();
            valueFont.SetMmgColor(MmgColor.GetSlateBlue());
            valueFont.SetText("Value2");

            lvPair2 = new MmgLabelValuePair(labelFont, valueFont);
            MmgHelper.CenterHorAndVert(lvPair2);
            lvPair2.SetY(lvPair2.GetY() + 0);
            AddObj(lvPair2);

            labelFont = labelFont.CloneTyped();
            labelFont.SetMmgColor(MmgColor.GetGrayWolf());
            labelFont.SetText("Label3:");

            valueFont = valueFont.CloneTyped();
            valueFont.SetMmgColor(MmgColor.GetCalmBlue());
            valueFont.SetText("Value3");

            lvPair3 = new MmgLabelValuePair(labelFont, valueFont);
            MmgHelper.CenterHorAndVert(lvPair3);
            lvPair3.SetY(lvPair3.GetY() + MmgHelper.ScaleValue(30));
            AddObj(lvPair3);

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
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_14);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_12);

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
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgLabelValuePair.ProcessKeyClick");
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
            MmgHelper.wr("ScreenTestMmgLabelValuePair.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgLabelValuePair.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}