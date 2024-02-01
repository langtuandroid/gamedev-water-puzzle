using UnityEngine;
using water_color_sorting.Resources.Scripts.Gameplay;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;
        [SerializeField]
        private  BottleControllerwp firstbottlewp;
        [SerializeField]
        private  BottleControllerwp secondbottlewp;
        public int numberofbottlestofillwp;
        
        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousepos2d = new Vector2(mousepos.x, mousepos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousepos2d, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<BottleControllerwp>() != null)
                    {
                        if (firstbottlewp == null)
                        {
                            firstbottlewp = hit.collider.GetComponent<BottleControllerwp>();
                            if(firstbottlewp.GetComponent<BottleControllerwp>().filledwp == true|| firstbottlewp.GetComponent<BottleControllerwp>().numberofcolorsinbottle == 0)
                            {
                                firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = false;
                                firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedposition();
                                firstbottlewp = null;
                            }
                            else
                            {                          
                                firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = true;
                                firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedposition();
                            }
                        
                        }
                        else
                        {
                            if (firstbottlewp == hit.collider.GetComponent<BottleControllerwp>())
                            {
                                firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = false;
                                firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedposition();
                                firstbottlewp = null;
                            }
                            else 
                            {
                                //  firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                                secondbottlewp = hit.collider.GetComponent<BottleControllerwp>();
                                firstbottlewp.otherbottlecontrollerref = secondbottlewp;
                                firstbottlewp.UpadteTopColorValues();
                                secondbottlewp.UpadteTopColorValues();
                                // && secondbottle.transform.position == secondbottle.transform.GetComponent<Bottlecontroller>().Orginalposition
                                if (secondbottlewp.fillbottlecheck(firstbottlewp.TopColor) == true)
                                {
                                    //  firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                                    firstbottlewp.StartColorTransfer();
                                    firstbottlewp = null;
                                    secondbottlewp = null;
                                }
                                else
                                {
                                    SoundManagerWP.instance.ErrorSoundwp();
                                    SoundManagerWP.instance.SetVibarationState();
                                    firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = false;
                                    firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedposition();
                                    firstbottlewp = null;
                                    secondbottlewp = null;
                                }

                            }
                        }

                    }
                }
            }
        }

        public void MakeLevelCompletewp()
        {
            //Increment Level Value
            int  levelvaluewp = SaveDataManagerwp.instance.Getlevelsvalue();
            int  levelvalue1wp = PlayerPrefs.GetInt("levelvalue1", 1);
            if (levelvaluewp == levelvalue1wp)
            {
                levelvaluewp++;
                SaveDataManagerwp.instance.Setlevelsvalue(levelvaluewp);
            }
            Invoke("EnableLevelCompeletewp", 1f);
        }

        private void EnableLevelCompeletewp()
        {
            UIManager.instance.LevelCompeletewp();
        }
    }
}

