using UnityEngine;
using System.Collections;

public class PlayerStateController : MonoBehaviour
{
    public enum playerStates
    {
        idle = 0,
        left,
        right,
        jump,
        landing,
        falling,
        kill,
        resurrect,
        firingWeapon,
        _stateCount
    }

    public static float[] stateDelayTimer = new float[(int)playerStates._stateCount];

    public delegate void PlayerStateChangeHandler(PlayerStateController.playerStates newState);
    public static event PlayerStateChangeHandler StateChange;


    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            if (horizontal < 0f)
            {
                if (StateChange != null)
                {
                    StateChange(PlayerStateController.playerStates.left);
                }
            }
            if (horizontal > 0f)
            {
                if (StateChange != null)
                {
                    StateChange(PlayerStateController.playerStates.right);
                }
            }
        }
        else
        {
            if (StateChange != null)
            {
                StateChange(PlayerStateController.playerStates.idle);
            }
        }

        float jump = Input.GetAxis("Jump");
        if (jump > 0.0f)
        {
            if (StateChange != null)
            {
                StateChange(PlayerStateController.playerStates.jump);
            }
        }

        float firing = Input.GetAxis("Fire1");
        if (firing > 0.0f)
        {
            if (StateChange != null)
            {
                StateChange(PlayerStateController.playerStates.firingWeapon);
            }
        }
    }
}
