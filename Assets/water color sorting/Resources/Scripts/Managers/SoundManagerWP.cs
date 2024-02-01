using UnityEngine;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class SoundManagerWP : MonoBehaviour
    {
        public static SoundManagerWP instance = null;

        [Header("Audio source to Play Sounds")]
        public AudioSource MusicSourcewp;
        public AudioSource SoundSourcewp;

        [Header("Audio Clips")]
        public AudioClip Musicwp;
        public AudioClip errormessagewp;
        public AudioClip ButtonSoundwp;
        public AudioClip waterdropsoundwp;
        public AudioClip levelcompeletesoundwp;
        public AudioClip bottlefillsoundwp;
        public AudioClip confettiparticlewp;
        
        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            PlayMusicwp();
            SetSoundState();
            SetMusicState();
        }

        public void SetSoundState()
        {
            if (SaveDataManagerwp.instance.Getsoundsvalue()==1)
            {
                SoundSourcewp.mute = false;
            }
            else
            {
                SoundSourcewp.mute = true;
            }
        }
        public void SetMusicState()
        {
            if (SaveDataManagerwp.instance.Getmusicsvalue() == 1)
            {
                MusicSourcewp.mute = false;
            }
            else
            {
                MusicSourcewp.mute = true;
            }
        }
        public void SetVibarationState()
        {
            if (SaveDataManagerwp.instance.Getvibrationsvalue() == 1)
            {
                Handheld.Vibrate();
            }
        }

        public void PlayButtonSoundwp()
        {
            SoundSourcewp.PlayOneShot(ButtonSoundwp);
        }
        
        public void PlaywaterdropSoundPlaywp()
        {
            SoundSourcewp.clip = waterdropsoundwp;
            SoundSourcewp.Play();
        }
        public void PlaywaterdropSoundStopwp()
        {
            SoundSourcewp.clip = null;
        }
        
        public void PlayconfettiSOundwp()
        {
            SoundSourcewp.PlayOneShot(confettiparticlewp);
        }

        public void ErrorSoundwp()
        {
            SoundSourcewp.PlayOneShot(errormessagewp);
        }

        public void PlaybottlfillSoundwp()
        {
            SoundSourcewp.PlayOneShot(bottlefillsoundwp);
        }
        public void PlaylevelcompeleteSoundwp()
        {
            SoundSourcewp.PlayOneShot(levelcompeletesoundwp);
        }

        public void PlayMusicwp()
        {
            MusicSourcewp.clip=Musicwp;
            MusicSourcewp.Play();
        }

    }
}
