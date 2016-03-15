using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class PlayerStateListener : MonoBehaviour
{
    public float playerWalkSpeed = 3f;

    private Animator playerAnimator = null;
    private PlayerStateController.playerStates currentState = PlayerStateController.playerStates.idle;

    void OnEnable()
    {
        PlayerStateController.StateChange += OnStateChange;
    }

    void OnDisable()
    {
        PlayerStateController.StateChange -= OnStateChange;
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        OnStateCycle();
    }

    private void OnStateCycle()
    {
        switch (currentState)
        {
            case PlayerStateController.playerStates.idle:
                break;

            case PlayerStateController.playerStates.left:
                transform.Translate(new Vector3((playerWalkSpeed * -1.0f) * Time.deltaTime, 0.0f, 0.0f));
                break;

            case PlayerStateController.playerStates.right:
                transform.Translate(new Vector3((playerWalkSpeed * 1.0f) * Time.deltaTime, 0.0f, 0.0f));
                break;
        }
    }

    private void OnStateChange(PlayerStateController.playerStates newState)
    {
        if (newState == currentState)
        {
            return;
        }

        if (StateTransitionAbort(newState))
        {
            return;
        }

        if (!StateTransitionValid(newState))
        {
            return;
        }

        switch (newState)
        {
            case PlayerStateController.playerStates.idle:
                break;

            case PlayerStateController.playerStates.left:
                break;

            case PlayerStateController.playerStates.right:
                break;
        }

        currentState = newState;
    }

    private bool StateTransitionAbort(PlayerStateController.playerStates newState)
    {
        return false;
    }

    private bool StateTransitionValid(PlayerStateController.playerStates newState)
    {
        bool result = false;
        switch (currentState)
        {
            case PlayerStateController.playerStates.idle:
                result = true;
                break;

            case PlayerStateController.playerStates.left:
                result = true;
                break;

            case PlayerStateController.playerStates.right:
                result = true;
                break;
        }
        return result;
    }

}
