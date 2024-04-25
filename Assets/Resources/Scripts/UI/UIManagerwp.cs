using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Levels;
using water_color_sorting.Resources.Scripts.Managers;

namespace water_color_sorting.Resources.Scripts.UI
{
    public class UIManagerwp : MonoBehaviour
    {
        public static UIManagerwp instance = null;

        public TextMeshProUGUI levelnowp;
        public Sprite[] GameplayBgwp;
        public Sprite[] GameplayTabletBgwp;
        public Image backgroundwp;
        public GameObject LevelCompletewp;
        public GameObject PausePanelwp;
        public GameObject Hintwp;
        public GameObject AddTubewp;
        public TextMeshProUGUI CoinsValuewp;
        int coinvaluewp;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        private void Start()
        {
            Time.timeScale = 1f;
           
            if (DeviceTypeChecker.CheckDeviceType() is DeviceType.Smartphone)
            {
                backgroundwp.sprite  = GameplayBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            }
            else
            {
                backgroundwp.sprite  = GameplayTabletBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            }

            coinvaluewp = SaveDataManagerwp.instancewp.Getcoinsvaluewp();
            CoinsValuewp.text = coinvaluewp.ToString();
            SaveDataManagerwp.instancewp.SetcoinsValuewp(coinvaluewp);
            int prsentLevel = SaveDataManagerwp.instancewp.GetPresentLevel();
            levelnowp.text = "LEVEL:" + prsentLevel;
            //Set hint value

            SetTubeandHintwp();
            if (prsentLevel > 2)
            {
                AddTubewp.SetActive(true);
            }
            if (prsentLevel > 3)
            {
                AddTubewp.SetActive(true);
                Hintwp.SetActive(true);
            }
            MakeAddTubewpHintButtoninteractablewp();
        }
    
        // private void Update()
        // {
        //     CoinsValuewp.text = SaveDataManagerwp.instancewp.Getcoinsvaluewp().ToString();
        // }


        public void SetTubeandHintwp()
        {
            AddTubewp.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = SaveDataManagerwp.instancewp.Gettubevaluewp().ToString();
            Hintwp.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = SaveDataManagerwp.instancewp.Gethintvaluewp().ToString();
            // if (prefmanager.instance.Gettubevalue() == 0)
            // {
            //     AddTube.transform.GetChild(1).gameObject.SetActive(false);
            //     AddTube.transform.GetChild(2).gameObject.SetActive(true);
            // }
            // else
            // {
            //     AddTube.transform.GetChild(1).gameObject.SetActive(true);
            //     AddTube.transform.GetChild(2).gameObject.SetActive(false);
            // }


            // if (prefmanager.instance.Gethintvalue() == 0)
            // {
            //     hint.transform.GetChild(1).gameObject.SetActive(false);
            //     hint.transform.GetChild(2).gameObject.SetActive(true);
            // }
            // else
            // {
            //     hint.transform.GetChild(1).gameObject.SetActive(true);
            //     hint.transform.GetChild(2).gameObject.SetActive(false);
            // }

        }

        public void SkipLevelwp()
        {
            int levelvalue = SaveDataManagerwp.instancewp.Getlevelsvaluewp();
            levelvalue++;
            SaveDataManagerwp.instancewp.Setlevelsvaluewp(levelvalue);
            SceneManager.LoadScene("LevelSelection");
        }

        public void LevelCompeletewp()
        {
            LevelCompletewp.gameObject.SetActive(true);
            StopAddTubewpHintButtoninteractablewp();
            AddExtraHintwp();
            AddExtraTubewp();
        }

        private void AddExtraHintwp()
        {
            int value = SaveDataManagerwp.instancewp.Gethintvaluewp();
            if (value < 3)
            {
                value++;
                SaveDataManagerwp.instancewp.SetHintValuewp(value);
            }
        }
    
        private void AddExtraTubewp()
        {
            int value = SaveDataManagerwp.instancewp.Gettubevaluewp();
            if (value < 3)
            {
                value++;
                SaveDataManagerwp.instancewp.SettubeValuewp(value);
            }
        }

        public void RetryClickwp()
        {
            SceneManager.LoadScene("gameplay");
        }
        public void ShowPausewp()
        {
            PausePanelwp.gameObject.SetActive(true);
        }
        public void Resumewp()
        {
            PausePanelwp.gameObject.SetActive(false);
        }

        public void LoadLevelSelectionwp()
        {
            SceneManager.LoadScene("LevelSelection");
        }
        public void LoadMenuwp()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void AddTubeClickwp()
        {
            int tubevalue = SaveDataManagerwp.instancewp.Gettubevaluewp();
            if (tubevalue > 0 && tubevalue < 14)
            {
                LevelContainerwp.instance.Addcubewp();
                int value = SaveDataManagerwp.instancewp.Gettubevaluewp();
                value--;
                //print("Total Value" + value);
                SaveDataManagerwp.instancewp.SettubeValuewp(value);
                SetTubeandHintwp();
            }
            else
            {
                //Enable Some offer for User
                // print("AddTubeClick  No Tube");
                //WatchtubeAd.gameObject.SetActive(true);
            }
        
        }

        public void HintClickwp()
        {
            if (SaveDataManagerwp.instancewp.Gethintvaluewp() > 0)
            {
                Hintwp.gameObject.GetComponent<Button>().interactable = false;
                LevelContainerwp.instance.OnHintClickwp();
                int value = SaveDataManagerwp.instancewp.Gethintvaluewp();
                value--;
                SaveDataManagerwp.instancewp.SetHintValuewp(value);
                SetTubeandHintwp();
            }
            else
            {
                // Enable Hint Offer for User
                //print("HintClick  No Hint");
                //WatchHintAd.gameObject.SetActive(true);
            }
        }

        public void MakeAddTubewpHintButtoninteractablewp()
        {
            Hintwp.gameObject.GetComponent<Button>().interactable = true;
            AddTubewp.gameObject.GetComponent<Button>().interactable = true;
        }
        public void StopAddTubewpHintButtoninteractablewp()
        {
            Hintwp.gameObject.GetComponent<Button>().interactable = false;
            AddTubewp.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
