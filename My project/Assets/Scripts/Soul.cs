using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatDictionary = System.Collections.Generic.Dictionary<Stats, int>;

public class Soul : Item
{
    public enum SoulSubtype
    {
        Harrower,
        Sage // Habría otras idealmente, pero no quiero infravalorar la carga de trabajo
    }

    private SoulSubtype subtype;

    private int _level;
    private int _exp;
    private int _exp_next_level; // Puede falsearse, o hacer una función para calcularlo.

    Soul()
    {
        _type = ItemType.Soul;
    }

} 
