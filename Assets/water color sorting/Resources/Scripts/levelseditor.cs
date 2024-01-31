using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelsEditor", menuName = "CreateLevelsEditor")]
public class levelseditor : ScriptableObject
{
    [SerializeField]
    public leveldata[] Levels;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
