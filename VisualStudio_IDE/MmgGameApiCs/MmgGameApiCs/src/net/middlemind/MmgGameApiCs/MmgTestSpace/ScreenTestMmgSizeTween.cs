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
    /// @author Victor G. Brusca
    /// </summary>
    public class ScreenTestMmgSizeTween : MmgGameScreen, GenericEventHandler, MmgEventHandler, MmgScaleHandler {

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
        /// An MmgBmp class instance used to hold a frame in an MmgBmp animation.
        /// </summary>
        private MmgBmp frame1;

        /// <summary>
        /// An MmgBmp class instance used to hold a frame in an MmgBmp animation.
        /// </summary>
        private MmgBmp frame2;

        /// <summary>
        /// An MmgBmp class instance used to hold a frame in an MmgBmp animation.
        /// </summary>
        private MmgBmp frame3;

        /// <summary>
        /// An array of MmgBmp instances that is used to hold references to a series of frames in the animation.
        /// </summary>
        private MmgBmp[] frames;

        /// <summary>
        /// An MmgSprite class instance used to animate an array of MmgBmp frames.
        /// </summary>
        private MmgSprite sprite1;

        /// <summary>
        /// An MmgSprite class instance used to animate an array of MmgBmp frames.
        /// </summary>
        private MmgSprite sprite2;

        /// <summary>
        /// An MmgPositionTween class instance used to move an MmgObj between positions.
        /// </summary>
        private MmgSizeTween sizeTween;

        /// <summary>
        /// An MmgFont class instance that is used to label the MmgPositionTween in this test game screen.
        /// </summary>
        private MmgFont posTweenLabel;

        /// <summary>
        /// An MmgFont class instance that is used to label the event associated with the MmgPositionTween.
        /// </summary>
        private MmgFont eventLabel;

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
        public ScreenTestMmgSizeTween(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgSizeTween.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// 
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        /// </summary>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgSizeTween.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// Gets the GenericEventHandler this game screen uses to handle GenericEvents.
        /// 
        /// <returns>The GenericEventHandler this screen uses to handle GenericEvents.</returns>
        /// </summary>
        public GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public virtual void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgSizeTween.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Size Tween (25 / " + GamePanel.TOTAL_TESTS + ")  >");
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

            frames = new MmgBmp[4];
            frames[0] = frame1;
            frames[1] = frame2;
            frames[2] = frame3;
            frames[3] = frame2;

            MmgVector2 tmpPos = frame1.GetPosition().Clone();
            tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(15));
            sprite1 = new MmgSprite(frames, tmpPos);
            sprite1.SetFrameTime(200L);
            AddObj(sprite1);

            sprite2 = sprite1.CloneTyped();

            posTweenLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            posTweenLabel.SetText("MmgSprite Example with 4 Frames Attached to an MmgSizeTween");
            MmgHelper.CenterHorAndVert(posTweenLabel);
            posTweenLabel.SetY(GetY() + MmgHelper.ScaleValue(70));
            AddObj(posTweenLabel);

            MmgVector2 start = new MmgVector2(MmgHelper.ScaleValue(64), MmgHelper.ScaleValue(64));
            MmgVector2 stop = new MmgVector2(MmgHelper.ScaleValue(128), MmgHelper.ScaleValue(128));

            sizeTween = new MmgSizeTween(sprite1, 5000, start, stop);
            sizeTween.SetOnReachStart(this);
            sizeTween.SetOnReachFinish(this);
            sizeTween.SetMsStartChange(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            sizeTween.SetChanging(true);
            sizeTween.SetOnSubjScale(this);
            sizeTween.SetSubjOrig(sprite2);

            eventLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            eventLabel.SetText("Event:");
            MmgHelper.CenterHor(eventLabel);
            eventLabel.SetY(GetY() + GetHeight() - MmgHelper.ScaleValue(30));
            AddObj(eventLabel);

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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessAClick");
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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDpadPress: " + dir);
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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_26);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_24);

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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgSizeTween.ProcessKeyClick");
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
            frame1 = null;
            frame2 = null;
            frame3 = null;
            frames = null;
            sprite1 = null;
            sizeTween = null;
            posTweenLabel = null;
            eventLabel = null;

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
                sizeTween.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
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
            MmgHelper.wr("ScreenTestMmgSizeTween.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// 
        /// <param name="e">An MmgEvent object instance to process.</param>
        /// </summary>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgSizeTween.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
            eventLabel.SetText("Event: " + e.GetMessage() + " Id: " + e.GetEventId() + " Type: " + e.GetEventType());
            MmgHelper.CenterHor(eventLabel);
            if (e.GetEventId() == MmgPositionTween.MMG_POSITION_TWEEN_REACH_FINISH)
            {
                sizeTween.SetDirStartToFinish(false);
                sizeTween.SetMsStartChange(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
                sizeTween.SetChanging(true);

            }
            else
            {
                sizeTween.SetDirStartToFinish(true);
                sizeTween.SetMsStartChange(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
                sizeTween.SetChanging(true);

            }
        }

        /// <summary>
        /// An event handler used to handle scaling events.
        /// </summary>
        /// <param name="v">The scaling parameters for the X and Y axis.</param>
        /// <param name="orig">An MmgObj object instance that is the original, unscaled object.</param>
        public virtual void MmgHandleScale(MmgVector2 v, MmgObj orig)
        {
            if (orig is MmgBmp)
            {
                sizeTween.SetSubj(MmgBmpScaler.ScaleMmgBmp((MmgBmp)orig, v, true));
            }
            else if (orig is MmgSprite)
            {
                MmgSprite s = ((MmgSprite)orig);
                MmgBmp b = s.GetCurrentFrame().CloneTyped();
                b = MmgBmpScaler.ScaleMmgBmp(b, v, true);
                s = ((MmgSprite)sizeTween.GetSubj());
                s.SetCurrentFrame(b);
            }
            else if (orig is MmgObj)
            {
                orig.SetWidth(v.GetX());
                orig.SetWidth(v.GetY());
            }
            MmgHelper.CenterHor(sizeTween.GetSubj());
        }
    }
}