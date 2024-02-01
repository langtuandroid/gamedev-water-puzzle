using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Managers;
using water_color_sorting.Resources.Scripts.UI;

namespace water_color_sorting.Resources.Scripts.Levels
{
    public class LevelSelectionwp : MonoBehaviour
    {
        [FormerlySerializedAs("unlockalllevel")] public bool unlockalllevelwp;
        [FormerlySerializedAs("TotalLevelsbuttons")] public int TotalLevelsbuttonswp;
        [FormerlySerializedAs("selectedsprite")] public Sprite selectedspritewp;
    
        //Scroller Position AdjustMent
        [FormerlySerializedAs("MyScrollRect")] public ScrollRect MyScrollRectwp;
        [FormerlySerializedAs("MyScrollContent")] public RectTransform MyScrollContentwp;
        [FormerlySerializedAs("currentbutton")] public GameObject currentbuttonwp;
    
        [FormerlySerializedAs("SpawnArea")] public GameObject SpawnAreawp;
        [FormerlySerializedAs("levelbuttonprefab")] public GameObject levelbuttonprefabwp;

        [FormerlySerializedAs("gameplaybg")] public Sprite[] gameplaybgwp;
        [FormerlySerializedAs("background")] public Image backgroundwp;
    
        private int levelvaluewp;
        
         private void Start()
        {
            //  PlayerPrefs.DeleteAll();
            backgroundwp.sprite = gameplaybgwp[PlayerPrefs.GetInt("backgroundvalue", 0)];
            levelvaluewp = SaveDataManagerwp.instancewp.Getlevelsvaluewp();
            if (unlockalllevelwp == true)
            {
                levelvaluewp = TotalLevelsbuttonswp;
            }
            //  print(levelvalue);
            PlaceLevelbuttonswp();
        }
         
        private void PlaceLevelbuttonswp()
        {
            for(int i=1; i<= TotalLevelsbuttonswp; i++)
            {
                GameObject button= Instantiate(levelbuttonprefabwp, SpawnAreawp.transform);
                button.GetComponent<OnButtonClick>().buttonLevelNumber = i;
                button.transform.GetChild(0).gameObject.GetComponent<Text>().text = i.ToString();
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
