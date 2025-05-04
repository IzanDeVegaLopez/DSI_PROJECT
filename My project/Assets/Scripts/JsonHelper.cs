using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static string ToJson(int[] items, bool pretty_print = true)
    {
        return JsonUtility.ToJson(items, true);
    }

    public static int[] FromJson(string json)
    {
        return JsonUtility.FromJson<int[]>(json);
    }
}
