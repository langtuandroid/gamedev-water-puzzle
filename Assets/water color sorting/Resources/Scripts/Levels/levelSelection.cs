using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using water_color_sorting.Resources.Scripts;
using water_color_sorting.Resources.Scripts.Managers;
using water_color_sorting.Resources.Scripts.UI;

public class levelSelection : MonoBehaviour
{
   public bool unlockalllevel;
    public int TotalLevelsbuttons;
    public Sprite selectedsprite;


    //Scroller Position AdjustMent
    public ScrollRect MyScrollRect;
    public RectTransform MyScrollContent;
    public GameObject currentbutton;


    public GameObject SpawnArea;
    public GameObject levelbuttonprefab;

    public Sprite[] gameplaybg;
    public Image background;




    private int levelvalue;


    

    // Start is called before the first frame update
    void Start()
    {
        //  PlayerPrefs.DeleteAll();
        background.sprite = gameplaybg[PlayerPrefs.GetInt("backgroundvalue", 0)];
        levelvalue = SaveDataManagerwp.instance.Getlevelsvalue();
        if (unlockalllevel == true)
        {
            levelvalue = TotalLevelsbuttons;
        }
        //  print(levelvalue);
        placeLevelbuttons();
        


    }

    
   
    void placeLevelbuttons()
    {
        for(int i=1; i<= TotalLevelsbuttons; i++)
        {

           GameObject button= Instantiate(levelbuttonprefab, SpawnArea.transform);
            button.GetComponent<OnButtonClick>().buttonLevelNumber = i;
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = i.ToString();
            if(i<= levelvalue)
            {
                button.transform.GetChild(1).gameObject.SetActive(false);
                if (i == levelvalue)
                {
                    button.gameObject.GetComponent<Image>().sprite = selectedsprite;
                    currentbutton = button;
                }
            }
        }

        Invoke("SnapTo", 0.2f);

    }


    public void SnapTo()
    {
        Canvas.ForceUpdateCanvases();

        MyScrollContent.anchoredPosition =
        (Vector2)MyScrollRect.transform.InverseTransformPoint(MyScrollContent.position)
        - (Vector2)MyScrollRect.transform.InverseTransformPoint(currentbutton.transform.position);

        MyScrollContent.anchoredPosition = new Vector2(0, MyScrollContent.anchoredPosition.y - 200f);
    }




    public void onbackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
