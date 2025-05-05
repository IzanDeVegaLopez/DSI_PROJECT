using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct SaveData
{
    public string soulname;
    public int[] items;
}
public class JsonHelper
{
    public static string ToJson(SaveData sd, bool pretty_print = true)
    {
        return JsonUtility.ToJson(sd, true);
    }

    public static SaveData FromJson(string json)
    {
        return JsonUtility.FromJson<SaveData>(json);
    }
}
