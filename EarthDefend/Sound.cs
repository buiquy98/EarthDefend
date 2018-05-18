using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace EarthDefend
{
    class Sound
    {
        public SoundEffect point;
        public SoundEffect lose;
        public SoundEffect lostLife;
        public SoundEffect ready;
        public SoundEffect win;
        public Song bgMusic;

        //constructor
        public Sound(SoundEffect soundEffect, Song song)
        {
            point = soundEffect;
            lose = soundEffect;
            lostLife = soundEffect;
            ready = soundEffect;
            win = soundEffect;
            bg 

           
        }
        public void LoadContent(ContentManager Content)
        {
            point = Content.Load<SoundEffect>("point");
            lose = Content.Load<SoundEffect>("lose");
            lostLife = Content.Load<SoundEffect>("lostlife");
            ready = Content.Load<SoundEffect>("ready");
            win = Content.Load<SoundEffect>("win");
            bgMusic = Content.Load<Song>("");
        }
    }
}
