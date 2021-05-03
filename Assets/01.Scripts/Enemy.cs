using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;   

public class Enemy : MonoBehaviour
{
    StageManager smCS;
    Clicker clickerCS;
    DataManager dataCS;
    Enemy enemyCS;

    public float speed = 0f;
    public float hp;
    public int enemyCount = 10;   
    float rHP;

    void Start()
    {
        smCS = GameObject.Find("StageManager").GetComponent<StageManager>();
        hp = Random.Range((smCS.killReward * 2), (smCS.killReward * 4));
        speed = Random.Range(3, 5);
    }

    void Update()
    {

        smCS = GameObject.Find("StageManager").GetComponent<StageManager>();
        dataCS = GameObject.Find("DataManager").GetComponent<DataManager>();
        clickerCS = GameObject.Find("Clicker").GetComponent<Clicker>();
        

        gameObject.transform.Translate(UnityEngine.Vector3.left * speed * Time.deltaTime, Space.World);

        if(gameObject.transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
            smCS.enemyList.RemoveAt(0);
            clickerCS.gold.text = clickerCS.Money((BigInteger)dataCS.gold, clickerCS.gold);
        }
    }

    public void Damaged(GameObject enemy)
    {
        clickerCS = GameObject.Find("Clicker").GetComponent<Clicker>();
        dataCS = GameObject.Find("DataManager").GetComponent<DataManager>();
        smCS = GameObject.Find("StageManager").GetComponent<StageManager>();

        enemy.GetComponent<Enemy>().hp -= clickerCS.power;

        if(enemy.GetComponent<Enemy>().hp <= 0)
        {
            Destroy(this.gameObject);
            enemyCount--;
            smCS.enemyList.RemoveAt(0);
            dataCS.gold += (BigInteger)smCS.killReward;
        }

        if(enemyCount == 0)
        {
            enemyCount = 10;
            smCS.StageLevelUP();
        }
    }
}
