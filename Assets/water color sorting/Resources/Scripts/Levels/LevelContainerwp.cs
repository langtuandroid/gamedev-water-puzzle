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

        private int numberofbottlestoSpawnInFirstGridwp;
        private int numberofbottlestoSpawnInSecondGridwp;
        private int numberofbottlestoSpawnInThirdGridwp;
        bool SpawnInMultipleGridswp;
        int bottleassigningvaluewp=0;
        int TotalBottleswp;

        [Header("Hint Values")]
        public List<GameObject> bottlesinusewp = new List<GameObject>();
        public GameObject Firstbottlewp;
        public GameObject SecondBottlewp;
        int firstbottlevalueValuewp;
        private Canvas _canvasBottles;
   
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

            _canvasBottles = gameObject.GetComponent<Canvas>();
            levelvalue = SaveDataManagerwp.instancewp.GetPresentLevel();
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

        private void SpawnBottleswp()
        {
            int totalBottles = leveldatawp.Levels[levelvalue - 1].TotalNumberofBottles.Length;

            if (totalBottles < 4)
            {
                // Если бутылок меньше 4, все распределяются в первом ряду
                numberofbottlestoSpawnInFirstGridwp = totalBottles;
                SpawnInFirstLine();
            }
            else if (totalBottles < 12)
            {
                // Если бутылок от 4 до 11, они распределяются между первым и вторым рядами
                int bottlesPerRow = totalBottles / 2;
                numberofbottlestoSpawnInFirstGridwp = bottlesPerRow;
                numberofbottlestoSpawnInSecondGridwp = totalBottles - bottlesPerRow;
                SpawnInFirstAndSecondLine();
            }
            else
            {
                // Если бутылок 12 или больше, они распределяются между всеми тремя рядами
                int bottlesPerRow = totalBottles / 3;
                int extraBottles = totalBottles % 3;

                numberofbottlestoSpawnInFirstGridwp = bottlesPerRow + (extraBottles >= 1 ? 1 : 0);
                numberofbottlestoSpawnInSecondGridwp = bottlesPerRow + (extraBottles >= 2 ? 1 : 0);
                numberofbottlestoSpawnInThirdGridwp = bottlesPerRow;

                SpawnInFirstSecondAndThirdLine();
            }
        }
        
        private void SpawnInFirstLine()
        {
            GameObject bottle;
            int rowIndex = 0;
            for(int i = 0; i < numberofbottlestoSpawnInFirstGridwp; i++)
            {
                bottle= Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[rowIndex].gameObject.transform.GetChild(i).transform);
                Assignbottlepropertieswp(bottle);
                bottleassigningvaluewp++;
                bottle.gameObject.transform.parent.gameObject.SetActive(true);
        
                // Если достигнут предел бутылок в ряду, переходим на следующий ряд
                if (i == Gridswp[rowIndex].transform.childCount - 1)
                {
                    rowIndex++;
                    // Проверяем, чтобы не выйти за пределы массива Gridswp
                    if (rowIndex >= Gridswp.Length)
                        break;
                }
            }
            UpdateAllBottlesPositionswp();
        }
        
        private void SpawnInFirstAndSecondLine()
        {
            GameObject bottle;
            int rowIndex = 0;
            for (int i = 0; i < numberofbottlestoSpawnInFirstGridwp; i++)
            {
                bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[rowIndex].gameObject.transform.GetChild(i).transform);
                Assignbottlepropertieswp(bottle);
                bottleassigningvaluewp++;
                bottle.gameObject.transform.parent.gameObject.SetActive(true);
        
                if (i == Gridswp[rowIndex].transform.childCount - 1)
                {
                    rowIndex++;
                    if (rowIndex >= Gridswp.Length)
                        break;
                }
            }
        
            rowIndex = 1;
            for (int i = 0; i < numberofbottlestoSpawnInSecondGridwp; i++)
            {
                bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[rowIndex].gameObject.transform.GetChild(i).transform);
                Assignbottlepropertieswp(bottle);
                bottleassigningvaluewp++;
                bottle.gameObject.transform.parent.gameObject.SetActive(true);
        
                if (i == Gridswp[rowIndex].transform.childCount - 1)
                {
                    rowIndex++;
                    if (rowIndex >= Gridswp.Length)
                        break;
                }
            }
        
            UpdateAllBottlesPositionswp();
        }

        private void SpawnInFirstSecondAndThirdLine()
        {
            GameObject bottle;
            int rowIndex = 0;
            for (int i = 0; i < numberofbottlestoSpawnInFirstGridwp; i++)
            {
                bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[rowIndex].gameObject.transform.GetChild(i).transform);
                Assignbottlepropertieswp(bottle);
                bottleassigningvaluewp++;
                bottle.gameObject.transform.parent.gameObject.SetActive(true);
        
                if (i == Gridswp[rowIndex].transform.childCount - 1)
                {
                    rowIndex++;
                    if (rowIndex >= Gridswp.Length)
                        break;
                }
            }
        
            rowIndex = 1;
            for (int i = 0; i < numberofbottlestoSpawnInSecondGridwp; i++)
            {
                bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[rowIndex].gameObject.transform.GetChild(i).transform);
                Assignbottlepropertieswp(bottle);
                bottleassigningvaluewp++;
                bottle.gameObject.transform.parent.gameObject.SetActive(true);
        
                if (i == Gridswp[rowIndex].transform.childCount - 1)
                {
                    rowIndex++;
                    if (rowIndex >= Gridswp.Length)
                        break;
                }
            }
        
            rowIndex = 2;
            for (int i = 0; i < numberofbottlestoSpawnInThirdGridwp; i++)
            {
                bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[rowIndex].gameObject.transform.GetChild(i).transform);
                Assignbottlepropertieswp(bottle);
                bottleassigningvaluewp++;
                bottle.gameObject.transform.parent.gameObject.SetActive(true);
        
                if (i == Gridswp[rowIndex].transform.childCount - 1)
                {
                    rowIndex++;
                    if (rowIndex >= Gridswp.Length)
                        break;
                }
            }
        
            UpdateAllBottlesPositionswp();
        }


        private void DuplicateSelectedBottleswp()
        {
            GameObject bottle;
            for(int i = 0; i < numberofbottlestoSpawnInFirstGridwp; i++)
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
            Invoke("UpdateAllBottlesPositionswp", 0.1f);

        }


        //Adding a Cube after Watching the Ad
        public void Addcubewp()
        {
            GameObject bottle = null;
            
                // Проходимся по каждому ряду
                for (int i = 0; i < Gridswp.Length; i++)
                {
                    // Если в текущем ряду есть свободные слоты, добавляем бутылку в этот ряд
                    if (GridHasEmptySlot(Gridswp[i].gameObject.transform))
                    {
                        // Находим индекс первого свободного слота в ряду
                        int gridIndex = FindFirstEmptySlotIndex(Gridswp[i].gameObject.transform);

                        // Создаем бутылку и устанавливаем ее в свободный слот
                        bottle = Instantiate(Bottledatawp.Bottles[bottlevalue], Gridswp[i].gameObject.transform.GetChild(gridIndex).transform);
                        bottle.transform.position = bottle.transform.parent.position;
                        bottleassigningvaluewp++;
                        bottle.gameObject.transform.parent.gameObject.SetActive(true);
                        bottle.GetComponent<BottleControllerwp>().waterdroplinewp = LineRendererwp;

                        // Увеличиваем счетчик общего количества бутылок
                        TotalBottleswp++;

                        // Выходим из цикла, так как уже добавили бутылку
                        break;
                    }
                }
                Invoke("UpdateAllBottlesPositionswp", 0.1f);
            
        }

        // Метод для проверки наличия свободных слотов в ряду
        private bool GridHasEmptySlot(Transform grid)
        {
            for (int i = 0; i < grid.childCount; i++)
            {
                if (grid.GetChild(i).childCount == 0) // Если слот пустой
                {
                    return true;
                }
            }
            return false;
        }

        // Метод для поиска индекса первого свободного слота в ряду
        private int FindFirstEmptySlotIndex(Transform grid)
        {
            for (int i = 0; i < grid.childCount; i++)
            {
                if (grid.GetChild(i).childCount == 0) // Если слот пустой
                {
                    return i;
                }
            }
            return -1; // Возвращаем -1, если свободных слотов не найдено (на всякий случай)
        }
        
        private void UpdateAllBottlesPositionswp()
        {
            // GameObject[] Gridbottles;
            for(int i = 0; i < 3; i++)
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
            Canvas.ForceUpdateCanvases();
            _canvasBottles.gameObject.SetActive(false);
            _canvasBottles.gameObject.SetActive(true);
        }


        //Hint for User Moving Bottle OwnHisOwn

        public void OnHintClickwp()
        {
            Firstbottlewp = null;
            SecondBottlewp = null;
            int indexvalue=0;
            bottlesinusewp.Clear();
            
            //  List<GameObject> bottlesinuse = new List<GameObject>();
            for (int i = 0; i < 3; i++)
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
