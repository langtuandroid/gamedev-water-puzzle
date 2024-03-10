using UnityEngine;
using UnityEngine.UI;


namespace water_color_sorting.Resources.Scripts.UI
{
    public class MenuPanelsManager : MonoBehaviour
    {
        private const string  BlurIntensityPropertyName = "Vector1_1844C1E0";
        
        [SerializeField]
        private GameObject _mainMenuPanel;
        [SerializeField]
        private GameObject _shopPanel;
        [SerializeField]
        private Button _showShopPanel;
        [SerializeField]
        private Button _hideShopPanel;
        [SerializeField]
        private GameObject _optionPanel;
        [SerializeField]
        private Button _showOptionPanel;
        [SerializeField]
        private Button _hideOptionPanel;

        [SerializeField]
        private Material _uiBgElements;
        [SerializeField]
        private Material _uiIconElements;

        private void Awake()
        {
            _showOptionPanel.onClick.AddListener(ShowOption);
            _hideOptionPanel.onClick.AddListener(HideOption);
            _showShopPanel.onClick.AddListener(ShowShop);
            _hideShopPanel.onClick.AddListener(HideShop);
        }

        private void OnDestroy()
        {
            _showOptionPanel.onClick.RemoveListener(ShowOption);
            _hideOptionPanel.onClick.RemoveListener(HideOption);
            _showShopPanel.onClick.RemoveListener(ShowShop);
            _hideShopPanel.onClick.RemoveListener(HideShop);
        }

        private void ShowOption()
        {
            _optionPanel.SetActive(true);
            _uiBgElements.SetFloat(BlurIntensityPropertyName, 0.5f);
            _uiIconElements.SetFloat(BlurIntensityPropertyName, 1.4f);
            
        }
        
        private void HideOption()
        {
            _optionPanel.SetActive(false);
            _uiBgElements.SetFloat(BlurIntensityPropertyName, 0f);
            _uiIconElements.SetFloat(BlurIntensityPropertyName, 0f);
        }
        
        private void ShowShop()
        {
            _shopPanel.SetActive(true);
            _mainMenuPanel.SetActive(false);
        }
        
        private void HideShop()
        {
            _shopPanel.SetActive(false);
            _mainMenuPanel.SetActive(true);
        }
    }
}
