using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    void Start()
    {
        SaveData();
    }

    public void SaveData()
    {
        PlayerData myData = new PlayerData();
        StageManager SM = new StageManager();
        Clicker clicker = new Clicker();

        myData.playerLevel = clicker.playerLevel;
        myData.stageLevel = SM.stageLevel;
    }
}
