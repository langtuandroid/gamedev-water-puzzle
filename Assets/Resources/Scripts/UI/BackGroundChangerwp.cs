using UnityEngine;

namespace water_color_sorting.Resources.Scripts.UI
{
    public class BackGroundChangerwp : MonoBehaviour
    {
        public Sprite[] _bgSpritewp;
        private int _bgIndexwp;

        private void Start()
        {
            _bgIndexwp = PlayerPrefs.GetInt("gameplaybgvalue", 2);
        }

        private void Update()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _bgSpritewp[_bgIndexwp];
        }

        private void RefactorWP()
        {
            int testwp = _bgIndexwp;
        }

    }
}