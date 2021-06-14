using System;
using Microsoft.Xna.Framework;
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
    public class ScreenTestMmgScrollHor : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An MmgScrollHor class instance used in this test game screen.
        /// </summary>
        protected MmgScrollHor scrollHor;

        /// <summary>
        /// An MmgBmp class instance used as the source for an Mmg9Slice resizing.
        /// </summary>
        private MmgBmp bground;

        /// <summary>
        /// An Mmg9Slice class instance used as the background for the MmgScrollHor scroll panel.
        /// </summary>
        private Mmg9Slice menuBground;

        /// <summary>
        /// An MmgFont class instance used as the title for the test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// An MmgFont class instance used to display instructions on this test game screen.
        /// </summary>
        private MmgFont instr;

        /// <summary>
        /// An MmgFont class instance used to display event information from the MmgScrollHor class instance.
        /// </summary>
        private MmgFont wdgEvent;

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
        /// <param name="State"></param>
        /// <param name="Owner"></param>
        public ScreenTestMmgScrollHor(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgScrollHor.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler"></param>
        public void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// Gets the GenericEventHandler this game screen uses to handle GenericEvents.
        /// </summary>
        /// <returns></returns>
        public GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Scroll Hor (14 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            instr = MmgFontData.CreateDefaultBoldMmgFontLg();
            instr.SetText("Press 'A' to navigate left, press 'B' to navigate right.");
            MmgHelper.CenterHorAndTop(instr);
            instr.SetY(instr.GetY() + MmgHelper.ScaleValue(70));
            AddObj(instr);

            MmgPen p;
            p = new MmgPen();
            p.SetCacheOn(false);

            int totalWidth = MmgHelper.ScaleValue(210);
            int totalHeight = MmgHelper.ScaleValue(235);
            bground = MmgHelper.GetBasicCachedBmp("popup_window_base.png");
            menuBground = new Mmg9Slice(16, bground, totalWidth, totalHeight);
            menuBground.SetPosition(MmgVector2.GetOriginVec());
            menuBground.SetWidth(totalWidth);
            menuBground.SetHeight(totalHeight);
            MmgHelper.CenterHorAndVert(menuBground);
            AddObj(menuBground);

            MmgBmp vPort = null;
            MmgBmp sPane = null;
            MmgDrawableBmpSet dBmpSetScrollPane = null;
            MmgDrawableBmpSet dBmpSetViewPort = null;
            MmgColor sBarColor;
            MmgColor sBarSldrColor;
            int sBarWidth = 0;
            int sBarSldrHeight = 0;
            int interval = 0;
            int hund2 = MmgHelper.ScaleValue(200);
            int hund4 = MmgHelper.ScaleValue(400);
            int sWidth = MmgHelper.ScaleValue(200);
            int sHeight = MmgHelper.ScaleValue(200);

            dBmpSetScrollPane = MmgHelper.CreateDrawableBmpSet(hund4, hund2, false, MmgColor.GetBlack());
            MmgHelper.FillRectWithColor(0, 0, hund4 / 4, hund2, Color.Red, dBmpSetScrollPane.buffImg);
            MmgHelper.FillRectWithColor(hund4 / 4, 0, hund4 / 4, hund2, Color.Blue, dBmpSetScrollPane.buffImg);
            MmgHelper.FillRectWithColor(hund4 / 2, 0, hund4 / 4, hund2, Color.Green, dBmpSetScrollPane.buffImg);

            dBmpSetViewPort = MmgHelper.CreateDrawableBmpSet(hund2, hund2, false, MmgColor.GetBlack());
            MmgHelper.FillRectWithColor(0, 0, hund2, hund2, Color.LightGray, dBmpSetViewPort.buffImg);

            vPort = dBmpSetViewPort.img;
            sPane = dBmpSetScrollPane.img;

            sBarColor = MmgColor.GetLightGray();
            sBarSldrColor = MmgColor.GetGray();
            sBarWidth = MmgHelper.ScaleValue(15);
            sBarSldrHeight = MmgHelper.ScaleValue(30);
            interval = 10;

            scrollHor = new MmgScrollHor(vPort, sPane, sBarColor, sBarSldrColor, sBarWidth, sBarSldrHeight, interval);
            scrollHor.SetIsVisible(true);
            scrollHor.SetWidth(sWidth);
            scrollHor.SetHeight(sHeight + scrollHor.GetScrollBarHeight());
            scrollHor.SetEventHandler(this);
            MmgScrollHor.SHOW_CONTROL_BOUNDING_BOX = true;
            MmgHelper.CenterHorAndVert(scrollHor);
            AddObj(scrollHor);

            wdgEvent = MmgFontData.CreateDefaultMmgFontSm();
            wdgEvent.SetText("Event: ");
            MmgHelper.CenterHorAndTop(wdgEvent);
            wdgEvent.SetY(scrollHor.GetY() + scrollHor.GetHeight() + MmgHelper.ScaleValue(30));
            AddObj(wdgEvent);

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
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessScreenRelease");
            if (scrollHor != null)
            {
                scrollHor.ProcessScreenClick(v.GetX(), v.GetY());
                isDirty = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessScreenRelease");
            if (scrollHor != null)
            {
                scrollHor.ProcessScreenClick(x, y);
                isDirty = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessAClick");
            //Go Left
            owner.SwitchGameState(GameStates.GAME_SCREEN_13);
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessBClick");
            //Go Right
            owner.SwitchGameState(GameStates.GAME_SCREEN_15);
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessDpadRelease: " + dir);
            scrollHor.ProcessDpadRelease(dir);
            isDirty = true;
            return true;
        }

        /// <summary>
        /// A method to handle dpad click events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadClick(int dir)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(MmgVector2 v, int btnIndex)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(int x, int y, int btnIndex)
        {
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessScreenClick");
            scrollHor.ProcessScreenClick(x, y);
            isDirty = true;
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
            MmgHelper.wr("ScreenTestMmgScrollHor.ProcessKeyClick");
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            scrollHor = null;
            bground = null;
            menuBground = null;
            title = null;
            instr = null;
            wdgEvent = null;

            ClearObjs();
            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// </summary>
        /// <returns>The game state of this game screen.</returns>
        public GameStates GetGameState()
        {
            return gameState;
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (pause == false && isVisible == true)
            {
                if (isDirty == true)
                {
                    base.GetObjects().SetIsDirty(true);

                    if (base.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true)
                    {
                        lret = true;
                    }
                }
            }

            return lret;
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
            MmgHelper.wr("ScreenTestMmgScrollHor.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            if (e.GetEventId() == MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID || e.GetEventId() == MmgScrollHor.SCROLL_HOR_CLICK_EVENT_ID || e.GetEventId() == MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID)
            {
                MmgVector2 v2 = (MmgVector2)e.GetExtra();
                wdgEvent.SetText("Event: Id: " + e.GetEventId() + " Type: " + e.GetEventType() + " Pos: " + v2.ToString() + " Msg: " + e.GetMessage() + " " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }
            else
            {
                wdgEvent.SetText("Event: Id: " + e.GetEventId() + " Type: " + e.GetEventType() + " Msg: " + e.GetMessage() + " " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            }

            MmgHelper.CenterHor(wdgEvent);
        }
    }
}