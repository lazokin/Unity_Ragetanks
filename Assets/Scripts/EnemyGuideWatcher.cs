using UnityEngine;
using System.Collections;

public class EnemyGuideWatcher : MonoBehaviour
{

    public EnemyController enemyController = null;

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            enemyController.switchDirections();
        }
    }
}
