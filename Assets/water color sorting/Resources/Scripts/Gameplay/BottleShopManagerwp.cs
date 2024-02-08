using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using water_color_sorting.Resources.Scripts.Managers;

namespace water_color_sorting.Resources.Scripts.Gameplay
{
    public class BottleShopManagerwp : MonoBehaviour
    {
        [Header("Selected Unselected Colors")]
        public Sprite[] hoverwp;

        public Text CoinsValuewp;
        public GameObject[] bgwp;
        public int[] Priceswp;
        private int coinvaluewp;
        private string bottlevalueswp;
        
        private void Start()
        {
            coinvaluewp = SaveDataManagerwp.instancewp.Getcoinsvaluewp();
            CoinsValuewp.text = coinvaluewp.ToString();
            SaveDataManagerwp.instancewp.SetcoinsValuewp(coinvaluewp);
            UnlockBottlewp();
        }
        
        private void UnlockBottlewp()
        {
            bottlevalueswp = PlayerPrefs.GetString("bottlelockfile", "10000000000");
            int i = 0;
            foreach(char c in bottlevalueswp)
            {
                if (c == '1')
                {
                    bgwp[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
                i++;
            }

            UnEquipallBotleswp();
            Equipclickwp(PlayerPrefs.GetInt("bottlevalue", 0));
        }
    
    
    
        void UnlockNowwp(int Value)
        {
            bottlevalueswp = PlayerPrefs.GetString("bottlelockfile", "10000000000");
            char[] chars = bottlevalueswp.ToCharArray();
            chars[Value] = '1';
            bottlevalueswp = new string(chars);
            PlayerPrefs.SetString("bottlelockfile", bottlevalueswp);

            coinvaluewp = SaveDataManagerwp.instancewp.Getcoinsvaluewp();
            coinvaluewp = coinvaluewp - Priceswp[Value];
            //gemsvalue = 5000;
            CoinsValuewp.text = coinvaluewp.ToString();
            SaveDataManagerwp.instancewp.SetcoinsValuewp(coinvaluewp);
 
            UnlockBottlewp();

            print(bottlevalueswp);
        }
        
        public void Buyclickwp(int bgvalue)
        {
            if(coinvaluewp >= Priceswp[bgvalue])
            {
                UnlockNowwp(bgvalue);
            }
        }
        
        public void Equipclickwp(int value)
        {
            if (!bgwp[value].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                UnEquipallBotleswp();
                bgwp[value].GetComponent<Image>().sprite = hoverwp[1];
                PlayerPrefs.SetInt("bottlevalue", value);
            }
            else
            {
                Buyclickwp(value);
            }
       
        }


        private void UnEquipallBotleswp()
        {
            for(int i = 0; i < bgwp.Length; i++)
            {
                bgwp[i].GetComponent<Image>().sprite = hoverwp[0];
            }
        }


        public void BackClickwp()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
