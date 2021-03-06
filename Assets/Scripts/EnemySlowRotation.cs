﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowRotation : MonoBehaviour
{
    public float Speed = 0.04f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + Speed, transform.position.y);
        transform.rotation *= Quaternion.Euler(0f, 0f, 0.9f);
    }
}
