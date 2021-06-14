using System;
using Microsoft.Xna.Framework;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen object, ScreenTest, that extends the MmgGameScreen base class.
    /// This class is for testing new UI widgets, etc.
    /// Created by Middlemind Games 02/25/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class ScreenTest : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An instance of the MmgScrollVert class for functionality testing.
        /// </summary>
        protected MmgScrollVert scrollVert;

        /// <summary>
        /// An instance of the MmgScrollHor class for functionality testing.
        /// </summary>
        protected MmgScrollHor scrollHor;

        /// <summary>
        /// An instance of the MmgScrollHorVert class for functionality testing.
        /// </summary>
        protected MmgScrollHorVert scrollBoth;

        /// <summary>
        /// An instance of the MmgBmp class to use as the scaled background source for an Mmg9Slice instance.
        /// </summary>
        private MmgBmp bground;

        /// <summary>
        /// An instance of the Mmg9Slice class used as the background image for the scroll panels.
        /// </summary>
        private Mmg9Slice menuBground;

        /// <summary>
        /// An instance of the MmgTextField class for functionality testing.
        /// </summary>
        private MmgTextField txtField;

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
        public ScreenTest(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            //SetMmgUpdateHandler(this);
            MmgHelper.wr("ScreenTest: Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTest.SetGenericEventHandler");
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
            MmgHelper.wr("ScreenTest.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            //MmgBmp tB = null;
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
            //AddObj(menuBground);

            int sWidth = 0;
            int sHeight = 0;
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

            sWidth = MmgHelper.ScaleValue(200);
            sHeight = MmgHelper.ScaleValue(200);

            dBmpSetScrollPane = MmgHelper.CreateDrawableBmpSet(hund2, hund4, false, MmgColor.GetBlack());
            //dBmpSetScrollPane.graphics.setColor(Color.Red);
            //dBmpSetScrollPane.graphics.fillRect(0, 0, hund2, hund4 / 4);
            MmgHelper.FillRectWithColor(0, 0, hund2, hund4 / 4, Color.Red, dBmpSetScrollPane.buffImg);

            //dBmpSetScrollPane.graphics.setColor(Color.Blue);
            //dBmpSetScrollPane.graphics.fillRect(0, hund4 / 4, hund2, hund4 / 4);
            MmgHelper.FillRectWithColor(0, hund4 / 4, hund2, hund4 / 4, Color.Blue, dBmpSetScrollPane.buffImg);

            //dBmpSetScrollPane.graphics.setColor(Color.Green);
            //dBmpSetScrollPane.graphics.fillRect(0, hund4 / 2, hund2, hund4 / 4);
            MmgHelper.FillRectWithColor(0, hund4 / 2, hund2, hund4 / 4, Color.Green, dBmpSetScrollPane.buffImg);

            dBmpSetViewPort = MmgHelper.CreateDrawableBmpSet(hund2, hund2, false, MmgColor.GetBlack());
            //dBmpSetViewPort.graphics.setColor(Color.LightGray);
            //dBmpSetViewPort.graphics.fillRect(0, 0, hund2, hund2);
            MmgHelper.FillRectWithColor(0, 0, hund2, hund2, Color.LightGray, dBmpSetScrollPane.buffImg);

            //vPort = new MmgBmp(new MmgObj(0, 0, hund2, hund2, true, MmgColor.GetRed()));        
            //sPane = new MmgBmp(new MmgObj(0, 0, hund2, hund4, true, MmgColor.GetBlue()));        
            vPort = dBmpSetViewPort.img;
            sPane = dBmpSetScrollPane.img;

            sBarColor = MmgColor.GetLightGray();
            sBarSldrColor = MmgColor.GetGray();
            sBarWidth = MmgHelper.ScaleValue(15);
            sBarSldrHeight = MmgHelper.ScaleValue(30);
            interval = 10;

            scrollVert = new MmgScrollVert(vPort, sPane, sBarColor, sBarSldrColor, sBarWidth, sBarSldrHeight, interval);
            //scrollVert = new MmgScrollVert(vPort, sPane, sBarColor, sBarSldrColor, interval, state);        
            scrollVert.SetIsVisible(true);
            scrollVert.SetWidth(sWidth + scrollVert.GetScrollBarWidth());
            scrollVert.SetHeight(sHeight);
            //scrollVert.SetHandler(this);    
            MmgScrollVert.SHOW_CONTROL_BOUNDING_BOX = true;
            MmgHelper.CenterHorAndVert(scrollVert);
            //AddObj(scrollVert);

            dBmpSetScrollPane = MmgHelper.CreateDrawableBmpSet(hund4, hund2, false, MmgColor.GetBlack());
            //dBmpSetScrollPane.graphics.setColor(Color.Red);
            //dBmpSetScrollPane.graphics.fillRect(0, 0, hund4 / 4, hund2);
            MmgHelper.FillRectWithColor(0, 0, hund4 / 4, hund2, Color.Red, dBmpSetScrollPane.buffImg);

            //dBmpSetScrollPane.graphics.setColor(Color.Blue);
            //dBmpSetScrollPane.graphics.fillRect(hund4 / 4, 0, hund4 / 4, hund2);
            MmgHelper.FillRectWithColor(hund4 / 4, 0, hund4 / 4, hund2, Color.Blue, dBmpSetScrollPane.buffImg);

            //dBmpSetScrollPane.graphics.setColor(Color.Green);
            //dBmpSetScrollPane.graphics.fillRect(hund4 / 2, 0, hund4 / 4, hund2);
            MmgHelper.FillRectWithColor(hund4 / 2, 0, hund4 / 4, hund2, Color.Green, dBmpSetScrollPane.buffImg);

            dBmpSetViewPort = MmgHelper.CreateDrawableBmpSet(hund2, hund2, false, MmgColor.GetBlack());
            //dBmpSetViewPort.graphics.setColor(Color.LightGray);
            //dBmpSetViewPort.graphics.fillRect(0, 0, hund2, hund2);
            MmgHelper.FillRectWithColor(0, 0, hund2, hund2, Color.LightGray, dBmpSetScrollPane.buffImg);

            //vPort = new MmgBmp(new MmgObj(0, 0, hund2, hund2, true, MmgColor.GetRed()));
            //sPane = new MmgBmp(new MmgObj(0, 0, hund4, hund2, true, MmgColor.GetBlue()));        
            vPort = dBmpSetViewPort.img;
            sPane = dBmpSetScrollPane.img;

            sBarColor = MmgColor.GetLightGray();
            sBarSldrColor = MmgColor.GetGray();
            sBarWidth = MmgHelper.ScaleValue(15);
            sBarSldrHeight = MmgHelper.ScaleValue(30);
            interval = 10;

            scrollHor = new MmgScrollHor(vPort, sPane, sBarColor, sBarSldrColor, sBarWidth, sBarSldrHeight, interval);
            //scrollHor = new MmgScrollHor(vPort, sPane, sBarColor, sBarSldrColor, interval, state);        
            scrollHor.SetIsVisible(true);
            scrollHor.SetWidth(sWidth);
            scrollHor.SetHeight(sHeight + scrollHor.GetScrollBarHeight());
            //scrollHor.SetHandler(this);
            MmgScrollHor.SHOW_CONTROL_BOUNDING_BOX = true;
            MmgHelper.CenterHorAndVert(scrollHor);
            //AddObj(scrollHor);

            dBmpSetScrollPane = MmgHelper.CreateDrawableBmpSet(hund4, hund4, false, MmgColor.GetBlack());
            //dBmpSetScrollPane.graphics.setColor(Color.Red);
            //dBmpSetScrollPane.graphics.fillRect(0, 0, hund4 / 4, hund4 / 4);
            MmgHelper.FillRectWithColor(0, 0, hund4 / 4, hund4 / 4, Color.Red, dBmpSetScrollPane.buffImg);

            //dBmpSetScrollPane.graphics.setColor(Color.Blue);
            //dBmpSetScrollPane.graphics.fillRect(hund4 / 4, hund4 / 4, hund4 / 4, hund4 / 4);
            MmgHelper.FillRectWithColor(hund4 / 4, hund4 / 4, hund4 / 4, hund4 / 4, Color.Blue, dBmpSetScrollPane.buffImg);

            //dBmpSetScrollPane.graphics.setColor(Color.Green);
            //dBmpSetScrollPane.graphics.fillRect(hund4 / 2, hund4 / 2, hund4 / 4, hund4 / 4);
            MmgHelper.FillRectWithColor(hund4 / 2, hund4 / 2, hund4 / 4, hund4 / 4, Color.Green, dBmpSetScrollPane.buffImg);

            dBmpSetViewPort = MmgHelper.CreateDrawableBmpSet(hund2, hund2, false, MmgColor.GetBlack());
            //dBmpSetViewPort.graphics.setColor(Color.LightGray);
            //dBmpSetViewPort.graphics.fillRect(0, 0, hund2, hund2);
            MmgHelper.FillRectWithColor(0, 0, hund2, hund2, Color.LightGray, dBmpSetScrollPane.buffImg);

            vPort = new MmgBmp(new MmgObj(0, 0, hund2, hund2, true, MmgColor.GetRed()));
            sPane = new MmgBmp(new MmgObj(0, 0, hund4, hund4, true, MmgColor.GetBlue()));
            vPort = dBmpSetViewPort.img;
            sPane = dBmpSetScrollPane.img;

            sBarColor = MmgColor.GetLightGray();
            sBarSldrColor = MmgColor.GetGray();
            sBarWidth = MmgHelper.ScaleValue(15);
            sBarSldrHeight = MmgHelper.ScaleValue(30);
            interval = 10;

            scrollBoth = new MmgScrollHorVert(vPort, sPane, sBarColor, sBarSldrColor, sBarWidth, sBarWidth, sBarSldrHeight, sBarSldrHeight, interval, interval);
            //scrollBoth = new MmgScrollHor(vPort, sPane, sBarColor, sBarSldrColor, interval, state);        
            scrollBoth.SetIsVisible(true);
            scrollBoth.SetWidth(sWidth + scrollBoth.GetScrollBarVertWidth());
            scrollBoth.SetHeight(sHeight + scrollBoth.GetScrollBarHorHeight());
            //scrollBoth.SetHandler(this);
            scrollBoth.SetEventHandler(this);
            MmgScrollHorVert.SHOW_CONTROL_BOUNDING_BOX = true;
            MmgHelper.CenterHorAndVert(scrollBoth);
            AddObj(scrollBoth);

            txtField = new MmgTextField(bground, MmgFontData.CreateDefaultMmgFontLg(), 200, 50, 12, 15);
            txtField.SetPosition(50, 100);
            AddObj(txtField);

            ready = true;
            pause = false;
            MmgHelper.wr("ScreenTest: LoadResources");
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMousePress(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTest.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTest.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTest.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTest.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTest.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTest.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTest.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTest.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTest.ProcessDpadRelease: " + dir);
            scrollVert.ProcessDpadRelease(dir);
            scrollHor.ProcessDpadRelease(dir);
            scrollBoth.ProcessDpadRelease(dir);
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
            MmgHelper.wr("ScreenTest.ProcessDpadClick: " + dir);
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
            MmgHelper.wr("ScreenTest.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTest.ProcessScreenClick");
            scrollVert.ProcessScreenClick(x, y);
            scrollHor.ProcessScreenClick(x, y);
            scrollBoth.ProcessScreenClick(x, y);
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
            if (Char.IsDigit(c) || Char.IsLetter(c))
            {
                txtField.ProcessKeyClick(c, code);
            }
            else if (code == 8)
            {
                txtField.DeleteChar();
            }
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);
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
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number. </param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (pause == false && isVisible == true)
            {
                //always run this update
                txtField.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);

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
        /// The callback method to handle GenericEventMessage objects.
        /// </summary>
        /// <param name="obj">A GenericEventMessage object instance to process.</param>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("ScreenTest.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
            if (obj.id == MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID || obj.id == MmgScrollHor.SCROLL_HOR_CLICK_EVENT_ID || obj.id == MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID)
            {
                MmgVector2 v2 = (MmgVector2)obj.payload;
                MmgHelper.wr("ScreenTest.HandleGenericEvent: " + v2.ToString());
            }
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr(e.ToString());
        }
    }
}