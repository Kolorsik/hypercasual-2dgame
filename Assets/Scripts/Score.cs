using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public static int UserScore;

    private void Start()
    {
        UserScore = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (UserScore % 10 == 0)
        {
            Spawn.SpawnRate -= 0.1f;
            EnemyIdle.Speed += 0.005f;
            EnemyRotation.Speed += 0.005f;
            EnemySlowRotation.Speed += 0.005f;
        }
        */
        ScoreText.text = UserScore.ToString();
    }
}
