using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        Debug.Log(Application.persistentDataPath);
        _iSelector = GetComponent <ItemSelector> ();
        _loadout_load = new List <VisualElement> ();
        _loadout_save = new List <VisualElement> ();

        root = GetComponent<UIDocument>().rootVisualElement;

        List<VisualElement> loadouts = root.Q("Loadouts").Children().ToList();

        int i = 0;
        foreach (VisualElement visualElement in loadouts)
        {
            int num = i;
            SaveData data = new();

            if (!File.Exists(Application.persistentDataPath + "/loadout_" + num + ".json"))
            {
                System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(new SaveData()));
            }

            data = JsonHelper.FromJson(File.ReadAllText(Application.persistentDataPath + "/loadout_" + num + ".json"));
            

            //Debug.Log("soulname: " + data.soulname);
            //Debug.Log("fullname: " + (temp+1).ToString() + " - " + data.soulname);

            visualElement.ElementAt(0).Q<Label>("Label").text = (num + 1).ToString() + " - " + data.soulname; // TODO: Connect to loadout soul name
            visualElement.ElementAt(0).ElementAt(0).RegisterCallback<ClickEvent, int>(LoadLoadout, num);

            visualElement.ElementAt(0).ElementAt(1).RegisterCallback<ClickEvent, int>(SaveLoadout, num);

            visualElement.ElementAt(0).ElementAt(2).RegisterCallback<ClickEvent, int>(DeleteLoadout, num);

            i++;
        }
    }

    void LoadLoadout(ClickEvent evt, int num)
    {
        //Debug.Log("Load");
        if (File.Exists(Application.persistentDataPath + "/loadout_" + num + ".json"))
        {
            SaveData data = JsonHelper.FromJson(File.ReadAllText(Application.persistentDataPath + "/loadout_" + num + ".json"));
            _iSelector.Items = data.items;
            _iSelector.LoadLoadout(data.items);

        }
    }
        void SaveLoadout(ClickEvent evt, int num)
    {
        Debug.Log(num);
        //Debug.Log("Save");
        SaveData data = new();
        data.items = _iSelector.Items; //items[2] for soul
        if (data.items[2] != -1)  data.soulname = _iSelector.Soulname;
        root.Q("Loadouts").ElementAt(num).ElementAt(0).Q<Label>("Label").text = (num + 1).ToString() + " - " + data.soulname;
        Debug.Log(data.soulname);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(data));
    }
    void DeleteLoadout(ClickEvent evt, int num)
    {
        //Debug.Log("Delete");

        root.Q("Loadouts").ElementAt(num).ElementAt(0).Q<Label>("Label").text = (num + 1).ToString() + " - NONE";

        System.IO.File.WriteAllText(Application.persistentDataPath + "/loadout_" + num + ".json", JsonHelper.ToJson(new SaveData()));
    }
}
