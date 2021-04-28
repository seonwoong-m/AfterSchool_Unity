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
        dataM = GameObject.Find("DataManager").GetComponent<DataManager>();
        clicker = GameObject.Find("Clicker").GetComponent<Clicker>();

        gameObject.transform.Translate(UnityEngine.Vector3.left * speed * Time.deltaTime, Space.World);

        if(gameObject.transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
#if UNITY_EDITOR
            dataM.gold += 248248248248248248;
            dataM.gold += 248248248248248248;
            dataM.gold += 248248248248248248;
            dataM.gold += 248248248248248248;
            dataM.gold += 248248248248248248;
            dataM.gold += 248248248248248248;
            dataM.gold += 248248248248248248;
            dataM.gold += 248248248248248248;
#endif
            clicker.gold.text = clicker.Money((BigInteger)dataM.gold, clicker.gold);
}
    }

    public void Damaged(List<GameObject> enemy_L)
    {
        clicker = GameObject.Find("Clicker").GetComponent<Clicker>();
        dataM = GameObject.Find("DataManager").GetComponent<DataManager>();
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();

        hp -= clicker.power;

        if(hp <= 0)
        {
            Destroy(this.gameObject);
            enemy_L.RemoveAt(0);
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
