using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class BackGroundShopManagerwp : MonoBehaviour
    {
        [Header("Selected Unselected Colors")]
        public Sprite[] hoverswp;

        public Text CoinsValuewp;
        public GameObject[] bgwp;
        public int[] Priceswp;
        private int currentbgvalue = 0;
        private int crownValue = 0;
        private int coinvalue;
        //public GameObject Buy;
        //public GameObject Equip;
        private string bgvalues;
        
        private void Start()
        {
            coinvalue = PlayerPrefs.GetInt("coinsvalue", 0);
            //coinvalue = 5000;
            CoinsValuewp.text = coinvalue.ToString();
            PlayerPrefs.SetInt("coinsvalue", coinvalue);
            UnlockBgwp();
        }

        private void UnlockBgwp()
        {
            bgvalues = PlayerPrefs.GetString("bglockfile", "10000000");
            int i = 0;
            foreach(char c in bgvalues)
            {
                if (c == '1')
                {
                    bgwp[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
                i++;
            }

            UnequipallBgwp();
            Equipclickwp(PlayerPrefs.GetInt("backgroundvalue",0));

        }
    
    
    
        private void UnlockNowwp(int Value)
        {
            bgvalues = PlayerPrefs.GetString("bglockfile", "10000000");
            char[] chars = bgvalues.ToCharArray();
            chars[Value] = '1';
            bgvalues = new string(chars);
            PlayerPrefs.SetString("bglockfile", bgvalues);

            coinvalue = PlayerPrefs.GetInt("coinsvalue", 0);
            coinvalue = coinvalue - Priceswp[Value];
            //gemsvalue = 5000;
            CoinsValuewp.text = coinvalue.ToString();
            PlayerPrefs.SetInt("coinsvalue", coinvalue);
            UnlockBgwp();

            print(bgvalues);
        }


  
        public void Buywp(int bgvalue)
        {
            if(coinvalue >= Priceswp[bgvalue])
            {
                UnlockNowwp(bgvalue);
           
            }
        }
        public void Equipclickwp(int value)
        {
            if (!bgwp[value].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                UnequipallBgwp();
                bgwp[value].gameObject.transform.GetChild(2).GetComponentInChildren<Image>().sprite = hoverswp[1];
                PlayerPrefs.SetInt("backgroundvalue", value);
            }
            else
            {
                Buywp(value);
            }
        }

        void UnequipallBgwp()
        {
            for(int i = 0; i < bgwp.Length; i++)
            {
                bgwp[i].gameObject.transform.GetChild(2).GetComponentInChildren<Image>().sprite = hoverswp[0];
            }
        }
        
        public void BackClickwp()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
