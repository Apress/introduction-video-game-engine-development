using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A game screen object, ScreenSplash, that extends the MmgGameScreen base class. 
    /// This game screen is for displaying a splash screen before the game loading screen.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class ScreenSplash : MmgSplashScreen, MmgUpdateHandler
    {
        /// <summary>
        /// Event display time complete id.
        /// </summary>
        public static int EVENT_DISPLAY_COMPLETE = 0;

        /// <summary>
        /// The game state this screen has.
        /// </summary>
        public GameStates state;

        /// <summary>
        /// Event handler for firing generic events. 
        /// Events would fire when the screen has non UI actions to broadcast.
        /// </summary>
        public GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen. 
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        public GamePanel owner;

        /// <summary>
        /// A data structure that stores all the class configuration file entries from the target file.
        /// </summary>
        public Dictionary<string, MmgCfgFileEntry> classConfig;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenSplash(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            state = State;
            owner = Owner;
            SetUpdateHandler(this);
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            handler = Handler;
        }

        /// <summary>
        /// Gets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <returns>A class that implements the GenericEventHandler interface.</returns>
        public virtual GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Public method that fires the local generic event, the listener will receive a display complete event.
        /// </summary>
        /// <param name="obj">The information payload to send along with this message.</param>
        public override void MmgHandleUpdate(Object obj)
        {
            if (handler != null)
            {
                handler.HandleGenericEvent(new GenericEventMessage(ScreenSplash.EVENT_DISPLAY_COMPLETE, null, GetGameState()));
            }
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public virtual void LoadResources()
        {
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            MmgHelper.wr("ScreenSplash: LoadResources: " + GameSettings.CLASS_CONFIG_DIR + "screen_splash.txt");
            classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + "screen_splash.txt");

            MmgBmp tB = null;
            string key = "";
            double scale = 1.0;
            int tmp = 0;
            string file = "";

            key = "splashScreenDisplayTimeMs";
            if (classConfig.ContainsKey(key))
            {
                base.SetDisplayTime((int)classConfig[key].number);
            }

            key = "bmpLogo";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "logo_large.jpg";
            }

            tB = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);

            if(tB != null)
            {
                MmgHelper.wr("ScreenSplash: LoadResources: ScreenSplash Logo is NOT null.");
                MmgHelper.wr("ScreenSplash: LoadResources: " + GameSettings.IMAGE_LOAD_DIR + file);
            }

            if (tB != null)
            {
                key = "splashLogoScale";
                if (classConfig.ContainsKey(key))
                {
                    scale = (double)classConfig[key].number;
                    if (scale != 1.0)
                    {
                        tB = MmgBmpScaler.ScaleMmgBmp(tB, scale, false);
                    }
                }

                SetCenteredBackground(tB);

                key = "splashLogoPosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "splashLogoPosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "splashLogoOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "splashLogoOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));
                }
            }

            MmgHelper.wr("ScreenSplash: Loadresources: " + this.GetObjects().GetCount());
            ready = true;
            pause = false;
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
            return state;
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
    }
}