using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{
    public float fuseLength = 0.1f;
    private float destructTime = 0.0f;

    public void Start()
    {
        destructTime = Time.time + fuseLength;
    }

    public void Update()
    {
        if (Time.time > destructTime)
        {
            Destroy(gameObject);
        }
    }
}
