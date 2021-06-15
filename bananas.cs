using System.Collections.Generic;
using System.Linq;
using Genbox.VelcroPhysics.Dynamics;
using Genbox.VelcroPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mind_Of_Monkey
{
    public class bananas : Sprite
    {
        private Game1 _game;

    
        public bool collided = false;

        private HashSet<Fixture> _collisions;
        


        public bananas(Game1 game, Vector2 position) :
        base("banana", game.Content.Load<Texture2D>($"banana"), position)
        {
            _collisions = new HashSet<Fixture>();
            _direction = Direction.Left;
            _game = game;

            AddRectangleBody(_game.Services.GetService<World>(), width: _size.X / 1f, height: _size.X * 1f); // kinematic is false by default

            Fixture sensor = FixtureFactory.AttachRectangle(
                _size.X / 1f, _size.Y * 1f,
                4, new Vector2(0, 0),
                Body);
            sensor.IsSensor = true;
            Body.IsSensor = true;
            Body.IgnoreGravity = true;

            if (collided == false)
            {
                sensor.OnCollision = (a, b, contact) =>
                {
                    Body.Position = new Vector2(-100, -100);
                    _game.bananaCount++;
                    collided = true;
                    _game.collectInstance.Play();

                };
            }
            if(_game.bananaCount == 1)
            {
             _game.objectivoInstance.Play();
            }
        }





        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

    }
}
