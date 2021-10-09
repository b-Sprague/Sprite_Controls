using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprite_Sheet
{
    public class Camera 
    {
        public Matrix Transform { get; protected set;}

        public void Follow(Player target)
        {
            var position = Matrix.CreateTranslation(
                -target.position.X - (target.playerRec.Width / 2),
                -target.position.Y - (target.playerRec.Height / 2), 0);

            var offset = Matrix.CreateTranslation(
                    Game1.screenWidth / 2,
                    Game1.screenHieght / 2, 0);

            Transform = position * offset;
        }
        
    }
}
