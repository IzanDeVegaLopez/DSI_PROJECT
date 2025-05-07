using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SaveData
{
    public string soulname;
    public int[] items;
    public SaveData(string soul = "NONE")
    {
        soulname = soul;
        items = new int[3] { -1, -1, -1 };
    }
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
