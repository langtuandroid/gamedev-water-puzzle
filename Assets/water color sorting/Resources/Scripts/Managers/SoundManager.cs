using UnityEngine;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance = null;

        [Header("Audio source to Play Sounds")]
        public AudioSource MusicSource;
        public AudioSource SoundSource;

        [Header("Audio Clips")]
        public AudioClip Music;
        public AudioClip errormessage;
        public AudioClip ButtonSound;
        public AudioClip waterdropsound;
        public AudioClip levelcompeletesound;
        public AudioClip bottlefillsound;
        public AudioClip confettiparticle;
        
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
            playmusic();
            SetSoundSource();
            SetMusicSource();
        }

        public void SetSoundSource()
        {
            if (SaveDataManager.instance.Getsoundsvalue()==1)
            {
                SoundSource.mute = false;
            }
            else
            {
                SoundSource.mute = true;
            }
        }
        public void SetMusicSource()
        {
            if (SaveDataManager.instance.Getmusicsvalue() == 1)
            {
                MusicSource.mute = false;
            }
            else
            {
                MusicSource.mute = true;
            }
        }
        public void MakeVibaration()
        {
            if (SaveDataManager.instance.Getvibrationsvalue() == 1)
            {
                Handheld.Vibrate();
            }
       
        }


        // Update is called once per frame
        void Update()
        {
        
        }

        public void PlayButtonSOund()
        {
            SoundSource.PlayOneShot(ButtonSound);
        }
        public void PlaywaterdropSoundplay()
        {
            SoundSource.clip = waterdropsound;
            SoundSource.Play();
        }
        public void PlaywaterdropSOundstop()
        {
            SoundSource.clip = null;
        }

    

        public void PlayconfettiSOund()
        {
            SoundSource.PlayOneShot(confettiparticle);
        }



        public void errorSOund()
        {

            SoundSource.PlayOneShot(errormessage);
        }

        public void PlaybottlfillSOund()
        {

            SoundSource.PlayOneShot(bottlefillsound);
        }
        public void PlaylevelcompeleteSOund()
        {
            SoundSource.PlayOneShot(levelcompeletesound);
        }

        public void playmusic()
        {
            MusicSource.clip=Music;
            MusicSource.Play();
        }












    }
}
