using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float SpawnRate = 2f;
    public GameObject Enemy;
    public static int CountEnemy;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CountEnemy < 5)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 v2 = new Vector2(-4.5f, Random.Range(-1.5f, 1.5f));
        Instantiate(Enemy, v2, Quaternion.identity);
        CountEnemy++;
        yield return new WaitForSeconds(SpawnRate);
    }
}
