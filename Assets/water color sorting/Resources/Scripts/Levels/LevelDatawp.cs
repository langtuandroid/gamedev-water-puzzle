using UnityEngine;


[System.Serializable]
public class TotalBottleswp
{
    public string Name;
    [Tooltip("Enter Value of Total Colors In bottles from 0 to 4")]
    public Color[] ColorsInBottle;
}

[System.Serializable]
public class LevelDatawp 
{
    public string Levelname;
    [Range(0, 16)]
    public int FillingBottles;

    public TotalBottleswp[] TotalNumberofBottles;
    
 
   
}




