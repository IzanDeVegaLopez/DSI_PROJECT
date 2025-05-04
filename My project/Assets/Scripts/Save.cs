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

    // Start is called before the first frame update
    void Start()
    {
        _iSelector = GetComponent<ItemSelector>();
        _loadout_load = new List <VisualElement> ();
        _loadout_save = new List <VisualElement> ();

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        List<VisualElement> loadouts = root.Q("Loadouts").Children().ToList();

        int i = 0;
        foreach (VisualElement visualElement in loadouts)
        {
            int temp = i;
            List<VisualElement> options = visualElement.Children().ToList();

            options[0].Q<Label>("Label").text = temp+" - "; // TODO: Connect to loadout soul name
            options[0].RegisterCallback<ClickEvent, int>(LoadLoadout, temp);

            options[1].RegisterCallback<ClickEvent, int>(SaveLoadout, temp);
            i++;
        }
    }

    void LoadLoadout(ClickEvent evt,int num)
    {
        int[] items = JsonHelper.FromJson(File.ReadAllText(Application.persistentDataPath + "/loadout_" + num + ".json"));
        _iSelector.Items = items;
    }
    void SaveLoadout(ClickEvent evt, int num)
    {
        int[] items = _iSelector.Items;
        System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(items));
    }
}
