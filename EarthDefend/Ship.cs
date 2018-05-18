using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace EarthDefend
{
    public class Ship : Sprite
    {
        public bool hasDied = false;
        public int life = 2;
        public int Score;
        Sound Sound;
        


        public Ship(Texture2D texture) : base(texture)
        {

        }
        
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Please assign a value to 'Input'!!");
            }
            Move(sprites);
            foreach (var item in sprites)
            {

                if (item is Ship)
                {
                    continue;
                }
                if (item.Rectangle.Intersects(this.Rectangle))
                {
                    Game1.isScore = true;
                    item.isRemoved = true;
                    Score++;
                    Sound.addPointSound();

                }
                if (item.position.X <= 0)
                {
                    life--;
                    Sound.addLostLifeSound();
                    item.isRemoved = true;
                }
                if (life == 0)
                {
                    this.hasDied = true;
                    Sound.addLoseSound();

                }
                position += veloctity;
                //Giữ Ship ship trong màn hình
                position.X = MathHelper.Clamp(position.X, 0, 800 - Rectangle.Width / 4);
                position.Y = MathHelper.Clamp(position.Y, 0, 600 - Rectangle.Height / 4);
                //reset velocity khi không có input
                veloctity = Vector2.Zero;
            }

        }

        /// <summary>
        /// Di chuyển Sprite
        /// </summary>
        /// <param name="sprites"></param>
        private void Move(List<Sprite> sprites)
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();
            if (currentKey.IsKeyDown(Input.Left))
            {
                position.X -= speed/2;
            }
            else if (currentKey.IsKeyDown(Input.Right))
            {
                position.X += speed/2;
            }
            direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            if (currentKey.IsKeyDown(Input.Up))
            {
                position.Y -= speed / 2;
            }
            if (currentKey.IsKeyDown(Input.Down))
            {
                position.Y += speed / 2;
            }
        }
    }
}
