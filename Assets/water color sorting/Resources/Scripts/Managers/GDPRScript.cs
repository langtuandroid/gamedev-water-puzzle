using UnityEngine;
using water_color_sorting.Resources.Scripts;

public class GDPRScript : MonoBehaviour
{
    public GameObject GDPR;
   
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
        //string privacy = FindObjectOfType<MainMenuManager>().PrivacyPolicywp;
        //Application.OpenURL(privacy);
    }

}
