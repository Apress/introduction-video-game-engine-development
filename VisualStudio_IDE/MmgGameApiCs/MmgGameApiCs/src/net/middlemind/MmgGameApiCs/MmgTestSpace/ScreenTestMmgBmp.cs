using System;
using Microsoft.Xna.Framework.Graphics;
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
    public class ScreenTestMmgBmp : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An MmgBmp class instance that is loaded from the MmgBmp cache.
        /// </summary>
        private MmgBmp bmpCache;

        /// <summary>
        /// An MmgFont class instance used as a label for the MmgBmp loaded from the cache.
        /// </summary>
        private MmgFont bmpCacheLabel;

        /// <summary>
        /// An MmgBmp class instance that is loaded from a file path.
        /// </summary>
        private MmgBmp bmpFile;

        /// <summary>
        /// An MmgFont class instance used as a label for the MmgBmp loaded from a file.
        /// </summary>
        private MmgFont bmpFileLabel;

        /// <summary>
        /// An MmgBmp class instance that is an example of a custom color fill.
        /// </summary>
        private MmgBmp bmpCustomFill;

        /// <summary>
        /// An MmgFont class instance used as a label for the MmgBmp that is an example of a custom color fill.
        /// </summary>
        private MmgFont bmpCustomFillLabel;

        /// <summary>
        /// An MmgBmp class instance that is an example of a partial copy of another MmgBmp.
        /// </summary>
        private MmgBmp bmpPartialCopy;

        /// <summary>
        /// An MmgFont class instance used as a label for the MmgBmp that is an example of a partial copy of another MmgBmp.
        /// </summary>
        private MmgFont bmpPartialCopyLabel;

        /// <summary>
        /// An MmgDrawableBmpSet class instance that is an example of creating a custom bitmap crawing set.
        /// </summary>
        private MmgDrawableBmpSet bmpSet;

        /// <summary>
        /// An MmgRect class instance used as the source rectangle for a custom bitmap copy.
        /// </summary>
        private MmgRect srcRect;

        /// <summary>
        /// An MmgRect class instance used as the destination rectangle for a custom bitmap copy.
        /// </summary>
        private MmgRect dstRect;

        /// <summary>
        /// An MmgFont class instance used as the title of the test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// An MmgBmp class instance used as an example of the MmgBmp scaling process.
        /// </summary>
        private MmgBmp bmpScaled;

        /// <summary>
        /// An MmgFont class instance used as a label for the MmgBmp that is an example of bitmap scaling.
        /// </summary>
        private MmgFont bmpScaledLabel;

        /// <summary>
        /// An MmgFont class instance used as an example of the MmgBmp rotation process.
        /// </summary>
        private MmgBmp bmpRotate;

        /// <summary>
        /// An MmgFont class instance used as a label for the MmgBmp that is an example of the MmgBmp rotation process.
        /// </summary>
        private MmgFont bmpRotateLabel;

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
        public ScreenTestMmgBmp(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgBmp.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgBmp.SetGenericEventHandler");
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
            MmgHelper.wr("ScreenTestMmgBmp.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Bmp (5 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            MmgHelper.ListCacheEntries();

            bmpCache = MmgHelper.GetBasicCachedBmp("soldier_frame_1.png");
            bmpCache.SetY(GetY() + MmgHelper.ScaleValue(90));
            bmpCache.SetX(MmgHelper.ScaleValue(220));
            AddObj(bmpCache);

            bmpCacheLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            bmpCacheLabel.SetText("MmgBmp From Auto Load Cache");
            bmpCacheLabel.SetPosition(MmgHelper.ScaleValue(50), GetY() + MmgHelper.ScaleValue(70));
            AddObj(bmpCacheLabel);

            bmpFile = MmgHelper.GetBasicCachedBmp("../cfg/drawable/loading_bar.png", "loading_bar.png");
            bmpFile.SetY(GetY() + MmgHelper.ScaleValue(90));
            bmpFile.SetX(MmgHelper.ScaleValue(560));
            AddObj(bmpFile);

            bmpFileLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            bmpFileLabel.SetText("MmgBmp From Path");
            bmpFileLabel.SetPosition(MmgHelper.ScaleValue(545), GetY() + MmgHelper.ScaleValue(70));
            AddObj(bmpFileLabel);

            bmpCustomFill = MmgHelper.CreateFilledBmp(MmgHelper.ScaleValue(50), MmgHelper.ScaleValue(50), MmgColor.GetCalmBlue());
            bmpCustomFill.SetY(GetY() + MmgHelper.ScaleValue(210));
            bmpCustomFill.SetX(MmgHelper.ScaleValue(205));
            AddObj(bmpCustomFill);

            bmpCustomFillLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            bmpCustomFillLabel.SetText("MmgBmp Created Custom with Fill");
            bmpCustomFillLabel.SetPosition(MmgHelper.ScaleValue(45), GetY() + MmgHelper.ScaleValue(190));
            AddObj(bmpCustomFillLabel);

            bmpSet = MmgHelper.CreateDrawableBmpSet(bmpCache.GetWidth() / 2, bmpCache.GetHeight() / 2, true);
            srcRect = new MmgRect(0, 0, bmpCache.GetHeight() / 2, bmpCache.GetWidth() / 2);
            dstRect = new MmgRect(0, 0, bmpCache.GetHeight() / 2, bmpCache.GetWidth() / 2);
            bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(bmpSet.buffImg);
            bmpSet.p.GetGraphics().Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            bmpSet.p.DrawBmp(bmpCache, srcRect, dstRect);
            bmpSet.p.GetGraphics().End();
            bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(null);

            bmpSet.img.SetY(GetY() + MmgHelper.ScaleValue(210));
            bmpSet.img.SetX(MmgHelper.ScaleValue(650));
            AddObj(bmpSet.img);

            bmpPartialCopyLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            bmpPartialCopyLabel.SetText("MmgBmp Custom with Copy");
            bmpPartialCopyLabel.SetPosition(MmgHelper.ScaleValue(505), GetY() + MmgHelper.ScaleValue(190));
            AddObj(bmpPartialCopyLabel);

            bmpScaled = MmgBmpScaler.ScaleMmgBmp(bmpCache, 1.50, true);
            bmpScaled.SetPosition(MmgHelper.ScaleValue(213), GetY() + MmgHelper.ScaleValue(330));
            AddObj(bmpScaled);

            bmpScaledLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            bmpScaledLabel.SetText("MmgBmp Custom Scaled");
            bmpScaledLabel.SetPosition(MmgHelper.ScaleValue(90), GetY() + MmgHelper.ScaleValue(310));
            AddObj(bmpScaledLabel);

            bmpRotate = MmgBmpScaler.RotateMmgBmp(bmpCache, 90, true);
            bmpRotate.SetPosition(MmgHelper.ScaleValue(645), GetY() + MmgHelper.ScaleValue(330));
            AddObj(bmpRotate);

            bmpRotateLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            bmpRotateLabel.SetText("MmgBmp Custom Rotated");
            bmpRotateLabel.SetPosition(MmgHelper.ScaleValue(515), GetY() + MmgHelper.ScaleValue(310));
            AddObj(bmpRotateLabel);

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
            MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgBmp.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgBmp.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgBmp.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgBmp.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgBmp.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_06);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_04);

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
            MmgHelper.wr("ScreenTestMmgBmp.ProcessDpadClick: " + dir);
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
            MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgBmp.ProcessKeyClick");
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            bmpCache = null;
            bmpCacheLabel = null;
            bmpCustomFill = null;
            bmpCustomFillLabel = null;
            bmpFile = null;
            bmpFileLabel = null;
            bmpPartialCopy = null;
            bmpPartialCopyLabel = null;
            bmpRotate = null;
            bmpRotateLabel = null;
            bmpScaled = null;
            bmpScaledLabel = null;
            bmpSet = null;

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
            MmgHelper.wr("ScreenTestMmgBmp.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
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