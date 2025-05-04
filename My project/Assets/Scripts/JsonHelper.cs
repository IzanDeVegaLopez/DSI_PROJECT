using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static string ToJson(List<Item> items, bool pretty_print = true)
    {
        return JsonUtility.ToJson(items, true);
    }

    public static List<Item> FromJson(string json)
    {
        return JsonUtility.FromJson<List<Item>>(json);
    }
}
