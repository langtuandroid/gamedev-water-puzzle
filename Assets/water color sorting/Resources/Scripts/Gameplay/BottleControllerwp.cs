using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using water_color_sorting.Resources.Scripts.Levels;
using water_color_sorting.Resources.Scripts.Managers;
using water_color_sorting.Resources.Scripts.UI;

namespace water_color_sorting.Resources.Scripts.Gameplay
{
    public class BottleControllerwp : MonoBehaviour
    {
        [FormerlySerializedAs("filled")] public bool filledwp;
        [FormerlySerializedAs("Selected")] public bool Selectedwp;
        public  bool normalposition=true;
         
        [FormerlySerializedAs("bottlecolors")] public Color[] bottlecolorswp;
        [FormerlySerializedAs("bottlemaskobject")] public SpriteRenderer bottlemaskobjectwp;
        [FormerlySerializedAs("filledCapAnim")] public GameObject filledCapAnimwp;
        [FormerlySerializedAs("ScaleandrotateMultiplayer")] public AnimationCurve ScaleandrotateMultiplayerwp;
        [FormerlySerializedAs("fillamountcurve")] public AnimationCurve fillamountcurvewp;
        [FormerlySerializedAs("rotationspeedmultiplayer")] public AnimationCurve rotationspeedmultiplayerwp;
        [FormerlySerializedAs("timetorotate")] [Header("Speed Value of Bottle Rotation")]
        public float timetorotatewp;
        [FormerlySerializedAs("movingspeed")] public float movingspeedwp;
        [FormerlySerializedAs("fillamounts")] public float[] fillamountswp;
        [FormerlySerializedAs("rotationvalues")] public float[] rotationvalueswp;

        [FormerlySerializedAs("numberofcolorsinbottle")] [Range(0,4)]
        public int numberofcolorsinbottlewp = 4;

        [FormerlySerializedAs("TopColor")] public Color TopColorwp;
        [FormerlySerializedAs("numberofTopColorlayers")] public int numberofTopColorlayerswp = 1;

        [FormerlySerializedAs("otherbottlecontrollerref")] public BottleControllerwp otherbottlecontrollerrefwp;
        [FormerlySerializedAs("justthisbottle")] public bool justthisbottlewp;
        private int numberofcolorstotransferwp = 0;

        //rotaion poistion and points
        [FormerlySerializedAs("leftrotationpoint")] public Transform leftrotationpointwp;
        [FormerlySerializedAs("rightrotationpoint")] public Transform rightrotationpointwp;
        private Transform choosenrotationpointwp;

        private float directionalmultiplayerwp = 1.0f;

        [FormerlySerializedAs("waterdropline")] public LineRenderer waterdroplinewp;


        [FormerlySerializedAs("SelectedUpPosition")] public Vector3 SelectedUpPositionwp;
        [FormerlySerializedAs("Orginalposition")] public Vector3 Orginalpositionwp;
        [FormerlySerializedAs("startposition")] public Vector3 startpositionwp;
        [FormerlySerializedAs("endposition")] public Vector3 endpositionwp;
     
        int rotationindex=0;
       
