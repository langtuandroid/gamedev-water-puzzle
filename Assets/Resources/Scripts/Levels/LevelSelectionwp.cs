using Integration;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Managers;
using water_color_sorting.Resources.Scripts.UI;
using Zenject;

namespace water_color_sorting.Resources.Scripts.Levels
{
    public class LevelSelectionwp : MonoBehaviour
    {
        public bool unlockalllevelwp;
        public int TotalLevelsbuttonswp;
        public Sprite selectedspritewp;
    
        //Scroller Position AdjustMent
        public ScrollRect MyScrollRectwp;
        public RectTransform MyScrollContentwp;
        public GameObject currentbuttonwp;
    
        public GameObject SpawnAreawp;
        public GameObject levelbuttonprefabwp;

        public Sprite[] gameplaybgwp;
        public Sprite[] gameplayTabletbgwp;
        public Image backgroundwp;
    
        private int levelvaluewp;

        private AdMobController _adMobController;
        
        [Inject]
        private void Construct(AdMobController adMobController)
        {
            _adMobController = adMobController;
        }
        
        private void Start()
        {
              PlayerPrefs.DeleteAll();
          
            if (DeviceTypeChecker.CheckDeviceType() is DeviceType.Smartphone)
            {
                backgroundwp.sprite = gameplaybgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            }
            else
            {
                backgroundwp.sprite = gameplayTabletbgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            }
            levelvaluewp = SaveDataManagerwp.instancewp.Getlevelsvaluewp();
            if (unlockalllevelwp == true)
            {
                levelvaluewp = TotalLevelsbuttonswp;
            }
            _adMobController.ShowBanner(true);
            PlaceLevelbuttonswp();
        }
         
        private void PlaceLevelbuttonswp()
        {
            for(int i=1; i<= TotalLevelsbuttonswp; i++)
            {
                GameObject button= Instantiate(levelbuttonprefabwp, SpawnAreawp.transform);
                button.GetComponent<OnButtonClick>().buttonLevelNumber = i;
                button.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = i.ToString();
                if(i<= levelvaluewp)
                {
                    button.transform.GetChild(1).gameObject.SetActive(false);
                    if (i == levelvaluewp)
                    {
                        button.gameObject.GetComponent<Image>().sprite = selectedspritewp;
                        currentbuttonwp = button;
                    }
                }
            }

            Invoke("SnapTowp", 0.2f);
        }


        public void SnapTowp()
        {
            Canvas.ForceUpdateCanvases();

            MyScrollContentwp.anchoredPosition =
                (Vector2)MyScrollRectwp.transform.InverseTransformPoint(MyScrollContentwp.position)
                - (Vector2)MyScrollRectwp.transform.InverseTransformPoint(currentbuttonwp.transform.position);

            MyScrollContentwp.anchoredPosition = new Vector2(0, MyScrollContentwp.anchoredPosition.y - 200f);
        }
        

        public void BackClickwp()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
