using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setscrollreacttoabove : MonoBehaviour
{
   
    void OnEnable()
    {
        gameObject.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
    }
}
