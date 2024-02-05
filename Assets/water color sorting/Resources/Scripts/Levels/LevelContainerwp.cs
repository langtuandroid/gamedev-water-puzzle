using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Gameplay;
using water_color_sorting.Resources.Scripts.Managers;

namespace water_color_sorting.Resources.Scripts.Levels
{
    public class LevelContainerwp : MonoBehaviour
    {
        public static LevelContainerwp instance = null;
        public LevelsEditor leveldatawp;
        public BottleEditor Bottledatawp;

        [Header("Adding Empty Bottles")]
        public GameObject EmptyBottlewp;

        [Header("For Positioning Bottles")]
        public GameObject[] Gridswp;
        public LineRenderer LineRendererwp;

        [Header("Total And Filled Bottles Amount")]
        public int TotalFillingBottleswp;
        public int CurrentfilledBottleswp;

        int levelvalue,bottlevalue;
        
        [Header("For Handling Value Where We have to Spawn Bottle")]
        int gridvaluewp = 0;
        int numberofbottlestoSpawnInFirstGridwp, numberofbottlestoSpawnInSecondGridwp;
        bool SpawnInMultipleGridswp;
        int bottleassigningvaluewp=0;
        int TotalBottleswp;

        [Header("Hint Values")]
        public List<GameObject> bottlesinusewp = new List<GameObject>();
        public GameObject Firstbottlewp;
        public GameObject SecondBottlewp;
        int firstbottlevalueValuewp;

   
        private void Start()
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
            CreateLevelwp();
        }
    

        private void CreateLevelwp()
        {
            TotalFillingBottleswp = leveldatawp.Levels[levelvalue-1].FillingBottles;
            TotalBottleswp = leveldatawp.Levels[levelvalue-1].TotalNumberofBottles.Length;
            SpawnBottleswp();
        }



        //Spawning Starting Level Bottles
        private void SpawnBottleswp()
        {
            //print(levelvalue);
            if (leveldatawp.Levels[levelvalue-1].TotalNumberofBottles.Length > 4)
            {
                SpawnInMultipleGridswp = true;
                numberofbottlestoSpawnInFirstGridwp = TotalBottleswp - TotalBottleswp / 2;
                numberofbottlestoSpawnInSecondGridwp = TotalBottleswp / 2;
            }
            else
            {
                SpawnInMultipleGridswp = false;
                numberofbottlestoSpawnInFirstGridwp = TotalBottleswp;
            }

            DuplicateSelectedBottleswp();


        }

