using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;
    
    private void Update()
    {
        transform.Rotate(0f, 0f, speed);
    }
}
