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

        coinvaluewp = SaveDataManagerwp.instance.Getcoinsvalue();
        CoinsValuewp.text = coinvaluewp.ToString();
        SaveDataManagerwp.instance.SetcoinsValue(coinvaluewp);
        levelnowp.text = "Level : " + SaveDataManagerwp.instance.Getlevelsvalue();
        //Set hint value

        SetTubeandHintwp();
        if (SaveDataManagerwp.instance.Getlevelsvalue() > 2)
        {
            AddTubewp.SetActive(true);
        }
        if (SaveDataManagerwp.instance.Getlevelsvalue() > 2)
        {
            AddTubewp.SetActive(true);
            Hintwp.SetActive(true);
        }
    }
    
    private void Update()
    {
        CoinsValuewp.text = SaveDataManagerwp.instance.Getcoinsvalue().ToString();
    }


    public void SetTubeandHintwp()
    {
        AddTubewp.transform.GetChild(1).gameObject.GetComponent<Text>().text = SaveDataManagerwp.instance.Gettubevalue().ToString();
        Hintwp.transform.GetChild(1).gameObject.GetComponent<Text>().text = SaveDataManagerwp.instance.Gethintvalue().ToString();
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
        int levelvalue = SaveDataManagerwp.instance.Getlevelsvalue();
        levelvalue++;
        SaveDataManagerwp.instance.Setlevelsvalue(levelvalue);
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
        int value = SaveDataManagerwp.instance.Gethintvalue();
        if (value < 3)
        {
            value++;
            SaveDataManagerwp.instance.SetHintValue(value);
        }
    }
    
    private void AddExtraTubewp()
    {
        int value = SaveDataManagerwp.instance.Gettubevalue();
        if (value < 3)
        {
            value++;
            SaveDataManagerwp.instance.SettubeValue(value);
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
        if (SaveDataManagerwp.instance.Gettubevalue() > 0)
        {
            LevelContainerwp.instance.Addcubewp();
            int value = SaveDataManagerwp.instance.Gettubevalue();
            value--;
            print("Total Value" + value);
            SaveDataManagerwp.instance.SettubeValue(value);
            SetTubeandHintwp();
        }
        else
        {
            //Enable Some offer for User
            print("AddTubeClick  No Tube");
           //WatchtubeAd.gameObject.SetActive(true);
        }
        
    }

    public void HintClickwp()
    {
        if (SaveDataManagerwp.instance.Gethintvalue() > 0)
        {
            Hintwp.gameObject.GetComponent<Button>().interactable = false;
            LevelContainerwp.instance.OnHintClickwp();
            int value = SaveDataManagerwp.instance.Gethintvalue();
            value--;
            SaveDataManagerwp.instance.SetHintValue(value);
            SetTubeandHintwp();
        }
        else
        {
            // Enable Hint Offer for User
            print("HintClick  No Hint");
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