        private void DuplicateSelectedBottleswp()
        {
            GameObject bottle;
            for(int i=0;i< numberofbottlestoSpawnInFirstGridwp; i++)
            {
                bottle= Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[0].gameObject.transform.GetChild(i).transform);
                Assignbottlepropertieswp(bottle);
                bottleassigningvaluewp++;


            }
            if (SpawnInMultipleGridswp == true)
            {
                for (int i = 0; i < numberofbottlestoSpawnInSecondGridwp; i++)
                {
                    bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[1].gameObject.transform.GetChild(i).transform);
                    Assignbottlepropertieswp(bottle);
                    bottleassigningvaluewp++;
                }
            }

        }


        //Adding a Cube after Watching the Ad
        public void Addcubewp()
        {
            
            GameObject bottle;
            if (TotalBottleswp % 2 == 0)
            {
                int gridindex = TotalBottleswp - TotalBottleswp / 2;
                gridvaluewp++;
                if (gridindex < 8)
                {
                    print("gridvaluewp = " + gridvaluewp);
                    print(gridindex);
               
                    bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[0].gameObject.transform.GetChild(gridindex).transform);
                    bottle.transform.position = bottle.transform.parent.position;
                    TotalBottleswp++;
                    bottleassigningvaluewp++;
                    bottle.gameObject.transform.parent.gameObject.SetActive(true);
                    bottle.GetComponent<BottleControllerwp>().waterdroplinewp = LineRendererwp;
                }

            }
            else
            {
                int gridindex = TotalBottleswp / 2;
                gridvaluewp++;
                if (gridindex < 8)
                {
                    print("gridvaluewp22 = " + gridvaluewp);
                    print(gridindex);
                    bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[1].gameObject.transform.GetChild(gridindex).transform);
                    bottle.transform.position = bottle.transform.parent.position;
                    TotalBottleswp++;
                    bottleassigningvaluewp++;
                    bottle.gameObject.transform.parent.gameObject.SetActive(true);
                    bottle.GetComponent<BottleControllerwp>().waterdroplinewp = LineRendererwp;
                }
            }

            //  print("Total Assigning Value"+bottleassigningvalue);
            if (bottleassigningvaluewp > 12)
            {
                Gridswp[0].gameObject.GetComponent<GridLayoutGroup>().spacing = new Vector2(5f, 0f);
                Gridswp[1].gameObject.GetComponent<GridLayoutGroup>().spacing = new Vector2(5f, 0f);
            }


            Invoke("UpdateAllBottlesPositionswp", 0.1f);

            // assignbottleproperties(bottle);
            //  bottleassigningvalue++;
            
        }

        //Update All Bottles Orginal Position After Adding One more bottle
        private void UpdateAllBottlesPositionswp()
        {
            // GameObject[] Gridbottles;
            for(int i = 0; i < 2; i++)
            {
                int j = 0;
                //print("Grid Value" + Gridswp[i].transform.childCount);
                for (j = 0; j < Gridswp[i].transform.childCount; j++)
                {
                    // print("value of i" + i + " value of j" + j);
                    if (Gridswp[i].gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                    {
                        Gridswp[i].gameObject.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject.GetComponent<BottleControllerwp>().SetOrginalPositionwp();
                    }
                }
            }
        }


        //Hint for User Moving Bottle OwnHisOwn

        public void OnHintClickwp()
        {
            Firstbottlewp = null;
            SecondBottlewp = null;
            int indexvalue=0;
            bottlesinusewp.Clear();
            
            //  List<GameObject> bottlesinuse = new List<GameObject>();
            for (int i = 0; i < 2; i++)
            {
                int j = 0;
                //print("Grid Value" + Gridswp[i].transform.childCount);
                for (j = 0; j < Gridswp[i].transform.childCount; j++)
                {
                    //   print("value of i" + i + " value of j" + j);
                    if (Gridswp[i].gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                    {
                        bottlesinusewp.Add(Gridswp[i].gameObject.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject);
                    }
                }
            }
            bool moveavailable= pickbottletoswapwp();
            if (moveavailable == true)
            {
                Firstbottlewp.gameObject.GetComponent<BottleControllerwp>().otherbottlecontrollerrefwp = SecondBottlewp.gameObject.GetComponent<BottleControllerwp>();
                Firstbottlewp.gameObject.GetComponent<BottleControllerwp>().StartColorTransferwp();
            }
        }

        
        bool pickbottletoswapwp()
        {
            firstbottlevalueValuewp = 0;
      
            pickfirstbottlewp();

            //Return value if move avaible

            if (Firstbottlewp != null && SecondBottlewp != null)
            
                return true;
            else

                return false;
        }

        void pickfirstbottlewp()
        {
            for (int i = firstbottlevalueValuewp; i < bottlesinusewp.Count; i++)
            {
                if (bottlesinusewp[i].gameObject.GetComponent<BottleControllerwp>().filledwp != true && bottlesinusewp[i].gameObject.GetComponent<BottleControllerwp>().numberofcolorsinbottlewp > 0 && Firstbottlewp == null)
                {
                    //print("first bottle Selected And Value Is" + firstbottlevalueValuewp);
                    Firstbottlewp = bottlesinusewp[i];
                    break;
                }
                else
                {
                    firstbottlevalueValuewp++;
                }
            }
            picksecondbottlewp();
        }
        void picksecondbottlewp()
        {
            for (int i = 0; i < bottlesinusewp.Count; i++)
            {
                if (i == firstbottlevalueValuewp)
                {
                   // print("skip that bottle");
                }
                else if (bottlesinusewp[i].gameObject.GetComponent<BottleControllerwp>().filledwp != true)
                {

                    if (bottlesinusewp[i].gameObject.GetComponent<BottleControllerwp>().numberofcolorsinbottlewp > 0 && bottlesinusewp[i].gameObject.GetComponent<BottleControllerwp>().numberofcolorsinbottlewp < 4)
                    {
                        if (Firstbottlewp.GetComponent<BottleControllerwp>().TopColorwp.Equals(bottlesinusewp[i].gameObject.GetComponent<BottleControllerwp>().TopColorwp))
                        {

                            //print("Second Bottle Called");
                            SecondBottlewp = bottlesinusewp[i];
                            break;

                        }
                    }
                    else if (bottlesinusewp[i].gameObject.GetComponent<BottleControllerwp>().numberofcolorsinbottlewp == 0)
                    {
                        SecondBottlewp = bottlesinusewp[i];
                        break;
                    
                    }
                
                }
            }

            if (SecondBottlewp == null)
            {
           
                if (firstbottlevalueValuewp < bottlesinusewp.Count)
                {
                    Firstbottlewp = null;
                    SecondBottlewp = null;
                    firstbottlevalueValuewp++;
                    //print("Change First Bottle"+ firstbottlevalueValuewp);
                    pickfirstbottlewp();
                
                }
                else
                {
                    Firstbottlewp = null;
                    //print("Not found");
                }
            }

        }
        

        void Assignbottlepropertieswp(GameObject bottle)
        {
            bottle.transform.position = bottle.transform.parent.transform.position;
            bottle.GetComponent<BottleControllerwp>().waterdroplinewp = LineRendererwp;
            bottle.GetComponent<BottleControllerwp>().numberofcolorsinbottlewp = leveldatawp.Levels[levelvalue-1].TotalNumberofBottles[bottleassigningvaluewp].ColorsInBottle.Length;
            for (int i=0;i< leveldatawp.Levels[levelvalue-1].TotalNumberofBottles[bottleassigningvaluewp].ColorsInBottle.Length; i++)
            {
                bottle.GetComponent<BottleControllerwp>().bottlecolorswp[i] = leveldatawp.Levels[levelvalue-1].TotalNumberofBottles[bottleassigningvaluewp].ColorsInBottle[i];
            }

            bottle.transform.parent.gameObject.SetActive(true);

        }
        

        public void FillBottleAndCheckLevelCompletewp()
        {
            CurrentfilledBottleswp++;
            if (CurrentfilledBottleswp == TotalFillingBottleswp)
            {
                SoundManagerWP.instance.PlaylevelcompeleteSoundwp();

                SoundManagerWP.instance.SetVibarationState();
                
                GameManager.instance.MakeLevelCompletewp();
            }
        }
        
    }
}
