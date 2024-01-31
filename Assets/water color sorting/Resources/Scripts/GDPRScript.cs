using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDPRScript : MonoBehaviour
{
    public GameObject GDPR;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("GDPR", 0) == 0)
        {
            GDPR.SetActive(true);
        }
        else
        {
            GDPR.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnAcceptclick()
    {
        PlayerPrefs.SetInt("GDPR", 1);
        PlayerPrefs.SetInt("NPAValue", 1);
        GDPR.gameObject.SetActive(false);
    }
    public void OnRejectclick()
    {
        PlayerPrefs.SetInt("GDPR", 1);
        PlayerPrefs.SetInt("NPAValue", 0);
        GDPR.gameObject.SetActive(false);
    }
    public void OnPrivacyClick()
    {
        string privacy = GameObject.FindObjectOfType<MainMenuManager>().privacypolicy;
        Application.OpenURL(privacy);
    }




}
