using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class CreateRandomId1 : MonoBehaviour
{
    public static List<int> ids = new List<int>();
    private static int min = 1000;
    private static int max = 10000;

    public static void AddToList()
    {
        ids.Add(UniqueRandomInt());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ids.Add(UniqueRandomInt());
        }
    }

    List<int> usedValues = new List<int>();
    /*public int UniqueRandomInt(int min, int max)
    {
        int val = UnityEngine.Random.Range(min, max);
        while(usedValues.Contains(val))
        {
            val = UnityEngine.Random.Range(min, max);
        }
        return val;
    }*/
    public static int UniqueRandomInt()
    {
        int val = UnityEngine.Random.Range(min, max);
        while(ids.Contains(val))
        {
            val = UnityEngine.Random.Range(min, max);
        }
        return val;
    }
    
    public static List<int> GenerateRandom(int count, int min, int max)
    {
        Random random = new Random();
        if (max <= min || count < 0 ||
            (count > max - min && max - min > 0))
        {
            throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                                                  " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
        }
 
        HashSet<int> candidates = new HashSet<int>();
 
        for (int top = max - count; top < max; top++)
        {
            if (!candidates.Add(random.Next(min, top + 1)))
            {
                candidates.Add(top);
            }
        }
 
        List<int> result = candidates.ToList();
 
        for (int i = result.Count - 1; i > 0; i--)
        {
            int k = random.Next(i + 1);
            int tmp = result[k];
            result[k] = result[i];
            result[i] = tmp;
        }
        return result;
    }
}
