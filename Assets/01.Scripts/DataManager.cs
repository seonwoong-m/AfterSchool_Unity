using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class DataManager : MonoBehaviour
{
    #region Singleton Pattern
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = FindObjectOfType<DataManager>();
                if(obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("Singleton Class").AddComponent<DataManager>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<DataManager>();
        if(objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public BigInteger gold;
}
