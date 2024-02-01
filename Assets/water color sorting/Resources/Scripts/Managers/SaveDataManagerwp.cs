using UnityEngine;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class SaveDataManagerwp : MonoBehaviour
    {
        public static SaveDataManagerwp instancewp = null;

        private int _hintvaluewp;
        private int _addcubevaluewp;
        private int _unlockedlevelvaluewp;
        private int _coinsvaluewp;

        void Awake()
        {
            if (instancewp == null)
            {
                instancewp = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public int Gethintvaluewp()
        {
            return PlayerPrefs.GetInt("hintpref", 3);
        }
        public void SetHintValuewp(int value)
        {
            PlayerPrefs.SetInt("hintpref", value);
        }

        
        //for getting and Setting extra cubes

        public int Gettubevaluewp()
        {
            return PlayerPrefs.GetInt("tubepref", 3);
        }
        public void SettubeValuewp(int value)
        {
            PlayerPrefs.SetInt("tubepref", value);
        }

        //for getting and setting coinsvalue
        public int Getcoinsvaluewp()
        {
            return PlayerPrefs.GetInt("coinsvalue", 0);
        }
        public void SetcoinsValuewp(int value)
        {
            PlayerPrefs.SetInt("coinsvalue", value);
        }

        //unlock level value container
        public int Getlevelsvaluewp()
        {
            return PlayerPrefs.GetInt("unlock", 1);
        }
        public void Setlevelsvaluewp(int value)
        {
            PlayerPrefs.SetInt("unlock", value);
        }

        //music pref value

        public int Getmusicsvaluewp()
        {
            return PlayerPrefs.GetInt("musicvalue", 1);
        }
        public void Setmusicsvaluewp(int value)
        {
            PlayerPrefs.SetInt("musicvalue", value);
        }

        //sound pref value

        public int Getsoundsvaluewp()
        {
            return PlayerPrefs.GetInt("soundvalue", 1);
        }
        public void Setsoundsvaluewp(int value)
        {
            PlayerPrefs.SetInt("soundvalue", value);
        }

        //vibration pref value

        public int Getvibrationsvaluewp()
        {
            return PlayerPrefs.GetInt("vibrationvalue", 1);
        }
        public void Setvibrationvaluewp(int value)
        {
            PlayerPrefs.SetInt("vibrationvalue", value);
        }





    }
}

