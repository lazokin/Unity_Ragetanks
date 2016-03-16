using UnityEngine;
using System.Collections;

public class TakeDamageFromPlayerBullet : MonoBehaviour
{
    public delegate void HitByPlayerBulletHandler();
    public event HitByPlayerBulletHandler HitByPlayerBullet;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            if (HitByPlayerBullet != null)
            {
                HitByPlayerBullet();
            }
        }
    }
}
