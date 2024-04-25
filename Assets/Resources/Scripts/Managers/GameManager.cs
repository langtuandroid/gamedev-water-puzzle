using Integration;
using UnityEngine;
using water_color_sorting.Resources.Scripts.Gameplay;
using water_color_sorting.Resources.Scripts.UI;
using Zenject;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;
        public  BottleControllerwp firstbottlewp;
        [SerializeField]
        private  BottleControllerwp secondbottlewp;
        public int numberofbottlestofillwp;
        
        private const string IntegrationsCounter = "CounterIntegrations";
        private int loadLevelCount = 0;
        
        private AdMobController _adMobController;
        private IAPService _iapService;
        
        [Inject]
        private void Construct(AdMobController adMobController, IAPService iapService)
        {
            _adMobController = adMobController;
            _iapService = iapService;
        }
        
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
            
            _adMobController.ShowBanner(true);
            ShowIntegration();
        }
        
        private void ShowIntegration()
        {
            loadLevelCount = PlayerPrefs.GetInt(IntegrationsCounter, 0);
            loadLevelCount++;
            
            if (loadLevelCount % 2 == 0)
            {
                _adMobController.ShowInterstitialAd();
            }
            else if (loadLevelCount % 3 == 0)
            {
                _iapService.ShowSubscriptionPanel();
            }
            if (loadLevelCount >= 3)
            {
                loadLevelCount = 0;
            }
            PlayerPrefs.SetInt(IntegrationsCounter, loadLevelCount);
            PlayerPrefs.Save();
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
                            if(firstbottlewp.GetComponent<BottleControllerwp>().filledwp == true|| firstbottlewp.GetComponent<BottleControllerwp>().numberofcolorsinbottlewp == 0)
                            {
                                firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = false;
                                firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedpositionwp();
                                firstbottlewp = null;
                            }
                            else
                            {                          
                                firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = true;
                                firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedpositionwp();
                            }
                        
                        }
                        else
                        {
                            if (firstbottlewp == hit.collider.GetComponent<BottleControllerwp>())
                            {
                                firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = false;
                                firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedpositionwp();
                                firstbottlewp = null;
                            }
                            else 
                            {
                                //  firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                                secondbottlewp = hit.collider.GetComponent<BottleControllerwp>();
                                firstbottlewp.otherbottlecontrollerrefwp = secondbottlewp;
                                firstbottlewp.UpadteTopColorValueswp();
                                secondbottlewp.UpadteTopColorValueswp();
                                // && secondbottle.transform.position == secondbottle.transform.GetComponent<Bottlecontroller>().Orginalposition
                                if (secondbottlewp.Fillbottlecheckwp(firstbottlewp.TopColorwp) == true)
                                {
                                    //  firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                                    firstbottlewp.StartColorTransferwp();
                                    firstbottlewp = null;
                                    secondbottlewp = null;
                                }
                                else
                                {
                                    SoundManagerWP.instance.ErrorSoundwp();
                                    SoundManagerWP.instance.SetVibarationState();
                                    firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = false;
                                    firstbottlewp.GetComponent<BottleControllerwp>().BottleSelectedpositionwp();
                                    firstbottlewp = null;
                                    secondbottlewp = null;
                                }

                            }
                        }

                    }
                    
                }
            }
        }

        public void ResetSelectedBottle()
        {
            if ( firstbottlewp != null)
            {
                print("Click");
                firstbottlewp.GetComponent<BottleControllerwp>().Selectedwp = false;
                firstbottlewp.GetComponent<BottleControllerwp>().ResetImidiatebottlePosition();
                firstbottlewp = null;
                secondbottlewp = null;
            }
        }

        public void MakeLevelCompletewp()
        {
            //Increment Level Value
            int  levelvaluewp = SaveDataManagerwp.instancewp.Getlevelsvaluewp();
            int  levelvalue1wp = PlayerPrefs.GetInt("levelvalue1", 1);
            if (levelvaluewp == levelvalue1wp)
            {
                levelvaluewp++;
                SaveDataManagerwp.instancewp.Setlevelsvaluewp(levelvaluewp);
            }
            Invoke("EnableLevelCompeletewp", 1f);
        }

        private void EnableLevelCompeletewp()
        {
            UIManagerwp.instance.LevelCompeletewp();
        }
    }
}

