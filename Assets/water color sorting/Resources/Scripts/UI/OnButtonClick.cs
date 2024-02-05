using UnityEngine;
using water_color_sorting.Resources.Scripts.Managers;

namespace water_color_sorting.Resources.Scripts.UI
{
    public class OnButtonClick : MonoBehaviour
    {
        public int buttonLevelNumber;
        
        public void onPlayclick()
        {
            if (!gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                SoundManagerWP.instance.PlayButtonSoundwp();
                SaveDataManagerwp.instancewp.SetPresentLevel(buttonLevelNumber);
                UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
            }
            else
            {
                SoundManagerWP.instance.ErrorSoundwp();
            }
        }
    }
}
