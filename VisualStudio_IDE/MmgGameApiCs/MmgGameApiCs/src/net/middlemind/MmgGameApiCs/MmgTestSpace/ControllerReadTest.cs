using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// 
    /// </summary>
    public class ControllerReadTest : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public enum ComponentType
        {
            ANALOG_BUTTON,
            DIGITAL_BUTTON,
            ANALOG_STICK,
            DIGITAL_STICK,
            ANALOG_TRIGGER,
            DIGITAL_TRIGGER,
            ANALOG_SHOULDER,
            DIGITAL_SHOULDER
        };

        /// <summary>
        /// 
        /// </summary>
        public ControllerReadTest()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Initialize()
        {
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0d / (double)1);
            base.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            PlayerIndex player = PlayerIndex.One;
            int gamePadIdx = 0;
            int componentIdx = 0;
            string componentStr = "";

            int compLen = 0;
            Dictionary<Buttons, ComponentType> componentsByType = new Dictionary<Buttons, ComponentType>();
            Dictionary<Buttons, int> componentsByBtn = new Dictionary<Buttons, int>();
            Dictionary<int, Buttons> componentsByIdx = new Dictionary<int, Buttons>();
            List<Buttons> components = new List<Buttons>();
            GamePad.InitDatabase();
            GamePadCapabilities gamePadCap = GamePad.GetCapabilities(gamePadIdx);

            if (gamePadCap.IsConnected == false)
            {
                return;
            }

            string ident = gamePadCap.Identifier.ToString();
            string gamePadStr = gamePadCap.DisplayName.ToString();
            bool isConnected = gamePadCap.IsConnected;
            GamePadState gamePadState;

            if (gamePadCap.HasAButton)
            {
                componentsByIdx.Add(compLen, Buttons.A);
                componentsByBtn.Add(Buttons.A, compLen);
                componentsByType.Add(Buttons.A, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.A);
            }

            if(gamePadCap.HasBackButton)
            {
                componentsByIdx.Add(compLen, Buttons.Back);
                componentsByBtn.Add(Buttons.Back, compLen);
                componentsByType.Add(Buttons.Back, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.Back);
            }

            if (gamePadCap.HasBButton)
            {
                componentsByIdx.Add(compLen, Buttons.B);
                componentsByBtn.Add(Buttons.B, compLen);
                componentsByType.Add(Buttons.B, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.B);
            }

            if (gamePadCap.HasBigButton)
            {
                componentsByBtn.Add(Buttons.BigButton, compLen);
                componentsByIdx.Add(compLen, Buttons.BigButton);
                componentsByType.Add(Buttons.BigButton, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.BigButton);
            }

            if (gamePadCap.HasDPadDownButton)
            {
                componentsByBtn.Add(Buttons.DPadDown, compLen);
                componentsByIdx.Add(compLen, Buttons.DPadDown);
                componentsByType.Add(Buttons.DPadDown, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.DPadDown);
            }

            if (gamePadCap.HasDPadLeftButton)
            {
                componentsByBtn.Add(Buttons.DPadLeft, compLen);
                componentsByIdx.Add(compLen, Buttons.DPadLeft);
                componentsByType.Add(Buttons.DPadLeft, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.DPadLeft);
            }

            if (gamePadCap.HasDPadRightButton)
            {
                componentsByBtn.Add(Buttons.DPadRight, compLen);
                componentsByIdx.Add(compLen, Buttons.DPadRight);
                componentsByType.Add(Buttons.DPadRight, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.DPadRight);
            }

            if (gamePadCap.HasDPadUpButton)
            {
                componentsByBtn.Add(Buttons.DPadUp, compLen);
                componentsByIdx.Add(compLen, Buttons.DPadUp);
                componentsByType.Add(Buttons.DPadUp, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.DPadUp);
            }

            if (gamePadCap.HasLeftShoulderButton)
            {
                componentsByBtn.Add(Buttons.LeftShoulder, compLen);
                componentsByIdx.Add(compLen, Buttons.LeftShoulder);
                componentsByType.Add(Buttons.LeftShoulder, ComponentType.ANALOG_SHOULDER);
                compLen++;
                components.Add(Buttons.LeftShoulder);
            }

            if (gamePadCap.HasLeftStickButton)
            {
                componentsByBtn.Add(Buttons.LeftStick, compLen);
                componentsByIdx.Add(compLen, Buttons.LeftStick);
                componentsByType.Add(Buttons.LeftStick, ComponentType.ANALOG_STICK);
                compLen++;
                components.Add(Buttons.LeftStick);
            }

            if (gamePadCap.HasLeftTrigger)
            {
                componentsByBtn.Add(Buttons.LeftTrigger, compLen);
                componentsByIdx.Add(compLen, Buttons.LeftTrigger);
                componentsByType.Add(Buttons.LeftTrigger, ComponentType.ANALOG_TRIGGER);
                compLen++;
                components.Add(Buttons.LeftTrigger);
            }

            if (gamePadCap.HasRightShoulderButton)
            {
                componentsByBtn.Add(Buttons.RightShoulder, compLen);
                componentsByIdx.Add(compLen, Buttons.RightShoulder);
                componentsByType.Add(Buttons.RightShoulder, ComponentType.ANALOG_SHOULDER);
                compLen++;
                components.Add(Buttons.RightShoulder);
            }

            if (gamePadCap.HasRightStickButton)
            {
                componentsByBtn.Add(Buttons.RightStick, compLen);
                componentsByIdx.Add(compLen, Buttons.RightStick);
                componentsByType.Add(Buttons.RightStick, ComponentType.ANALOG_STICK);
                compLen++;
                components.Add(Buttons.RightStick);
            }

            if (gamePadCap.HasRightTrigger)
            {
                componentsByBtn.Add(Buttons.RightTrigger, compLen);
                componentsByIdx.Add(compLen, Buttons.RightTrigger);
                componentsByType.Add(Buttons.RightTrigger, ComponentType.ANALOG_TRIGGER);
                compLen++;
                components.Add(Buttons.RightTrigger);
            }

            if (gamePadCap.HasStartButton)
            {
                componentsByBtn.Add(Buttons.Start, compLen);
                componentsByIdx.Add(compLen, Buttons.Start);
                componentsByType.Add(Buttons.Start, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.Start);
            }

            if (gamePadCap.HasXButton)
            {
                componentsByBtn.Add(Buttons.X, compLen);
                componentsByIdx.Add(compLen, Buttons.X);
                componentsByType.Add(Buttons.X, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.X);
            }

            if (gamePadCap.HasYButton)
            {
                componentsByBtn.Add(Buttons.Y, compLen);
                componentsByIdx.Add(compLen, Buttons.Y);
                componentsByType.Add(Buttons.Y, ComponentType.DIGITAL_BUTTON);
                compLen++;
                components.Add(Buttons.Y);
            }

            gamePadState = GamePad.GetState(player);
            bool isAnalog = false;
            bool isRelative = false;
            string data = "0";
            bool found = true;

            foreach (Buttons b in components)
            {
                componentIdx = componentsByBtn[b];
                componentStr = b.ToString();
                isAnalog = false;

                if (componentsByType[b] == ComponentType.ANALOG_BUTTON || componentsByType[b] == ComponentType.ANALOG_SHOULDER || componentsByType[b] == ComponentType.ANALOG_STICK || componentsByType[b] == ComponentType.ANALOG_TRIGGER)
                {
                    isAnalog = true;
                }

                wr("Component " + componentIdx + ": " + componentStr);
                wr("\t\tIsAnalog: " + isAnalog);
                wr("\t\tIsRelative: " + isRelative);
                wr("\t\tData: " + data);
            }

            wr("");
            wr("");
            wr("[" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "]==============================================================");
            wr("GamePad Index: " + gamePadIdx + " Component Count: " + compLen + " IsConnected: " + isConnected);
            wr("\t\tIdentifier: " + ident);
            foreach (Buttons b in components)
            {
                componentIdx = componentsByBtn[b];
                componentStr = b.ToString();
                isAnalog = false;
                found = false;

                if (componentsByType[b] == ComponentType.ANALOG_BUTTON || componentsByType[b] == ComponentType.ANALOG_SHOULDER || componentsByType[b] == ComponentType.ANALOG_STICK || componentsByType[b] == ComponentType.ANALOG_TRIGGER)
                {
                    isAnalog = true;
                }

                ComponentType ct = componentsByType[b];
                if(ct == ComponentType.DIGITAL_BUTTON || ct == ComponentType.ANALOG_BUTTON)
                {
                    if(gamePadState.IsButtonDown(b))
                    {
                        found = true;
                        data = "1";
                    }
                    else
                    {
                        data = "0";
                    }
                }
                else if(ct == ComponentType.ANALOG_SHOULDER || ct == ComponentType.DIGITAL_SHOULDER)
                {
                    if(gamePadState.IsButtonDown(b))
                    {
                        found = true;
                        data = "1";
                    }
                    else
                    {
                        data = "0";
                    }
                }
                else if(ct == ComponentType.ANALOG_TRIGGER)
                {
                    if(b == Buttons.LeftTrigger)
                    {
                        found = true;
                        data = gamePadState.Triggers.Left + "";
                    }
                    else if(b == Buttons.RightTrigger)
                    {
                        found = true;
                        data = gamePadState.Triggers.Right + "";
                    }
                    else
                    {
                        data = "n/a";
                    }
                }
                else if(ct == ComponentType.ANALOG_STICK)
                {
                    if(b == Buttons.LeftStick)
                    {
                        found = true;
                        data = gamePadState.ThumbSticks.Left.ToString();
                    }
                    else if(b == Buttons.RightStick)
                    {
                        found = true;
                        data = gamePadState.ThumbSticks.Right.ToString();
                    }
                    else
                    {
                        data = "n/a";
                    }
                }

                if (found)
                {
                    wr("Component " + componentIdx + ": " + componentStr);
                    wr("\t\tIsAnalog: " + isAnalog);
                    wr("\t\tIsRelative: " + isRelative);
                    wr("\t\tData: " + data);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }

        /// <summary>
        /// Centralized logging method for standard out logging.
        /// </summary>
        /// <param name="s">The string to be logged.</param>
        public static void wr(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
            Console.WriteLine(s);
        }

        /// <summary>
        /// Static main method.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        [STAThread]
        public static void AltMain(string[] args)
        {
            using (var game = new ControllerReadTest())
            {
                game.Run();
            }
        }
    }
}