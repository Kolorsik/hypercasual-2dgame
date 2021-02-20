using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float SpawnRate = 2f;
    public GameObject Enemy;
    public static int CountEnemy;

    private float Timer;
    private float R, G, B;


    void Start()
    {
        Timer = SpawnRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Vector2 v2s = Enemy.transform.localScale;
            v2s.x = Random.Range(1f, 1.6f);
            Enemy.transform.localScale = v2s;

            Vector2 v2p = new Vector2(-4.5f, Random.Range(-1.5f, 1.5f));
            GameObject tempEnemy = Instantiate(Enemy, v2p, Quaternion.identity);
            switch (Random.Range(1, 4))
            {
                case 1:
                    {
                        tempEnemy.AddComponent<EnemyRotation>();
                        break;
                    }
                case 2:
                    {
                        tempEnemy.AddComponent<EnemySlowRotation>();
                        break;
                    }
                case 3:
                    {
                        tempEnemy.AddComponent<EnemyIdle>();
                        break;
                    }
            }
            tempEnemy.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Timer = SpawnRate;
        }
    }
}
