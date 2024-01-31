using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bgshopmanager : MonoBehaviour
{
    [Header("Selected Unselected Colors")]
    public Color[] hover;

    public Text CoinsValue;
   


    public GameObject[] bg;
    public int[] Prices;
    int currentbgvalue = 0, crownValue=0;
    int coinvalue;
    //public GameObject Buy;
   // public GameObject Equip;
    string bgvalues;
    


    // Start is called before the first frame update
    void Start()
    {
       
        //PlayerPrefs.DeleteAll();
        coinvalue = PlayerPrefs.GetInt("coinsvalue", 0);
    //    coinvalue = 5000;
        CoinsValue.text = coinvalue.ToString();
        PlayerPrefs.SetInt("coinsvalue", coinvalue);
        
       
        unlockbg();
       
    }






   
    void unlockbg()
    {
        bgvalues = PlayerPrefs.GetString("bglockfile", "10000000");
        int i = 0;
        foreach(char c in bgvalues)
        {
            if (c == '1')
            {
                bg[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            i++;
        }

        unequipallbg();
        onEquipclick(PlayerPrefs.GetInt("backgroundvalue",0));

    }
    
    
    
    void unlockNow(int Value)
    {
        bgvalues = PlayerPrefs.GetString("bglockfile", "10000000");
        char[] chars = bgvalues.ToCharArray();
        chars[Value] = '1';
        bgvalues = new string(chars);
        PlayerPrefs.SetString("bglockfile", bgvalues);

        coinvalue = PlayerPrefs.GetInt("coinsvalue", 0);
        coinvalue = coinvalue - Prices[Value];
        //gemsvalue = 5000;
        CoinsValue.text = coinvalue.ToString();
        PlayerPrefs.SetInt("coinsvalue", coinvalue);
        unlockbg();

        print(bgvalues);
    }


  
    public void onBuyclick(int bgvalue)
    {
        if(coinvalue >= Prices[bgvalue])
        {
            unlockNow(bgvalue);
           
        }
    }
    public void onEquipclick(int value)
    {
        if (!bg[value].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
        {

           
            unequipallbg();
            bg[value].gameObject.transform.parent.gameObject.GetComponent<Image>().color = hover[1];

            PlayerPrefs.SetInt("backgroundvalue", value);



        }
        else
        {
            onBuyclick(value);
        }
       
    }


    void unequipallbg()
    {
        for(int i = 0; i < bg.Length; i++)
        {
            bg[i].gameObject.transform.parent.gameObject.GetComponent<Image>().color = hover[0];
        }
    }


    public void onBackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
