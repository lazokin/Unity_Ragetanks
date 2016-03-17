using UnityEngine;
using System.Collections;
using System;

public class ParallaxController : MonoBehaviour
{
    public GameObject[] clouds;
    public GameObject[] nearHills;
    public GameObject[] farHills;

    public float cloudLayerSpeedMultiplier;
    public float nearHillsLayerSpeedMultiplier;
    public float farHillsLayerSpeedMultiplier;

    public Camera myCamera;

    private Vector3 lastCamPos;

    void Start()
    {
        lastCamPos = myCamera.transform.position;
    }

    void Update()
    {
        Vector3 currCamPos = myCamera.transform.position;
        float xPosDiff = lastCamPos.x - currCamPos.x;
        adjustParallaxPositionsForArray(clouds, cloudLayerSpeedMultiplier, xPosDiff);
        adjustParallaxPositionsForArray(nearHills, nearHillsLayerSpeedMultiplier, xPosDiff);
        adjustParallaxPositionsForArray(farHills, farHillsLayerSpeedMultiplier, xPosDiff);
        lastCamPos = myCamera.transform.position;
    }

    private void adjustParallaxPositionsForArray(GameObject[] gameObjects, float speedMultiplier, float xPosDiff)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 objPos = gameObjects[i].transform.position;
            objPos.x += xPosDiff * speedMultiplier;
            gameObjects[i].transform.position = objPos;
        }
    }
}
