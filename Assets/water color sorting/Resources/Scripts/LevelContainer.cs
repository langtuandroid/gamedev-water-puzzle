using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Managers;

public class LevelContainer : MonoBehaviour
{
    public static LevelContainer instance = null;
    public levelseditor leveldata;
    public BottleEditor Bottledata;

    [Header("Adding Empty Bottles")]
    public GameObject EmptyBottle;

    [Header("For Positioning Bottles")]
    public GameObject[] Grids;
    public LineRenderer LineRenderer;

    [Header("Total And Filled Bottles Amount")]
    public int TotalFillingBottles;
    public int CurrentfilledBottles;

    int levelvalue,bottlevalue;
    [Header("For Handling Value Where We have to Spawn Bottle")]
    int gridvalue = 0;
    int numberofbottlestoSpawnInFirstGrid, numberofbottlestoSpawnInSecondGrid;
    bool SpawnInMultipleGrids;
    int bottleassigningvalue=0;
    int TotalBottles;

    [Header("Hint Values")]
    public List<GameObject> bottlesinuse = new List<GameObject>();
    public GameObject Firstbottle;
    public GameObject SecondBottle;
    int firstbottlevalueValue;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        levelvalue = PlayerPrefs.GetInt("levelvalue1", 1);
        bottlevalue = PlayerPrefs.GetInt("bottlevalue", 0);
        //for Creating Levels and spwaning Desired Bottles
        CreateLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //for Creating the Level

    void CreateLevel()
    {
        TotalFillingBottles = leveldata.Levels[levelvalue-1].FillingBottles;
        TotalBottles = leveldata.Levels[levelvalue-1].TotalNumberofBottles.Length;
        SpawnBottles();
    }



    //Spawning Starting Level Bottles
    void SpawnBottles()
    {
        print(levelvalue);
        if (leveldata.Levels[levelvalue-1].TotalNumberofBottles.Length > 4)
        {
            SpawnInMultipleGrids = true;
            numberofbottlestoSpawnInFirstGrid = TotalBottles - TotalBottles / 2;
            numberofbottlestoSpawnInSecondGrid = TotalBottles / 2;
        }
        else
        {
            SpawnInMultipleGrids = false;
            numberofbottlestoSpawnInFirstGrid = TotalBottles;
        }

        DuplicateSelectedBottles();


    }

    void DuplicateSelectedBottles()
    {
        GameObject bottle;
        for(int i=0;i< numberofbottlestoSpawnInFirstGrid; i++)
        {
            bottle= Instantiate(Bottledata.Bottles[bottlevalue], Grids[0].gameObject.transform.GetChild(i).transform);
            assignbottleproperties(bottle);
            bottleassigningvalue++;


        }
        if (SpawnInMultipleGrids == true)
        {
            for (int i = 0; i < numberofbottlestoSpawnInSecondGrid; i++)
            {
                bottle = Instantiate(Bottledata.Bottles[bottlevalue], Grids[1].gameObject.transform.GetChild(i).transform);
                assignbottleproperties(bottle);
                bottleassigningvalue++;
            }
        }

    }


    //Adding a Cube after Watching the Ad
    public void Addcube()
    {

     
            GameObject bottle;
            if (TotalBottles % 2 == 0)
            {
                int gridindex = TotalBottles - TotalBottles / 2;
                 gridvalue++;
                if (gridindex < 8)
                {
                    print(gridindex);
               
                    bottle = Instantiate(Bottledata.Bottles[bottlevalue], Grids[0].gameObject.transform.GetChild(gridindex).transform);
                    bottle.transform.position = bottle.transform.parent.position;
                    TotalBottles++;
                    bottleassigningvalue++;
                    bottle.gameObject.transform.parent.gameObject.SetActive(true);
                    bottle.GetComponent<Bottlecontroller>().waterdropline = LineRenderer;
                }

            }
            else
            {
                int gridindex = TotalBottles / 2;
                gridvalue++;
                if (gridindex < 8)
                {
                //print(gridindex);
                bottle = Instantiate(Bottledata.Bottles[bottlevalue], Grids[1].gameObject.transform.GetChild(gridindex).transform);
                bottle.transform.position = bottle.transform.parent.position;
                TotalBottles++;
                    bottleassigningvalue++;
                    bottle.gameObject.transform.parent.gameObject.SetActive(true);
                    bottle.GetComponent<Bottlecontroller>().waterdropline = LineRenderer;
                }
            }

      //  print("Total Assigning Value"+bottleassigningvalue);
        if (bottleassigningvalue > 12)
        {
            Grids[0].gameObject.GetComponent<GridLayoutGroup>().spacing = new Vector2(5f, 0f);
            Grids[1].gameObject.GetComponent<GridLayoutGroup>().spacing = new Vector2(5f, 0f);
        }


        Invoke("UpdateAllBottlesPositions", 0.1f);

            // assignbottleproperties(bottle);
            //  bottleassigningvalue++;


    }

