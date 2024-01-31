using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Managers;

namespace water_color_sorting.Resources.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        public string PrivacyPolicywp;
        public string RateUsLink;
        public Sprite[] gameplayBgwp;
        public Image backgroundwp;
        public Image shopBackgroundwp;
        public Text cointextwp;
        public Sprite[] onoffwp;
        public Image music;
        public Image sound;
        public Image vibration;
    
        private void Start()
        {
            // SaveDataManager.instance.SetHintValue(10);
            // SaveDataManager.instance.SettubeValue(10);
            SettingWindowInit();
        }
    
        private void Update()
        {
            backgroundwp.sprite = gameplayBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            shopBackgroundwp.sprite = gameplayBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            cointextwp.text = SaveDataManager.instance.Getcoinsvalue().ToString();

        }
        public void OnPLayGame()
        {
            SoundManager.instance.PlayButtonSOund();
            SceneManager.LoadScene("levelselection");
        }
        private void SettingWindowInit()
        {
            music.sprite = onoffwp[SaveDataManager.instance.Getmusicsvalue()];
            sound.sprite = onoffwp[SaveDataManager.instance.Getsoundsvalue()]; 
            vibration.sprite = onoffwp[SaveDataManager.instance.Getvibrationsvalue()];
        }
    
        public void SetMusic()
        {
            SaveDataManager.instance.Setmusicsvalue(SaveDataManager.instance.Getmusicsvalue() == 1 ? 0 : 1);
            music.sprite = onoffwp[SaveDataManager.instance.Getmusicsvalue()];
            SoundManager.instance.SetMusicSource();
        }

        public void SetSound()
        {
            SaveDataManager.instance.Setsoundsvalue(SaveDataManager.instance.Getsoundsvalue() == 1 ? 0 : 1);
            sound.sprite = onoffwp[SaveDataManager.instance.Getsoundsvalue()];
            SoundManager.instance.SetSoundSource();
        }

        public void SetVibration()
        {
            SaveDataManager.instance.Setvibrationvalue(SaveDataManager.instance.Getvibrationsvalue() == 1 ? 0 : 1);
            vibration.sprite = onoffwp[SaveDataManager.instance.Getvibrationsvalue()];
        }
        

        public void ShowPrivacy()
        {
            Application.OpenURL(PrivacyPolicywp);
        }
        public void RateUSToStore()
        {
            Application.OpenURL(RateUsLink);
            //Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
        }

        private void Refacfjjksj()
        {
            float somefloatwp = 0;
        }
        
    }
}
