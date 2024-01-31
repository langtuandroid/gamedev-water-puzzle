using UnityEngine;
using UnityEngine.Serialization;
using water_color_sorting.Resources.Scripts.Managers;

namespace water_color_sorting.Resources.Scripts.UI
{
    public class OnButtonClick : MonoBehaviour
    {
        [FormerlySerializedAs("buttonvalue")] public int buttonLevelNumber;
        
        public void onPlayclick()
        {
            if (!gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                SoundManager.instance.PlayButtonSOund();
                PlayerPrefs.SetInt("levelvalue1", buttonLevelNumber);
                UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
            }
            else {
                SoundManager.instance.errorSOund();

            }
        }
    }
}
