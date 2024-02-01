using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Managers;

namespace water_color_sorting.Resources.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
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
            cointextwp.text = SaveDataManagerwp.instance.Getcoinsvalue().ToString();

        }
        public void OnPLayGame()
        {
            SoundManagerWP.instance.PlayButtonSoundwp();
            SceneManager.LoadScene("levelselection");
        }
        private void SettingWindowInit()
        {
            music.sprite = onoffwp[SaveDataManagerwp.instance.Getmusicsvalue()];
            sound.sprite = onoffwp[SaveDataManagerwp.instance.Getsoundsvalue()]; 
            vibration.sprite = onoffwp[SaveDataManagerwp.instance.Getvibrationsvalue()];
        }
    
        public void SetMusic()
        {
            SaveDataManagerwp.instance.Setmusicsvalue(SaveDataManagerwp.instance.Getmusicsvalue() == 1 ? 0 : 1);
            music.sprite = onoffwp[SaveDataManagerwp.instance.Getmusicsvalue()];
            SoundManagerWP.instance.SetMusicState();
        }

        public void SetSound()
        {
            SaveDataManagerwp.instance.Setsoundsvalue(SaveDataManagerwp.instance.Getsoundsvalue() == 1 ? 0 : 1);
            sound.sprite = onoffwp[SaveDataManagerwp.instance.Getsoundsvalue()];
            SoundManagerWP.instance.SetSoundState();
        }

        public void SetVibration()
        {
            SaveDataManagerwp.instance.Setvibrationvalue(SaveDataManagerwp.instance.Getvibrationsvalue() == 1 ? 0 : 1);
            vibration.sprite = onoffwp[SaveDataManagerwp.instance.Getvibrationsvalue()];
        }
        

//         public void ShowPrivacy()
//         {
//             Application.OpenURL(PrivacyPolicywp);
//         }
//         public void RateUSToStore()
//         {
//             Application.OpenURL(RateUsLink);
//             //Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
//         }
//         
//         public void ShareLink()
//         {
// #if UNITY_IOS
//             new NativeShare()
//                 .SetUrl(ShareAppLink)
//                 .Share();
// #elif UNITY_ANDROID
//             new NativeShare()
//                 .SetUrl(ShareAppLink)
//                 .Share(); 
// #endif
//
//         }
//         private void Refacfjjksj()
//         {
//             float somefloatwp = 0;
//         }
//         
    }
}
