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
        resurrect
    }

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
            else
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
    }
}
