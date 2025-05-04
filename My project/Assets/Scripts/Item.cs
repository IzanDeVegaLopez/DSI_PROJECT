using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

[Serializable]
public class Item : VisualElement
{
    public int Id
    {
        get { return id; }
        set
        {
            if (value != id)
            {
                id = value;
            }
        }
    }
    public string Nombre
    {
        get { return nombre; }
        set
        {
            if(value != nombre)
            {
                nombre = value;
                //Cambio?.Invoke();
            }
        }
    }
    public string Flavour
    {
        get { return flavour; }
        set
        {
            if (value != flavour)
            {
                flavour = value;
                //Cambio?.Invoke();
            }
        }
    }

    public string File
    {
        get => file;
        set
        {
            if (value != file)
            {
                file = value;
                this.style.backgroundImage = Resources.Load<Texture2D>(file);
            }
        }
    }
    public int Determination
    {
        get { return determination; }
        set
        {
            if (value != determination)
            {
                determination = value;
                //Cambio?.Invoke();
            }
        }
    }
    public int Vigor
    {
        get { return vigor; }
        set
        {
            if (value != vigor)
            {
                vigor = value;
                //Cambio?.Invoke();
            }
        }
    }
    public int Serenity
    {
        get { return serenity; }
        set
        {
            if (value != serenity)
            {
                serenity = value;
                //Cambio?.Invoke();
            }
        }
    }
    public int Agility
    {
        get { return agility; }
        set
        {
            if (value != agility)
            {
                agility = value;
                //Cambio?.Invoke();
            }
        }
    }
    public int Hope
    {
        get { return hope; }
        set
        {
            if (value != hope)
            {
                hope = value;
                //Cambio?.Invoke();
            }
        }
    }
    public int Hate
    {
        get { return hate; }
        set
        {
            if (value != hate)
            {
                hate = value;
                //Cambio?.Invoke();
            }
        }
    }
    [FormerlySerializedAs("Nombre")]
    [SerializeField]
    protected string nombre;
    [FormerlySerializedAs("Flavour")]
    [SerializeField]
    protected string flavour;
    [FormerlySerializedAs("File")]
    [SerializeField]
    protected string file = "sprite/placeholder";
    [FormerlySerializedAs("Determination")]
    [SerializeField]
    protected int determination;
    [FormerlySerializedAs("Vigor")]
    [SerializeField]
    protected int vigor;
    [FormerlySerializedAs("Serenity")]
    [SerializeField]
    protected int serenity;
    [FormerlySerializedAs("Agility")]
    [SerializeField]
    protected int agility;
    [FormerlySerializedAs("Hope")]
    [SerializeField]
    protected int hope;
    [FormerlySerializedAs("Hate")]
    [SerializeField]
    protected int hate;
    [FormerlySerializedAs("Id")]
    [SerializeField]
    protected int id;


    public new class UxmlFactory : UxmlFactory<Item, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription nombre = new UxmlStringAttributeDescription { name = "Nombre", defaultValue = "no name"};
        UxmlStringAttributeDescription flavour = new UxmlStringAttributeDescription { name = "Flavour", defaultValue = "" };
        UxmlStringAttributeDescription file = new UxmlStringAttributeDescription { name = "File", defaultValue = "" };
        UxmlIntAttributeDescription determination = new UxmlIntAttributeDescription { name = "Determination", defaultValue = 0 };
        UxmlIntAttributeDescription vigor = new UxmlIntAttributeDescription { name = "Vigor", defaultValue = 0 };
        UxmlIntAttributeDescription serenity = new UxmlIntAttributeDescription { name = "Serenity", defaultValue = 0 };
        UxmlIntAttributeDescription agility = new UxmlIntAttributeDescription { name = "Agility", defaultValue = 0 };
        UxmlIntAttributeDescription hope = new UxmlIntAttributeDescription { name = "Hope", defaultValue = 0 };
        UxmlIntAttributeDescription hate = new UxmlIntAttributeDescription { name = "Hate", defaultValue = 0 };
        UxmlIntAttributeDescription id = new UxmlIntAttributeDescription { name = "Id", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var item = ve as Item;
            item.Nombre = nombre.GetValueFromBag(bag, cc);
            item.Flavour = flavour.GetValueFromBag(bag, cc);
            item.File = file.GetValueFromBag(bag, cc);
            item.Determination = determination.GetValueFromBag(bag, cc);
            item.Vigor = vigor.GetValueFromBag(bag,cc);
            item.Serenity = serenity.GetValueFromBag(bag, cc);
            item.Agility = agility.GetValueFromBag(bag, cc);
            item.Hope = hope.GetValueFromBag(bag, cc);
            item.Hate = hate.GetValueFromBag(bag, cc);
            item.Id = id.GetValueFromBag(bag, cc);
        }
    }

    public Item()
    {
        this.style.width = 200;
        this.style.height = 200;
        this.style.backgroundImage = Resources.Load<Texture2D>(file);
        this.style.backgroundColor = new Color(162f/255, 229f/255, 115f/255,1);
        this.style.alignItems = Align.Stretch;
        this.style.justifyContent = Justify.FlexStart;
        this.style.alignSelf = Align.Auto;

        this.style.marginTop = 30;
        this.style.marginLeft = 30;
    }

    public void AssignItem(VisualElement v)
    {
        Item i = v as Item;
        Nombre = i.Nombre;
        Flavour = i.Flavour;
        File = i.File;
        Determination = i.Determination;
        Vigor = i.Vigor;
        Serenity = i.Serenity;
        Agility = i.Agility;
        Hope = i.Hope;
        Hate = i.Hate;
    }

    public int[] getStats()
    {
        int[] n = new int[6];
        n[0] = Determination;
        n[1] = Vigor;
        n[2] = Serenity;
        n[3] = Agility;
        n[4] = Hope;
        n[5] = Hate;
        return n;
    }
}
