using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour
{
    public float walkingSpeed = 0.45f;
    private bool walkingLeft = true;

    public void Start()
    {
        walkingLeft = (UnityEngine.Random.Range(0, 2) == 1);
        updateVisualWalkOrientation();
    }

    public void Update()
    {
        if (walkingLeft)
        {
            transform.Translate(new Vector3(-walkingSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
        else
        {
            transform.Translate(new Vector3(+walkingSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
    }

    public void switchDirections()
    {
        walkingLeft = !walkingLeft;
        updateVisualWalkOrientation();
    }

    private void updateVisualWalkOrientation()
    {
        Vector3 localScale = transform.localScale;
        if (walkingLeft)
        {
            if (localScale.x > 0.0f)
            {
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }
        else
        {
            if (localScale.x < 0.0f)
            {
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }
    }
}
