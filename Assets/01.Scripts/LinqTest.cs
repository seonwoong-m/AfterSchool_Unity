using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqTest : MonoBehaviour
{
    public void LinqSample()
    {
        int[] scores = new int[] {97, 92, 81, 60};

        IEnumerable<int> scoreQuery = from score in scores where score > 80 select score;

        foreach (int i in scoreQuery)
        {
            Debug.Log(i + " ");
        }
    }

    public void LinqSample2()
    {
        int[] scores = new int[] { 97, 92, 81, 60};

        foreach (int i in scores.Where(x => x > 80))
        {
            Debug.Log(i + " ");
        }
    }

    void Start()
    {
        LinqSample();
    }
}
