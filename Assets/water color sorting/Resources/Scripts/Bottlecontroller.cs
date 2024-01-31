using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottlecontroller : MonoBehaviour
{




    public bool filled;
    public bool Selected;
    public  bool normalposition=true;
         
    public Color[] bottlecolors;
    public SpriteRenderer bottlemaskobject;
    public GameObject filledCapAnim;
    public AnimationCurve ScaleandrotateMultiplayer;
    public AnimationCurve fillamountcurve;
    public AnimationCurve rotationspeedmultiplayer;
    [Header("Speed Value of Bottle Rotation")]
    public float timetorotate;
    public float movingspeed;
    public float[] fillamounts;
    public float[] rotationvalues;

    [Range(0,4)]
    public int numberofcolorsinbottle = 4;

    public Color TopColor;
    public int numberofTopColorlayers = 1;

    public Bottlecontroller otherbottlecontrollerref;
    public bool justthisbottle;
    private int numberofcolorstotransfer = 0;

    //rotaion poistion and points
    public Transform leftrotationpoint;
    public Transform rightrotationpoint;
    private Transform choosenrotationpoint;

    private float directionalmultiplayer = 1.0f;

    public LineRenderer waterdropline;


   public Vector3 SelectedUpPosition;
   public Vector3 Orginalposition;
   public Vector3 startposition;
   public Vector3 endposition;
     
    int rotationindex=0;
    private void Awake()
    {
       // Orginalposition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        bottlemaskobject.material.SetFloat("_fillamount", fillamounts[numberofcolorsinbottle]);

        Orginalposition =new Vector3( gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Invoke("SetOrginalPosition", 0.1f);
        //  Orginalposition = transform.position;

        Updatecolors();
        UpadteTopColorValues();
    }
    public void SetOrginalPosition()
    {
        Orginalposition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
       // Orginalposition = transform.position;
      //  print("Orginal Position" + Orginalposition);
       // print("GameObject Position"+gameObject.transform.position);
    }

    public void StartColorTransfer()
    {
        normalposition = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        UIManager.instance.hint.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
        UIManager.instance.AddTube.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
        ///  SoundManager.instance.MakeVibaration();
        //  otherbottlecontrollerref.GetComponent<BoxCollider2D>().enabled = false;
        Selected = false;
        choserotationpointanddirection();
        numberofcolorstotransfer = Mathf.Min(numberofTopColorlayers, 4 - otherbottlecontrollerref.numberofcolorsinbottle);
        for (int i = 0; i < numberofcolorstotransfer; i++)
        {
            otherbottlecontrollerref.bottlecolors[otherbottlecontrollerref.numberofcolorsinbottle + i] = TopColor;
        }

        setemptyabovecolors(otherbottlecontrollerref.numberofcolorsinbottle, TopColor);

        otherbottlecontrollerref.Updatecolors();
        calculaterotationindex(4 - otherbottlecontrollerref.numberofcolorsinbottle);
        transform.GetComponent<SpriteRenderer>().sortingOrder += 2;
        bottlemaskobject.sortingOrder += 2;

        StartCoroutine(MoveBottle());

    }
         
    //transforming position After Selected as first Bottle
    public void BottleSelectedposition()
    {
        if (Selected == true)
        {
               StartCoroutine(MakeBottleSelected());
            //  transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), 1f);
            //   transform.position = Vector3.Lerp(Orginalposition, new Vector3(Orginalposition.x, Orginalposition.y + 1, Orginalposition.z), 1f);
            //  transform.position = Vector3.Lerp(transform.parent.transform.position, new Vector3(0f, 1f, 0f), 1f);
          //  this.gameObject.transform.position = Orginalposition;

        }
        else
        {
            StartCoroutine(MakeBottleSelected());
          //  this.gameObject.transform.position = Orginalposition;
          //  transform.position = new Vector3(0f, 0f, 0f);
            //StartCoroutine(MakeBottleSelected());
            //  transform.position = Vector3.Lerp(transform.position, new Vector3(0f, 0f, 0f), 1f);
            //  transform.position = Vector3.Lerp(transform.position, Orginalposition, 1f);
        }
    }



    IEnumerator MakeBottleSelected()
    {
       

        float t = 0;
        while (t <= 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), t);
            t += Time.deltaTime * 30;

            yield return new WaitForEndOfFrame();
        }
        if (Selected == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), t);
        }
        else
        {
            transform.position = Orginalposition;
        }
        //  normalposition = true;
        transform.GetComponent<SpriteRenderer>().sortingOrder = 2;
        bottlemaskobject.sortingOrder = 1;
    //      StartCoroutine(RotateBottle());
    }






    //move bottle to other bottle
    IEnumerator MoveBottle()
    {
        startposition = transform.position;
        if (choosenrotationpoint == leftrotationpoint)
        {
            endposition = otherbottlecontrollerref.rightrotationpoint.position;
        }
        else
        {
            endposition = otherbottlecontrollerref.leftrotationpoint.position;
        }
        float t = 0;
        while (t <= 1)
        {
            transform.position = Vector3.Lerp(startposition, endposition, t);
            t += Time.deltaTime * movingspeed;

            yield return new WaitForEndOfFrame();
        }
        transform.position = endposition;
        StartCoroutine(RotateBottle());
    }
    IEnumerator MoveBottleBack()
    {
        startposition = transform.position;
      
        endposition = Orginalposition;
        
        float t = 0;
        while (t <= 1)
        {
            transform.position = Vector3.Lerp(startposition, endposition, t);
            t += Time.deltaTime * movingspeed;

            yield return new WaitForEndOfFrame();
        }
        transform.position = endposition;


        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        otherbottlecontrollerref.GetComponent<BoxCollider2D>().enabled = true;
        //  normalposition = true;
        transform.GetComponent<SpriteRenderer>().sortingOrder -= 2;
        bottlemaskobject.sortingOrder -= 2;
        UIManager.instance.hint.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
        UIManager.instance.AddTube.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
        //  StartCoroutine(RotateBottle());
    }



    void Updatecolors()
    {
        bottlemaskobject.material.SetColor("_C1", bottlecolors[0]);
        bottlemaskobject.material.SetColor("_C2", bottlecolors[1]);
        bottlemaskobject.material.SetColor("_C3", bottlecolors[2]);
        bottlemaskobject.material.SetColor("_C4", bottlecolors[3]);
    }




    IEnumerator RotateBottle()
    {
        SoundManager.instance.PlaywaterdropSoundplay();
        float t = 0;
        float lerpvalue, anglevalue;

        float lastanglevalue = 0;

        while (t < timetorotate)
        {
            lerpvalue = t / timetorotate;
            anglevalue = Mathf.Lerp(0.0f,directionalmultiplayer*rotationvalues[rotationindex], lerpvalue);

            //transform.eulerAngles = new Vector3(0, 0, anglevalue);
            transform.RotateAround(choosenrotationpoint.position, Vector3.forward, lastanglevalue-anglevalue);
            bottlemaskobject.material.SetFloat("_Size", ScaleandrotateMultiplayer.Evaluate(anglevalue));

            if(fillamounts[numberofcolorsinbottle]> fillamountcurve.Evaluate(anglevalue))
            {
               
                if (waterdropline.enabled == false)
                {
                    Debug.Log("Line renderer enabled");
                    waterdropline.startColor = TopColor;
                    waterdropline.endColor = TopColor;
                    waterdropline.SetPosition(0, choosenrotationpoint.position);
                    waterdropline.SetPosition(1, choosenrotationpoint.position-Vector3.up*20f);
                    waterdropline.enabled = true;
                }

                bottlemaskobject.material.SetFloat("_fillamount", fillamountcurve.Evaluate(anglevalue));
                //filling up other bottle
                otherbottlecontrollerref.fillup(fillamountcurve.Evaluate(lastanglevalue)- fillamountcurve.Evaluate(anglevalue));
            }
            
            t += Time.deltaTime * rotationspeedmultiplayer.Evaluate(anglevalue);
            lastanglevalue = anglevalue;
            print(anglevalue);
            yield return new WaitForEndOfFrame();
        }
        anglevalue = directionalmultiplayer * rotationvalues[rotationindex];
      //   transform.eulerAngles = new Vector3(0, 0, anglevalue);
        bottlemaskobject.material.SetFloat("_fillamount", ScaleandrotateMultiplayer.Evaluate(anglevalue));
        bottlemaskobject.material.SetFloat("_fillamount", fillamountcurve.Evaluate(anglevalue));
       
        //subtracting and adding values in current and other bottle
        numberofcolorsinbottle -= numberofcolorstotransfer;
        otherbottlecontrollerref.numberofcolorsinbottle += numberofcolorstotransfer;
        setotherbottleexactcolorvalue();


        //checking Other Bottle Is filled Or not

        CheckOtherBottleComplete(otherbottlecontrollerref);


        waterdropline.enabled = false;

        StartCoroutine(RotateBottleback());
    }

    IEnumerator RotateBottleback()
    {
        SoundManager.instance.PlaywaterdropSOundstop();

        float t = 0;
        float lerpvalue, anglevalue;

        float lastanglevalue = directionalmultiplayer * rotationvalues[rotationindex];


        while (t < timetorotate)
        {
            lerpvalue = t / timetorotate;

            anglevalue = Mathf.Lerp(directionalmultiplayer * rotationvalues[rotationindex], 0.0f, lerpvalue);

          // transform.eulerAngles = new Vector3(0, 0, anglevalue);

            transform.RotateAround(choosenrotationpoint.position, Vector3.forward, lastanglevalue - anglevalue);

            bottlemaskobject.material.SetFloat("_Size", ScaleandrotateMultiplayer.Evaluate(anglevalue));

            lastanglevalue = anglevalue;

            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        UpadteTopColorValues();
        anglevalue = 0f;
        transform.eulerAngles = new Vector3(0, 0, anglevalue);
        bottlemaskobject.material.SetFloat("_Size", ScaleandrotateMultiplayer.Evaluate(anglevalue));
        StartCoroutine(MoveBottleBack());
    }


    //for Checking the top Color Values and Number

    public void UpadteTopColorValues()
    {
        if (numberofcolorsinbottle != 0)
        {
            numberofTopColorlayers = 1;
            TopColor = bottlecolors[numberofcolorsinbottle - 1];
            if(numberofcolorsinbottle == 4)
            {
                if (bottlecolors[3].Equals(bottlecolors[2]))
                {
                    numberofTopColorlayers = 2;
                    if (bottlecolors[2].Equals(bottlecolors[1]))
                    {
                        numberofTopColorlayers = 3;
                        if (bottlecolors[1].Equals(bottlecolors[0]))
                        {
                            numberofTopColorlayers = 4;
                        }
                    }
                }
            }
            else if (numberofcolorsinbottle == 3)
            {
                if (bottlecolors[2].Equals(bottlecolors[1]))
                {
                    numberofTopColorlayers = 2;
                    if (bottlecolors[1].Equals(bottlecolors[0]))
                    {
                        numberofTopColorlayers = 3;
                       
                    }
                }
            }
            else if (numberofcolorsinbottle == 2)
            {
                if (bottlecolors[1].Equals(bottlecolors[0]))
                {
                    numberofTopColorlayers = 2;
                    
                }
            }

            rotationindex = 3 - (numberofcolorsinbottle - numberofTopColorlayers);

        }
    }


    void setemptyabovecolors(int colorchangevalue,Color uppercolorvalues)
    {
       // print("filledfunctioncalled");
        if (colorchangevalue == 4)
        {
            otherbottlecontrollerref.filled = true;
        }
        for(int i=3;i> colorchangevalue; i--)
        {
            otherbottlecontrollerref.bottlecolors[i] = uppercolorvalues;
            otherbottlecontrollerref.TopColor = uppercolorvalues;
        }
    }

    // for Checking If Other Bottle Is compeleted with Same Colors

    public void CheckOtherBottleComplete(Bottlecontroller other)
    {
        if (other.numberofcolorsinbottle == 4&&other.bottlecolors[0].Equals(other.bottlecolors[1])&& other.bottlecolors[0].Equals(other.bottlecolors[2])&&other.bottlecolors[0].Equals(other.bottlecolors[3]))
        {
            other.filled = true;
            other.enableotherbottlefillparticle();
            GameObject.FindObjectOfType<LevelContainer>().FillBottleAndCheckLevelComplete();
        }
    }




    public void enableotherbottlefillparticle()
    {
        filledCapAnim.SetActive(true);
        SoundManager.instance.PlayconfettiSOund();
    }







    //for transfering color from One Bottle to another

    public bool fillbottlecheck(Color colortocheck)
    {
        if (numberofcolorsinbottle == 0)
        {
            return true;
        }
        else
        {
            if (numberofcolorsinbottle == 4)
            {
                return false;
            }
            else
            {
                if (TopColor.Equals(colortocheck))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }



    // Calculation rotation index again after transfering colors
    private void calculaterotationindex(int numberofemptyspaceinsecondbottle)
    {
        rotationindex = 3 - (numberofcolorsinbottle- Mathf.Min(numberofemptyspaceinsecondbottle, numberofTopColorlayers));
    }
   

    //filling Other Bottle
    private void fillup(float fillamounttoadd)
    {
        print(fillamounttoadd);
        bottlemaskobject.material.SetFloat("_fillamount", bottlemaskobject.material.GetFloat("_fillamount")+fillamounttoadd);
    }
    void setotherbottleexactcolorvalue()
    {
       
        otherbottlecontrollerref.bottlemaskobject.material.SetFloat("_fillamount", otherbottlecontrollerref.fillamounts[otherbottlecontrollerref.numberofcolorsinbottle]);
        /*
                for (int i=0;i< otherbottlecontrollerref.fillamounts.Length; i++)
                {
                    if(otherbottlecontrollerref.fillamounts[0] - otherbottlecontrollerref.bottlemaskobject.material.GetFloat("_fillamount")> nearestvalue)
                    {
                        nearestvalue = otherbottlecontrollerref.fillamounts[0] - otherbottlecontrollerref.bottlemaskobject.material.GetFloat("_fillamount");
                    }
                }
                if (otherbottlecontrollerref.bottlemaskobject.material.GetFloat("_fillamount")> otherbottlecontrollerref.fillamounts[4])
                {
                    otherbottlecontrollerref.bottlemaskobject.material.SetFloat("_fillamount", otherbottlecontrollerref.fillamounts[4]);
                }
               */
    }

    //for rotating position and transform
    private void choserotationpointanddirection()
    {
        if (transform.position.x > otherbottlecontrollerref.transform.position.x)
        {
            choosenrotationpoint = leftrotationpoint;
            directionalmultiplayer = -1.0f;
        }
        else
        {
            choosenrotationpoint = rightrotationpoint;
            directionalmultiplayer = 1.0f;
        }

    }
        

}
