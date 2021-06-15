using System.Collections.Generic;
using System.Linq;
using Genbox.VelcroPhysics.Dynamics;
using Genbox.VelcroPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Mind_Of_Monkey
{
    public class Player : AnimatedSprite
    {
        enum Status
        {
            Idle, Walk,
        }
        private Status _status = Status.Idle;
        private Game1 _game;
        private bool _isGrounded = false;
        private Texture2D _fireBall;

        private List<ITempObject> _objects;

        private List<Texture2D> _idleFrames;
        private List<Texture2D> _walkFrames;

        private static Vector2 start_pos = new Vector2(0, 2);

        private Vector2 res_pos = new Vector2(0, 2);

        public void Restart()
        {
            Body.Position = res_pos;
        }

        public Player(Game1 game) :
            base("macaco",
                start_pos,
                Enumerable.Range(1, 1)
                    .Select(
                        n => game.Content.Load<Texture2D>($"macaco walk 3")
                        )
                    .ToArray())
        {
            _idleFrames = _textures; // loaded by the base construtor

            _walkFrames = Enumerable.Range(1, 12)
                .Select(
                    n => game.Content.Load<Texture2D>($"macaco walk {n}")
                )
                .ToList();

            _game = game;

            /*_fireBall = _game.Content.Load<Texture2D>("fireball");
            _objects = new List<ITempObject>();*/
            //collision box
            AddRectangleBody(
                _game.Services.GetService<World>(),
                width: _size.X / 2f
            ); // kinematic is false by default

            Fixture sensor = FixtureFactory.AttachRectangle(
                _size.X / 3f, _size.Y * 0.05f,
                4, new Vector2(0, -_size.Y / 2f),
                Body);
            sensor.IsSensor = true;

            sensor.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name != "bullet") _isGrounded = true;
                //if (b.GameObject().Name == "spike") Restart();

            };
            sensor.OnSeparation = (a, b, contact) => _isGrounded = false;

            Body.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "croc") Restart();
            };
            /*Fixture sensor2 = FixtureFactory.AttachRectangle(
                _size.X / 2f,_size.Y / 2f,
                4, new Vector2(0,0),
                Body);
            sensor2.IsSensor = true;
            sensor2.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "spike") Restart();
            };
            */
            KeyboardManager.Register(
                Keys.Space,
                KeysState.GoingDown,
                () =>
                {
                    if (_isGrounded) Body.ApplyForce(new Vector2(0, 100f));

                });
            KeyboardManager.Register(
                Keys.A,
                KeysState.Down,
                () => { Body.ApplyForce(new Vector2(-3f, 0)); });
            KeyboardManager.Register(
                Keys.D,
                KeysState.Down,
                () => { Body.ApplyForce(new Vector2(3f, 0)); });
            KeyboardManager.Register(Keys.R, KeysState.Down, () =>
            {
                Restart();
            });
        }

        public override void Update(GameTime gameTime)
        {
            /*  foreach (ITempObject obj in _objects)
                  obj.Update(gameTime);*/

            if (_status == Status.Idle && Body.LinearVelocity.LengthSquared() > 0.001f)
            {
                _status = Status.Walk;
                _textures = _walkFrames;
                _currentTexture = 0;
            }

            if (_status == Status.Walk && Body.LinearVelocity.LengthSquared() <= 0.001f)
            {
                _status = Status.Idle;
                _textures = _idleFrames;
                _currentTexture = 0;
            }

            if (Body.LinearVelocity.X < 0f) _direction = Direction.Left;
            else if (Body.LinearVelocity.X > 0f) _direction = Direction.Right;

            if (Position == start_pos)
            {
                _game.inicioInstance.Play();
            }
            if ((Position.X > 7) && (Position.X < 9))
            {
                if ((Position.Y > 0) && (Position.Y < 2))
                {
                    _game.crocInstance.Play();
                }

            }
            if ((Position.X > 55) && (Position.X < 57))
            {
                if ((Position.Y > 0) && (Position.Y < 2))
                {
                    _game.caixaInstance.Play();
                }

            }
            base.Update(gameTime);
            Camera.LookAt(_position);

            /*_objects.AddRange( _objects
                .Where(obj => obj is Bullet)
                .Cast<Bullet>()
                .Where(b => b.Collided)
                .ToArray()
            );
            _objects = _objects.Where(b => !b.IsDead()).ToList();*/
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
            // foreach (ITempObject obj in _objects)
            // obj.Draw(spriteBatch, gameTime);
        }

    }
}