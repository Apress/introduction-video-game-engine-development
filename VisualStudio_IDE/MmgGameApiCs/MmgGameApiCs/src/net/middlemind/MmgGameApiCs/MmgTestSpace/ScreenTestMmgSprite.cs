using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen class that : the MmgGameScreen base class.
    /// This class is for testing API classes.
    /// Created by Middlemind Games 02/25/2020
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    public class ScreenTestMmgSprite : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An MmgFont class instance used to provide information about the MmgSprite test on this test game screen.
        /// </summary>
        private MmgFont spriteLabel1;

        /// <summary>
        /// An MmgFont class instance used to provide information about the MmgSprite test on this test game screen.
        /// </summary>
        private MmgFont spriteLabel2;

        /// <summary>
        /// An MmgBmp class instance that is the first frame in an animated series of MmgBmp frames.
        /// </summary>
        private MmgBmp frame1;

        /// <summary>
        /// An MmgBmp class instance that is the second frame in an animated series of MmgBmp frames.
        /// </summary>
        private MmgBmp frame2;

        /// <summary>
        /// An MmgBmp class instance that is the third frame in an animated series of MmgBmp frames.
        /// </summary>
        private MmgBmp frame3;

        /// <summary>
        /// An array used to store the MmgBmp frames used in the animation.
        /// </summary>
        private MmgBmp[] frames1;

        /// <summary>
        /// An array used to store the MmgBmp frames used in the animation.
        /// </summary>
        private MmgBmp[] frames2;

        /// <summary>
        /// An MmgSprite class instance used to demonstrate multi-frame image in this test game screen.
        /// </summary>
        private MmgSprite sprite1;

        /// <summary>
        /// An MmgSprite class instance used to demonstrate multi-frame image in this test game screen.
        /// </summary>
        private MmgSprite sprite2;

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
        /// 
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        /// </summary>
        public ScreenTestMmgSprite(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgSprite.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// 
        /// <param name="Handler">A class that , the GenericEventHandler interface.</param>
        /// </summary>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgSprite.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// Gets the GenericEventHandler this game screen uses to handle GenericEvents.
        /// 
        /// <returns>The GenericEventHandler this screen uses to handle GenericEvents.</returns>
        /// </summary>
        public virtual GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        //     @SuppressWarnings("UnusedAssignment")
        public virtual void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgSprite.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Sprite (8 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            frame1 = MmgHelper.GetBasicCachedBmp("soldier_frame_1.png");
            frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame1);

            frame2 = MmgHelper.GetBasicCachedBmp("soldier_frame_2.png");
            frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame2);

            frame3 = MmgHelper.GetBasicCachedBmp("soldier_frame_3.png");
            frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
            MmgHelper.CenterHorAndVert(frame3);

            frames1 = new MmgBmp[4];
            frames1[0] = frame1;
            frames1[1] = frame2;
            frames1[2] = frame3;
            frames1[3] = frame2;

            frames2 = new MmgBmp[4];
            frames2[0] = frame1.CloneTyped();
            frames2[1] = frame2.CloneTyped();
            frames2[2] = frame3.CloneTyped();
            frames2[3] = frame2.CloneTyped();

            MmgVector2 tmpPos = frame1.GetPosition().Clone();
            tmpPos.SetY(tmpPos.GetY() - MmgHelper.ScaleValue(30));
            sprite1 = new MmgSprite(frames1, tmpPos);
            sprite1.SetMsPerFrame(200L);
            AddObj(sprite1);

            spriteLabel1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            spriteLabel1.SetText("MmgSprite Example with 4 Frames");
            MmgHelper.CenterHorAndVert(spriteLabel1);
            spriteLabel1.SetY(sprite1.GetY() - MmgHelper.ScaleValue(20));
            AddObj(spriteLabel1);

            tmpPos = frame1.GetPosition().Clone();
            tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(90));
            sprite2 = new MmgSprite(frames2, new MmgRect(0, 0, frame1.GetHeight() / 2, frame1.GetWidth() / 2), new MmgRect(tmpPos.GetX(), tmpPos.GetY(), tmpPos.GetY() + frame1.GetHeight() / 2, tmpPos.GetX() + frame1.GetWidth() / 2), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
            sprite2.SetFrameTime(200L);
            sprite2.SetPosition(tmpPos);
            sprite2.SetSimpleRendering(false);
            AddObj(sprite2);

            spriteLabel2 = MmgFontData.CreateDefaultBoldMmgFontLg();
            spriteLabel2.SetText("MmgSprite Example with 4 Frames and Source/Destination Rectangles");
            MmgHelper.CenterHorAndVert(spriteLabel2);
            spriteLabel2.SetY(sprite2.GetY() - MmgHelper.ScaleValue(20));
            AddObj(spriteLabel2);

            ready = true;
            pause = false;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMousePress(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenPress");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMousePress(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenRelease");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// 
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMouseRelease(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// 
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// 
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_09);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_07);

            }
            return true;
        }

        /// <summary>
        /// A method to handle dpad click events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadClick(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenClick");
            return true;
        }

        /// <summary>
        /// A method to handle keyboard click events.
        /// 
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessKeyClick(char c, int code)
        {
            MmgHelper.wr("ScreenTestMmgSprite.ProcessKeyClick");
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            spriteLabel1 = null;
            spriteLabel2 = null;
            frame1 = null;
            frame2 = null;
            frame3 = null;
            frames1 = null;
            sprite1 = null;
            frames2 = null;
            sprite2 = null;
            title = null;

            ClearObjs();
            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// 
        /// <returns>The game state of this game screen.</returns>
        /// </summary>
        public virtual GameStates GetGameState()
        {
            return gameState;
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// 
        /// <param name="updateTicks">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        /// </summary>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (pause == false && isVisible == true)
            {
                //always run this update
                sprite1.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                sprite2.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
            }

            return lret;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// 
        /// <param name="p">The MmgPen used to draw this object.</param>
        /// </summary>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// The callback method to handle GenericEventMessage objects.
        /// 
        /// <param name="obj">A GenericEventMessage object instance to process.</param>
        /// </summary>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("ScreenTestMmgSprite.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// 
        /// <param name="e">An MmgEvent object instance to process.</param>
        /// </summary>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgSprite.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}