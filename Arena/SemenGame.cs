using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Evolution
{ 
    public class Player
    {
        public static int StepSize = 10;
        public static int RotationAngle = 30;
        public static float Scale = 0.5F;
        public static int InitialLife = 100;
        public static int InitialDirection = 270;
        public static int FoodLifeBonus = 50;
        public int Life { get; set; }
        public float WallDistance { get; set; }
        public float FoodDistance { get; set; }
        public Vector2 Position;
        public Texture2D Texture;
        public int Direction;
        public float A, B, C;
        public Player(Texture2D texture)
        {
            this.Texture = texture;
            this.Life = InitialLife;
            this.Position = new Vector2(SemenGame.ScreenWidth / 2, SemenGame.ScreenHeight / 2);
            this.Direction = InitialDirection;
        }
        public void MoveForward()
        {
            Life--;
            if (!(WallDistance >= StepSize)) return;
            float radians = (float) ((Direction == 180) ? Math.PI : MathHelper.ToRadians(Direction));
            Position.X += StepSize*(float) Math.Cos(radians);
            Position.Y += StepSize*(float) Math.Sin(radians);
        }
        public void MoveRight()
        {
            Life--;
            Direction += RotationAngle;
            Direction %= 360;
        }
        public void MoveLeft()
        {
            Life--;
            Direction += (360- RotationAngle);
            Direction %= 360;
        }
        public void RefreshFormula()
        {
            if (Direction % 180 == 90)
            {
                A = 1;
                B = 0;
                C = -Position.X;
            }
            else if (Direction == 180)
            {
                A = 0;
                B = 1;
                C = -Position.Y;
            }
            else
            {
                A = -(float)Math.Tan(MathHelper.ToRadians(Direction));
                B = 1;
                C = -A * Position.X - Position.Y;
            }
        }
        public void AddLife(int size = 0)
        {
            if (size == 0)
                this.Life += FoodLifeBonus;
            else
                this.Life += size;
        }
        private int HeadPosition()
        {
            return Convert.ToInt32(Texture.Height * Scale / 2 + 1);
        }
    }

    public class SemenGame : Microsoft.Xna.Framework.Game, IDisposable
    {
        #region Members
        public static int ScreenWidth = 700;
        public static int ScreenHeight = 700;
        public static float Fps = 300;
        public Environment Environment;
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GraphicsDevice device;
        private Texture2D backgroundTexture, playerTexture, wallTexture, foodTexture;
        private Random rnd = new Random();
        private KeyboardState oldKeyboardState;
        private SpriteFont font;
        private int keyboardCounter, turnsCounter, lifetime;
        private Creature mainCreature;
        private Player mainPlayer;
        private int generation, offspring;
        private Manager manager;
        private GameParameters newGameParameters;
        private readonly object newParametersLock = new object();
        #endregion

        public SemenGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.manager = new Manager();
        }

        #region Overrides
        protected override void Initialize()
        {
            base.Initialize();
            newGameParameters = new GameParameters { HasChanged = false};
            oldKeyboardState = Keyboard.GetState();
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / Fps);
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Boooom";
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("background");
            playerTexture = Content.Load<Texture2D>("player");
            wallTexture = Content.Load<Texture2D>("wall");
            foodTexture = Content.Load<Texture2D>("food");
            font = Content.Load<SpriteFont>("font");
            SetUpEnvironment();
            RefreshGame();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            lock (newParametersLock)
            {
                if (newGameParameters.HasChanged)
                    ApplyGameParameters();
                NewGameParameters.HasChanged = false;
            }
            while (NewGameParameters.Pause)
                continue;
            base.Update(gameTime);
            UpdateMainPlayer();
            if (IsKeyPressed(Keys.Space))
                Environment.ShuffleFood();
            if (oldKeyboardState.Equals(Keyboard.GetState()))
            {
                keyboardCounter++;
            }
            else
            {
                oldKeyboardState = Keyboard.GetState();
                keyboardCounter = 0;
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawScenery();
            DrawPlayers();
            DrawOverlay();
            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion

        #region SingleGame

        private void SetUpPlayer()
        {
            mainPlayer = new Player(playerTexture);
        }

        private void SetUpEnvironment()
        {
            Environment = new Environment();
            //environment.AddWall(new Line(new Vector2(100, 50), new Vector2(200, 600)));
        }

        private void UpdateMainPlayer()
        {
            //if (IsKeyPressed(Keys.Right)) mainPlayer.MoveRight();
            //else if (IsKeyPressed(Keys.Left)) mainPlayer.MoveLeft();
            //if (IsKeyPressed(Keys.Up)) mainPlayer.MoveForward();
            if (IsItTime())
            {
                mainCreature.Turn(mainPlayer);
                lifetime++;
            }
            mainPlayer.RefreshFormula();
            Environment.UpdateLocation(mainPlayer);
            mainPlayer.WallDistance = Environment.WallDistance(mainPlayer);
            mainPlayer.FoodDistance = Environment.FoodDistanceFront(mainPlayer);
            if (mainPlayer.Life <= 0) this.NewRound();
        }

        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, ScreenWidth, ScreenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            Environment.DrawWalls(spriteBatch, wallTexture);
            Environment.DrawFood(spriteBatch, foodTexture);
        }

        private void DrawPlayers()
        {
            spriteBatch.Draw(mainPlayer.Texture,
                        mainPlayer.Position,
                        null,
                        Color.White,
                        MathHelper.ToRadians(mainPlayer.Direction),
                        new Vector2(mainPlayer.Texture.Width, mainPlayer.Texture.Height / 2),
                        Player.Scale,
                        SpriteEffects.None,
                        0);
        }

        private void DrawOverlay()
        {
            spriteBatch.DrawString(font,"Wall Distance: " + FormatDistance(mainPlayer.WallDistance), new Vector2(10, 10), Color.BlueViolet);
            spriteBatch.DrawString(font,"Food Distance: " + FormatDistance(mainPlayer.FoodDistance), new Vector2(10, 30), Color.BlueViolet);
            spriteBatch.DrawString(font, "Life: " + Convert.ToString(mainPlayer.Life), new Vector2(10, 50), Color.BlueViolet);
            spriteBatch.DrawString(font, "Generation No: " + Convert.ToString(generation + 1), new Vector2(10, ScreenHeight - 60), Color.Firebrick);
            spriteBatch.DrawString(font, "Offspring No: " + Convert.ToString(offspring + 1), new Vector2(10, ScreenHeight - 40), Color.Firebrick);
        }

        #endregion

        #region Managment
        private void NewRound()
        {
            manager.NextCreature(GetGrade());
            RefreshGame();
        }
        private void RefreshGame()
        {
            mainCreature = manager.CurrentCreature;
            generation = manager.CurrentGeneration;
            offspring = manager.CurrentCreatureNumber;
            keyboardCounter = 0;
            turnsCounter = 0;
            lifetime = 0;
            SetUpPlayer();
        }
        private int GetGrade()
        {
            return (int)(lifetime + (ScreenCross - Environment.FoodDistance(mainPlayer)));
        }
        #endregion

        private bool IsItTime()
        {
            if (turnsCounter >= 0)
            {
                turnsCounter = 0;
                return true;
            }
            turnsCounter++;
            return false;
        }
        private bool IsKeyPressed(Keys key)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            if (oldKeyboardState.IsKeyDown(key))
            {
                if (currentKeyboardState.IsKeyUp(key)) return true;
                else if (keyboardCounter >= 10)
                {
                    keyboardCounter = 0;
                    return true;
                }
            }
            return false;
        }
        private static string FormatDistance(float distance)
        {
            if (distance == float.MaxValue) return "None In Sight";
            return Convert.ToString(distance);
        }
        public static int ScreenCross
        {
            get { return (int) Math.Sqrt(ScreenWidth*ScreenWidth + ScreenHeight*ScreenHeight); }
        }

        public GameParameters NewGameParameters
        {
            set
            {
                lock (newParametersLock)
                {
                    newGameParameters = value;
                }
            }
            get
            {
                lock (newParametersLock)
                {
                    return newGameParameters;
                }
            }
        }
        private void ApplyGameParameters()
        {
            // Xna :
            ScreenWidth = NewGameParameters.ScreenWidth;
            ScreenHeight = NewGameParameters.ScreenHeight;
            Fps = NewGameParameters.Fps;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / Fps);
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();
            // Player :
            Player.StepSize = NewGameParameters.StepSize;
            Player.RotationAngle = NewGameParameters.RotationAngle;
            Player.InitialLife = NewGameParameters.InitialLife;
            Player.InitialDirection = NewGameParameters.InitialDirection;
            Player.FoodLifeBonus = NewGameParameters.FoodLifeBonus;
            Player.Scale = NewGameParameters.Scale;
            // Environment:
            Environment.foodCount = NewGameParameters.FoodCount;
            Environment.RefreshParameters();
            // Evolution Manager:
            Manager.GenerationSize = newGameParameters.GenerationSize;
            Manager.BestfitsCount = newGameParameters.BestfitsCount;
            if (NewGameParameters.NewManager)
            {
                manager = new Manager();
                NewRound();
            }
            // Creature:
            Creature.HiddenLayers = NewGameParameters.HiddenLayers;

        }

        public void Dispose()
        {

        }
    }
}
