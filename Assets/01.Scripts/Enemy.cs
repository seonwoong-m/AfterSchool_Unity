using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    StageManager SM;

    public float speed = 10f;

    void Update()
    {
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if(gameObject.transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
            SM.enemy_L.RemoveAt(0);
        }
    }


}
