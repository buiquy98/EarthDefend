using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthDefend
{
    public class Target : Sprite
    {
        
        public Target(Texture2D texture) : base(texture)
        {
            // Set location cho ufo
            var xPos = Game1.random.Next(Game1.screenWidth/2, Game1.screenWidth);
            var yPos = Game1.random.Next(10, Game1.screenHeight-10);
            position = new Vector2(xPos,yPos);
            speed = Game1.random.Next(1, 4);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //vị trí xuất hiện target
            //position.X -= speed;
            position.X -= speed;

            if (Rectangle.Bottom >= Game1.screenWidth)
            {
                isRemoved = true;
            }
        }
    }
}
