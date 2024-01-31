using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using water_color_sorting.Resources.Scripts;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;


    public Text levelno;

    public Sprite[] gameplaybg;
    public SpriteRenderer background;
    public GameObject WatchtubeAd, WatchHintAd;
   
    public GameObject LevelComplete;
    public GameObject pausebox;

    public GameObject hint;
    public GameObject AddTube;

    public Text CoinsValue;
    int coinvalue;

    void Awake()
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


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;  
        background.sprite  = gameplaybg[PlayerPrefs.GetInt("backgroundvalue", 0)];

        coinvalue = SaveDataManager.instance.Getcoinsvalue();
        CoinsValue.text = coinvalue.ToString();
        SaveDataManager.instance.SetcoinsValue(coinvalue);
        levelno.text = "Level : " + SaveDataManager.instance.Getlevelsvalue();
        //Set hint value

        Setaddtubeandhintvalue();
        if (SaveDataManager.instance.Getlevelsvalue() > 2)
        {
            AddTube.SetActive(true);
        }
        if (SaveDataManager.instance.Getlevelsvalue() > 2)
        {
            AddTube.SetActive(true);
            hint.SetActive(true);
        }



    }

    // Update is called once per frame
    void Update()
    {
        CoinsValue.text = SaveDataManager.instance.Getcoinsvalue().ToString();
    }


    public void Setaddtubeandhintvalue()
    {
        AddTube.transform.GetChild(1).gameObject.GetComponent<Text>().text = SaveDataManager.instance.Gettubevalue().ToString();
        hint.transform.GetChild(1).gameObject.GetComponent<Text>().text = SaveDataManager.instance.Gethintvalue().ToString();
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

    public void SkipLevel()
    {

        int levelvalue = SaveDataManager.instance.Getlevelsvalue();
       
            levelvalue++;
            SaveDataManager.instance.Setlevelsvalue(levelvalue);

          SceneManager.LoadScene("LevelSelection");

        



    }



    public void LevelCompelete()
    {
        LevelComplete.gameObject.SetActive(true);
        AddExtraHint();
        AddExtraTube();
    }

    private void AddExtraHint()
    {
        int value = SaveDataManager.instance.Gethintvalue();
        value++;
        SaveDataManager.instance.SetHintValue(value);
    }
    
    private void AddExtraTube()
    {
        int value = SaveDataManager.instance.Gettubevalue();
        value++;
        SaveDataManager.instance.SettubeValue(value);
        print("Total Value" + value);
    }
         

    public void RetryClick()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void pauseClick()
    {
        pausebox.gameObject.SetActive(true);
    }
    public void resumeClick()
    {
        pausebox.gameObject.SetActive(false);
    }

    public void OnstagClick()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void OnMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void AddTubeClick()
    {
        if (SaveDataManager.instance.Gettubevalue() > 0)
        {
            LevelContainer.instance.Addcube();
            int value = SaveDataManager.instance.Gettubevalue();
            value--;
            print("Total Value" + value);
            SaveDataManager.instance.SettubeValue(value);
            Setaddtubeandhintvalue();
        }
        else
        {
            //Enable Some offer for User
            print("AddTubeClick  No Tube");
           //WatchtubeAd.gameObject.SetActive(true);
        }
        
    }

    public void HintClick()
    {
        if (SaveDataManager.instance.Gethintvalue() > 0)
        {
            hint.gameObject.GetComponent<Button>().interactable = false;
            LevelContainer.instance.OnHintClick();
            int value = SaveDataManager.instance.Gethintvalue();
            value--;
            SaveDataManager.instance.SetHintValue(value);
            Setaddtubeandhintvalue();
        }
        else
        {
            // Enable Hint Offer for User
            print("HintClick  No Hint");
            //WatchHintAd.gameObject.SetActive(true);

        }

        
    }




    public void MakeHintButtoninteractable()
    {
        hint.gameObject.GetComponent<Button>().interactable = true;
    }
    public void stopHintButtoninteractable()
    {
        hint.gameObject.GetComponent<Button>().interactable = false;
    }





}
