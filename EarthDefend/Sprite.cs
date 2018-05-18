using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthDefend
{
    public class Sprite : ICloneable
    {
        //Khai báo biến
        protected Texture2D texture;
       

        protected float rotation;

        public float rotationVelocity = 3f;
        public float linearVelocity = 4f;
        public float speed;
        public Color Color = Color.White;


        protected KeyboardState currentKey;
        protected KeyboardState previousKey;

        public Vector2 position;
        public Vector2 origin;
        public Vector2 direction;
        public Vector2 veloctity;

        public Input Input;

        public float lifeSpan = 0f;
        public bool isRemoved = false;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        //Khởi tạo constructor
        public Sprite(Texture2D texture2D)
        {
            texture = texture2D;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }
        public virtual void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("");
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 0);

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
