using UnityEngine;
using System.Collections;

public class ScoreWatcher : MonoBehaviour
{

    public int currScore = 0;
    private TextMesh scoreMesh = null;

	void Start ()
    {
        scoreMesh = GetComponent<TextMesh>();
        scoreMesh.text = "0";
	}

    void OnEnable()
    {
        EnemyController.enemyDied += AddScore;
    }

    void OnDisabled()
    {
        EnemyController.enemyDied -= AddScore;
    }

    void AddScore(int scoreToAdd)
    {
        currScore += scoreToAdd;
        scoreMesh.text = currScore.ToString();
    }

}
