using UnityEngine;
using System.Collections;

public class PlayerColliderListener : MonoBehaviour
{
    public PlayerStateListener targetStateListener = null;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Platform":
                targetStateListener.OnStateChange(PlayerStateController.playerStates.landing);
                break;

            case "DeathTrigger":
                targetStateListener.OnStateChange(PlayerStateController.playerStates.kill);
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Platform":
                targetStateListener.OnStateChange(PlayerStateController.playerStates.falling);
                break;
        }
    }
}
