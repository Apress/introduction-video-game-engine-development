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
    public class ScreenTestMmgColor : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An MmgFont instance used as a label for the first color entry.
        /// </summary>
        private MmgFont color1Label;

        /// <summary>
        /// An MmgFont instance used as a label for the second color entry.
        /// </summary>
        private MmgFont color2Label;

        /// <summary>
        /// An MmgFont instance used as a label for the third color entry.
        /// </summary>
        private MmgFont color3Label;

        /// <summary>
        /// An MmgFont instance used as a label for the fourth color entry.
        /// </summary>
        private MmgFont color4Label;

        /// <summary>
        /// An MmgFont instance used as a label for the fifth color entry.
        /// </summary>
        private MmgFont color5Label;

        /// <summary>
        /// An MmgFont instance used as a label for the sixth color entry.
        /// </summary>
        private MmgFont color6Label;

        /// <summary>
        /// An MmgFont instance used as a label for the seventh color entry.
        /// </summary>
        private MmgFont color7Label;

        /// <summary>
        /// An MmgFont instance used as a label for the eighth color entry.
        /// </summary>
        private MmgFont color8Label;

        /// <summary>
        /// An MmgFont instance used as a label for the ninth color entry.
        /// </summary>
        private MmgFont color9Label;

        /// <summary>
        /// An MmgFont instance used as a label for the tenth color entry.
        /// </summary>
        private MmgFont color10Label;

        /// <summary>
        /// An MmgFont class instance used as the title of the test game screen.
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
        public ScreenTestMmgColor(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgColor.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgColor.SetGenericEventHandler");
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
            MmgHelper.wr("ScreenTestMmgColor.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Color (11 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            int yDiff = MmgHelper.ScaleValue(40);
            int yStrt = GetY() + MmgHelper.ScaleValue(140);
            int xLeft = MmgHelper.ScaleValue(200);
            int i = 0;

            color1Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color1Label.SetMmgColor(MmgColor.GetBlueGray());
            color1Label.SetText("Color: BlueGray");
            color1Label.SetX(xLeft);
            color1Label.SetY(yStrt + (yDiff * i));
            AddObj(color1Label);
            i++;

            color2Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color2Label.SetMmgColor(MmgColor.GetCarbonGray());
            color2Label.SetText("Color: CarbonGray");
            color2Label.SetX(xLeft);
            color2Label.SetY(yStrt + (yDiff * i));
            AddObj(color2Label);
            i++;

            color3Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color3Label.SetMmgColor(MmgColor.GetDarkRed());
            color3Label.SetText("Color: DarkRed");
            color3Label.SetX(xLeft);
            color3Label.SetY(yStrt + (yDiff * i));
            AddObj(color3Label);
            i++;

            color4Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color4Label.SetMmgColor(MmgColor.GetIridium());
            color4Label.SetText("Color: Iridium");
            color4Label.SetX(xLeft);
            color4Label.SetY(yStrt + (yDiff * i));
            AddObj(color4Label);
            i++;

            color5Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color5Label.SetMmgColor(MmgColor.GetLimeGreen());
            color5Label.SetText("Color: LimeGreen");
            color5Label.SetX(xLeft);
            color5Label.SetY(yStrt + (yDiff * i));
            AddObj(color5Label);
            i++;

            xLeft = GetWidth() / 2 + MmgHelper.ScaleValue(70);
            i = 0;

            color6Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color6Label.SetMmgColor(MmgColor.GetMaroon());
            color6Label.SetText("Color: Maroon");
            color6Label.SetX(xLeft);
            color6Label.SetY(yStrt + (yDiff * i));
            AddObj(color6Label);
            i++;

            color7Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color7Label.SetMmgColor(MmgColor.GetOil());
            color7Label.SetText("Color: Oil");
            color7Label.SetX(xLeft);
            color7Label.SetY(yStrt + (yDiff * i));
            AddObj(color7Label);
            i++;

            color8Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color8Label.SetMmgColor(MmgColor.GetOlive());
            color8Label.SetText("Color: Olive");
            color8Label.SetX(xLeft);
            color8Label.SetY(yStrt + (yDiff * i));
            AddObj(color8Label);
            i++;

            color9Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color9Label.SetMmgColor(MmgColor.GetOrange());
            color9Label.SetText("Color: Orange");
            color9Label.SetX(xLeft);
            color9Label.SetY(yStrt + (yDiff * i));
            AddObj(color9Label);
            i++;

            color10Label = MmgFontData.CreateDefaultBoldMmgFontLg();
            color10Label.SetMmgColor(MmgColor.GetPlatinum());
            color10Label.SetText("Color: Platinum");
            color10Label.SetX(xLeft);
            color10Label.SetY(yStrt + (yDiff * i));
            AddObj(color10Label);
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
            MmgHelper.wr("ScreenTestMmgColor.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgColor.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgColor.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgColor.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgColor.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgColor.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgColor.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgColor.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgColor.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_12);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_10);

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
            MmgHelper.wr("ScreenTestMmgColor.ProcessDpadClick: " + dir);
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
            MmgHelper.wr("ScreenTestMmgColor.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgColor.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgColor.ProcessKeyClick");
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
            MmgHelper.wr("ScreenTestMmgColor.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgColor.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}