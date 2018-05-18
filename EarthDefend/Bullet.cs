﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthDefend
{
    public class Bullet : Sprite
    {
        public float timer;
        public Bullet(Texture2D texture) : base(texture)
        {

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            timer += (float)gameTime.TotalGameTime.TotalSeconds;
            if (timer < lifeSpan)
            {
                isRemoved = true;
            }
            position += direction * linearVelocity;
        }

    }
}
