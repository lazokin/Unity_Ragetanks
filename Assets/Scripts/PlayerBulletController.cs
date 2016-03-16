using UnityEngine;
using System.Collections;

public class PlayerBulletController : MonoBehaviour
{
    public GameObject playerObject = null;
    public float bulletSpeed = 15.0f;

    public void launchBullet()
    {
        float mainXScale = playerObject.transform.localScale.x;
        Vector2 bulletVelocity;
        if (mainXScale < 0.0f)
        {
            bulletVelocity = new Vector2(-bulletSpeed, 0.0f);
        }
        else
        {
            bulletVelocity = new Vector2(+bulletSpeed, 0.0f);
        }
        GetComponent<Rigidbody2D>().velocity = bulletVelocity; 
    }

}
