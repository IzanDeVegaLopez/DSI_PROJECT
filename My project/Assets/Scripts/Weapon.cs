using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatDictionary = System.Collections.Generic.Dictionary<Stats, int>;

public class Weapon : Item
{
    public enum WeaponSubtype
    {
        Light_Sword,
        Heavy_Sword,
        Spear,
        Axe,
        Mace,
        Staff,
        Grimoire
    }


    private WeaponSubtype subtype;
    public int BaseDamage
    {
        get { return _base_damage; }
    }
    private int _base_damage;
    public int Speed
    {
        get { return _speed; }
    }
    private int _speed; // Representado como un decimal con dos cifras decimales.
}
