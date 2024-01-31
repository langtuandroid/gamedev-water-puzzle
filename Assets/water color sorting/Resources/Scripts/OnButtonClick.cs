using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{

    public int buttonvalue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onPlayclick()
    {

        if (!gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            SoundManager.instance.PlayButtonSOund();
            PlayerPrefs.SetInt("levelvalue1", buttonvalue);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        }
        else {
            SoundManager.instance.errorSOund();

        }
    }
}
