using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clicker : MonoBehaviour
{
    public GameObject destroyEffect;
    
    float levelUpCost;
    float power;
    float touchDelay;
    public int playerLevel = 1;

    void Start()
    {
        levelUpCost = (float)(50 * (Math.Pow(1.07, playerLevel - 1)));
    }
}
