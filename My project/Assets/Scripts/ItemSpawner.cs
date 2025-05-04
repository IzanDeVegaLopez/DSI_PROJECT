using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSpawner : MonoBehaviour
{
    private void OnEnable()
    {
        /*
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement equipment_menu = root.Q("EquipmentMenu");
        VisualElement selectable_cat = equipment_menu.Q("SelectableCategoriesSpace");
        //Debug.Log(selectable_cat);
        for(int i = 0; i < 4; ++i)
            selectable_cat.Add(new Item());
        VisualElement selectable_it = equipment_menu.Q("SelectableItemsSpace");
        //Debug.Log(selectable_it);
        for (int i = 0; i < 7; ++i)
            selectable_it.Add(new Item());

        VisualElement current_selected = equipment_menu.Q("CurrentSelectedItemMidSpace");
        current_selected.Add(new Item());
        */
    }
}
