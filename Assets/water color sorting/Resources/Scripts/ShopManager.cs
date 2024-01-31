using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] shopspanel;
    public GameObject[] Shoppanelclickbuttons;

    public Sprite[] selectedUnselected;

   

    // Start is called before the first frame update
    void Start()
    {
        selectbg();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void selectbg()
    {
        SoundManager.instance.PlayButtonSOund();
        shopspanel[0].gameObject.SetActive(true);
        Shoppanelclickbuttons[0].GetComponent<Image>().sprite = selectedUnselected[1];
    }



    public void Onshopbuttonclick(int value)
    {
        SoundManager.instance.PlayButtonSOund();
        disableallshops();
        shopspanel[value].gameObject.SetActive(true);
        Shoppanelclickbuttons[value].GetComponent<Image>().sprite = selectedUnselected[1];


    }

    void disableallshops()
    {
        for (int i = 0; i < shopspanel.Length; i++)
        {
            shopspanel[i].gameObject.SetActive(false);          
            Shoppanelclickbuttons[i].GetComponent<Image>().sprite = selectedUnselected[0];
        }
    }












}
