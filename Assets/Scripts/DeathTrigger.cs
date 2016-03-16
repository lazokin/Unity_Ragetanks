using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("hitDeathTrigger", SendMessageOptions.DontRequireReceiver);
    }
}
