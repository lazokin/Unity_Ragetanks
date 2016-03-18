using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour
{
    public float walkingSpeed = 0.45f;
    public TakeDamageFromPlayerBullet takeDamageFromPlayerBullet = null;
    public GameObject deathParticleSystemPrefab = null;
    private bool walkingLeft = true;

    public delegate void enemyEventHandler(int scoreMod);
    public static event enemyEventHandler enemyDied;

    public void OnEnable()
    {
        takeDamageFromPlayerBullet.HitByPlayerBullet += OnHitByPlayerBullet;
    }

    public void OnDisable()
    {
        takeDamageFromPlayerBullet.HitByPlayerBullet -= OnHitByPlayerBullet;
    }

    public void Start()
    {
        walkingLeft = (UnityEngine.Random.Range(0, 2) == 1);
        updateVisualWalkOrientation();
    }

    public void Update()
    {
        if (walkingLeft)
        {
            transform.Translate(new Vector3(-walkingSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
        else
        {
            transform.Translate(new Vector3(+walkingSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
    }

    public void switchDirections()
    {
        walkingLeft = !walkingLeft;
        updateVisualWalkOrientation();
    }

    private void updateVisualWalkOrientation()
    {
        Vector3 localScale = transform.localScale;
        if (walkingLeft)
        {
            if (localScale.x > 0.0f)
            {
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }
        else
        {
            if (localScale.x < 0.0f)
            {
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }
    }

    private void OnHitByPlayerBullet()
    {
        GameObject deathParticle = (GameObject)Instantiate(deathParticleSystemPrefab);
        Vector3 enemyPos = transform.position;
        Vector3 particlePos = new Vector3(enemyPos.x, enemyPos.y, enemyPos.z + 1.0f);
        deathParticle.transform.position = particlePos;
        if (enemyDied != null)
        {
            enemyDied(25);
        }
        Destroy(gameObject, 0.1f);
    }
}
