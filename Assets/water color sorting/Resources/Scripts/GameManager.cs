using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using water_color_sorting.Resources.Scripts;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


   

    public Bottlecontroller firstbottle;
    public Bottlecontroller secondbottle;

    public int numberofbottlestofill;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousepos2d = new Vector2(mousepos.x, mousepos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousepos2d, Vector2.zero);

            if (hit.collider != null)
            {
              //  print("Collision occur");
                if (hit.collider.GetComponent<Bottlecontroller>() != null)
                {
                    if (firstbottle == null)
                    {
                        firstbottle = hit.collider.GetComponent<Bottlecontroller>();
                        if(firstbottle.GetComponent<Bottlecontroller>().filled == true|| firstbottle.GetComponent<Bottlecontroller>().numberofcolorsinbottle == 0)
                        {
                            firstbottle.GetComponent<Bottlecontroller>().Selected = false;
                            firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                            firstbottle = null;
                        }
                        else
                        {                          
                            firstbottle.GetComponent<Bottlecontroller>().Selected = true;
                            firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                            print("first bottle selected");
                        }
                        
                    }
                    else
                    {
                        if (firstbottle == hit.collider.GetComponent<Bottlecontroller>())
                        {
                           firstbottle.GetComponent<Bottlecontroller>().Selected = false;
                            firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                            firstbottle = null;
                        }
                        else 
                        {
                            print("Second bottle selected");
                          //  firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                            secondbottle = hit.collider.GetComponent<Bottlecontroller>();
                            firstbottle.otherbottlecontrollerref = secondbottle;
                            firstbottle.UpadteTopColorValues();
                            secondbottle.UpadteTopColorValues();
                           // && secondbottle.transform.position == secondbottle.transform.GetComponent<Bottlecontroller>().Orginalposition
                            if (secondbottle.fillbottlecheck(firstbottle.TopColor) == true)
                            {
                                //  firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                                print("color is trasnfering");
                                firstbottle.StartColorTransfer();
                                firstbottle = null;
                                secondbottle = null;
                            }
                            else
                            {
                                SoundManager.instance.errorSOund();
                                SoundManager.instance.MakeVibaration();
                                firstbottle.GetComponent<Bottlecontroller>().Selected = false;
                                firstbottle.GetComponent<Bottlecontroller>().BottleSelectedposition();
                                firstbottle = null;
                                secondbottle = null;
                            }

                        }
                    }

                }
            }
        }
    }




    public void MakeLevelComplete()
    {
        //Increment Level Value
        int  levelvalue = SaveDataManager.instance.Getlevelsvalue();
        int  levelvalue1 = PlayerPrefs.GetInt("levelvalue1", 1);
        if (levelvalue == levelvalue1)
        {
            levelvalue++;
        SaveDataManager.instance.Setlevelsvalue(levelvalue);
       
        }

        Invoke("enablelevelcompelete", 1f);
        
    }

    void enablelevelcompelete()
    {
        UIManager.instance.LevelCompelete();
    }















}
