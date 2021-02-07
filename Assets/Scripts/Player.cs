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
