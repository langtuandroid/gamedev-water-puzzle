using UnityEngine;
using UnityEngine.UI;

namespace water_color_sorting.Resources.Scripts.UI
{
    public class SetScrollrectwp : MonoBehaviour
    {
        private int _refactorvluewp;
        private void OnEnable()
        {
            gameObject.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
        }
    }
}
