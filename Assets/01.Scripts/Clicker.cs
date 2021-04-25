using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Numerics;

public class Clicker : MonoBehaviour
{
    public GameObject destroyEffect;
    DataManager dataM;
    StageManager SM;
    Enemy enemy;

    public float levelUpCost;
    public float power;
    float touchDelay;
    public int playerLevel = 1;

    void Start()
    {
        levelUpCost = (float)(50 * (Math.Pow(1.07, playerLevel - 1)));
        power = levelUpCost * 0.4f;
    }

    void LevelUp()
    {
        dataM = GameObject.Find("DataManager").GetComponent<DataManager>();

        if((float)dataM.gold >= levelUpCost)
        {
            dataM.gold -= (BigInteger)levelUpCost;
            playerLevel += 1;
        }

        levelUpCost = (float)(50 * (Math.Pow(1.07f, playerLevel - 1)));
        power = levelUpCost * 0.4f;
    }

    public void OnClickAtk()
    {
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

        if(SM.enemy == SM.enemy_L[0])
        {
            enemy.Damaged();
        }
    }
}
