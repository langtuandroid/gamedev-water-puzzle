using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public Sprite[] smartphoneBgwp;
        public Sprite[] tabletBgwp;
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
    
        private void OnEnable()
        {
            if (DeviceTypeChecker.CheckDeviceType() is DeviceType.Smartphone)
            {
                backgroundwp.sprite = smartphoneBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
                shopBackgroundwp.sprite = smartphoneBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            }
            else
            {
                backgroundwp.sprite = tabletBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
                shopBackgroundwp.sprite = tabletBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            }
           
            //cointextwp.text = SaveDataManagerwp.instancewp.Getcoinsvaluewp().ToString();
        }
        public void PLayGamewp()
        {
            SoundManagerWP.instance.PlayButtonSoundwp();
            SceneManager.LoadScene("levelselection");
        }
        private void SettingWindowInit()
        {
            music.sprite = onoffwp[SaveDataManagerwp.instancewp.Getmusicsvaluewp()];
            sound.sprite = onoffwp[SaveDataManagerwp.instancewp.Getsoundsvaluewp()]; 
            vibration.sprite = onoffwp[SaveDataManagerwp.instancewp.Getvibrationsvaluewp()];
        }
    
        public void SetMusicwp()
        {
            SaveDataManagerwp.instancewp.Setmusicsvaluewp(SaveDataManagerwp.instancewp.Getmusicsvaluewp() == 1 ? 0 : 1);
            music.sprite = onoffwp[SaveDataManagerwp.instancewp.Getmusicsvaluewp()];
            SoundManagerWP.instance.SetMusicState();
        }

        public void SetSoundwp()
        {
            SaveDataManagerwp.instancewp.Setsoundsvaluewp(SaveDataManagerwp.instancewp.Getsoundsvaluewp() == 1 ? 0 : 1);
            sound.sprite = onoffwp[SaveDataManagerwp.instancewp.Getsoundsvaluewp()];
            SoundManagerWP.instance.SetSoundState();
        }

        public void SetVibrationwp()
        {
            SaveDataManagerwp.instancewp.Setvibrationvaluewp(SaveDataManagerwp.instancewp.Getvibrationsvaluewp() == 1 ? 0 : 1);
            vibration.sprite = onoffwp[SaveDataManagerwp.instancewp.Getvibrationsvaluewp()];
        }
    }
}

