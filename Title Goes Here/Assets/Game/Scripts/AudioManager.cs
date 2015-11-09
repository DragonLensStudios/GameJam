namespace DLS.Games.TitleGoesHere
{
    using UnityEngine;

    /// <summary>
    /// This class Handles audio and sound effects and methods to manipulate and change audio and sound effects.
    /// </summary>
    [System.Serializable]
    public class AudioManager
    {
        public AudioSource Control; // Move to AudioManager
        public AudioClip[] SFX;
        public AudioClip[] BGM;
//        public AudioClip Day1song; // Move to AudioManager

        public void PlaySFX(int SFXIndex)
        {
            Control.clip = SFX[SFXIndex];
            Control.Play();
        }
        public void PlayBGM(int BGMIndex)
        {
            Control.clip = BGM[BGMIndex];
            Control.Play();
        }

    }
}