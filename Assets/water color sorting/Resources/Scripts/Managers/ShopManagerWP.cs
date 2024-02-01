using UnityEngine;
using UnityEngine.UI;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class ShopManagerWP : MonoBehaviour
    {
        public GameObject[] shopspanelwp;
        public GameObject[] Shoppanelclickbuttonswp;
        public Sprite[] selectedUnselectedwp;

        private void SelectBgwp()
        {
            SoundManagerWP.instance.PlayButtonSoundwp();
            shopspanelwp[0].gameObject.SetActive(true);
            Shoppanelclickbuttonswp[0].GetComponent<Image>().sprite = selectedUnselectedwp[1];
        }
        
        public void ShowShopwp(int value)
        {
            SoundManagerWP.instance.PlayButtonSoundwp();
            HideShopwp();
            shopspanelwp[value].gameObject.SetActive(true);
            Shoppanelclickbuttonswp[value].GetComponent<Image>().sprite = selectedUnselectedwp[1];
        }

        private void HideShopwp()
        {
            for (int i = 0; i < shopspanelwp.Length; i++)
            {
                shopspanelwp[i].gameObject.SetActive(false);          
                Shoppanelclickbuttonswp[i].GetComponent<Image>().sprite = selectedUnselectedwp[0];
            }
        }
    }
}
