﻿using System.Collections;
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
        TopGoal.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), 3.2f);
        DownGoal.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), -3.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionName = collision.gameObject.name;
        if (collisionName.Contains("Goal"))
        {
            Score.UserScore++;
            
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