        private void Start()
        {
            bottlemaskobjectwp.material.SetFloat("_fillamount", fillamountswp[numberofcolorsinbottlewp]);

            Orginalpositionwp =new Vector3( gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Invoke("SetOrginalPositionwp", 0.1f);
            //  Orginalposition = transform.position;

            Updatecolorswp();
            UpadteTopColorValueswp();
        }
        public void SetOrginalPositionwp()
        {
            Orginalpositionwp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        // Update is called once per frame
        void Update()
        {
            // Orginalposition = transform.position;
            //  print("Orginal Position" + Orginalposition);
            // print("GameObject Position"+gameObject.transform.position);
        }

        public void StartColorTransferwp()
        {
            normalposition = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            UIManagerwp.instance.Hintwp.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
            UIManagerwp.instance.AddTubewp.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
            ///  SoundManager.instance.MakeVibaration();
            //  otherbottlecontrollerref.GetComponent<BoxCollider2D>().enabled = false;
            Selectedwp = false;
            Choserotationpointanddirectionwp();
            numberofcolorstotransferwp = Mathf.Min(numberofTopColorlayerswp, 4 - otherbottlecontrollerrefwp.numberofcolorsinbottlewp);
            for (int i = 0; i < numberofcolorstotransferwp; i++)
            {
                otherbottlecontrollerrefwp.bottlecolorswp[otherbottlecontrollerrefwp.numberofcolorsinbottlewp + i] = TopColorwp;
            }

            SetEmptyaboveColorswp(otherbottlecontrollerrefwp.numberofcolorsinbottlewp, TopColorwp);

            otherbottlecontrollerrefwp.Updatecolorswp();
            CalculaterotationIndexwp(4 - otherbottlecontrollerrefwp.numberofcolorsinbottlewp);
            transform.GetComponent<SpriteRenderer>().sortingOrder += 2;
            bottlemaskobjectwp.sortingOrder += 2;

            StartCoroutine(MoveBottlewp());

        }
         
        //transforming position After Selected as first Bottle
        public void BottleSelectedpositionwp()
        {
            if (Selectedwp == true)
            {
                StartCoroutine(MakeBottleSelectedwp());
                //  transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), 1f);
                //   transform.position = Vector3.Lerp(Orginalposition, new Vector3(Orginalposition.x, Orginalposition.y + 1, Orginalposition.z), 1f);
                //  transform.position = Vector3.Lerp(transform.parent.transform.position, new Vector3(0f, 1f, 0f), 1f);
                //  this.gameObject.transform.position = Orginalposition;

            }
            else
            {
                StartCoroutine(MakeBottleSelectedwp());
                //  this.gameObject.transform.position = Orginalposition;
                //  transform.position = new Vector3(0f, 0f, 0f);
                //StartCoroutine(MakeBottleSelected());
                //  transform.position = Vector3.Lerp(transform.position, new Vector3(0f, 0f, 0f), 1f);
                //  transform.position = Vector3.Lerp(transform.position, Orginalposition, 1f);
            }
        }



        IEnumerator MakeBottleSelectedwp()
        {
            float t = 0;
            while (t <= 1)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), t);
                t += Time.deltaTime * 30;

                yield return new WaitForEndOfFrame();
            }
            if (Selectedwp == true)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), t);
            }
            else
            {
                transform.position = Orginalpositionwp;
            }
            //  normalposition = true;
            transform.GetComponent<SpriteRenderer>().sortingOrder = 2;
            bottlemaskobjectwp.sortingOrder = 1;
            //      StartCoroutine(RotateBottle());
        }






        //move bottle to other bottle
        IEnumerator MoveBottlewp()
        {
            startpositionwp = transform.position;
            if (choosenrotationpointwp == leftrotationpointwp)
            {
                endpositionwp = otherbottlecontrollerrefwp.rightrotationpointwp.position;
            }
            else
            {
                endpositionwp = otherbottlecontrollerrefwp.leftrotationpointwp.position;
            }
            float t = 0;
            while (t <= 1)
            {
                transform.position = Vector3.Lerp(startpositionwp, endpositionwp, t);
                t += Time.deltaTime * movingspeedwp;

                yield return new WaitForEndOfFrame();
            }
            transform.position = endpositionwp;
            StartCoroutine(RotateBottlewp());
        }
        IEnumerator MoveBottleBackwp()
        {
            startpositionwp = transform.position;
      
            endpositionwp = Orginalpositionwp;
        
            float t = 0;
            while (t <= 1)
            {
                transform.position = Vector3.Lerp(startpositionwp, endpositionwp, t);
                t += Time.deltaTime * movingspeedwp;

                yield return new WaitForEndOfFrame();
            }
            transform.position = endpositionwp;


            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            otherbottlecontrollerrefwp.GetComponent<BoxCollider2D>().enabled = true;
            //  normalposition = true;
            transform.GetComponent<SpriteRenderer>().sortingOrder -= 2;
            bottlemaskobjectwp.sortingOrder -= 2;
            UIManagerwp.instance.Hintwp.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
            UIManagerwp.instance.AddTubewp.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
            //  StartCoroutine(RotateBottle());
        }



        void Updatecolorswp()
        {
            bottlemaskobjectwp.material.SetColor("_C1", bottlecolorswp[0]);
            bottlemaskobjectwp.material.SetColor("_C2", bottlecolorswp[1]);
            bottlemaskobjectwp.material.SetColor("_C3", bottlecolorswp[2]);
            bottlemaskobjectwp.material.SetColor("_C4", bottlecolorswp[3]);
        }




        IEnumerator RotateBottlewp()
        {
            SoundManagerWP.instance.PlaywaterdropSoundPlaywp();
            float t = 0;
            float lerpvalue, anglevalue;

            float lastanglevalue = 0;

            while (t < timetorotatewp)
            {
                lerpvalue = t / timetorotatewp;
                anglevalue = Mathf.Lerp(0.0f,directionalmultiplayerwp*rotationvalueswp[rotationindex], lerpvalue);

                //transform.eulerAngles = new Vector3(0, 0, anglevalue);
                transform.RotateAround(choosenrotationpointwp.position, Vector3.forward, lastanglevalue-anglevalue);
                bottlemaskobjectwp.material.SetFloat("_Size", ScaleandrotateMultiplayerwp.Evaluate(anglevalue));

                if(fillamountswp[numberofcolorsinbottlewp]> fillamountcurvewp.Evaluate(anglevalue))
                {
               
                    if (waterdroplinewp.enabled == false)
                    {
                       // Debug.Log("Line renderer enabled");
                        waterdroplinewp.startColor = TopColorwp;
                        waterdroplinewp.endColor = TopColorwp;
                        waterdroplinewp.SetPosition(0, choosenrotationpointwp.position);
                        waterdroplinewp.SetPosition(1, choosenrotationpointwp.position - Vector3.up*20f);
                        waterdroplinewp.enabled = true;
                    }

                    bottlemaskobjectwp.material.SetFloat("_fillamount", fillamountcurvewp.Evaluate(anglevalue));
                    //filling up other bottle
                    otherbottlecontrollerrefwp.Fillupwp(fillamountcurvewp.Evaluate(lastanglevalue)- fillamountcurvewp.Evaluate(anglevalue));
                }
            
                t += Time.deltaTime * rotationspeedmultiplayerwp.Evaluate(anglevalue);
                lastanglevalue = anglevalue;
                //print(anglevalue);
                yield return new WaitForEndOfFrame();
            }
            anglevalue = directionalmultiplayerwp * rotationvalueswp[rotationindex];
            //   transform.eulerAngles = new Vector3(0, 0, anglevalue);
            bottlemaskobjectwp.material.SetFloat("_fillamount", ScaleandrotateMultiplayerwp.Evaluate(anglevalue));
            bottlemaskobjectwp.material.SetFloat("_fillamount", fillamountcurvewp.Evaluate(anglevalue));
       
            //subtracting and adding values in current and other bottle
            numberofcolorsinbottlewp -= numberofcolorstotransferwp;
            otherbottlecontrollerrefwp.numberofcolorsinbottlewp += numberofcolorstotransferwp;
            Setotherbottleexactcolorvaluewp();


            //checking Other Bottle Is filled Or not

            CheckOtherBottleCompletewp(otherbottlecontrollerrefwp);


            waterdroplinewp.enabled = false;

            StartCoroutine(RotateBottlebackwp());
        }

        IEnumerator RotateBottlebackwp()
        {
            SoundManagerWP.instance.PlaywaterdropSoundStopwp();

            float t = 0;
            float lerpvalue, anglevalue;

            float lastanglevalue = directionalmultiplayerwp * rotationvalueswp[rotationindex];


            while (t < timetorotatewp)
            {
                lerpvalue = t / timetorotatewp;

                anglevalue = Mathf.Lerp(directionalmultiplayerwp * rotationvalueswp[rotationindex], 0.0f, lerpvalue);

                // transform.eulerAngles = new Vector3(0, 0, anglevalue);

                transform.RotateAround(choosenrotationpointwp.position, Vector3.forward, lastanglevalue - anglevalue);

                bottlemaskobjectwp.material.SetFloat("_Size", ScaleandrotateMultiplayerwp.Evaluate(anglevalue));

                lastanglevalue = anglevalue;

                t += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            UpadteTopColorValueswp();
            anglevalue = 0f;
            transform.eulerAngles = new Vector3(0, 0, anglevalue);
            bottlemaskobjectwp.material.SetFloat("_Size", ScaleandrotateMultiplayerwp.Evaluate(anglevalue));
            StartCoroutine(MoveBottleBackwp());
        }


        //for Checking the top Color Values and Number

        public void UpadteTopColorValueswp()
        {
            if (numberofcolorsinbottlewp != 0)
            {
                numberofTopColorlayerswp = 1;
                TopColorwp = bottlecolorswp[numberofcolorsinbottlewp - 1];
                if(numberofcolorsinbottlewp == 4)
                {
                    if (bottlecolorswp[3].Equals(bottlecolorswp[2]))
                    {
                        numberofTopColorlayerswp = 2;
                        if (bottlecolorswp[2].Equals(bottlecolorswp[1]))
                        {
                            numberofTopColorlayerswp = 3;
                            if (bottlecolorswp[1].Equals(bottlecolorswp[0]))
                            {
                                numberofTopColorlayerswp = 4;
                            }
                        }
                    }
                }
                else if (numberofcolorsinbottlewp == 3)
                {
                    if (bottlecolorswp[2].Equals(bottlecolorswp[1]))
                    {
                        numberofTopColorlayerswp = 2;
                        if (bottlecolorswp[1].Equals(bottlecolorswp[0]))
                        {
                            numberofTopColorlayerswp = 3;
                       
                        }
                    }
                }
                else if (numberofcolorsinbottlewp == 2)
                {
                    if (bottlecolorswp[1].Equals(bottlecolorswp[0]))
                    {
                        numberofTopColorlayerswp = 2;
                    
                    }
                }

                rotationindex = 3 - (numberofcolorsinbottlewp - numberofTopColorlayerswp);

            }
        }


        void SetEmptyaboveColorswp(int colorchangevalue,Color uppercolorvalues)
        {
            // print("filledfunctioncalled");
            if (colorchangevalue == 4)
            {
                otherbottlecontrollerrefwp.filledwp = true;
            }
            for(int i=3;i> colorchangevalue; i--)
            {
                otherbottlecontrollerrefwp.bottlecolorswp[i] = uppercolorvalues;
                otherbottlecontrollerrefwp.TopColorwp = uppercolorvalues;
            }
        }

        // for Checking If Other Bottle Is compeleted with Same Colors

        public void CheckOtherBottleCompletewp(BottleControllerwp other)
        {
            if (other.numberofcolorsinbottlewp == 4&&other.bottlecolorswp[0].Equals(other.bottlecolorswp[1])&& other.bottlecolorswp[0].Equals(other.bottlecolorswp[2])&&other.bottlecolorswp[0].Equals(other.bottlecolorswp[3]))
            {
                other.filledwp = true;
                other.Enableotherbottlefillparticlewp();
                GameObject.FindObjectOfType<LevelContainerwp>().FillBottleAndCheckLevelCompletewp();
            }
        }

        
        public void Enableotherbottlefillparticlewp()
        {
            filledCapAnimwp.SetActive(true);
            SoundManagerWP.instance.PlayconfettiSOundwp();
        }
        

        //for transfering color from One Bottle to another

        public bool Fillbottlecheckwp(Color colortocheck)
        {
            if (numberofcolorsinbottlewp == 0)
            {
                return true;
            }
            else
            {
                if (numberofcolorsinbottlewp == 4)
                {
                    return false;
                }
                else
                {
                    if (TopColorwp.Equals(colortocheck))
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
        private void CalculaterotationIndexwp(int numberofemptyspaceinsecondbottle)
        {
            rotationindex = 3 - (numberofcolorsinbottlewp- Mathf.Min(numberofemptyspaceinsecondbottle, numberofTopColorlayerswp));
        }
   

        //filling Other Bottle
        private void Fillupwp(float fillamounttoadd)
        {
            //print(fillamounttoadd);
            bottlemaskobjectwp.material.SetFloat("_fillamount", bottlemaskobjectwp.material.GetFloat("_fillamount")+fillamounttoadd);
        }
        void Setotherbottleexactcolorvaluewp()
        {
       
            otherbottlecontrollerrefwp.bottlemaskobjectwp.material.SetFloat("_fillamount", otherbottlecontrollerrefwp.fillamountswp[otherbottlecontrollerrefwp.numberofcolorsinbottlewp]);
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
        private void Choserotationpointanddirectionwp()
        {
            if (transform.position.x > otherbottlecontrollerrefwp.transform.position.x)
            {
                choosenrotationpointwp = leftrotationpointwp;
                directionalmultiplayerwp = -1.0f;
            }
            else
            {
                choosenrotationpointwp = rightrotationpointwp;
                directionalmultiplayerwp = 1.0f;
            }

        }
        
    }
}
