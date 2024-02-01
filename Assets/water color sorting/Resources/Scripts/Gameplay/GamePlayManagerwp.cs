using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace water_color_sorting.Resources.Scripts.Gameplay
{
    public class GamePlayManagerwp : MonoBehaviour
    {
        private int stagewp;
        [FormerlySerializedAs("levels")] public GameObject[] levelswp;
        
        private void Start()
        {
            stagewp = PlayerPrefs.GetInt("level", stagewp);
            levelswp[stagewp].gameObject.SetActive(true);
        }
        
        public void BackClickwp()
        {
            SceneManager.LoadScene("levelSelection");
        }
        
        public void NextClickwp()
        {

            print(stagewp);
            if (stagewp == PlayerPrefs.GetInt("unlock", 0))
            {
                stagewp += 1;
                PlayerPrefs.SetInt("unlock", stagewp);
            }

            SceneManager.LoadScene("levelSelection");
        }
    }
}
