using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using StatDictionary = System.Collections.Generic.Dictionary<Stats, int>;

public class Item
{
    public enum ItemType
    {
        Relic,
        Soul,
        Weapon
    }

    protected string _name; // Nombre del objeto (También actúa como identificador para la imagen)
    protected string _flavour; // Breve texto descriptivo (Se puede omitir)
    protected ItemType _type; // Tipo del objeto
    protected StatDictionary _stats; // Estadísticas otorgadas por el objeto
    protected string _description; // Texto del objeto representado bajo la imagen

    public void OnEquip() // Se llama antes de aplicar las estadísticas, para el cálculo de efectos que lo necesiten.
    {

    }
    public void OnUnequip()
    {

    }
}
