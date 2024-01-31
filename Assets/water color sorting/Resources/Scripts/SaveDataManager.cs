using UnityEngine;

namespace water_color_sorting.Resources.Scripts
{
    public class SaveDataManager : MonoBehaviour
    {
        public static SaveDataManager instance = null;

        int hintvalue, addcubevalue, unlockedlevelvalue, coinsvalue;

        
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public int Gethintvalue()
        {
            return PlayerPrefs.GetInt("hintpref", 3);
        }
        public void SetHintValue(int value)
        {
            PlayerPrefs.SetInt("hintpref", value);
        }

        
        //for getting and Setting extra cubes

        public int Gettubevalue()
        {
            return PlayerPrefs.GetInt("tubepref", 3);
        }
        public void SettubeValue(int value)
        {
            PlayerPrefs.SetInt("tubepref", value);
        }





        //for getting and setting coinsvalue
        public int Getcoinsvalue()
        {
            return PlayerPrefs.GetInt("coinsvalue", 0);
        }
        public void SetcoinsValue(int value)
        {
            PlayerPrefs.SetInt("coinsvalue", value);
        }





        //unlock level value container
        public int Getlevelsvalue()
        {
            return PlayerPrefs.GetInt("unlock", 1);
        }
        public void Setlevelsvalue(int value)
        {
            PlayerPrefs.SetInt("unlock", value);
        }

        //music pref value

        public int Getmusicsvalue()
        {
            return PlayerPrefs.GetInt("musicvalue", 1);
        }
        public void Setmusicsvalue(int value)
        {
            PlayerPrefs.SetInt("musicvalue", value);
        }

        //sound pref value

        public int Getsoundsvalue()
        {
            return PlayerPrefs.GetInt("soundvalue", 1);
        }
        public void Setsoundsvalue(int value)
        {
            PlayerPrefs.SetInt("soundvalue", value);
        }

        //vibration pref value

        public int Getvibrationsvalue()
        {
            return PlayerPrefs.GetInt("vibrationvalue", 1);
        }
        public void Setvibrationvalue(int value)
        {
            PlayerPrefs.SetInt("vibrationvalue", value);
        }





    }
}
