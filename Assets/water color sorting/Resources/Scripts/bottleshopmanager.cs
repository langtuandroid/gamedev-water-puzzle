using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bottleshopmanager : MonoBehaviour
{
    [Header("Selected Unselected Colors")]
    public Color[] hover;

    public Text CoinsValue;
   


    public GameObject[] bg;
    public int[] Prices;
   
    int coinvalue;
    //public GameObject Buy;
   // public GameObject Equip;
    string bottlevalues;
    


    // Start is called before the first frame update
    void Start()
    {

        //PlayerPrefs.DeleteAll();
        coinvalue = prefmanager.instance.Getcoinsvalue();
        CoinsValue.text = coinvalue.ToString();
        prefmanager.instance.SetcoinsValue(coinvalue);


        unlockbottle();
       
    }






   
    void unlockbottle()
    {
        bottlevalues = PlayerPrefs.GetString("bottlelockfile", "10000000000");
        int i = 0;
        foreach(char c in bottlevalues)
        {
            if (c == '1')
            {
                bg[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            i++;
        }

        unequipallbotles();
        onEquipclick(PlayerPrefs.GetInt("bottlevalue", 0));




    }
    
    
    
    void unlockNow(int Value)
    {
        bottlevalues = PlayerPrefs.GetString("bottlelockfile", "10000000000");
        char[] chars = bottlevalues.ToCharArray();
        chars[Value] = '1';
        bottlevalues = new string(chars);
        PlayerPrefs.SetString("bottlelockfile", bottlevalues);

        coinvalue = prefmanager.instance.Getcoinsvalue();
        coinvalue = coinvalue - Prices[Value];
        //gemsvalue = 5000;
        CoinsValue.text = coinvalue.ToString();
        prefmanager.instance.SetcoinsValue(coinvalue);
 
        unlockbottle();

        print(bottlevalues);
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


            unequipallbotles();
            bg[value].gameObject.GetComponent<Image>().color = hover[1];

            PlayerPrefs.SetInt("bottlevalue", value);



        }
        else
        {
            onBuyclick(value);
        }
       
    }


    void unequipallbotles()
    {
        for(int i = 0; i < bg.Length; i++)
        {
            bg[i].gameObject.transform.GetComponent<Image>().color = hover[0];
        }
    }


    public void onBackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
