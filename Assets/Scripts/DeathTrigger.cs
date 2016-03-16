using UnityEngine;
using System.Collections;

public class DeathTriggerScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("hitDeathTrigger");
    }
}
