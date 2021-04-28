using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StageManager : MonoBehaviour
{
    public GameObject enemy;
    

    float RandomY;
    Vector3 RandomPos;
    float timer = 0.5f;

    public float killReward;
    public int stageLevel = 1;

    void SpawnEnemy()
    {
        RandomY = UnityEngine.Random.Range(-4.5f, 4.5f);

        RandomPos = new Vector3(9.5f, RandomY, 0);

        timer -= Time.deltaTime;

        if(timer <= 0.0f)
        {
            Instantiate(enemy, RandomPos, Quaternion.identity);
            timer = 0.5f;
        }
    }

    public void StageLevelUP()
    {
        stageLevel++;
    }

    void Start()
    {
        killReward = (float)(10 * ((Math.Pow(1.06, 10) - Math.Pow(1.06, 10 + stageLevel)) / (1 - 1.06)));
    }

    void Update()
    {
        SpawnEnemy();
    }
}
