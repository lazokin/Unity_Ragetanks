using UnityEngine;
using System.Collections;

public class EnemyRespawner : MonoBehaviour
{

    public GameObject spawnEnemy = null;
    float respawnTime = 0.0f;

    void OnEnable()
    {
        EnemyController.enemyDied += scheduleRespawn;
    }

    void OnDisable()
    {
        EnemyController.enemyDied -= scheduleRespawn;
    }

    void scheduleRespawn(int enemyScore)
    {
        if (Random.Range(0, 10) < 5)
        {
            return;
        }
        respawnTime = Time.time + 4.0f;
    }

    void Update()
    {
        if (respawnTime > 0.0f)
        {
            if (Time.time > respawnTime)
            {
                respawnTime = 0.0f;
                GameObject newEnemy = Instantiate(spawnEnemy) as GameObject;
                newEnemy.transform.position = transform.position;
            }
        }
    }
}
