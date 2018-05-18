using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthDefend
{
    class Sound
    {
        private Song bgMusic;
        private SoundEffect lose;
        private SoundEffect lostLife;
        private SoundEffect point;
        private SoundEffect ready;
        private SoundEffect win;

        public Song BgMusic { get => bgMusic; set => bgMusic = value; }
        public SoundEffect Lose { get => lose; set => lose = value; }
        public SoundEffect LostLife { get => lostLife; set => lostLife = value; }
        public SoundEffect Point { get => point; set => point = value; }
        public SoundEffect Ready { get => ready; set => ready = value; }
        public SoundEffect Win { get => win; set => win = value; }

        public Sound()
        {
            BgMusic = bgMusic;
            Lose = lose;
            LostLife = lostLife;
            Point = point;
            Ready = ready;
            Win = win;
        }
        public void LoadContent(ContentManager content)
        {
            bgMusic = content.Load<Song>("bgmusic");
            lose = content.Load<SoundEffect>("lose");
            lostLife = content.Load<SoundEffect>("lostlife");
            point = content.Load<SoundEffect>("point");
            ready = content.Load<SoundEffect>("ready");
            win = content.Load<SoundEffect>("win");
        }
        public void playBgMusic()
        {
            MediaPlayer.Play(bgMusic);
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }
        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            MediaPlayer.Volume -= -0.1f;
            MediaPlayer.Play(bgMusic);
        }

        public void addLoseSound()
        {
            lose.Play();
        }
        public void addLostLifeSound()
        {
            lostLife.Play();
        }
        public void addPointSound()
        {
            point.Play();
        }
        public void addReadySound()
        {
            
            ready.Play();
        }
        public void addWinSound()
        {
            win.Play();
        }
    }
}
