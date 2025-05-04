using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class Save : MonoBehaviour
{
    List <VisualElement> _loadout_load;
    List <VisualElement> _loadout_save;

    // Start is called before the first frame update
    void Start()
    {
        _loadout_load = new List <VisualElement> ();
        _loadout_save = new List <VisualElement> ();

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        List<VisualElement> loadouts = root.Q("Loadouts").Children().ToList();

        int i = 0;
        foreach (VisualElement visualElement in loadouts)
        {
            int temp = i;
            VisualElement load = visualElement.Children().ToList()[0];
            load.Q<Label>("Label").text = "· "+temp+" - "; // TODO: Connect to loadout soul name
            load.RegisterCallback<ClickEvent, int>(LoadLoadout, temp);
            visualElement.Children().ToList()[1].RegisterCallback<ClickEvent, int>(SaveLoadout, temp);
            i++;
        }
    }

    void LoadLoadout(ClickEvent evt,int num)
    {
        JsonHelper.FromJson(File.ReadAllText(Application.persistentDataPath + "/Saves/loadout" + num));
    }
    void SaveLoadout(ClickEvent evt, int num)
    {
        List<Item> temp = new List<Item>(); // TODO: Connect to current loadout
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Saves/loadout" + num, JsonHelper.ToJson(temp));
    }
}
