using UnityEngine;
using UnityEngine.UI;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class ShopManagerWP : MonoBehaviour
    {
        public GameObject[] shopspanelwp;
        public Sprite[] selectedUnselectedwp;
        [SerializeField]
        private Button _buttonBgwp;
        [SerializeField]
        private Button _buttonTubewp;

        private void Awake()
        {
            _buttonBgwp.onClick.AddListener(ShowBgPanelwp);
            _buttonTubewp.onClick.AddListener(ShowTubePanelwp);
        }

        private void OnDestroy()
        {
            _buttonBgwp.onClick.RemoveListener(ShowBgPanelwp);
            _buttonTubewp.onClick.RemoveListener(ShowTubePanelwp);
        }

        private void ShowBgPanelwp()
        {
            _buttonBgwp.GetComponent<Image>().sprite = selectedUnselectedwp[0];
            _buttonTubewp.GetComponent<Image>().sprite = selectedUnselectedwp[3];
            ShowShopwp(0);
        }
        private void ShowTubePanelwp()
        {
            _buttonBgwp.GetComponent<Image>().sprite = selectedUnselectedwp[1];
            _buttonTubewp.GetComponent<Image>().sprite = selectedUnselectedwp[2];
            ShowShopwp(1);
        }
       
        public void ShowShopwp(int value)
        {
            SoundManagerWP.instance.PlayButtonSoundwp();
            HideShopwp();
            shopspanelwp[value].gameObject.SetActive(true);
        }

        private void HideShopwp()
        {
            for (int i = 0; i < shopspanelwp.Length; i++)
            {
                shopspanelwp[i].gameObject.SetActive(false);
            }
        }
    }
}
