using NativeShareNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using water_color_sorting.Resources.Scripts.Levels;
using water_color_sorting.Resources.Scripts.Managers;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public Text levelnowp;
    [FormerlySerializedAs("gameplaybg")] public Sprite[] GameplayBgwp;
    [FormerlySerializedAs("background")] public SpriteRenderer backgroundwp;

    [FormerlySerializedAs("LevelComplete")] public GameObject LevelCompletewp;
    [FormerlySerializedAs("pausebox")] public GameObject PausePanelwp;

    [FormerlySerializedAs("hint")] public GameObject Hintwp;
    [FormerlySerializedAs("AddTube")] public GameObject AddTubewp;

    [FormerlySerializedAs("CoinsValue")] public Text CoinsValuewp;
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
        backgroundwp.sprite  = GameplayBgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];

        coinvaluewp = SaveDataManagerwp.instancewp.Getcoinsvaluewp();
        CoinsValuewp.text = coinvaluewp.ToString();
        SaveDataManagerwp.instancewp.SetcoinsValuewp(coinvaluewp);
        levelnowp.text = "Level : " + SaveDataManagerwp.instancewp.Getlevelsvaluewp();
        //Set hint value

        SetTubeandHintwp();
        if (SaveDataManagerwp.instancewp.Getlevelsvaluewp() > 2)
        {
            AddTubewp.SetActive(true);
        }
        if (SaveDataManagerwp.instancewp.Getlevelsvaluewp() > 2)
        {
            AddTubewp.SetActive(true);
            Hintwp.SetActive(true);
        }
    }
    
    private void Update()
    {
        CoinsValuewp.text = SaveDataManagerwp.instancewp.Getcoinsvaluewp().ToString();
    }


    public void SetTubeandHintwp()
    {
        AddTubewp.transform.GetChild(1).gameObject.GetComponent<Text>().text = SaveDataManagerwp.instancewp.Gettubevaluewp().ToString();
        Hintwp.transform.GetChild(1).gameObject.GetComponent<Text>().text = SaveDataManagerwp.instancewp.Gethintvaluewp().ToString();
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
        if (SaveDataManagerwp.instancewp.Gettubevaluewp() > 0)
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

    public void MakeHintButtoninteractablewp()
    {
        Hintwp.gameObject.GetComponent<Button>().interactable = true;
    }
    public void StopHintButtoninteractablewp()
    {
        Hintwp.gameObject.GetComponent<Button>().interactable = false;
    }
}
