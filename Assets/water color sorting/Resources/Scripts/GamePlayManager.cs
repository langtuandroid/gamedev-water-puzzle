using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePlayManager : MonoBehaviour
{
    private int stage;
    public GameObject[] levels;



    // Start is called before the first frame update
    void Start()
    {

        stage = PlayerPrefs.GetInt("level", stage);
        levels[stage].gameObject.SetActive(true);
    }


    public void onbackclick()
    {
        SceneManager.LoadScene("levelSelection");
    }

   

    public void nextclick()
    {

        print(stage);
        if (stage == PlayerPrefs.GetInt("unlock", 0))
        {
            stage += 1;
            PlayerPrefs.SetInt("unlock", stage);
        }

        SceneManager.LoadScene("levelSelection");
    }
}
