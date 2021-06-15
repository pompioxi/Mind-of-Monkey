using Genbox.VelcroPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using Genbox.VelcroPhysics.Factories;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Mind_Of_Monkey
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SoundEffect _eff;
        private SpriteBatch _spriteBatch;
        private Scene _scene;
        private Player _player;
        //private NPC _npc;
        private vine _vine, _vine2, _vine3;
        private bananas banana1, banana2, banana3, banana4, banana5, banana6;
        private Caixa caixa1, caixa2;
        private Spike spike1;
        private Crocodilo croc1, croc2, croc3, croc4;
        private Casa casa;
        private Arvore arv1, arv2, arv3;
        private World _world;
        public int bananaCount;
        private SpriteFont arial12;
        public Player Player => _player;
        private Song _song;
        private SoundEffect incio,collect,caixa,crocodilo,objetivo;
        public SoundEffectInstance inicioInstance,collectInstance,crocInstance,objectivoInstance,caixaInstance;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _world = new World(new Vector2(0, -9.82f));
            Services.AddService(_world);

            new KeyboardManager(this);
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.ApplyChanges();

            Debug.SetGraphicsDevice(GraphicsDevice);

            new Camera(GraphicsDevice, height: 5f);
            Camera.LookAt(Camera.WorldSize / 2f);

            _player = new Player(this);
            // _npc = new NPC(this);

            _vine = new vine(this, new Vector2(32, 8));
            _vine2 = new vine(this, new Vector2(43.5f, 2.2f));
            _vine3 = new vine(this, new Vector2(56f, 3f));
            //banana1 = new bananas(this, new Vector2(-1, 1));
            //banana2 = new bananas(this, new Vector2(0, 1));
            //banana3 = new bananas(this, new Vector2(1, 1));
            //banana4 = new bananas(this, new Vector2(2, 1));
            //banana5 = new bananas(this, new Vector2(3, 1));
            //banana6 = new bananas(this, new Vector2(4, 1));
            caixa1 = new Caixa(this, new Vector2(48, 9));
            caixa2 = new Caixa(this, new Vector2(22, 2));
            //spike1 = new Spike(this, new Vector2(2,0));
            croc1 = new Crocodilo(this, new Vector2(15, 2));
            croc2 = new Crocodilo(this, new Vector2(30, 2));
            croc3 = new Crocodilo(this, new Vector2(39.7f, 2));
            croc4 = new Crocodilo(this, new Vector2(49, 2));
            arv1 = new Arvore(this, new Vector2(27.1f, 3.3f));
            arv2 = new Arvore(this, new Vector2(38f, 3.3f));
            arv3 = new Arvore(this, new Vector2(46.5f, 3.3f));
            casa = new Casa(this, new Vector2(1.85f, 2.3f));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scene = new Scene(this, "MainScene");
            arial12 = Content.Load<SpriteFont>("arial 12"); 
            incio = Content.Load<SoundEffect>("inicio (online-audio-converter.com)");
            inicioInstance =incio.CreateInstance(); 
           
            collect = Content.Load<SoundEffect>("Arcade Game Collect Item Sound Effect");
            collectInstance = collect.CreateInstance();
           
            objetivo = Content.Load<SoundEffect>("primeira banana");
            objectivoInstance= objetivo.CreateInstance();
            
            caixa = Content.Load<SoundEffect>("caixa");
            caixaInstance = caixa.CreateInstance();
            
            
            crocodilo = Content.Load<SoundEffect>("primerio crocodilo");
            crocInstance = crocodilo.CreateInstance();
            
            _song = Content.Load<Song>("Donkey Kong Country Theme Restored to HD");
            MediaPlayer.Volume = 0.15f;
            MediaPlayer.Play(_song);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
            _player.Update(gameTime);
            // _npc.Update(gameTime);
            _vine.Update(gameTime);
            _vine2.Update(gameTime);
            _vine3.Update(gameTime);
            //banana1.Update(gameTime);
            //banana2.Update(gameTime);
            //banana3.Update(gameTime);
            //banana4.Update(gameTime);
            //banana5.Update(gameTime);
            //banana6.Update(gameTime);
            caixa1.Update(gameTime);
            caixa2.Update(gameTime);
            //spike1.Update(gameTime);
            croc1.Update(gameTime);
            croc2.Update(gameTime);
            croc3.Update(gameTime);
            croc4.Update(gameTime);
            arv1.Update(gameTime);
            arv2.Update(gameTime);
            arv3.Update(gameTime);
            casa.Update(gameTime);
            base.Update(gameTime);

            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            arv1.Draw(_spriteBatch, gameTime);
            arv2.Draw(_spriteBatch, gameTime);
            arv3.Draw(_spriteBatch, gameTime);
            casa.Draw(_spriteBatch, gameTime);
            _scene.Draw(_spriteBatch, gameTime);
            // _npc.Draw(_spriteBatch, gameTime);
            _vine.Draw(_spriteBatch, gameTime);
            _vine2.Draw(_spriteBatch, gameTime);
            _vine3.Draw(_spriteBatch, gameTime);
            //banana1.Draw(_spriteBatch, gameTime);
            //banana2.Draw(_spriteBatch, gameTime);
            //banana3.Draw(_spriteBatch, gameTime);
            //banana4.Draw(_spriteBatch, gameTime);
            //banana5.Draw(_spriteBatch, gameTime);
            //.Draw(_spriteBatch, gameTime);
            _player.Draw(_spriteBatch, gameTime);
            caixa1.Draw(_spriteBatch, gameTime);
            caixa2.Draw(_spriteBatch, gameTime);
            //spike1.Draw(_spriteBatch, gameTime);
            croc1.Draw(_spriteBatch, gameTime);
            croc2.Draw(_spriteBatch, gameTime);
            croc3.Draw(_spriteBatch, gameTime);
            croc4.Draw(_spriteBatch, gameTime);
            string bananas = $"Bananas: {bananaCount}";
            Point measure = arial12.MeasureString(bananas).ToPoint();
            _spriteBatch.DrawString(arial12, bananas, new Vector2(1, 720), Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

