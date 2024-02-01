using UnityEngine;
using UnityEngine.UI;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class ShopManagerWP : MonoBehaviour
    {
        public GameObject[] shopspanel;
        public GameObject[] Shoppanelclickbuttons;
        public Sprite[] selectedUnselected;

        private void SelectBgwp()
        {
            SoundManagerWP.instance.PlayButtonSoundwp();
            shopspanel[0].gameObject.SetActive(true);
            Shoppanelclickbuttons[0].GetComponent<Image>().sprite = selectedUnselected[1];
        }
        
        public void ShowShopwp(int value)
        {
            SoundManagerWP.instance.PlayButtonSoundwp();
            HideShopwp();
            shopspanel[value].gameObject.SetActive(true);
            Shoppanelclickbuttons[value].GetComponent<Image>().sprite = selectedUnselected[1];
        }

        private void HideShopwp()
        {
            for (int i = 0; i < shopspanel.Length; i++)
            {
                shopspanel[i].gameObject.SetActive(false);          
                Shoppanelclickbuttons[i].GetComponent<Image>().sprite = selectedUnselected[0];
            }
        }
    }
}
