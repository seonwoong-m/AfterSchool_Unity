using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Enemy : MonoBehaviour
{
    StageManager SM;
    Clicker clicker;
    DataManager dataM;

    public float speed = 10f;
    public float hp;
    public int enemyCount = 10;

    void Start()
    {
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        hp = SM.killReward * 2;
    }

    void Update()
    {
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        gameObject.transform.Translate(UnityEngine.Vector3.left * speed * Time.deltaTime, Space.World);

        if(gameObject.transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
            SM.enemy_L.RemoveAt(0);
        }
    }

    public void Damaged()
    {
        clicker = GameObject.Find("Clicker").GetComponent<Clicker>();
        dataM = GameObject.Find("DataManager").GetComponent<DataManager>();
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        
        hp -= clicker.power;

        if(hp <= 0)
        {
            Destroy(this.gameObject);
            SM.enemy_L.RemoveAt(0);
            enemyCount--;
            dataM.gold += (BigInteger)SM.killReward;
        }

        if(enemyCount == 0)
        {
            enemyCount = 10;
            SM.StageLevelUP();
        }
    }

}
