using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject TopGoal;
    public GameObject DownGoal;

    private bool Check = false;

    public float Speed = 0.1f;

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionName = collision.gameObject.name;
        if (collisionName.Contains("Goal"))
        {
            Score.UserScore++;
            if (collisionName.Equals("DownGoal"))
            {
                collision.gameObject.SetActive(false);
                Vector2 v2p = new Vector2(Random.Range(-1.7f, 1.7f), -3.1f);
                collision.gameObject.transform.position = v2p;
                collision.gameObject.SetActive(true);
            }
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
