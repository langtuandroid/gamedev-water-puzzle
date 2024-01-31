using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public bool deleteallpref;

    public string privacypolicy;
 

    public Sprite[] gameplaybg;
    public Image background;
    public Text cointext;

    public Sprite[] onoff;
    public Image music, sound, vibration;

    // Start is called before the first frame update
    void Start()
    {


        if (deleteallpref == true)
        {
            PlayerPrefs.DeleteAll();
        }
     
        // prefmanager.instance.SetHintValue(10);
       //  prefmanager.instance.SettubeValue(10);
        setingdialogue();
    }

    // Update is called once per frame
    void Update()
    {
        background.sprite = gameplaybg[PlayerPrefs.GetInt("backgroundvalue", 0)];
        cointext.text = prefmanager.instance.Getcoinsvalue().ToString();

    }
    public void onPLayclick()
    {
        SoundManager.instance.PlayButtonSOund();
        SceneManager.LoadScene("levelselection");
    }
   void setingdialogue()
    {
        music.sprite = onoff[prefmanager.instance.Getmusicsvalue()];
        sound.sprite = onoff[prefmanager.instance.Getsoundsvalue()]; 
        vibration.sprite = onoff[prefmanager.instance.Getvibrationsvalue()];
    }




    public void onmusicclick()
    {
        if (prefmanager.instance.Getmusicsvalue() == 1)
        {
            prefmanager.instance.Setmusicsvalue(0);
            music.sprite = onoff[prefmanager.instance.Getmusicsvalue()];
        }
        else
        {
            prefmanager.instance.Setmusicsvalue(1);
            music.sprite = onoff[prefmanager.instance.Getmusicsvalue()];
        }
        SoundManager.instance.SetMusicSource();
    }

    public void onsoundclick()
    {
        if (prefmanager.instance.Getsoundsvalue() == 1)
        {
            prefmanager.instance.Setsoundsvalue(0);          
        }
        else
        {
            prefmanager.instance.Setsoundsvalue(1);           
        }
        sound.sprite = onoff[prefmanager.instance.Getsoundsvalue()];
        SoundManager.instance.SetSoundSource();
    }

    public void onvibrationclick()
    {
        if (prefmanager.instance.Getvibrationsvalue() == 1)
        {
            prefmanager.instance.Setvibrationvalue(0);
            vibration.sprite = onoff[prefmanager.instance.Getvibrationsvalue()];
        }
        else
        {
            prefmanager.instance.Setvibrationvalue(1);
            vibration.sprite = onoff[prefmanager.instance.Getvibrationsvalue()];
        }
    }



    public void OnPrivacyclick()
    {
        Application.OpenURL(privacypolicy);
    }
    public void RateUS()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
    }

   



}
