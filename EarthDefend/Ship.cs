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

namespace EarthDefend
{
    public class Ship : Sprite
    {
        public Bullet Bullet;
        public bool hasDied = false;
        public int life = 2;
        public int Score;
        
        


        public Ship(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Please assign a value to 'Input'!!");
            }
            //di chuyển Ship
            Move(sprites);
            
            foreach (var item in sprites)
            {

                if (item is Ship)
                {
                    continue;
                }
                if (item.Rectangle.Intersects(this.Rectangle))
                {

                    //life--;
                    //item.isRemoved = true;
                    item.isRemoved = true;
                    Score++;

                }
                if (item.position.X <= 0)
                {
                    life--;

                    item.isRemoved = true;
                }
                if (life == 0)
                {
                    this.hasDied = true;

                }
                //if (Bullet.Rectangle.Intersects(item.Rectangle))
                //{
                //    score++;
                //    item.isRemoved = true;
                //    Bullet.isRemoved = true;
                //}
                position += veloctity;
                //giữ sprite trong màn hình
                //position = Vector2.Clamp(position, new Vector2(0, 0), new Vector2(Game1.screenWidth - this.Rectangle.Width, Game1.screenHeight - this.Rectangle.Height));

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
            //if (currentKey.IsKeyDown(Input.Space) && previousKey.IsKeyUp(Input.Space))
            //{
            //    var bullet = Bullet.Clone() as Bullet;
            //    //thêm bullet
            //    addBullet(sprites, bullet);
            //}
        }

        /// <summary>
        /// Thêm Bullet
        /// </summary>
        /// <param name="sprites"></param>
        /// <param name="bullet"></param>
        //private void addBullet(List<Sprite> sprites, Bullet bullet)
        //{
        //    bullet.direction = this.direction;
        //    //vị trí của Bullet
        //    bullet.position = new Vector2(this.position.X + 40, this.position.Y);
        //    bullet.linearVelocity = this.linearVelocity * 2;
        //    bullet.lifeSpan = 1f;
        //    bullet.parent = this;
        //    sprites.Add(bullet);
        //}
    }
}
