using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameData : MonoBehaviour
{
    PlayerData myData;
    StageManager SM;
    Clicker clicker;
    DataManager dataM;

    void Start()
    {
        SaveData();
    }

    public void SaveData()
    {
        myData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        clicker = GameObject.Find("Clicker").GetComponent<Clicker>();
        dataM = GameObject.Find("DataManager").GetComponent<DataManager>();

        myData.playerLevel = clicker.playerLevel;
        myData.stageLevel = SM.stageLevel;
        myData.gold = dataM.gold;

        string str = JsonUtility.ToJson(myData);

        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", JsonUtility.ToJson(str));
    }
}
