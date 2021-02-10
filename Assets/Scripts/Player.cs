using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject TopGoal;
    public GameObject DownGoal;
    public GameObject DeadParticles;
    public GameObject GameScore;
    public GameObject EndScore;
    public GameObject EndBackground;
    public GameObject TapButton;

    private Text EndScoreText;
    private Animator EndBackgroundAnimator;
    private Animator GameScoreAnimator;

    private bool Check;

    public float Speed = 0.1f;

    void Start()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                {
                    Check = false;
                    DownGoal.SetActive(true);
                    break;
                }
            case 2:
                {
                    Check = true;
                    TopGoal.SetActive(true);
                    break;
                }
        }

        TopGoal.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), 3.2f);
        DownGoal.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), -3.2f);
        EndScoreText = EndScore.GetComponent<Text>();
        EndBackgroundAnimator = EndBackground.GetComponent<Animator>();
        GameScoreAnimator = GameScore.GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        string collisionName = collision.gameObject.name;
        if (collisionName.Contains("Platform"))
        {
            Change();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionName = collision.gameObject.name;
        if (collisionName.Contains("Enemy"))
        {
            GameObject deadParticle = Instantiate(DeadParticles, collision.transform.position, Quaternion.identity);
            deadParticle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            GameScore.SetActive(false);
            TapButton.SetActive(false);
            EndBackground.SetActive(true);
            EndBackgroundAnimator.Play("EndBackgroundIn");
            EndScoreText.text = "Твои очки: " + Score.UserScore.ToString();
            SaveSystem.SaveScore(Score.UserScore);
        }

        if (collisionName.Contains("Goal"))
        {
            Score.UserScore++;
            GameScoreAnimator.Play("AddScore");
            if (collisionName.Equals("DownGoal"))
            {
                DownGoal.SetActive(false);

                TopGoal.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), 3.2f); 
                TopGoal.SetActive(true);
            }
            else
            {
                TopGoal.SetActive(false);

                DownGoal.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), -3.2f);
                DownGoal.SetActive(true);
            }
        }

        if (collisionName.Contains("Platform"))
        {
            Change();   
        }
    }


    void FixedUpdate()
    {
        if (Check)
        {
            transform.position = Vector3.MoveTowards(transform.position, TopGoal.transform.position, Speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, DownGoal.transform.position, Speed);
        }

        transform.rotation *= Quaternion.Euler(0f, 0f, 1.9f);
    }

    public void Change()
    {
        Check = !Check;
    }
}
