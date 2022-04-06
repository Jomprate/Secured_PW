using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public static class CreateRandomId 
{
    public static List<int> ids = new List<int>();
    
    private static int min = 1000000;
    private static int max = 9999999;

    public static int UniqueRandomInt()
    {
        int val = UnityEngine.Random.Range(min, max);
        while(ids.Contains(val))
        {
            val = UnityEngine.Random.Range(min, max);
        }
        ids.Add(val);
        return val;
    }
    
    
}
