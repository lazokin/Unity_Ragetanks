using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class PlayerStateListener : MonoBehaviour
{
    public float playerWalkSpeed = 3f;
    public GameObject playerRespawnPoint = null;

    private Animator playerAnimator = null;
    private PlayerStateController.playerStates currentState = PlayerStateController.playerStates.idle;

    public void OnEnable()
    {
        PlayerStateController.StateChange += OnStateChange;
    }

    public void OnDisable()
    {
        PlayerStateController.StateChange -= OnStateChange;
    }

    public void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void LateUpdate()
    {
        OnStateCycle();
    }

    public void hitDeathTrigger()
    {
        OnStateChange(PlayerStateController.playerStates.kill);
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

            case PlayerStateController.playerStates.kill:
                OnStateChange(PlayerStateController.playerStates.resurrect);
                break;

            case PlayerStateController.playerStates.resurrect:
                OnStateChange(PlayerStateController.playerStates.idle);
                break;
        }
    }

    private void OnStateChange(PlayerStateController.playerStates newState)
    {
        Vector3 localScale = transform.localScale;

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
                playerAnimator.SetBool("Walking", false);
                break;

            case PlayerStateController.playerStates.left:
                playerAnimator.SetBool("Walking", true);
                if (localScale.x > 0.0f)
                {
                    localScale.x *= -1.0f;
                    transform.localScale = localScale;
                }
                break;

            case PlayerStateController.playerStates.right:
                playerAnimator.SetBool("Walking", true);
                if (localScale.x < 0.0f)
                {
                    localScale.x *= -1.0f;
                    transform.localScale = localScale;
                }
                break;

            case PlayerStateController.playerStates.kill:
                break;

            case PlayerStateController.playerStates.resurrect:
                transform.position = playerRespawnPoint.transform.position;
                transform.rotation = Quaternion.identity;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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

            case PlayerStateController.playerStates.kill:
                if (newState == PlayerStateController.playerStates.resurrect)
                {
                    result = true;
                }
                break;

            case PlayerStateController.playerStates.resurrect:
                if (newState == PlayerStateController.playerStates.idle)
                {
                    result = true;
                }
                break;
        }
        return result;
    }

}
