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
    public class ScreenTestMmgSpriteMatrix : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        private MmgFont spriteLabel;

        /// <summary>
        /// An MmgSprite class instance used to demonstrate multi-frame image in this test game screen.
        /// </summary>
        private MmgSprite sprite;

        /// <summary>
        /// An MmgFont class instance used as the title for the test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// A bool flag indicating if there is work to do in the next MmgUpdate call.
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// The sprite matrix's source image.
        /// </summary>
        private MmgBmp spriteMatrixSrc;

        /// <summary>
        /// The sprite matrix class instance.
        /// </summary>
        private MmgSpriteMatrix spriteMatrix;

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
        public ScreenTestMmgSpriteMatrix(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgSpriteSheet.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// 
        /// <param name="Handler">A class that , the GenericEventHandler interface.</param>
        /// </summary>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgSpriteSheet.SetGenericEventHandler");
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
        public void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgSpriteSheet.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Sprite Matrix (26 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            //64x64
            spriteMatrixSrc = MmgHelper.GetBasicCachedBmp("enemy_banshee_spritematrix_w_shadow.png");
            spriteMatrixSrc = MmgBmpScaler.ScaleMmgBmp(spriteMatrixSrc, 2.0f, true);

            //MmgHelper.wr("SpriteSheetSrcHeight: " + spriteSheetSrc.GetHeight());
            MmgHelper.CenterHor(spriteMatrixSrc);
            spriteMatrixSrc.SetPosition(new MmgVector2(25, MmgHelper.ScaleValue(160)));
            AddObj(spriteMatrixSrc);

            spriteMatrix = new MmgSpriteMatrix(spriteMatrixSrc.CloneTyped(), 64, 68, 4, 3);
            MmgObj tmpObj = new MmgObj();
            tmpObj.SetHeight(68);
            tmpObj.SetWidth(64);
            MmgHelper.CenterHorAndVert(tmpObj);

            MmgVector2 tmpPos = tmpObj.GetPosition().Clone();
            tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(15));
            tmpPos.SetX(MmgScreenData.GetGameWidth() - 64 - 25);
            sprite = new MmgSprite(spriteMatrix.GetFrames(), tmpPos);
            sprite.SetFrameTime(200L);
            AddObj(sprite);

            spriteLabel = MmgFontData.CreateDefaultBoldMmgFontSm();
            spriteLabel.SetText("MmgSprite Example Loaded from an MmgSpriteMatrix");
            MmgHelper.CenterHorAndVert(spriteLabel);
            spriteLabel.SetY(spriteLabel.GetY() + MmgHelper.ScaleValue(30));
            spriteLabel.SetX(spriteLabel.GetX() + MmgHelper.ScaleValue(65));
            AddObj(spriteLabel);

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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessAClick");
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessDpadPress: " + dir);
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_01);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_25);

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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessDpadClick: " + dir);
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessScreenClick");
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.ProcessKeyClick");
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            spriteLabel = null;
            spriteMatrixSrc = null;
            spriteMatrix = null;
            sprite = null;
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
                sprite.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
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
            MmgHelper.wr("ScreenTestMmgSpriteSheet.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// 
        /// <param name="e">An MmgEvent object instance to process.</param>
        /// </summary>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgSpriteSheet.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}