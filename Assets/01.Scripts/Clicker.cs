using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Numerics;
using UnityEngine.UI;
using System.Globalization;

public class Clicker : MonoBehaviour
{
    public List<GameObject> enemy_L;

    public GameObject destroyEffect;
    public GameObject targeting;
    public Text levelUPBtn;
    public Text gold;
    public Text playerLevel_T;
    public Text playerPower;
    DataManager dataCS;
    StageManager smCS;
    Enemy enemyCS;

    public float levelUpCost;
    public float power;
    float touchDelay = 0.1f;
    public int playerLevel = 1;
    public float shortDis;

    void Start()
    {
        dataCS = GameObject.Find("DataManager").GetComponent<DataManager>();

        levelUpCost = (float)(50 * (Math.Pow(1.07, playerLevel - 1)));
        power = levelUpCost * 0.4f;
        levelUPBtn.text = $"LevelUp Cost : {(BigInteger)levelUpCost}";
        gold.text = Money((BigInteger)dataCS.gold, gold);
        playerLevel_T.text = $"Lv. : {(BigInteger)playerLevel}";
        playerPower.text = $"PlayerPower : {(BigInteger)power}";
        touchDelay = 0f;
    }

    public void LevelUp()
    {
        dataCS = GameObject.Find("DataManager").GetComponent<DataManager>();

        if ((float)dataCS.gold >= levelUpCost)
        {
            dataCS.gold -= (BigInteger)levelUpCost;
            playerLevel += 1;
            Debug.Log((int)playerLevel);
        }



        levelUpCost = (float)(50 * (Math.Pow(1.07f, playerLevel - 1)));
        power = levelUpCost * 0.4f;
        levelUPBtn.text = $"LevelUp Cost : {(BigInteger)levelUpCost}";
        gold.text = Money((BigInteger)dataCS.gold, gold);
        playerLevel_T.text = $"Lv. {(BigInteger)playerLevel}";
        playerPower.text = $"Power : {(BigInteger)power}";
    }

    public void OnClickAtk()
    {
        smCS = GameObject.Find("StageManager").GetComponent<StageManager>();
        enemyCS = GameObject.Find("Enemy").GetComponent<Enemy>();

        shortDis = UnityEngine.Vector3.Distance(transform.position, smCS.enemyList[0].transform.position);
   
        foreach (GameObject found in smCS.enemyList)
        {
            float distance = UnityEngine.Vector3.Distance(transform.position, found.transform.position);
            if (distance < shortDis)
            {
                targeting = found;
                shortDis = distance;
            }
        }

        targeting.GetComponent<Enemy>().Damaged(targeting);
    }

    public string Money(BigInteger num, Text text)
    {
        if (num / 1000 >= 1 && num / 1000 <= 1000)
            text.text = "Gold : " + $"{num / 1000:0K}";
        else if (num / 1000 >= 1000 && num / 1000 <= 1000000)
            text.text = "Gold : " + $"{num / 1000000:0M}";
        else if (num / 1000 >= 1000000 && num / 1000 <= 1000000000)
            text.text = "Gold : " + $"{num / 1000000000:0B}";
        else if (num / 1000 >= 1000000000 && num / 1000 <= 1000000000000)
            text.text = "Gold : " + $"{num / 1000000000000:0T}";
        else if (num / 1000 >= 1000000000000)
            text.text = "Gold : " + num.ToString("0.##E+0", CultureInfo.InvariantCulture);

        return text.text;
    }
}