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
        ScoreText.text = UserScore.ToString();
    }
}
