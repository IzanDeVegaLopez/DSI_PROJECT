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
            SaveData data = new SaveData ();
            if (File.Exists(Application.persistentDataPath + "/loadout_" + temp + ".json")) 
                data = JsonHelper.FromJson(File.ReadAllText(Application.persistentDataPath + "/loadout_" + temp + ".json"));
            //Debug.Log("Continue");
            options[0].Q<Label>("Label").text = temp + " - " + data.soulname != null ? data.soulname : "None"; // TODO: Connect to loadout soul name
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
        SaveData data;
        data.items = _iSelector.Items; //items[2] for soul
        data.soulname = (root.Q("Menu3").Children().ToList()[2] as Item).name;
        System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(data));
    }
    void DeleteLoadout(ClickEvent evt, int num)
    {
        SaveData data = new SaveData();
        System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(data));
    }
}
