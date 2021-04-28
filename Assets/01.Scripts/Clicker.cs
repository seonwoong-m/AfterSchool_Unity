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
    public Text levelUPBtn;
    public Text gold;
    public Text playerLevel_T;
    public Text playerPower;
    DataManager dataM;
    StageManager SM;
    Enemy enemy;

    public float levelUpCost;
    public float power;
    float touchDelay = 0.1f;
    public int playerLevel = 1;

    void Start()         
    {
        dataM = GameObject.Find("DataManager").GetComponent<DataManager>();

        levelUpCost = (float)(50 * (Math.Pow(1.07, playerLevel - 1)));
        power = levelUpCost * 0.4f;
        levelUPBtn.text = $"LevelUp Cost : {(BigInteger)levelUpCost}";
        gold.text = Money((BigInteger)dataM.gold, gold);
        playerLevel_T.text = $"Lv. : {(BigInteger)playerLevel}";
        playerPower.text = $"PlayerPower : {(BigInteger)power}";
        touchDelay = 0f;
    }

    public void LevelUp()
    {
            dataM = GameObject.Find("DataManager").GetComponent<DataManager>();

            if ((float)dataM.gold >= levelUpCost)
            {
                dataM.gold -= (BigInteger)levelUpCost;
                playerLevel += 1;
                Debug.Log((int)playerLevel);
            }



            levelUpCost = (float)(50 * (Math.Pow(1.07f, playerLevel - 1)));
            power = levelUpCost * 0.4f;
            levelUPBtn.text = $"LevelUp Cost : {(BigInteger)levelUpCost}";
            gold.text = Money((BigInteger)dataM.gold, gold);
            playerLevel_T.text = $"Lv. {(BigInteger)playerLevel}";
            playerPower.text = $"Power : {(BigInteger)power}";
    }

    public void OnClickAtk()
    {
        enemy_L = new List<GameObject>();
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

        if (enemy_L[0] == null)
        {
            SM.enemy = enemy_L[0];
        }

        if (SM.enemy == enemy_L[0])
        {
            enemy.Damaged(enemy_L);
        }
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