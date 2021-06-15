using System.Collections.Generic;
using System.Linq;
using Genbox.VelcroPhysics.Dynamics;
using Genbox.VelcroPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mind_Of_Monkey
{
    class Win : Sprite
    {
        private Game1 _game;

        private bool collided = false;
        private bool _win = false;

        public bool _Win => _win;
        public Win(Game1 game, Vector2 position) : 
        base("win", game.Content.Load<Texture2D>($"bananas"), position)
        {
            _game = game;
            AddRectangleBody(_game.Services.GetService<World>(), width: _size.X / 1f, height: _size.X * 1f);
            Fixture sensor = FixtureFactory.AttachRectangle(
                _size.X, _size.Y,
                4, new Vector2(0, 0),
                Body);
            sensor.IsSensor = true;
            Body.IsSensor = true;
            Body.IgnoreGravity = true;

            sensor.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "macaco")
                {
                    if (_game.bananaCount == 5)
                    {
                        if (collided == false)
                        {
                            Body.Position = new Vector2(-100, -100);
                            _game.bananaCount++;
                            collided = true;
                            _win = true;
                            //_game.collectInstance.Play();
                        }
                    }
                }
            };
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
