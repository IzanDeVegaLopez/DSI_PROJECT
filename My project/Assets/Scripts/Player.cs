using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using StatDictionary = System.Collections.Generic.Dictionary<Stats, int>;
public enum Stats
{
    Determination,
    Vigor,
    Serenity,
    Agility,
    Hope,
    Hate
}

public class Player
{
    public enum Race
    {
        Human,
        Elf,
        Dwarf,
        Orc
    }

    private string _name; // Nombre del objeto (También actúa como identificador para la imagen)
    private Race _race; // Raza del jugador

    private Soul.SoulSubtype _path; // Clase del jugador (Obtenida del objeto Soul equipado)
    private int _level;
    private int _exp;
    private int _exp_next_level;

    private StatDictionary _stats; // Estadísticas del jugador

    #region parameters
    private int _health; 
    private int _mana;

    private int _attack_damage;
    private int _attack_speed; // Representado como un decimal con dos cifras decimales.

    private int _dps; // Representado como un decimal con dos cifras decimales.
     
    private int _buff_potency; // Representado como un decimal con dos cifras decimales.
    private int _debuff_potency; // Representado como un decimal con dos cifras decimales.
    #endregion

    #region equipment
    private Weapon _weaponL;
    private Weapon _weaponR;
    private Relic _relic;
    private Soul _soul;
    #endregion
    public void RecalculateParameters()
    {
        _health = _stats[Stats.Determination] * 100 + _level * 10;
        _mana = _stats[Stats.Serenity] * 75 + _level * 5;

        _attack_damage = (_weaponL.BaseDamage * _stats[Stats.Vigor])/10; // Cálculo con WeaponR pendiente
        _attack_speed = (_weaponL.Speed * _stats[Stats.Agility] * 2 / 10 + (_weaponL.Speed * _stats[Stats.Agility])); // Cálculo con WeaponR pendiente

        _dps = _attack_damage * _attack_speed; // Cálculo con WeaponR pendiente

        _buff_potency = _stats[Stats.Hope] - 5;
        _debuff_potency = (_stats[Stats.Hate] - 10) * 5;
    }
}
