using UnityEngine;

namespace water_color_sorting.Resources.Scripts.Levels
{
    [CreateAssetMenu(fileName = "LevelsEditor", menuName = "CreateLevelsEditor")]
    public class LevelsEditor : ScriptableObject
    {
        [SerializeField]
        public LevelData[] Levels;
    
    }
}
