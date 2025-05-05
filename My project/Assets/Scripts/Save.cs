using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class Save : MonoBehaviour
{
    ItemSelector _iSelector;

    List <VisualElement> _loadout_load;
    List <VisualElement> _loadout_save;

    VisualElement root;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("SaveStart");
        _iSelector = GetComponent <ItemSelector> ();
        _loadout_load = new List <VisualElement> ();
        _loadout_save = new List <VisualElement> ();

        root = GetComponent<UIDocument>().rootVisualElement;

        List<VisualElement> loadouts = root.Q("Loadouts").Children().ToList();

        int i = 0;
        foreach (VisualElement visualElement in loadouts)
        {
            int temp = i;
            List<VisualElement> options = visualElement.Children().ToList();
            SaveData data = new();

            if (File.Exists(Application.persistentDataPath + "/loadout_" + temp + ".json"))
            {
                Debug.Log("It Lives");
                data = JsonHelper.FromJson(File.ReadAllText(Application.persistentDataPath + "/loadout_" + temp + ".json"));
            }

            //Debug.Log("soulname: " + data.soulname);
            //Debug.Log("fullname: " + (temp+1).ToString() + " - " + data.soulname);

            options[0].Q<Label>("Label").text = (temp + 1).ToString() + " - " + data.soulname; // TODO: Connect to loadout soul name
            options[0].RegisterCallback<ClickEvent, int>(LoadLoadout, temp);

            options[1].RegisterCallback<ClickEvent, int>(SaveLoadout, temp);
            options[2].RegisterCallback<ClickEvent, int>(DeleteLoadout, temp);
            i++;
        }
    }

    void LoadLoadout(ClickEvent evt,int num)
    {
        SaveData data = JsonHelper.FromJson(File.ReadAllText(Application.persistentDataPath + "/loadout_" + num + ".json"));
        _iSelector.Items = data.items;
    }
    void SaveLoadout(ClickEvent evt, int num)
    {
        SaveData data = new();
        data.items = _iSelector.Items; //items[2] for soul
        if (data.items[2] != -1)  data.soulname = (root.Q("Menu3").Children().ToList()[2] as Item).name;
        root.Q("Loadout"+(num+1).ToString()).Q<Label>("Label").text = (num + 1).ToString() + " - " + data.soulname;

        System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(data));
    }
    void DeleteLoadout(ClickEvent evt, int num)
    {
        SaveData data = new();
        root.Q("Loadout" + (num + 1).ToString()).Q<Label>("Label").text = (num + 1).ToString() + " - None";

        System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(data));
    }
}
