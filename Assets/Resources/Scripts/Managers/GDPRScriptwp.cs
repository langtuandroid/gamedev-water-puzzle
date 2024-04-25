using UnityEngine;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class GDPRScriptwp : MonoBehaviour
    {
        public GameObject GDPRwp;
   
        void Start()
        {
            GDPRwp.SetActive(PlayerPrefs.GetInt("GDPR", 0) == 0);
        }
    
        public void OnAcceptclickwp()
        {
            PlayerPrefs.SetInt("GDPR", 1);
            PlayerPrefs.SetInt("NPAValue", 1);
            GDPRwp.gameObject.SetActive(false);
        }
        public void OnRejectclickwp()
        {
            PlayerPrefs.SetInt("GDPR", 1);
            PlayerPrefs.SetInt("NPAValue", 0);
            GDPRwp.gameObject.SetActive(false);
        }
        
    }
}
