using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        coinvalue = prefmanager.instance.Getcoinsvalue();
        CoinsValue.text = coinvalue.ToString();
        prefmanager.instance.SetcoinsValue(coinvalue);
        levelno.text = "Level : " + prefmanager.instance.Getlevelsvalue();
        //Set hint value

        Setaddtubeandhintvalue();
        if (prefmanager.instance.Getlevelsvalue() > 2)
        {
            AddTube.SetActive(true);
        }
        if (prefmanager.instance.Getlevelsvalue() > 2)
        {
            AddTube.SetActive(true);
            hint.SetActive(true);
        }



    }

    // Update is called once per frame
    void Update()
    {
        CoinsValue.text = prefmanager.instance.Getcoinsvalue().ToString();
    }


    public void Setaddtubeandhintvalue()
    {
        AddTube.transform.GetChild(1).gameObject.GetComponent<Text>().text = prefmanager.instance.Gettubevalue().ToString();
        hint.transform.GetChild(1).gameObject.GetComponent<Text>().text = prefmanager.instance.Gethintvalue().ToString();
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

        int levelvalue = prefmanager.instance.Getlevelsvalue();
       
            levelvalue++;
            prefmanager.instance.Setlevelsvalue(levelvalue);

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
        int value = prefmanager.instance.Gethintvalue();
        value++;
        prefmanager.instance.SetHintValue(value);
    }
    
    private void AddExtraTube()
    {
        int value = prefmanager.instance.Gettubevalue();
        value++;
        prefmanager.instance.SettubeValue(value);
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
        if (prefmanager.instance.Gettubevalue() > 0)
        {
            LevelContainer.instance.Addcube();
            int value = prefmanager.instance.Gettubevalue();
            value--;
            print("Total Value" + value);
            prefmanager.instance.SettubeValue(value);
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
        if (prefmanager.instance.Gethintvalue() > 0)
        {
            hint.gameObject.GetComponent<Button>().interactable = false;
            LevelContainer.instance.OnHintClick();
            int value = prefmanager.instance.Gethintvalue();
            value--;
            prefmanager.instance.SetHintValue(value);
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
