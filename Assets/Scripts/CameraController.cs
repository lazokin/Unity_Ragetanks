using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{
    public PlayerStateController.playerStates currentPlayerState = PlayerStateController.playerStates.idle;
    public GameObject playerObject = null;
    public float cameraTrackingSpeed = 0.2f;
    private Vector3 lastTargetPosition = Vector3.zero;
    private Vector3 currTargetPosition = Vector3.zero;
    private float currLerpDistance = 0.0f;

	void Start ()
    {
        Vector3 playerPos = playerObject.transform.position;
        Vector3 cameraPos = transform.position;
        Vector3 startTargPos = playerPos;
        startTargPos.z = cameraPos.z;
        lastTargetPosition = startTargPos;
        currTargetPosition = startTargPos;
        currLerpDistance = 1.0f;
	}

    void OnEnable()
    {
        PlayerStateController.StateChange += OnPlayerStateChange;
    }

    void OnDisable()
    {
        PlayerStateController.StateChange -= OnPlayerStateChange;
    }
	
	void LateUpdate ()
    {
        OnStateCycle();
        currLerpDistance += cameraTrackingSpeed;
        transform.position = Vector3.Lerp(lastTargetPosition, currTargetPosition, currLerpDistance);
	}

    private void OnStateCycle()
    {
        switch (currentPlayerState)
        {
            case PlayerStateController.playerStates.idle:
                trackPlayer();
                break;

            case PlayerStateController.playerStates.left:
                trackPlayer();
                break;

            case PlayerStateController.playerStates.right:
                trackPlayer();
                break;
        }
    }

    private void trackPlayer()
    {
        Vector3 currCamPos = transform.position;
        Vector3 currPlayerPos = playerObject.transform.position;
        if (currCamPos.x == currPlayerPos.x && currCamPos.y == currPlayerPos.y)
        {
            currLerpDistance = 1.0f;
            lastTargetPosition = currCamPos;
            currTargetPosition = currCamPos;
            return;
        }

        currLerpDistance = 0.0f;
        lastTargetPosition = currCamPos;
        currTargetPosition = currPlayerPos;
        currTargetPosition.z = currCamPos.z;
    }

    private void stopTrackingPlayer()
    {
        Vector3 currCamPos = transform.position;
        currTargetPosition = currCamPos;
        lastTargetPosition = currCamPos;
        currLerpDistance = 1.0f;
    }

    private void OnPlayerStateChange(PlayerStateController.playerStates newState)
    {
        currentPlayerState = newState;
    }
}
