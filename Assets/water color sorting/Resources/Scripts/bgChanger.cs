using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] bg1;
  /*  public Sprite bg2;
    public Sprite bg3;
    public Sprite bg4;
    public Sprite bg5;
    public Sprite bg6;
    public Sprite bg7;
    public Sprite bg8;
  */

    int bgvalue;

    private void Start()
    {
        bgvalue = PlayerPrefs.GetInt("gameplaybgvalue", 2);
    }

    void Update()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = bg1[bgvalue];
      /*  switch (bgvalue)
        {
            case 1:
               this.gameObject.GetComponent<SpriteRenderer>().sprite = bg1[bgvalue];
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bg2;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bg3;
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bg4;
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bg5;
                break;
            case 6:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bg6;
                break;
            case 7:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bg7;
                break;
        }  */
    }

}