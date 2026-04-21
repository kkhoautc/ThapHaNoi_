using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Media;

namespace ThapHaNoi
{
    public static class SoundManager
    {

        private static SoundPlayer movePlayer;
        private static SoundPlayer errorPlayer;
        private static SoundPlayer winPlayer;
        private static SoundPlayer backgroundSound;
        public static bool IsSoundEnabled = true;
        
        public static void InitSounds()
        {

            backgroundSound = new SoundPlayer(Properties.Resources.sound);
            movePlayer = new SoundPlayer(Properties.Resources.moveSound);
            errorPlayer = new SoundPlayer(Properties.Resources.errorSound);
            winPlayer = new SoundPlayer(Properties.Resources.winSound);


            backgroundSound.LoadAsync();
            errorPlayer.LoadAsync();
            winPlayer.LoadAsync();
            movePlayer.LoadAsync();
        }
        public static void setEnable(bool enable)
        {
            if (enable)
            {
                IsSoundEnabled = true;
            }
            else
            {
                IsSoundEnabled = false;
            }
        }
        public static void PlaySound()
        {
            if (IsSoundEnabled) backgroundSound.Play();
        }
        public static void StopSound()
        {
            backgroundSound.Stop();
        }
        public static void PlayMove()
        {
            if (IsSoundEnabled && movePlayer != null) movePlayer.Play();
        }

        public static void PlayError()
        {
            if (IsSoundEnabled && errorPlayer != null) errorPlayer.Play();
        }

        public static void PlayWin()
        {
            if (IsSoundEnabled && winPlayer != null) winPlayer.Play();
        }
    }
}