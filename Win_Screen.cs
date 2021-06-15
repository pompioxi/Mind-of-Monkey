using System.Collections.Generic;
using System.Linq;
using Genbox.VelcroPhysics.Dynamics;
using Genbox.VelcroPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mind_Of_Monkey
{
    class Win_Screen : Sprite
    {
        private Game1 _game;
        public Win_Screen(Game1 game, Vector2 position) :
        base("win_screen", game.Content.Load<Texture2D>($"win_screen"), position)
        {
            _game = game;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
