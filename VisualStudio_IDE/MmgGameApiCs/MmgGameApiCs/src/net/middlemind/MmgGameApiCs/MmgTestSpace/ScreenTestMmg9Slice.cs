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
    public class ScreenTestMmg9Slice : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An MmgFont class instance used to label the background MmgBmp class.
        /// </summary>
        private MmgFont bgroundLabel;

        /// <summary>
        /// An MmgFont class instance used as the title of this test screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// An MmgBmp class instance used as the source of the Mmg9Slice scaling object.
        /// </summary>
        private MmgBmp bground;

        /// <summary>
        /// An MmgFont class instance used as the Mmg9Slice label.
        /// </summary>
        private MmgFont menuBgroundLabel;

        /// <summary>
        /// An Mmg9Slice class instance used to scale the MmgBmp bground object.
        /// </summary>
        private Mmg9Slice menuBground;

        /// <summary>
        /// A private bool flag indicating that there is work to be done on the next MmgUpdate call.
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// A private bool flag indicating work was done during the MmgUpdate method call.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenTestMmg9Slice(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmg9Slice.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmg9Slice.SetGenericEventHandler");
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
            MmgHelper.wr("ScreenTestMmg9Slice.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            MmgPen p;
            p = new MmgPen();
            p.SetCacheOn(false);

            int width = MmgHelper.ScaleValue(345);
            int height = MmgHelper.ScaleValue(300);

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg 9 Slice (2 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            bground = MmgHelper.GetBasicCachedBmp("popup_window_base.png");
            MmgHelper.CenterHorAndVert(bground);
            bground.SetX(bground.GetX() - MmgHelper.ScaleValue(200));
            bground.SetY(bground.GetY() - MmgHelper.ScaleValue(32));
            AddObj(bground);

            bgroundLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            bgroundLabel.SetText("Original MmgBmp");
            bgroundLabel.SetPosition(bground.GetPosition().Clone());
            bgroundLabel.SetY(bgroundLabel.GetY() - bgroundLabel.GetHeight());
            AddObj(bgroundLabel);

            menuBground = new Mmg9Slice(MmgHelper.ScaleValue(8), bground, width, height);
            menuBground.SetPosition(MmgVector2.GetOriginVec());
            menuBground.SetWidth(width);
            menuBground.SetHeight(height);
            MmgHelper.CenterHorAndVert(menuBground);
            menuBground.SetX(menuBground.GetX() + MmgHelper.ScaleValue(200));
            menuBground.SetY(menuBground.GetY() + MmgHelper.ScaleValue(36));
            AddObj(menuBground);

            menuBgroundLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            menuBgroundLabel.SetText("MmgBmp Resized By Mmg9Slice");
            menuBgroundLabel.SetPosition(menuBground.GetPosition().Clone());
            menuBgroundLabel.SetY(menuBgroundLabel.GetY() - menuBgroundLabel.GetHeight());
            AddObj(menuBgroundLabel);

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
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_03);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_01);

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
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessDpadClick: " + dir);
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
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmg9Slice.ProcessKeyClick");
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);
            bground = null;
            bgroundLabel = null;
            title = null;
            menuBground = null;
            menuBgroundLabel = null;
            base.ClearObjs();
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
            MmgHelper.wr("ScreenTestMmg9Slice.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmg9Slice.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}