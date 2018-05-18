using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace EarthDefend
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        //List<SoundEffect> soundEffects;
        

        private List<Sprite> sprites;
        private SpriteFont font;
        public static Random random;

        public static int screenHeight;
        public static int screenWidth;

        public bool hasStarted = false;
        public float timer;

        Song song;
        SoundEffect soundEffect;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            random = new Random();

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

            screenHeight = graphics.PreferredBackBufferHeight;
            screenWidth = graphics.PreferredBackBufferWidth;

            //soundEffects = new List<SoundEffect>();
           


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //LoadbgMusic();
            //playBackgroundMusic();
            
            // TODO: use this.Content to load your game content here
            Restart();
        }

        
        private void LoadbgMusic()
        {
            song = Content.Load<Song>("bgmusic");
            MediaPlayer.Play(song);
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            MediaPlayer.Volume -= -0.1f;
            MediaPlayer.Play(song);
        }

        //private void playBackgroundMusic()
        //{
        //    soundEffects.Add(Content.Load<SoundEffect>("musicbackground"));

        //    soundEffects[0].Play();

        //    SoundEffectInstance instance = soundEffects[0].CreateInstance();
        //    instance.IsLooped = true;
        //    soundEffects[0].Play(0.5f, 0.0f, 0.0f);
        //}

        private void Restart()
        {
            //load Texture2D Ship 
            background = Content.Load<Texture2D>("background");
            var ship = Content.Load<Texture2D>("af");
            sprites = new List<Sprite>
            {
                
                new Ship(ship)
                {
                    //position=new Vector2(10,600),
                    //Bullet=new Bullet(Content.Load<Texture2D>("bullet")),
                    Input= new Input()
                    {
                        Left=Keys.Left,
                        Right=Keys.Right,
                        Up=Keys.Up,
                        Down=Keys.Down,
                        Enter=Keys.Enter,
                    },
                    speed=10f,
                }
            };
            font = Content.Load<SpriteFont>("score");
            hasStarted = false;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                hasStarted = true;
                LoadbgMusic();
            }
            if (!hasStarted)
            {
                return;
            }

            // TODO: Add your update logic here
            foreach (var item in sprites.ToArray())
            {
                item.Update(gameTime, sprites);
            }
            for (int i = 0; i < sprites.Count; i++)
            {
                if (sprites[i].isRemoved)
                {
                    sprites.RemoveAt(i);
                    i--;
                    
                }
            }
            //if (hasStarted==true)
            //{
            //    playBackgroundMusic();
            //}

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (var item in sprites)
            {
                item.Update(gameTime, sprites);
            }
            //sinh ra target mỗi 0.5s
            if (timer > 0.5f)
            {
                timer = 0;
                /// Add Texture ufo"
                sprites.Add(new Target(Content.Load<Texture2D>("ufo")));

            }
            for (int i = 0; i < sprites.Count; i++)
            {
                var sprite = sprites[i];
                if (sprite.isRemoved)
                {
                    sprites.RemoveAt(i);
                    i--;
                   
                }
                if (sprite is Ship)
                {
                    var ship = sprite as Ship;
                    //mỗi khi hết mạng sẽ Restart()
                    if (ship.hasDied == true)
                    {
                        Restart();
                        LoadbgMusic();
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            foreach (var item in sprites)
            {
                item.Draw(spriteBatch);
            }
            foreach (var item in sprites)
            {
                if (item is Ship)
                {
                    spriteBatch.DrawString(font, string.Format("Score: {0}",((Ship)item).Score), new Vector2(10, 10), Color.AliceBlue);
                    spriteBatch.DrawString(font, string.Format("Life: {0}", ((Ship)item).life), new Vector2(10, 30), Color.AliceBlue);
                }
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