    //Update All Bottles Orginal Position After Adding One more bottle
    void UpdateAllBottlesPositions()
    {
       // GameObject[] Gridbottles;
        for(int i = 0; i < 2; i++)
        {
            int j = 0;
            print("Grid Value" + Grids[i].transform.childCount);
            for (j = 0; j < Grids[i].transform.childCount; j++)
            {
               // print("value of i" + i + " value of j" + j);
                if (Grids[i].gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                {
                    Grids[i].gameObject.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject.GetComponent<Bottlecontroller>().SetOrginalPosition();
                }
            }
        }

    }


    //Hint for User Moving Bottle OwnHisOwn

   public void OnHintClick()
    {
        Firstbottle = null;
        SecondBottle = null;
        int indexvalue=0;
        bottlesinuse.Clear();


        //  List<GameObject> bottlesinuse = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            int j = 0;
            print("Grid Value" + Grids[i].transform.childCount);
            for (j = 0; j < Grids[i].transform.childCount; j++)
            {
             //   print("value of i" + i + " value of j" + j);
                if (Grids[i].gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                {
                    bottlesinuse.Add(Grids[i].gameObject.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject);
                }
            }
        }
        bool moveavailable= pickbottletoswap();
        if (moveavailable == true)
        {
            Firstbottle.gameObject.GetComponent<Bottlecontroller>().otherbottlecontrollerref = SecondBottle.gameObject.GetComponent<Bottlecontroller>();
            Firstbottle.gameObject.GetComponent<Bottlecontroller>().StartColorTransfer();
        }
    }

    
  

    bool pickbottletoswap()
    {
        firstbottlevalueValue = 0;
      
        pickfirstbottle();

        //Return value if move avaible

        if (Firstbottle != null && SecondBottle != null)
            
            return true;
        else

        return false;






    }

    void pickfirstbottle()
    {
        for (int i = firstbottlevalueValue; i < bottlesinuse.Count; i++)
        {
            if (bottlesinuse[i].gameObject.GetComponent<Bottlecontroller>().filled != true && bottlesinuse[i].gameObject.GetComponent<Bottlecontroller>().numberofcolorsinbottle > 0 && Firstbottle == null)
            {
                print("first bottle Selected And Value Is" + firstbottlevalueValue);
                Firstbottle = bottlesinuse[i];
                break;
            }
            else
            {
                firstbottlevalueValue++;
            }
        }
        picksecondbottle();
    }
    void picksecondbottle()
    {
        for (int i = 0; i < bottlesinuse.Count; i++)
        {
            if (i == firstbottlevalueValue)
            {
                print("skip that bottle");
            }
            else if (bottlesinuse[i].gameObject.GetComponent<Bottlecontroller>().filled != true)
            {

                if (bottlesinuse[i].gameObject.GetComponent<Bottlecontroller>().numberofcolorsinbottle > 0 && bottlesinuse[i].gameObject.GetComponent<Bottlecontroller>().numberofcolorsinbottle < 4)
                {
                    if (Firstbottle.GetComponent<Bottlecontroller>().TopColor.Equals(bottlesinuse[i].gameObject.GetComponent<Bottlecontroller>().TopColor))
                    {

                        print("Second Bottle Called");
                        SecondBottle = bottlesinuse[i];
                        break;

                    }
                }
                else if (bottlesinuse[i].gameObject.GetComponent<Bottlecontroller>().numberofcolorsinbottle == 0)
                {
                    SecondBottle = bottlesinuse[i];
                    break;
                    
                }
                
            }
        }

        if (SecondBottle == null)
        {
           
            if (firstbottlevalueValue < bottlesinuse.Count)
            {
                Firstbottle = null;
                SecondBottle = null;
                firstbottlevalueValue++;
                print("Change First Bottle"+ firstbottlevalueValue);
                pickfirstbottle();
                
            }
            else
            {
                Firstbottle = null;
                print("Not found");
            }
        }

        
        

    }








    void assignbottleproperties(GameObject bottle)
       {
        bottle.transform.position = bottle.transform.parent.transform.position;
        bottle.GetComponent<Bottlecontroller>().waterdropline = LineRenderer;
        bottle.GetComponent<Bottlecontroller>().numberofcolorsinbottle = leveldata.Levels[levelvalue-1].TotalNumberofBottles[bottleassigningvalue].ColorsInBottle.Length;
        for (int i=0;i< leveldata.Levels[levelvalue-1].TotalNumberofBottles[bottleassigningvalue].ColorsInBottle.Length; i++)
        {
            bottle.GetComponent<Bottlecontroller>().bottlecolors[i] = leveldata.Levels[levelvalue-1].TotalNumberofBottles[bottleassigningvalue].ColorsInBottle[i];
        }

        bottle.transform.parent.gameObject.SetActive(true);

    }









   public void FillBottleAndCheckLevelComplete()
    {
        CurrentfilledBottles++;
        if (CurrentfilledBottles == TotalFillingBottles)
        {
            SoundManager.instance.PlaylevelcompeleteSOund();

            SoundManager.instance.MakeVibaration();


            GameManager.instance.MakeLevelComplete();
        }
    }
         




}
